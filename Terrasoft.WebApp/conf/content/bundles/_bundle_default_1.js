Terrasoft.configuration.Structures.AccountBillingInfoDetail={innerHierarchyStack:["AccountBillingInfoDetail"]};define("AccountBillingInfoDetailStructure",function(){return{type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("AccountBillingInfoDetail",["AccountBillingInfo","AccountBillingInfoDetailStructure"],function(n,t){return t.userCode=function(){this.entitySchema=n;this.name="AccountBillingInfoDetailViewModel";this.editPageName="AccountBillingInfoPage";this.typeColumn="Type";this.columnsConfig=[[{cols:8,key:[{name:{bindTo:"Name"},type:"title"}]},{cols:16,key:[{name:{bindTo:"BillingInfo"}}]}]];this.loadedColumns=[{columnPath:"Name"},{columnPath:"BillingInfo"}];this.methods.setEntitySchema=function(){this.entitySchema=n}},t})
Terrasoft.configuration.Structures.AccountBillingInfoPage={innerHierarchyStack:["AccountBillingInfoPage"]};define("AccountBillingInfoPageStructure",["AccountBillingInfoPageResources"],function(){return{type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("AccountBillingInfoPage",["ext-base","terrasoft","sandbox","AccountBillingInfo","AccountBillingInfoPageStructure","AccountBillingInfoPageResources"],function(n,t,i,r,u,f){return u.userCode=function(){this.entitySchema=r;this.name="AccountBillingInfoCardViewModel";var i=function(){return t.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"[ContactCareer:Contact].Account",this.get("Account").value)};this.schema.leftPanel=[{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Id",columnPath:"Id",visible:!1,viewVisible:!1},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",dataValueType:t.DataValueType.LOOKUP,visible:!0,customConfig:{enabled:!1}},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Name",columnPath:"Name",dataValueType:t.DataValueType.TEXT,visible:!0,viewVisible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Country",columnPath:"Country",dataValueType:t.DataValueType.LOOKUP,columns:["BillingInfo"],visible:!0,viewVisible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"BillingInfo",columnPath:"BillingInfo",customConfig:{className:"Terrasoft.controls.MemoEdit",height:"100px"},visible:!0,viewVisible:!0,dependencies:["Country"],methodName:"countryChanged"},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"AccountManager",columnPath:"AccountManager",dataValueType:t.DataValueType.LOOKUP,visible:!0,viewVisible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"ChiefAccountant",columnPath:"ChiefAccountant",dataValueType:t.DataValueType.LOOKUP,visible:!0,viewVisible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Description",columnPath:"Description",visible:!0,customConfig:{className:"Terrasoft.controls.MemoEdit",height:"100px"}}];t.applySchemaItemProperties(this.schema.leftPanel,"AccountManager",{filter:i});t.applySchemaItemProperties(this.schema.leftPanel,"ChiefAccountant",{filter:i});this.getItemViewHeader=function(){return{columns:[{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",viewVisible:!0,labelClass:"account-accountname"}]}};this.methods.countryChanged=function(){var r={buttons:[t.MessageBoxButtons.YES.returnCode,t.MessageBoxButtons.NO.returnCode],defaultButton:0},u=this.get("BillingInfo"),i=this.get("Country");n.isEmpty(i)||(u?this.showInformationDialog(f.localizableStrings.CountryIsChange,this.getSelectedButton,r):this.set("BillingInfo",i.BillingInfo))};this.methods.getSelectedButton=function(n){if(n===t.MessageBoxButtons.YES.returnCode){var i=this.get("Country");this.set("BillingInfo",i.BillingInfo)}}},u})
Terrasoft.configuration.Structures.AccountOrganizationChartDetail={innerHierarchyStack:["AccountOrganizationChartDetail"]};define("AccountOrganizationChartDetailStructure",function(){return{type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("AccountOrganizationChartDetail",["AccountOrganizationChart","AccountOrganizationChartDetailStructure","AccountOrganizationChartDetailResources"],function(n,t,i){return t.userCode=function(){this.entitySchema=n;this.name="AccountOrganizationChartDetailViewModel";this.editPageName="AccountOrganizationChartPage";this.hierarchicalGrid=!0;this.loadAll=!0;this.columnsConfig=[[{cols:24,key:[{name:{bindTo:"CustomDepartmentName"},type:"title"}]}]];this.loadedColumns=[{columnPath:"CustomDepartmentName"},{columnPath:"Parent"}];this.editPages=[{caption:i.localizableStrings.AddItem,name:"AddItem",UId:""},{caption:i.localizableStrings.AddChildItem,name:"AddChildItem",UId:"",bindTo:"addChild",enabled:{bindTo:"isSomeSelected"}}];this.methods.addChild=function(){this.add(null,function(){var r=this.GetSelectedItems();if(r){var t=this,u=r[0],f={name:this.filterPath,value:this.filterValue},e={name:"Parent",value:u},o=this.editPageName,n=this.sandbox,i=n.id+"_CardModule_"+this.entitySchema.name;n.subscribe("CardModuleEntityInfo",function(){var n={};return n.action="add",n.cardSchemaName=o,n.activeRow="",n.valuePairs=[],n.valuePairs.push(f,e),n},[i]);n.publish("OpenCardModule",i,[this.getCardModuleSandboxId()]);n.subscribe("UpdateDetail",function(){var n=t.get("gridData");n.clear();t.load();t.isObsolete=!0},[i])}})};this.methods.onDeleteAccept=function(){var t=this.GetSelectedItems(),i=this.get("gridData"),n=Ext.create("Terrasoft.BatchQuery");Terrasoft.each(t,function(t){this.deleteItem(t,n,this)},this);n.queries.length>0&&n.execute(this.onDeleted,this)};this.methods.onDeleted=function(n){if(n&&n.success){var t=this.get("gridData");this.clearSelection();this.set("gridEmpty",!t.getItems().length)}else this.showConfirmationDialog(i.localizableStrings.OnDeleteError)};this.methods.deleteItem=function(n,t,i){var r=i.get("gridData"),f=new Terrasoft.Collection,e,u,o;r.each(function(t){var i=t.get("Parent");i&&i.value===n&&f.add(t)},r);Terrasoft.each(f.getItems(),function(n){this.deleteItem(n.get("Id"),t,this)},i);r.find(n)&&(e=r.get(n),r.remove(e),u=Ext.create("Terrasoft.DeleteQuery",{rootSchema:i.entitySchema}),o=Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,"Id",n),u.filters.addItem(o),t.add(u))};this.methods.setEntitySchema=function(){this.entitySchema=n}},t})
Terrasoft.configuration.Structures.AccountOrganizationChartPage={innerHierarchyStack:["AccountOrganizationChartPage"]};define("AccountOrganizationChartPageStructure",["AccountOrganizationChartPageResources"],function(){return{type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("AccountOrganizationChartPage",["ext-base","terrasoft","sandbox","AccountOrganizationChart","AccountOrganizationChartPageStructure","AccountOrganizationChartPageResources","BusinessRuleModule"],function(n,t,i,r,u){return u.userCode=function(){this.entitySchema=r;this.name="AccountOrganizationChartPageViewModel";this.getItemViewHeader=function(){return{columns:[{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",viewVisible:!0,labelClass:"campaign-campaignname"}]}};this.methods.onDepartmentChange=function(){var t=this.get("Department");n.isEmpty(t)?this.set("CustomDepartmentName",null):this.set("CustomDepartmentName",t.displayValue)};this.schema.leftPanel=[{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",dataValueType:t.DataValueType.LOOKUP,visible:!0,viewVisible:!0,customConfig:{readonly:!0}},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"CustomDepartmentName",columnPath:"CustomDepartmentName",dataValueType:t.DataValueType.TEXT,visible:!0,viewVisible:!0,dependencies:["Department"],methodName:"onDepartmentChange"},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Department",columnPath:"Department",dataValueType:t.DataValueType.LOOKUP,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Manager",columnPath:"Manager",dataValueType:t.DataValueType.LOOKUP,visible:!0,filter:function(){return t.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"[ContactCareer:Contact].Account",this.get("Account").value)}},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Description",columnPath:"Description",dataValueType:t.DataValueType.LOOKUP,visible:!0,customConfig:{className:"Terrasoft.controls.MemoEdit",height:"100px"}},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Id",columnPath:"Id",visible:!1,viewVisible:!1},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Parent",columnPath:"Parent",visible:!1,viewVisible:!1}]},u})
Terrasoft.configuration.Structures.AccountRelationshipDetailCss={innerHierarchyStack:["AccountRelationshipDetailCss"]};define("AccountRelationshipDetailCss",[],function(){return{}})
Terrasoft.configuration.Structures.AccountSearchRowSchema={innerHierarchyStack:["AccountSearchRowSchema"],structureParent:"BaseSearchRowSchema"};define("AccountSearchRowSchemaStructure",["AccountSearchRowSchemaResources"],function(){return{schemaUId:"e59f4cfb-fc72-4a62-aa4a-a2228196e26c",schemaCaption:"AccountSearchRowSchema",parentSchemaName:"BaseSearchRowSchema",packageName:"GlobalSearch",schemaName:"AccountSearchRowSchema",parentSchemaUId:"254c5d91-bad1-44be-a75e-1d511f816dc0",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("AccountSearchRowSchema",[],function(){return{diff:[{operation:"remove",name:"EntitySchemaCaption"},{operation:"merge",name:"FoundColumnsContainerList",values:{layout:{column:0,row:2,colSpan:12}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Phone",values:{layout:{column:12,row:0,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Country",values:{layout:{column:18,row:0,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"PrimaryContact",values:{layout:{column:0,row:1,colSpan:12}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Web",values:{layout:{column:12,row:1,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"City",values:{layout:{column:18,row:1,colSpan:6}}}]}})
Terrasoft.configuration.Structures.ActionButtonHelper={innerHierarchyStack:["ActionButtonHelper"]};define("ActionButtonHelper",["terrasoft","ActionButtonHelperResources","ViewUtilities","css!ActionButtonHelper"],function(n,t,i){function r(r){var e=r.color||"Grey",o=n.ImageUrlBuilder.getUrl(t.localizableImages[e+"ButtonImage"]),f=i.getContainerConfig(r.name),u={className:"Terrasoft.Button",caption:r.caption,style:n.controls.ButtonEnums.style.TRANSPARENT,iconAlign:n.controls.ButtonEnums.iconAlign.LEFT,imageConfig:{source:n.ImageSources.URL,url:o},classes:{imageClass:["action-btn-image"],wrapperClass:["action-btn-wrapper"]}};return r.click&&(u.click=r.click),r.visible&&(u.visible=r.visible),r.enabled&&(u.enabled=r.enabled),f.items=[Ext.merge(u,r.buttonConfig)],f}function u(t){var f=t.id||"actionsButtonsContainer",u=i.getContainerConfig(f,["action-container-wrapper"]),e=t.actions;return n.each(e,function(n){var t=r(n);u.items.push(t)}),u}return{getActionButtonsConfig:u,getActionButtonConfigL:r}})
Terrasoft.configuration.Structures.ActionUtilitiesModule={innerHierarchyStack:["ActionUtilitiesModule"]};define("ActionUtilitiesModule",["ext-base","ActionUtilitiesModuleResources","ReportUtilities"],function(n,t,i){var u=t.localizableStrings.ActionButtonCaption,r=function(t,i){Terrasoft.each(i,function(i){var r={caption:i.caption,tag:i.tag===undefined?i.schemaName:i.tag,className:i.className,enabled:i.enabled?i.enabled:!0};i.className!=="Terrasoft.MenuSeparator"&&(r.click=i.click?i.click:{bindTo:i.methodName===undefined?"executeAction":i.methodName});i.menu&&(r.menu=i.menu);i.visible&&(r.visible=i.visible);n.isEmpty(i.customConfig)||n.apply(r,i.customConfig);t.push(r)})},f=function(i){var u={className:"Terrasoft.Button",style:Terrasoft.controls.ButtonEnums.style.DEFAULT,caption:t.localizableStrings.ActionButtonCaption,classes:{wrapperClass:["main-buttons"]}},f=[],e;return r(f,i),e={menu:{items:f}},n.apply(u,e),u};return{addActionsButton:function(n,t){if(t){var i=n.filter(function(n){return n.caption===u});i&&i.length>0?r(i[0].menu.items,t):n.push(f(t))}},getReports:function(n){if(n.length){var r=i.getReportsMenuConfig(n);return r.length>0&&r.unshift({caption:t.localizableStrings.PrintCaption,className:"Terrasoft.MenuSeparator"}),r}}}})
Terrasoft.configuration.Structures.ActivityDetail={innerHierarchyStack:["ActivityDetail"]};define("ActivityDetailStructure",function(){return{type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ActivityDetail",["Activity","sandbox","ActivityDetailStructure","ActivityDetailResources"],function(n,t,i,r){return i.userCode=function(){var e=this.entitySchema=n,i,u,f;this.name="ActivityDetailViewModel";this.editPageName="ActivityPage";this.typeColumn="Type";this.utilsConfig={hiddenAdd:!0,useAdditionalAddButton:!0};this.captionsConfig=[{cols:12,name:r.localizableStrings.TitleCaption},{cols:6,name:r.localizableStrings.StartDateCaption},{cols:6,name:r.localizableStrings.StatusCaption}];this.columnsConfig=[[{cols:12,key:[{name:{bindTo:"Title"},type:"title"}]},{cols:6,key:[{name:{bindTo:"StartDate"}}]},{cols:6,key:[{name:{bindTo:"Status"}}]}]];this.loadedColumns=[{columnPath:"Title"},{columnPath:"StartDate"},{columnPath:"Status"},{columnPath:"Type"},{columnPath:"ProcessElementId"}];i=this.methods.edit;this.methods.edit=function(){var e=this.GetSelectedItems(),n=e[0],f=this.get("gridData"),r,u;if(n&&f&&f.collection&&n&&(r=f.collection.items.filter(function(t){return t.values.Id===n}),r&&r.length>0&&(u=r[0].values.ProcessElementId,u&&!Terrasoft.isEmptyGUID(u)))){t.publish("ProcessExecDataChanged",{procElUId:u,recordId:n,scope:this,parentMethodArguments:null,parentMethod:i});return}Ext.isEmpty(i)||i.call(this)};u=this.methods.applyFilter;this.methods.applyFilter=function(n,t){var i=this.filterPath,r=this.filterValue;return t&&(i=this.filterPath=t.filterPath,r=this.filterValue=t.filterValue),t.filterPath==="Participant"?(n.filters.add("participiantdetailFilter",Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,"[ActivityParticipant:Activity].Participant.Id",t.filterValue)),!1):(u.apply(this,arguments),!0)};f=this.methods.add;this.methods.add=function(n){f.call(this,n,function(){var e=this,u=this.filterValue,f=this.filterPath,i=Terrasoft.configuration.ModuleStructure[this.entitySchema.name],o=n.UId||n,s=this.getEditPage(i,o),r;t=this.sandbox;r=t.id+"_CardModule_"+this.entitySchema.name;t.subscribe("CardModuleEntityInfo",function(){var t={};return t.action="add",t.cardSchemaName=s,t.activeRow="",i&&i.attribute&&(t.typeUId=n.UId,t.typeColumnName=i.attribute),t.valuePairs=[],n&&n.additionalValues&&(t.valuePairs=n.additionalValues),f!=="Participant"?t.valuePairs.push({name:f,value:u}):t.valuePairs.push({name:"Contact",value:u}),t},[r]);t.publish("OpenCardModule",r,[this.getCardModuleSandboxId()]);t.subscribe("UpdateDetail",function(n){e.isObsolete=!0;t.publish("DetailChanged",[t.id,n])},[r])})};this.methods.modifyView=function(n){var i=Terrasoft.configuration.ModuleStructure[e.name],r=[],t;i&&i.pages&&Terrasoft.each(i.pages,function(n){var t={caption:n.caption,tag:n,click:{bindTo:n.bindTo||"add"}};n.enabled&&(t.enabled=n.enabled);r.push(t)},this);t=n.items[0].items[1];t.hasOwnProperty("click")&&delete t.click;t.menu={items:r}}},i})
Terrasoft.configuration.Structures.ActivityPage={innerHierarchyStack:["ActivityPage"]};define("ActivityPageStructure",function(){return{type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ActivityPage",["ext-base","terrasoft","sandbox","Activity","ActivityPageStructure","ActivityPageResources","BusinessRuleModule","ConfigurationConstants","ConfigurationEnums","BaseFiltersGenerateModule","GeneralDetails","ActivityUtilities"],function(n,t,i,r,u,f,e,o,s,h,c,l){var a={type:t.ViewModelSchemaItem.GROUP,name:"reminding",caption:f.localizableStrings.RemindingGroupCaption,visible:!0,collapsed:!1,wrapContainerClass:"control-group-container",items:[{type:s.CustomViewModelSchemaItem.ITEMS_GROUP,name:"reminding-container",caption:f.localizableStrings.RemindToOwnerCaption,id:"reminding-container",wrapContainerClass:"controlCaption",visible:!0,items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,caption:f.localizableStrings.RemindToOwnerCaption,name:"RemindToOwner",columnPath:"RemindToOwner",dataValueType:t.DataValueType.BOOLEAN,visible:!0,wrapClass:"RemindToOwner",id:"RemindToOwner"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,caption:" ",name:"RemindToOwnerDate",columnPath:"RemindToOwnerDate",dataValueType:t.DataValueType.DATE_TIME,visible:!0,wrapContainerClass:"RemindToOwnerDate",rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.ENABLED,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"RemindToOwner"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:!0}}]}],dependencies:["RemindToOwner"],methodName:"setDefaultRemindToOwner"}]},{type:s.CustomViewModelSchemaItem.ITEMS_GROUP,name:"reminding-to-autor-container",caption:f.localizableStrings.RemindToAuthorCaption,id:"reminding-to-autor-container",wrapContainerClass:"controlCaption",visible:!0,items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,caption:" ",name:"RemindToAuthor",columnPath:"RemindToAuthor",dataValueType:t.DataValueType.BOOLEAN,visible:!0,wrapClass:"RemindToOwner"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,caption:" ",name:"RemindToAuthorDate",columnPath:"RemindToAuthorDate",dataValueType:t.DataValueType.DATE_TIME,visible:!0,wrapContainerClass:"RemindToOwnerDate",rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.ENABLED,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"RemindToAuthor"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:!0}}]}],dependencies:["RemindToAuthor"],methodName:"setDefaultRemindToAuthor"}]}]};return u.userCode=function(){this.entitySchema=r;this.contextHelpId="1010";this.name="ActivityCardViewModel";this.schema.rightPanel=[{name:"activity",schemaName:"ActivityParticipantDetail",type:t.ViewModelSchemaItem.DETAIL,filterPath:"Activity",filterValuePath:"Id",caption:f.localizableStrings.ActivityParticipantDetailCaption,visible:!0,leftWidth:"60%",rightWidth:"40%",wrapContainerClass:"control-group-container"},c.Notes("Notes"),n.apply(c.File("Activity"),{collapsed:!1})];this.schema.leftPanel=[{type:t.ViewModelSchemaItem.GROUP,name:"baseElementsControlGroup",visible:!0,collapsed:!1,wrapContainerClass:"main-elements-control-group-container",items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Id",columnPath:"Id",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Type",columnPath:"Type",dataValueType:t.DataValueType.ENUM,visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"ProcessElementId",columnPath:"ProcessElementId",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"AllowedResult",columnPath:"AllowedResult",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Title",columnPath:"Title",dataValueType:t.DataValueType.TEXT,visible:!0,customConfig:{className:"Terrasoft.controls.MemoEdit",height:"100px"}},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Owner",columnPath:"Owner",dataValueType:t.DataValueType.LOOKUP,visible:!0,filter:h.OwnerFilter},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"ActivityCategory",columnPath:"ActivityCategory",dataValueType:t.DataValueType.ENUM,visible:!0,rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.VISIBLE,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"Type"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:o.Activity.Type.Task}}]},{ruleType:e.enums.RuleType.FILTRATION,baseAttributePatch:"ActivityType",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Type"}],dependencies:["Type"],methodName:"setDefaultActivityValues"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"StartDate",columnPath:"StartDate",dataValueType:t.DataValueType.DATE_TIME,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"DueDate",columnPath:"DueDate",dataValueType:t.DataValueType.DATE_TIME,visible:!0,dependencies:["StartDate"],methodName:"setDueDate"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Priority",columnPath:"Priority",dataValueType:t.DataValueType.ENUM,visible:!0,advancedVisible:!0,isRequired:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Author",columnPath:"Author",dataValueType:t.DataValueType.LOOKUP,visible:!0,advancedVisible:!0,isRequired:!0,filter:h.OwnerFilter},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"ShowInScheduler",columnPath:"ShowInScheduler",dataValueType:t.DataValueType.BOOLEAN,visible:!0,advancedVisible:!0,dependencies:["ActivityCategory"],methodName:"setDefaultShowInScheduler"}]},{type:t.ViewModelSchemaItem.GROUP,name:"status",caption:f.localizableStrings.StatusGroupCaption,visible:!0,collapsed:!1,wrapContainerClass:"control-group-container",items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Status",columnPath:"Status",dataValueType:t.DataValueType.ENUM,visible:!0,isRequired:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Result",columnPath:"Result",dataValueType:t.DataValueType.ENUM,visible:!0,filter:function(){var i,r=this.get("ActivityCategory");return n.isEmpty(r)||(i=t.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"[ActivityCategoryResultEntry:ActivityResult].ActivityCategory",r.value)),i},rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.ENABLED,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"Status",attributePath:"Finish"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:!0}}]}],dependencies:["Status"],methodName:"clearIfNotFinish"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"DetailedResult",columnPath:"DetailedResult",dataValueType:t.DataValueType.TEXT,visible:!0,advancedVisible:!0,customConfig:{className:"Terrasoft.controls.MemoEdit",height:"100px"},rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.ENABLED,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"Status",attributePath:"Finish"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:!0}}]}]}]},a,{type:t.ViewModelSchemaItem.GROUP,name:"bounds",caption:f.localizableStrings.BoundGroupCaption,visible:!0,collapsed:!1,wrapContainerClass:"control-group-container",items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",dataValueType:t.DataValueType.LOOKUP,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Contact",columnPath:"Contact",dataValueType:t.DataValueType.LOOKUP,visible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Account",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"}]},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Opportunity",columnPath:"Opportunity",dataValueType:t.DataValueType.LOOKUP,visible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Contact",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Contact"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Account",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Campaign",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Campaign"}]},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Document",columnPath:"Document",dataValueType:t.DataValueType.LOOKUP,visible:!0,advancedVisible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Account",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Contact",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Contact"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Campaign",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Campaign"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Opportunity",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Opportunity"}]},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Campaign",columnPath:"Campaign",dataValueType:t.DataValueType.LOOKUP,visible:!0,advancedVisible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Lead",columnPath:"Lead",dataValueType:t.DataValueType.LOOKUP,visible:!0,advancedVisible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"QualifiedAccount",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"QualifiedContact",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Contact"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Campaign",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Campaign"}]}]}];this.defineMethods()},u.userCodeInProcessMode=function(){this.entitySchema=r;this.name="ActivityCardViewModel";this.schema.rightPanel=[{name:"activity",schemaName:"ActivityParticipantDetail",type:t.ViewModelSchemaItem.DETAIL,filterPath:"Activity",filterValuePath:"Id",caption:f.localizableStrings.ActivityParticipantDetailCaption,visible:!0,leftWidth:"60%",rightWidth:"40%",wrapContainerClass:"control-group-container"},c.Notes("Notes"),c.File("Activity"),c.InFolder("Activity")];this.schema.leftPanel=[{type:t.ViewModelSchemaItem.GROUP,name:"general",caption:"",visible:!0,collapsed:!1,wrapContainerClass:"control-group-container",items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Id",columnPath:"Id",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Type",columnPath:"Type",dataValueType:t.DataValueType.ENUM,visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"ProcessElementId",columnPath:"ProcessElementId",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"AllowedResult",columnPath:"AllowedResult",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Title",columnPath:"Title",dataValueType:t.DataValueType.TEXT,visible:!0,customConfig:{className:"Terrasoft.controls.MemoEdit",height:"100px"}},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"ActivityCategory",columnPath:"ActivityCategory",dataValueType:t.DataValueType.ENUM,visible:!1,advancedVisible:!0,rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.VISIBLE,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"Type"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:o.Activity.Type.Task}}]},{ruleType:e.enums.RuleType.FILTRATION,baseAttributePatch:"ActivityType",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Type"}],dependencies:["Type"],methodName:"setDefaultActivityValues"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"StartDate",columnPath:"StartDate",dataValueType:t.DataValueType.DATE_TIME,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"DueDate",columnPath:"DueDate",dataValueType:t.DataValueType.DATE_TIME,visible:!0,dependencies:["StartDate"],methodName:"setDueDate"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Owner",columnPath:"Owner",dataValueType:t.DataValueType.LOOKUP,visible:!0,filter:h.OwnerFilter},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Priority",columnPath:"Priority",dataValueType:t.DataValueType.ENUM,visible:!1,advancedVisible:!0,isRequired:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Author",columnPath:"Author",dataValueType:t.DataValueType.LOOKUP,visible:!1,advancedVisible:!0,isRequired:!0,filter:h.OwnerFilter},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"ShowInScheduler",columnPath:"ShowInScheduler",dataValueType:t.DataValueType.BOOLEAN,visible:!1,advancedVisible:!0,dependencies:["ActivityCategory"],methodName:"setDefaultShowInScheduler"}]},{type:t.ViewModelSchemaItem.GROUP,name:"status",caption:f.localizableStrings.StatusGroupCaption,collapsed:!1,wrapContainerClass:"control-group-container",items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Status",columnPath:"Status",dataValueType:t.DataValueType.ENUM,visible:!0,isRequired:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Result",columnPath:"Result",dataValueType:t.DataValueType.ENUM,visible:!0,filter:function(){var i,r=this.get("ActivityCategory");return n.isEmpty(r)||(i=t.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"[ActivityCategoryResultEntry:ActivityResult].ActivityCategory",r.value)),i},rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.REQUIRED,logicalOperation:t.LogicalOperatorType.AND,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"ProcessElementId"},comparisonType:t.core.enums.ComparisonType.IS_NOT_NULL},{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"Status",attributePath:"Finish"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:!0}}]},{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.ENABLED,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"Status",attributePath:"Finish"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:!0}}]}],dependencies:["Status"],methodName:"clearIfNotFinish"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"DetailedResult",columnPath:"DetailedResult",dataValueType:t.DataValueType.TEXT,visible:!0,advancedVisible:!0,customConfig:{className:"Terrasoft.controls.MemoEdit",height:"100px"},rules:[{ruleType:e.enums.RuleType.BINDPARAMETER,property:e.enums.Property.ENABLED,conditions:[{leftExpression:{type:e.enums.ValueType.ATTRIBUTE,attribute:"Status",attributePath:"Finish"},comparisonType:t.core.enums.ComparisonType.EQUAL,rightExpression:{type:e.enums.ValueType.CONSTANT,value:!0}}]}]}],customConfig:{visible:{bindTo:"isStatusGroupVisible"}}},{type:t.ViewModelSchemaItem.GROUP,name:"result",caption:f.localizableStrings.ResultGroupCaption,collapsed:!1,wrapContainerClass:"control-group-container",items:[{type:s.CustomViewModelSchemaItem.ITEMS_GROUP,name:"results-container",id:"results-container",wrapContainerClass:"results-container",visible:!0}],customConfig:{visible:{bindTo:"isResultGroupVisible"}}},a,{type:t.ViewModelSchemaItem.GROUP,name:"bounds",caption:f.localizableStrings.BoundGroupCaption,visible:!0,collapsed:!0,wrapContainerClass:"control-group-container",items:[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",dataValueType:t.DataValueType.LOOKUP,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Contact",columnPath:"Contact",dataValueType:t.DataValueType.LOOKUP,visible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Account",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"}]},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Opportunity",columnPath:"Opportunity",dataValueType:t.DataValueType.LOOKUP,visible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Contact",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Contact"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Account",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Campaign",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Campaign"}]},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Document",columnPath:"Document",dataValueType:t.DataValueType.LOOKUP,visible:!0,advancedVisible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Account",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Contact",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Contact"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Campaign",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Campaign"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Opportunity",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Opportunity"}]},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Campaign",columnPath:"Campaign",dataValueType:t.DataValueType.LOOKUP,visible:!0,advancedVisible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Lead",columnPath:"Lead",dataValueType:t.DataValueType.LOOKUP,visible:!0,advancedVisible:!0,rules:[{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"QualifiedAccount",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Account"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"QualifiedContact",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Contact"},{ruleType:e.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!1,baseAttributePatch:"Campaign",comparisonType:t.ComparisonType.EQUAL,type:e.enums.ValueType.ATTRIBUTE,attribute:"Campaign"}]}]}];this.defineMethods()},u.customizeView=function(n,t,i){l.customizeView(n,t,i,f)},u.defineMethods=function(){this.methods.resultButtonClick=function(t,i,r,u){var f=n.decode(u);this.set("Status",f.status);this.set("Result",f.result);this.set("resultSelected",!0)};this.methods.cancelResultSelected=function(){this.set("Status",o.Activity.Status.NotStarted);this.set("Result",null);this.set("resultSelected",!1)};this.methods.save=function(){var t=this.get("StartDate"),i=this.get("DueDate");return!n.isDate(t)||!n.isDate(i)?!1:(t=new Date(t.setMilliseconds(0)),t=new Date(t.setSeconds(0)),i=new Date(i.setMilliseconds(0)),i=new Date(i.setSeconds(0)),this.set("StartDate",t),this.set("DueDate",i),t>i?(this.showInformationDialog(f.localizableStrings.StartDateGreaterDueDate),!1):!0)};this.methods.init=function(){var t=this.get("StartDate"),i;n.isDate(t)&&this.action!=="copy"&&(i=new Date(t.getTime()+18e5),this.isNew&&this.set("DueDate",i))};var r=function(){return!1};this.methods.edit=function(){var n=this.get("ProcessElementId"),u=this.get("Id");return n&&!t.isEmptyGUID(n)?(i.publish("ProcessExecDataChanged",{procElUId:n,recordId:u,scope:this,parentMethodArguments:null,parentMethod:r}),!0):!1};this.methods.setDueDate=function(){var t=this.get("StartDate"),i=this.get("DueDate");n.isDate(t)&&(t=new Date(t.setMilliseconds(0)),t=new Date(t.setSeconds(0)),t>i&&this.set("DueDate",t))};this.methods.setDefaultRemindToOwner=function(){var i=this.get("RemindToOwner"),t;if(i){if(t=this.get("StartDate"),!n.isDate(t))return;t=new Date(t.setMilliseconds(0));t=new Date(t.setSeconds(0));this.set("RemindToOwnerDate",t)}else this.set("RemindToOwnerDate",null)};this.methods.setDefaultRemindToAuthor=function(){var i=this.get("RemindToAuthor"),t;if(i){if(t=this.get("DueDate"),!n.isDate(t))return;t=new Date(t.setMilliseconds(0));t=new Date(t.setSeconds(0));this.set("RemindToAuthorDate",t)}else this.set("RemindToAuthorDate",null)};this.methods.setDefaultShowInScheduler=function(){var n=this.get("ActivityCategory");n&&n.value===o.Activity.ActivityCategory.Meeting&&this.set("ShowInScheduler",!0)};this.methods.setDefaultActivityValues=function(){var r=this.get("Type"),t,i;switch(r.value){case o.Activity.Type.Call:t=o.Activity.ActivityCategory.Call;break;case o.Activity.Type.Email:t=o.Activity.ActivityCategory.Email;break;default:t=o.Activity.ActivityCategory.DoIt}i=n.create("Terrasoft.EntitySchemaQuery",{rootSchemaName:"ActivityCategory"});i.addColumn("Id");i.addColumn("Name");i.getEntity(t,function(n){var t=n.entity,i;t&&(i={displayValue:t.get("Name"),value:t.get("Id")},this.set("ActivityCategory",i))},this)};this.methods.clearIfNotFinish=function(){var n=this.get("Status");n&&n.Finish===!1&&(this.set("Result",null),this.set("DetailedResult",null))}},u})
Terrasoft.configuration.Structures.ActivityPageV2Utilities={innerHierarchyStack:["ActivityPageV2Utilities"]};define("ActivityPageV2Utilities",["terrasoft","ext-base","ConfigurationConstants","ActivityPageV2UtilitiesResources","TooltipUtilities"],function(n,t,i,r){function f(t){var u=t.categoryColor==="red"?i.Activity.Status.Cancel:i.Activity.Status.Done;return{operation:"insert",name:t.name,parentName:"CustomResultControlBlock",propertyName:"items",values:{itemType:n.ViewItemType.BUTTON,caption:t.caption,markerValue:"ActivityResultButton_"+t.caption,style:n.controls.ButtonEnums.style.TRANSPARENT,iconAlign:n.controls.ButtonEnums.iconAlign.LEFT,imageConfig:r.localizableImages[t.color+"ResultIcon"],visible:{bindTo:"Result",bindConfig:{converter:function(n){return this.get("Result")?n.value===t.resultId:!0}}},click:{bindTo:"resultButtonClick"},tag:{result:{value:t.resultId},status:{value:u,Finish:!0}}}}}var u=null;return{getCustomValues:function(){return this.prcExecData.informationOnStep?{InformationOnStep:this.prcExecData.informationOnStep}:{}},getCustomAttributes:function(){return{}},getCustomDiff:function(){var s,r,e;if((u=[{operation:"remove",name:"BackButton"}],this.prcExecData.informationOnStep&&(s={operation:"insert",parentName:"InformationOnStepButtonContainer",propertyName:"items",name:"InformationOnStepButton",values:{itemType:n.ViewItemType.INFORMATION_BUTTON,content:{bindTo:"InformationOnStep"},tools:[]}},u.push(s)),!this.prcExecData.allowedResults)||(r=t.decode(this.prcExecData.allowedResults),!r||r.length===0))return u;u.push({operation:"remove",name:"Status"},{operation:"remove",name:"Result"},{operation:"remove",name:"DetailedResult"},{operation:"merge",name:"ShowInScheduler",values:{layout:{column:0,row:3,colSpan:12}}});var h=i.Activity.ResultCategory.Neutral.toLowerCase(),c=i.Activity.ResultCategory.Fail.toLowerCase(),o=[];return n.each(r,function(n){n.color="green";n.category=0;var t=n.categoryId.toLowerCase();t===c?(n.color="red",n.category=2):t===h&&(n.color="grey",n.category=1);o.push(n)}),o.sort(function(n,t){return n.category<t.category?-1:n.category>t.category?1:n.caption<t.caption?-1:n.caption>t.caption?1:0}),e=0,n.each(o,function(n){n.name="CustomResultItem"+e;u.push(f(n));e++}),u.push({operation:"merge",name:"DetailedResult",values:{layout:{row:e}}}),u}}})
Terrasoft.configuration.Structures.ActivitySection={innerHierarchyStack:["ActivitySectionCrtNUI","ActivitySection"]};define("ActivitySectionCrtNUIStructure",["ActivitySectionCrtNUIResources"],function(){return{schemaUId:"ea6d7c8c-bd1c-4ecf-b595-d1a4ad979edf",schemaCaption:"Activities section (Old version)",parentSchemaName:"",packageName:"Exchange",schemaName:"ActivitySectionCrtNUI",parentSchemaUId:"",extendParent:!1,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ActivitySectionStructure",["ActivitySectionResources"],function(){return{schemaUId:"5c54f4ec-fa7d-418d-9716-9eeea7a7e902",schemaCaption:"Activities section (Old version)",parentSchemaName:"ActivitySectionCrtNUI",packageName:"Exchange",schemaName:"ActivitySection",parentSchemaUId:"ea6d7c8c-bd1c-4ecf-b595-d1a4ad979edf",extendParent:!0,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"ActivitySectionCrtNUI",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ActivitySectionCrtNUIResources",["terrasoft"],function(){return{localizableStrings:{},localizableImages:{},parametersLocalizableStrings:{}}});define("ActivitySectionCrtNUI",["ext-base","terrasoft","sandbox","Activity","ActivitySectionCrtNUIStructure","ActivitySectionCrtNUIResources","ProcessModule","SectionViewGenerator","ActionUtilitiesModule","ConfigurationEnums","ConfigurationConstants","EmailUtilities","BaseFiltersGenerateModule","MaskHelper"],function(n,t,i,r,u,f,e,o,s,h,c,l,a,v){function w(n){var i=n.get("Status.Finish"),r=n.get("DueDate");return r<=new Date&&!i?t.ScheduleItemStatus.OVERDUE:i?t.ScheduleItemStatus.DONE:t.ScheduleItemStatus.NEW}function y(n,t){return{className:"Terrasoft.Container",classes:{wrapClassName:t},items:[],id:n,selectors:{wrapEl:"#"+n}}}function b(){var i=t.SysSettings.cachedSettings.SchedulerTimingStart,r=t.SysSettings.cachedSettings.SchedulerTimingEnd;return{className:"Terrasoft.ScheduleEdit",startHour:0,displayStartHour:(!n.isEmpty(i)&&i>0&&i<24?i:8)+"-00",dueHour:!n.isEmpty(r)&&r>0&&r<24?r:24,timeScale:{bindTo:"getTimeScale"},period:{bindTo:"getSchedulerPeriod"},timezone:[{timezoneTitle:"Kiev",timezoneTime:"+2"}],startDate:null,dueDate:null,activityCollection:{bindTo:"gridData"},selectedItems:{bindTo:"selectedRows"},scheduleItemDoubleClick:{bindTo:"dblClickOpen"},change:{bindTo:"changeScheduleItem"},itemBindingConfig:{itemId:{bindTo:"Id"},title:{bindTo:"Title"},dueDate:{bindTo:"DueDate"},status:{bindTo:"SchedulerStatus"},startDate:{bindTo:"StartDate"},background:{bindTo:"Background"},fontColor:{bindTo:"FontColor"},isBold:{bindTo:"IsBold"},isItalic:{bindTo:"IsItalic"},isUnderline:{bindTo:"IsUnderline"}}}}function k(){var n=[o.getButtonAddConfig(r)];return n.push({className:"Terrasoft.Button",tag:h.CardState.View,enabled:{bindTo:"getEditButtonsEnabled"},click:{bindTo:"onSchedulerView"},styles:{textStyle:{margin:"0px 10px 0px 0px"}},style:t.controls.ButtonEnums.style.DEFAULT,caption:f.localizableStrings.ViewButtonCaption}),n.push({className:"Terrasoft.Button",enabled:{bindTo:"getEditButtonsEnabled"},click:{bindTo:"onSchedulerEdit"},styles:{textStyle:{margin:"0px 10px 0px 0px"}},style:t.controls.ButtonEnums.style.DEFAULT,caption:f.localizableStrings.EditButtonCaption,tag:h.CardState.Edit}),n.push({className:"Terrasoft.Button",enabled:{bindTo:"getEditButtonsEnabled"},click:{bindTo:"onSchedulerCopy"},styles:{textStyle:{margin:"0px 10px 0px 0px"}},style:t.controls.ButtonEnums.style.DEFAULT,caption:f.localizableStrings.CopyButtonCaption,tag:h.CardState.Copy}),n.push({className:"Terrasoft.Button",tag:h.CardState.Delete,enabled:{bindTo:"getEditButtonsEnabled"},click:{bindTo:"onSchedulerDelete"},styles:{textStyle:{margin:"0px 10px 0px 0px"}},style:t.controls.ButtonEnums.style.DEFAULT,caption:f.localizableStrings.DeleteButtonCaption}),n.push({className:"Terrasoft.Button",tag:h.CardState.Send,enabled:{bindTo:"getEditButtonsEnabled"},visible:{bindTo:"getSchedulerSendButtonsVisible"},click:{bindTo:"onSchedulerSend"},styles:{textStyle:{margin:"0px 10px 0px 0px"}},style:t.controls.ButtonEnums.style.DEFAULT,caption:f.localizableStrings.SendButtonCaption}),n}var p;return u.userCode=function(){function o(n,t,r,u,f){i.publish("ProcessExecDataChanged",{procElUId:n,recordId:t,scope:r,parentMethodArguments:u,parentMethod:f})}function u(i){var f=i.get("selectedRows"),e;if(f&&f.length>0&&i.set("activeRow",f[0]),e=t.configuration.ModuleStructure[r.name].attribute,!n.isEmpty(e)){var s=i.get("gridData"),h=i.get("activeRow"),o=null;if(s.each(function(n){n.get(n.primaryColumnName)===h&&(o=n.get(e))},this),!n.isEmpty(o)){var c=o.value,l=t.configuration.ModuleStructure[r.name].pages,u=null;if(t.each(l,function(t){t.UId===c&&n.isEmpty(u)&&(u=t)}),!n.isEmpty(u))return u}}return{}}function d(){var i,r;this.set("isMailboxSyncEnabled",!1);this.set("isMailboxSyncExist",!1);i=n.create("Terrasoft.EntitySchemaQuery",{rootSchemaName:"MailboxSyncSettings"});i.addColumn("Id");r=t.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"SysAdminUnit",t.SysValue.CURRENT_USER.value);i.filters.addItem(r);i.getEntityCollection(function(n){n.success&&(this.set("isMailboxSyncEnabled",!0),this.set("isMailboxSyncExist",n.collection.getItems().length>0))},this)}this.entitySchema=r;this.contextHelpId="1010";this.name="ActivitySectionViewModel";this.finishedTaskColor=null;this.configuration={sort:{columns:[{name:"StartDate",orderPosition:1,orderDirection:t.OrderDirection.DESC}]},pageNumber:0,pageRowsCount:10};this.columnsConfig=[[{cols:24,key:[{name:{bindTo:"Title"},type:"title"}]}],[{cols:6,key:[{name:{bindTo:"Owner"}}]},{cols:3,key:[{name:{bindTo:"StartDate"}}]},{cols:4,key:[{name:{bindTo:"Result"}}]},{cols:11,key:[{name:{bindTo:"DetailedResult"}}]}]];this.loadedColumns=[{columnPath:"Type"},{columnPath:"Title"},{columnPath:"StartDate"},{columnPath:"DueDate"},{columnPath:"Owner"},{columnPath:"Result"},{columnPath:"DetailedResult"},{columnPath:"ProcessElementId"},{columnPath:"Status"},{columnPath:"Status.Finish"},{columnPath:"EmailSendStatus"},{columnPath:"Sender"},{columnPath:"Recepient"},{columnPath:"CopyRecepient"},{columnPath:"BlindCopyRecepient"},{columnPath:"MessageType"},{columnPath:"ShowInScheduler"}];this.methods.createActions=function(){return t.SysSettings.cachedSettings.BuildType!=="e45eb864-59cc-4325-8276-d85e1ba90c95"?[{caption:"",className:"Terrasoft.MenuSeparator"},{caption:f.localizableStrings.SynchronizeWithGoogleCalendarAction,methodName:"synchronizeWithGoogleCalendar"},{caption:f.localizableStrings.OpenGoogleSettingsPage,methodName:"openGoogleSettingsPage"},{caption:f.localizableStrings.LoadImapEmailsAction,methodName:"loadEmails"}]:[]};this.actions=this.methods.createActions();this.methods.changeScheduleItem=function(t){var r=this.get("gridData"),i=r.get(t);n.isEmpty(i)||i.saveEntity(function(){})};this.methods.openGoogleSettingsPage=function(){i.publish("PushHistoryState",{hash:"GoogleIntegrationSettingsModule/",stateObj:{schema:"Activity"}})};this.methods.onSchedulerSend=function(){var n=this.get("selectedRows"),i=this.get("gridData");n&&t.each(n,function(n){var t=i.get(n);this.sendEmail(t)},this)};this.methods.sendEmail=function(t){var i,u;if(!n.isEmpty(t))if(i=t.get("Type"),i.value===c.Activity.Type.Email){var e=t.get("Sender"),o=t.get("Recepient"),s=t.get("CopyRecepient"),h=t.get("BlindCopyRecepient"),r=t.get("EmailSendStatus");n.isEmpty(r)||r.value!==c.Activity.EmailSendStatus.Sended?n.isEmpty(e)?this.showConfirmationDialog(f.localizableStrings.SendEmailForUserQuestion):n.isEmpty(o)&&n.isEmpty(s)&&n.isEmpty(h)?this.showConfirmationDialog(f.localizableStrings.RecepientEmailForUserQuestion):(u=t.get("Id"),l.send(u,this)):this.showConfirmationDialog(f.localizableStrings.EmailWasSent)}else this.showConfirmationDialog(f.localizableStrings.ThisNotEmail)};this.methods.onActiveRowAction=function(n,t,r){switch(n){case h.CardState.Send:var u=this.get("gridData"),f=this.get("activeRow"),e=u.get(f);this.sendEmail(e);break;case h.CardState.Reply:var o=this.get("gridData"),s=this.get("activeRow"),c=o.get(s);i.publish("PushHistoryState",{hash:c.replyLink});break;case h.CardState.ReplyAll:var l=this.get("gridData"),a=this.get("activeRow"),v=l.get(a);i.publish("PushHistoryState",{hash:v.replyAllLink});break;case h.CardState.Forward:var y=this.get("gridData"),p=this.get("activeRow"),w=y.get(p);i.publish("PushHistoryState",{hash:w.forwardLink});break;default:r.call(this,n,t)}};var e=function(n){i.publish("PushHistoryState",n)};this.methods.dblClickOpen=function(n){var f=this.get("gridData"),i=f.get(n),s=i.get("Id"),r=i.get("ProcessElementId"),u={hash:i.editLink};r&&!t.isEmptyGUID(r)?o(r,s,this,u,e):e.call(this,u)};this.methods.getLink=function(n,i){var s=t.workspaceBaseUrl,e=n.get("Id"),r=t.configuration.ModuleStructure["Activity"],o=n.get(r.attribute),u="",f=r.cardSchema;return t.each(r.pages,function(n){n.UId===o.value&&n.cardSchema&&(f=n.cardSchema)},this),i==="linkEdit"?u=[r.cardModule,f,h.CardState.Edit,e]:i==="linkReply"?u=[r.cardModule,f,h.CardState.Add,r.attribute,o.value,"Reply",e]:i==="linkReplyAll"?u=[r.cardModule,f,h.CardState.Add,r.attribute,o.value,"ReplyAll",e]:i==="linkForward"&&(u=[r.cardModule,f,h.CardState.Add,r.attribute,o.value,"Forward",e]),u.join("/")};this.methods.edit=function(n,i,r){var u,e,f=this;t.each(this.changedValues.gridData.getItems(),function(n){f.changedValues.activeRow===n.get(f.primaryColumnName)&&(u=n.get("ProcessElementId"),e=n.get("Id"))});u&&!t.isEmptyGUID(u)?o(u,i,this,n,r):r&&r.call(this,n)};this.methods.getSchedulerPeriod=function(){var t=this.get("SchedulerStartDate"),i=this.get("SchedulerDueDate"),r=n.Date.clearTime(i),u=n.Date.clearTime(t),f=r-u;return f<0&&(t=i),{startDate:t,dueDate:i}};this.methods.getTimeScale=function(){return this.get("SchedulerTimeScaleLookupValue").value};this.methods.esqConfig={sort:{columns:[{name:"StartDate",orderPosition:0,orderDirection:t.OrderDirection.ASC}]}};this.methods.getEditButtonsEnabled=function(){var n=this.get("selectedRows");return n&&n.length>0};this.methods.getSchedulerSendButtonsVisible=function(){var n=this.get("selectedRows"),i=this.get("gridData"),r=!1;return n&&t.each(n,function(n){if(i.contains(n)){var t=i.get(n),u=t.get("Type");u.value===c.Activity.Type.Email&&(r=!0)}},this),r};this.methods.onSchedulerView=function(){var n=u(this),t=this.get("activeRow");this.view(n,t)};this.methods.onSchedulerEdit=function(){var n=u(this),t=this.get("activeRow");this.edit(n,t)};this.methods.onSchedulerCopy=function(){var n=u(this),t=this.get("activeRow");this.copy(n,t)};this.methods.onSchedulerDelete=function(){u(this);this.onDelete()};this.methods.getSendButtonsEnabled=function(){var n=this.get("selectedRows");return n&&n.length>0};this.methods.modifyGridConfig=function(n){var e={className:"Terrasoft.Button",tag:h.CardState.Send,visible:{bindTo:"getSendButtonsVisible"},style:t.controls.ButtonEnums.style.GREY,caption:f.localizableStrings.SendButtonCaption},o={className:"Terrasoft.Button",tag:h.CardState.Reply,visible:{bindTo:"getReplyButtonsVisible"},style:t.controls.ButtonEnums.style.GREY,caption:f.localizableStrings.ReplyButtonCaption},s={className:"Terrasoft.Button",tag:h.CardState.ReplyAll,visible:{bindTo:"getReplyButtonsVisible"},style:t.controls.ButtonEnums.style.GREY,caption:f.localizableStrings.ReplyAllButtonCaption},c={className:"Terrasoft.Button",tag:h.CardState.Forward,visible:{bindTo:"getForwardButtonsVisible"},style:t.controls.ButtonEnums.style.GREY,caption:f.localizableStrings.ForwardButtonCaption},i=n,r=[],u;return t.each(i.activeRowActions,function(n){n.tag==="delete"?u=n:r.push(n)},this),i.activeRowActions=r,p!==undefined&&p||(i.activeRowActions.push(e),i.activeRowActions.push(o),i.activeRowActions.push(s),i.activeRowActions.push(c),i.activeRowActions.push(u)),i};this.methods.view=function(n,t){var i=arguments[arguments.length-1];i.call(this,n,t)};this.methods.createViewConfig=function(){var r,i;if(1){var u=y("SectionActionsContainer"),n=y("schedulerUtils"),f=y("summary-container"),t=y("button-panel");return t.items=k(),r=this.createActions(),s.addActionsButton(t.items,r),n.items=[t],n.items.push(f),n.items.push(u),i=y("schedulerAutoGeneratedContainer"),i.items=[n,b()],i}return null};this.methods.getCurrentViewActions=function(n){var t=this.get("currentTabName");return t==="scheduler"?this.getSchedulerActions():n.call(this)};this.methods.initViewModel=function(){this.set("SchedulerTimeScaleLookupValue",{value:t.TimeScale.THIRTY_MINUTES});this.set("SchedulerSelectedItems",[]);d.call(this)};this.methods.getDefView=function(){var t=this.getCustomProfileValue("activeView");return n.isEmpty(t)?"scheduler":t};this.methods.getViews=function(n){var t=n.call(this);return t.unshift({name:"scheduler",caption:f.localizableStrings.SchedulerHeader}),t};this.methods.getSchedulerActions=function(){var i=[],r,n;for(r in t.TimeScale)n=t.TimeScale[r],i.push({caption:f.localizableStrings.IntervalFormat.replace("#interval#",n),tag:n,click:{bindTo:"changeInterval"}});return i};this.methods.changeInterval=function(n){this.set("SchedulerTimeScaleLookupValue",{value:n})};this.methods.add=function(n,t){this.get("currentTabName")==="scheduler"&&(n.additionalValues=[{name:"ShowInScheduler",value:!0}]);t.call(this,n)};this.methods.load=function(n,t){var r=arguments[arguments.length-1],i=this.publishMessage("GetFixedFilter","PeriodFilter");i&&i.startDate&&i.dueDate||(i={startDate:new Date,dueDate:new Date});this.set("SchedulerStartDate",i.startDate);this.set("SchedulerDueDate",i.dueDate);r.call(this,n,t)};this.methods.viewChanging=function(n){this.get("SchedulerStartDate")||this.set("SchedulerStartDate",new Date);this.get("SchedulerDueDate")||this.set("SchedulerDueDate",new Date);this.loadAll=n==="scheduler";this.setCustomProfile("activeView",n==="mainView"?n:"")};this.methods.onLoadData=function(n){var t=n.collection,i=this.finishedTaskColor,r=this.expiredTaskColor;return t&&this.get("currentTabName")==="scheduler"&&t.each(function(n){n.get("ShowInScheduler")||this.remove(n)},t),n};this.fixedFilterConfig={entitySchema:r,filters:[{name:"PeriodFilter",caption:f.localizableStrings.PeriodFilterCaption,dataValueType:t.DataValueType.DATE,startDate:{columnName:"StartDate",defValue:t.startOfWeek(new Date)},dueDate:{columnName:"DueDate",defValue:t.endOfWeek(new Date)}},{name:"Owner",caption:f.localizableStrings.OwnerFilterCaption,columnName:"Owner",defValue:t.SysValue.CURRENT_USER_CONTACT,dataValueType:t.DataValueType.LOOKUP,filter:a.OwnerFilter,appendFilter:function(n){var i;return n.value&&n.value.length>0&&(i=t.createColumnInFilterWithParameters("[ActivityParticipant:Activity].Participant",n.value)),i}}]};this.methods.modifyItems=function(n){n.each(function(n){var i=n.columns;t.each(i,function(n){n.type=t.ViewModelColumnType.ENTITY_COLUMN},this);n.set("SchedulerStatus",w(n));n.editLink=this.getLink(n,"linkEdit",this);n.replyLink=this.getLink(n,"linkReply",this);n.replyAllLink=this.getLink(n,"linkReplyAll",this);n.forwardLink=this.getLink(n,"linkForward",this);n.getForwardButtonsVisible=function(){var n=!1,t=this.get("Type"),i=this.get("EmailSendStatus");return t.value===c.Activity.Type.Email&&i.value===c.Activity.EmailSendStatus.Sended&&(n=!0),n};n.getSendButtonsVisible=function(){var n=!1,t=this.get("Type"),i=this.get("EmailSendStatus");return t.value===c.Activity.Type.Email&&i.value!==c.Activity.EmailSendStatus.Sended&&(n=!0),n};n.getReplyButtonsVisible=function(){var n=!1,t=this.get("Type"),i=this.get("MessageType");return t.value===c.Activity.Type.Email&&i.value===c.Activity.MessageType.Incoming&&(n=!0),n}},this)};this.methods.synchronizeWithGoogleCalendar=function(){v.ShowBodyMask();var r=t.workspaceBaseUrl+"/ServiceModel/ProcessEngineService.svc/SynchronizeCalendarWithGoogleModuleProcess/Execute?ResultParameterName=SyncResult",i=this;n.Ajax.request({url:r,headers:{"Content-Type":"application/json",Accept:"application/json"},method:"POST",scope:this,callback:function(r,u,e){var s,h,o,c;u?(h=e.responseXML.firstChild.textContent,o=n.decode(n.decode(h)),n.isEmpty(o)?s=f.localizableStrings.SyncProcessFail:o.addedRecordsInBPMonlineCount?(i.clear(),i.load(),c=n.String.format(f.localizableStrings.SynchronizeWithGoogleSyncResult,o.addedRecordsInBPMonlineCount,o.updatedRecordsInBPMonlineCount,o.deletedRecordsInBPMonlineCount,o.addedRecordsInGoogleCount,o.updatedRecordsInGoogleCount,o.deletedRecordsInGoogleCount),t.utils.showInformation(c,null,null,{buttons:["ok"]})):o.settingsNotSet?s=f.localizableStrings.SettingsNotSet:(s=f.localizableStrings.SyncProcessFail,n.isString(o)&&(s=s+": \r\n"+o))):s=f.localizableStrings.CallbackFailed;v.HideBodyMask();s&&t.utils.showInformation(s,null,null,{buttons:["ok"]})}})};this.methods.applySectionConfig=function(n){n!==undefined&&n!==null&&n.isHomePage&&(p=!0)};this.methods.loadImapEmails=function(){window.console.warn(n.String.format(t.Resources.ObsoleteMessages.ObsoleteMethodMessage,"loadImapEmails","loadEmails"));this.loadEmails()};this.methods.loadEmails=function(){var r,i;if(!this.get("isMailboxSyncExist")){r={buttons:[t.MessageBoxButtons.OK.returnCode],defaultButton:0};t.showInformation(f.localizableStrings.MailboxSettingsEmpty,function(){},this,r);return}i=n.create("Terrasoft.EntitySchemaQuery",{rootSchemaName:"ActivityFolder"});i.addColumn("Id");i.filters.addItem(i.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"[MailboxSyncSettings:MailboxName:Name].SysAdminUnit",t.SysValue.CURRENT_USER.value));i.getEntityCollection(function(i){i.success&&t.each(i.collection.getItems(),function(i){var r=t.workspaceBaseUrl+"/ServiceModel/ProcessEngineService.svc/LoadImapEmailsProcess/Execute?ResultParameterName=LoadResult&MailBoxFolderId="+i.get("Id");v.ShowBodyMask();n.Ajax.request({url:r,headers:{"Content-Type":"application/json",Accept:"application/json"},method:"POST",scope:this,callback:function(i,r,u){var e,o;v.HideBodyMask();r&&(o=u.responseXML.firstChild.textContent,e=n.decode(n.decode(o)),this.clear(),this.load(),t.utils.showInformation(f.localizableStrings.LoadImapEmailsResult,null,null,{buttons:["ok"]}));e.Messages.length>0&&t.each(e.Messages,function(n){t.utils.showInformation(n.message,null,null,{buttons:["ok"]})},this)}})},this)},this)}},u});define("ActivitySection",["ext-base","terrasoft","sandbox","Activity","ActivitySectionStructure","ActivitySectionResources","ProcessModule","SectionViewGenerator","ActionUtilitiesModule","ConfigurationEnums","ConfigurationConstants","EmailUtilities","BaseFiltersGenerateModule","MaskHelper","ExchangeNUIConstants"],function(n,t,i,r,u,f,e,o,s,h,c,l,a,v,y){return u.userCode=function(){function i(i){var u=0,r=[];t.each(i,function(i){var e;e=i.get("MailServerTypeId")===y.MailServer.Type.Exchange?t.workspaceBaseUrl+"/ServiceModel/ProcessEngineService.svc/LoadExchangeEmailsProcess/Execute?ResultParameterName=LoadResult&SenderEmailAddress="+i.get("SenderEmailAddress"):t.workspaceBaseUrl+"/ServiceModel/ProcessEngineService.svc/LoadImapEmailsProcess/Execute?ResultParameterName=LoadResult&MailBoxFolderId="+i.get("Id");v.ShowBodyMask();u++;n.Ajax.request({url:e,timeout:18e4,headers:{"Content-Type":"application/json",Accept:"application/json"},method:"POST",scope:this,callback:function(i,e,o){var h,s;e&&(h=n.decode(n.decode(o.responseXML.firstChild.textContent)),h.Messages.length>0&&(r=r.concat(h.Messages)));--u<=0&&(this.clear(),this.load(),s=f.localizableStrings.LoadImapEmailsResultEx,r.length>0&&(s="",t.each(r,function(t){s=s.concat(n.String.format("[{0}]: {1} ",t.key,t.message))},this)),v.HideBodyMask(),t.utils.showInformation(s,null,null,{buttons:["ok"]}))}})},this)}this.methods.loadEmails=function(){var u,r;if(!this.get("isMailboxSyncExist")){u={buttons:[t.MessageBoxButtons.OK.returnCode],defaultButton:0};t.showInformation(f.localizableStrings.MailboxSettingsEmptyEx,function(){},this,u);return}r=n.create("Terrasoft.EntitySchemaQuery",{rootSchemaName:"ActivityFolder"});r.addColumn("Id");r.addColumn("[MailboxSyncSettings:MailboxName:Name].SenderEmailAddress","SenderEmailAddress");r.addColumn("[MailboxSyncSettings:MailboxName:Name].MailServer.Type.Id","MailServerTypeId");r.filters.addItem(r.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"[MailboxSyncSettings:MailboxName:Name].SysAdminUnit",t.SysValue.CURRENT_USER.value));r.getEntityCollection(function(n){n.success&&i.call(this,n.collection.getItems())},this)}},u})
Terrasoft.configuration.Structures.ActivitySectionCSS={innerHierarchyStack:["ActivitySectionCSS"]};define("ActivitySectionCSS",[],function(){return{}})
Terrasoft.configuration.Structures.ActivityUtilities={innerHierarchyStack:["ActivityUtilities"]};define("ActivityUtilities",["ext-base","terrasoft","ConfigurationConstants"],function(n,t,i){function r(r,f,e,o){var h=f.get("AllowedResult"),c=h&&h.length>0,s;f.set("isResultGroupVisible",c);f.set("isStatusGroupVisible",!c);c?(h=n.decode(f.get("AllowedResult")),s=n.create("Terrasoft.EntitySchemaQuery",{rootSchemaName:"ActivityResult"}),s.addColumn("Id"),s.addColumn("Name"),s.addColumn("Category"),s.getEntityCollection(function(r){var c=r.collection.collection,v,s;if(c.length>0){var l=[],a=i.Activity.ResultCategory.Neutral.toLowerCase(),y=i.Activity.ResultCategory.Fail.toLowerCase();t.each(h,function(t){var r="green",u=0,f=c.map[t],i=f.values.Category.value;i=n.isEmpty(i)?a:i.toLowerCase();i===y?(r="red",u=2):i===a&&(r="grey",u=1);l.push({resultId:t,caption:f.values.Name,color:r,index:u})},this);v=2;s=n.getCmp("autoGeneratedLeftContainer").items.items[v];s.items.items[0].add(n.create("Terrasoft.Container",u(l,o)));s.bind(f);e()}},this)):e()}function u(n,r){var u={className:"Terrasoft.Container",id:"custom-results-container",selectors:{wrapEl:"#custom-results-container"},items:[]},f=1,e=i.Activity.Status.Cancel,o=i.Activity.Status.Done;return n.sort(function(n,t){var i=n.index-t.index;return i===0&&(n.caption<t.caption?i=-1:n.caption>t.caption&&(i=1)),i}),t.each(n,function(n){var i=n.color,s=i==="red"?e:o,h=t.ImageUrlBuilder.getUrl(r.localizableImages[i+"ResultIcon"]);u.items.push({className:"Terrasoft.Container",id:"custom-result-item-container"+f,selectors:{wrapEl:"#custom-result-item-container"+f},styles:{wrapStyles:{"margin-bottom":"9px"}},items:[{className:"Terrasoft.Button",caption:n.caption,style:t.controls.ButtonEnums.style.TRANSPARENT,iconAlign:t.controls.ButtonEnums.iconAlign.LEFT,imageConfig:{source:t.ImageSources.URL,url:h},click:{bindTo:"resultButtonClick"},visible:{bindTo:"resultSelected",bindConfig:{converter:function(t){var i=this.get("isResultGroupVisible"),r=n.resultId;return i&&(!t||this.get("Result").value===r)}}},tag:'{"result": {"value": "'+n.resultId+'"},"status": {"value": "'+s+'"}}'}]});f++},this),u.items.push({className:"Terrasoft.Label",visible:{bindTo:"resultSelected"},caption:r.localizableStrings.DetailedResultCaption,classes:{labelClass:"controlCaption"}}),u.items.push({className:"Terrasoft.MemoEdit",height:"77px",visible:{bindTo:"resultSelected"},value:{bindTo:"DetailedResult"}}),u.items.push({className:"Terrasoft.Container",id:"detailResultControlsContainer",classes:["utils-left"],selectors:{wrapEl:"#detailResultControlsContainer"},items:[{className:"Terrasoft.Button",style:t.controls.ButtonEnums.style.BLUE,caption:r.localizableStrings.OkResultButtonCaption,click:{bindTo:"save"},visible:{bindTo:"resultSelected"}},{className:"Terrasoft.Button",caption:r.localizableStrings.CancelResultButtonCaption,click:{bindTo:"cancelResultSelected"},visible:{bindTo:"resultSelected"}}]}),u}return{customizeView:r}})
Terrasoft.configuration.Structures.ActivityWorkDoneReportFilter={innerHierarchyStack:["ActivityWorkDoneReportFilter"]};define("ActivityWorkDoneReportFilter",["ActivityWorkDoneReportFilterResources","ConfigurationConstants"],function(n,t){var i=Terrasoft.startOfWeek(Ext.Date.add(new Date,"d",-7)),r=Terrasoft.endOfWeek(i);return[{name:"PeriodFilter",dataValueType:"PeriodFilter",columnName:"DueDate",startDate:{defValue:i},dueDate:{defValue:r}},{name:"Owner",caption:n.localizableStrings.Owner,dataValueType:"LOOKUP",columnName:"Owner",defValue:Terrasoft.SysValue.CURRENT_USER_CONTACT,parameterName:"OwnerId"},{name:"Type",caption:n.localizableStrings.Type,dataValueType:"ENUM",columnName:"Type",defValue:{value:t.Activity.Type.Task,displayValue:n.localizableStrings.TaskCaption},parameterName:"ActivityType"}]})
Terrasoft.configuration.Structures.AddDataUserTaskItemInitializer={innerHierarchyStack:["AddDataUserTaskItemInitializer"]};define("AddDataUserTaskItemInitializer",["BaseProcessFlowElementSchemaItemInitializer"],function(){Terrasoft.AddDataUserTaskItemInitializer=(class extends Terrasoft.BaseProcessFlowElementSchemaItemInitializer{getElementEntityParameterName(){return"EntitySchemaId"}})})
Terrasoft.configuration.Structures.AddPostModule={innerHierarchyStack:["AddPostModule"]};define("AddPostModule",[],function(){function n(n){n.sandbox.publish("PushHistoryState",{hash:"SectionModuleV2/ESNFeedSectionV2",stateObj:{focusAddPost:!0,moduleId:n.sandbox.id+"_ESNFeedSection"}})}return{Run:n}})
Terrasoft.configuration.Structures.AddTagView={innerHierarchyStack:["AddTagView"]};define("AddTagView",["ext-base","terrasoft","AddTagViewResources"],function(n,t,i){function u(){return{id:"simpleTagFilterEditContainer",selectors:{el:"#simpleTagFilterEditContainer",wrapEl:"#simpleTagFilterEditContainer"},classes:{wrapClassName:"tag-inner-container"},items:[r("Terrasoft.TextEdit"),{className:"Terrasoft.Button",imageConfig:i.localizableImages.ApplyButtonImage,style:t.controls.ButtonEnums.style.BLUE,classes:{wrapperClass:["tag-element-with-right-space"]},click:{bindTo:"applyTag"}},{className:"Terrasoft.Button",imageConfig:i.localizableImages.CancelButtonImage,click:{bindTo:"destroyTagAddingContainer"}}],destroy:{bindTo:"clearTagProperties"}}}function f(){return{id:"tagContainer",selectors:{el:"#tagContainer",wrapEl:"#tagContainer"},tpl:['<span id="{id}" style="{wrapStyles}" class="{wrapClassName}">',"{%this.renderItems(out, values)%}","<\/span>"],items:[{className:"Terrasoft.Container",id:"tagFilterButtonContainer",selectors:{el:"#tagFilterButtonContainer",wrapEl:"#tagFilterButtonContainer"},classes:{wrapClassName:"tag-inner-container"},items:[{className:"Terrasoft.Button",imageConfig:i.localizableImages.ImageFilter,style:t.controls.ButtonEnums.style.TRANSPARENT,classes:{wrapperClass:"image-container"}}]},{className:"Terrasoft.Container",id:"tagCommonContainer",selectors:{el:"#tagCommonContainer",wrapEl:"#tagCommonContainer"},items:[]},{className:"Terrasoft.Container",id:"addTagButtonContainer",selectors:{el:"#addTagButtonContainer",wrapEl:"#addTagButtonContainer"},classes:{wrapClassName:"tag-inner-container"},items:[{className:"Terrasoft.Button",caption:{bindTo:"getAddButtonCaption"},style:t.controls.ButtonEnums.style.TRANSPARENT,click:{bindTo:"addTag"},visible:{bindTo:"editVisible"}}]}]}}function r(t){var r={classes:{wrapClass:"tag-simple-tag-edit"},value:{bindTo:"tagValueColumn"},enterkeypressed:{bindTo:"applyTag"},placeholder:i.localizableStrings.TagEmptyValueEditPlaceHolder};return t.className?n.apply(r,t):r.className=t,r}function e(n,r){return{classes:{wrapClassName:["tag-inner-container","tag-"+r]},visible:{bindTo:"viewVisible",bindConfig:{converter:function(n){return n===!1?!1:!0}}},items:[{className:"Terrasoft.Label",classes:{labelClass:["tag-value-label","tag-element-with-right-space"]},caption:{bindTo:"displayValue"},click:{bindTo:"editTag"},tag:n},{className:"Terrasoft.Button",classes:{wrapperClass:"tag-remove-button"},style:t.controls.ButtonEnums.style.TRANSPARENT,imageConfig:i.localizableImages.RemoveButtonImage,visible:{bindTo:"readOnlyMode",bindConfig:{converter:function(n){return!n}}},click:{bindTo:"removeTag"},tag:n}]}}return{generate:f,generateAddTagConfig:u,getTagValueEditConfig:r,generateTagViewConfig:e}})
Terrasoft.configuration.Structures.AdministrationSystemDesignerSectionV2={innerHierarchyStack:["AdministrationSystemDesignerSectionV2"],structureParent:"BaseSystemDesignerSectionV2"};define("AdministrationSystemDesignerSectionV2Structure",["AdministrationSystemDesignerSectionV2Resources"],function(){return{schemaUId:"2b284b3b-22d8-49de-bb9a-79e5cfff47c6",schemaCaption:"Users and administration",parentSchemaName:"BaseSystemDesignerSectionV2",packageName:"CrtUIv2",schemaName:"AdministrationSystemDesignerSectionV2",parentSchemaUId:"11d4ac38-ad67-4331-968a-5376ebb77b6f",extendParent:!1,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("AdministrationSystemDesignerSectionV2",["terrasoft"],function(){return{diff:[]}})
Terrasoft.configuration.Structures.Angular7xDetailModule={innerHierarchyStack:["Angular7xDetailModule"]};define("Angular7xDetailModule",["@creatio-devkit/common","Base7xViewElement"],function(n,t){class i extends t{set defaultValues(n){n&&(this._defaultValues=n,this._init())}get defaultValues(){return this._defaultValues?.map(n=>({name:n.name,value:n.value?.value||n.value}))||[]}set config(n){n&&(this._config=n,this._init())}get config(){return this._config||[]}constructor(){super("Angular7xDetail")}_init(){if(this._isValidConfig()){const n=this;this._initTimeout&&clearTimeout(this._initTimeout);this._initTimeout=setTimeout(()=>{this.initContext(()=>{this._moduleId=this._getSandboxModuleId(),this._subscribeOnEvents(n),this._loadDetailModule()})},200)}}_isValidConfig(){return!!this._getValueFromConfig("detailName")&&!!this._getValueFromConfig("masterRecordId")}_getSandboxModuleId(){const n=this._getValueFromConfig("moduleIdSuffix");return n?this.sandbox.id+n:this.sandbox.id+"_module_Angular7xDetailModule"}_subscribeOnEvents(n){this._subscribeOnGetDetailInfo();this._subscribeOnUpdateCardProperty(n)}_subscribeOnGetDetailInfo(){const n=this;this.sandbox.subscribe("GetDetailInfo",function(){return{detailName:n._getValueFromConfig("detailName"),schemaName:n._getValueFromConfig("schemaName"),masterRecordId:n._getValueFromConfig("masterRecordId"),defaultValues:n.defaultValues,isEnabled:!0,isFormPage:!0}},null,[this._moduleId])}_subscribeOnUpdateCardProperty(n){const t=this;this.sandbox.subscribe("UpdateCardProperty",function(i){if(t._isNeedToFireDetailChanged(i)){const r=new CustomEvent("detailChanged",{detail:t._createDetailChangedEventData(t)});n.dispatchEvent(r)}},null,[this._moduleId])}_loadDetailModule(){this.destroyed=new Promise(n=>{this.resolveDestroyedFn=function(){n()}});this.sandbox.loadModule("DetailModuleV2",{renderTo:this._renderTo,id:this._moduleId})}_saveDetail(){this.sandbox.publish("SaveDetail",null,[this._moduleId])}_discardChangeDetail(){this.sandbox.publish("DiscardChanges",null,[this._moduleId])}_isCurrentDetailInValue(n){return Array.isArray(n)&&n.includes(this._moduleId)}_isNeedToFireDetailChanged(n){return(n.key=="ShowSaveButton"||n.key=="ShowDiscardButton")&&n.value==!0}_createDetailChangedEventData(n){const t=n._moduleId;return{detailId:t,saveChanges:()=>new Promise(function(i,r){n.sandbox.subscribe("DetailSaved",function(u){n.sandbox.unsubscribePtp("DetailSaved",[t]);u.success?i():r(u)},null,[t]);n._saveDetail()}),discardChanges:()=>(n._discardChangeDetail(),Promise.resolve()),destroyed:()=>n.destroyed}}_getValueFromConfig(n){return this.config.find(t=>t.name===n)?.value}disconnectedCallback(){this.sandbox.unloadModule(this._moduleId,this._renderTo);this.resolveDestroyedFn();super.disconnectedCallback()}getMessages(){const n=super.getMessages();return Object.assign(n,{GetDetailInfo:{mode:Terrasoft.MessageMode.PTP,direction:Terrasoft.MessageDirectionType.SUBSCRIBE},UpdateCardProperty:{mode:Terrasoft.MessageMode.PTP,direction:Terrasoft.MessageDirectionType.SUBSCRIBE},DetailSaved:{mode:Terrasoft.MessageMode.PTP,direction:Terrasoft.MessageDirectionType.SUBSCRIBE},SaveDetail:{mode:Terrasoft.MessageMode.PTP,direction:Terrasoft.MessageDirectionType.PUBLISH},DiscardChanges:{mode:Terrasoft.MessageMode.BROADCAST,direction:Terrasoft.MessageDirectionType.PUBLISH}})}}return customElements.define("crt-angular-7x-detail",i),n.registerViewElement({type:"crt.Angular7XDetail",selector:"crt-angular-7x-detail",inputs:{defaultValues:[],config:[]},outputs:{detailChanged:{}}}),Terrasoft.Angular7xDetailModule})
Terrasoft.configuration.Structures.AnniversaryDetail={innerHierarchyStack:["AnniversaryDetail"]};define("AnniversaryDetailStructure",function(){return{type:Terrasoft.SchemaType.EDIT_CONTROLS_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{attributes:[]},methods:{},schemaDifferences:function(){}}});define("AnniversaryDetail",["ext-base","terrasoft","ContactAnniversary","AccountAnniversary","AnniversaryDetailStructure","AnniversaryDetailResources"],function(n,t,i,r,u,f){var e=function(n,t){var i={className:"Terrasoft.Container",items:[],id:n,selectors:{wrapEl:"#"+n}};return t&&(i.classes={wrapClassName:t}),i};return u.userCode=function(){var u;this.selectedItem={};switch(this.filterPath){case"Contact":this.entitySchema=i;u="Contact";break;case"Account":this.entitySchema=r;u="Account"}this.name="AnniversaryDetailViewModel";this.parentColumnPath="Id";this.typeColumn="AnniversaryType";this.filterColumnPath=u;this.attributes=[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"AnniversaryType",columnPath:"AnniversaryType",dataValueType:t.DataValueType.ENUM,visible:!1,captionVisible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Date",columnPath:"Date",dataValueType:t.DataValueType.DATE,visible:!0,captionVisible:!0,caption:{bindTo:"AnniversaryType.Name"}},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:u,columnPath:u,dataValueType:t.DataValueType.ENUM,visible:!1,viewVisible:!1}];this.defValues=[];this.methods.typeChanged=function(n){this.selectedItem=n};this.methods.getCustomItemView=function(i,r,u,o){t.each(o,function(n){n.click={bindTo:"typeChanged"}});var c=i.attributes,s=c[0],l=c[1],h=e(r+"-view","detail-view-container-user-class");switch(u){case"add":case"copy":case"edit":var a=e(r+"-title","controlCaption"),v=e(r+"-value"),p={id:r+"-type",className:"Terrasoft.Button",classes:{wrapperClass:"detail-type-btn-user-class",innerWrapperClass:"communication-detail-type-btn-inner-user-class"},style:t.controls.ButtonEnums.style.TRANSPARENT,selectors:{wrapEl:"#"+r+"-type"},caption:{bindTo:s.name,bindConfig:{converter:t.getTypedStringValue}},menu:{items:o}},w={id:r+"-delete",className:"Terrasoft.Button",classes:{wrapperClass:"detail-delete-btn-user-class"},imageConfig:f.localizableImages.DeleteIcon,style:t.controls.ButtonEnums.style.TRANSPARENT,selectors:{wrapEl:"#"+r+"-delete"},click:{bindTo:"delete"}},b={id:r+"-edit",className:"Terrasoft.DateEdit",value:{bindTo:l.name}};a.items.push(p,w);v.items.push(b);h.items.push(a,v);break;case"view":var k={className:"Terrasoft.Label",labelClass:"t-label communication-detail-type-lbl-user-class",caption:{bindTo:s.name,bindConfig:{converter:t.getTypedStringValue}},visible:{bindTo:s.name,bindConfig:{converter:function(t){return n.isEmpty(t)?!1:!0}}}},d={className:"Terrasoft.Label",labelClass:"t-label communication-detail-number-lbl-user-class",caption:{bindTo:l.name,bindConfig:{converter:t.getTypedStringValue}},visible:{bindTo:s.name,bindConfig:{converter:function(t){return n.isEmpty(t)?!1:!0}}}},y=e(r+"-empty","detail-empty-user-class");y.visible={bindTo:s.name,bindConfig:{converter:function(t){return n.isEmpty(t)?!1:!0}}};h.items.push(k,d,y)}return h};this.methods.getAddItems=function(n){return n};this.methods.onLookUpClick=function(){return};this.methods.save=function(){};this.loadedColumns=[{columnPath:"Date"},{columnPath:"AnniversaryType"},{columnPath:u}]},u})
Terrasoft.configuration.Structures.AuthInfoUsernameValuePage={innerHierarchyStack:["AuthInfoUsernameValuePage"],structureParent:"AuthInfoParameterValuePage"};define("AuthInfoUsernameValuePageStructure",["AuthInfoUsernameValuePageResources"],function(){return{schemaUId:"44ad135e-4354-4507-a7f6-c0663fe916d1",schemaCaption:"AuthInfoUsernameValuePage",parentSchemaName:"AuthInfoParameterValuePage",packageName:"ServiceDesigner",schemaName:"AuthInfoUsernameValuePage",parentSchemaUId:"14c99d52-3f74-4839-9720-fb520db4ba10",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("AuthInfoUsernameValuePage",[],function(){return{attributes:{AuthInfoPropertyName:{value:"username"}}}})
Terrasoft.configuration.Structures.AutoGeneratedPageV2Utilities={innerHierarchyStack:["AutoGeneratedPageV2Utilities"]};define("AutoGeneratedPageV2Utilities",["terrasoft","ext-base","AutoGeneratedPageV2UtilitiesResources"],function(n,t){function f(n){return n+c}function a(t){const r=t.pageSchema.utils;for(var u=0;u<r.length;u++){const f=r[u];i.push(v(f,u))}i.push({operation:"merge",name:"CloseButton",values:{visible:!1}});i.push({operation:"insert",parentName:"LeftContainer",propertyName:"items",name:"AutoGeneratedPageV2CloseButton",index:r.length,values:{itemType:n.ViewItemType.BUTTON,caption:{bindTo:"Resources.Strings.CloseButtonCaption"},classes:{textClass:"actions-button-margin-right"},click:{bindTo:"onCloseClick"},layout:{column:r.length,row:0,colSpan:2}}})}function v(t,i){return{operation:"insert",name:t.name,parentName:h,propertyName:"items",index:i,values:{itemType:n.ViewItemType.BUTTON,caption:t.caption,enabled:t.enabled,style:t.style,layout:{column:i,row:0,colSpan:2},classes:{textClass:"actions-button-margin-right"},click:{bindTo:t.validate===!0?"completeProcessElementWithVerification":"completeProcessElement"},tag:t.name}}}function y(t){const i={dataValueType:t.dataValueType,caption:t.caption,isProcessUserTaskParameterAttribute:!0};t.dataValueType===n.DataValueType.FLOAT&&(i.precision=l);t.isRequired===!0&&(i.isRequired=!0);o(t.dataValueType)&&(i.isLookup=!0,i.referenceSchemaName=t.referenceSchemaName,u[f(t.name)]={isCollection:!0});u[t.name]=i}function p(t){r[f(t.name)]=new n.Collection}function o(t){return t===n.DataValueType.LOOKUP||t===n.DataValueType.ENUM}function s(n,t,r){let u;o(n.dataValueType)?(u=k(n),p(n)):u=n.text?w(n):b(n);u.parentName=t;r!==null&&(u.values.layout={column:0,row:r,colSpan:12});i.push(u);y(n)}function w(t){return{operation:"insert",name:t.name,propertyName:"items",values:{itemType:n.ViewItemType.LABEL,caption:{bindTo:t.name},classes:{labelClass:["information","recommendation"]}}}}function b(t){const i={operation:"insert",name:t.name,propertyName:"items",values:{caption:t.caption,bindTo:t.name}};return t.isMultiLine===!0&&(i.values.contentType=n.ContentType.LONG_TEXT),i}function k(t){const i={operation:"insert",propertyName:"items",name:t.name,values:{caption:t.caption,contentType:n.ContentType.LOOKUP,bindTo:t.name,controlConfig:{tag:t.name}}};if(t.dataValueType===n.DataValueType.ENUM)i.values.contentType="Terrasoft.ContentType.ENUM";else{const r=i.values.controlConfig;r.list={bindTo:f(t.name)};r.loadVocabulary={bindTo:"loadVocabulary"}}return i}function d(i,r,u,f){return{operation:"insert",parentName:u,name:r,propertyName:"items",values:{itemType:n.ViewItemType.CONTROL_GROUP,items:[],caption:i.caption,controlConfig:{collapsed:t.isEmpty(i.collapsed)?!1:i.collapsed},visible:t.isEmpty(i.visible)?!0:i.visible,layout:{column:0,row:f,colSpan:12}}}}const h="LeftContainer",e="AutoGeneratedPageContentBlock",c="List";let u=null,i=null,r=null;const l=2;return{getCustomValues:function(n){return n.parameters&&t.apply(r,n.parameters),r.header=n.title,r},getCustomAttributes:function(){return u},getCustomDiff:function(f){i=[];r={};u={};a(f);const o=f.pageSchema.schema.leftContainer;if(!o||o.length===0)return i;let h=0;return n.each(o,function(r){switch(r.type){case n.ViewModelSchemaItem.ATTRIBUTE:s(r,e,h);break;case n.ViewModelSchemaItem.GROUP:const o=r.name+"ControlGroup";i.push(d(r,o,e,h));const u=r.items;if(t.isArray(u))for(var f=0;f<u.length;f++){const c=u[f];s(c,o,null)}break;default:throw new n.UnsupportedTypeException({message:r.type?r.type.toString():this.get("Resources.Strings.UnsupportedType")});}h++}),i}}})
Terrasoft.configuration.Structures.AutosizeModule={innerHierarchyStack:["AutosizeModule"]};define("AutosizeModule",["ext-base","terrasoft","css!AutosizeModule"],function(n,t){function i(n){var f={className:"autosizejs",id:"autosizejs",append:"",callback:!1,resizeDelay:1,placeholder:!0},u=["fontFamily","fontSize","fontWeight","fontStyle","letterSpacing","textTransform","wordSpacing","textIndent"],r,i=n("<textarea tabindex='-1' style='position:absolute; top:-999px; left:0; right:auto; bottom:auto; border:0; padding: 0; -moz-box-sizing:content-box; -webkit-box-sizing:content-box; box-sizing:content-box; word-wrap:break-word; height:0 !important; min-height:0 !important;overflow:hidden; transition:none; -webkit-transition:none; -moz-transition:none;'/>").data("autosize",!0)[0];i.style.lineHeight="99px";n(i).css("lineHeight")==="99px"&&u.push("lineHeight");i.style.lineHeight="";n.fn.autosize=function(e){return this.length?(e=n.extend({},f,e||{}),i.parentNode!==document.body&&n(document.body).append(i),this.each(function(){function y(){var n,r=window.getComputedStyle?window.getComputedStyle(o,null):!1;r?(n=o.getBoundingClientRect().width,n===0&&(n=parseInt(r.width,10)),t.each(["paddingLeft","paddingRight","borderLeftWidth","borderRightWidth"],function(t){n-=parseInt(r[t],10)})):n=Math.max(f.width(),0);i.style.width=n+"px"}function k(){var s={},c;r=o;i.className=e.className;i.id=e.id;h=parseInt(f.css("maxHeight"),10);t.each(u,function(n){s[n]=f.css(n)});n(i).css(s).attr("wrap",f.attr("wrap"));y();window.chrome&&(c=o.style.width,o.style.width="0px",o.style.width=c)}function s(){var n,t;r!==o?k():y();i.value=!o.value&&e.placeholder?(f.attr("placeholder")||"")+e.append:o.value+e.append;i.style.overflowY=o.style.overflowY;t=parseInt(o.style.height,10);i.scrollTop=0;i.scrollTop=9e4;n=i.scrollTop;h&&n>h?(o.style.overflowY="scroll",n=h):(o.style.overflowY="hidden",n<c&&(n=c));n+=l;t!==n&&(o.style.height=n+"px");w&&e.callback.call(o,o)}function p(){clearTimeout(a);a=setTimeout(function(){var n=f.width();n!==v&&(v=n,s())},parseInt(e.resizeDelay,10))}var o=this,f=n(o),h,c,l=0,w=n.isFunction(e.callback),b={height:o.style.height,overflow:o.style.overflow,overflowY:o.style.overflowY,wordWrap:o.style.wordWrap,resize:o.style.resize},a,v=f.width();if(!f.data("autosize")){if(f.data("autosize",!0),(f.css("box-sizing")==="border-box"||f.css("-moz-box-sizing")==="border-box"||f.css("-webkit-box-sizing")==="border-box")&&(l=f.outerHeight()-f.height()),c=Math.max(parseInt(f.css("minHeight"),10)-l||0,f.height()),f.css({overflow:"hidden",overflowY:"hidden",wordWrap:"break-word",resize:f.css("resize")==="none"||f.css("resize")==="vertical"?"none":"horizontal"}),"onpropertychange"in o)if("oninput"in o)f.on("input.autosize keyup.autosize",s);else f.on("propertychange.autosize",function(){event.propertyName==="value"&&s()});else f.on("input.autosize",s);if(e.resizeDelay!==!1)n(window).on("resize.autosize",p);f.on("autosize.resize",s);f.on("autosize.resizeIncludeStyle",function(){r=null;s()});f.on("autosize.destroy",function(){r=null;clearTimeout(a);n(window).off("resize",p);f.off("autosize").off(".autosize").css(b).removeData("autosize")});s()}})):this}}function r(n,t){window.jQueryAutosize===!0&&n.call(t);require(["jQuery"],function(){i(window.jQuery||window.$);window.jQueryAutosize=!0;n.call(t)})}function u(t,i){var s=n.get(t+"-scroll"),r,u,f,o,h;if(s){s.addCls("autosize-hide-scrollbar");r=$("#"+t+"-el");for(u in i){f=i[u];for(o in f)h=f[o],r[u](o,h)}r.autosize({callback:e})}}function f(n){$("#"+n+"-el").trigger("autosize.resize")}function e(){var n=$(this),t=n.css("minHeight"),i=n.height()+"px";n.css({"line-height":"normal","padding-top":"7px"})}return{init:r,attach:u,refresh:f}})
Terrasoft.configuration.Structures.BaseAddressPageV2={innerHierarchyStack:["BaseAddressPageV2"],structureParent:"BasePageV2"};define("BaseAddressPageV2Structure",["BaseAddressPageV2Resources"],function(){return{schemaUId:"81234854-097b-4248-bf1c-826717e7467d",schemaCaption:"Base address page",parentSchemaName:"BasePageV2",packageName:"CrtUIv2",schemaName:"BaseAddressPageV2",parentSchemaUId:"d3cc497c-f286-4f13-99c1-751c468733c0",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("BaseAddressPageV2",["BusinessRuleModule"],function(n){return{diff:[{operation:"merge",name:"Tabs",values:{visible:!1}},{operation:"merge",name:"actions",values:{visible:!1}},{operation:"insert",parentName:"Header",propertyName:"items",name:"Country",values:{bindTo:"Country",layout:{column:0,row:0,colSpan:12}}},{operation:"insert",parentName:"Header",propertyName:"items",name:"AddressType",values:{bindTo:"AddressType",contentType:Terrasoft.ContentType.ENUM,layout:{column:12,row:0,colSpan:12}}},{operation:"insert",parentName:"Header",propertyName:"items",name:"Region",values:{bindTo:"Region",layout:{column:0,row:1,colSpan:12},tip:{content:{bindTo:"Resources.Strings.RegionFilterRuleTip"}}}},{operation:"insert",parentName:"Header",propertyName:"items",name:"Zip",values:{bindTo:"Zip",layout:{column:12,row:1,colSpan:12}}},{operation:"insert",parentName:"Header",propertyName:"items",name:"City",values:{bindTo:"City",layout:{column:0,row:2,colSpan:12},tip:{content:{bindTo:"Resources.Strings.CityFilterRuleTip"}}}},{operation:"insert",parentName:"Header",propertyName:"items",name:"Primary",values:{bindTo:"Primary",layout:{column:12,row:2,colSpan:12}}},{operation:"insert",parentName:"Header",propertyName:"items",name:"Address",values:{bindTo:"Address",layout:{column:0,row:3,colSpan:12}}}],rules:{Region:{FiltrationRegionByCountry:{ruleType:n.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!0,baseAttributePatch:"Country",comparisonType:Terrasoft.ComparisonType.EQUAL,type:n.enums.ValueType.ATTRIBUTE,attribute:"Country"}},City:{FiltrationCityByCountry:{ruleType:n.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!0,baseAttributePatch:"Country",comparisonType:Terrasoft.ComparisonType.EQUAL,type:n.enums.ValueType.ATTRIBUTE,attribute:"Country"},FiltrationCityByRegion:{ruleType:n.enums.RuleType.FILTRATION,autocomplete:!0,autoClean:!0,baseAttributePatch:"Region",comparisonType:Terrasoft.ComparisonType.EQUAL,type:n.enums.ValueType.ATTRIBUTE,attribute:"Region"}}}}})
Terrasoft.configuration.Structures.BaseAnniversaryPageV2={innerHierarchyStack:["BaseAnniversaryPageV2"],structureParent:"BasePageV2"};define("BaseAnniversaryPageV2Structure",["BaseAnniversaryPageV2Resources"],function(){return{schemaUId:"200b6193-7c8d-4b19-adcb-095515a2caab",schemaCaption:"Base noteworthy event page",parentSchemaName:"BasePageV2",packageName:"CrtUIv2",schemaName:"BaseAnniversaryPageV2",parentSchemaUId:"d3cc497c-f286-4f13-99c1-751c468733c0",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("BaseAnniversaryPageV2",[],function(){return{diff:[{operation:"merge",name:"actions",values:{visible:!1}},{operation:"merge",name:"Tabs",values:{visible:!1}},{operation:"insert",parentName:"Header",propertyName:"items",name:"AnniversaryType",values:{contentType:Terrasoft.ContentType.ENUM,layout:{column:0,row:0,colSpan:12}}},{operation:"insert",parentName:"Header",propertyName:"items",name:"Date",values:{layout:{column:0,row:1,colSpan:12}}}]}})
Terrasoft.configuration.Structures.BaseProcessFlowElementSchemaItemInitializer={innerHierarchyStack:["BaseProcessFlowElementSchemaItemInitializer"]};define("BaseProcessFlowElementSchemaItemInitializer",[],function(){Terrasoft.BaseProcessFlowElementSchemaItemInitializer=(class{constructor(n,t){this.element=n;this.sandbox=t}_initElementParameter(n,t){const i=this.element.findParameterByName(n);i&&t&&(i.isResult=!0,i.setMappingValue(t))}getElementEntityParameterName(){return""}getElementEntityParameterValue(n){const t=n.referenceSchemaUId;return{source:Terrasoft.ProcessSchemaParameterValueSource.ConstValue,value:t}}initElement(n,t){if(this.element.defaultParamValues){this.initDefaultParamValues(this.element.defaultParamValues,n,t);return}n.call(t)}initDefaultParamValues(n,t,i){const r=this.getElementEntityParameterValue(n),u=this.getElementEntityParameterName();this._initElementParameter(u,r);t.call(i)}})})
Terrasoft.configuration.Structures.BaseReportParameterInModulePageFilter={innerHierarchyStack:["BaseReportParameterInModulePageFilter"]};define("BaseReportParameterInModulePageFilter",["BaseReportParameterInModulePageFilterResources"],function(){return[{name:"FormingMethod",dataValueType:"FormingMethod"}]})
Terrasoft.configuration.Structures.BasicServiceAuthInfoValuesPage={innerHierarchyStack:["BasicServiceAuthInfoValuesPage"]};define("BasicServiceAuthInfoValuesPageStructure",["BasicServiceAuthInfoValuesPageResources"],function(){return{schemaUId:"7ed57aec-7412-45e6-98e2-4b4b0508c670",schemaCaption:"",parentSchemaName:"",packageName:"ServiceDesigner",schemaName:"BasicServiceAuthInfoValuesPage",parentSchemaUId:"",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("BasicServiceAuthInfoValuesPage",[],function(){return{attributes:{ServiceSchemaUId:{dataValueType:Terrasoft.DataValueType.GUID},CanEditSchema:{dataValueType:Terrasoft.DataValueType.BOOLEAN}},modules:{AuthInfoUsernameParameter:{moduleId:"AuthInfoUsernameParameterValuePage",moduleName:"ConfigurationModuleV2",config:{isSchemaConfigInitialized:!1,schemaName:"AuthInfoUsernameValuePage",parameters:{viewModelConfig:{ServiceSchemaUid:{attributeValue:"ServiceSchemaUId"},CanEditSchema:{attributeValue:"CanEditSchema"}}},useHistoryState:!1}},AuthInfoPasswordParameter:{moduleId:"AuthInfoPasswordParameterValuePage",moduleName:"ConfigurationModuleV2",config:{isSchemaConfigInitialized:!1,schemaName:"AuthInfoPasswordValuePage",parameters:{viewModelConfig:{ServiceSchemaUid:{attributeValue:"ServiceSchemaUId"},CanEditSchema:{attributeValue:"CanEditSchema"}}},useHistoryState:!1}}},diff:[{operation:"insert",name:"BasicAuthInfoContainer",parentName:"ParameterEdit",propertyName:"items",values:{itemType:Terrasoft.ViewItemType.CONTAINER,items:[]},index:0},{operation:"insert",name:"AuthInfoUsernameParameter",parentName:"BasicAuthInfoContainer",propertyName:"items",values:{itemType:Terrasoft.ViewItemType.MODULE}},{operation:"insert",name:"AuthInfoPasswordParameter",parentName:"BasicAuthInfoContainer",propertyName:"items",values:{itemType:Terrasoft.ViewItemType.MODULE}}]}})
Terrasoft.configuration.Structures.CardControlGeneratorHelper={innerHierarchyStack:["CardControlGeneratorHelper"]};define("CardControlGeneratorHelper",["ext-base","terrasoft","CardControlGeneratorHelperResources"],function(){return{}})
Terrasoft.configuration.Structures.CardProcessViewGenerator={innerHierarchyStack:["CardProcessViewGenerator"]};define("CardProcessViewGenerator",["ext-base","terrasoft","BusinessRuleModule","CardProcessViewGeneratorResources","ActionUtilitiesModule","ConfigurationEnums","GridUtilities"],function(n,t,i,r,u,f,e){function ot(n){return t.utils.common.deepClone(n)}function d(n,i){var r=t.getTypedStringValue(n,i);return r!==""&&r!==null}function g(n,i){return i===t.DataValueType.BOOLEAN&&h(n)}function st(n,i){return i===t.DataValueType.IMAGE&&h(n)}function ht(n){return n.customConfig&&(n.customConfig.className==="Terrasoft.controls.HtmlEdit"||n.customConfig.className==="Terrasoft.controls.HtmlControl")}function h(n){return n===f.CardState.EditStructure||n===f.CardState.Edit||n===f.CardState.Add||n===f.CardState.Copy}function ct(n,t){var i=n!==f.CardState.View;return i&&t.visible===!1||!i&&t.viewVisible===!1}function nt(n){return n===t.DataValueType.ENUM?t.DataValueType.LOOKUP:n}function lt(n,i,r){var u={},e;return n===f.CardState.View?i.type===t.ViewModelSchemaItem.ATTRIBUTE&&(e=d,n==="view"&&i.columnType===t.ViewModelColumnType.VIRTUAL_COLUMN&&(e=function(n){return d(n,nt(i.dataValueType))}),u.visible={bindTo:i.name,bindConfig:{converter:e}}):r&&r.hasOwnProperty("visible")&&(u.visible=r.visible),u}function at(i){switch(i.type){case t.ViewModelSchemaItem.ATTRIBUTE:var r=s.getColumnByName(i.name);if(n.isEmpty(i.caption)){if(!n.isEmpty(r))return r.caption}else return i.caption;break;case t.ViewModelSchemaItem.METHOD:return i.caption}}function tt(i,r,u,f){var e=c(i,r,u,f),b=i.name+"ValueControlLabel",h=i.columnPath,y=t.getTypedStringValue,l,a,o,p,w,v;return f==="view"&&i.columnType===t.ViewModelColumnType.VIRTUAL_COLUMN&&(y=function(n){return t.getTypedStringValue(n,nt(i.dataValueType))}),n.apply(e,{id:b,caption:{bindTo:i.name,bindConfig:{converter:i.valueLabelConverter||y}}}),i.type===t.ViewModelSchemaItem.ATTRIBUTE&&(l=e.classes.labelClass.indexOf("required-caption"),l!==-1&&e.classes.labelClass.splice(l,1)),s&&s.name&&t[s.name]&&(a=t[s.name].columns,a&&h&&(o=a[h],o&&o.isLookup&&o.referenceSchemaName&&(p=o.referenceSchemaName,w=t.configuration.ModuleStructure[p],w&&(v=e.classes.labelClass||[],v.push("label-link"),e.classes.labelClass=v,e.click={bindTo:"onLabelLink"+h+"Click"})))),e}function c(i,r,u,e){var y=r[i.name],p=lt(e,i,y),a,c,h=[],l,v,o;return i.labelClass?h.push(i.labelClass):u==="right"?(h.push("right-label-left-panel"),c=i.rightWidth):u==="left"?(h.push("left-label-left-panel"),c=i.leftWidth):h.push("controlCaption"),l=s.getColumnByName(i.name),(e!==f.CardState.View&&l&&l.isRequired||i.isRequired)&&h.push("required-caption"),a=at(i),v=i.name+"ControlLabel",o={id:v,className:"Terrasoft.Label",caption:a||"",markerValue:i.name,visible:!0,classes:{labelClass:h}},n.apply(o,p),i.captionLabelCustomConfig&&n.apply(o,i.captionLabelCustomConfig),i.labelCustomConfig&&(e===f.CardState.View||i.labelCustomConfigModes&&i.labelCustomConfigModes.indexOf(e)!==-1)&&(t.each(i.labelCustomConfig.classes,function(n){h.push(n)},this),i.labelCustomConfig.visible&&(o.visible=i.labelCustomConfig.visible)),c&&(o.width=c),i.usePlaceholder&&e!==f.CardState.View&&(o.visible=!1,i.placeholderCaption=o.caption),o}function v(i,r,u){var c,o,e,l,h;return!ht(i)&&u===f.CardState.View?tt(i,r,"right",f.CardState.View):(o={classes:{wrapClass:"controlBaseedit"}},i.type===t.ViewModelSchemaItem.METHOD?n.isEmpty(i.customItem)&&(o.readonly=!0):(e=s.getColumnByName(i.name),n.isEmpty(e)?n.isEmpty(i.columnPath)||i.columnPath.indexOf(".")===-1||(n.isEmpty(i.customConfig)&&(i.customConfig={}),i.customConfig.enabled=!1):(e.isRequired===!0&&e.dataValueType!==t.DataValueType.DATE_TIME&&(o.isRequired=!0),e.readonly===!0&&(o.readonly=!0),l=e.precision,n.isEmpty(l)||e.dataValueType!==t.DataValueType.FLOAT&&e.dataValueType!==t.DataValueType.MONEY||(o.decimalPrecision=l)),i.advancedVisible===!0&&u===f.CardState.Add?(o.visible={bindTo:"advancedVisible"},p=!0):w=!1),c=t.getControlConfigByDataValueType(i.dataValueType),n.apply(c,o,{markerValue:i.name}),oi(c,i,r),h=t.utils.common.deepClone(i.customConfig),u===f.CardState.View&&(h.enabled=!1,h.className==="Terrasoft.controls.HtmlEdit"&&i.customItem&&(h={id:h.id,className:"Terrasoft.controls.HtmlControl"})),n.isEmpty(h)||n.apply(c,h),i.usePlaceholder&&u!==f.CardState.View&&i.dataValueType!==t.DataValueType.DATE_TIME&&(c.placeholder=i.placeholder||i.placeholderCaption||""),c)}function it(n){return{className:"Terrasoft.ImageEdit",imageSrc:{bindTo:n.getSrcMethod},defaultImageSrc:n.defaultImage,change:{bindTo:n.onPhotoChange},styles:{wrapStyles:{marginTop:"0px"}},readonly:!0}}function vt(n,t,i,r,u,f){return(y(),s=n,r)?tt(t,i,u,f):c(t,i,u,f)}function yt(n,t,i,r){return y(),s=n,v(t,i,r)}function pt(t,i,r,u,f,e,o){y();s=f;o=n.isEmpty(o)?!0:o;l({container:t,columnsObject:i,bindings:r,action:u,info:e,useInfoButtons:o})}function rt(t,i){var r=o(t.name,[t.wrapContainerClass]);return n.apply(r,{visible:i===f.CardState.View?{bindTo:t.name+"GetVisible"}:i===f.CardState.Add&&t.advancedVisible?{bindTo:"advancedVisible"}:!0,items:[]}),r}function ut(n,t,i,u){if(i&&t)n.collapsedchanged={bindTo:"showAllFields"},u&&(n.collapsed=u);else if(t){var f=e.getLoadButtonConfig();f.classes={wrapperClass:"show-all-btn-user-class"};f.caption=r.localizableStrings.ShowAllButtonCaption;f.visible={bindTo:"advancedVisible",bindConfig:{converter:function(n){return!n}}};f.click={bindTo:"showAllFields"};n.items.push(f)}}function wt(n,t,i){t.id=k.generate();n.inputId=t.id+"-el";var r=o(i+"container",["check-box-container"]);return r.visible=n.visible,n.labelClass="t-label custom-label-container check-box-label-container",t.classes={wrapClass:["custom-control-container"]},r.items.push(t,n),r}function bt(n,t){switch(n){case"imageLoaded":case"plainTextMode":case"images":case"value":case"checked":case"click":return null;case"enabled":return!1;case"visible":return!0;default:return t[n]}}function ft(n){t.each(n,function(n){var t,i;n.className==="Terrasoft.ControlGroup"&&(n.collapsed=!1);n.className==="Terrasoft.controls.HtmlEdit"&&(n.className="Terrasoft.TextEdit",n.margin&&delete n.margin);n.enabled=!1;for(t in n){if(t==="items"){ft(n.items);continue}n[t]&&n[t].hasOwnProperty("bindTo")&&(i=bt(t,n),i===null?delete n[t]:n[t]=i)}})}function kt(t,i){var u=[],s=h(i.action)?c(t,i.bindings,null,i.action):c(t,i.bindings,"left",f.CardState.View),r=v(t,i.bindings,i.action),e,l,a;return(r.visible&&(s.visible=r.visible),g(i.action,t.dataValueType)?r=wt(s,r,t.name):t.captionVisible!==!1&&u.push(s),i.useInfoButtons&&!n.isEmpty(t.info))?(e=pi(t,h(i.action)?!1:["control-info-button-view"]),r.visible&&(e.visible=r.visible),l=["control-info-container"],g(i.action,t.dataValueType)&&(l=["control-info-container-checkbox"]),h(i.action)?(a=o(t.name+"_InfoControlContainer",l),a.items=[r,e],u.push(a),u):(u.push(r),u.push(e),u)):(u.push(r),u)}function dt(i,r,u,e){var v=i.name+"_item_"+t.generateGUID(),s=r.items,h,c,a;return t.each(s,function(t){var r=i.usePlaceholder;t.usePlaceholder=n.isEmpty(r)?!0:r},this),n.isArray(s)&&s.length>0&&(c=["radio-itemgroup-container"],e===f.CardState.View&&c.push("radio-itemgroup-container-view"),h=o(v+"_container",c),i.showControls||(h.visible={bindTo:i.group,bindConfig:{converter:function(n){return r.tag===n}}}),a=t.deepClone(u),n.apply(a,{container:h,columnsObject:s}),l(a)),h}function gt(i,r,u,e){var l=i.name+"_item_"+t.generateGUID(),s,h,c;return i.group=i.group||i.name,s=o(l,["radio-item-container"]),e===f.CardState.View?s.visible=!1:(h=r.visible,s.visible=n.isEmpty(h)?!0:h),c=r.enabled,s.items=[{className:"Terrasoft.RadioButton",tag:r.tag,checked:{bindTo:i.group||i.name},enabled:n.isEmpty(c)?!0:c},{className:"Terrasoft.Label",caption:r.caption}],s}function l(i){var a=i.container,u=i.bindings,r=i.action,o=i.info,y=i.profile,s=!1,e=a.items;t.each(i.columnsObject,function(a){var k,yt,at,g,pt,nt,et,ht,bt,ii,vt,fi;if(a.advancedVisible&&r===f.CardState.Add&&(s=!0),!ct(r,a)){if(k=e,r===f.CardState.EditStructure){var d=null,ft=a.EditStructureContainerId,lt={tag:{itemName:a.name,containerId:ft},afterrender:{bindTo:"containerRendered"},afterrerender:{bindTo:"containerRendered"}};switch(a.type){case t.ViewModelSchemaItem.GROUP:d=b(ft,["ts-controlgroup-wrap","designer-item-container"]);n.apply(d,lt);k=d.items;e.push(d);yt=ni(a,o,k,"fieldGroupContainer-");at=t.deepClone(i);n.apply(at,{container:yt,columnsObject:a.items});l(at);return;case t.ViewModelSchemaItem.DETAIL:d=b(ft,["ts-controlDetail-wrap","designer-item-container"]);n.apply(d,lt);k=d.items;e.push(d);ti(a,o,k,"fieldDetailContainer-");return;default:d=b(ft,["designer-item-container"]);n.apply(d,lt);k=d.items;e.push(d);a.info&&delete a.info}}st(r,a.dataValueType)&&(g=it(a),g.readonly=!0,r===f.CardState.Add&&(g.beforefileselected={bindTo:a.beforefileselected},g.uploadButtonEnabled=!1),g.styles={wrapStyles:{marginTop:"30px"}},k.push(g));switch(a.type){case t.ViewModelSchemaItem.ATTRIBUTE:case t.ViewModelSchemaItem.METHOD:pt=kt(a,i);t.each(pt,function(n){k.push(n)});break;case f.CustomViewModelSchemaItem.RADIO_GROUP:a.id=a.name;nt=rt(a,r);nt.visible=n.isEmpty(a.visible)?!0:a.visible;et=["radio-group-container"];n.isEmpty(a.wrapContainerClass)||et.push(a.wrapContainerClass);r===f.CardState.View&&et.push("radio-group-container-view");nt.classes={wrapClassName:et};t.each(a.items,function(t){var f=gt(a,t,i,r),u=dt(a,t,i,r);nt.items.push(f);n.isEmpty(u)||nt.items.push(u)},this);k.push(nt);break;case f.CustomViewModelSchemaItem.ITEMS_GROUP:var tt=rt(a,r),ei={caption:a.caption||"",className:"Terrasoft.Label",classes:{labelClass:r===f.CardState.View?"left-label-left-panel":"class-caption-"+a.name},id:"caption-"+a.name,selectors:{wrapEl:"#caption-"+a.name}},oi=t.deepClone(a.customConfig||{});n.apply(tt,oi);var ot=u[a.name]?u[a.name].enabled:!0,wt=a.items,si=a.showLabel;si?t.each(wt,function(t){if(t.viewVisible!==!1||r!==f.CardState.View){var i=h(r)?c(t,u,null,r):c(t,u,"left",f.CardState.View);n.apply(t,i);tt.items.push(i)}},this):tt.items.push(ei);t.each(wt,function(t){var e,i;(t.viewVisible!==!1||r!==f.CardState.View)&&(u[t.name]&&u[t.name].enabled&&(ot=u[t.name].enabled),t.customConfig&&t.customConfig.hasOwnProperty("enabled")&&(ot=t.customConfig.enabled),e={customConfig:{classes:{wrapClass:t.wrapClass?t.wrapClass:""},id:t.name,selectors:{wrapEl:"#"+t.name},enabled:n.isEmpty(ot)?!0:ot}},n.apply(t,e),i=v(t,u,r),n.apply(t,i),tt.items.push(i))},this);k.push(tt);break;case t.ViewModelSchemaItem.GROUP:p=!1;s=!1;w=!0;ht=ui(a,r,y);(a.leftWidth||a.rightWidth)&&(bt=a.items,ii={leftWidth:a.leftWidth,rightWidth:a.rightWidth},t.each(bt,function(t){n.apply(t,ii)},this));vt=t.deepClone(i);n.apply(vt,{container:ht,columnsObject:a.items});l(vt);ut(ht,p,!0,w);k.push(ht);break;case t.ViewModelSchemaItem.DETAIL:fi=ri(a,o,y);k.push(fi)}}},this);r===f.CardState.EditStructure&&ft(e);ut(a,s)}function ni(n,t,i,r){var f={caption:n.caption||"",className:"Terrasoft.Label",classes:{labelClass:["ts-controlgroup-wrap"]},id:"group-caption-"+n.name,selectors:{wrapEl:"#group-caption-"+n.name},tag:n.name},u=o(r+n.name,["ts-controlgroup-container","ts-controlgroup-container-shown","control-group-container"]);return i.push(f),i.push(u),u}function ti(n,t,i){var r={caption:n.caption||"",className:"Terrasoft.Label",classes:{labelClass:["ts-controlgroup-wrap"]},id:"group-caption-"+n.name,selectors:{wrapEl:"#group-caption-"+n.name},tag:n.name};i.push(r)}function ii(n,i){t.each(n.groups,function(n){n.id===i.id&&(n.containerId=i.containerId)},this)}function ri(n,t){var i;return n.containerId="datail-"+n.name,ii(t,n),n.inContainer?o(n.containerId):(i=["control-group-container"],n.wrapContainerClass&&i.push(n.wrapContainerClass),{id:n.containerId,caption:n.caption,className:"Terrasoft.ControlGroup",tag:n.name,markerValue:n.caption,classes:{wrapContainerClass:i},collapsedchanged:{bindTo:"onDetailCollapsedChanged"},items:[],visible:n.visible,collapsed:{bindTo:"detail_collapsed_"+n.name}})}function ui(i,r,u){var o=["control-group-container"],e,s;return i.wrapContainerClass&&o.push(i.wrapContainerClass),e={id:i.id,className:"Terrasoft.ControlGroup",caption:i.caption,markerValue:i.caption,visible:r===f.CardState.View?{bindTo:i.name+"GetVisible"}:i.visible?i.visible:!0,classes:{wrapContainerClass:o},collapsedchanged:{bindTo:"onDetailCollapsedChanged"},tag:i.name,items:[]},u&&u[i.name]?e.collapsed=u[i.name].collapsed:typeof i.collapsed=="boolean"&&(e.collapsed=i.collapsed),s=t.deepClone(i.customConfig||{}),n.apply(e,s),e}function fi(i){var r=!1,e=i.type,u,f;switch(e){case t.ViewModelSchemaItem.METHOD:u=i.dataValueType;r=u===t.DataValueType.LOOKUP||u===t.DataValueType.ENUM;break;case t.ViewModelSchemaItem.ATTRIBUTE:f=s.getColumnByName(i.columnPath);n.isEmpty(f)?(i.isLookup||i.isCollection)&&(r=!0):r=f.isLookup;break;default:r=!1}return r}function ei(n,t,i){var e=t.customConfig?t.customConfig.enabled:!0,r=i?i.enabled||!0:e,u=i?i.readonly||!1:!1,s=i?i.isRequired||!1:!1,f=o(t.name,["datetimeeditcontainer-class","controlBaseedit"]);return f.items=[{className:"Terrasoft.DateEdit",classes:{wrapClass:["dimension-class","datetime-datecontrol"]},id:"date-edit-"+t.name,selectors:{wrapEl:"#date-edit-"+t.name},value:{bindTo:t.name},enabled:r,readonly:u,isRequired:s},{className:"Terrasoft.TimeEdit",id:"time-edit-"+t.name,selectors:{wrapEl:"#time-edit-"+t.name},classes:{wrapClass:["dimension-class","datetime-timecontrol"]},value:{bindTo:t.name},enabled:r,readonly:u}],f}function oi(i,r,u){var e=r.name,o=u[e],f,s;if(n.isEmpty(o)||n.apply(i,o),f={},r.dataValueType===t.DataValueType.BOOLEAN){n.apply(i,{checked:{bindTo:e}});return}r.customItem?f=r.customItemConfig:f.value={bindTo:e};fi(r)&&(s=r.list||e+"List",f.list={bindTo:s},r.dataValueType===t.DataValueType.LOOKUP&&(f.loadVocabulary={bindTo:"loadVocabulary"},f.tag=e));r.dataValueType===t.DataValueType.DATE_TIME&&(delete i.isRequired,f=ei(f,r,o));n.apply(i,f)}function o(t,i){var r={className:"Terrasoft.Container",items:[],id:t,selectors:{wrapEl:"#"+t}};return n.isEmpty(i)||(r.classes={wrapClassName:i}),r}function b(n,t){var i=o(n,t);return i.tpl=['<div id="{id}" style="{wrapStyles}" class="{wrapClassName}" tabindex="{tabIndex}">',"{%this.renderItems(out, values)%}","<\/div>"],i}function si(){var n={source:t.ImageSources.IMAGE_LIST_SCHEMA,params:{schemaUId:"d3cf6e63-3322-49e5-8b11-049812be5090",itemUId:"8fe7c97d-0586-4c29-862d-a649e1dd7623"}};return{className:"Terrasoft.Button",visible:!1,style:t.controls.ButtonEnums.style.DEFAULT,imageConfig:n}}function hi(){var n={source:t.ImageSources.IMAGE_LIST_SCHEMA,params:{schemaUId:"d3cf6e63-3322-49e5-8b11-049812be5090",itemUId:"7068bb49-6efa-41d1-8cbe-49e1b0ab2b30"}};return{className:"Terrasoft.Button",visible:!1,style:t.controls.ButtonEnums.style.DEFAULT,imageConfig:n}}function y(){k=new n.data.SequentialIdGenerator({prefix:"card-module-control_",seed:0});et=new n.data.SequentialIdGenerator({prefix:"field-container-",seed:0})}function ci(n){var t=o("header",["header"]),i={className:"Terrasoft.Container",id:"header-name-container",classes:{wrapClassName:["header-name-container"]},selectors:{wrapEl:"#header-name-container"},items:[{className:"Terrasoft.Label",id:"header-name",caption:{bindTo:"getHeader"}}]},u={className:"Terrasoft.Container",id:"card-command-line-container",classes:{wrapClassName:["card-command-line"]},selectors:{wrapEl:"#card-command-line-container"},items:[]},r,f;return t.items=[i,u,{className:"Terrasoft.Container",id:"card-context-help-container",classes:{wrapClassName:["card-context-help"]},selectors:{wrapEl:"#card-context-help-container"},items:[]}],n.entityInfo&&n.entityInfo.pageConfig&&(r=n.entityInfo.pageConfig,r.header===!1&&(t.visible=!1),r.name===!1&&(i.visible=!1),r.commandLine===!1&&(u.visible=!1,i.classes.wrapClassName.push("wide-header-name-container"))),n.headConfig&&n.headConfig.useCommandLine===!1&&(u.visible=!1,i.classes.wrapClassName.push("wide-header-name-container")),f=n.entityInfo,f&&f.hideHeader&&(t.visible=!1),t}function li(n){return h(n)?{className:"Terrasoft.Button",caption:r.localizableStrings.SaveButtonCaption,style:t.controls.ButtonEnums.style.GREEN,click:{bindTo:"save"},visible:{bindTo:"isVisibleEditButton"}}:{className:"Terrasoft.Button",caption:r.localizableStrings.ChangeButtonCaption,style:t.controls.ButtonEnums.style.DEFAULT,click:{bindTo:f.CardState.Edit},visible:{bindTo:"isVisibleEditButton"}}}function ai(i,u,e){var o=[],h=[],s,c;t.each(i.groups,function(n){o.push(n.caption);h[n.caption]=n},this);o.length>0&&(o.sort(),s=[],t.each(o,function(n){var t=h[n],i;t&&(i=t.visible?t.visible:!0,u!==f.CardState.View||t.isDetail||(i={bindTo:t.name+"GetVisible"}),s.push({caption:t.caption,tag:t.id,visible:i,click:{bindTo:"moveToAction"}}))},this),c={caption:r.localizableStrings.GotoButtonCaption,menu:{items:s}},e.push(n.apply({},c,{className:"Terrasoft.Button"})))}function vi(i,f,e,s,h){var a=o("utils"),c=[],d,g,nt,v,y,p,tt,b,k;e.isReadOnly||(d=li(i),c.push(n.apply({},d)));g={className:"Terrasoft.Button",caption:r.localizableStrings.DoLaterButtonCaption,style:t.controls.ButtonEnums.style.DEFAULT,visible:{bindTo:"delayExecutionButtonVisible"},click:{bindTo:"delayExecution"}};c.push(n.apply({},g));nt=n.apply({},{className:"Terrasoft.Button",style:t.controls.ButtonEnums.style.DEFAULT,caption:r.localizableStrings.CancelButtonCaption,click:{bindTo:"cancel"}},{className:"Terrasoft.Button"});c.push(nt);v={className:"Terrasoft.Button",caption:r.localizableStrings.ActionButtonCaption,menu:{items:[]}};c.push(n.apply({},v));ai(f,i,c);u.addActionsButton(c,e.actions);s=u.getReports(s);u.addActionsButton(c,s);y=[{caption:"",className:"Terrasoft.MenuSeparator",visible:{bindTo:"getSchemaAdministratedByRecords"}},{caption:r.localizableStrings.RightsButtonCaption,click:{bindTo:"editRights"},visible:{bindTo:"getSchemaAdministratedByRecords"}}];t.SysSettings.cachedSettings.BuildType!=="e45eb864-59cc-4325-8276-d85e1ba90c95"&&(y.push({caption:"",visible:{bindTo:"canDesignPage"},className:"Terrasoft.MenuSeparator"}),y.push({caption:r.localizableStrings.EditPageCaption,visible:{bindTo:"canDesignPage"},click:{bindTo:"openPageDesigner"}}));u.addActionsButton(c,y);p=[];v.menu.items.forEach(function(n){n.visible&&n.visible.bindTo&&p.push(n.visible.bindTo)});p.length===v.menu.items.length&&(v.visible={bindTo:"getActionsButtonVisible"},h.visibilityBindings=p);c.push({className:"Terrasoft.Button",visible:!1,style:t.controls.ButtonEnums.style.DEFAULT,caption:r.localizableStrings.GotoButtonCaption,menu:{items:[]}});var l=e.schema.utilsConfig,it=l&&l.leftUtilsClass?l.leftUtilsClass:"utils-left",w=o(it);return w.items=e.schema.customLeftUtils&&l.useLeftUtils?e.schema.customLeftUtils:c,e.methods.modifyLeftUtilsConfig&&(w=e.methods.modifyLeftUtilsConfig(w)),tt=l&&l.rightUtilsClass?l.rightUtilsClass:"utils-right",b=o(tt),b.items=e.schema.customRightUtils&&l&&l.useRightUtils?e.schema.customRightUtils:[{className:"Terrasoft.Button",style:t.controls.ButtonEnums.style.DEFAULT,visible:!1,caption:r.localizableStrings.ViewButtonCaption,menu:{items:[{caption:"SingleMenuItem"}]}},si(),hi()],a.items.push(w),a.items.push(b),e.entityInfo&&e.entityInfo.pageConfig&&e.entityInfo.pageConfig.topUtils===!1&&(a.visible=!1),k=e.entityInfo,k&&k.hideUtils&&(a.visible=!1),a}function yi(n,t,i){var r=o("bottomUtils");return i.schema.bottomUtilsConfig&&(r.items=i.schema.bottomUtilsConfig),r}function pi(n,i){var u=n.info||{},f;return i=i||["control-info-button"],f={className:"Terrasoft.Button",imageConfig:u.InfoImage||r.localizableImages.InfoImage,style:t.controls.ButtonEnums.style.TRANSPARENT,tabIndex:-1,tag:n.name,classes:{wrapperClass:i},click:{bindTo:n.name+"ShowInfo"}},u.visible&&(f.visible=u.visible),u.click&&(f.click=u.click),f}function a(i,r,u,f){var s=t.deepClone(u),e,h;r&&(e=f,f.hasOwnProperty("className")||(e=o(f.id,f.wrapClass),f.hasOwnProperty("items")&&(e.items=f.items)),h={container:e,columnsObject:r},n.apply(s,h),l(s),i.items.push(e))}var p=!1,w=!1,s,k,et;return{generateView:pt,generateLabelConfig:vt,generateControlConfig:yt,generate:function(r,u,e,h,c){var l,k,b,d,g,w,nt;y();l=ot(r);s=l.entitySchema;var p=o("autoGeneratedContainer"),tt=ci(l),rt=vi(u,e,l,c,r);return p.items=[tt,o("process-reminder"),rt,o("delay-execution"),o("usertask-recommendation")],u===f.CardState.View&&l.getItemViewHeader&&(k=l.getItemViewHeader(),b=o("item-information-container"),b.items=[o("item-image"),o("item-info")],d=k.columns,t.each(d,function(n){n.dataValueType===t.DataValueType.IMAGE?b.items[0].items.push(it(n)):b.items[1].items.push(v(n,l.bindings,u))}),p.items.push(b)),i.prepareViewRule(l,e.rules),g=n.isEmpty(l.useInfoButtons)?!0:l.useInfoButtons,w={bindings:l.bindings,action:u,info:e,profile:h,useInfoButtons:g},a(p,l.schema.customPanel,w,{id:"autoGeneratedCustomContainer",wrapClass:l.schema.customPanelWrapClass}),a(p,l.schema.leftPanel,w,{id:"autoGeneratedLeftContainer",wrapClass:l.schema.leftPanelWrapClass}),a(p,l.schema.rightPanel,w,{id:"autoGeneratedRightContainer",wrapClass:l.schema.rightPanelWrapClass,items:[o("processExecutionContextContainer")]}),nt=yi(u,e,l,c,r),a(p,l.schema.bottomUtilsConfig,w,nt),a(p,l.schema.customBottomPanel,w,{id:"autoGeneratedCustomBottomContainer",wrapClass:l.schema.customBottomPanelWrapClass}),p}}})
Terrasoft.configuration.Structures.ChangeAdminRightsUserTaskItemInitializer={innerHierarchyStack:["ChangeAdminRightsUserTaskItemInitializer"]};define("ChangeAdminRightsUserTaskItemInitializer",["BaseProcessFlowElementSchemaItemInitializer"],function(){Terrasoft.ChangeAdminRightsUserTaskItemInitializer=(class extends Terrasoft.BaseProcessFlowElementSchemaItemInitializer{getElementEntityParameterName(){return"EntitySchemaUId"}})})
Terrasoft.configuration.Structures.ChangeDataUserTaskItemInitializer={innerHierarchyStack:["ChangeDataUserTaskItemInitializer"]};define("ChangeDataUserTaskItemInitializer",["BaseProcessFlowElementSchemaItemInitializer"],function(){Terrasoft.ChangeDataUserTaskItemInitializer=(class extends Terrasoft.BaseProcessFlowElementSchemaItemInitializer{getElementEntityParameterName(){return"EntitySchemaUId"}})})
Terrasoft.configuration.Structures.CheckBoxDateBlockGeneratorV2={innerHierarchyStack:["CheckBoxDateBlockGeneratorV2"]};define("CheckBoxDateBlockGeneratorV2",["css!CheckBoxDateBlockGeneratorV2"],function(){function n(n){var t=n.name+"CheckBoxDateBlock",i=n.name+"DateTimeContainer",r=n.name+"CheckBox";return{className:"Terrasoft.Container",id:t,classes:{wrapClassName:["dateTimeContainerBlock","control-width-15"]},selectors:{wrapEl:"#"+t},items:[{className:"Terrasoft.Label",classes:{labelClass:["labelElement"]},caption:n.checkBoxCaption,inputId:r+"-el"},{className:"Terrasoft.CheckBoxEdit",id:r,classes:{wrapClassName:["checkBoxContainer"]},checked:n.enabledValue,focus:{bindTo:n.checkBoxFocus},markerValue:n.name},{className:"Terrasoft.Container",id:i,selectors:{wrapEl:"#"+i},classes:{wrapClassName:["dateTimeContainer"]},visible:n.enabledValue,items:[{className:"Terrasoft.DateEdit",id:n.name+"DateEdit",value:n.dateTimeValue,focus:{bindTo:n.dateFocus},markerValue:n.name,classes:{wrapClass:["datetime-datecontrol"]}},{className:"Terrasoft.TimeEdit",id:n.name+"TimeEdit",value:n.dateTimeValue,focus:{bindTo:n.timeFocus},markerValue:n.name,classes:{wrapClass:["datetime-timecontrol"]}}]}]}}return{generateCheckBoxDateBlock:n}})
Terrasoft.configuration.Structures.CityPage={innerHierarchyStack:["CityPage"]};define("CityPageStructure",function(){return{type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("CityPage",["ext-base","terrasoft","sandbox","City","CityPageStructure","CityPageResources","GeneralDetails","LookupUtilities","BusinessRuleModule"],function(n,t,i,r,u,f,e,o,s){return u.userCode=function(){this.entitySchema=r;this.name="CityCardViewModel";this.schema.leftPanel=o.GetBaseLookupPageStructure()},u.finalizeStructure=function(){var i=this.find("baseElementsControlGroup"),n;i&&(n=i.items,n.splice(2,0,{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Country",columnPath:"Country",dataValueType:t.DataValueType.LOOKUP,visible:!0}),n.splice(3,0,{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Region",columnPath:"Region",dataValueType:t.DataValueType.LOOKUP,visible:!0,rules:[{ruleType:s.enums.RuleType.FILTRATION,autocomplete:!0,baseAttributePatch:"Country",comparisonType:t.ComparisonType.EQUAL,type:s.enums.ValueType.ATTRIBUTE,attribute:"Country",attributePath:"",value:""}]}),n.splice(4,0,{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"TimeZone",columnPath:"TimeZone",dataValueType:t.DataValueType.LOOKUP,visible:!0}),i.items=n)},u})
Terrasoft.configuration.Structures.ckeditor={innerHierarchyStack:["ckeditor"]};define("ckeditor",["ckeditor-base"],function(){var n=Ext.String.format(Terrasoft.Resources.ObsoleteMessages.ObsoleteModule,"ckeditor","ckeditor-base");window.console.log(n)})
Terrasoft.configuration.Structures.ClientUnitSchemaModelItemDesigner={innerHierarchyStack:["ClientUnitSchemaModelItemDesigner"],structureParent:"SchemaModelItemDesigner"};define("ClientUnitSchemaModelItemDesignerStructure",["ClientUnitSchemaModelItemDesignerResources"],function(){return{schemaUId:"5d19a0e4-ca3b-4e22-9e32-661e1fb1070f",schemaCaption:"ClientUnitSchemaModelItemDesigner",parentSchemaName:"SchemaModelItemDesigner",packageName:"CrtDesignerTools",schemaName:"ClientUnitSchemaModelItemDesigner",parentSchemaUId:"52f23ebc-4ed7-496a-847e-3b33ecb3fb4a",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ClientUnitSchemaModelItemDesigner",[],function(){return{diff:[{operation:"remove",name:"IsValueCloneable"},{operation:"remove",name:"LabelCaption"},{operation:"remove",name:"IsCascade"}]}})
Terrasoft.configuration.Structures.ColumnPage={innerHierarchyStack:["ColumnPage"]};define("ColumnPage",["ext-base","terrasoft","sandbox","ColumnPageView","ColumnPageViewModel"],function(n,t,i,r,u){function h(h){var c,l;if(f){c=t.deepClone(o);e=n.create("Terrasoft.Container",c);e.bind(f);e.render(h);return}s=i.publish("GetColumnInfo",null,[i.id])||{};l=u.generate(i,s);f=n.create("Terrasoft.BaseViewModel",l);t.SysSettings.querySysSettingsItem("SchemaNamePrefix",function(){f.init(function(){o=r.generate(s,f);var i=t.deepClone(o);e=n.create("Terrasoft.Container",i);f.renderTo=h;e.bind(f);e.render(h)})},this)}var o,f,s,e;return{init:function(){var r=i.publish("GetHistoryState"),f=r.hash,u=r.state||{},n;u.moduleId!==i.id&&(n=t.deepClone(u),n.moduleId=i.id,i.publish("ReplaceHistoryState",{stateObj:n,pageTitle:null,hash:f.historyState,silent:!0}))},render:h}})
Terrasoft.configuration.Structures.ColumnPageView={innerHierarchyStack:["ColumnPageView"]};define("ColumnPageView",["ext-base","terrasoft","ColumnPageViewResources","CardViewGenerator","ColumnHelper"],function(n,t,i,r,u){function s(n,t){return{className:"Terrasoft.Container",id:n+"CheckBoxContainer",selectors:{wrapEl:"#"+n+"CheckBoxContainer"},classes:{wrapClassName:["custom-inline"]},items:t}}function f(t,i){var r={className:"Terrasoft.Container",id:t+"Container",selectors:{wrapEl:"#"+t+"Container"},items:[]};return n.isArray(i)&&(r.classes={wrapClassName:i}),r}function o(n){return[{className:"Terrasoft.RadioButton",tag:n,enabled:{bindTo:"isEnabled"},checked:{bindTo:"lookupToken"}},{className:"Terrasoft.Label",caption:i.localizableStrings["Lookup"+n+"Caption"]}]}function e(n,r,u){var f=r||n;return{type:t.ViewModelSchemaItem.ATTRIBUTE,name:n,columnPath:n,caption:i.localizableStrings[f+"Caption"],dataValueType:u}}function h(){var v=e("LookupName","Name",t.DataValueType.TEXT),y=e("LookupCaption","LookupCaption",t.DataValueType.TEXT),p=e("Lookup","Lookup",t.DataValueType.LOOKUP),w=r.generateControlConfig(this,p,{}),s,h,c,l,u,a,i;return n.apply(w,{enabled:{bindTo:"isExistLookupEnabled"}}),s=r.generateControlConfig(this,v,{}),n.apply(s,{enabled:{bindTo:"isNewLookupEnabled"}}),h=r.generateControlConfig(this,y,{}),n.apply(h,{enabled:{bindTo:"isNewLookupEnabled"}}),c=f.call(this,"lookup",["lookupContainer"]),l=f.call(this,"lookupExist",["custom-inline"]),l.items=o.call(this,"Exist"),u=f.call(this,"lookupExistControl",["lookupTypeContainer"]),u.items.push(r.generateLabelConfig(this,p,{})),u.items.push(w),a=f.call(this,"lookupNew",["custom-inline"]),a.items=o.call(this,"New"),i=f.call(this,"lookupNewControl",["lookupTypeContainer"]),i.items.push(r.generateLabelConfig(this,y,{})),i.items.push(h),i.items.push(r.generateLabelConfig(this,v,{})),i.items.push(s),c.items.push(l,u,a,i),c}function c(u){var f=[],o=["Title","IsRequired","IsMultiline","IsEnum"],c=["StringType","FloatType","DateType"];return t.each(u,function(u){var p=this.columns[u],l=e(u,u,p.dataValueType),y,a,v;c.indexOf(u)>=0&&(this.columns[u].isRequired=!0,l.columnType=t.ViewModelColumnType.VIRTUAL_COLUMN,l.customConfig={list:{bindTo:"EnumList"},prepareList:{bindTo:"loadEnumItems"}});y=r.generateLabelConfig(this,l,{});a=r.generateControlConfig(this,l,{});o.indexOf(u)<0&&(a.enabled={bindTo:"isEnabled"});u==="Lookup"?f.push(h.call(this)):p.dataValueType===t.DataValueType.BOOLEAN?f.push(s.call(this,u,[y,a])):f.push(y,a);u==="Name"&&(v=t.SysSettings.cachedSettings.SchemaNamePrefix,!n.isEmpty(v)&&v.length>0&&f.push({className:"Terrasoft.Label",id:"prefixLabel",caption:n.String.format(i.localizableStrings.PrefixMask,v)}))},this),f}function l(n,r){var f=["Title","Name"],e,o;switch(n.type.enumName){case u.Type.STRING.enumName:f.push("StringType","IsMultiline");break;case u.Type.FLOAT.enumName:n.type.baseDataType!=="Integer"&&f.push("FloatType");break;case u.Type.DATE.enumName:f.push("DateType");break;case u.Type.LOOKUP.enumName:f.push("Lookup","IsEnum")}return n.type.enumName!==u.Type.BOOLEAN.enumName&&f.push("IsRequired"),e=c.call(r,f),o={id:"mergeDuplicatesContainer",selectors:{wrapEl:"#mergeDuplicatesContainer"},items:[{className:"Terrasoft.Container",id:"captionContainer",selectors:{wrapEl:"#captionContainer"},classes:{wrapClassName:["captionContainer"]},items:[{className:"Terrasoft.Label",id:"captionLabel",caption:{bindTo:"getHeader"}}]},{className:"Terrasoft.Container",id:"buttonsContainer",selectors:{wrapEl:"#buttonsContainer"},items:[{className:"Terrasoft.Button",id:"acceptButton",caption:i.localizableStrings.AcceptButtonCaption,style:t.controls.ButtonEnums.style.GREEN,tag:"AcceptButton",click:{bindTo:"onAcceptClick"}},{className:"Terrasoft.Button",id:"cancelButton",caption:i.localizableStrings.CancelButtonCaption,tag:"CancelButton",click:{bindTo:"onCancelClick"}},{className:"Terrasoft.Container",id:"controlsContainer",selectors:{wrapEl:"#controlsContainer"},items:e}]}]},o}return{generate:l}})
Terrasoft.configuration.Structures.CommonFilterUtils={innerHierarchyStack:["CommonFilterUtils"]};define("CommonFilterUtils",["CommonFilterUtilsResources"],function(n){return{resources:n}})
Terrasoft.configuration.Structures.ConfActivityLogDiffBuilder={innerHierarchyStack:["ConfActivityLogDiffBuilder"]};define("ConfActivityLogDiffBuilder",["ConfActivityLogDiffMapper","ConfActivityLogDiffTemplate","ConfActivityLogDiffRuntime"],function(n,t,i){function r(n){return JSON.stringify(n||{}).replace(/</g,"\\u003c").replace(/>/g,"\\u003e").replace(/&/g,"\\u0026").replace(/\u2028/g,"\\u2028").replace(/\u2029/g,"\\u2029").replace(/<\/script/gi,"<\\/script")}function f(n){return String(n||"").replace(/<\/script/gi,"<\\/script")}function e(n){const u=r(i.getTexts());return t.buildDiffHtml(r(n),f(i.getScript(u)))}function u(n){return t.buildErrorHtml(n)}function o(t,i){return n.isSuccessful(t)?e(n.buildDiffModel(t,i)):u(n.getErrorMessage(t))}return{buildHtml:o,buildErrorHtml:u}})
Terrasoft.configuration.Structures.ConfActivityLogDiffMapper={innerHierarchyStack:["ConfActivityLogDiffMapper"]};define("ConfActivityLogDiffMapper",["ConfActivityLogDiffMapperResources"],function(n){function i(n){return n===null||n===undefined?"":String(n)}function f(n){return i(n).trim().toLowerCase()}function t(n,t,i){if(!n)return i;for(let i=0;i<t.length;i++){const r=t[i];if(n[r]!==undefined)return n[r]}return i}function l(n,i){const r=t(n,i,[]);return Array.isArray(r)?r:[]}function kt(n){return i(n).replace(/\\/g,"/").replace(/\/+/g,"/").toLowerCase()}function a(n){return l(n,ut)}function v(n,i){return t(n,h,t(i,h,""))}function y(n,t){return f(v(n,t))===wt}function dt(n,t){return f(v(n,t))===bt}function e(n){return i(t(n,ft,""))}function gt(n){return l(n,st)}function p(n){return!n||s(e(n))?null:{modifiedOn:i(t(n,et,"")),modifiedBy:i(t(n,ot,""))}}function w(n){const t=i(n),r=t.split(/[\\/]/);return r[r.length-1]||t}function ni(n){return f(w(n))}function ti(n){const t=kt(n);return t?t:f(w(n))}function ii(n){return{path:i(t(n,ht,"")),contentType:i(t(n,lt,"")),content:i(t(n,ct,""))}}function o(n){return gt(n).reduce(function(n,t){const r=ii(t),i=ti(r.path);return!i||Object.prototype.hasOwnProperty.call(n,i)?n:(n[i]=r,n)},Object.create(null))}function ri(n,t){const i=f(t);return i?n.find(function(n){return f(e(n))===i})||null:null}function ui(n,t){return n.find(function(n){return n!==t})||null}function b(n,t){const i=ri(n,t);return i?{previous:ui(n,i),current:i}:{previous:n[0]||null,current:n[1]||null}}function k(n,t){Object.keys(t).forEach(function(t){n[t]=!0})}function d(n,t){const i=Object.create(null);return k(i,n),k(i,t),Object.keys(i)}function g(n,t,i){return{key:n,displayPath:i&&i.path||t&&t.path||n,oldContent:t?t.content:"",newContent:i?i.content:"",oldContentType:t?t.contentType:"",newContentType:i?i.contentType:"",hasOld:!!t,hasNew:!!i}}function nt(n){return!n.hasOld||!n.hasNew||n.oldContent!==n.newContent}function tt(n,t){return(n.displayPath||n.key).localeCompare(t.displayPath||t.key)}function s(n){return f(n)===pt}function fi(n){return{key:n.key,title:n.title,files:[]}}function ei(){return u.reduce(function(n,t){return n[t.key]=fi(t),n},Object.create(null))}function oi(n){const t=ni(n.displayPath||n.key);for(let n=0;n<u.length;n++)if(u[n].matches(t))return u[n].key;return""}function si(n){const t=ei();return n.forEach(function(n){const i=oi(n);i&&t[i].files.push(n)}),t}function hi(n){return u.map(function(t){const i=n[t.key];return{key:t.key,title:t.title,count:i?i.files.length:0}})}function ci(n){for(let i=0;i<u.length;i++){const t=n[u[i].key];if(t&&t.files.length)return t.key}return""}function it(n,t,i,r,u){const f=si(n);return u=u||{},{hasPreviousVersion:t,showCurrentContentOnly:!!u.showCurrentContentOnly,versionInfo:i||{previous:null,current:null},availableModes:hi(f),defaultMode:ci(f),filesByMode:f,emptyState:r||null}}function rt(n,t,i){return{previous:i?p(n):null,current:p(t)}}function li(n,t){const i=b(a(n),t&&t.currentLogEntryId);if(!i.current)return[];const f=!y(n,i.current)&&!!i.previous&&!s(e(i.previous)),r=f?o(i.previous):Object.create(null),u=o(i.current);return d(r,u).map(function(n){return g(n,r[n],u[n])}).filter(function(n){return nt(n)}).sort(function(n,t){return tt(n,t)})}function ai(n,t){const i=b(a(n),t&&t.currentLogEntryId);if(!i.current)return it([],!0,rt(null,null,!1),{title:r.noFilesTitle,message:r.noFilesMessage});const u=!y(n,i.current)&&!!i.previous&&!s(e(i.previous)),l=dt(n,i.current)&&!u,v=rt(i.previous,i.current,u),h=u?o(i.previous):Object.create(null),c=o(i.current),p=d(h,c).map(function(n){return g(n,h[n],c[n])}).filter(function(n){return nt(n)}).sort(function(n,t){return tt(n,t)}),f=it(p,u,v,null,{showCurrentContentOnly:l});return f.defaultMode||(f.emptyState={title:r.noSupportedContentTitle,message:r.noSupportedContentMessage}),f}function vi(n){const u=t(n,at,null);return i(t(u,vt,r.defaultErrorMessage))||r.defaultErrorMessage}function yi(n){if(!n)return!1;const i=t(n,yt,undefined);return typeof i=="boolean"?i:!0}const r={defaultErrorMessage:n.localizableStrings.DefaultErrorMessage,sourceCode:n.localizableStrings.SourceCode,metadata:n.localizableStrings.Metadata,descriptor:n.localizableStrings.Descriptor,noFilesTitle:n.localizableStrings.NoFilesTitle,noFilesMessage:n.localizableStrings.NoFilesMessage,noSupportedContentTitle:n.localizableStrings.NoSupportedContentTitle,noSupportedContentMessage:n.localizableStrings.NoSupportedContentMessage},ut=["values","Values"],h=["operation","Operation"],ft=["logEntryId","LogEntryId"],et=["modifiedOn","ModifiedOn"],ot=["modifiedBy","ModifiedBy"],st=["files","Files"],ht=["path","Path"],ct=["content","Content"],lt=["contentType","ContentType"],at=["errorInfo","ErrorInfo"],vt=["message","Message"],yt=["success","Success"],pt="00000000-0000-0000-0000-000000000000",wt="create",bt="update",c=["descriptor.json","app-descriptor.json"],u=[{key:"sourceCode",title:r.sourceCode,matches:function(n){return/\.(cs|js|less|sql|css|html)$/.test(n)}},{key:"metadata",title:r.metadata,matches:function(n){return/\.json$/.test(n)&&c.indexOf(n)===-1}},{key:"descriptor",title:r.descriptor,matches:function(n){return c.indexOf(n)!==-1}}];return{buildDiffModel:ai,buildComparableFiles:li,getErrorMessage:vi,isSuccessful:yi}})
Terrasoft.configuration.Structures.ConfActivityLogDiffRuntime={innerHierarchyStack:["ConfActivityLogDiffRuntime"]};define("ConfActivityLogDiffRuntime",["ConfActivityLogDiffRuntimeResources"],function(n){function t(n){return n===null||n===undefined?"":String(n)}function r(){const i=n.localizableStrings||{};return{noFilesTitle:t(i.NoFilesTitle),noFilesMeta:t(i.NoFilesMeta),noOldContent:t(i.NoOldContent),noNewContent:t(i.NoNewContent),noChangedContent:t(i.NoChangedContent),modeContentUnavailable:t(i.ModeContentUnavailable),largeContentTitle:t(i.LargeContentTitle),largeContentMeta:t(i.LargeContentMeta),largeContentPane:t(i.LargeContentPane),added:t(i.Added),removed:t(i.Removed),modified:t(i.Modified),sourceCode:t(i.SourceCode),metadata:t(i.Metadata),descriptor:t(i.Descriptor),hiddenUnchangedLinesPrefix:"... ",hiddenUnchangedLinesSuffix:t(i.HiddenUnchangedLinesSuffix),modeNoFilesPrefix:t(i.ModeNoFilesPrefix),modeNoFilesSuffix:t(i.ModeNoFilesSuffix),metaSeparator:" | ",oldLinesLabel:t(i.OldLinesLabel),newLinesLabel:t(i.NewLinesLabel),previousVersion:t(i.PreviousVersion),currentVersion:t(i.CurrentVersion),noPreviousVersion:t(i.NoPreviousVersion),noPreviousVersionDeletedDuringCleanup:t(i.NoPreviousVersionDeletedDuringCleanup),enterFullscreen:t(i.EnterFullscreen),exitFullscreen:t(i.ExitFullscreen)}}function f(n){return u.replace(i,n)}const i="__RUNTIME_TEXTS_JSON__";const u=`(function() {
		var Texts = ${i};
		var ModeOrder = [
			{ key: 'sourceCode', title: Texts.sourceCode },
			{ key: 'metadata', title: Texts.metadata },
			{ key: 'descriptor', title: Texts.descriptor }
		];
		var RowTypes = {
			same: 'same',
			added: 'added',
			removed: 'removed',
			changed: 'changed',
			empty: 'emptyline'
		};
		var ViewModes = {
			side: 'side',
			unified: 'unified'
		};
		var ContextLinesCount = 3;
		var MaxDiffLinesPerSide = 5000;
		var MaxDiffCharsPerSide = 500000;
		var MaxDiffResyncLookahead = 100;
		var MaxInlineDiffLineChars = 2000;
		var MaxInlineDiffTokens = 300;
		var ScrollEndTolerance = 2;
		var FullscreenFrameClassName = 'conf-activity-log-diff-fullscreen-frame';
		var FullscreenBodyClassName = 'conf-activity-log-diff-fullscreen-body';
		var dom = {
			root: document.querySelector('.gidiff'),
			compareMenu: document.querySelector('[data-compare-menu]'),
			compareMenuToggle: document.querySelector('[data-compare-menu-toggle]'),
			compareModes: document.querySelector('[data-compare-modes]'),
			tabs: document.querySelector('[data-tabs]'),
			title: document.querySelector('[data-title]'),
			meta: document.querySelector('[data-meta]'),
			leftVersionTitle: document.querySelector('[data-left-version-title]'),
			leftVersionMeta: document.querySelector('[data-left-version-meta]'),
			rightVersionTitle: document.querySelector('[data-right-version-title]'),
			rightVersionMeta: document.querySelector('[data-right-version-meta]'),
			unifiedLeftVersionTitle: document.querySelector('[data-unified-left-version-title]'),
			unifiedLeftVersionMeta: document.querySelector('[data-unified-left-version-meta]'),
			unifiedRightVersionTitle: document.querySelector('[data-unified-right-version-title]'),
			unifiedRightVersionMeta: document.querySelector('[data-unified-right-version-meta]'),
			left: document.querySelector('[data-left]'),
			right: document.querySelector('[data-right]'),
			unified: document.querySelector('[data-unified]'),
			compactToggle: document.querySelector('[data-compact-toggle]'),
			viewMode: document.querySelector('.view-mode'),
			modeButtons: Array.prototype.slice.call(document.querySelectorAll('[data-view-mode]')),
			changeNavButtons: Array.prototype.slice.call(document.querySelectorAll('[data-change-nav]')),
			fullscreenToggle: document.querySelector('[data-fullscreen-toggle]'),
			fullscreenEnterIcon: document.querySelector('[data-fullscreen-enter-icon]'),
			fullscreenExitIcon: document.querySelector('[data-fullscreen-exit-icon]')
		};
		dom.leftPane = dom.left && dom.left.closest('.pane');
		dom.compactToggleLabel = dom.compactToggle && dom.compactToggle.closest('.toggle');
		dom.rightVersionHead = dom.rightVersionTitle && dom.rightVersionTitle.closest('.version-head');
		var state = {
			activeKey: '',
			selectedMode: '',
			viewMode: ViewModes.side,
			compact: !!(dom.compactToggle && dom.compactToggle.checked),
			changeCount: 0,
			changeNavigationFrame: 0,
			syncLock: false
		};
		var model = normalizeDiffModel(diffModel);

		function setCompareMenuOpen(isOpen) {
			if (!dom.compareMenu || !dom.compareMenuToggle) {
				return;
			}
			dom.compareMenu.classList.toggle('is-open', isOpen);
			dom.compareMenuToggle.classList.toggle('active', isOpen);
			dom.compareMenuToggle.setAttribute('aria-expanded', isOpen ? 'true' : 'false');
		}

		function closeCompareMenu() {
			setCompareMenuOpen(false);
		}

		function getFullscreenTarget() {
			var frameElement = null;
			try {
				frameElement = window.frameElement;
			} catch (error) {
				frameElement = null;
			}
			return frameElement || document.documentElement;
		}

		function isFullscreenActive() {
			var target = getFullscreenTarget();
			return target.classList.contains(FullscreenFrameClassName) || dom.root.classList.contains('is-fullscreen');
		}

		function updateFullscreenButton() {
			if (!dom.fullscreenToggle) {
				return;
			}
			var isActive = isFullscreenActive();
			var caption = isActive ? Texts.exitFullscreen : Texts.enterFullscreen;
			dom.fullscreenToggle.classList.toggle('active', isActive);
			dom.fullscreenToggle.setAttribute('aria-label', caption);
			dom.fullscreenToggle.setAttribute('title', caption);
			if (dom.fullscreenEnterIcon) {
				dom.fullscreenEnterIcon.classList.toggle('is-hidden', isActive);
			}
			if (dom.fullscreenExitIcon) {
				dom.fullscreenExitIcon.classList.toggle('is-hidden', !isActive);
			}
		}

		function getFullscreenStyleElement(doc) {
			var styleElement = doc.getElementById('conf-activity-log-diff-fullscreen-style');
			if (styleElement) {
				return styleElement;
			}
			styleElement = doc.createElement('style');
			styleElement.id = 'conf-activity-log-diff-fullscreen-style';
			styleElement.textContent = '.' + FullscreenBodyClassName + ' { overflow: hidden !important; }' +
				'.' + FullscreenFrameClassName + ' { position: fixed !important; inset: 0 !important; ' +
				'z-index: 2147483647 !important; width: 100vw !important; height: 100vh !important; ' +
				'max-width: none !important; max-height: none !important; margin: 0 !important; ' +
				'border: 0 !important; border-radius: 0 !important; background: #fff !important; }';
			doc.head.appendChild(styleElement);
			return styleElement;
		}

		function setFullscreenActive(isActive) {
			var target = getFullscreenTarget();
			var parentDocument = target.ownerDocument || document;
			getFullscreenStyleElement(parentDocument);
			target.classList.toggle(FullscreenFrameClassName, isActive);
			dom.root.classList.toggle('is-fullscreen', isActive);
			if (parentDocument.body) {
				parentDocument.body.classList.toggle(FullscreenBodyClassName, isActive);
			}
			updateFullscreenButton();
		}

		function toggleFullscreen() {
			setFullscreenActive(!isFullscreenActive());
		}

		function normalizeDiffModel(value) {
			var defaultModes = ModeOrder.map(function(mode) {
				return {
					key: mode.key,
					title: mode.title,
					count: 0
				};
			});
			if (Array.isArray(value)) {
				return {
					hasPreviousVersion: true,
					showCurrentContentOnly: false,
					versionInfo: {
						previous: null,
						current: null
					},
					availableModes: defaultModes,
					defaultMode: '',
					filesByMode: {},
					emptyState: null
				};
			}
			value = value || {};
			return {
				hasPreviousVersion: value.hasPreviousVersion !== false,
				showCurrentContentOnly: !!value.showCurrentContentOnly,
				versionInfo: value.versionInfo || {
					previous: null,
					current: null
				},
				availableModes: Array.isArray(value.availableModes) ? value.availableModes : defaultModes,
				defaultMode: value.defaultMode || '',
				filesByMode: value.filesByMode || {},
				emptyState: value.emptyState || null
			};
		}

		function getModeTitle(modeKey) {
			var modes = model.availableModes || [];
			for (var index = 0; index < modes.length; index++) {
				if (modes[index].key === modeKey) {
					return modes[index].title;
				}
			}
			for (var orderIndex = 0; orderIndex < ModeOrder.length; orderIndex++) {
				if (ModeOrder[orderIndex].key === modeKey) {
					return ModeOrder[orderIndex].title;
				}
			}
			return modeKey || '';
		}

		function getFilesForMode(modeKey) {
			var mode = model.filesByMode && model.filesByMode[modeKey];
			return mode && Array.isArray(mode.files) ? mode.files : [];
		}

		function getInitialMode() {
			if (model.defaultMode) {
				return model.defaultMode;
			}
			return model.availableModes && model.availableModes[0] && model.availableModes[0].key || '';
		}

		function getDisplayPath(file) {
			return file && (file.displayPath || file.key) || '';
		}

		function normalizeText(value) {
			return value === null || value === undefined ? '' : String(value);
		}

		function parseDate(value) {
			var text = normalizeText(value);
			var dotNetDateMatch = /\\/Date\\((-?\\d+)/.exec(text);
			var date = dotNetDateMatch ? new Date(Number(dotNetDateMatch[1])) : new Date(text);
			return isNaN(date.getTime()) ? null : date;
		}

		function formatDate(value) {
			var date = parseDate(value);
			return date ? date.toLocaleString() : normalizeText(value);
		}

		function formatVersionMeta(versionInfo) {
			if (!versionInfo) {
				return '';
			}
			var parts = [];
			var modifiedBy = normalizeText(versionInfo.modifiedBy);
			var modifiedOn = formatDate(versionInfo.modifiedOn);
			if (modifiedBy) {
				parts.push(modifiedBy);
			}
			if (modifiedOn) {
				parts.push('(' + modifiedOn + ')');
			}
			return parts.join(' ');
		}

		function updateVersionHeaders() {
			var versionInfo = model.versionInfo || {};
			var hasPreviousVersion = model.hasPreviousVersion !== false;
			var currentVersionMeta = formatVersionMeta(versionInfo.current);
			var currentVersionText = Texts.currentVersion;
			var previousVersionText = Texts.previousVersion;
			if (dom.root) {
				dom.root.classList.toggle('no-previous-version', !hasPreviousVersion);
			}
			if (dom.leftPane) {
				dom.leftPane.classList.toggle('is-hidden', !hasPreviousVersion);
			}
			if (dom.viewMode) {
				dom.viewMode.classList.toggle('is-hidden', !hasPreviousVersion);
			}
			if (dom.compactToggleLabel) {
				dom.compactToggleLabel.classList.toggle('is-hidden', !hasPreviousVersion);
			}
			if (dom.rightVersionHead) {
				dom.rightVersionHead.classList.toggle('is-stacked', !hasPreviousVersion);
			}
			dom.leftVersionTitle.textContent = previousVersionText;
			dom.leftVersionMeta.textContent = formatVersionMeta(versionInfo.previous);
			dom.unifiedLeftVersionTitle.textContent = previousVersionText;
			dom.unifiedLeftVersionMeta.textContent = formatVersionMeta(versionInfo.previous);
			dom.unifiedRightVersionTitle.textContent = currentVersionText;
			dom.unifiedRightVersionMeta.textContent = currentVersionMeta;
			if (hasPreviousVersion) {
				dom.rightVersionTitle.textContent = currentVersionText;
				dom.rightVersionMeta.textContent = currentVersionMeta;
				return;
			}
			dom.rightVersionTitle.textContent = Texts.noPreviousVersion;
			if (model.showCurrentContentOnly) {
				dom.rightVersionTitle.textContent = Texts.noPreviousVersionDeletedDuringCleanup;
			}
			dom.rightVersionMeta.textContent = currentVersionText + ' ' + currentVersionMeta;
		}

		function compareFiles(left, right) {
			return getDisplayPath(left).localeCompare(getDisplayPath(right));
		}

		function getSortedFiles() {
			return getFilesForMode(state.selectedMode).slice().sort(compareFiles);
		}

		function getActiveFile() {
			var items = getSortedFiles();
			for (var index = 0; index < items.length; index++) {
				if (items[index].key === state.activeKey) {
					return items[index];
				}
			}
			return items[0] || null;
		}

		function splitLines(text) {
			var lines = String(text || '').replace(/\\r/g, '').split('\\n');
			return lines.length === 1 && lines[0] === '' ? [] : lines;
		}

		function createLinePair(type, left, right, hasLeft, hasRight) {
			return {
				type: type,
				left: left || '',
				right: right || '',
				hasLeft: !!hasLeft,
				hasRight: !!hasRight
			};
		}

		function findLookaheadOffset(lines, startIndex, value) {
			var endIndex = Math.min(lines.length, startIndex + MaxDiffResyncLookahead + 1);
			for (var index = startIndex + 1; index < endIndex; index++) {
				if (lines[index] === value) {
					return index - startIndex;
				}
			}
			return -1;
		}

		function buildLinePairs(leftLines, rightLines) {
			var pairs = [];
			var leftIndex = 0;
			var rightIndex = 0;

			while (leftIndex < leftLines.length && rightIndex < rightLines.length) {
				if (leftLines[leftIndex] === rightLines[rightIndex]) {
					pairs.push(createLinePair(RowTypes.same, leftLines[leftIndex], rightLines[rightIndex], true, true));
					leftIndex++;
					rightIndex++;
					continue;
				}

				var rightOffset = findLookaheadOffset(rightLines, rightIndex, leftLines[leftIndex]);
				var leftOffset = findLookaheadOffset(leftLines, leftIndex, rightLines[rightIndex]);

				if (rightOffset > 0 && (leftOffset < 0 || rightOffset < leftOffset)) {
					while (rightOffset > 0) {
						pairs.push(createLinePair(RowTypes.added, '', rightLines[rightIndex], false, true));
						rightIndex++;
						rightOffset--;
					}
					continue;
				}

				if (leftOffset > 0 && (rightOffset < 0 || leftOffset < rightOffset)) {
					while (leftOffset > 0) {
						pairs.push(createLinePair(RowTypes.removed, leftLines[leftIndex], '', true, false));
						leftIndex++;
						leftOffset--;
					}
					continue;
				}

				pairs.push(createLinePair(RowTypes.changed, leftLines[leftIndex], rightLines[rightIndex], true, true));
				leftIndex++;
				rightIndex++;
			}

			while (leftIndex < leftLines.length) {
				pairs.push(createLinePair(RowTypes.removed, leftLines[leftIndex], '', true, false));
				leftIndex++;
			}

			while (rightIndex < rightLines.length) {
				pairs.push(createLinePair(RowTypes.added, '', rightLines[rightIndex], false, true));
				rightIndex++;
			}

			return pairs;
		}

		function tokenize(text) {
			return (text || '').match(/(\\s+|[^\\s]+)/g) || [''];
		}

		function buildFragments(tokens, changedStartIndex, changedEndIndex) {
			var fragments = [];

			function appendFragment(changed, startIndex, endIndex) {
				if (startIndex >= endIndex) {
					return;
				}
				fragments.push({
					changed: changed,
					text: tokens.slice(startIndex, endIndex).join('')
				});
			}

			appendFragment(false, 0, changedStartIndex);
			appendFragment(true, changedStartIndex, changedEndIndex);
			appendFragment(false, changedEndIndex, tokens.length);
			return fragments;
		}

		function buildInlineDiff(leftText, rightText) {
			var leftTokens = tokenize(leftText);
			var rightTokens = tokenize(rightText);
			var prefixLength = 0;
			var leftSuffixIndex = leftTokens.length;
			var rightSuffixIndex = rightTokens.length;

			if (leftTokens.length > MaxInlineDiffTokens || rightTokens.length > MaxInlineDiffTokens) {
				return null;
			}

			while (prefixLength < leftTokens.length && prefixLength < rightTokens.length &&
					leftTokens[prefixLength] === rightTokens[prefixLength]) {
				prefixLength++;
			}

			while (leftSuffixIndex > prefixLength && rightSuffixIndex > prefixLength &&
					leftTokens[leftSuffixIndex - 1] === rightTokens[rightSuffixIndex - 1]) {
				leftSuffixIndex--;
				rightSuffixIndex--;
			}

			return {
				left: buildFragments(leftTokens, prefixLength, leftSuffixIndex),
				right: buildFragments(rightTokens, prefixLength, rightSuffixIndex)
			};
		}

		function createRow(pair, leftLineNumber, rightLineNumber) {
			var row = {
				leftNo: pair.hasLeft ? leftLineNumber : 0,
				rightNo: pair.hasRight ? rightLineNumber : 0,
				left: pair.left || '',
				right: pair.right || '',
				hasLeft: !!pair.hasLeft,
				hasRight: !!pair.hasRight,
				type: pair.type
			};

			if (pair.type === RowTypes.changed &&
					(row.left.length <= MaxInlineDiffLineChars && row.right.length <= MaxInlineDiffLineChars)) {
				row.inline = buildInlineDiff(row.left, row.right);
			}

			return row;
		}

		function buildRows(file) {
			if (model.showCurrentContentOnly) {
				return splitLines(file.newContent || '').map(function(line, index) {
					return {
						type: RowTypes.same,
						leftNo: 0,
						rightNo: index + 1,
						left: '',
						right: line,
						hasLeft: false,
						hasRight: true
					};
				});
			}
			var linePairs = buildLinePairs(
				splitLines(file.oldContent || ''),
				splitLines(file.newContent || '')
			);
			var leftLineNumber = 1;
			var rightLineNumber = 1;

			return linePairs.map(function(pair) {
				var row = createRow(pair, leftLineNumber, rightLineNumber);
				if (pair.hasLeft) {
					leftLineNumber++;
				}
				if (pair.hasRight) {
					rightLineNumber++;
				}
				return row;
			});
		}

		function buildHiddenRow(count) {
			var hiddenText = Texts.hiddenUnchangedLinesPrefix + count + Texts.hiddenUnchangedLinesSuffix;
			return {
				type: RowTypes.empty,
				leftNo: 0,
				rightNo: 0,
				left: hiddenText,
				right: hiddenText,
				hasLeft: true,
				hasRight: true
			};
		}

		function collectVisibleRanges(rows) {
			var ranges = [];

			for (var index = 0; index < rows.length; index++) {
				if (rows[index].type === RowTypes.same) {
					continue;
				}

				var start = Math.max(0, index - ContextLinesCount);
				var end = Math.min(rows.length - 1, index + ContextLinesCount);
				var lastRange = ranges[ranges.length - 1];

				if (!lastRange || start > lastRange.end + 1) {
					ranges.push({ start: start, end: end });
					continue;
				}

				lastRange.end = Math.max(lastRange.end, end);
			}

			return ranges;
		}

		function compactRows(rows) {
			if (!state.compact || !rows.length) {
				return rows;
			}

			var ranges = collectVisibleRanges(rows);
			if (!ranges.length) {
				return rows;
			}

			var compactedRows = [];
			var cursor = 0;

			ranges.forEach(function(range) {
				if (range.start > cursor) {
					compactedRows.push(buildHiddenRow(range.start - cursor));
				}

				for (var index = range.start; index <= range.end; index++) {
					compactedRows.push(rows[index]);
				}

				cursor = range.end + 1;
			});

			if (cursor < rows.length) {
				compactedRows.push(buildHiddenRow(rows.length - cursor));
			}

			return compactedRows;
		}

		function appendFragments(target, fragments, changedClassName) {
			(fragments || []).forEach(function(fragment) {
				var span = document.createElement('span');
				if (fragment.changed) {
					span.className = changedClassName;
				}
				span.textContent = fragment.text;
				target.appendChild(span);
			});
		}

		function appendLine(target, rowType, lineNumber, marker, textValue, fragments, changedClassName) {
			var line = document.createElement('div');
			var lineNumberEl = document.createElement('span');
			var markerEl = document.createElement('span');
			var textEl = document.createElement('span');

			line.className = 'line ' + rowType;
			lineNumberEl.className = 'num';
			lineNumberEl.textContent = lineNumber || '';
			markerEl.className = 'mark';
			markerEl.textContent = marker || '';
			textEl.className = 'text';

			if (fragments) {
				appendFragments(textEl, fragments, changedClassName);
			} else {
				textEl.textContent = textValue || '';
			}

			line.appendChild(lineNumberEl);
			line.appendChild(markerEl);
			line.appendChild(textEl);
			target.appendChild(line);
			return line;
		}

		function createLinesContainer(target) {
			var lines = document.createElement('div');
			target.innerHTML = '';
			lines.className = 'lines';
			target.appendChild(lines);
			return lines;
		}

		function fitLinesToScrollableWidth(lines) {
			var lineElements = Array.prototype.slice.call(lines.querySelectorAll('.line'));
			var content = lines.parentElement;
			var width = content ? content.clientWidth : 0;
			lines.style.width = '';
			lineElements.forEach(function(line) {
				width = Math.max(width, line.scrollWidth);
			});
			if (width > 0) {
				lines.style.width = width + 'px';
			}
		}

		function getSideMarker(rowType, side) {
			if (rowType === RowTypes.added) {
				return side === 'right' ? '+' : '';
			}
			if (rowType === RowTypes.removed) {
				return side === 'left' ? '-' : '';
			}
			if (rowType === RowTypes.changed) {
				return side === 'left' ? '-' : '+';
			}
			return '';
		}

		function getSideRenderConfig(row, side) {
			var isLeftSide = side === 'left';
			var hasContent = isLeftSide ? row.hasLeft : row.hasRight;

			return {
				rowType: row.type === RowTypes.same ? RowTypes.same : hasContent ? row.type : RowTypes.empty,
				lineNumber: isLeftSide ? (row.leftNo || '') : (row.rightNo || ''),
				marker: getSideMarker(row.type, side),
				text: hasContent ? (isLeftSide ? row.left : row.right) : '',
				fragments: row.type === RowTypes.changed && row.inline && hasContent ? row.inline[side] : null,
				changedClassName: isLeftSide ? 'inline-removed' : 'inline-added'
			};
		}

		function isChangeRow(row) {
			return row && row.type !== RowTypes.same && row.type !== RowTypes.empty;
		}

		function setLineChangeIndex(line, changeIndex) {
			if (line && changeIndex >= 0) {
				line.setAttribute('data-change-index', String(changeIndex));
			}
		}

		function assignChangeIndexes(rows) {
			var changeIndex = -1;
			var previousRowHasChange = false;
			rows.forEach(function(row) {
				if (!isChangeRow(row)) {
					previousRowHasChange = false;
					return;
				}
				if (!previousRowHasChange) {
					changeIndex++;
				}
				row.changeIndex = changeIndex;
				previousRowHasChange = true;
			});
			return changeIndex + 1;
		}

		function renderSide(target, rows, side) {
			var lines = createLinesContainer(target);
			rows.forEach(function(row) {
				var config = getSideRenderConfig(row, side);
				var line = appendLine(
					lines,
					config.rowType,
					config.lineNumber,
					config.marker,
					config.text,
					config.fragments,
					config.changedClassName
				);
				if (isChangeRow(row)) {
					setLineChangeIndex(line, row.changeIndex);
				}
			});
			fitLinesToScrollableWidth(lines);
		}

		function renderUnified(target, rows) {
			var lines = createLinesContainer(target);
			rows.forEach(function(row) {
				var firstLine;
				var secondLine;
				if (row.type === RowTypes.empty) {
					appendLine(lines, RowTypes.empty, '', '', row.left || row.right || '', null, '');
					return;
				}
				if (row.type === RowTypes.same) {
					appendLine(
						lines,
						RowTypes.same,
						row.rightNo || row.leftNo || '',
						'',
						row.right || row.left || '',
						null,
						''
					);
					return;
				}
				if (row.type === RowTypes.removed) {
					firstLine = appendLine(lines, RowTypes.removed, row.leftNo || '', '-', row.left, null, '');
					setLineChangeIndex(firstLine, row.changeIndex);
					return;
				}
				if (row.type === RowTypes.added) {
					firstLine = appendLine(lines, RowTypes.added, row.rightNo || '', '+', row.right, null, '');
					setLineChangeIndex(firstLine, row.changeIndex);
					return;
				}
				firstLine = appendLine(
					lines,
					RowTypes.removed,
					row.leftNo || '',
					'-',
					row.left,
					row.inline && row.inline.left,
					'inline-removed'
				);
				secondLine = appendLine(
					lines,
					RowTypes.added,
					row.rightNo || '',
					'+',
					row.right,
					row.inline && row.inline.right,
					'inline-added'
				);
				setLineChangeIndex(firstLine, row.changeIndex);
				setLineChangeIndex(secondLine, row.changeIndex);
			});
			fitLinesToScrollableWidth(lines);
		}

		function createEmptyBlock(text) {
			var empty = document.createElement('div');
			empty.className = 'empty';
			empty.textContent = text;
			return empty;
		}

		function getFileState(file) {
			if (!file.hasOld) {
				return Texts.added;
			}
			if (!file.hasNew) {
				return Texts.removed;
			}
			return Texts.modified;
		}

		function createTabButton(file) {
			var button = document.createElement('button');
			button.type = 'button';
			button.className = 'tab' + (file.key === state.activeKey ? ' active' : '');
			button.setAttribute('data-key', file.key);
			button.innerHTML = '<span class="tab-title"></span><span class="tab-meta"></span>';
			button.querySelector('.tab-title').textContent = getDisplayPath(file);
			button.querySelector('.tab-meta').textContent = getFileState(file);
			return button;
		}

		function createModeButton(mode) {
			var button = document.createElement('button');
			var isActive = mode.key === state.selectedMode;
			button.type = 'button';
			button.className = 'compare-mode' + (isActive ? ' active' : '');
			button.setAttribute('data-mode', mode.key);
			button.setAttribute('aria-pressed', isActive ? 'true' : 'false');
			button.innerHTML = '<span></span><span class="compare-mode-count"></span>';
			button.querySelector('span').textContent = mode.title;
			button.querySelector('.compare-mode-count').textContent = String(mode.count || 0);
			return button;
		}

		function renderModes() {
			dom.compareModes.innerHTML = '';
			(model.availableModes || []).forEach(function(mode) {
				dom.compareModes.appendChild(createModeButton(mode));
			});
		}

		function getModeUnavailableMessage() {
			var modeTitle = getModeTitle(state.selectedMode);
			return {
				title: modeTitle + Texts.modeContentUnavailable,
				message: Texts.modeNoFilesPrefix + modeTitle.toLowerCase() + Texts.modeNoFilesSuffix
			};
		}

		function renderTabs() {
			var items = getSortedFiles();
			dom.tabs.innerHTML = '';

			if (!items.length) {
				dom.tabs.appendChild(createEmptyBlock(
					model.emptyState && model.emptyState.title || getModeUnavailableMessage().title
				));
				return;
			}

			items.forEach(function(file) {
				dom.tabs.appendChild(createTabButton(file));
			});
		}

		function setEmptyContent(target, text) {
			target.innerHTML = '';
			target.appendChild(createEmptyBlock(text));
		}

		function renderEmptyState(title, meta) {
			dom.title.textContent = title;
			dom.meta.textContent = meta;
			setEmptyContent(dom.left, meta);
			setEmptyContent(dom.right, meta);
			setEmptyContent(dom.unified, meta);
		}

		function getLineCount(text) {
			return splitLines(text).length;
		}

		function isLargeFile(file) {
			var oldContent = file.oldContent || '';
			var newContent = file.newContent || '';
			return oldContent.length > MaxDiffCharsPerSide ||
				newContent.length > MaxDiffCharsPerSide ||
				getLineCount(oldContent) > MaxDiffLinesPerSide ||
				getLineCount(newContent) > MaxDiffLinesPerSide;
		}

		function renderLargeFileState(file) {
			dom.title.textContent = Texts.largeContentTitle;
			dom.meta.textContent = getDisplayPath(file) + Texts.metaSeparator + Texts.largeContentMeta;
			setEmptyContent(dom.left, Texts.largeContentPane);
			setEmptyContent(dom.right, Texts.largeContentPane);
			setEmptyContent(dom.unified, Texts.largeContentPane);
			updateChangeNavigation(0);
		}

		function resetScroll(target) {
			target.scrollTop = 0;
			target.scrollLeft = 0;
		}

		function updateHeader(file) {
			var oldLinesCount = splitLines(file.oldContent || '').length;
			var newLinesCount = splitLines(file.newContent || '').length;
			dom.title.textContent = getDisplayPath(file);
			dom.meta.textContent = getFileState(file) + Texts.metaSeparator + Texts.oldLinesLabel + oldLinesCount +
				Texts.metaSeparator + Texts.newLinesLabel + newLinesCount;
		}

		function renderActive() {
			var file = getActiveFile();
			if (!file) {
				var emptyState = model.emptyState || getModeUnavailableMessage();
				renderEmptyState(emptyState.title, emptyState.message);
				updateChangeNavigation(0);
				renderTabs();
				return;
			}

			state.activeKey = file.key;
			updateHeader(file);

			if (isLargeFile(file)) {
				renderLargeFileState(file);
				renderTabs();
				return;
			}

			var rows = compactRows(buildRows(file));
			var changeCount = assignChangeIndexes(rows);
			renderSide(dom.left, rows, 'left');
			renderSide(dom.right, rows, 'right');
			renderUnified(dom.unified, rows);
			resetScroll(dom.left);
			resetScroll(dom.right);
			resetScroll(dom.unified);
			updateChangeNavigation(changeCount);
			renderTabs();
		}

		function syncScroll(source, target) {
			if (state.syncLock) {
				return;
			}
			state.syncLock = true;
			target.scrollTop = source.scrollTop;
			target.scrollLeft = source.scrollLeft;
			state.syncLock = false;
		}

		function setViewMode(mode) {
			var hasPreviousVersion = model.hasPreviousVersion !== false;
			state.viewMode = hasPreviousVersion && mode === ViewModes.unified ? ViewModes.unified : ViewModes.side;
			if (dom.root) {
				dom.root.classList.toggle('is-unified', state.viewMode === ViewModes.unified);
			}
			dom.modeButtons.forEach(function(button) {
				var isActive = button.getAttribute('data-view-mode') === state.viewMode;
				button.classList.toggle('active', isActive);
				button.setAttribute('aria-pressed', isActive ? 'true' : 'false');
			});
		}

		function updateChangeNavigation(changeCount) {
			if (typeof changeCount === 'number') {
				state.changeCount = changeCount;
			}
			var scrollTarget = getPrimaryScrollTarget();
			var currentChangeIndex = getCurrentChangeIndex();
			dom.changeNavButtons.forEach(function(button) {
				var direction = button.getAttribute('data-change-nav');
				button.disabled = !state.changeCount ||
					(direction === 'previous' && (currentChangeIndex <= 0 || isScrollAtStart(scrollTarget))) ||
					(direction === 'next' &&
						(currentChangeIndex >= state.changeCount - 1 || isScrollAtEnd(scrollTarget)));
			});
		}

		function isScrollAtStart(target) {
			return !target || target.scrollTop <= ScrollEndTolerance;
		}

		function isScrollAtEnd(target) {
			return !target || target.scrollTop + target.clientHeight >= target.scrollHeight - ScrollEndTolerance;
		}

		function getPrimaryScrollTarget() {
			if (state.viewMode === ViewModes.unified) {
				return dom.unified;
			}
			return model.hasPreviousVersion === false ? dom.right : dom.left;
		}

		function getActiveScrollTargets() {
			var primaryTarget = getPrimaryScrollTarget();
			if (state.viewMode === ViewModes.unified) {
				return [primaryTarget];
			}
			return model.hasPreviousVersion === false ? [primaryTarget] : [dom.left, dom.right];
		}

		function getChangeLinePositions(target) {
			var itemsByIndex = {};
			return Array.prototype.slice.call(target.querySelectorAll('[data-change-index]')).reduce(function(items, line) {
				var changeIndex = Number(line.getAttribute('data-change-index'));
				var lineTop = line.offsetTop;
				var lineBottom = lineTop + line.offsetHeight;
				var item = itemsByIndex[changeIndex];
				if (isNaN(changeIndex)) {
					return items;
				}
				if (item) {
					item.bottom = Math.max(item.bottom, lineBottom);
					return items;
				}
				items.push({
					index: changeIndex,
					top: lineTop,
					bottom: lineBottom
				});
				itemsByIndex[changeIndex] = items[items.length - 1];
				return items;
			}, []);
		}

		function getCurrentChangeIndex() {
			var target = getPrimaryScrollTarget();
			if (!target || !state.changeCount) {
				return -1;
			}
			var anchorTop = target.scrollTop + target.clientHeight / 2;
			var closestChange = getChangeLinePositions(target).reduce(function(closest, item) {
				var distance = anchorTop < item.top ? item.top - anchorTop :
					anchorTop > item.bottom ? anchorTop - item.bottom : 0;
				if (!closest || distance < closest.distance) {
					return {
						index: item.index,
						distance: distance
					};
				}
				return closest;
			}, null);
			return closestChange ? closestChange.index : -1;
		}

		function scrollTargetToChange(target, changeIndex) {
			var line = target && target.querySelector('[data-change-index="' + changeIndex + '"]');
			if (!line) {
				return;
			}
			target.scrollTop = Math.max(0, line.offsetTop - target.clientHeight / 2);
		}

		function navigateChange(direction) {
			if (!state.changeCount) {
				return;
			}
			var step = direction === 'previous' ? -1 : 1;
			var currentIndex = getCurrentChangeIndex();
			var nextIndex = currentIndex + step;
			if (currentIndex < 0 || nextIndex < 0 || nextIndex >= state.changeCount) {
				updateChangeNavigation();
				return;
			}
			getActiveScrollTargets().forEach(function(target) {
				scrollTargetToChange(target, nextIndex);
			});
			updateChangeNavigation();
		}

		function scheduleChangeNavigationUpdate() {
			if (state.changeNavigationFrame) {
				return;
			}
			state.changeNavigationFrame = window.requestAnimationFrame(function() {
				state.changeNavigationFrame = 0;
				updateChangeNavigation();
			});
		}

		function bindEvents() {
			dom.compareModes.addEventListener('click', function(event) {
				var button = event.target.closest('[data-mode]');
				if (!button || button.disabled) {
					return;
				}
				state.selectedMode = button.getAttribute('data-mode') || '';
				state.activeKey = '';
				renderModes();
				renderTabs();
				renderActive();
				closeCompareMenu();
			});

			dom.tabs.addEventListener('click', function(event) {
				var button = event.target.closest('[data-key]');
				if (!button) {
					return;
				}
				state.activeKey = button.getAttribute('data-key') || '';
				renderActive();
				closeCompareMenu();
			});

			if (dom.compactToggle) {
				dom.compactToggle.addEventListener('change', function() {
					state.compact = !!dom.compactToggle.checked;
					renderActive();
				});
			}

			dom.modeButtons.forEach(function(button) {
				button.addEventListener('click', function() {
					setViewMode(button.getAttribute('data-view-mode'));
					updateChangeNavigation();
				});
			});

			dom.changeNavButtons.forEach(function(button) {
				button.addEventListener('click', function() {
					navigateChange(button.getAttribute('data-change-nav'));
				});
			});

			if (dom.compareMenuToggle) {
				dom.compareMenuToggle.addEventListener('click', function(event) {
					event.stopPropagation();
					setCompareMenuOpen(!(dom.compareMenu && dom.compareMenu.classList.contains('is-open')));
				});
			}

			if (dom.compareMenu) {
				dom.compareMenu.addEventListener('click', function(event) {
					event.stopPropagation();
				});
			}

			if (dom.fullscreenToggle) {
				dom.fullscreenToggle.addEventListener('click', function(event) {
					event.stopPropagation();
					toggleFullscreen();
				});
			}

			document.addEventListener('click', closeCompareMenu);
			document.addEventListener('keydown', function(event) {
				if (event.key === 'Escape') {
					closeCompareMenu();
					if (isFullscreenActive()) {
						setFullscreenActive(false);
					}
				}
			});

			dom.left.addEventListener('scroll', function() {
				syncScroll(dom.left, dom.right);
				scheduleChangeNavigationUpdate();
			});
			dom.right.addEventListener('scroll', function() {
				syncScroll(dom.right, dom.left);
				scheduleChangeNavigationUpdate();
			});
			dom.unified.addEventListener('scroll', function() {
				scheduleChangeNavigationUpdate();
			});
		}

		function initialize() {
			state.selectedMode = getInitialMode();
			var firstFile = getSortedFiles()[0];
			state.activeKey = firstFile ? firstFile.key : '';
			setViewMode(state.viewMode);
			renderModes();
			renderTabs();
			renderActive();
			updateVersionHeaders();
			updateFullscreenButton();
		}

		bindEvents();
		initialize();
	})();`;return{getScript:f,getTexts:r}})
Terrasoft.configuration.Structures.ConfActivityLogDiffTemplate={innerHierarchyStack:["ConfActivityLogDiffTemplate"]};define("ConfActivityLogDiffTemplate",["ConfActivityLogDiffTemplateResources"],function(n){function l(n){return n===null||n===undefined?"":String(n)}function a(n){return l(n).replace(/&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/"/g,"&quot;").replace(/'/g,"&#39;")}function v(n,t){return h.replace(i,n).replace(r,t)}function y(n){return c.replace("__ERROR_MESSAGE__",a(n))}const i="__DIFF_MODEL_JSON__",r="__RUNTIME_SCRIPT__",t={pageTitle:n.localizableStrings.PageTitle,compareContent:n.localizableStrings.CompareContent,noFilesTitle:n.localizableStrings.NoFilesTitle,noFilesMeta:n.localizableStrings.NoFilesMeta,diffViewMode:n.localizableStrings.DiffViewMode,sideBySide:n.localizableStrings.SideBySide,unified:n.localizableStrings.Unified,compactUnchangedBlocks:n.localizableStrings.CompactUnchangedBlocks},u=`"Open Sans", "Bpmonline Open Sans", Arial, sans-serif`,f=`
		@font-face {
			font-family: "Open Sans";
			font-style: normal;
			font-weight: 400;
			src: local("Open Sans"),
				url("../Resources/ui/Fonts/Open%20Sans/OpenSans-Regular.woff2") format("woff2"),
				url("../Resources/ui/Fonts/Open%20Sans/OpenSans-Regular.woff") format("woff");
		}
	`,e=`
${f}

		:root {
			color-scheme: light;
			--conf-activity-log-diff-font-family: ${u};
			font-family: var(--conf-activity-log-diff-font-family);
		}

		html,
		body {
			height: 100%;
			overflow: hidden;
		}

		body {
			margin: 0;
			background: #edf3f8;
			color: #15324a;
			font-family: var(--conf-activity-log-diff-font-family);
		}

		.gidiff {
			display: grid;
			grid-template-columns: 280px minmax(0, 1fr);
			height: 100%;
			min-height: 0;
			overflow: hidden;
		}

		.sidebar {
			display: flex;
			flex-direction: column;
			background: #fff;
			border-right: 1px solid #d7e3ef;
			min-height: 0;
			overflow: hidden;
		}

		.sidebar-head {
			padding: 18px 16px 0;
		}

		.sidebar-head h1 {
			margin: 0;
			font-size: 14px;
			letter-spacing: .04em;
			text-transform: uppercase;
			color: #61788f;
		}

		.sidebar-title-row {
			display: flex;
			align-items: center;
		}

		.compare-menu-button {
			display: none;
			align-items: center;
			justify-content: center;
			box-sizing: border-box;
			width: 32px;
			height: 32px;
			border: 0;
			border-radius: 8px;
			background: transparent;
			cursor: pointer;
		}

		.compare-menu-button:hover,
		.compare-menu-button.active {
			background: #f2f5ff;
		}

		.compare-menu-button:focus {
			outline: none;
		}

		.compare-menu-icon,
		.compare-menu-icon::before,
		.compare-menu-icon::after {
			display: block;
			width: 4px;
			height: 4px;
			border-radius: 50%;
			background: #15324a;
		}

		.compare-menu-icon {
			position: relative;
		}

		.compare-menu-icon::before,
		.compare-menu-icon::after {
			content: "";
			position: absolute;
			left: 0;
		}

		.compare-menu-icon::before {
			top: -7px;
		}

		.compare-menu-icon::after {
			top: 7px;
		}

		.compare-menu {
			display: flex;
			flex: 1 1 auto;
			flex-direction: column;
			min-height: 0;
			overflow: hidden;
		}

		.compare-modes {
			display: flex;
			flex-direction: column;
			gap: 4px;
			padding: 12px;
			border-bottom: 1px solid #d7e3ef;
		}

		.compare-mode {
			display: flex;
			align-items: center;
			justify-content: space-between;
			gap: 8px;
			min-height: 32px;
			padding: 6px 10px;
			border: 1px solid transparent;
			border-radius: 8px;
			background: transparent;
			color: #15324a;
			cursor: pointer;
			font: 13px var(--conf-activity-log-diff-font-family);
			text-align: left;
		}

		.compare-mode.active {
			background: #f2f5ff;
			border-color: transparent;
			font-weight: 600;
		}

		.compare-mode:not(:disabled):hover {
			background: #f7f9ff;
		}

		.compare-mode:disabled {
			color: #9daabb;
			cursor: default;
		}

		.compare-mode-count {
			color: #61788f;
			font-size: 12px;
			font-weight: 400;
		}

		.tabs {
			display: flex;
			flex-direction: column;
			flex: 1 1 auto;
			gap: 8px;
			min-height: 0;
			padding: 12px;
			overflow: auto;
		}

		.toggle {
			display: inline-flex;
			align-items: center;
			gap: 8px;
			min-height: 32px;
			font-size: 13px;
			line-height: 1.2;
			color: #15324a;
			cursor: pointer;
			user-select: none;
		}

		.toggle.is-hidden {
			display: none;
		}

		.toggle input {
			appearance: none;
			-webkit-appearance: none;
			box-sizing: border-box;
			width: 16px;
			height: 16px;
			margin: 0;
			flex: 0 0 auto;
			align-self: center;
			border: 1px solid #004fd6;
			border-radius: 4px;
			background: #fff;
			cursor: pointer;
		}

		.toggle input:checked {
			background-color: #004fd6;
			background-image: url("data:image/svg+xml,%3Csvg width='12' height='10' viewBox='0 0 12 10' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='M1 5L4.2 8L11 1' stroke='white' stroke-width='2' stroke-linecap='round' stroke-linejoin='round'/%3E%3C/svg%3E");
			background-position: center;
			background-repeat: no-repeat;
			background-size: 12px 10px;
			border-color: #004fd6;
		}

		.toggle input:focus {
			outline: none;
		}

		.toggle span {
			display: inline-flex;
			align-items: center;
			color: #15324a;
			font-family: var(--conf-activity-log-diff-font-family);
			font-size: 13px;
			font-weight: 600;
			line-height: 18px;
		}

		.tab {
			padding: 10px 12px;
			border: 1px solid transparent;
			border-radius: 8px;
			background: transparent;
			cursor: pointer;
			text-align: left;
			font: inherit;
			color: inherit;
		}

		.tab.active {
			background: #f2f5ff;
			border-color: transparent;
		}

		.tab:hover {
			background: #f7f9ff;
		}

		.tab-title {
			display: block;
			font-size: 13px;
			font-weight: 600;
			white-space: nowrap;
			overflow: hidden;
			text-overflow: ellipsis;
		}

		.tab-meta {
			display: block;
			margin-top: 5px;
			font-size: 12px;
			color: #61788f;
		}

		.empty {
			padding: 24px 18px;
			color: #61788f;
			font-size: 13px;
		}

		.main {
			position: relative;
			display: flex;
			flex-direction: column;
			min-width: 0;
			min-height: 0;
			overflow: hidden;
		}

		.main-head {
			display: flex;
			align-items: center;
			justify-content: space-between;
			gap: 16px;
			padding: 16px 42px 16px 18px;
			border-bottom: 1px solid #d7e3ef;
			background: rgba(255, 255, 255, .88);
		}

		.main-head-main {
			min-width: 0;
		}

		.main-title-row {
			display: flex;
			align-items: flex-start;
			gap: 8px;
			min-width: 0;
		}

		.main-title-text {
			min-width: 0;
		}

		.main-head h2 {
			margin: 0;
			font-size: 16px;
			white-space: nowrap;
			overflow: hidden;
			text-overflow: ellipsis;
		}

		.main-head p {
			margin: 5px 0 0;
			color: #61788f;
			font-size: 12px;
		}

		.main-actions {
			display: flex;
			align-items: center;
			justify-content: flex-end;
			gap: 12px;
			flex-wrap: wrap;
			min-height: 32px;
		}

		.change-navigation {
			display: inline-flex;
			align-items: center;
			gap: 2px;
			min-height: 32px;
		}

		.change-nav-button {
			display: inline-flex;
			align-items: center;
			justify-content: center;
			box-sizing: border-box;
			width: 32px;
			height: 32px;
			padding: 0;
			border: 0;
			border-radius: 8px;
			background: transparent;
			color: #15324a;
			cursor: pointer;
		}

		.change-nav-button:not(:disabled):hover {
			background: #f7f9ff;
		}

		.change-nav-button:disabled {
			color: #9daabb;
			cursor: default;
		}

		.change-nav-button:focus {
			outline: none;
		}

		.change-nav-button svg {
			width: 16px;
			height: 16px;
			fill: none;
			stroke: currentColor;
			stroke-linecap: round;
			stroke-linejoin: round;
			stroke-width: 2;
		}

		.view-mode {
			display: inline-flex;
			align-items: center;
			gap: 4px;
			min-height: 32px;
		}

		.view-mode.is-hidden {
			display: none;
		}

		.mode-button {
			display: inline-flex;
			align-items: center;
			justify-content: center;
			box-sizing: border-box;
			min-height: 32px;
			padding: 6px 10px;
			border: 0;
			border-radius: 8px;
			background: transparent;
			color: #15324a;
			cursor: pointer;
			font: 13px var(--conf-activity-log-diff-font-family);
			line-height: 1.2;
		}

		.mode-button.active {
			background: #f2f5ff;
			color: #15324a;
			font-weight: 600;
		}

		.mode-button:hover {
			background: #f7f9ff;
		}

		.mode-button:focus {
			outline: none;
		}

		.fullscreen-button {
			position: absolute;
			top: 4px;
			right: 4px;
			z-index: 2;
			display: inline-flex;
			align-items: center;
			justify-content: center;
			box-sizing: border-box;
			width: 24px;
			height: 24px;
			padding: 0;
			border: 0;
			border-radius: 4px;
			background: transparent;
			color: #15324a;
			cursor: pointer;
			flex: 0 0 auto;
		}

		.fullscreen-button:hover,
		.fullscreen-button.active {
			background: transparent;
		}

		.fullscreen-button:focus {
			outline: none;
		}

		.fullscreen-button svg {
			width: 12px;
			height: 12px;
			fill: currentColor;
		}

		.fullscreen-button .is-hidden {
			display: none;
		}

		.gidiff.is-fullscreen {
			grid-template-columns: minmax(0, 1fr);
		}

		.gidiff.is-fullscreen .sidebar {
			position: absolute;
			top: 50px;
			left: 14px;
			z-index: 6;
			display: block;
			width: 280px;
			min-height: 0;
			border-right: 0;
			background: transparent;
			overflow: visible;
			pointer-events: none;
		}

		.gidiff.is-fullscreen .sidebar-head {
			display: none;
		}

		.gidiff.is-fullscreen .compare-menu-button {
			display: inline-flex;
		}

		.gidiff.is-fullscreen .compare-menu {
			display: none;
			max-height: 420px;
			padding: 8px;
			border: 1px solid #d7e3ef;
			border-radius: 8px;
			background: #fff;
			box-shadow: 0 8px 20px rgba(21, 50, 74, .14);
			overflow: auto;
			pointer-events: auto;
		}

		.gidiff.is-fullscreen .compare-menu.is-open {
			display: flex;
		}

		.gidiff.is-fullscreen .compare-modes {
			padding: 0;
			border-bottom: 0;
		}

		.gidiff.is-fullscreen .tabs {
			flex: 0 0 auto;
			padding: 8px 0 0;
			overflow: visible;
		}

		.viewer {
			display: grid;
			grid-template-columns: 1fr 1fr;
			min-height: 0;
			flex: 1;
			overflow: hidden;
		}

		.gidiff.no-previous-version .viewer {
			grid-template-columns: 1fr;
		}

		.gidiff.no-previous-version .main-actions {
			display: none;
		}

		.unified-viewer {
			display: none;
			min-height: 0;
			flex: 1;
			overflow: hidden;
		}

		.gidiff.is-unified .viewer {
			display: none;
		}

		.gidiff.is-unified .unified-viewer {
			display: flex;
		}

		.pane {
			display: flex;
			flex-direction: column;
			min-height: 0;
			min-width: 0;
		}

		.pane + .pane {
			border-left: 1px solid #d7e3ef;
		}

		.pane.is-hidden {
			display: none;
		}

		.gidiff.no-previous-version .pane + .pane {
			border-left: 0;
		}

		.unified-viewer .pane {
			flex: 1 1 auto;
			border-left: 0;
		}

		.unified-version-head {
			display: flex;
			align-items: center;
			gap: 24px;
			min-width: 0;
			min-height: 26px;
		}

		.pane-head {
			box-sizing: border-box;
			display: flex;
			align-items: center;
			height: 46px;
			padding: 4px 14px;
			border-bottom: 1px solid #d7e3ef;
			background: #fff;
			font-size: 12px;
			font-weight: 600;
			line-height: 18px;
			color: #61788f;
		}

		.version-head {
			display: flex;
			align-items: center;
			gap: 6px;
			min-height: 26px;
			overflow: hidden;
			font-family: var(--conf-activity-log-diff-font-family);
			font-size: 13px;
			font-weight: 600;
			line-height: 18px;
			color: #15324a;
		}

		.version-head.is-stacked {
			flex-direction: column;
			align-items: flex-start;
			gap: 0;
		}

		.version-title {
			display: inline-flex;
			align-items: center;
			color: #15324a;
			font-family: var(--conf-activity-log-diff-font-family);
			font-size: 13px;
			font-weight: 600;
			line-height: 18px;
		}

		.version-meta {
			display: inline-flex;
			align-items: center;
			min-width: 0;
			overflow: hidden;
			text-overflow: ellipsis;
			color: #15324a;
			font-family: var(--conf-activity-log-diff-font-family);
			font-size: 13px;
			font-weight: 600;
			line-height: 18px;
		}

		.content {
			margin: 0;
			padding: 8px 0;
			flex: 1 1 auto;
			height: auto;
			min-height: 0;
			overflow-x: scroll;
			overflow-y: auto;
			scrollbar-gutter: stable;
			background: #fbfdff;
			font: 12px/1.45 Consolas, "Courier New", monospace;
		}

		.lines {
			min-width: 100%;
		}

		.line {
			box-sizing: border-box;
			display: grid;
			align-items: center;
			grid-template-columns: 52px 18px 1fr;
			gap: 8px;
			min-height: 22px;
			width: 100%;
			min-width: 100%;
			padding: 1px 12px;
		}

		.num,
		.mark {
			color: #8a98a8;
			user-select: none;
		}

		.num {
			text-align: right;
		}

		.mark {
			text-align: center;
			font-weight: 700;
		}

		.text {
			display: block;
			min-width: 0;
			white-space: pre;
		}

		.added {
			background: #e8f7ec;
		}

		.removed {
			background: #fdeceb;
		}

		.changed {
			background: #fff4d8;
		}

		.emptyline {
			background: repeating-linear-gradient(
				-45deg,
				rgba(128, 146, 168, .12) 0,
				rgba(128, 146, 168, .12) 4px,
				rgba(128, 146, 168, .04) 4px,
				rgba(128, 146, 168, .04) 8px
			);
			color: #a3aebb;
		}

		.inline-added {
			background: #c7ecd2;
			border-radius: 2px;
			display: inline-block;
			padding: 1px 0;
		}

		.inline-removed {
			background: #f6cfc9;
			border-radius: 2px;
			display: inline-block;
			padding: 1px 0;
		}

		@media (max-width: 900px) {
			.gidiff {
				grid-template-columns: 1fr;
			}

			.sidebar {
				position: absolute;
				top: 50px;
				left: 14px;
				z-index: 6;
				display: block;
				width: min(280px, calc(100% - 28px));
				border-right: 0;
				background: transparent;
				overflow: visible;
				pointer-events: none;
			}

			.sidebar-head {
				display: none;
			}

			.compare-menu-button {
				display: inline-flex;
			}

			.compare-menu {
				display: none;
				max-height: 360px;
				padding: 8px;
				border: 1px solid #d7e3ef;
				border-radius: 8px;
				background: #fff;
				box-shadow: 0 8px 20px rgba(21, 50, 74, .14);
				overflow: auto;
				pointer-events: auto;
			}

			.compare-menu.is-open {
				display: flex;
			}

			.compare-modes {
				padding: 0;
				border-bottom: 0;
			}

			.tabs {
				flex: 0 0 auto;
				padding: 8px 0 0;
				overflow: visible;
			}

			.main-head {
				flex-direction: column;
				align-items: stretch;
				padding-right: 42px;
			}

			.main-actions {
				justify-content: flex-start;
			}

			.viewer {
				grid-template-columns: 1fr;
				grid-template-rows: repeat(2, minmax(0, 1fr));
			}

			.gidiff.no-previous-version .viewer {
				grid-template-rows: minmax(0, 1fr);
			}

			.pane + .pane {
				border-top: 1px solid #d7e3ef;
				border-left: 0;
			}

			.gidiff.no-previous-version .pane + .pane {
				border-top: 0;
			}

		}
	`,o=`
	<div class="gidiff">
		<aside class="sidebar">
			<div class="sidebar-head">
				<div class="sidebar-title-row">
					<h1>${t.compareContent}</h1>
				</div>
			</div>
			<div class="compare-menu" data-compare-menu>
				<div class="compare-modes" data-compare-modes></div>
				<div class="tabs" data-tabs></div>
			</div>
		</aside>
		<main class="main">
			<div class="main-head">
				<div class="main-head-main">
					<div class="main-title-row">
						<button class="compare-menu-button" type="button" data-compare-menu-toggle
								aria-label="${t.compareContent}" aria-expanded="false">
							<span class="compare-menu-icon"></span>
						</button>
						<div class="main-title-text">
							<h2 data-title>${t.noFilesTitle}</h2>
							<p data-meta>${t.noFilesMeta}</p>
						</div>
					</div>
				</div>
				<div class="main-actions">
					<div class="change-navigation" role="group" aria-label="Change navigation">
						<button class="change-nav-button" type="button" data-change-nav="previous"
								aria-label="Previous change" title="Previous change">
							<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
									aria-hidden="true" focusable="false">
								<path d="m18 15-6-6-6 6" />
							</svg>
						</button>
						<button class="change-nav-button" type="button" data-change-nav="next"
								aria-label="Next change" title="Next change">
							<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
									aria-hidden="true" focusable="false">
								<path d="m6 9 6 6 6-6" />
							</svg>
						</button>
					</div>
					<div class="view-mode is-hidden" role="group" aria-label="${t.diffViewMode}">
						<button class="mode-button active" type="button" data-view-mode="side" aria-pressed="true">${t.sideBySide}</button>
						<button class="mode-button" type="button" data-view-mode="unified" aria-pressed="false">${t.unified}</button>
					</div>
					<label class="toggle">
						<input type="checkbox" data-compact-toggle checked />
						<span>${t.compactUnchangedBlocks}</span>
					</label>
				</div>
			</div>
			<button class="fullscreen-button" type="button" data-fullscreen-toggle>
				<svg xmlns="http://www.w3.org/2000/svg" width="100%" height="100%" viewBox="0 0 12 12"
						aria-hidden="true" focusable="false">
					<path data-fullscreen-enter-icon fill="currentColor" d="M6.824 2.465a.59.59 0 0 1 .59-.59h2.12a.59.59 0 0 1 .591.59v2.121a.59.59 0 1 1-1.18 0V3.89L7.477 5.357a.59.59 0 1 1-.835-.835L8.11 3.056h-.696a.59.59 0 0 1-.59-.59ZM5.357 6.643a.59.59 0 0 1 0 .835L3.89 8.944h.696a.59.59 0 1 1 0 1.181h-2.12a.59.59 0 0 1-.591-.59V7.414a.59.59 0 0 1 1.18 0v.696l1.467-1.467a.59.59 0 0 1 .835 0Z" />
					<path data-fullscreen-exit-icon class="is-hidden" fill="currentColor" d="M10.311 1.689a.644.644 0 0 1 0 .91l-1.6 1.6h.76a.644.644 0 0 1 0 1.288H7.156a.644.644 0 0 1-.644-.644V2.53a.644.644 0 1 1 1.288 0v.759l1.6-1.6a.644.644 0 0 1 .91 0ZM1.886 7.157c0-.356.288-.644.644-.644h2.313c.356 0 .644.288.644.644V9.47a.644.644 0 1 1-1.288 0v-.759l-1.6 1.6a.644.644 0 1 1-.91-.91l1.6-1.6h-.76a.644.644 0 0 1-.643-.644Z" />
				</svg>
			</button>
			<div class="viewer">
				<section class="pane">
					<div class="pane-head">
						<div class="version-head">
							<span class="version-title" data-left-version-title></span>
							<span class="version-meta" data-left-version-meta></span>
						</div>
					</div>
					<div class="content" data-left></div>
				</section>
				<section class="pane">
					<div class="pane-head">
						<div class="version-head">
							<span class="version-title" data-right-version-title></span>
							<span class="version-meta" data-right-version-meta></span>
						</div>
					</div>
					<div class="content" data-right></div>
				</section>
			</div>
			<div class="unified-viewer">
				<section class="pane">
					<div class="pane-head">
						<div class="unified-version-head">
							<div class="version-head">
								<span class="version-title" data-unified-left-version-title></span>
								<span class="version-meta" data-unified-left-version-meta></span>
							</div>
							<div class="version-head">
								<span class="version-title" data-unified-right-version-title></span>
								<span class="version-meta" data-unified-right-version-meta></span>
							</div>
						</div>
					</div>
					<div class="content" data-unified></div>
				</section>
			</div>
		</main>
	</div>
	`,s=`
${f}

		body {
			margin: 0;
			padding: 24px;
			background: #edf3f8;
			color: #15324a;
			font: 13px ${u};
		}

		pre {
			margin: 0;
			padding: 16px;
			border: 1px solid #d7e3ef;
			border-radius: 8px;
			background: #fff;
			white-space: pre-wrap;
		}
	`,h=`<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<title>${t.pageTitle}</title>
	<style>
${e}
	</style>
</head>
<body>
${o}
	<script>
		var diffModel = ${i};
${r}
	</script>
</body>
</html>`,c=`<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<title>${t.pageTitle}</title>
	<style>
${s}
	</style>
</head>
<body><pre>__ERROR_MESSAGE__</pre></body>
</html>`;return{buildDiffHtml:v,buildErrorHtml:y}})
Terrasoft.configuration.Structures.ConfigurationSystemDesignerSectionV2={innerHierarchyStack:["ConfigurationSystemDesignerSectionV2"],structureParent:"BaseSystemDesignerSectionV2"};define("ConfigurationSystemDesignerSectionV2Structure",["ConfigurationSystemDesignerSectionV2Resources"],function(){return{schemaUId:"c1e923c8-0a42-4632-bdc8-0e8bf2caa645",schemaCaption:"Admin area",parentSchemaName:"BaseSystemDesignerSectionV2",packageName:"CrtUIv2",schemaName:"ConfigurationSystemDesignerSectionV2",parentSchemaUId:"11d4ac38-ad67-4331-968a-5376ebb77b6f",extendParent:!1,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ConfigurationSystemDesignerSectionV2",["terrasoft"],function(){return{diff:[]}})
Terrasoft.configuration.Structures.ConfItemSearchRowSchema={innerHierarchyStack:["ConfItemSearchRowSchema"],structureParent:"BaseSearchRowSchema"};define("ConfItemSearchRowSchemaStructure",["ConfItemSearchRowSchemaResources"],function(){return{schemaUId:"52354b31-c7e3-4c22-94de-471905950eb4",schemaCaption:"ConfItemSearchRowSchema",parentSchemaName:"BaseSearchRowSchema",packageName:"GlobalSearch",schemaName:"ConfItemSearchRowSchema",parentSchemaUId:"254c5d91-bad1-44be-a75e-1d511f816dc0",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ConfItemSearchRowSchema",[],function(){return{diff:[{operation:"remove",name:"EntitySchemaCaption"},{operation:"merge",name:"PrimaryColumnContainer",values:{layout:{column:0,row:0,colSpan:18}}},{operation:"merge",name:"FoundColumnsContainerList",values:{layout:{column:0,row:2,colSpan:12}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Type",values:{layout:{column:18,row:0,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"InventoryNumber",values:{layout:{column:0,row:1,colSpan:12}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"SerialNumber",values:{layout:{column:12,row:1,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Status",values:{layout:{column:18,row:1,colSpan:6}}}]}})
Terrasoft.configuration.Structures.ContactAnniversariesReportFilter={innerHierarchyStack:["ContactAnniversariesReportFilter"]};define("ContactAnniversariesReportFilter",["ContactAnniversariesReportFilterResources"],function(n){return[{name:"FormingMethod",dataValueType:"FormingMethod"},{name:"PeriodFilter",caption:n.localizableStrings.PeriodFilterCaption,dataValueType:"PeriodFilter",columnName:"CreatedOn",startDate:{defValue:Terrasoft.startOfWeek(new Date)},dueDate:{defValue:Terrasoft.endOfWeek(new Date)}}]})
Terrasoft.configuration.Structures.ContactCareerDetail={innerHierarchyStack:["ContactCareerDetail"]};define("ContactCareerDetailStructure",function(){return{type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ContactCareerDetail",["terrasoft","ContactCareer","ContactCareerDetailStructure","ContactCareerDetailResources"],function(n,t,i,r){return i.userCode=function(){var i,u;this.name="ContactCareerDetailViewModel";switch(this.filterPath){case"Contact":this.columnsConfig=[[{cols:24,key:[{name:{bindTo:"Account"},type:"title"}]}],[{cols:12,key:[{name:{bindTo:"Job"}}]},{cols:6,key:[{name:{bindTo:"Current"}}]},{cols:6,key:[{name:{bindTo:"Primary"}}]}]];this.loadedColumns=[{columnPath:"Account"},{columnPath:"Job"},{columnPath:"Current"},{columnPath:"Primary"}];this.editPageName="ContactCareerPageInContact";break;case"Account":this.columnsConfig=[[{cols:12,key:[{name:{bindTo:"Contact"},type:"title"}]},{cols:6,key:[{name:{bindTo:"Contact.Phone"}}]},{cols:6,key:[{name:{bindTo:"Contact.Email"}}]}],[{cols:12,key:[{name:{bindTo:"Job"}}]},{cols:6,key:[{name:{bindTo:"Department"}}]},{cols:6,key:[{name:{bindTo:"Current"}}]}]];this.loadedColumns=[{columnPath:"Contact"},{columnPath:"Contact.Phone"},{columnPath:"Contact.Email"},{columnPath:"Job"},{columnPath:"Department"},{columnPath:"Current"}];this.editPageName="ContactCareerPageInAccount";this.editPages=[{caption:r.localizableStrings.AddContact,name:"AddContact",UId:"",bindTo:"addAddContact"},{caption:r.localizableStrings.LinkToContact,name:"LinkToContact",UId:"",bindTo:"addLinkToContact"}]}this.entitySchema=t;this.methods.addAddContact=function(){i("ContactPage",this)};this.methods.addLinkToContact=function(){i("ContactCareerPageInAccount",this)};i=function(n,t){var e={name:t.filterPath,value:t.filterValue},i=t.sandbox,r=i.id+"_CardModule_"+n,u=function(){i.subscribe("CardModuleEntityInfo",function(){var t={};return t.action="add",t.cardSchemaName=n,t.activeRow="",t.valuePairs=[],t.valuePairs.push(e),t},[r]);i.publish("OpenCardModule",r,[t.getCardModuleSandboxId()]);i.subscribe("UpdateDetail",function(){t.isObsolete=!0},[r])},o,s=t.args.operationType==="add"||t.args.operationType==="copy";if(s){var h=i.publish("GetHistoryState"),f=h.state.moduleId,c={callback:u,tag:null,scope:t,escope:t,customAction:o,moduleId:Ext.isEmpty(f)?i.id:f};i.publish("SaveRecord",c)}else u()};this.methods.gridRecolor=function(){var t=this.get("gridData"),r=t.getItems(),i={};n.each(r,function(n){n.customStyle=null;n.values.Current||(n.customStyle={color:"gray"});var t=n.get(n.primaryColumnName);i[t]=n},this);t.clear();t.loadAll(i)};u=this.methods.onLoadData;this.methods.onLoadData=function(n){u.call(this,n);this.gridRecolor()}},i})
Terrasoft.configuration.Structures.ContactCareerPageInAccount={innerHierarchyStack:["ContactCareerPageInAccount"]};define("ContactCareerPageInAccountStructure",function(){return{type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ContactCareerPageInAccount",["ext-base","terrasoft","sandbox","ContactCareer","ContactCareerPageInAccountStructure","ContactCareerPageInAccountResources"],function(n,t,i,r,u,f){return u.userCode=function(){var i,u,e;this.entitySchema=r;this.name="ContactCareerCardViewModel";this.schema.leftPanel=[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Id",columnPath:"Id",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",dataValueType:t.DataValueType.LOOKUP,visible:!0,customConfig:{enabled:!1}},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Contact",columnPath:"Contact",dataValueType:t.DataValueType.LOOKUP,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Job",columnPath:"Job",dataValueType:t.DataValueType.ENUM,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"JobTitle",columnPath:"JobTitle",dataValueType:t.DataValueType.TEXT,visible:!0,dependencies:["Job"],methodName:"onJobChange"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Department",columnPath:"Department",dataValueType:t.DataValueType.LOOKUP,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"StartDate",columnPath:"StartDate",dataValueType:t.DataValueType.DATE,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"DueDate",columnPath:"DueDate",dataValueType:t.DataValueType.DATE,visible:!0,dependencies:["Current"],methodName:"onCurrentChange"},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Primary",columnPath:"Primary",dataValueType:t.DataValueType.BOOLEAN,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Current",columnPath:"Current",dataValueType:t.DataValueType.BOOLEAN,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"JobChangeReason",columnPath:"JobChangeReason",dataValueType:t.DataValueType.ENUM,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Description",columnPath:"Description",dataValueType:t.DataValueType.TEXT,visible:!0}];this.methods={init:function(){u=this.get("Current");e=this.get("Primary")},onJobChange:function(){var t=this.get("Job");n.isEmpty(t)||this.set("JobTitle",t.displayValue)},onCurrentChange:function(){var n=this.get("Current");n?this.set("DueDate",null):this.set("DueDate",new Date)},save:function(){var u=this.get("StartDate"),t=this.get("DueDate"),i,r,n;if(t!==null&&u>t){this.showInformationDialog(f.localizableStrings.WarningWrongDate);return}i=this.get("Current");r=this.get("Primary");i&&r?(n=this.get("Contact"),n&&this.getContactCareerCollection(n.value)):this.saveEntity(this.onSaved)},getContactCareerCollection:function(i){var r=n.create("Terrasoft.EntitySchemaQuery",{rootSchemaName:"ContactCareer"});r.addColumn("Id");r.addColumn("Contact");r.addColumn("Account");r.addColumn("Job");r.filters.add("CareerIdFilter",r.createColumnFilterWithParameter(t.ComparisonType.NOT_EQUAL,"Id",this.get("Id")));r.filters.add("CurrentIdFilter",r.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Contact",i));r.filters.add("CurrentFilter",r.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Current",!0));r.filters.add("PrimaryFilter",r.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Primary",!0));r.getEntityCollection(this.onGetSelectResult,this)},onGetSelectResult:function(r){var u;if(i=r.collection,u={buttons:[t.MessageBoxButtons.YES.returnCode,t.MessageBoxButtons.NO.returnCode],defaultButton:0},i.getCount()>0){var s=f.localizableStrings.ChangeContactJob,h=i.getItems()[0].get("Contact").displayValue,c=i.getItems()[0].get("Account").displayValue,e=i.getItems()[0].get("Job"),o="";e&&(o=e.displayValue);this.showInformationDialog(n.String.format(s,h,c,o),this.getSelectedButton,u)}else this.saveEntity(this.onSaved)},getSelectedButton:function(n){n===t.MessageBoxButtons.YES.returnCode?this.saveEntity(this.onAnswerYes,this):this.saveEntity(this.onAnswerNo,this)},onAnswerNo:function(){var f=i.getItems()[0].get("Id"),u=n.create("Terrasoft.UpdateQuery",{rootSchema:r});u.filters.add("ContactIdFilter",u.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Id",f));u.setParameterValue("Current",!1);u.setParameterValue("DueDate",new Date);u.execute();this.onSaved()},onAnswerYes:function(){var f=i.getItems()[0].get("Id"),u=n.create("Terrasoft.UpdateQuery",{rootSchema:r});u.filters.add("ContactIdFilter",u.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Id",f));u.setParameterValue("Primary",!1);u.execute();this.onSaved()}}},u})
Terrasoft.configuration.Structures.ContactCareerPageInContact={innerHierarchyStack:["ContactCareerPageInContact"]};define("ContactCareerPageInContactStructure",["ContactCareerPageInContactResources"],function(){return{type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ContactCareerPageInContact",["ext-base","terrasoft","sandbox","ContactCareer","ContactCareerPageInContactStructure","ContactCareerPageInContactResources"],function(n,t,i,r,u,f){return u.userCode=function(){var i,u,e;this.entitySchema=r;this.name="ContactCareerCardViewModel";this.schema.leftPanel=[{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Id",columnPath:"Id",visible:!1,viewVisible:!1},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Account",columnPath:"Account",dataValueType:t.DataValueType.LOOKUP,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Contact",columnPath:"Contact",dataValueType:t.DataValueType.LOOKUP,visible:!0,customConfig:{enabled:!1}},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Job",columnPath:"Job",dataValueType:t.DataValueType.ENUM,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"JobTitle",columnPath:"JobTitle",dataValueType:t.DataValueType.TEXT,visible:!0,dependencies:["Job"],methodName:"onJobChange"},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"Department",columnPath:"Department",dataValueType:t.DataValueType.LOOKUP,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"StartDate",columnPath:"StartDate",dataValueType:t.DataValueType.DATE,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"DueDate",columnPath:"DueDate",dataValueType:t.DataValueType.DATE,visible:!0,dependencies:["Current"],methodName:"onCurrentChange"},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Primary",columnPath:"Primary",dataValueType:t.DataValueType.BOOLEAN,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Current",columnPath:"Current",dataValueType:t.DataValueType.BOOLEAN,visible:!0},{type:t.core.enums.ViewModelSchemaItem.ATTRIBUTE,name:"JobChangeReason",columnPath:"JobChangeReason",dataValueType:t.DataValueType.ENUM,visible:!0},{type:t.ViewModelSchemaItem.ATTRIBUTE,name:"Description",columnPath:"Description",dataValueType:t.DataValueType.TEXT,visible:!0}];this.methods={init:function(){u=this.get("Current");e=this.get("Primary")},onJobChange:function(){var t=this.get("Job");n.isEmpty(t)||this.set("JobTitle",t.displayValue)},onCurrentChange:function(){var n=this.get("Current");n?this.set("DueDate",null):this.set("DueDate",new Date)},save:function(){var u=this.get("StartDate"),n=this.get("DueDate"),t,i,r;if(n!==null&&u>n){this.showInformationDialog(f.localizableStrings.WarningWrongDate);return}t=this.get("Current");i=this.get("Primary");t&&i?(r=this.get("Contact").value,this.getContactCareerCollection(r)):this.saveEntity(this.onSaved)},getContactCareerCollection:function(i){var r=n.create("Terrasoft.EntitySchemaQuery",{rootSchemaName:"ContactCareer"});r.addColumn("Id");r.addColumn("Contact");r.addColumn("Account");r.addColumn("Job");r.filters.add("CareerIdFilter",r.createColumnFilterWithParameter(t.ComparisonType.NOT_EQUAL,"Id",this.get("Id")));r.filters.add("CurrentIdFilter",r.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Contact",i));r.filters.add("CurrentFilter",r.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Current",!0));r.filters.add("PrimaryFilter",r.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Primary",!0));r.getEntityCollection(this.onGetSelectResult,this)},onGetSelectResult:function(r){var u;if(i=r.collection,u={buttons:[t.MessageBoxButtons.YES.returnCode,t.MessageBoxButtons.NO.returnCode],defaultButton:0},i.getCount()>0){var s=f.localizableStrings.ChangeContactJob,h=i.getItems()[0].get("Contact").displayValue,c=i.getItems()[0].get("Account").displayValue,e=i.getItems()[0].get("Job"),o="";e&&(o=e.displayValue);this.showInformationDialog(n.String.format(s,h,c,o),this.getSelectedButton,u)}else this.saveEntity(this.onSaved)},getSelectedButton:function(n){n===t.MessageBoxButtons.YES.returnCode?this.saveEntity(this.onAnswerYes,this):this.saveEntity(this.onAnswerNo,this)},onAnswerNo:function(){var f=i.getItems()[0].get("Id"),u=n.create("Terrasoft.UpdateQuery",{rootSchema:r});u.filters.add("ContactIdFilter",u.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Id",f));u.setParameterValue("Current",!1);u.setParameterValue("DueDate",new Date);u.execute();this.onSaved()},onAnswerYes:function(){var f=i.getItems()[0].get("Id"),u=n.create("Terrasoft.UpdateQuery",{rootSchema:r});u.filters.add("ContactIdFilter",u.createColumnFilterWithParameter(t.ComparisonType.EQUAL,"Id",f));u.setParameterValue("Primary",!1);u.execute();this.onSaved()}}},u})
Terrasoft.configuration.Structures.ContactEnrichmentSchemaCSS={innerHierarchyStack:["ContactEnrichmentSchemaCSS"]};define("ContactEnrichmentSchemaCSS",[],function(){})
Terrasoft.configuration.Structures.ContactSearchRowSchema={innerHierarchyStack:["ContactSearchRowSchema"],structureParent:"BaseSearchRowSchema"};define("ContactSearchRowSchemaStructure",["ContactSearchRowSchemaResources"],function(){return{schemaUId:"81ecc8f8-fe04-45a5-9827-2c7ee5d7ee81",schemaCaption:"ContactSearchRowSchema",parentSchemaName:"BaseSearchRowSchema",packageName:"GlobalSearch",schemaName:"ContactSearchRowSchema",parentSchemaUId:"254c5d91-bad1-44be-a75e-1d511f816dc0",extendParent:!1,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:"",name:"",extend:"Terrasoft.model.BaseViewModel",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){}}});define("ContactSearchRowSchema",[],function(){return{diff:[{operation:"remove",name:"EntitySchemaCaption"},{operation:"merge",name:"FoundColumnsContainerList",values:{layout:{column:0,row:2,colSpan:12}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Job",values:{layout:{column:12,row:0,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Phone",values:{layout:{column:18,row:0,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Account",values:{layout:{column:0,row:1,colSpan:12}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"Email",values:{className:"Terrasoft.Hyperlink",href:{bindTo:"getEmailUrl"},click:{bindTo:"onEmailUrlClick"},layout:{column:12,row:1,colSpan:6}}},{operation:"insert",parentName:"DataContainer",propertyName:"items",name:"MobilePhone",values:{layout:{column:18,row:1,colSpan:6}}}]}})