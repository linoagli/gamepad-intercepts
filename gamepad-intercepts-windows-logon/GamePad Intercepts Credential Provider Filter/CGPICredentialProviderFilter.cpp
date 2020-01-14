#include <time.h>
#include <string>

#include "CGPICredentialProviderFilter.h"
#include "clsids.h"

CGPICredentialProviderFilter::CGPICredentialProviderFilter() :
	_cRef(1)
{
	DllAddRef();
}

CGPICredentialProviderFilter::~CGPICredentialProviderFilter()
{
	DllRelease();
}

HRESULT CGPICredentialProviderFilter::Filter(CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, DWORD dwFlags, GUID* rgclsidProviders, BOOL* rgbAllow, DWORD cProviders)
{
	switch (cpus)
	{
	case CPUS_LOGON:
	{
		for (DWORD i = 0; i < cProviders; i++)
		{
			rgbAllow[i] = (IsEqualGUID(rgclsidProviders[i], CLSID_CGamePadIntercepts)) ? TRUE : FALSE;
		}

		return S_OK;
	}

	case CPUS_UNLOCK_WORKSTATION:
	case CPUS_CREDUI:
	case CPUS_CHANGE_PASSWORD:
		return E_NOTIMPL;
	default:
		return E_INVALIDARG;
	}
}

HRESULT CGPICredentialProviderFilter::UpdateRemoteCredential(const CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION* pcpsIn, CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION* pcpcsOut)
{
	pcpcsOut->ulAuthenticationPackage = pcpsIn->ulAuthenticationPackage;
	pcpcsOut->clsidCredentialProvider = CLSID_CGamePadIntercepts;
	pcpcsOut->cbSerialization = pcpsIn->cbSerialization;

	if (pcpsIn->cbSerialization > 0)
	{
		pcpcsOut->rgbSerialization = (byte*)CoTaskMemAlloc(pcpsIn->cbSerialization);

		if (pcpcsOut->rgbSerialization == NULL)
		{
			return E_OUTOFMEMORY;
		}

		CopyMemory(pcpcsOut->rgbSerialization, pcpsIn->rgbSerialization, pcpsIn->cbSerialization);
	}

	return S_OK;
}

HRESULT CGPI_CreateInstance(__in REFIID riid, __deref_out void** ppv)
{
	HRESULT hr;

	CGPICredentialProviderFilter* pProvider = new CGPICredentialProviderFilter();

	if (pProvider)
	{
		hr = pProvider->QueryInterface(riid, ppv);
		pProvider->Release();
	}
	else
	{
		hr = E_OUTOFMEMORY;
	}

	return hr;
}