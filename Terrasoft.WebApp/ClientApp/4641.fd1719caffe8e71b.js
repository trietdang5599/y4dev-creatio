"use strict";(self.webpackChunkapp_studio_enterprise_system_designer=self.webpackChunkapp_studio_enterprise_system_designer||[]).push([[4641],{44641(Q,D,d){d.d(D,{B_:()=>l,Fe:()=>w,NS:()=>o});class I{tracker;columnIndex=0;rowIndex=0;get rowCount(){return this.rowIndex+1}get rowspan(){const t=Math.max(...this.tracker);return t>1?this.rowCount+t-1:this.rowCount}positions;update(t,e){this.columnIndex=0,this.rowIndex=0,this.tracker=new Array(t),this.tracker.fill(0,0,this.tracker.length),this.positions=e.map(n=>this._trackTile(n))}_trackTile(t){const e=this._findMatchingGap(t.colspan);return this._markTilePosition(e,t),this.columnIndex=e+t.colspan,new H(this.rowIndex,e)}_findMatchingGap(t){if(t>this.tracker.length&&(typeof ngDevMode>"u"||ngDevMode))throw Error(`mat-grid-list: tile with colspan ${t} is wider than grid with cols="${this.tracker.length}".`);let e=-1,n=-1;do{if(this.columnIndex+t>this.tracker.length){this._nextRow(),e=this.tracker.indexOf(0,this.columnIndex),n=this._findGapEndIndex(e);continue}if(e=this.tracker.indexOf(0,this.columnIndex),e==-1){this._nextRow(),e=this.tracker.indexOf(0,this.columnIndex),n=this._findGapEndIndex(e);continue}n=this._findGapEndIndex(e),this.columnIndex=e+1}while(n-e<t||n==0);return Math.max(e,0)}_nextRow(){this.columnIndex=0,this.rowIndex++;for(let t=0;t<this.tracker.length;t++)this.tracker[t]=Math.max(0,this.tracker[t]-1)}_findGapEndIndex(t){for(let e=t+1;e<this.tracker.length;e++)if(this.tracker[e]!=0)return e;return this.tracker.length}_markTilePosition(t,e){for(let n=0;n<e.colspan;n++)this.tracker[t+n]=e.rowspan}}class H{row;col;constructor(t,e){this.row=t,this.col=e}}const W=null;var i=d(20863),g=d(46296),T=d(2978),b=d(43913),v=d(3126),$=d(20965);class h{static \u0275fac=function(e){return new(e||h)};static \u0275dir=i.FsC({type:h,selectors:[["","mat-line",""],["","matLine",""]],hostAttrs:[1,"mat-line"]})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(h,[{type:i.WLR,args:[{selector:"[mat-line], [matLine]",host:{class:"mat-line"}}]}],null,null);function C(s,t,e="mat"){s.changes.pipe((0,$.Z)(s)).subscribe(({length:n})=>{x(t,`${e}-2-line`,!1),x(t,`${e}-3-line`,!1),x(t,`${e}-multi-line`,!1),n===2||n===3?x(t,`${e}-${n}-line`,!0):n>3&&x(t,`${e}-multi-line`,!0)})}function x(s,t,e){s.nativeElement.classList.toggle(t,e)}class m{static \u0275fac=function(e){return new(e||m)};static \u0275mod=i.$C({type:m});static \u0275inj=g.G2t({imports:[v.jI]})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(m,[{type:i.UQu,args:[{imports:[h],exports:[h,v.jI]}]}],null,null);var G=d(44167);const k=["*"],R=[[["","mat-grid-avatar",""],["","matGridAvatar",""]],[["","mat-line",""],["","matLine",""]],"*"],A=["[mat-grid-avatar], [matGridAvatar]","[mat-line], [matLine]","*"],L=`.mat-grid-list {
  display: block;
  position: relative;
}

.mat-grid-tile {
  display: block;
  position: absolute;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-tile-header,
.mat-grid-tile .mat-grid-tile-footer {
  display: flex;
  align-items: center;
  height: 48px;
  color: #fff;
  background: rgba(0, 0, 0, 0.38);
  overflow: hidden;
  padding: 0 16px;
  position: absolute;
  left: 0;
  right: 0;
}
.mat-grid-tile .mat-grid-tile-header > *,
.mat-grid-tile .mat-grid-tile-footer > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-tile-header.mat-2-line,
.mat-grid-tile .mat-grid-tile-footer.mat-2-line {
  height: 68px;
}
.mat-grid-tile .mat-grid-list-text {
  display: flex;
  flex-direction: column;
  flex: auto;
  box-sizing: border-box;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-list-text > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-list-text:empty {
  display: none;
}
.mat-grid-tile .mat-grid-tile-header {
  top: 0;
}
.mat-grid-tile .mat-grid-tile-footer {
  bottom: 0;
}
.mat-grid-tile .mat-grid-avatar {
  padding-right: 16px;
}
[dir=rtl] .mat-grid-tile .mat-grid-avatar {
  padding-right: 0;
  padding-left: 16px;
}
.mat-grid-tile .mat-grid-avatar:empty {
  display: none;
}

.mat-grid-tile-header {
  font-size: var(--mat-grid-list-tile-header-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-header .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-header .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-header-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-footer {
  font-size: var(--mat-grid-list-tile-footer-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-footer .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-footer .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-footer-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-content {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  padding: 0;
  margin: 0;
}
`,S=new g.nKC("MAT_GRID_LIST");class o{_element=(0,g.WQX)(i.aKT);_gridList=(0,g.WQX)(S,{optional:!0});_rowspan=1;_colspan=1;constructor(){}get rowspan(){return this._rowspan}set rowspan(t){this._rowspan=Math.round((0,b.OE)(t))}get colspan(){return this._colspan}set colspan(t){this._colspan=Math.round((0,b.OE)(t))}_setStyle(t,e){this._element.nativeElement.style[t]=e}static \u0275fac=function(e){return new(e||o)};static \u0275cmp=i.VBU({type:o,selectors:[["mat-grid-tile"]],hostAttrs:[1,"mat-grid-tile"],hostVars:2,hostBindings:function(e,n){e&2&&i.BMQ("rowspan",n.rowspan)("colspan",n.colspan)},inputs:{rowspan:"rowspan",colspan:"colspan"},exportAs:["matGridTile"],ngContentSelectors:k,decls:2,vars:0,consts:[[1,"mat-grid-tile-content"]],template:function(e,n){e&1&&(i.NAR(),i.rj2(0,"div",0),i.SdG(1),i.eux())},styles:[`.mat-grid-list {
  display: block;
  position: relative;
}

.mat-grid-tile {
  display: block;
  position: absolute;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-tile-header,
.mat-grid-tile .mat-grid-tile-footer {
  display: flex;
  align-items: center;
  height: 48px;
  color: #fff;
  background: rgba(0, 0, 0, 0.38);
  overflow: hidden;
  padding: 0 16px;
  position: absolute;
  left: 0;
  right: 0;
}
.mat-grid-tile .mat-grid-tile-header > *,
.mat-grid-tile .mat-grid-tile-footer > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-tile-header.mat-2-line,
.mat-grid-tile .mat-grid-tile-footer.mat-2-line {
  height: 68px;
}
.mat-grid-tile .mat-grid-list-text {
  display: flex;
  flex-direction: column;
  flex: auto;
  box-sizing: border-box;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-list-text > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-list-text:empty {
  display: none;
}
.mat-grid-tile .mat-grid-tile-header {
  top: 0;
}
.mat-grid-tile .mat-grid-tile-footer {
  bottom: 0;
}
.mat-grid-tile .mat-grid-avatar {
  padding-right: 16px;
}
[dir=rtl] .mat-grid-tile .mat-grid-avatar {
  padding-right: 0;
  padding-left: 16px;
}
.mat-grid-tile .mat-grid-avatar:empty {
  display: none;
}

.mat-grid-tile-header {
  font-size: var(--mat-grid-list-tile-header-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-header .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-header .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-header-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-footer {
  font-size: var(--mat-grid-list-tile-footer-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-footer .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-footer .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-footer-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-content {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  padding: 0;
  margin: 0;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(o,[{type:i.uAl,args:[{selector:"mat-grid-tile",exportAs:"matGridTile",host:{class:"mat-grid-tile","[attr.rowspan]":"rowspan","[attr.colspan]":"colspan"},encapsulation:i.gXe.None,changeDetection:i.Ngq.OnPush,template:`<div class="mat-grid-tile-content">
  <ng-content></ng-content>
</div>
`,styles:[`.mat-grid-list {
  display: block;
  position: relative;
}

.mat-grid-tile {
  display: block;
  position: absolute;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-tile-header,
.mat-grid-tile .mat-grid-tile-footer {
  display: flex;
  align-items: center;
  height: 48px;
  color: #fff;
  background: rgba(0, 0, 0, 0.38);
  overflow: hidden;
  padding: 0 16px;
  position: absolute;
  left: 0;
  right: 0;
}
.mat-grid-tile .mat-grid-tile-header > *,
.mat-grid-tile .mat-grid-tile-footer > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-tile-header.mat-2-line,
.mat-grid-tile .mat-grid-tile-footer.mat-2-line {
  height: 68px;
}
.mat-grid-tile .mat-grid-list-text {
  display: flex;
  flex-direction: column;
  flex: auto;
  box-sizing: border-box;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-list-text > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-list-text:empty {
  display: none;
}
.mat-grid-tile .mat-grid-tile-header {
  top: 0;
}
.mat-grid-tile .mat-grid-tile-footer {
  bottom: 0;
}
.mat-grid-tile .mat-grid-avatar {
  padding-right: 16px;
}
[dir=rtl] .mat-grid-tile .mat-grid-avatar {
  padding-right: 0;
  padding-left: 16px;
}
.mat-grid-tile .mat-grid-avatar:empty {
  display: none;
}

.mat-grid-tile-header {
  font-size: var(--mat-grid-list-tile-header-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-header .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-header .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-header-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-footer {
  font-size: var(--mat-grid-list-tile-footer-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-footer .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-footer .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-footer-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-content {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  padding: 0;
  margin: 0;
}
`]}]}],()=>[],{rowspan:[{type:i.pde}],colspan:[{type:i.pde}]});class p{_element=(0,g.WQX)(i.aKT);_lines;constructor(){}ngAfterContentInit(){C(this._lines,this._element)}static \u0275fac=function(e){return new(e||p)};static \u0275cmp=i.VBU({type:p,selectors:[["mat-grid-tile-header"],["mat-grid-tile-footer"]],contentQueries:function(e,n,r){if(e&1&&i.wni(r,h,5),e&2){let a;i.mGM(a=i.lsd())&&(n._lines=a)}},ngContentSelectors:A,decls:4,vars:0,consts:[[1,"mat-grid-list-text"]],template:function(e,n){e&1&&(i.NAR(R),i.SdG(0),i.rj2(1,"div",0),i.SdG(2,1),i.eux(),i.SdG(3,2))},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(p,[{type:i.uAl,args:[{selector:"mat-grid-tile-header, mat-grid-tile-footer",changeDetection:i.Ngq.OnPush,encapsulation:i.gXe.None,template:`<ng-content select="[mat-grid-avatar], [matGridAvatar]"></ng-content>
<div class="mat-grid-list-text"><ng-content select="[mat-line], [matLine]"></ng-content></div>
<ng-content></ng-content>
`}]}],()=>[],{_lines:[{type:T.F8v,args:[h,{descendants:!0}]}]});class f{static \u0275fac=function(e){return new(e||f)};static \u0275dir=i.FsC({type:f,selectors:[["","mat-grid-avatar",""],["","matGridAvatar",""]],hostAttrs:[1,"mat-grid-avatar"]})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(f,[{type:i.WLR,args:[{selector:"[mat-grid-avatar], [matGridAvatar]",host:{class:"mat-grid-avatar"}}]}],null,null);class u{static \u0275fac=function(e){return new(e||u)};static \u0275dir=i.FsC({type:u,selectors:[["mat-grid-tile-header"]],hostAttrs:[1,"mat-grid-tile-header"]})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(u,[{type:i.WLR,args:[{selector:"mat-grid-tile-header",host:{class:"mat-grid-tile-header"}}]}],null,null);class y{static \u0275fac=function(e){return new(e||y)};static \u0275dir=i.FsC({type:y,selectors:[["mat-grid-tile-footer"]],hostAttrs:[1,"mat-grid-tile-footer"]})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(y,[{type:i.WLR,args:[{selector:"mat-grid-tile-footer",host:{class:"mat-grid-tile-footer"}}]}],null,null);const E=/^-?\d+((\.\d+)?[A-Za-z%$]?)+$/;class z{_gutterSize;_rows=0;_rowspan=0;_cols;_direction;init(t,e,n,r){this._gutterSize=M(t),this._rows=e.rowCount,this._rowspan=e.rowspan,this._cols=n,this._direction=r}getBaseTileSize(t,e){return`(${t}% - (${this._gutterSize} * ${e}))`}getTilePosition(t,e){return e===0?"0":c(`(${t} + ${this._gutterSize}) * ${e}`)}getTileSize(t,e){return`(${t} * ${e}) + (${e-1} * ${this._gutterSize})`}setStyle(t,e,n){let r=100/this._cols,a=(this._cols-1)/this._cols;this.setColStyles(t,n,r,a),this.setRowStyles(t,e,r,a)}setColStyles(t,e,n,r){let a=this.getBaseTileSize(n,r),_=this._direction==="rtl"?"right":"left";t._setStyle(_,this.getTilePosition(a,e)),t._setStyle("width",c(this.getTileSize(a,t.colspan)))}getGutterSpan(){return`${this._gutterSize} * (${this._rowspan} - 1)`}getTileSpan(t){return`${this._rowspan} * ${this.getTileSize(t,1)}`}getComputedHeight(){return null}}class F extends z{fixedRowHeight;constructor(t){super(),this.fixedRowHeight=t}init(t,e,n,r){if(super.init(t,e,n,r),this.fixedRowHeight=M(this.fixedRowHeight),!E.test(this.fixedRowHeight)&&(typeof ngDevMode>"u"||ngDevMode))throw Error(`Invalid value "${this.fixedRowHeight}" set as rowHeight.`)}setRowStyles(t,e){t._setStyle("top",this.getTilePosition(this.fixedRowHeight,e)),t._setStyle("height",c(this.getTileSize(this.fixedRowHeight,t.rowspan)))}getComputedHeight(){return["height",c(`${this.getTileSpan(this.fixedRowHeight)} + ${this.getGutterSpan()}`)]}reset(t){t._setListStyle(["height",null]),t._tiles&&t._tiles.forEach(e=>{e._setStyle("top",null),e._setStyle("height",null)})}}class P extends z{rowHeightRatio;baseTileHeight;constructor(t){super(),this._parseRatio(t)}setRowStyles(t,e,n,r){let a=n/this.rowHeightRatio;this.baseTileHeight=this.getBaseTileSize(a,r),t._setStyle("marginTop",this.getTilePosition(this.baseTileHeight,e)),t._setStyle("paddingTop",c(this.getTileSize(this.baseTileHeight,t.rowspan)))}getComputedHeight(){return["paddingBottom",c(`${this.getTileSpan(this.baseTileHeight)} + ${this.getGutterSpan()}`)]}reset(t){t._setListStyle(["paddingBottom",null]),t._tiles.forEach(e=>{e._setStyle("marginTop",null),e._setStyle("paddingTop",null)})}_parseRatio(t){const e=t.split(":");if(e.length!==2&&(typeof ngDevMode>"u"||ngDevMode))throw Error(`mat-grid-list: invalid ratio given for row-height: "${t}"`);this.rowHeightRatio=parseFloat(e[0])/parseFloat(e[1])}}class B extends z{setRowStyles(t,e){let n=100/this._rowspan,r=(this._rows-1)/this._rows,a=this.getBaseTileSize(n,r);t._setStyle("top",this.getTilePosition(a,e)),t._setStyle("height",c(this.getTileSize(a,t.rowspan)))}reset(t){t._tiles&&t._tiles.forEach(e=>{e._setStyle("top",null),e._setStyle("height",null)})}}function c(s){return`calc(${s})`}function M(s){return s.match(/([A-Za-z%]+)$/)?s:`${s}px`}const j="fit";class l{_element=(0,g.WQX)(i.aKT);_dir=(0,g.WQX)(G.dS,{optional:!0});_cols;_tileCoordinator;_rowHeight;_gutter="1px";_tileStyler;_tiles;constructor(){}get cols(){return this._cols}set cols(t){this._cols=Math.max(1,Math.round((0,b.OE)(t)))}get gutterSize(){return this._gutter}set gutterSize(t){this._gutter=`${t??""}`}get rowHeight(){return this._rowHeight}set rowHeight(t){const e=`${t??""}`;e!==this._rowHeight&&(this._rowHeight=e,this._setTileStyler(this._rowHeight))}ngOnInit(){this._checkCols(),this._checkRowHeight()}ngAfterContentChecked(){this._layoutTiles()}_checkCols(){if(!this.cols&&(typeof ngDevMode>"u"||ngDevMode))throw Error('mat-grid-list: must pass in number of columns. Example: <mat-grid-list cols="3">')}_checkRowHeight(){this._rowHeight||this._setTileStyler("1:1")}_setTileStyler(t){this._tileStyler&&this._tileStyler.reset(this),t===j?this._tileStyler=new B:t&&t.indexOf(":")>-1?this._tileStyler=new P(t):this._tileStyler=new F(t)}_layoutTiles(){this._tileCoordinator||(this._tileCoordinator=new I);const t=this._tileCoordinator,e=this._tiles.filter(r=>!r._gridList||r._gridList===this),n=this._dir?this._dir.value:"ltr";this._tileCoordinator.update(this.cols,e),this._tileStyler.init(this.gutterSize,t,this.cols,n),e.forEach((r,a)=>{const _=t.positions[a];this._tileStyler.setStyle(r,_.row,_.col)}),this._setListStyle(this._tileStyler.getComputedHeight())}_setListStyle(t){t&&(this._element.nativeElement.style[t[0]]=t[1])}static \u0275fac=function(e){return new(e||l)};static \u0275cmp=i.VBU({type:l,selectors:[["mat-grid-list"]],contentQueries:function(e,n,r){if(e&1&&i.wni(r,o,5),e&2){let a;i.mGM(a=i.lsd())&&(n._tiles=a)}},hostAttrs:[1,"mat-grid-list"],hostVars:1,hostBindings:function(e,n){e&2&&i.BMQ("cols",n.cols)},inputs:{cols:"cols",gutterSize:"gutterSize",rowHeight:"rowHeight"},exportAs:["matGridList"],features:[i.Jv_([{provide:S,useExisting:l}])],ngContentSelectors:k,decls:2,vars:0,template:function(e,n){e&1&&(i.NAR(),i.rj2(0,"div"),i.SdG(1),i.eux())},styles:[L],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(l,[{type:i.uAl,args:[{selector:"mat-grid-list",exportAs:"matGridList",host:{class:"mat-grid-list","[attr.cols]":"cols"},providers:[{provide:S,useExisting:l}],changeDetection:i.Ngq.OnPush,encapsulation:i.gXe.None,template:`<div>
  <ng-content></ng-content>
</div>`,styles:[`.mat-grid-list {
  display: block;
  position: relative;
}

.mat-grid-tile {
  display: block;
  position: absolute;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-tile-header,
.mat-grid-tile .mat-grid-tile-footer {
  display: flex;
  align-items: center;
  height: 48px;
  color: #fff;
  background: rgba(0, 0, 0, 0.38);
  overflow: hidden;
  padding: 0 16px;
  position: absolute;
  left: 0;
  right: 0;
}
.mat-grid-tile .mat-grid-tile-header > *,
.mat-grid-tile .mat-grid-tile-footer > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-tile-header.mat-2-line,
.mat-grid-tile .mat-grid-tile-footer.mat-2-line {
  height: 68px;
}
.mat-grid-tile .mat-grid-list-text {
  display: flex;
  flex-direction: column;
  flex: auto;
  box-sizing: border-box;
  overflow: hidden;
}
.mat-grid-tile .mat-grid-list-text > * {
  margin: 0;
  padding: 0;
  font-weight: normal;
  font-size: inherit;
}
.mat-grid-tile .mat-grid-list-text:empty {
  display: none;
}
.mat-grid-tile .mat-grid-tile-header {
  top: 0;
}
.mat-grid-tile .mat-grid-tile-footer {
  bottom: 0;
}
.mat-grid-tile .mat-grid-avatar {
  padding-right: 16px;
}
[dir=rtl] .mat-grid-tile .mat-grid-avatar {
  padding-right: 0;
  padding-left: 16px;
}
.mat-grid-tile .mat-grid-avatar:empty {
  display: none;
}

.mat-grid-tile-header {
  font-size: var(--mat-grid-list-tile-header-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-header .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-header .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-header-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-footer {
  font-size: var(--mat-grid-list-tile-footer-primary-text-size, var(--mat-sys-body-large));
}
.mat-grid-tile-footer .mat-line {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  display: block;
  box-sizing: border-box;
}
.mat-grid-tile-footer .mat-line:nth-child(n+2) {
  font-size: var(--mat-grid-list-tile-footer-secondary-text-size, var(--mat-sys-body-medium));
}

.mat-grid-tile-content {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  padding: 0;
  margin: 0;
}
`]}]}],()=>[],{_tiles:[{type:T.F8v,args:[o,{descendants:!0}]}],cols:[{type:i.pde}],gutterSize:[{type:i.pde}],rowHeight:[{type:i.pde}]});class w{static \u0275fac=function(e){return new(e||w)};static \u0275mod=i.$C({type:w});static \u0275inj=g.G2t({imports:[m,v.jI,m]})}(typeof ngDevMode>"u"||ngDevMode)&&i.cDI(w,[{type:i.UQu,args:[{imports:[m,l,o,p,u,y,f],exports:[v.jI,l,o,p,m,u,y,f]}]}],null,null)}}]);
