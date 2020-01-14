#pragma once

#ifndef WIN32_NO_STATUS
#include <ntstatus.h>
#define WIN32_NO_STATUS
#endif

#include <wincred.h>

#include "helpers.h"

enum GPI_FIELD_ID
{
	GPI_FIELD_ID_TILE_IMAGE = 0,
	GPI_FIELD_ID_LABEL = 1,
	GPI_FIELD_ID_SUBMIT_BUTTON = 2,
	GPI_FIELD_ID_NUM_FIELDS = 3  // Note: keep NUM_FIELDS last.  This is used as a count of the number of fields
};

struct FIELD_STATE_PAIR
{
	CREDENTIAL_PROVIDER_FIELD_STATE cpfs;
	CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE cpfis;
};

struct REPORT_RESULT_STATUS_INFO
{
	NTSTATUS ntsStatus;
	NTSTATUS ntsSubstatus;
	PWSTR     pwzMessage;
	CREDENTIAL_PROVIDER_STATUS_ICON cpsi;
};

static const CREDENTIAL_PROVIDER_FIELD_DESCRIPTOR s_rgCredProvFieldDescriptors[] =
{
	{ GPI_FIELD_ID_TILE_IMAGE,        CPFT_TILE_IMAGE,      L"Image",                            CPFG_CREDENTIAL_PROVIDER_LOGO  },
	{ GPI_FIELD_ID_LABEL,             CPFT_LARGE_TEXT,      L"Login to GamePad Intercepts",      CPFG_CREDENTIAL_PROVIDER_LABEL },
	{ GPI_FIELD_ID_SUBMIT_BUTTON,     CPFT_SUBMIT_BUTTON,   L"Login"                                                            }
};

static const FIELD_STATE_PAIR s_rgFieldStatePairs[] =
{
	{ CPFS_DISPLAY_IN_BOTH,            CPFIS_NONE    },    // SFI_TILEIMAGE
	{ CPFS_DISPLAY_IN_BOTH,            CPFIS_NONE    },    // SFI_LABEL
	{ CPFS_DISPLAY_IN_SELECTED_TILE,   CPFIS_FOCUSED }     // SFI_SUBMIT_BUTTON
};

static const REPORT_RESULT_STATUS_INFO s_rgLogonStatusInfo[] =
{
	{ STATUS_LOGON_FAILURE,        STATUS_SUCCESS,          L"Incorrect password or username.",    CPSI_ERROR, },
	{ STATUS_ACCOUNT_RESTRICTION,  STATUS_ACCOUNT_DISABLED, L"The account is disabled.",           CPSI_WARNING }
};