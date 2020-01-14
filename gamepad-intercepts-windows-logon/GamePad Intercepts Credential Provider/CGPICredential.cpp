#include <unknwn.h>

#include "CGPICredential.h"
#include "clsids.h"
#include "helpers.h"
#include "resource.h"

#import "GamePad Intercepts Authentication Module.tlb" named_guids

CGPICredential::CGPICredential() :
	_cRef(1),
	_pCredProvCredentialEvents(nullptr),
	_pszUserSid(nullptr),
	_pszQualifiedUserName(nullptr),
	_fIsLocalUser(false),
	_fChecked(false),
	_fShowControls(false),
	_dwComboIndex(0)
{
	DllAddRef();

	ZeroMemory(_rgCredProvFieldDescriptors, sizeof(_rgCredProvFieldDescriptors));
	ZeroMemory(_rgFieldStatePairs, sizeof(_rgFieldStatePairs));
	ZeroMemory(_rgFieldStrings, sizeof(_rgFieldStrings));
}

CGPICredential::~CGPICredential()
{
	for (int i = 0; i < ARRAYSIZE(_rgFieldStrings); i++)
	{
		CoTaskMemFree(_rgFieldStrings[i]);
		CoTaskMemFree(_rgCredProvFieldDescriptors[i].pszLabel);
	}

	CoTaskMemFree(_pszUserSid);
	CoTaskMemFree(_pszQualifiedUserName);
	DllRelease();
}


HRESULT CGPICredential::Initialize(CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus,
	_In_ CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR const* rgcpfd,
	_In_ FIELD_STATE_PAIR const* rgfsp,
	_In_ ICredentialProviderUser* pcpUser, CGPICredentialProvider* pGPICredentialProvider)
{
	HRESULT hr = S_OK;
	_cpus = cpus;

	GUID guidProvider;
	pcpUser->GetProviderID(&guidProvider);
	_fIsLocalUser = (guidProvider == Identity_LocalUserProvider);

	// Copy the field descriptors for each field. This is useful if you want to vary the field
	// descriptors based on what Usage scenario the credential was created for.
	for (DWORD i = 0; SUCCEEDED(hr) && i < ARRAYSIZE(_rgCredProvFieldDescriptors); i++)
	{
		_rgFieldStatePairs[i] = rgfsp[i];
		hr = FieldDescriptorCopy(rgcpfd[i], &_rgCredProvFieldDescriptors[i]);
	}

	// Initialize the String value of all the fields.
	if (SUCCEEDED(hr))
	{
		hr = SHStrDupW(L"Login to GamePad Intercepts", &_rgFieldStrings[GPI_FIELD_ID_LABEL]);
	}

	if (SUCCEEDED(hr))
	{
		hr = SHStrDupW(L"Login", &_rgFieldStrings[GPI_FIELD_ID_SUBMIT_BUTTON]);
	}

	if (SUCCEEDED(hr))
	{
		hr = pcpUser->GetStringValue(PKEY_Identity_QualifiedUserName, &_pszQualifiedUserName);
	}
	
	if (SUCCEEDED(hr))
	{
		hr = pcpUser->GetSid(&_pszUserSid);
	}

	_pGPICredentialProvider = pGPICredentialProvider;

	// Some demo code below...
	/*
	PWSTR value;
	pcpUser->GetStringValue(PKEY_Identity_UserName, &value);
	pcpUser->GetStringValue(PKEY_Identity_DisplayName, &value);
	pcpUser->GetStringValue(PKEY_Identity_LogonStatusString, &pszLogonStatus);
	wchar_t szString[256];
	StringCchPrintf(szString, ARRAYSIZE(szString), L"User Name: %s", value);
	hr = SHStrDupW(szString, &_rgFieldStrings[INDEX]);
	CoTaskMemFree(value);
	*/

	return hr;
}

HRESULT CGPICredential::Advise(_In_ ICredentialProviderCredentialEvents* pcpce)
{
	if (_pCredProvCredentialEvents != nullptr)
	{
		_pCredProvCredentialEvents->Release();
	}

	return pcpce->QueryInterface(IID_PPV_ARGS(&_pCredProvCredentialEvents));
}

HRESULT CGPICredential::UnAdvise()
{
	if (_pCredProvCredentialEvents != nullptr)
	{
		_pCredProvCredentialEvents->Release();
	}

	_pCredProvCredentialEvents = nullptr;
	return S_OK;
}

HRESULT CGPICredential::SetSelected(_Out_ BOOL* pbAutoLogon)
{
	*pbAutoLogon = FALSE;
	return S_OK;
}

HRESULT CGPICredential::SetDeselected()
{
	// Demo code to securely clear a password field
	/*
	if (_rgFieldStrings[SFI_PASSWORD])
	{
		size_t lenPassword = wcslen(_rgFieldStrings[SFI_PASSWORD]);
		SecureZeroMemory(_rgFieldStrings[SFI_PASSWORD], lenPassword * sizeof(*_rgFieldStrings[SFI_PASSWORD]));

		CoTaskMemFree(_rgFieldStrings[SFI_PASSWORD]);
		HRESULT hr = SHStrDupW(L"", &_rgFieldStrings[SFI_PASSWORD]);

		if (SUCCEEDED(hr) && _pCredProvCredentialEvents)
		{
			_pCredProvCredentialEvents->SetFieldString(this, SFI_PASSWORD, _rgFieldStrings[SFI_PASSWORD]);
		}
	}
	*/

	return S_OK;
}

HRESULT CGPICredential::GetFieldState(DWORD dwFieldID,
	_Out_ CREDENTIAL_PROVIDER_FIELD_STATE* pcpfs,
	_Out_ CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE* pcpfis)
{
	if ((dwFieldID < ARRAYSIZE(_rgFieldStatePairs)))
	{
		*pcpfs = _rgFieldStatePairs[dwFieldID].cpfs;
		*pcpfis = _rgFieldStatePairs[dwFieldID].cpfis;

		return S_OK;
	}

	return E_INVALIDARG;
}

HRESULT CGPICredential::GetStringValue(DWORD dwFieldID, _Outptr_result_nullonfailure_ PWSTR* ppwsz)
{
	*ppwsz = nullptr;

	if (dwFieldID < ARRAYSIZE(_rgCredProvFieldDescriptors))
	{
		return SHStrDupW(_rgFieldStrings[dwFieldID], ppwsz);
	}

	return E_INVALIDARG;
}

HRESULT CGPICredential::GetBitmapValue(DWORD dwFieldID, _Outptr_result_nullonfailure_ HBITMAP* phbmp)
{
	*phbmp = nullptr;

	if (dwFieldID == GPI_FIELD_ID_TILE_IMAGE)
	{
		HBITMAP hbmp = LoadBitmap(HINST_THISDLL, MAKEINTRESOURCE(IDB_GPI_LOGO));
		
		if (hbmp != nullptr)
		{
			*phbmp = hbmp;
			return S_OK;
		}
	}

	return E_UNEXPECTED;
}

HRESULT CGPICredential::GetSubmitButtonValue(DWORD dwFieldID, _Out_ DWORD* pdwAdjacentTo)
{
	if (dwFieldID == GPI_FIELD_ID_SUBMIT_BUTTON)
	{
		*pdwAdjacentTo = GPI_FIELD_ID_LABEL;
		return S_OK;
	}

	return E_INVALIDARG;
}

HRESULT CGPICredential::SetStringValue(DWORD dwFieldID, _In_ PCWSTR pwz)
{
	return S_OK;
}

HRESULT CGPICredential::GetCheckboxValue(DWORD dwFieldID, _Out_ BOOL* pbChecked, _Outptr_result_nullonfailure_ PWSTR* ppwszLabel)
{
	return S_OK;
}

HRESULT CGPICredential::SetCheckboxValue(DWORD dwFieldID, BOOL bChecked)
{
	return S_OK;
}

HRESULT CGPICredential::GetComboBoxValueCount(DWORD dwFieldID, _Out_ DWORD* pcItems, _Deref_out_range_(< , *pcItems) _Out_ DWORD* pdwSelectedItem)
{
	return S_OK;
}

HRESULT CGPICredential::GetComboBoxValueAt(DWORD dwFieldID, DWORD dwItem, _Outptr_result_nullonfailure_ PWSTR* ppwszItem)
{
	return S_OK;
}

HRESULT CGPICredential::SetComboBoxSelectedValue(DWORD dwFieldID, DWORD dwSelectedItem)
{
	return S_OK;
}

HRESULT CGPICredential::CommandLinkClicked(DWORD dwFieldID)
{
	return S_OK;
}

HRESULT CGPICredential::GetSerialization(_Out_ CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE* pcpgsr,
	_Out_ CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION* pcpcs,
	_Outptr_result_maybenull_ PWSTR* ppwszOptionalStatusText,
	_Out_ CREDENTIAL_PROVIDER_STATUS_ICON* pcpsiOptionalStatusIcon)
{
	HRESULT hr = E_UNEXPECTED;
	*pcpgsr = CPGSR_NO_CREDENTIAL_NOT_FINISHED;
	*ppwszOptionalStatusText = nullptr;
	*pcpsiOptionalStatusIcon = CPSI_NONE;
	ZeroMemory(pcpcs, sizeof(*pcpcs));

	// For local user, the domain and user name can be split from _pszQualifiedUserName (domain\username).
	// CredPackAuthenticationBuffer() cannot be used because it won't work with unlock scenario.
	if (_fIsLocalUser)
	{
		PWSTR pwzProtectedPassword;
		//hr = ProtectIfNecessaryAndCopyPassword(_rgFieldStrings[SFI_PASSWORD], _cpus, &pwzProtectedPassword);
		hr = ProtectIfNecessaryAndCopyPassword(L"", _cpus, &pwzProtectedPassword);
		if (SUCCEEDED(hr))
		{
			PWSTR pszDomain;
			PWSTR pszUsername;
			hr = SplitDomainAndUsername(_pszQualifiedUserName, &pszDomain, &pszUsername);
			if (SUCCEEDED(hr))
			{
				KERB_INTERACTIVE_UNLOCK_LOGON kiul;
				hr = KerbInteractiveUnlockLogonInit(pszDomain, pszUsername, pwzProtectedPassword, _cpus, &kiul);
				if (SUCCEEDED(hr))
				{
					// We use KERB_INTERACTIVE_UNLOCK_LOGON in both unlock and logon scenarios.  It contains a
					// KERB_INTERACTIVE_LOGON to hold the creds plus a LUID that is filled in for us by Winlogon
					// as necessary.
					hr = KerbInteractiveUnlockLogonPack(kiul, &pcpcs->rgbSerialization, &pcpcs->cbSerialization);
					if (SUCCEEDED(hr))
					{
						ULONG ulAuthPackage;
						hr = RetrieveNegotiateAuthPackage(&ulAuthPackage);
						if (SUCCEEDED(hr))
						{
							pcpcs->ulAuthenticationPackage = ulAuthPackage;
							pcpcs->clsidCredentialProvider = CLSID_CGamePadIntercepts;

							HWND hwnd;
							_pCredProvCredentialEvents->OnCreatingWindow(&hwnd);

							if (_pGPICredentialProvider->IsGPIAuthModuleReady())
							{
								VARIANT_BOOL vbIsAuthenticated = VARIANT_FALSE;
								_pGPICredentialProvider->GetGPIAuthModulePtr()->Authenticate((LONG_PTR)hwnd, &pszUsername, &vbIsAuthenticated);

								*pcpgsr = (vbIsAuthenticated == VARIANT_TRUE) ? CPGSR_RETURN_CREDENTIAL_FINISHED : CPGSR_NO_CREDENTIAL_FINISHED;
							}
							else
							{
								*pcpgsr = CPGSR_NO_CREDENTIAL_FINISHED;
							}
						}
					}
				}
				CoTaskMemFree(pszDomain);
				CoTaskMemFree(pszUsername);
			}
			CoTaskMemFree(pwzProtectedPassword);
		}
	}

	return hr;
}

// ReportResult is completely optional.  Its purpose is to allow a credential to customize the string
// and the icon displayed in the case of a logon failure.  For example, we have chosen to
// customize the error shown in the case of bad username/password and in the case of the account
// being disabled.
HRESULT CGPICredential::ReportResult(NTSTATUS ntsStatus,
	NTSTATUS ntsSubstatus,
	_Outptr_result_maybenull_ PWSTR* ppwszOptionalStatusText,
	_Out_ CREDENTIAL_PROVIDER_STATUS_ICON* pcpsiOptionalStatusIcon)
{
	*ppwszOptionalStatusText = nullptr;
	*pcpsiOptionalStatusIcon = CPSI_NONE;

	DWORD dwStatusInfo = (DWORD)-1;

	// Look for a match on status and substatus.
	for (DWORD i = 0; i < ARRAYSIZE(s_rgLogonStatusInfo); i++)
	{
		if (s_rgLogonStatusInfo[i].ntsStatus == ntsStatus && s_rgLogonStatusInfo[i].ntsSubstatus == ntsSubstatus)
		{
			dwStatusInfo = i;
			break;
		}
	}

	if ((DWORD)-1 != dwStatusInfo)
	{
		if (SUCCEEDED(SHStrDupW(s_rgLogonStatusInfo[dwStatusInfo].pwzMessage, ppwszOptionalStatusText)))
		{
			*pcpsiOptionalStatusIcon = s_rgLogonStatusInfo[dwStatusInfo].cpsi;
		}
	}

	// If we failed the logon, try to erase the password field.
	if (FAILED(HRESULT_FROM_NT(ntsStatus)))
	{
		if (_pCredProvCredentialEvents)
		{
			//_pCredProvCredentialEvents->SetFieldString(this, SFI_PASSWORD, L"");
		}
	}

	// Since nullptr is a valid value for *ppwszOptionalStatusText and *pcpsiOptionalStatusIcon
	// this function can't fail.
	return S_OK;
}

HRESULT CGPICredential::GetUserSid(_Outptr_result_nullonfailure_ PWSTR* ppszSid)
{
	*ppszSid = nullptr;

	if (_pszUserSid != nullptr)
	{
		return SHStrDupW(_pszUserSid, ppszSid);
	}
	
	// NOTE: Return S_FALSE with a null SID in ppszSid for the credential to be associated with an empty user tile.

	return E_UNEXPECTED;
}

HRESULT CGPICredential::GetFieldOptions(DWORD dwFieldID, _Out_ CREDENTIAL_PROVIDER_CREDENTIAL_FIELD_OPTIONS* pcpcfo)
{
	*pcpcfo = CPCFO_NONE;

	if (dwFieldID == GPI_FIELD_ID_TILE_IMAGE)
	{
		*pcpcfo = CPCFO_ENABLE_TOUCH_KEYBOARD_AUTO_INVOKE;
	}

	return S_OK;
}