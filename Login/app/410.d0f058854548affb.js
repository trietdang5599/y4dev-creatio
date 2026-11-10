"use strict";(self.webpackChunkapp_studio_enterprise_login=self.webpackChunkapp_studio_enterprise_login||[]).push([[410],{3410(D,h,l){l.r(h),l.d(h,{TableCellWrapperComponent:()=>d.TableCellWrapperComponent,TableComponent:()=>d.TableComponent,TableModule:()=>C.TableModule,TreeTableComponent:()=>d.TreeTableComponent});var d=l(42779),C=l(86650)},42779(D,h,l){l.r(h),l.d(h,{TableCellWrapperComponent:()=>C.TableCellWrapperComponent,TableComponent:()=>d.TableComponent,TreeTableComponent:()=>s.TreeTableComponent});var d=l(9505),C=l(84733),s=l(49377)},84733(D,h,l){l.r(h),l.d(h,{TableCellWrapperComponent:()=>c});var d=l(56622),C=l(19965),s=l(75444),b=l(41374),_=l(49866),i=l(23596);const u=["tableCell"];class c{constructor(){this.valueChange=new C.EventEmitter}_generateTableCell(t){this.tableCell.clear();const p=this.tableCell.createComponent(t),g=p.instance;if(t!==_.TableCellComponent&&!(g instanceof b.BaseTableCellComponent))throw new TypeError("Value of property `cellComponentClass` must be a component class inherited from `BaseTableCellComponent`");return p}_updateTableCell(){const t=this.columnDataSchema.cellComponentClass||_.TableCellComponent;(!this._cellComponentRef||!(this._cellComponentRef.instance instanceof t))&&(this._cellComponentRef=this._generateTableCell(t));const p=this._cellComponentRef.instance;p.columnDataSchema=this.columnDataSchema,p.record=this.record,p.eventHandlers=this.eventHandlers,p instanceof s.BaseEditableTableCellComponent&&p.valueChange.subscribe(g=>this.valueChange.emit(g)),this._cellComponentRef.changeDetectorRef.detectChanges()}ngOnChanges(t){!this.record||!this.columnDataSchema||!(t.record||t.columnDataSchema||t.eventHandlers&&!(0,i.default)(t.eventHandlers.previousValue,t.eventHandlers.currentValue))||this._updateTableCell()}static{this.\u0275fac=function(p){return new(p||c)}}static{this.\u0275cmp=d.\u0275\u0275defineComponent({type:c,selectors:[["ts-table-cell-wrapper"]],viewQuery:function(p,g){if(p&1&&d.\u0275\u0275viewQuery(u,7,d.ViewContainerRef),p&2){let w;d.\u0275\u0275queryRefresh(w=d.\u0275\u0275loadQuery())&&(g.tableCell=w.first)}},inputs:{columnDataSchema:"columnDataSchema",record:"record",eventHandlers:"eventHandlers"},outputs:{valueChange:"valueChange"},standalone:!1,features:[d.\u0275\u0275NgOnChangesFeature],decls:2,vars:0,consts:[["tableCell",""]],template:function(p,g){p&1&&d.\u0275\u0275element(0,"span",null,0)},encapsulation:2})}}},9505(D,h,l){l.r(h),l.d(h,{TableComponent:()=>R});var d=l(85899),C=l(66900),s=l(19965),b=l(22029),_=l(68403),i=l(38495),u=l(53637),c=l(23596),f=l(2978),t=l(56622),p=l(2002),g=l(26182),w=l(63422),E=l(84733);const S=()=>["expandableRow"];function v(o,e){if(o&1){const n=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"th",3)(1,"mat-checkbox",12),t.\u0275\u0275listener("change",function(r){s.\u0275\u0275restoreView(n);const m=t.\u0275\u0275nextContext(3);return s.\u0275\u0275resetView(r?m.allRowsSelectToggle():null)}),t.\u0275\u0275elementEnd()()}if(o&2){const n=t.\u0275\u0275nextContext(3);t.\u0275\u0275advance(),t.\u0275\u0275styleProp("visibility",n.showSelectAllButton&&!n.isEmpty()?"visible":"hidden"),t.\u0275\u0275property("checked",n.isAllRowsCheckboxChecked())("indeterminate",n.isAllRowsCheckboxIntermediate())}}function T(o,e){o&1&&t.\u0275\u0275template(0,v,2,4,"th",11)}function P(o,e){if(o&1){const n=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"td",13)(1,"mat-checkbox",14),t.\u0275\u0275listener("click",function(r){const m=s.\u0275\u0275restoreView(n).$implicit,x=t.\u0275\u0275nextContext(2);return s.\u0275\u0275resetView(x.onCheckboxClick(m,r))}),t.\u0275\u0275elementEnd()()}if(o&2){const n=e.$implicit,a=t.\u0275\u0275nextContext(2);t.\u0275\u0275advance(),t.\u0275\u0275property("checked",a.isRecordSelected(n))}}function y(o,e){o&1&&t.\u0275\u0275element(0,"th",5)}function M(o,e){o&1&&t.\u0275\u0275template(0,y,1,0,"th",15)}function O(o,e){if(o&1){const n=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"td",16)(1,"button",17),t.\u0275\u0275listener("click",function(r){const m=s.\u0275\u0275restoreView(n).$implicit,x=t.\u0275\u0275nextContext(2);return s.\u0275\u0275resetView(x.toggleRowExpansion(m,r))}),t.\u0275\u0275element(2,"mat-icon",18),t.\u0275\u0275elementEnd()()}if(o&2){const n=e.$implicit,a=t.\u0275\u0275nextContext(2);t.\u0275\u0275advance(),t.\u0275\u0275classProp("expanded",a.isRecordExpanded(n))("collapsed",!a.isRecordExpanded(n)),t.\u0275\u0275advance(),t.\u0275\u0275property("ngClass","row-expander-icon "+(a.isRecordExpanded(n)?"expanded":"collapsed"))}}function A(o,e){if(o&1&&(t.\u0275\u0275elementStart(0,"th",19)(1,"label"),t.\u0275\u0275text(2),t.\u0275\u0275elementEnd()()),o&2){const n=t.\u0275\u0275nextContext(3).$implicit,a=t.\u0275\u0275nextContext(2);t.\u0275\u0275property("disabled",!a.isColumnSortable(n))("ngClass",a.getColumnHeaderCssClass(n.valueType,n.span)),t.\u0275\u0275advance(2),t.\u0275\u0275textInterpolate(n.caption)}}function I(o,e){o&1&&t.\u0275\u0275template(0,A,3,3,"th",20)}function B(o,e){if(o&1){const n=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"td",21)(1,"ts-table-cell-wrapper",22),t.\u0275\u0275listener("valueChange",function(r){const m=s.\u0275\u0275restoreView(n).$implicit,x=t.\u0275\u0275nextContext(2).$implicit,k=t.\u0275\u0275nextContext(2);return s.\u0275\u0275resetView(k.onCellValueChange(m,x,r))}),t.\u0275\u0275elementEnd()()}if(o&2){const n=e.$implicit,a=t.\u0275\u0275nextContext(),r=t.\u0275\u0275nextContext().$implicit,m=t.\u0275\u0275nextContext(2);t.\u0275\u0275property("ngClass",m.getValueTypeCssClass(r.valueType)),t.\u0275\u0275advance(),t.\u0275\u0275property("columnDataSchema",r)("record",n)("eventHandlers",m.eventHandlers&&m.eventHandlers[a])}}function W(o,e){if(o&1&&(t.\u0275\u0275elementContainerStart(0,2),t.\u0275\u0275conditionalCreate(1,I,1,0,"th",19),t.\u0275\u0275template(2,B,2,4,"td",8),t.\u0275\u0275elementContainerEnd()),o&2){const n=t.\u0275\u0275nextContext(3);t.\u0275\u0275property("matColumnDef",t.\u0275\u0275interpolate(e)),t.\u0275\u0275advance(),t.\u0275\u0275conditional(n.showHeader?1:-1)}}function L(o,e){if(o&1&&t.\u0275\u0275conditionalCreate(0,W,3,3,"ng-container",2),o&2){let n;const a=e.$implicit;t.\u0275\u0275conditional((n=a.name)?0:-1,n)}}function V(o,e){if(o&1&&(t.\u0275\u0275elementStart(0,"td",21)(1,"div",23)(2,"div",24),t.\u0275\u0275element(3,"ts-table-cell-wrapper",25),t.\u0275\u0275elementEnd()()()),o&2){const n=e.$implicit,a=t.\u0275\u0275nextContext(2);t.\u0275\u0275property("ngClass","expandable-cell-"+(a.isRecordExpanded(n)?"expanded":"collapsed")),t.\u0275\u0275attribute("colspan",a.columns.length),t.\u0275\u0275advance(),t.\u0275\u0275classProp("expanded",a.isRecordExpanded(n))("collapsed",!a.isRecordExpanded(n)),t.\u0275\u0275advance(2),t.\u0275\u0275property("columnDataSchema",a.dataSchema.expandableRow)("record",n)("eventHandlers",a.eventHandlers&&a.eventHandlers[a.dataSchema.expandableRow.name])}}function H(o,e){o&1&&t.\u0275\u0275element(0,"tr",9)}function K(o,e){if(o&1&&t.\u0275\u0275template(0,H,1,0,"tr",26),o&2){const n=t.\u0275\u0275nextContext(2);t.\u0275\u0275property("matHeaderRowDef",n.columns)("matHeaderRowDefSticky",n.headerSticky)}}function U(o,e){if(o&1){const n=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"tr",27),t.\u0275\u0275listener("click",function(){const r=s.\u0275\u0275restoreView(n).$implicit,m=t.\u0275\u0275nextContext(2);return s.\u0275\u0275resetView(m.onRowClick(r))})("dblclick",function(){const r=s.\u0275\u0275restoreView(n).$implicit,m=t.\u0275\u0275nextContext(2);return s.\u0275\u0275resetView(m.onRowDoubleClick(r))}),t.\u0275\u0275elementEnd()}if(o&2){const n=e.$implicit,a=e.even,r=t.\u0275\u0275nextContext(2);t.\u0275\u0275property("ngClass",r.getRowCssClass(n,a))("cdkDragData",n)("cdkDragBoundary",r.dragBoundarySelector)("cdkDragDisabled",!r.enableOrdering)}}function F(o,e){o&1&&t.\u0275\u0275element(0,"tr",29)}function N(o,e){o&1&&(t.\u0275\u0275elementStart(0,"div"),t.\u0275\u0275template(1,F,1,0,"tr",28),t.\u0275\u0275elementEnd()),o&2&&(t.\u0275\u0275advance(),t.\u0275\u0275property("matRowDefColumns",t.\u0275\u0275pureFunction0(1,S)))}function $(o,e){if(o&1){const n=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"table",1),t.\u0275\u0275listener("matSortChange",function(r){s.\u0275\u0275restoreView(n);const m=t.\u0275\u0275nextContext();return s.\u0275\u0275resetView(m.onSortChange(r))})("cdkDropListDropped",function(r){s.\u0275\u0275restoreView(n);const m=t.\u0275\u0275nextContext();return s.\u0275\u0275resetView(m.onItemDrop(r))}),t.\u0275\u0275elementContainerStart(1,2),t.\u0275\u0275conditionalCreate(2,T,1,0,"th",3),t.\u0275\u0275template(3,P,2,1,"td",4),t.\u0275\u0275elementContainerEnd(),t.\u0275\u0275elementContainerStart(4,2),t.\u0275\u0275conditionalCreate(5,M,1,0,"th",5),t.\u0275\u0275template(6,O,3,5,"td",6),t.\u0275\u0275elementContainerEnd(),t.\u0275\u0275repeaterCreate(7,L,1,1,null,null,t.\u0275\u0275repeaterTrackByIdentity),t.\u0275\u0275elementContainerStart(9,7),t.\u0275\u0275template(10,V,4,9,"td",8),t.\u0275\u0275elementContainerEnd(),t.\u0275\u0275conditionalCreate(11,K,1,2,"tr",9),t.\u0275\u0275template(12,U,1,4,"tr",10),t.\u0275\u0275conditionalCreate(13,N,2,2,"div"),t.\u0275\u0275elementEnd()}if(o&2){const n=t.\u0275\u0275nextContext();t.\u0275\u0275styleProp("display",n.isEmpty()?"none":null),t.\u0275\u0275property("dataSource",n.dataSource)("matSortDirection",n.sortDirection)("matSortActive",n.sortColumn)("cdkDropListDisabled",!n.enableOrdering)("trackBy",n.trackByFunction),t.\u0275\u0275advance(),t.\u0275\u0275property("matColumnDef",t.\u0275\u0275interpolate(n.getMultiSelectColumnName())),t.\u0275\u0275advance(),t.\u0275\u0275conditional(n.showHeader?2:-1),t.\u0275\u0275advance(2),t.\u0275\u0275property("matColumnDef",t.\u0275\u0275interpolate(n.getRowExpanderColumnName())),t.\u0275\u0275advance(),t.\u0275\u0275conditional(n.showHeader?5:-1),t.\u0275\u0275advance(2),t.\u0275\u0275repeater(n.dataSchema.columns),t.\u0275\u0275advance(4),t.\u0275\u0275conditional(n.showHeader?11:-1),t.\u0275\u0275advance(),t.\u0275\u0275property("matRowDefColumns",n.columns),t.\u0275\u0275advance(),t.\u0275\u0275conditional(n.dataSchema.expandableRow?13:-1)}}const G=["headerSticky","selectMode","showHeader","showSelectAllButton","allRowsSelectState","allRowsSelectToggleHandler","sortable","sortColumn","sortDirection","selectedRowCssClass","evenRowCssClass","minWidthPerColumn"],Q={selectMode:"none",headerSticky:!1,showHeader:!0,showSelectAllButton:!0,sortable:!0,sortColumn:"",sortDirection:"asc",selectedRowCssClass:"selected",evenRowCssClass:"even-row",minWidthPerColumn:120};class R{get filteredData(){return this.dataSource?this.dataSource.filteredData:[]}get dataSchema(){return this._dataSchema}set dataSchema(e){this._dataSchema=e;const n={};e&&e.columns.forEach(a=>{n[a.name]=a}),this.columnsDataSchema=n,this.markForCheck()}get dataColumns(){const e=this.dataSchema;return!e||!e.columns?[]:e.columns.map(n=>n.name)}get columns(){const e=this.dataColumns;return this.selectMode==="multi"&&e.unshift(this.getMultiSelectColumnName()),this.dataSchema.expandableRow&&(this.rowExpanderPosition==="start"&&e.unshift(this.getRowExpanderColumnName()),this.rowExpanderPosition==="end"&&e.push(this.getRowExpanderColumnName())),e}get selected(){const e=this.selection.selected;return this.data.filter(n=>e.includes(this.trackRecord(n)))}set selected(e){this.deselectRedundant();const n=this.trackRecords(e);if(this.deselectExcluding(...n||[]),n){const a=this.trackRecordsAreInTable(n);this.selection.select(...a)}}get expanded(){const e=this.expansion.selected;return this.data.filter(n=>e.includes(this.trackRecord(n)))}set expanded(e){this.collapseRedundant();const n=this.trackRecords(e);if(this.collapseExcluding(...n||[]),n){const a=this.trackRecordsAreInTable(n);this.expansion.select(...a)}}set sort(e){e=e||{},this.sortColumn=e.columnName,this.sortDirection=e.direction}set matSort(e){this._matSort===e||!this._dataSource||!e||(this._matSort=e,this.dataSource.sort=e)}set data(e){e=e||[],this._dataSource||this.initDataSource(),this.dataSource.data=e}get data(){return this.dataSource&&this.dataSource.data||[]}set dataSource(e){this.initDataSource(e)}get dataSource(){return this._dataSource}get eventHandlers(){return this._eventHandlers}set eventHandlers(e){this._eventHandlers=e,this.markForCheck()}set config(e){e=e||{};const n=this._config;this._config=e,(0,c.default)(e,n)||this._applyConfig(e)}constructor(e){this.changeDetectorRef=e,this.selection=new d.SelectionModel(!0,[]),this.expansion=new d.SelectionModel(!0,[]),this.dataValueType=i.DataValueType,this.cellValueChange=new s.EventEmitter,this.enableOrdering=!1,this.rowExpanderPosition="end",this.selectedChange=new s.EventEmitter,this.sortChange=new s.EventEmitter,this.expandedChange=new s.EventEmitter,this.recordPositionChange=new s.EventEmitter,this.rowDoubleClick=new s.EventEmitter,this.getColumnSortingAccessor=(n,a)=>{const r=this.columnsDataSchema[a],m=n&&n[a];if(!r)return m;if(r.sortingDataAccessor)return r.sortingDataAccessor(n);if(r.valueType===i.DataValueType.Lookup){const x=m;return x&&x.displayValue}else return m},this.getMultiSelectColumnName=()=>"_multiSelectColumn",this.getRowExpanderColumnName=()=>"_rowExpanderColumn",this.trackByFunction=(n,a)=>this.trackRecord(a),this.config=Q}_applyConfig(e){G.forEach(n=>{const a=n,r=n,m=e[a],x=this[r];m!==void 0&&!(0,c.default)(m,x)&&(this[r]=e[a])})}trackRecord(e){return this._dataSchema?.trackBy?this._dataSchema.trackBy(e):e}trackRecords(e){return e?.map(n=>this.trackRecord(n))}isRecordInTable(e){return this.data.some(n=>this.trackRecord(n)===e)}deselectRedundant(){if(!this.dataSource)return null;const e=this.trackRecordsAreNotInTable(this.selection.selected);return e.length!==0&&this.selection.deselect(...e),e}collapseRedundant(){if(!this.dataSource)return null;const e=this.trackRecordsAreNotInTable(this.expansion.selected);return e.length!==0&&this.expansion.deselect(...e),e}deselectExcluding(...e){if(!this.data||!this.selection.hasValue())return;const a=this.trackRecordsExceptExcluded(e);this.selection.deselect(...a)}collapseExcluding(...e){const n=this.trackRecordsExceptExcluded(e);this.expansion.deselect(...n)}changeSelectionForRecords(e,n){e?this.selection.select(...n):this.selection.deselect(...n)}initDataSource(e){e=e||new _.MatTableDataSource,e.sortingDataAccessor=this.getColumnSortingAccessor,e.connect().subscribe(n=>{this.renderedDataTrackValues=this.trackRecords(n),this.deselectRedundant()?.length>0&&this.emitSelectionChange(),this.collapseRedundant()?.length>0&&this.emitExpandedChange(),this.markForCheck(),this.calculateMinWidth()}),this._dataSource=e}markForCheck(){this.changeDetectorRef.markForCheck()}emitSelectionChange(){this.selectedChange.emit(this.selected)}emitExpandedChange(){this.expandedChange.emit(this.expanded)}selectSingleRecord(e){this.deselectExcluding(e),this.selection.select(e),this.emitSelectionChange()}validateColumnEventHandlers(){const e=Object.keys(this.eventHandlers),n=this._dataSchema.expandableRow;let a=e.find(r=>!this.columnsDataSchema[r]);if(n&&a===n.name&&(a=null),a){const r=Object.keys(this.columnsDataSchema).join(", ");throw new Error(`Event handlers for column "${a}" can not be specified because the column was not defined in table data schema. Actual table columns: ${r}.`)}}changeSelectionForRange(e){if(!this.renderedDataTrackValues||!this.lastSelectToggledRecord||this.lastSelectToggledRecord===e)return!1;const n=this.renderedDataTrackValues.indexOf(this.lastSelectToggledRecord),a=this.renderedDataTrackValues.indexOf(e);if(n===-1||a===-1)return!1;const r=this.renderedDataTrackValues.slice(Math.min(n,a),Math.max(n,a)+1);return this.changeSelectionForRecords(!this.selection.isSelected(e),r),this.lastSelectToggledRecord=e,this.emitSelectionChange(),!0}trackRecordsAreInTable(e){return this.dataSource?e.filter(n=>this.isRecordInTable(n)):e}trackRecordsAreNotInTable(e){return this.dataSource?e.filter(n=>!this.isRecordInTable(n)):e}trackRecordsExceptExcluded(e){const n=this.trackRecords(this.data);return e?n.filter(a=>!e.includes(a)):n}calculateMinWidth(){const e=this.minWidthPerColumn,n=this.dataSchema?.columns?.length??0,a=!this.isEmpty()&&e>0&&n>0;this.minWidth=a?e*n+"px":""}getColumnSpanClass(e){return e>0&&e<=24?`ts-column-span-${e}`:""}allRecordsSelected(){return this.dataSource&&this.selection.hasValue()&&this.selection.selected.length>=this.filteredData.length&&this.filteredData.every(this.isRecordSelected.bind(this))}getAllRowsSelectState(){let e;return this.allRowsSelectState&&(e=this.allRowsSelectState())?e:this.allRecordsSelected()?u.TableAllRowsSelectState.All:this.isAnyRecordSelected()?u.TableAllRowsSelectState.Intermediate:u.TableAllRowsSelectState.None}ngOnChanges(){this.eventHandlers&&this.columnsDataSchema&&this.validateColumnEventHandlers(),this.calculateMinWidth()}isDataSchemaEmpty(){return!this.dataSchema||!this.dataSchema.columns||this.dataColumns.length===0}isEmpty(){return this.isDataSchemaEmpty()||!this.renderedDataTrackValues||this.renderedDataTrackValues.length===0}recordSelectToggle(e){const n=this.trackRecord(e);this.selection.toggle(n),this.lastSelectToggledRecord=n,this.emitSelectionChange()}onSortChange(e){const n={columnName:e.active,direction:e.direction};this.sort=n,this.sortChange.emit(n)}isAnyRecordSelected(){return this.selection.hasValue()}isRecordSelected(e){return this.selection.isSelected(this.trackRecord(e))}isRecordExpanded(e){return this.expansion.isSelected(this.trackRecord(e))}isAllRowsCheckboxChecked(){return this.getAllRowsSelectState()===u.TableAllRowsSelectState.All}isAllRowsCheckboxIntermediate(){return this.getAllRowsSelectState()===u.TableAllRowsSelectState.Intermediate}allRowsSelectToggle(){if(this.selectMode!=="multi")throw new RangeError("Multi-select mode should be enabled to select all records.");if(this.allRowsSelectToggleHandler)this.allRowsSelectToggleHandler();else{const e=!this.isAllRowsCheckboxChecked();this.changeSelectionForRecords(e,this.trackRecords(this.filteredData)),this.emitSelectionChange()}}onRowClick(e){this.selectMode==="single"&&this.selectSingleRecord(this.trackRecord(e))}onRowDoubleClick(e){this.rowDoubleClick.emit(e)}getValueTypeCssClass(e){return"ts-value-type-"+(e&&i.DataValueType[e].toString().toLowerCase())}getColumnHeaderCssClass(e,n){return[this.getValueTypeCssClass(e),this.getColumnSpanClass(n)].filter(a=>!!a)}getRowCssClass(e,n){const a=[];n&&a.push(this.evenRowCssClass),this.selectMode==="single"&&this.isRecordSelected(e)&&a.push(this.selectedRowCssClass);const r=typeof this.dataSchema.rowCssClass=="function"?this.dataSchema.rowCssClass(e):this.dataSchema.rowCssClass;return r&&a.push(r),a}isColumnSortable(e){return!e.caption||this.enableOrdering?!1:this.sortable?e.sortable!==!1:e.sortable===!0}onCheckboxClick(e,n){const a=this.trackRecord(e);(!n.shiftKey||!this.changeSelectionForRange(a))&&this.recordSelectToggle(e),n.stopPropagation()}toggleRowExpansion(e,n){if(n.stopPropagation(),!this.dataSchema.expandableRow)throw new Error("An expandable cell must be set for this operation");this.expansion.toggle(this.trackRecord(e)),this.emitExpandedChange()}onCellValueChange(e,n,a){this.data=this.data,this.cellValueChange.emit({record:e,columnDataSchema:n,value:a})}onItemDrop(e){const n=this.data.indexOf(e.item.data);(0,C.moveItemInArray)(this.data,n,e.currentIndex),this.data=this.data;const a={record:e.item.data,newIndex:e.currentIndex,prevIndex:n};this.recordPositionChange.emit(a)}static{this.\u0275fac=function(n){return new(n||R)(t.\u0275\u0275directiveInject(f.ChangeDetectorRef))}}static{this.\u0275cmp=t.\u0275\u0275defineComponent({type:R,selectors:[["ts-table"]],viewQuery:function(n,a){if(n&1&&t.\u0275\u0275viewQuery(b.MatSort,5),n&2){let r;t.\u0275\u0275queryRefresh(r=t.\u0275\u0275loadQuery())&&(a.matSort=r.first)}},hostVars:2,hostBindings:function(n,a){n&2&&t.\u0275\u0275styleProp("min-width",a.minWidth)},inputs:{dataSchema:"dataSchema",selectMode:"selectMode",headerSticky:"headerSticky",showHeader:"showHeader",showSelectAllButton:"showSelectAllButton",sortable:"sortable",sortColumn:"sortColumn",sortDirection:"sortDirection",selectedRowCssClass:"selectedRowCssClass",evenRowCssClass:"evenRowCssClass",minWidthPerColumn:"minWidthPerColumn",enableOrdering:"enableOrdering",dragBoundarySelector:"dragBoundarySelector",rowExpanderPosition:"rowExpanderPosition",selected:"selected",expanded:"expanded",sort:"sort",data:"data",dataSource:"dataSource",eventHandlers:"eventHandlers",config:"config",allRowsSelectState:"allRowsSelectState",allRowsSelectToggleHandler:"allRowsSelectToggleHandler"},outputs:{cellValueChange:"cellValueChange",selectedChange:"selectedChange",sortChange:"sortChange",expandedChange:"expandedChange",recordPositionChange:"recordPositionChange",rowDoubleClick:"rowDoubleClick"},standalone:!1,features:[t.\u0275\u0275NgOnChangesFeature],decls:1,vars:1,consts:[["mat-table","","matSort","","matSortDisableClear","","multiTemplateDataRows","","cdkDropList","",3,"display","dataSource","matSortDirection","matSortActive","cdkDropListDisabled","trackBy"],["mat-table","","matSort","","matSortDisableClear","","multiTemplateDataRows","","cdkDropList","",3,"matSortChange","cdkDropListDropped","dataSource","matSortDirection","matSortActive","cdkDropListDisabled","trackBy"],[3,"matColumnDef"],["mat-header-cell","",1,"multi-select-column"],["mat-cell","","class","multi-select-column",4,"matCellDef"],["mat-header-cell","",1,"row-expander-column"],["mat-cell","","class","row-expander-column",4,"matCellDef"],["matColumnDef","expandableRow"],["mat-cell","",3,"ngClass",4,"matCellDef"],["mat-header-row",""],["mat-row","","cdkDragLockAxis","y","cdkDrag","",3,"ngClass","cdkDragData","cdkDragBoundary","cdkDragDisabled","click","dblclick",4,"matRowDef","matRowDefColumns"],["mat-header-cell","","class","multi-select-column",4,"matHeaderCellDef"],[3,"change","checked","indeterminate"],["mat-cell","",1,"multi-select-column"],[3,"click","checked"],["mat-header-cell","","class","row-expander-column",4,"matHeaderCellDef"],["mat-cell","",1,"row-expander-column"],[1,"trigger-button",3,"click"],[3,"ngClass"],["mat-header-cell","","mat-sort-header","",3,"disabled","ngClass"],["mat-header-cell","","mat-sort-header","",3,"disabled","ngClass",4,"matHeaderCellDef"],["mat-cell","",3,"ngClass"],[3,"valueChange","columnDataSchema","record","eventHandlers"],[1,"expandable-row-wrapper"],[1,"expandable-row-content"],[3,"columnDataSchema","record","eventHandlers"],["mat-header-row","",4,"matHeaderRowDef","matHeaderRowDefSticky"],["mat-row","","cdkDragLockAxis","y","cdkDrag","",3,"click","dblclick","ngClass","cdkDragData","cdkDragBoundary","cdkDragDisabled"],["mat-row","","class","expandable-row",4,"matRowDef","matRowDefColumns"],["mat-row","",1,"expandable-row"]],template:function(n,a){n&1&&t.\u0275\u0275conditionalCreate(0,$,14,16,"table",0),n&2&&t.\u0275\u0275conditional(a.isDataSchemaEmpty()?-1:0)},dependencies:[p.NgClass,C.CdkDropList,C.CdkDrag,g.MatIcon,w.MatCheckbox,b.MatSort,b.MatSortHeader,_.MatTable,_.MatHeaderCellDef,_.MatHeaderRowDef,_.MatColumnDef,_.MatCellDef,_.MatRowDef,_.MatHeaderCell,_.MatCell,_.MatHeaderRow,_.MatRow,E.TableCellWrapperComponent],styles:[`ts-table {
  display: inline-block;
  width: 100%;
}
ts-table table {
  width: 100%;
}
ts-table table tr.expandable-row {
  height: auto;
}
ts-table table tr.expandable-row td.expandable-cell-collapsed {
  border-bottom: hidden;
}
ts-table table tr td,
ts-table table tr th {
  overflow: hidden;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column),
ts-table table tr th:not(.multi-select-column, .row-expander-column) {
  width: auto;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-1,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-1 {
  width: 4.1666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-2,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-2 {
  width: 8.3333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-3,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-3 {
  width: 12.5%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-4,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-4 {
  width: 16.6666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-5,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-5 {
  width: 20.8333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-6,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-6 {
  width: 25%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-7,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-7 {
  width: 29.1666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-8,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-8 {
  width: 33.3333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-9,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-9 {
  width: 37.5%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-10,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-10 {
  width: 41.6666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-11,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-11 {
  width: 45.8333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-12,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-12 {
  width: 50%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-13,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-13 {
  width: 54.1666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-14,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-14 {
  width: 58.3333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-15,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-15 {
  width: 62.5%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-16,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-16 {
  width: 66.6666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-17,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-17 {
  width: 70.8333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-18,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-18 {
  width: 75%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-19,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-19 {
  width: 79.1666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-20,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-20 {
  width: 83.3333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-21,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-21 {
  width: 87.5%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-22,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-22 {
  width: 91.6666666667%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-23,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-23 {
  width: 95.8333333333%;
}
ts-table table tr td:not(.multi-select-column, .row-expander-column).ts-column-span-24,
ts-table table tr th:not(.multi-select-column, .row-expander-column).ts-column-span-24 {
  width: 100%;
}
ts-table table tr td:not(:first-of-type),
ts-table table tr th:not(:first-of-type) {
  padding-left: 5px;
}
ts-table table tr td:not(:last-of-type),
ts-table table tr th:not(:last-of-type) {
  padding-right: 5px;
}
ts-table table tr td.multi-select-column,
ts-table table tr th.multi-select-column {
  padding-right: 10px;
  width: 16px !important;
  text-align: center;
  overflow: visible !important;
  /* eslint-disable-next-line creatio/mat-components */
}
ts-table table tr td.multi-select-column mat-checkbox .mdc-checkbox__ripple,
ts-table table tr th.multi-select-column mat-checkbox .mdc-checkbox__ripple {
  overflow: visible;
  position: absolute;
  left: calc(50% - 16px);
  top: calc(50% - 16px);
  height: 32px;
  width: 32px;
  /* eslint-disable-next-line creatio/mat-components */
}
ts-table table tr td.multi-select-column mat-checkbox .mdc-checkbox__ripple .mat-ripple-element:not(.mdc-checkbox__persistent-ripple),
ts-table table tr th.multi-select-column mat-checkbox .mdc-checkbox__ripple .mat-ripple-element:not(.mdc-checkbox__persistent-ripple) {
  display: none;
}
ts-table table tr td.row-expander-column .trigger-button,
ts-table table tr th.row-expander-column .trigger-button {
  background: none;
  border: none;
}
ts-table table tr td.row-expander-column .trigger-button:focus,
ts-table table tr th.row-expander-column .trigger-button:focus {
  background: none;
  border: none;
  outline: none;
}
ts-table table tr td.row-expander-column .trigger-button .row-expander-icon,
ts-table table tr th.row-expander-column .trigger-button .row-expander-icon {
  background-image: url("data:image/svg+xml,%3Csvg id='Component_447' data-name='Component 447' xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'%3E%3Cpath id='Path_1315' data-name='Path 1315' d='M7,13,0,6.5,7,0' transform='translate(14.549 4.25) rotate(90)' fill='none' stroke='%23006ce0' stroke-width='1.1'/%3E%3Crect id='Rectangle_6725' data-name='Rectangle 6725' width='16' height='16' fill='none'/%3E%3C/svg%3E%0A");
  background-position: center;
  opacity: 1;
  transition: transform 200ms ease, opacity 200ms ease;
}
ts-table table tr td.row-expander-column .trigger-button .row-expander-icon.expanded,
ts-table table tr th.row-expander-column .trigger-button .row-expander-icon.expanded {
  transform: rotate(0deg);
}
ts-table table tr td.row-expander-column .trigger-button .row-expander-icon.collapsed,
ts-table table tr th.row-expander-column .trigger-button .row-expander-icon.collapsed {
  transform: rotate(-180deg);
  opacity: 0.6;
}
ts-table table tr td .expandable-row-wrapper,
ts-table table tr th .expandable-row-wrapper {
  display: grid;
  grid-template-rows: 0fr;
  opacity: 0;
  transition: grid-template-rows 200ms ease, opacity 200ms ease;
}
ts-table table tr td .expandable-row-wrapper.expanded,
ts-table table tr th .expandable-row-wrapper.expanded {
  grid-template-rows: 1fr;
  opacity: 1;
}
ts-table table tr td .expandable-row-wrapper .expandable-row-content,
ts-table table tr th .expandable-row-wrapper .expandable-row-content {
  min-height: 0;
  overflow: hidden;
}
ts-table table tr td .expandable-row-wrapper ts-table-cell-wrapper,
ts-table table tr th .expandable-row-wrapper ts-table-cell-wrapper {
  display: block;
  width: 100%;
  margin: 10px 0;
}
ts-table table tr th.ts-value-type-boolean {
  /* eslint-disable-next-line creatio/mat-components */
}
ts-table table tr th.ts-value-type-boolean .mat-sort-header-container {
  justify-content: center;
  padding-left: 21px;
}
ts-table table tr td.ts-value-type-boolean {
  text-align: center;
}`],encapsulation:2,changeDetection:0})}}},49377(D,h,l){l.r(h),l.d(h,{TreeTableComponent:()=>b});var d=l(56622),C=l(33227);const s=["angularTreeGrid"];class b{constructor(){this._config={id_field:"id",parent_id_field:"parent",parent_display_field:"name",data_loading_text:"",row_class_function:null,css:{expand_class:"right-arrow",collapse_class:"down-arrow"},columns:[]},this._notImplementedContracts=["sortable","valueType","linkGenerator","sortingDataAccessor"],this.data=[]}set primaryColumn(i){this._config.id_field=i}set parentColumn(i){this._config.parent_id_field=i}set primaryDisplayColumn(i){this._config.parent_display_field=i}get config(){return this._config}_validateTreeTableColumnContract(i){const u=Object.getOwnPropertyNames(i);this._notImplementedContracts.forEach(c=>{if(u.indexOf(c)!==-1)throw new Error(`Contract "${c}" in TreeTableColumnDataSchema not implemented.`)})}_rowLevelClassGenerator(i){return i.leaf?"leaf-level":"root-level"}_setColumnsConfig(i){const u=i.map(c=>(this._validateTreeTableColumnContract(c),{name:c.name,header:c.caption,css_class:"tree-table-column-"+c.name,renderer:c.formatter}));this._config.columns=u}_setRowCssClassGenerator(i){if(!this.dataSchema?.rowCssClass){this._config.row_class_function=this._rowLevelClassGenerator;return}const u=typeof this.dataSchema?.rowCssClass=="function"?this.dataSchema.rowCssClass:c=>this.dataSchema.rowCssClass;this._config.row_class_function=c=>[this._rowLevelClassGenerator(c),u(c)].join(" ")}get dataSchema(){return this._dataSchema}set dataSchema(i){this._dataSchema=i,i&&this._setColumnsConfig(i.columns),this._setRowCssClassGenerator(i)}collapseAll(){this.angularTreeGrid.collapseAll()}expandAll(){this.angularTreeGrid.expandAll()}static{this.\u0275fac=function(u){return new(u||b)}}static{this.\u0275cmp=d.\u0275\u0275defineComponent({type:b,selectors:[["ts-tree-table"]],viewQuery:function(u,c){if(u&1&&d.\u0275\u0275viewQuery(s,5),u&2){let f;d.\u0275\u0275queryRefresh(f=d.\u0275\u0275loadQuery())&&(c.angularTreeGrid=f.first)}},inputs:{primaryColumn:"primaryColumn",parentColumn:"parentColumn",primaryDisplayColumn:"primaryDisplayColumn",data:"data",dataSchema:"dataSchema"},standalone:!1,decls:2,vars:2,consts:[["angularTreeGrid",""],[1,"tree-table",3,"data","configs"]],template:function(u,c){u&1&&d.\u0275\u0275element(0,"db-angular-tree-grid",1,0),u&2&&d.\u0275\u0275property("data",c.data)("configs",c.config)},dependencies:[C.AngularTreeGridComponent],styles:[`ts-tree-table .tree-table table.db-tree-view {
  border: 0;
  width: 100%;
}
ts-tree-table .tree-table .db-tree-view thead tr th,
ts-tree-table .tree-table .db-tree-view tbody tr td {
  border-left-width: 0;
  border-right-width: 0;
  border-top-width: 0;
}
ts-tree-table .tree-table .db-tree-view thead tr th {
  font: 400 13px/17px "Bpmonline Open Sans", Regular, sans-serif;
  color: #999999;
  font-size: 13px;
  text-align: left;
}
ts-tree-table .tree-table .db-tree-view tbody tr {
  line-height: normal;
}
ts-tree-table .tree-table .db-tree-view tbody tr td {
  font: 400 14px/19px "Bpmonline Open Sans", Regular, sans-serif;
  font-size: 14px;
  color: rgba(0, 0, 0, 0.87);
}
ts-tree-table .tree-table .db-tree-view .root-level td:first-child {
  padding-left: 10px;
}
ts-tree-table .tree-table .db-tree-view .leaf-level {
  background: #fcfcfc 0% 0% no-repeat padding-box;
}
ts-tree-table .tree-table .db-tree-view .leaf-level td:first-child {
  padding-left: 25px;
}
ts-tree-table .tree-table .right-arrow::before {
  color: #006ce0;
  border-style: solid;
  border-width: 1px 1px 0 0;
  content: "";
  display: inline-block;
  padding: 3px;
  transform: rotate(45deg);
  vertical-align: middle;
  margin-bottom: 6px;
}
ts-tree-table .tree-table .down-arrow::before {
  color: #006ce0;
  border-style: solid;
  border-width: 0 1px 1px 0;
  content: "";
  display: inline-block;
  padding: 3px;
  transform: rotate(45deg);
  vertical-align: middle;
  margin-bottom: 6px;
}`],encapsulation:2})}}},86650(D,h,l){l.r(h),l.d(h,{TableModule:()=>T});var d=l(66900),C=l(2002),s=l(72221),b=l(26182),_=l(63422),i=l(22029),u=l(68403),c=l(50502),f=l(86731),t=l(87014),p=l(33227),g=l(9505),w=l(84733),E=l(49377),S=l(56622),v=l(19965);class T{static{this.\u0275fac=function(M){return new(M||T)}}static{this.\u0275mod=S.\u0275\u0275defineNgModule({type:T})}static{this.\u0275inj=v.\u0275\u0275defineInjector({imports:[p.AngularTreeGridModule,C.CommonModule,d.DragDropModule,s.MatButtonModule,b.MatIconModule,_.MatCheckboxModule,i.MatSortModule,u.MatTableModule,c.RouterModule,f.TranslateModule,t.TableCdkModule,t.TableCdkModule]})}}(function(){(typeof ngJitMode>"u"||ngJitMode)&&S.\u0275\u0275setNgModuleScope(T,{declarations:[w.TableCellWrapperComponent,g.TableComponent,E.TreeTableComponent],imports:[p.AngularTreeGridModule,C.CommonModule,d.DragDropModule,s.MatButtonModule,b.MatIconModule,_.MatCheckboxModule,i.MatSortModule,u.MatTableModule,c.RouterModule,f.TranslateModule,t.TableCdkModule],exports:[w.TableCellWrapperComponent,g.TableComponent,E.TreeTableComponent,t.TableCdkModule]})})()}}]);
