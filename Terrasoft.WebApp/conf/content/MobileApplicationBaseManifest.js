Terrasoft.configuration.Structures["MobileApplicationBaseManifest"] = {innerHierarchyStack: ["MobileApplicationBaseManifestCrtMobile7x", "MobileApplicationBaseManifestCrtMobileFreedomUIStylesFor7x", "MobileApplicationBaseManifestMobile", "MobileApplicationBaseManifest"]};
define('MobileApplicationBaseManifestCrtMobileFreedomUIStylesFor7xStructure', ['MobileApplicationBaseManifestCrtMobileFreedomUIStylesFor7xResources'], function(resources) {return {schemaUId:'1363cb94-e4d6-4633-8c8b-c19a18ec38fa',schemaCaption: "MobileApplicationBaseManifest", parentSchemaName: "", packageName: "CrtESN7x", schemaName:'MobileApplicationBaseManifestCrtMobileFreedomUIStylesFor7x',parentSchemaUId:'faeb77cb-89d6-4cf8-913c-3a9f16e5fdfd',extendParent:true,type:Terrasoft.SchemaType.NONE,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schemaDifferences:function(){

}};});
define('MobileApplicationBaseManifestMobileStructure', ['MobileApplicationBaseManifestMobileResources'], function(resources) {return {schemaUId:'d15d0fd4-24ad-4a47-9d66-5a78a26847ea',schemaCaption: "MobileApplicationBaseManifest", parentSchemaName: "MobileApplicationBaseManifestCrtMobileFreedomUIStylesFor7x", packageName: "CrtESN7x", schemaName:'MobileApplicationBaseManifestMobile',parentSchemaUId:'1363cb94-e4d6-4633-8c8b-c19a18ec38fa',extendParent:true,type:Terrasoft.SchemaType.NONE,entitySchema:'',name:'',extend:"MobileApplicationBaseManifestCrtMobileFreedomUIStylesFor7x",schemaDifferences:function(){

}};});
define('MobileApplicationBaseManifestStructure', ['MobileApplicationBaseManifestResources'], function(resources) {return {schemaUId:'7d94f51d-52be-4836-abf4-5708a1cec6eb',schemaCaption: "MobileApplicationBaseManifest", parentSchemaName: "MobileApplicationBaseManifestMobile", packageName: "CrtESN7x", schemaName:'MobileApplicationBaseManifest',parentSchemaUId:'d15d0fd4-24ad-4a47-9d66-5a78a26847ea',extendParent:true,type:Terrasoft.SchemaType.NONE,entitySchema:'',name:'',extend:"MobileApplicationBaseManifestMobile",schemaDifferences:function(){

}};});
define('MobileApplicationBaseManifestCrtMobile7xResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
 {
	"Features": {
		"UseMobileCallerId": {
			"CustomSchemas": [
				"MobileCallerIdDataLoader"
			],
			"SyncOptions": {
				"ModelDataImportConfig": [
					{
						"Name": "DialingCode",
						"SyncColumns": [
							"Country",
							"Code",
							"TrunkPrefix"
						]
					},
					{
						"Name": "Employee",
						"SyncColumns": [
							"Contact"
						]
					}
				]
			},
			"ApplicationRequiredModels": ["DialingCode", "Employee"]
		},
		"UseMobileFolders": {
			"CustomSchemas": [
				"MobileFoldersData",
				"MobileFoldersStore"
			],
			"ApplicationRequiredModels": ["BaseFolder", "FolderType"]
		},
		"UseMobileDynamicLink": {
			"CustomSchemas": [
				"MobileDynamicLinkReceiver"
			],
			"ApplicationRequiredModels": ["VwModuleEditInfo"]
		},
		"UseMobileSummaries": {
			"CustomSchemas": [
				"MobileSummariesData"
			]
		}
	},
	"UseOptimisticEditing": true,
	"PreferredFilterFuncType": "Terrasoft.FilterFunctions.SubStringOf",
	"UseUTC": true,
	"ModuleGroups": {
		"main": {
			"Position": 0
		},
		"sales": {
			"Position": 1
		}
	},
	"DefaultModuleImageId": "MobileImageListDefaultModuleImage",
	"DefaultModuleImageIdV2": "MobileImageListDefaultModuleImageV2",
	"CustomSchemas": [
		"MobileImageList",
		"MobileCss",
		"MobileUtilities",
		"MobileConstants",
		"MobileDashboardEnums",
		"MobileDashboardUtils",
		"MobileDashboardContainer",
		"MobileServiceHelper",
		"MobileAnalyticsService",
		"MobileAnalyticsServiceResponseParser",
		"MobileAnalyticsServiceGridDataProxy",
		"MobileDashboardViewGenerator",
		"MobileDashboardDataManager",
		"MobileBaseDashboardItemConfigGenerator",
		"MobileBaseDashboardItem",
		"MobileIndicatorDashboardConfigGenerator",
		"MobileIndicatorDashboardComponent",
		"MobileIndicatorDashboardItem",
		"MobileGridDashboardItem",
		"MobileChartDashboardItemConfigGenerator",
		"MobileChartDashboardItem",
		"MobilePushNotificationReceiver",
		"MobileLookupGridPageConfig",
		"MobilePhoneCallLogPage",
		"MobilePhoneCallLogUtils",
		"BaseLocalNotificationManager",
		"MobileLocalNotificationManager",
		"MobileEditPageController",
		"MobileFileAndLinksPreviewControllerV2",
		"MobileFileAndLinksEditControllerV2",
		"MobileFileAndLinksBusinessRule",
		"MobileFileAndLinksEmbeddedDetailGenerator",
		"MobilePortalMessagePublisherPage",
		"MobileActionAddFileAndLinks",
		"MobileOpenStandardDetailAction",
		"MobileOpenPortalMessagePublisherPageAction",
		"MobileFileService",
		"MobileFileServiceProvider",
		"MobileActionShareLink",
		"MobileVisaEmbeddedDetailGenerator",
		"MobileVisaEmbeddedDetailItem",
		"MobileVisaActions"
	],
	"SyncOptions": {
		"ImportPageSize": 1000,
		"PagesInImportTransaction": 5,
		"UseBatchExport": true,
		"UseSkipToken": true,
		"SysSettingsImportConfig": [
			"PrimaryCulture",
			"MobileApplicationMode",
			"CollectMobileAppUsageStatistics",
			"CanCollectMobileUsageStatistics",
			"MobileAppUsageStatisticsEmail",
			"MobileAppUsageStatisticsStorePeriod",
			"MobileSectionsWithSearchOnly",
			"MobileShowMenuOnApplicationStart",
			"MobileAppCheckUpdatePeriod",
			"ShowMobileLocalNotifications",
			"MobileLogoImage",
			"RunMobileSyncInService",
			"NotifyMobileUserAboutAppUpdate",
			"EnableMobileErrorLog",
			"MobileDataSyncFrequency",
			"MobileTrackLocationFrequency",
			"UseMobileLastKnownLocation",
			"UseMobileCertificateAuthentication",
			"MobileEmailForPermissionRequests",
			"MobileAmplitudeApiKey",
			"DataServiceQueryTimeout",
			"MaxFileSize",
			"MaxImageSize",
			"FileExtensionsAllowList",
			"CrtBackgroundConfig",
			"MobileBusinessRulesMode",
			"EnableMobilePasswordUnmasking",
			"CreatioAIAllowedFileExtensions",
			"CreatioAIMaxSessionFileSize"
		],
		"SysLookupsImportConfig": [
			"AddressType",
			"CommunicationType",
			"AnniversaryType",
			"InformationSource",
			"FileType",
			"CallDirection",
			"VisaStatus",
			"CopilotIntentStatus"
		],
		"OfflineSyncRules": ["ApprovalModule", "NotificationsModule"],
		"SyncRules": {
			"ApprovalModule": {
				"importOptions": {
					"adapterType": "Approval"
				}
			},
			"NotificationsModule": {
				"runType": 1,
				"importOptions": {
					"adapterType": "Entity",
					"entityName": "MobileNotificationLog",
					"columns": [
						"Title",
						"Message",
						"AdditionalData"
					],
					"filters": {
						"logicalOperation": 0,
						"filterType": 6,
						"rootSchemaName": "MobileNotificationLog",
						"items": {
							"TypeFilter": {
								"filterType": 1,
								"rightExpression": {
									"expressionType": 1,
									"functionType": 1,
									"macrosType": 1
								},
								"leftExpression": {
									"expressionType": 0, 
									"columnPath": "SysAdminUnitId"
								},
								"comparisonType": 3
							}
						}
					}
				}
			}
		},
		"ModelDataImportConfig": [
			{
				"Name": "VwSysEntitySchemaInWorkspace",
				"Position": 0
			},
			{
				"Name": "SysAdminUnit",
				"ExpandLookups": true,
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "SysAdminUnit",
					"logicalOperation": 0,
					"items": {
						"CurrentContact": {
							"filterType": 1,
							"comparisonType": 3,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Contact"
							},
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							}
						}
					}
				},
				"SyncColumns": [
					"Contact",
					"Account",
					"SysAdminUnitTypeValue",
					"Active",
					"ConnectionType"
				]
			},
			{
				"Name": "Contact",
				"ExpandLookups": true,
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "Contact",
					"logicalOperation": 0,
					"items": {
						"CurrentContact": {
							"filterType": 1,
							"comparisonType": 3,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Id"
							},
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							}
						}
					}
				},
				"SyncColumns": [
					"Name",
					"Account",
					"Department",
					"JobTitle",
					"Photo",
					"Job",
					"GivenName"
				]
			},
			{
				"Name": "SysImage",
				"SyncFilter": {
					"property": "HasRef",
					"value": true
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "SysImage",
					"items": {
						"ExistContactPhoto": {
							"filterType": 5,
							"comparisonType": 15,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "[Contact:Photo].Id"
							},
							"subFilters": {
								"items": {},
								"logicalOperation": 0,
								"filterType": 6,
								"rootSchemaName": "Contact",
								"key": "069e89d5-96d6-4268-a4ae-93fd7f97f3e4"
							}
						}
					}
				},
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "SysImage",
					"logicalOperation": 0,
					"items": {
						"CurrentContact": {
							"filterType": 1,
							"comparisonType": 3,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "[Contact:Photo].Id"
							},
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							}
						}
					}
				},
				"SyncColumns": [
					"Name",
					"HasRef",
					{
						"Name": "PreviewData",
						"UseRecordIdAsFileName": true,
						"ImportBinaryData": true
					}
				]
			},
			{
				"Name": "VwRemindings",
				"SyncFilter": {
					"property": "Contact",
					"valueIsMacros": true,
					"value": "Terrasoft.ValueMacros.CurrentUserContact"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "VwRemindings",
					"items": {
						"ContactCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Contact"
							},
							"comparisonType": 3
						}
					}
				}
			}, 
			{
				"Name": "CallDirection"
			},
			{
				"Name": "VisaStatus",
				"SyncColumns": [
					"IsFinal"
				]
			},
			{
				"Name": "VwModuleEditInfo",
				"SyncColumns": [
					"Name",
					"ModuleCode"
				],
				"RequiredDataFilter": {
					"filterType": 6,
					"rootSchemaName": "VwModuleEditInfo",
					"logicalOperation": 0,
					"items": {
						"Module": {
							"comparisonType": 4,
							"filterType": 1,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "ModuleCode"
							},
							"rightExpression": {
								"expressionType": 2,
								"parameter": {
									"dataValueType": 1,
									"value": ""
								}
							}
						}
					}
				}
			}
		]
	},
	"Modules": {
		"Contact": {
			"Group": "main",
			"Model": "Contact",
			"Position": 0,
			"Title": "ContactSectionTitle",
			"Icon": {
				"ImageId": "MobileImageListContactModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListContactModuleImageV2"
			},
			"Hidden": true
		},
		"Account": {
			"Group": "main",
			"Model": "Account",
			"Position": 1,
			"Title": "AccountSectionTitle",
			"Icon": {
				"ImageId": "MobileImageListAccountModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListAccountModuleImageV2"
			},
			"Hidden": true
		},
		"Activity": {
			"Group": "main",
			"Model": "Activity",
			"Position": 2,
			"Title": "ActivitySectionTitle",
			"Icon": {
				"ImageId": "MobileImageListActivityModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListActivityModuleImageV2"
			},
			"Hidden": true
		},
		"Contract": {
			"Group": "main",
			"Model": "Contract",
			"Icon": {
				"ImageId": "MobileImageListContractModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListContractModuleImageV2"
			},
			"Hidden": true
		},
		"Document": {
			"Group": "main",
			"Model": "Document",
			"Icon": {
				"ImageId": "MobileImageListDocumentModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListDocumentModuleImageV2"
			},
			"Hidden": true
		},
		"Order": {
			"Group": "main",
			"Model": "Order",
			"Icon": {
				"ImageId": "MobileImageListOrderModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListOrderModuleImageV2"
			},
			"Hidden": true
		},
		"Forecast": {
			"Group": "main",
			"Model": "Forecast",
			"Icon": {
				"ImageId": "MobileImageListPlanningModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListPlanningModuleImageV2"
			},
			"Hidden": true
		},
		"Product": {
			"Group": "main",
			"Model": "Product",
			"Icon": {
				"ImageId": "MobileImageListProductModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListProductModuleImageV2"
			},
			"Hidden": true
		},
		"Project": {
			"Group": "main",
			"Model": "Project",
			"Icon": {
				"ImageId": "MobileImageListProjectModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListProjectModuleImageV2"
			},
			"Hidden": true
		},
		"Invoice": {
			"Group": "main",
			"Model": "Invoice",
			"Icon": {
				"ImageId": "MobileImageListInvoiceModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListInvoiceModuleImageV2"
			},
			"Hidden": true
		},
		"Request": {
			"Group": "main",
			"Model": "Request",
			"Icon": {
				"ImageId": "MobileImageListRequestModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListRequestModuleImageV2"
			},
			"Hidden": true
		},
		"Listing": {
			"Group": "main",
			"Model": "Listing",
			"Icon": {
				"ImageId": "MobileImageListListingModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListListingModuleImageV2"
			},
			"Hidden": true
		},
		"SocialMessage": {
			"Group": "main",
			"Model": "SocialMessage",
			"Icon": {
				"ImageId": "MobileImageListFeedModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListFeedModuleImageV2"
			},
			"Hidden": true
		},
		"ConfItem": {
			"Group": "main",
			"Model": "ConfItem",
			"Icon": {
				"ImageId": "MobileImageListConfigurationModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListConfigurationModuleImageV2"
			},
			"Hidden": true
		},
		"Case": {
			"Group": "main",
			"Model": "Case",
			"Icon": {
				"ImageId": "MobileImageListTreatmentModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListTreatmentModuleImageV2"
			},
			"Hidden": true
		},
		"Problem": {
			"Group": "main",
			"Model": "Problem",
			"Icon": {
				"ImageId": "MobileImageListProblemModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListProblemModuleImageV2"
			},
			"Hidden": true
		},
		"ServicePact": {
			"Group": "main",
			"Model": "ServicePact",
			"Icon": {
				"ImageId": "MobileImageListServiceContractModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListServiceContractModuleImageV2"
			},
			"Hidden": true
		},
		"ServiceItem": {
			"Group": "main",
			"Model": "ServiceItem",
			"Icon": {
				"ImageId": "MobileImageListServiceModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListServiceModuleImageV2"
			},
			"Hidden": true
		},
		"Campaign": {
			"Group": "main",
			"Model": "Campaign",
			"Icon": {
				"ImageId": "MobileImageListCampaignModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListCampaignModuleImageV2"
			},
			"Hidden": true
		},
		"KnowledgeBase": {
			"Group": "main",
			"Model": "KnowledgeBase",
			"Icon": {
				"ImageId": "MobileImageListKnowledgeBaseModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListKnowledgeBaseModuleImageV2"
			},
			"Title": "KnowledgeBaseSectionTitle",
			"Hidden": true
		},
		"BulkEmail": {
			"Group": "main",
			"Model": "BulkEmail",
			"Icon": {
				"ImageId": "MobileImageListEmailModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListEmailModuleImageV2"
			},
			"Hidden": true
		},
		"Event": {
			"Group": "main",
			"Model": "Event",
			"Icon": {
				"ImageId": "MobileImageListActionModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListActionModuleImageV2"
			},
			"Hidden": true
		},
		"SocialSubscription": {
			"Group": "main",
			"Model": "SocialSubscription",
			"Icon": {
				"ImageId": "MobileImageListSubscriptionModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListSubscriptionModuleImageV2"
			},
			"Hidden": true
		},
		"Lead": {
			"Group": "main",
			"Model": "Lead",
			"Icon": {
				"ImageId": "MobileImageListLeadModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListLeadModuleImageV2"
			},
			"Hidden": true
		},
		"Opportunity": {
			"Group": "main",
			"Model": "Opportunity",
			"Icon": {
				"ImageId": "MobileImageListOpportunityModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListOpportunityModuleImageV2"
			},
			"Hidden": true
		},
		"SysDashboard": {
			"Group": "main",
			"Model": "SysDashboard",
			"Position": 6,
			"Title": "DashboardSectionTitle",
			"Icon": {
				"ImageId": "MobileImageListDashboardModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListDashboardModuleImageV2"
			},
			"Hidden": true,
			"sysModuleCode": "Dashboard"
		},
		"Approval": {
			"Group": "main",
			"Model": "Approval",
			"Position": 7,
			"Title": "ApprovalSectionTitle",
			"IconV2": {
				"ImageId": "MobileImageListApprovalModuleImage"
			},
			"Hidden": true,
			"screens": {
				"start": {
					"screenName": "ApprovalsScreen"
				}
			},
			"syncRules": ["ApprovalModule"],
			"iconId": "92311908-1a2a-4d35-a8df-15bd03cb1895",
			"backgroundColor": "#0091EA"
		}
	},
	"Models": {
		"SysDashboard": {
			"CacheConfig": {
				"Disable": true
			},
			"RequiredModels": [
				"SysDashboard",
				"SysModule"
			],
			"Grid": "MobileDashboardPage",
			"PagesExtensions": [
				"MobileDashboardPageView",
				"MobileDashboardPageController",
				"MobileDashboardItemPageView",
				"MobileDashboardItemPageController",
				"MobileChartDashboardItemPageView",
				"MobileChartDashboardItemPageController",
				"MobileIndicatorDashboardItemPageView",
				"MobileIndicatorDashboardItemPageController"
			]
		},
		"LocationHistory": {
			"RequiredModels": [
				"LocationHistory"
			],
			"Autoclear": true
		},
		"VisaStatus": {
			"RequiredModels": [
				"VisaStatus"
			]
		},
		"MobileNotificationLog": {
			"RequiredModels": [
				"MobileNotificationLog"
			]
		}
	},
	"ApplicationRequiredModels": [
		"SysImage",
		"SysAdminUnit","SysAdminUnitInRole", 
		"SysSchema", "VwSysEntitySchemaInWorkspace",
		"SysModule",
		"VwRemindings",
		"DuplicatesHistory",
		"Contact", "Account",
		"Communication", "ComTypebyCommunication", "CommunicationType",
		"UserConsentHistory", "Consent", "CopilotAgent", "CreatioAISessionFile"
	]
}

define('MobileApplicationBaseManifestCrtMobileFreedomUIStylesFor7xResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
{
  "Features": {
    "Mobile.UseFreedomUIStylesFor7x": {    
      "CustomSchemas": [
          "MobileFreedomUIStylesUtils",
          "MobileCommonFreedomUIStyles",
          "MobileFieldForceFreedomUIStyles"
      ],
      "Models": {
		"Activity": {
          "PagesExtensions": [
            "MobileActivityFreedomUIStyles"
          ]
        },
		"SysDashboard": {
          "PagesExtensions": [
            "MobileDashboardFreedomUIStyles"
          ]
        },
         "SocialMessage": {
          "PagesExtensions": [
            "MobileFeedFreedomUIStyles"
          ]
        }
      }
    },
    "Mobile.UseDashboardsFreedomUIStylesFor7x": { 
      "CustomSchemas": [
          "MobileFreedomUIStylesUtils"
      ],
      "Models": {
		"SysDashboard": {
          "PagesExtensions": [
            "MobileDashboardFreedomUIStyles"
          ]
        }
      }
    }
  }
}
define('MobileApplicationBaseManifestMobileResources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
{
	"SyncOptions": {
		"SysSettingsImportConfig": [
			"PrimaryCurrency",
			"SchedulerTimingStart",
			"SchedulerTimingEnd"
		],
		"SysLookupsImportConfig": [
			"ActivityCategory",
			"ActivityPriority",
			"ActivityResult",
			"ActivityResultCategory",
			"ActivityStatus",
			"ActivityType",
			"ActivityCategoryResultEntry",
			"ActivityParticipantRole",
			"AccountType",
			"AccountCategory"
		],
		"SyncRules": {
			"EmployeeLookup": {
				"importOptions": {
					"entityName": "Contact",
					"adapterType": "Entity",
					"useLastSyncDate": false,
					"dependencies": [
						{
							"importOptions": {
								"entityName": "SysAdminUnit",
								"adapterType": "Entity"
							},
							"deleteNonExistentRecords": false,
							"masterColumn": "Id",
							"detailColumn": "Contact"
						}
					]
				}
			}
		}
	}
}
{
	"CustomSchemas": [
		"MobileSocialMessageUtilities",
		"MobileFeedList",
		"MobileFeedCommentsList",
		"MobileSocialMessageHtmlField"
	],
	"SyncOptions": {
		"SysSettingsImportConfig": [],
		"SysLookupsImportConfig": [
			"SocialChannel",
			"VwMobileSysSchema"
		],
		"ModelDataImportConfig": [
			"SocialChannel",
			"SocialLike",
			{
				"Name": "VwSocialSubscription",
				"SyncFilter": {
					"property": "SysAdminUnit",
					"valueIsMacros": true,
					"value": "Terrasoft.ValueMacros.CurrentUser"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "VwSocialSubscription",
					"items": {
						"SysAdminUnitCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 1
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "SysAdminUnit"
							},
							"comparisonType": 3
						}
					}
				}
			},
			{
				"Name": "VwSocialUnsubscription",
				"SyncFilter": {
					"property": "SysAdminUnit",
					"valueIsMacros": true,
					"value": "Terrasoft.ValueMacros.CurrentUser"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "VwSocialUnsubscription",
					"items": {
						"SysAdminUnitCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 1
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "SysAdminUnit"
							},
							"comparisonType": 3
						}
					}
				}
			},
			"VwMobileSysSchema",
			{
				"Name": "SocialMessage",
				"SyncColumns": [
					"CreatedBy",
					"Message",
					"Parent",
					"EntityId",
					"EntitySchemaUId",
					"LikeCount",
					"CommentCount"
				]
			},
			{
				"Name": "SysImage",
				"SyncFilter": {
					"property": "HasRef",
					"value": true
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "SysImage",
					"items": {
						"ExistContactPhoto": {
							"filterType": 5,
							"comparisonType": 15,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "[Contact:Photo].Id"
							},
							"subFilters": {
								"items": {},
								"logicalOperation": 0,
								"filterType": 6,
								"rootSchemaName": "Contact",
								"key": "069e89d5-96d6-4268-a4ae-93fd7f97f3e4"
							}
						}
					}
				},
				"SyncColumns": [
					"Name",
					"HasRef",
					{
						"Name": "PreviewData",
						"UseRecordIdAsFileName": true,
						"ImportBinaryData": true
					}
				]
			},
			{
				"Name": "Contact",
				"SyncColumns": [
					"Photo"
				]
			}
		],
		"ModelDataExportConfig": [
			{
				"Name": "SocialLike",
				"IgnoreSplitLogActions": true
			},
			{
				"Name": "SocialMessage",
				"IgnoreSplitLogActions": true
			},
			{
				"Name": "SocialMention",
				"IgnoreSplitLogActions": true
			}
		]
	},
	"Modules": {
		"SocialMessage": {
			"Title": "SocialMessageSectionTitle",
			"sysModuleCode": "ESNFeed"
		}
	},
	"Models": {
		"SocialMessage": {
			"CacheConfig": {
				"Disable": true
			},
			"Grid": "MobileSocialMessageGridPage",
			"Preview": "MobileSocialMessagePreviewPage",
			"Edit": "MobileSocialMessageEditPage",
			"RequiredModels": [
				"SocialMessage",
				"Contact",
				"SysImage",
				"SocialSubscription",
				"SocialUnsubscription",
				"VwSocialSubscription",
				"VwSocialUnsubscription",
				"SocialChannel",
				"VwMobileSysSchema",
				"SocialLike",
				"SocialMention",
				"SysAdminUnit"
			],
			"ModelExtensions": [
				"MobileSocialMessageModelConfig"
			],
			"PagesExtensions": [
				"MobileSocialMessageGridPageSettingsDefaultWorkplace",
				"MobileSocialMessageRecordPageSettingsDefaultWorkplace",
				"MobileSocialMessageActionsSettingsDefaultWorkplace",
				"MobileSocialMessageEntityLoader",
				"MobileSocialMessageLikeManager",
				"MobileSocialMessageModuleConfig",
				"MobileSocialMessageGridPageStore",
				"MobileSocialMessageGridPageView",
				"MobileSocialMessageGridPageController",
				"MobileSocialMessageAssociateModelCacheManager"
			]
		},
		"SocialMention": {
			"ModelExtensions": [
				"MobileSocialMentionModelConfig"
			]
		}
	}
}


