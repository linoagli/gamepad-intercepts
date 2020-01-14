#pragma once

#include <windows.h>
#include <strsafe.h>
#include <new>

#include "helpers.h"

#import "GamePad Intercepts Authentication Module.tlb" named_guids

class CGPICredential;
class CGPICredentialProvider : public ICredentialProvider, public ICredentialProviderSetUserArray
{
public:
	// IUnknown
	IFACEMETHODIMP_(ULONG) AddRef()
	{
		return ++_cRef;
	}

	IFACEMETHODIMP_(ULONG) Release()
	{
		long cRef = --_cRef;
		if (!cRef)
		{
			delete this;
		}
		return cRef;
	}

	IFACEMETHODIMP QueryInterface(_In_ REFIID riid, _COM_Outptr_ void** ppv)
	{
		static const QITAB qit[] =
		{
			QITABENT(CGPICredentialProvider, ICredentialProvider), // IID_ICredentialProvider
			QITABENT(CGPICredentialProvider, ICredentialProviderSetUserArray), // IID_ICredentialProviderSetUserArray
			{0},
		};
		return QISearch(this, qit, riid, ppv);
	}

public:
	friend HRESULT CGPI_CreateInstance(_In_ REFIID riid, _Outptr_ void** ppv);

public:
	IFACEMETHODIMP SetUsageScenario(CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, DWORD dwFlags);
	IFACEMETHODIMP SetSerialization(_In_ CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION const* pcpcs);
	IFACEMETHODIMP Advise(_In_ ICredentialProviderEvents* pcpe, _In_ UINT_PTR upAdviseContext);
	IFACEMETHODIMP UnAdvise();
	IFACEMETHODIMP GetFieldDescriptorCount(_Out_ DWORD* pdwCount);
	IFACEMETHODIMP GetFieldDescriptorAt(DWORD dwIndex, _Outptr_result_nullonfailure_ CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR** ppcpfd);
	IFACEMETHODIMP GetCredentialCount(_Out_ DWORD* pdwCount, _Out_ DWORD* pdwDefault, _Out_ BOOL* pbAutoLogonWithDefault);
	IFACEMETHODIMP GetCredentialAt(DWORD dwIndex, _Outptr_result_nullonfailure_ ICredentialProviderCredential** ppcpc);
	IFACEMETHODIMP SetUserArray(_In_ ICredentialProviderUserArray* users);

protected:
	CGPICredentialProvider();
	__override ~CGPICredentialProvider();

private:
	long _cRef;

	CGPICredential* _pCredential;
	ICredentialProviderUserArray* _pCredProviderUserArray;

	bool  _fRecreateEnumeratedCredentials;
	CREDENTIAL_PROVIDER_USAGE_SCENARIO _cpus;

	GamePad_Intercepts_Authentication_Module::IGamePadInterceptsAuthenticationModulePtr _pGPIAuthModulePtr;

public:
	bool IsGPIAuthModuleReady();
	GamePad_Intercepts_Authentication_Module::IGamePadInterceptsAuthenticationModulePtr GetGPIAuthModulePtr();

private:
	void _ReleaseEnumeratedCredentials();
	void _CreateEnumeratedCredentials();
	HRESULT _EnumerateCredentials();
};

