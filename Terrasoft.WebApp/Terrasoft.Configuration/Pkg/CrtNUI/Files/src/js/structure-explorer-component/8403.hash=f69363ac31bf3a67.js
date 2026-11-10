(self.webpackChunkapp_studio_enterprise_structure_explorer=self.webpackChunkapp_studio_enterprise_structure_explorer||[]).push([[8403],{68403(J,P,u){u.r(P),u.d(P,{MatCell:()=>g,MatCellDef:()=>c,MatColumnDef:()=>f,MatFooterCell:()=>_,MatFooterCellDef:()=>h,MatFooterRow:()=>D,MatFooterRowDef:()=>y,MatHeaderCell:()=>p,MatHeaderCellDef:()=>m,MatHeaderRow:()=>v,MatHeaderRowDef:()=>b,MatNoDataRow:()=>C,MatRecycleRows:()=>k,MatRow:()=>x,MatRowDef:()=>w,MatTable:()=>d,MatTableDataSource:()=>Y,MatTableModule:()=>R,MatTextColumn:()=>F});var e=u(39638),n=u(26157),s=u(88632),H=u(41407),j=u(73971),I=u(24884),A=u(90459);const L=[[["caption"]],[["colgroup"],["col"]],"*"],K=["caption","colgroup, col","*"];function V(l,t){l&1&&e.\u0275\u0275projection(0,2)}function W(l,t){l&1&&(e.\u0275\u0275elementStart(0,"thead",0),e.\u0275\u0275elementContainer(1,1),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(2,"tbody",2),e.\u0275\u0275elementContainer(3,3)(4,4),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(5,"tfoot",0),e.\u0275\u0275elementContainer(6,5),e.\u0275\u0275elementEnd())}function U(l,t){l&1&&e.\u0275\u0275elementContainer(0,1)(1,3)(2,4)(3,5)}function G(l,t){if(l&1&&(e.\u0275\u0275elementStart(0,"th",3),e.\u0275\u0275text(1),e.\u0275\u0275elementEnd()),l&2){const a=e.\u0275\u0275nextContext();e.\u0275\u0275styleProp("text-align",a.justify),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate1(" ",a.headerText," ")}}function $(l,t){if(l&1&&(e.\u0275\u0275elementStart(0,"td",4),e.\u0275\u0275text(1),e.\u0275\u0275elementEnd()),l&2){const a=t.$implicit,o=e.\u0275\u0275nextContext();e.\u0275\u0275styleProp("text-align",o.justify),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate1(" ",o.dataAccessor(a,o.name)," ")}}class k{static \u0275fac=function(a){return new(a||k)};static \u0275dir=e.\u0275\u0275defineDirective({type:k,selectors:[["mat-table","recycleRows",""],["table","mat-table","","recycleRows",""]]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(k,[{type:e.Directive,args:[{selector:"mat-table[recycleRows], table[mat-table][recycleRows]"}]}],null,null);class d extends n.CdkTable{stickyCssClass="mat-mdc-table-sticky";needsPositionStickyOnElement=!1;static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(d)))(o||d)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:d,selectors:[["mat-table"],["table","mat-table",""]],hostAttrs:[1,"mat-mdc-table","mdc-data-table__table"],hostVars:2,hostBindings:function(a,o){a&2&&e.\u0275\u0275classProp("mat-table-fixed-layout",o.fixedLayout)},exportAs:["matTable"],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkTable,useExisting:d},{provide:n.CDK_TABLE,useExisting:d},{provide:n.STICKY_POSITIONING_LISTENER,useValue:null}]),e.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:K,decls:5,vars:2,consts:[["role","rowgroup"],["headerRowOutlet",""],["role","rowgroup",1,"mdc-data-table__content"],["rowOutlet",""],["noDataRowOutlet",""],["footerRowOutlet",""]],template:function(a,o){a&1&&(e.\u0275\u0275projectionDef(L),e.\u0275\u0275projection(0),e.\u0275\u0275projection(1,1),e.\u0275\u0275conditionalCreate(2,V,1,0),e.\u0275\u0275conditionalCreate(3,W,7,0)(4,U,4,0)),a&2&&(e.\u0275\u0275advance(2),e.\u0275\u0275conditional(o._isServer?2:-1),e.\u0275\u0275advance(),e.\u0275\u0275conditional(o._isNativeHtmlTable?3:4))},dependencies:[n.HeaderRowOutlet,n.DataRowOutlet,n.NoDataRowOutlet,n.FooterRowOutlet],styles:[`.mat-mdc-table-sticky {
  position: sticky !important;
}

mat-table {
  display: block;
}

mat-header-row {
  min-height: var(--mat-table-header-container-height, 56px);
}

mat-row {
  min-height: var(--mat-table-row-item-container-height, 52px);
}

mat-footer-row {
  min-height: var(--mat-table-footer-container-height, 52px);
}

mat-row, mat-header-row, mat-footer-row {
  display: flex;
  border-width: 0;
  border-bottom-width: 1px;
  border-style: solid;
  align-items: center;
  box-sizing: border-box;
}

mat-cell:first-of-type, mat-header-cell:first-of-type, mat-footer-cell:first-of-type {
  padding-left: 24px;
}
[dir=rtl] mat-cell:first-of-type:not(:only-of-type), [dir=rtl] mat-header-cell:first-of-type:not(:only-of-type), [dir=rtl] mat-footer-cell:first-of-type:not(:only-of-type) {
  padding-left: 0;
  padding-right: 24px;
}
mat-cell:last-of-type, mat-header-cell:last-of-type, mat-footer-cell:last-of-type {
  padding-right: 24px;
}
[dir=rtl] mat-cell:last-of-type:not(:only-of-type), [dir=rtl] mat-header-cell:last-of-type:not(:only-of-type), [dir=rtl] mat-footer-cell:last-of-type:not(:only-of-type) {
  padding-right: 0;
  padding-left: 24px;
}

mat-cell, mat-header-cell, mat-footer-cell {
  flex: 1;
  display: flex;
  align-items: center;
  overflow: hidden;
  word-wrap: break-word;
  min-height: inherit;
}

.mat-mdc-table {
  min-width: 100%;
  border: 0;
  border-spacing: 0;
  table-layout: auto;
  white-space: normal;
  background-color: var(--mat-table-background-color, var(--mat-sys-surface));
}

.mat-table-fixed-layout {
  table-layout: fixed;
}

.mdc-data-table__cell {
  box-sizing: border-box;
  overflow: hidden;
  text-align: start;
  text-overflow: ellipsis;
}

.mdc-data-table__cell,
.mdc-data-table__header-cell {
  padding: 0 16px;
}

.mat-mdc-header-row {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  height: var(--mat-table-header-container-height, 56px);
  color: var(--mat-table-header-headline-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
  font-family: var(--mat-table-header-headline-font, var(--mat-sys-title-small-font, Roboto, sans-serif));
  line-height: var(--mat-table-header-headline-line-height, var(--mat-sys-title-small-line-height));
  font-size: var(--mat-table-header-headline-size, var(--mat-sys-title-small-size, 14px));
  font-weight: var(--mat-table-header-headline-weight, var(--mat-sys-title-small-weight, 500));
}

.mat-mdc-row {
  height: var(--mat-table-row-item-container-height, 52px);
  color: var(--mat-table-row-item-label-text-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
}

.mat-mdc-row,
.mdc-data-table__content {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  font-family: var(--mat-table-row-item-label-text-font, var(--mat-sys-body-medium-font, Roboto, sans-serif));
  line-height: var(--mat-table-row-item-label-text-line-height, var(--mat-sys-body-medium-line-height));
  font-size: var(--mat-table-row-item-label-text-size, var(--mat-sys-body-medium-size, 14px));
  font-weight: var(--mat-table-row-item-label-text-weight, var(--mat-sys-body-medium-weight));
}

.mat-mdc-footer-row {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  height: var(--mat-table-footer-container-height, 52px);
  color: var(--mat-table-row-item-label-text-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
  font-family: var(--mat-table-footer-supporting-text-font, var(--mat-sys-body-medium-font, Roboto, sans-serif));
  line-height: var(--mat-table-footer-supporting-text-line-height, var(--mat-sys-body-medium-line-height));
  font-size: var(--mat-table-footer-supporting-text-size, var(--mat-sys-body-medium-size, 14px));
  font-weight: var(--mat-table-footer-supporting-text-weight, var(--mat-sys-body-medium-weight));
  letter-spacing: var(--mat-table-footer-supporting-text-tracking, var(--mat-sys-body-medium-tracking));
}

.mat-mdc-header-cell {
  border-bottom-color: var(--mat-table-row-item-outline-color, var(--mat-sys-outline, rgba(0, 0, 0, 0.12)));
  border-bottom-width: var(--mat-table-row-item-outline-width, 1px);
  border-bottom-style: solid;
  letter-spacing: var(--mat-table-header-headline-tracking, var(--mat-sys-title-small-tracking));
  font-weight: inherit;
  line-height: inherit;
  box-sizing: border-box;
  text-overflow: ellipsis;
  overflow: hidden;
  outline: none;
  text-align: start;
}
.mdc-data-table__row:last-child > .mat-mdc-header-cell {
  border-bottom: none;
}

.mat-mdc-cell {
  border-bottom-color: var(--mat-table-row-item-outline-color, var(--mat-sys-outline, rgba(0, 0, 0, 0.12)));
  border-bottom-width: var(--mat-table-row-item-outline-width, 1px);
  border-bottom-style: solid;
  letter-spacing: var(--mat-table-row-item-label-text-tracking, var(--mat-sys-body-medium-tracking));
  line-height: inherit;
}
.mdc-data-table__row:last-child > .mat-mdc-cell {
  border-bottom: none;
}

.mat-mdc-footer-cell {
  letter-spacing: var(--mat-table-row-item-label-text-tracking, var(--mat-sys-body-medium-tracking));
}

mat-row.mat-mdc-row,
mat-header-row.mat-mdc-header-row,
mat-footer-row.mat-mdc-footer-row {
  border-bottom: none;
}

.mat-mdc-table tbody,
.mat-mdc-table tfoot,
.mat-mdc-table thead,
.mat-mdc-cell,
.mat-mdc-footer-cell,
.mat-mdc-header-row,
.mat-mdc-row,
.mat-mdc-footer-row,
.mat-mdc-table .mat-mdc-header-cell {
  background: inherit;
}

.mat-mdc-table mat-header-row.mat-mdc-header-row,
.mat-mdc-table mat-row.mat-mdc-row,
.mat-mdc-table mat-footer-row.mat-mdc-footer-cell {
  height: unset;
}

mat-header-cell.mat-mdc-header-cell,
mat-cell.mat-mdc-cell,
mat-footer-cell.mat-mdc-footer-cell {
  align-self: stretch;
}
`],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(d,[{type:e.Component,args:[{selector:"mat-table, table[mat-table]",exportAs:"matTable",template:`
    <ng-content select="caption"/>
    <ng-content select="colgroup, col"/>

    <!--
      Unprojected content throws a hydration error so we need this to capture it.
      It gets removed on the client so it doesn't affect the layout.
    -->
    @if (_isServer) {
      <ng-content/>
    }

    @if (_isNativeHtmlTable) {
      <thead role="rowgroup">
        <ng-container headerRowOutlet/>
      </thead>
      <tbody class="mdc-data-table__content" role="rowgroup">
        <ng-container rowOutlet/>
        <ng-container noDataRowOutlet/>
      </tbody>
      <tfoot role="rowgroup">
        <ng-container footerRowOutlet/>
      </tfoot>
    } @else {
      <ng-container headerRowOutlet/>
      <ng-container rowOutlet/>
      <ng-container noDataRowOutlet/>
      <ng-container footerRowOutlet/>
    }
  `,host:{class:"mat-mdc-table mdc-data-table__table","[class.mat-table-fixed-layout]":"fixedLayout"},providers:[{provide:n.CdkTable,useExisting:d},{provide:n.CDK_TABLE,useExisting:d},{provide:n.STICKY_POSITIONING_LISTENER,useValue:null}],encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.Default,imports:[n.HeaderRowOutlet,n.DataRowOutlet,n.NoDataRowOutlet,n.FooterRowOutlet],styles:[`.mat-mdc-table-sticky {
  position: sticky !important;
}

mat-table {
  display: block;
}

mat-header-row {
  min-height: var(--mat-table-header-container-height, 56px);
}

mat-row {
  min-height: var(--mat-table-row-item-container-height, 52px);
}

mat-footer-row {
  min-height: var(--mat-table-footer-container-height, 52px);
}

mat-row, mat-header-row, mat-footer-row {
  display: flex;
  border-width: 0;
  border-bottom-width: 1px;
  border-style: solid;
  align-items: center;
  box-sizing: border-box;
}

mat-cell:first-of-type, mat-header-cell:first-of-type, mat-footer-cell:first-of-type {
  padding-left: 24px;
}
[dir=rtl] mat-cell:first-of-type:not(:only-of-type), [dir=rtl] mat-header-cell:first-of-type:not(:only-of-type), [dir=rtl] mat-footer-cell:first-of-type:not(:only-of-type) {
  padding-left: 0;
  padding-right: 24px;
}
mat-cell:last-of-type, mat-header-cell:last-of-type, mat-footer-cell:last-of-type {
  padding-right: 24px;
}
[dir=rtl] mat-cell:last-of-type:not(:only-of-type), [dir=rtl] mat-header-cell:last-of-type:not(:only-of-type), [dir=rtl] mat-footer-cell:last-of-type:not(:only-of-type) {
  padding-right: 0;
  padding-left: 24px;
}

mat-cell, mat-header-cell, mat-footer-cell {
  flex: 1;
  display: flex;
  align-items: center;
  overflow: hidden;
  word-wrap: break-word;
  min-height: inherit;
}

.mat-mdc-table {
  min-width: 100%;
  border: 0;
  border-spacing: 0;
  table-layout: auto;
  white-space: normal;
  background-color: var(--mat-table-background-color, var(--mat-sys-surface));
}

.mat-table-fixed-layout {
  table-layout: fixed;
}

.mdc-data-table__cell {
  box-sizing: border-box;
  overflow: hidden;
  text-align: start;
  text-overflow: ellipsis;
}

.mdc-data-table__cell,
.mdc-data-table__header-cell {
  padding: 0 16px;
}

.mat-mdc-header-row {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  height: var(--mat-table-header-container-height, 56px);
  color: var(--mat-table-header-headline-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
  font-family: var(--mat-table-header-headline-font, var(--mat-sys-title-small-font, Roboto, sans-serif));
  line-height: var(--mat-table-header-headline-line-height, var(--mat-sys-title-small-line-height));
  font-size: var(--mat-table-header-headline-size, var(--mat-sys-title-small-size, 14px));
  font-weight: var(--mat-table-header-headline-weight, var(--mat-sys-title-small-weight, 500));
}

.mat-mdc-row {
  height: var(--mat-table-row-item-container-height, 52px);
  color: var(--mat-table-row-item-label-text-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
}

.mat-mdc-row,
.mdc-data-table__content {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  font-family: var(--mat-table-row-item-label-text-font, var(--mat-sys-body-medium-font, Roboto, sans-serif));
  line-height: var(--mat-table-row-item-label-text-line-height, var(--mat-sys-body-medium-line-height));
  font-size: var(--mat-table-row-item-label-text-size, var(--mat-sys-body-medium-size, 14px));
  font-weight: var(--mat-table-row-item-label-text-weight, var(--mat-sys-body-medium-weight));
}

.mat-mdc-footer-row {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  height: var(--mat-table-footer-container-height, 52px);
  color: var(--mat-table-row-item-label-text-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
  font-family: var(--mat-table-footer-supporting-text-font, var(--mat-sys-body-medium-font, Roboto, sans-serif));
  line-height: var(--mat-table-footer-supporting-text-line-height, var(--mat-sys-body-medium-line-height));
  font-size: var(--mat-table-footer-supporting-text-size, var(--mat-sys-body-medium-size, 14px));
  font-weight: var(--mat-table-footer-supporting-text-weight, var(--mat-sys-body-medium-weight));
  letter-spacing: var(--mat-table-footer-supporting-text-tracking, var(--mat-sys-body-medium-tracking));
}

.mat-mdc-header-cell {
  border-bottom-color: var(--mat-table-row-item-outline-color, var(--mat-sys-outline, rgba(0, 0, 0, 0.12)));
  border-bottom-width: var(--mat-table-row-item-outline-width, 1px);
  border-bottom-style: solid;
  letter-spacing: var(--mat-table-header-headline-tracking, var(--mat-sys-title-small-tracking));
  font-weight: inherit;
  line-height: inherit;
  box-sizing: border-box;
  text-overflow: ellipsis;
  overflow: hidden;
  outline: none;
  text-align: start;
}
.mdc-data-table__row:last-child > .mat-mdc-header-cell {
  border-bottom: none;
}

.mat-mdc-cell {
  border-bottom-color: var(--mat-table-row-item-outline-color, var(--mat-sys-outline, rgba(0, 0, 0, 0.12)));
  border-bottom-width: var(--mat-table-row-item-outline-width, 1px);
  border-bottom-style: solid;
  letter-spacing: var(--mat-table-row-item-label-text-tracking, var(--mat-sys-body-medium-tracking));
  line-height: inherit;
}
.mdc-data-table__row:last-child > .mat-mdc-cell {
  border-bottom: none;
}

.mat-mdc-footer-cell {
  letter-spacing: var(--mat-table-row-item-label-text-tracking, var(--mat-sys-body-medium-tracking));
}

mat-row.mat-mdc-row,
mat-header-row.mat-mdc-header-row,
mat-footer-row.mat-mdc-footer-row {
  border-bottom: none;
}

.mat-mdc-table tbody,
.mat-mdc-table tfoot,
.mat-mdc-table thead,
.mat-mdc-cell,
.mat-mdc-footer-cell,
.mat-mdc-header-row,
.mat-mdc-row,
.mat-mdc-footer-row,
.mat-mdc-table .mat-mdc-header-cell {
  background: inherit;
}

.mat-mdc-table mat-header-row.mat-mdc-header-row,
.mat-mdc-table mat-row.mat-mdc-row,
.mat-mdc-table mat-footer-row.mat-mdc-footer-cell {
  height: unset;
}

mat-header-cell.mat-mdc-header-cell,
mat-cell.mat-mdc-cell,
mat-footer-cell.mat-mdc-footer-cell {
  align-self: stretch;
}
`]}]}],null,null);class c extends n.CdkCellDef{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(c)))(o||c)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:c,selectors:[["","matCellDef",""]],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkCellDef,useExisting:c}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(c,[{type:e.Directive,args:[{selector:"[matCellDef]",providers:[{provide:n.CdkCellDef,useExisting:c}]}]}],null,null);class m extends n.CdkHeaderCellDef{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(m)))(o||m)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:m,selectors:[["","matHeaderCellDef",""]],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkHeaderCellDef,useExisting:m}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(m,[{type:e.Directive,args:[{selector:"[matHeaderCellDef]",providers:[{provide:n.CdkHeaderCellDef,useExisting:m}]}]}],null,null);class h extends n.CdkFooterCellDef{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(h)))(o||h)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:h,selectors:[["","matFooterCellDef",""]],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkFooterCellDef,useExisting:h}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(h,[{type:e.Directive,args:[{selector:"[matFooterCellDef]",providers:[{provide:n.CdkFooterCellDef,useExisting:h}]}]}],null,null);class f extends n.CdkColumnDef{get name(){return this._name}set name(t){this._setNameInput(t)}_updateColumnCssClassName(){super._updateColumnCssClassName(),this._columnCssClassName.push(`mat-column-${this.cssClassFriendlyName}`)}static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(f)))(o||f)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:f,selectors:[["","matColumnDef",""]],inputs:{name:[0,"matColumnDef","name"]},features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkColumnDef,useExisting:f}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(f,[{type:e.Directive,args:[{selector:"[matColumnDef]",providers:[{provide:n.CdkColumnDef,useExisting:f}]}]}],null,{name:[{type:e.Input,args:["matColumnDef"]}]});class p extends n.CdkHeaderCell{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(p)))(o||p)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:p,selectors:[["mat-header-cell"],["th","mat-header-cell",""]],hostAttrs:["role","columnheader",1,"mat-mdc-header-cell","mdc-data-table__header-cell"],features:[e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(p,[{type:e.Directive,args:[{selector:"mat-header-cell, th[mat-header-cell]",host:{class:"mat-mdc-header-cell mdc-data-table__header-cell",role:"columnheader"}}]}],null,null);class _ extends n.CdkFooterCell{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(_)))(o||_)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:_,selectors:[["mat-footer-cell"],["td","mat-footer-cell",""]],hostAttrs:[1,"mat-mdc-footer-cell","mdc-data-table__cell"],features:[e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(_,[{type:e.Directive,args:[{selector:"mat-footer-cell, td[mat-footer-cell]",host:{class:"mat-mdc-footer-cell mdc-data-table__cell"}}]}],null,null);class g extends n.CdkCell{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(g)))(o||g)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:g,selectors:[["mat-cell"],["td","mat-cell",""]],hostAttrs:[1,"mat-mdc-cell","mdc-data-table__cell"],features:[e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(g,[{type:e.Directive,args:[{selector:"mat-cell, td[mat-cell]",host:{class:"mat-mdc-cell mdc-data-table__cell"}}]}],null,null);const T="<ng-container cdkCellOutlet></ng-container>";class b extends n.CdkHeaderRowDef{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(b)))(o||b)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:b,selectors:[["","matHeaderRowDef",""]],inputs:{columns:[0,"matHeaderRowDef","columns"],sticky:[2,"matHeaderRowDefSticky","sticky",e.booleanAttribute]},features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkHeaderRowDef,useExisting:b}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(b,[{type:e.Directive,args:[{selector:"[matHeaderRowDef]",providers:[{provide:n.CdkHeaderRowDef,useExisting:b}],inputs:[{name:"columns",alias:"matHeaderRowDef"},{name:"sticky",alias:"matHeaderRowDefSticky",transform:e.booleanAttribute}]}]}],null,null);class y extends n.CdkFooterRowDef{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(y)))(o||y)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:y,selectors:[["","matFooterRowDef",""]],inputs:{columns:[0,"matFooterRowDef","columns"],sticky:[2,"matFooterRowDefSticky","sticky",e.booleanAttribute]},features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkFooterRowDef,useExisting:y}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(y,[{type:e.Directive,args:[{selector:"[matFooterRowDef]",providers:[{provide:n.CdkFooterRowDef,useExisting:y}],inputs:[{name:"columns",alias:"matFooterRowDef"},{name:"sticky",alias:"matFooterRowDefSticky",transform:e.booleanAttribute}]}]}],null,null);class w extends n.CdkRowDef{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(w)))(o||w)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:w,selectors:[["","matRowDef",""]],inputs:{columns:[0,"matRowDefColumns","columns"],when:[0,"matRowDefWhen","when"]},features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkRowDef,useExisting:w}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(w,[{type:e.Directive,args:[{selector:"[matRowDef]",providers:[{provide:n.CdkRowDef,useExisting:w}],inputs:[{name:"columns",alias:"matRowDefColumns"},{name:"when",alias:"matRowDefWhen"}]}]}],null,null);class v extends n.CdkHeaderRow{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(v)))(o||v)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:v,selectors:[["mat-header-row"],["tr","mat-header-row",""]],hostAttrs:["role","row",1,"mat-mdc-header-row","mdc-data-table__header-row"],exportAs:["matHeaderRow"],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkHeaderRow,useExisting:v}]),e.\u0275\u0275InheritDefinitionFeature],decls:1,vars:0,consts:[["cdkCellOutlet",""]],template:function(a,o){a&1&&e.\u0275\u0275elementContainer(0,0)},dependencies:[n.CdkCellOutlet],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(v,[{type:e.Component,args:[{selector:"mat-header-row, tr[mat-header-row]",template:T,host:{class:"mat-mdc-header-row mdc-data-table__header-row",role:"row"},changeDetection:e.ChangeDetectionStrategy.Default,encapsulation:e.ViewEncapsulation.None,exportAs:"matHeaderRow",providers:[{provide:n.CdkHeaderRow,useExisting:v}],imports:[n.CdkCellOutlet]}]}],null,null);class D extends n.CdkFooterRow{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(D)))(o||D)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:D,selectors:[["mat-footer-row"],["tr","mat-footer-row",""]],hostAttrs:["role","row",1,"mat-mdc-footer-row","mdc-data-table__row"],exportAs:["matFooterRow"],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkFooterRow,useExisting:D}]),e.\u0275\u0275InheritDefinitionFeature],decls:1,vars:0,consts:[["cdkCellOutlet",""]],template:function(a,o){a&1&&e.\u0275\u0275elementContainer(0,0)},dependencies:[n.CdkCellOutlet],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(D,[{type:e.Component,args:[{selector:"mat-footer-row, tr[mat-footer-row]",template:T,host:{class:"mat-mdc-footer-row mdc-data-table__row",role:"row"},changeDetection:e.ChangeDetectionStrategy.Default,encapsulation:e.ViewEncapsulation.None,exportAs:"matFooterRow",providers:[{provide:n.CdkFooterRow,useExisting:D}],imports:[n.CdkCellOutlet]}]}],null,null);class x extends n.CdkRow{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(x)))(o||x)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:x,selectors:[["mat-row"],["tr","mat-row",""]],hostAttrs:["role","row",1,"mat-mdc-row","mdc-data-table__row"],exportAs:["matRow"],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkRow,useExisting:x}]),e.\u0275\u0275InheritDefinitionFeature],decls:1,vars:0,consts:[["cdkCellOutlet",""]],template:function(a,o){a&1&&e.\u0275\u0275elementContainer(0,0)},dependencies:[n.CdkCellOutlet],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(x,[{type:e.Component,args:[{selector:"mat-row, tr[mat-row]",template:T,host:{class:"mat-mdc-row mdc-data-table__row",role:"row"},changeDetection:e.ChangeDetectionStrategy.Default,encapsulation:e.ViewEncapsulation.None,exportAs:"matRow",providers:[{provide:n.CdkRow,useExisting:x}],imports:[n.CdkCellOutlet]}]}],null,null);class C extends n.CdkNoDataRow{_cellSelector="td, mat-cell, [mat-cell], .mat-cell";constructor(){super(),this._contentClassNames.push("mat-mdc-no-data-row","mat-mdc-row","mdc-data-table__row"),this._cellClassNames.push("mat-mdc-cell","mdc-data-table__cell","mat-no-data-cell")}static \u0275fac=function(a){return new(a||C)};static \u0275dir=e.\u0275\u0275defineDirective({type:C,selectors:[["ng-template","matNoDataRow",""]],features:[e.\u0275\u0275ProvidersFeature([{provide:n.CdkNoDataRow,useExisting:C}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(C,[{type:e.Directive,args:[{selector:"ng-template[matNoDataRow]",providers:[{provide:n.CdkNoDataRow,useExisting:C}]}]}],()=>[],null);class F extends n.CdkTextColumn{static \u0275fac=(()=>{let t;return function(o){return(t||(t=e.\u0275\u0275getInheritedFactory(F)))(o||F)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:F,selectors:[["mat-text-column"]],features:[e.\u0275\u0275InheritDefinitionFeature],decls:3,vars:0,consts:[["matColumnDef",""],["mat-header-cell","",3,"text-align",4,"matHeaderCellDef"],["mat-cell","",3,"text-align",4,"matCellDef"],["mat-header-cell",""],["mat-cell",""]],template:function(a,o){a&1&&(e.\u0275\u0275elementContainerStart(0,0),e.\u0275\u0275template(1,G,2,3,"th",1)(2,$,2,3,"td",2),e.\u0275\u0275elementContainerEnd())},dependencies:[f,m,p,c,g],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(F,[{type:e.Component,args:[{selector:"mat-text-column",template:`
    <ng-container matColumnDef>
      <th mat-header-cell *matHeaderCellDef [style.text-align]="justify">
        {{headerText}}
      </th>
      <td mat-cell *matCellDef="let data" [style.text-align]="justify">
        {{dataAccessor(data, name)}}
      </td>
    </ng-container>
  `,encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.Default,imports:[f,m,p,c,g]}]}],null,null);const z=[d,k,m,b,f,c,w,h,y,p,g,_,v,x,D,C,F];class R{static \u0275fac=function(a){return new(a||R)};static \u0275mod=e.\u0275\u0275defineNgModule({type:R});static \u0275inj=e.\u0275\u0275defineInjector({imports:[n.CdkTableModule,A.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(R,[{type:e.NgModule,args:[{imports:[n.CdkTableModule,...z],exports:[A.BidiModule,z]}]}],null,null);const X=9007199254740991;class Y extends H.DataSource{_data;_renderData=new s.BehaviorSubject([]);_filter=new s.BehaviorSubject("");_internalPageChanges=new s.Subject;_renderChangesSubscription=null;filteredData;get data(){return this._data.value}set data(t){t=Array.isArray(t)?t:[],this._data.next(t),this._renderChangesSubscription||this._filterData(t)}get filter(){return this._filter.value}set filter(t){this._filter.next(t),this._renderChangesSubscription||this._filterData(this.data)}get sort(){return this._sort}set sort(t){this._sort=t,this._updateChangeSubscription()}_sort;get paginator(){return this._paginator}set paginator(t){this._paginator=t,this._updateChangeSubscription()}_paginator;sortingDataAccessor=(t,a)=>{const o=t[a];if((0,j._isNumberValue)(o)){const i=Number(o);return i<X?i:o}return o};sortData=(t,a)=>{const o=a.active,i=a.direction;return!o||i==""?t:t.sort((O,S)=>{let r=this.sortingDataAccessor(O,o),M=this.sortingDataAccessor(S,o);const B=typeof r,N=typeof M;B!==N&&(B==="number"&&(r+=""),N==="number"&&(M+=""));let E=0;return r!=null&&M!=null?r>M?E=1:r<M&&(E=-1):r!=null?E=1:M!=null&&(E=-1),E*(i=="asc"?1:-1)})};filterPredicate=(t,a)=>{(typeof ngDevMode>"u"||ngDevMode)&&(typeof t!="object"||t===null)&&console.warn("Default implementation of filterPredicate requires data to be a non-null object.");const o=a.trim().toLowerCase();return Object.values(t).some(i=>`${i}`.toLowerCase().includes(o))};constructor(t=[]){super(),this._data=new s.BehaviorSubject(t),this._updateChangeSubscription()}_updateChangeSubscription(){const t=this._sort?(0,s.merge)(this._sort.sortChange,this._sort.initialized):(0,s.of)(null),a=this._paginator?(0,s.merge)(this._paginator.page,this._internalPageChanges,this._paginator.initialized):(0,s.of)(null),o=this._data,i=(0,s.combineLatest)([o,this._filter]).pipe((0,I.map)(([r])=>this._filterData(r))),O=(0,s.combineLatest)([i,t]).pipe((0,I.map)(([r])=>this._orderData(r))),S=(0,s.combineLatest)([O,a]).pipe((0,I.map)(([r])=>this._pageData(r)));this._renderChangesSubscription?.unsubscribe(),this._renderChangesSubscription=S.subscribe(r=>this._renderData.next(r))}_filterData(t){return this.filteredData=this.filter==null||this.filter===""?t:t.filter(a=>this.filterPredicate(a,this.filter)),this.paginator&&this._updatePaginator(this.filteredData.length),this.filteredData}_orderData(t){return this.sort?this.sortData(t.slice(),this.sort):t}_pageData(t){if(!this.paginator)return t;const a=this.paginator.pageIndex*this.paginator.pageSize;return t.slice(a,a+this.paginator.pageSize)}_updatePaginator(t){Promise.resolve().then(()=>{const a=this.paginator;if(a&&(a.length=t,a.pageIndex>0)){const o=Math.ceil(a.length/a.pageSize)-1||0,i=Math.min(a.pageIndex,o);i!==a.pageIndex&&(a.pageIndex=i,this._internalPageChanges.next())}})}connect(){return this._renderChangesSubscription||this._updateChangeSubscription(),this._renderData}disconnect(){this._renderChangesSubscription?.unsubscribe(),this._renderChangesSubscription=null}}}}]);
