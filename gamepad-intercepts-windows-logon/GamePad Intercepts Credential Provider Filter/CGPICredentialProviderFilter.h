#pragma once

#include <credentialprovider.h>
#include <windows.h>
#include <strsafe.h>

#include "dll.h"
#include "helpers.h"

class CGPICredentialProviderFilter : public ICredentialProviderFilter
{
protected:
	CGPICredentialProviderFilter();
	__override ~CGPICredentialProviderFilter();

public:
	IFACEMETHODIMP_(ULONG) AddRef()
	{
		return ++_cRef;
	}

	IFACEMETHODIMP_(ULONG) Release()
	{
		LONG cRef = --_cRef;
		if (!cRef)
		{
			delete this;
		}
		return cRef;
	}

	IFACEMETHODIMP QueryInterface(__in REFIID riid, __deref_out void** ppv)
	{
		static const QITAB qit[] =
		{
			QITABENT(CGPICredentialProviderFilter, ICredentialProviderFilter), // IID_ICredentialProviderFilter
			{0},
		};
		return QISearch(this, qit, riid, ppv);
	}

public:
	IFACEMETHODIMP Filter(CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, DWORD dwFlags, GUID* rgclsidProviders, BOOL* rgbAllow, DWORD cProviders);
	IFACEMETHODIMP UpdateRemoteCredential(const CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION* pcpcsIn, CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION* pcpcsOut);

public:
	friend HRESULT CGPI_CreateInstance(__in REFIID riid, __deref_out void** ppv);

private:
	LONG _cRef;
};

