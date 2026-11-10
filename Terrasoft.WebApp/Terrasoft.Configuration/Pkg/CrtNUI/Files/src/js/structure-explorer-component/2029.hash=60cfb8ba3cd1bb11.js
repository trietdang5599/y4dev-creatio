(self.webpackChunkapp_studio_enterprise_structure_explorer=self.webpackChunkapp_studio_enterprise_structure_explorer||[]).push([[2029],{34630(g,m,a){a.d(m,{Rc:()=>f,Sx:()=>_,_J:()=>c});var e=a(15047),o=a(39638);const _=new o.InjectionToken("MATERIAL_ANIMATIONS");let d=null;function c(){return(0,o.inject)(_,{optional:!0})?.animationsDisabled||(0,o.inject)(o.ANIMATION_MODULE_TYPE,{optional:!0})==="NoopAnimations"?"di-disabled":(d??=(0,o.inject)(e.MediaMatcher).matchMedia("(prefers-reduced-motion)").matches,d?"reduced-motion":"enabled")}function f(){return c()!=="enabled"}},30184(g,m,a){a.d(m,{A:()=>o});var e=a(39638);class o{static \u0275fac=function(c){return new(c||o)};static \u0275cmp=e.\u0275\u0275defineComponent({type:o,selectors:[["structural-styles"]],decls:0,vars:0,template:function(c,f){},styles:[`.mat-focus-indicator {
  position: relative;
}
.mat-focus-indicator::before {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  box-sizing: border-box;
  pointer-events: none;
  display: var(--mat-focus-indicator-display, none);
  border-width: var(--mat-focus-indicator-border-width, 3px);
  border-style: var(--mat-focus-indicator-border-style, solid);
  border-color: var(--mat-focus-indicator-border-color, transparent);
  border-radius: var(--mat-focus-indicator-border-radius, 4px);
}
.mat-focus-indicator:focus-visible::before {
  content: "";
}

@media (forced-colors: active) {
  html {
    --mat-focus-indicator-display: block;
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(o,[{type:e.Component,args:[{selector:"structural-styles",encapsulation:e.ViewEncapsulation.None,template:"",changeDetection:e.ChangeDetectionStrategy.OnPush,styles:[`.mat-focus-indicator {
  position: relative;
}
.mat-focus-indicator::before {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  box-sizing: border-box;
  pointer-events: none;
  display: var(--mat-focus-indicator-display, none);
  border-width: var(--mat-focus-indicator-border-width, 3px);
  border-style: var(--mat-focus-indicator-border-style, solid);
  border-color: var(--mat-focus-indicator-border-color, transparent);
  border-radius: var(--mat-focus-indicator-border-radius, 4px);
}
.mat-focus-indicator:focus-visible::before {
  content: "";
}

@media (forced-colors: active) {
  html {
    --mat-focus-indicator-display: block;
  }
}
`]}]}],null,null)},22029(g,m,a){a.r(m),a.d(m,{MAT_SORT_DEFAULT_OPTIONS:()=>b,MatSort:()=>s,MatSortHeader:()=>l,MatSortHeaderIntl:()=>h,MatSortModule:()=>p});var e=a(39638),o=a(88632),_=a(60447),d=a(88783),c=a(4295),f=a(26157),v=a(34630),D=a(30184),y=a(90459),T=a(15047);const w=["mat-sort-header",""],S=["*",[["","matSortHeaderIcon",""]]],M=["*","[matSortHeaderIcon]"];function C(i,t){i&1&&(e.\u0275\u0275namespaceSVG(),e.\u0275\u0275domElementStart(0,"svg",3),e.\u0275\u0275domElement(1,"path",4),e.\u0275\u0275domElementEnd())}function A(i,t){i&1&&(e.\u0275\u0275domElementStart(0,"div",2),e.\u0275\u0275projection(1,1,null,C,2,0),e.\u0275\u0275domElementEnd())}function E(i){return Error(`Cannot have two MatSortables with the same id (${i}).`)}function I(){return Error("MatSortHeader must be placed within a parent element with the MatSort directive.")}function O(){return Error("MatSortHeader must be provided with a unique id.")}function x(i){return Error(`${i} is not a valid sort direction ('asc' or 'desc').`)}const b=new e.InjectionToken("MAT_SORT_DEFAULT_OPTIONS");class s{_defaultOptions;_initializedStream=new o.ReplaySubject(1);sortables=new Map;_stateChanges=new o.Subject;active;start="asc";get direction(){return this._direction}set direction(t){if(t&&t!=="asc"&&t!=="desc"&&(typeof ngDevMode>"u"||ngDevMode))throw x(t);this._direction=t}_direction="";disableClear;disabled=!1;sortChange=new e.EventEmitter;initialized=this._initializedStream;constructor(t){this._defaultOptions=t}register(t){if(typeof ngDevMode>"u"||ngDevMode){if(!t.id)throw O();if(this.sortables.has(t.id))throw E(t.id)}this.sortables.set(t.id,t)}deregister(t){this.sortables.delete(t.id)}sort(t){this.active!=t.id?(this.active=t.id,this.direction=t.start?t.start:this.start):this.direction=this.getNextSortDirection(t),this.sortChange.emit({active:this.active,direction:this.direction})}getNextSortDirection(t){if(!t)return"";const r=t?.disableClear??this.disableClear??!!this._defaultOptions?.disableClear;let n=P(t.start||this.start,r),u=n.indexOf(this.direction)+1;return u>=n.length&&(u=0),n[u]}ngOnInit(){this._initializedStream.next()}ngOnChanges(){this._stateChanges.next()}ngOnDestroy(){this._stateChanges.complete(),this._initializedStream.complete()}static \u0275fac=function(r){return new(r||s)(e.\u0275\u0275directiveInject(b,8))};static \u0275dir=e.\u0275\u0275defineDirective({type:s,selectors:[["","matSort",""]],hostAttrs:[1,"mat-sort"],inputs:{active:[0,"matSortActive","active"],start:[0,"matSortStart","start"],direction:[0,"matSortDirection","direction"],disableClear:[2,"matSortDisableClear","disableClear",e.booleanAttribute],disabled:[2,"matSortDisabled","disabled",e.booleanAttribute]},outputs:{sortChange:"matSortChange"},exportAs:["matSort"],features:[e.\u0275\u0275NgOnChangesFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(s,[{type:e.Directive,args:[{selector:"[matSort]",exportAs:"matSort",host:{class:"mat-sort"}}]}],()=>[{type:void 0,decorators:[{type:e.Optional},{type:e.Inject,args:[b]}]}],{active:[{type:e.Input,args:["matSortActive"]}],start:[{type:e.Input,args:["matSortStart"]}],direction:[{type:e.Input,args:["matSortDirection"]}],disableClear:[{type:e.Input,args:[{alias:"matSortDisableClear",transform:e.booleanAttribute}]}],disabled:[{type:e.Input,args:[{alias:"matSortDisabled",transform:e.booleanAttribute}]}],sortChange:[{type:e.Output,args:["matSortChange"]}]});function P(i,t){let r=["asc","desc"];return i=="desc"&&r.reverse(),t||r.push(""),r}class l{_sort=(0,e.inject)(s,{optional:!0});_columnDef=(0,e.inject)(f.CdkColumnDef,{optional:!0});_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_focusMonitor=(0,e.inject)(_.FocusMonitor);_elementRef=(0,e.inject)(e.ElementRef);_ariaDescriber=(0,e.inject)(_.AriaDescriber,{optional:!0});_renderChanges;_animationsDisabled=(0,v.Rc)();_recentlyCleared=(0,e.signal)(null,...ngDevMode?[{debugName:"_recentlyCleared"}]:[]);_sortButton;id;arrowPosition="after";start;disabled=!1;get sortActionDescription(){return this._sortActionDescription}set sortActionDescription(t){this._updateSortActionDescription(t)}_sortActionDescription="Sort";disableClear;constructor(){(0,e.inject)(c._CdkPrivateStyleLoader).load(D.A);const t=(0,e.inject)(b,{optional:!0});if(!this._sort&&(typeof ngDevMode>"u"||ngDevMode))throw I();t?.arrowPosition&&(this.arrowPosition=t?.arrowPosition)}ngOnInit(){!this.id&&this._columnDef&&(this.id=this._columnDef.name),this._sort.register(this),this._renderChanges=(0,o.merge)(this._sort._stateChanges,this._sort.sortChange).subscribe(()=>this._changeDetectorRef.markForCheck()),this._sortButton=this._elementRef.nativeElement.querySelector(".mat-sort-header-container"),this._updateSortActionDescription(this._sortActionDescription)}ngAfterViewInit(){this._focusMonitor.monitor(this._elementRef,!0).subscribe(()=>{Promise.resolve().then(()=>this._recentlyCleared.set(null))})}ngOnDestroy(){this._focusMonitor.stopMonitoring(this._elementRef),this._sort.deregister(this),this._renderChanges?.unsubscribe(),this._sortButton&&this._ariaDescriber?.removeDescription(this._sortButton,this._sortActionDescription)}_toggleOnInteraction(){if(!this._isDisabled()){const t=this._isSorted(),r=this._sort.direction;this._sort.sort(this),this._recentlyCleared.set(t&&!this._isSorted()?r:null)}}_handleKeydown(t){(t.keyCode===d.SPACE||t.keyCode===d.ENTER)&&(t.preventDefault(),this._toggleOnInteraction())}_isSorted(){return this._sort.active==this.id&&(this._sort.direction==="asc"||this._sort.direction==="desc")}_isDisabled(){return this._sort.disabled||this.disabled}_getAriaSortAttribute(){return this._isSorted()?this._sort.direction=="asc"?"ascending":"descending":"none"}_renderArrow(){return!this._isDisabled()||this._isSorted()}_updateSortActionDescription(t){this._sortButton&&(this._ariaDescriber?.removeDescription(this._sortButton,this._sortActionDescription),this._ariaDescriber?.describe(this._sortButton,t)),this._sortActionDescription=t}static \u0275fac=function(r){return new(r||l)};static \u0275cmp=e.\u0275\u0275defineComponent({type:l,selectors:[["","mat-sort-header",""]],hostAttrs:[1,"mat-sort-header"],hostVars:3,hostBindings:function(r,n){r&1&&e.\u0275\u0275listener("click",function(){return n._toggleOnInteraction()})("keydown",function(k){return n._handleKeydown(k)})("mouseleave",function(){return n._recentlyCleared.set(null)}),r&2&&(e.\u0275\u0275attribute("aria-sort",n._getAriaSortAttribute()),e.\u0275\u0275classProp("mat-sort-header-disabled",n._isDisabled()))},inputs:{id:[0,"mat-sort-header","id"],arrowPosition:"arrowPosition",start:"start",disabled:[2,"disabled","disabled",e.booleanAttribute],sortActionDescription:"sortActionDescription",disableClear:[2,"disableClear","disableClear",e.booleanAttribute]},exportAs:["matSortHeader"],attrs:w,ngContentSelectors:M,decls:4,vars:17,consts:[[1,"mat-sort-header-container","mat-focus-indicator"],[1,"mat-sort-header-content"],[1,"mat-sort-header-arrow"],["viewBox","0 -960 960 960","focusable","false","aria-hidden","true"],["d","M440-240v-368L296-464l-56-56 240-240 240 240-56 56-144-144v368h-80Z"]],template:function(r,n){r&1&&(e.\u0275\u0275projectionDef(S),e.\u0275\u0275domElementStart(0,"div",0)(1,"div",1),e.\u0275\u0275projection(2),e.\u0275\u0275domElementEnd(),e.\u0275\u0275conditionalCreate(3,A,3,0,"div",2),e.\u0275\u0275domElementEnd()),r&2&&(e.\u0275\u0275classProp("mat-sort-header-sorted",n._isSorted())("mat-sort-header-position-before",n.arrowPosition==="before")("mat-sort-header-descending",n._sort.direction==="desc")("mat-sort-header-ascending",n._sort.direction==="asc")("mat-sort-header-recently-cleared-ascending",n._recentlyCleared()==="asc")("mat-sort-header-recently-cleared-descending",n._recentlyCleared()==="desc")("mat-sort-header-animations-disabled",n._animationsDisabled),e.\u0275\u0275attribute("tabindex",n._isDisabled()?null:0)("role",n._isDisabled()?null:"button"),e.\u0275\u0275advance(3),e.\u0275\u0275conditional(n._renderArrow()?3:-1))},styles:[`.mat-sort-header {
  cursor: pointer;
}

.mat-sort-header-disabled {
  cursor: default;
}

.mat-sort-header-container {
  display: flex;
  align-items: center;
  letter-spacing: normal;
  outline: 0;
}
[mat-sort-header].cdk-keyboard-focused .mat-sort-header-container, [mat-sort-header].cdk-program-focused .mat-sort-header-container {
  border-bottom: solid 1px currentColor;
}
.mat-sort-header-container::before {
  margin: calc(calc(var(--mat-focus-indicator-border-width, 3px) + 2px) * -1);
}

.mat-sort-header-content {
  display: flex;
  align-items: center;
}

.mat-sort-header-position-before {
  flex-direction: row-reverse;
}

@keyframes _mat-sort-header-recently-cleared-ascending {
  from {
    transform: translateY(0);
    opacity: 1;
  }
  to {
    transform: translateY(-25%);
    opacity: 0;
  }
}
@keyframes _mat-sort-header-recently-cleared-descending {
  from {
    transform: translateY(0) rotate(180deg);
    opacity: 1;
  }
  to {
    transform: translateY(25%) rotate(180deg);
    opacity: 0;
  }
}
.mat-sort-header-arrow {
  height: 12px;
  width: 12px;
  position: relative;
  transition: transform 225ms cubic-bezier(0.4, 0, 0.2, 1), opacity 225ms cubic-bezier(0.4, 0, 0.2, 1);
  opacity: 0;
  overflow: visible;
  color: var(--mat-sort-arrow-color, var(--mat-sys-on-surface));
}
.mat-sort-header.cdk-keyboard-focused .mat-sort-header-arrow, .mat-sort-header.cdk-program-focused .mat-sort-header-arrow, .mat-sort-header:hover .mat-sort-header-arrow {
  opacity: 0.54;
}
.mat-sort-header .mat-sort-header-sorted .mat-sort-header-arrow {
  opacity: 1;
}
.mat-sort-header-descending .mat-sort-header-arrow {
  transform: rotate(180deg);
}
.mat-sort-header-recently-cleared-ascending .mat-sort-header-arrow {
  transform: translateY(-25%);
}
.mat-sort-header-recently-cleared-ascending .mat-sort-header-arrow {
  transition: none;
  animation: _mat-sort-header-recently-cleared-ascending 225ms cubic-bezier(0.4, 0, 0.2, 1) forwards;
}
.mat-sort-header-recently-cleared-descending .mat-sort-header-arrow {
  transition: none;
  animation: _mat-sort-header-recently-cleared-descending 225ms cubic-bezier(0.4, 0, 0.2, 1) forwards;
}
.mat-sort-header-animations-disabled .mat-sort-header-arrow {
  transition-duration: 0ms;
  animation-duration: 0ms;
}
.mat-sort-header-arrow > svg, .mat-sort-header-arrow [matSortHeaderIcon] {
  width: 24px;
  height: 24px;
  fill: currentColor;
  position: absolute;
  top: 50%;
  left: 50%;
  margin: -12px 0 0 -12px;
  transform: translateZ(0);
}
.mat-sort-header-arrow, [dir=rtl] .mat-sort-header-position-before .mat-sort-header-arrow {
  margin: 0 0 0 6px;
}
.mat-sort-header-position-before .mat-sort-header-arrow, [dir=rtl] .mat-sort-header-arrow {
  margin: 0 6px 0 0;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(l,[{type:e.Component,args:[{selector:"[mat-sort-header]",exportAs:"matSortHeader",host:{class:"mat-sort-header","(click)":"_toggleOnInteraction()","(keydown)":"_handleKeydown($event)","(mouseleave)":"_recentlyCleared.set(null)","[attr.aria-sort]":"_getAriaSortAttribute()","[class.mat-sort-header-disabled]":"_isDisabled()"},encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,template:`<!--
  We set the \`tabindex\` on an element inside the table header, rather than the header itself,
  because of a bug in NVDA where having a \`tabindex\` on a \`th\` breaks keyboard navigation in the
  table (see https://github.com/nvaccess/nvda/issues/7718). This allows for the header to both
  be focusable, and have screen readers read out its \`aria-sort\` state. We prefer this approach
  over having a button with an \`aria-label\` inside the header, because the button's \`aria-label\`
  will be read out as the user is navigating the table's cell (see #13012).

  The approach is based off of: https://dequeuniversity.com/library/aria/tables/sf-sortable-grid
-->
<div class="mat-sort-header-container mat-focus-indicator"
     [class.mat-sort-header-sorted]="_isSorted()"
     [class.mat-sort-header-position-before]="arrowPosition === 'before'"
     [class.mat-sort-header-descending]="_sort.direction === 'desc'"
     [class.mat-sort-header-ascending]="_sort.direction === 'asc'"
     [class.mat-sort-header-recently-cleared-ascending]="_recentlyCleared() === 'asc'"
     [class.mat-sort-header-recently-cleared-descending]="_recentlyCleared() === 'desc'"
     [class.mat-sort-header-animations-disabled]="_animationsDisabled"
     [attr.tabindex]="_isDisabled() ? null : 0"
     [attr.role]="_isDisabled() ? null : 'button'">

  <!--
    TODO(crisbeto): this div isn't strictly necessary, but we have to keep it due to a large
    number of screenshot diff failures. It should be removed eventually. Note that the difference
    isn't visible with a shorter header, but once it breaks up into multiple lines, this element
    causes it to be center-aligned, whereas removing it will keep the text to the left.
  -->
  <div class="mat-sort-header-content">
    <ng-content></ng-content>
  </div>

  <!-- Disable animations while a current animation is running -->
  @if (_renderArrow()) {
    <div class="mat-sort-header-arrow">
      <ng-content select="[matSortHeaderIcon]">
        <svg viewBox="0 -960 960 960" focusable="false" aria-hidden="true">
          <path d="M440-240v-368L296-464l-56-56 240-240 240 240-56 56-144-144v368h-80Z"/>
        </svg>
      </ng-content>
    </div>
  }
</div>
`,styles:[`.mat-sort-header {
  cursor: pointer;
}

.mat-sort-header-disabled {
  cursor: default;
}

.mat-sort-header-container {
  display: flex;
  align-items: center;
  letter-spacing: normal;
  outline: 0;
}
[mat-sort-header].cdk-keyboard-focused .mat-sort-header-container, [mat-sort-header].cdk-program-focused .mat-sort-header-container {
  border-bottom: solid 1px currentColor;
}
.mat-sort-header-container::before {
  margin: calc(calc(var(--mat-focus-indicator-border-width, 3px) + 2px) * -1);
}

.mat-sort-header-content {
  display: flex;
  align-items: center;
}

.mat-sort-header-position-before {
  flex-direction: row-reverse;
}

@keyframes _mat-sort-header-recently-cleared-ascending {
  from {
    transform: translateY(0);
    opacity: 1;
  }
  to {
    transform: translateY(-25%);
    opacity: 0;
  }
}
@keyframes _mat-sort-header-recently-cleared-descending {
  from {
    transform: translateY(0) rotate(180deg);
    opacity: 1;
  }
  to {
    transform: translateY(25%) rotate(180deg);
    opacity: 0;
  }
}
.mat-sort-header-arrow {
  height: 12px;
  width: 12px;
  position: relative;
  transition: transform 225ms cubic-bezier(0.4, 0, 0.2, 1), opacity 225ms cubic-bezier(0.4, 0, 0.2, 1);
  opacity: 0;
  overflow: visible;
  color: var(--mat-sort-arrow-color, var(--mat-sys-on-surface));
}
.mat-sort-header.cdk-keyboard-focused .mat-sort-header-arrow, .mat-sort-header.cdk-program-focused .mat-sort-header-arrow, .mat-sort-header:hover .mat-sort-header-arrow {
  opacity: 0.54;
}
.mat-sort-header .mat-sort-header-sorted .mat-sort-header-arrow {
  opacity: 1;
}
.mat-sort-header-descending .mat-sort-header-arrow {
  transform: rotate(180deg);
}
.mat-sort-header-recently-cleared-ascending .mat-sort-header-arrow {
  transform: translateY(-25%);
}
.mat-sort-header-recently-cleared-ascending .mat-sort-header-arrow {
  transition: none;
  animation: _mat-sort-header-recently-cleared-ascending 225ms cubic-bezier(0.4, 0, 0.2, 1) forwards;
}
.mat-sort-header-recently-cleared-descending .mat-sort-header-arrow {
  transition: none;
  animation: _mat-sort-header-recently-cleared-descending 225ms cubic-bezier(0.4, 0, 0.2, 1) forwards;
}
.mat-sort-header-animations-disabled .mat-sort-header-arrow {
  transition-duration: 0ms;
  animation-duration: 0ms;
}
.mat-sort-header-arrow > svg, .mat-sort-header-arrow [matSortHeaderIcon] {
  width: 24px;
  height: 24px;
  fill: currentColor;
  position: absolute;
  top: 50%;
  left: 50%;
  margin: -12px 0 0 -12px;
  transform: translateZ(0);
}
.mat-sort-header-arrow, [dir=rtl] .mat-sort-header-position-before .mat-sort-header-arrow {
  margin: 0 0 0 6px;
}
.mat-sort-header-position-before .mat-sort-header-arrow, [dir=rtl] .mat-sort-header-arrow {
  margin: 0 6px 0 0;
}
`]}]}],()=>[],{id:[{type:e.Input,args:["mat-sort-header"]}],arrowPosition:[{type:e.Input}],start:[{type:e.Input}],disabled:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],sortActionDescription:[{type:e.Input}],disableClear:[{type:e.Input,args:[{transform:e.booleanAttribute}]}]});class p{static \u0275fac=function(r){return new(r||p)};static \u0275mod=e.\u0275\u0275defineNgModule({type:p});static \u0275inj=e.\u0275\u0275defineInjector({imports:[y.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(p,[{type:e.NgModule,args:[{imports:[s,l],exports:[s,l,y.BidiModule]}]}],null,null);class h{changes=new o.Subject;static \u0275fac=function(r){return new(r||h)};static \u0275prov=e.\u0275\u0275defineInjectable({token:h,factory:h.\u0275fac,providedIn:"root"})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(h,[{type:e.Injectable,args:[{providedIn:"root"}]}],null,null)}}]);
