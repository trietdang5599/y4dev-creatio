(self.webpackChunkapp_studio_enterprise_structure_explorer=self.webpackChunkapp_studio_enterprise_structure_explorer||[]).push([[1640],{34630(v,d,i){i.d(d,{Rc:()=>g,Sx:()=>l,_J:()=>p});var r=i(15047),a=i(39638);const l=new a.InjectionToken("MATERIAL_ANIMATIONS");let o=null;function p(){return(0,a.inject)(l,{optional:!0})?.animationsDisabled||(0,a.inject)(a.ANIMATION_MODULE_TYPE,{optional:!0})==="NoopAnimations"?"di-disabled":(o??=(0,a.inject)(r.MediaMatcher).matchMedia("(prefers-reduced-motion)").matches,o?"reduced-motion":"enabled")}function g(){return p()!=="enabled"}},21640(v,d,i){i.r(d),i.d(d,{MAT_PROGRESS_SPINNER_DEFAULT_OPTIONS:()=>u,MatProgressSpinner:()=>c,MatProgressSpinnerModule:()=>m,MatSpinner:()=>_});var r=i(39638),a=i(90508),l=i(34630),o=i(90459),p=i(15047);const g=["determinateSpinner"];function y(f,e){if(f&1&&(r.\u0275\u0275namespaceSVG(),r.\u0275\u0275elementStart(0,"svg",11),r.\u0275\u0275element(1,"circle",12),r.\u0275\u0275elementEnd()),f&2){const t=r.\u0275\u0275nextContext();r.\u0275\u0275attribute("viewBox",t._viewBox()),r.\u0275\u0275advance(),r.\u0275\u0275styleProp("stroke-dasharray",t._strokeCircumference(),"px")("stroke-dashoffset",t._strokeCircumference()/2,"px")("stroke-width",t._circleStrokeWidth(),"%"),r.\u0275\u0275attribute("r",t._circleRadius())}}const u=new r.InjectionToken("mat-progress-spinner-default-options",{providedIn:"root",factory:()=>({diameter:h})}),h=100,b=10;class c{_elementRef=(0,r.inject)(r.ElementRef);_noopAnimations;get color(){return this._color||this._defaultColor}set color(e){this._color=e}_color;_defaultColor="primary";_determinateCircle;constructor(){const e=(0,r.inject)(u),t=(0,l._J)(),n=this._elementRef.nativeElement;this._noopAnimations=t==="di-disabled"&&!!e&&!e._forceAnimations,this.mode=n.nodeName.toLowerCase()==="mat-spinner"?"indeterminate":"determinate",!this._noopAnimations&&t==="reduced-motion"&&n.classList.add("mat-progress-spinner-reduced-motion"),e&&(e.color&&(this.color=this._defaultColor=e.color),e.diameter&&(this.diameter=e.diameter),e.strokeWidth&&(this.strokeWidth=e.strokeWidth))}mode;get value(){return this.mode==="determinate"?this._value:0}set value(e){this._value=Math.max(0,Math.min(100,e||0))}_value=0;get diameter(){return this._diameter}set diameter(e){this._diameter=e||0}_diameter=h;get strokeWidth(){return this._strokeWidth??this.diameter/10}set strokeWidth(e){this._strokeWidth=e||0}_strokeWidth;_circleRadius(){return(this.diameter-b)/2}_viewBox(){const e=this._circleRadius()*2+this.strokeWidth;return`0 0 ${e} ${e}`}_strokeCircumference(){return 2*Math.PI*this._circleRadius()}_strokeDashOffset(){return this.mode==="determinate"?this._strokeCircumference()*(100-this._value)/100:null}_circleStrokeWidth(){return this.strokeWidth/this.diameter*100}static \u0275fac=function(t){return new(t||c)};static \u0275cmp=r.\u0275\u0275defineComponent({type:c,selectors:[["mat-progress-spinner"],["mat-spinner"]],viewQuery:function(t,n){if(t&1&&r.\u0275\u0275viewQuery(g,5),t&2){let s;r.\u0275\u0275queryRefresh(s=r.\u0275\u0275loadQuery())&&(n._determinateCircle=s.first)}},hostAttrs:["role","progressbar","tabindex","-1",1,"mat-mdc-progress-spinner","mdc-circular-progress"],hostVars:18,hostBindings:function(t,n){t&2&&(r.\u0275\u0275attribute("aria-valuemin",0)("aria-valuemax",100)("aria-valuenow",n.mode==="determinate"?n.value:null)("mode",n.mode),r.\u0275\u0275classMap("mat-"+n.color),r.\u0275\u0275styleProp("width",n.diameter,"px")("height",n.diameter,"px")("--mat-progress-spinner-size",n.diameter+"px")("--mat-progress-spinner-active-indicator-width",n.diameter+"px"),r.\u0275\u0275classProp("_mat-animation-noopable",n._noopAnimations)("mdc-circular-progress--indeterminate",n.mode==="indeterminate"))},inputs:{color:"color",mode:"mode",value:[2,"value","value",r.numberAttribute],diameter:[2,"diameter","diameter",r.numberAttribute],strokeWidth:[2,"strokeWidth","strokeWidth",r.numberAttribute]},exportAs:["matProgressSpinner"],decls:14,vars:11,consts:[["circle",""],["determinateSpinner",""],["aria-hidden","true",1,"mdc-circular-progress__determinate-container"],["xmlns","http://www.w3.org/2000/svg","focusable","false",1,"mdc-circular-progress__determinate-circle-graphic"],["cx","50%","cy","50%",1,"mdc-circular-progress__determinate-circle"],["aria-hidden","true",1,"mdc-circular-progress__indeterminate-container"],[1,"mdc-circular-progress__spinner-layer"],[1,"mdc-circular-progress__circle-clipper","mdc-circular-progress__circle-left"],[3,"ngTemplateOutlet"],[1,"mdc-circular-progress__gap-patch"],[1,"mdc-circular-progress__circle-clipper","mdc-circular-progress__circle-right"],["xmlns","http://www.w3.org/2000/svg","focusable","false",1,"mdc-circular-progress__indeterminate-circle-graphic"],["cx","50%","cy","50%"]],template:function(t,n){if(t&1&&(r.\u0275\u0275template(0,y,2,8,"ng-template",null,0,r.\u0275\u0275templateRefExtractor),r.\u0275\u0275elementStart(2,"div",2,1),r.\u0275\u0275namespaceSVG(),r.\u0275\u0275elementStart(4,"svg",3),r.\u0275\u0275element(5,"circle",4),r.\u0275\u0275elementEnd()(),r.\u0275\u0275namespaceHTML(),r.\u0275\u0275elementStart(6,"div",5)(7,"div",6)(8,"div",7),r.\u0275\u0275elementContainer(9,8),r.\u0275\u0275elementEnd(),r.\u0275\u0275elementStart(10,"div",9),r.\u0275\u0275elementContainer(11,8),r.\u0275\u0275elementEnd(),r.\u0275\u0275elementStart(12,"div",10),r.\u0275\u0275elementContainer(13,8),r.\u0275\u0275elementEnd()()()),t&2){const s=r.\u0275\u0275reference(1);r.\u0275\u0275advance(4),r.\u0275\u0275attribute("viewBox",n._viewBox()),r.\u0275\u0275advance(),r.\u0275\u0275styleProp("stroke-dasharray",n._strokeCircumference(),"px")("stroke-dashoffset",n._strokeDashOffset(),"px")("stroke-width",n._circleStrokeWidth(),"%"),r.\u0275\u0275attribute("r",n._circleRadius()),r.\u0275\u0275advance(4),r.\u0275\u0275property("ngTemplateOutlet",s),r.\u0275\u0275advance(2),r.\u0275\u0275property("ngTemplateOutlet",s),r.\u0275\u0275advance(2),r.\u0275\u0275property("ngTemplateOutlet",s)}},dependencies:[a.NgTemplateOutlet],styles:[`.mat-mdc-progress-spinner {
  --mat-progress-spinner-animation-multiplier: 1;
  display: block;
  overflow: hidden;
  line-height: 0;
  position: relative;
  direction: ltr;
  transition: opacity 250ms cubic-bezier(0.4, 0, 0.6, 1);
}
.mat-mdc-progress-spinner circle {
  stroke-width: var(--mat-progress-spinner-active-indicator-width, 4px);
}
.mat-mdc-progress-spinner._mat-animation-noopable, .mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__determinate-circle {
  transition: none !important;
}
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__indeterminate-circle-graphic,
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__spinner-layer,
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__indeterminate-container {
  animation: none !important;
}
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__indeterminate-container circle {
  stroke-dasharray: 0 !important;
}
@media (forced-colors: active) {
  .mat-mdc-progress-spinner .mdc-circular-progress__indeterminate-circle-graphic,
  .mat-mdc-progress-spinner .mdc-circular-progress__determinate-circle {
    stroke: currentColor;
    stroke: CanvasText;
  }
}

.mat-progress-spinner-reduced-motion {
  --mat-progress-spinner-animation-multiplier: 1.25;
}

.mdc-circular-progress__determinate-container,
.mdc-circular-progress__indeterminate-circle-graphic,
.mdc-circular-progress__indeterminate-container,
.mdc-circular-progress__spinner-layer {
  position: absolute;
  width: 100%;
  height: 100%;
}

.mdc-circular-progress__determinate-container {
  transform: rotate(-90deg);
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__determinate-container {
  opacity: 0;
}

.mdc-circular-progress__indeterminate-container {
  font-size: 0;
  letter-spacing: 0;
  white-space: nowrap;
  opacity: 0;
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__indeterminate-container {
  opacity: 1;
  animation: mdc-circular-progress-container-rotate calc(1568.2352941176ms * var(--mat-progress-spinner-animation-multiplier)) linear infinite;
}

.mdc-circular-progress__determinate-circle-graphic,
.mdc-circular-progress__indeterminate-circle-graphic {
  fill: transparent;
}

.mat-mdc-progress-spinner .mdc-circular-progress__determinate-circle,
.mat-mdc-progress-spinner .mdc-circular-progress__indeterminate-circle-graphic {
  stroke: var(--mat-progress-spinner-active-indicator-color, var(--mat-sys-primary));
}
@media (forced-colors: active) {
  .mat-mdc-progress-spinner .mdc-circular-progress__determinate-circle,
  .mat-mdc-progress-spinner .mdc-circular-progress__indeterminate-circle-graphic {
    stroke: CanvasText;
  }
}

.mdc-circular-progress__determinate-circle {
  transition: stroke-dashoffset 500ms cubic-bezier(0, 0, 0.2, 1);
}

.mdc-circular-progress__gap-patch {
  position: absolute;
  top: 0;
  left: 47.5%;
  box-sizing: border-box;
  width: 5%;
  height: 100%;
  overflow: hidden;
}

.mdc-circular-progress__gap-patch .mdc-circular-progress__indeterminate-circle-graphic {
  left: -900%;
  width: 2000%;
  transform: rotate(180deg);
}
.mdc-circular-progress__circle-clipper .mdc-circular-progress__indeterminate-circle-graphic {
  width: 200%;
}
.mdc-circular-progress__circle-right .mdc-circular-progress__indeterminate-circle-graphic {
  left: -100%;
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__circle-left .mdc-circular-progress__indeterminate-circle-graphic {
  animation: mdc-circular-progress-left-spin calc(1333ms * var(--mat-progress-spinner-animation-multiplier)) cubic-bezier(0.4, 0, 0.2, 1) infinite both;
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__circle-right .mdc-circular-progress__indeterminate-circle-graphic {
  animation: mdc-circular-progress-right-spin calc(1333ms * var(--mat-progress-spinner-animation-multiplier)) cubic-bezier(0.4, 0, 0.2, 1) infinite both;
}

.mdc-circular-progress__circle-clipper {
  display: inline-flex;
  position: relative;
  width: 50%;
  height: 100%;
  overflow: hidden;
}

.mdc-circular-progress--indeterminate .mdc-circular-progress__spinner-layer {
  animation: mdc-circular-progress-spinner-layer-rotate calc(5332ms * var(--mat-progress-spinner-animation-multiplier)) cubic-bezier(0.4, 0, 0.2, 1) infinite both;
}

@keyframes mdc-circular-progress-container-rotate {
  to {
    transform: rotate(360deg);
  }
}
@keyframes mdc-circular-progress-spinner-layer-rotate {
  12.5% {
    transform: rotate(135deg);
  }
  25% {
    transform: rotate(270deg);
  }
  37.5% {
    transform: rotate(405deg);
  }
  50% {
    transform: rotate(540deg);
  }
  62.5% {
    transform: rotate(675deg);
  }
  75% {
    transform: rotate(810deg);
  }
  87.5% {
    transform: rotate(945deg);
  }
  100% {
    transform: rotate(1080deg);
  }
}
@keyframes mdc-circular-progress-left-spin {
  from {
    transform: rotate(265deg);
  }
  50% {
    transform: rotate(130deg);
  }
  to {
    transform: rotate(265deg);
  }
}
@keyframes mdc-circular-progress-right-spin {
  from {
    transform: rotate(-265deg);
  }
  50% {
    transform: rotate(-130deg);
  }
  to {
    transform: rotate(-265deg);
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&r.\u0275setClassMetadata(c,[{type:r.Component,args:[{selector:"mat-progress-spinner, mat-spinner",exportAs:"matProgressSpinner",host:{role:"progressbar",class:"mat-mdc-progress-spinner mdc-circular-progress",tabindex:"-1","[class]":'"mat-" + color',"[class._mat-animation-noopable]":"_noopAnimations","[class.mdc-circular-progress--indeterminate]":'mode === "indeterminate"',"[style.width.px]":"diameter","[style.height.px]":"diameter","[style.--mat-progress-spinner-size]":'diameter + "px"',"[style.--mat-progress-spinner-active-indicator-width]":'diameter + "px"',"[attr.aria-valuemin]":"0","[attr.aria-valuemax]":"100","[attr.aria-valuenow]":'mode === "determinate" ? value : null',"[attr.mode]":"mode"},changeDetection:r.ChangeDetectionStrategy.OnPush,encapsulation:r.ViewEncapsulation.None,imports:[a.NgTemplateOutlet],template:`<ng-template #circle>
  <svg [attr.viewBox]="_viewBox()" class="mdc-circular-progress__indeterminate-circle-graphic"
       xmlns="http://www.w3.org/2000/svg" focusable="false">
    <circle [attr.r]="_circleRadius()"
            [style.stroke-dasharray.px]="_strokeCircumference()"
            [style.stroke-dashoffset.px]="_strokeCircumference() / 2"
            [style.stroke-width.%]="_circleStrokeWidth()"
            cx="50%" cy="50%"/>
  </svg>
</ng-template>

<!--
  All children need to be hidden for screen readers in order to support ChromeVox.
  More context in the issue: https://github.com/angular/components/issues/22165.
-->
<div class="mdc-circular-progress__determinate-container" aria-hidden="true" #determinateSpinner>
  <svg [attr.viewBox]="_viewBox()" class="mdc-circular-progress__determinate-circle-graphic"
       xmlns="http://www.w3.org/2000/svg" focusable="false">
    <circle [attr.r]="_circleRadius()"
            [style.stroke-dasharray.px]="_strokeCircumference()"
            [style.stroke-dashoffset.px]="_strokeDashOffset()"
            [style.stroke-width.%]="_circleStrokeWidth()"
            class="mdc-circular-progress__determinate-circle"
            cx="50%" cy="50%"/>
  </svg>
</div>
<!--TODO: figure out why there are 3 separate svgs-->
<div class="mdc-circular-progress__indeterminate-container" aria-hidden="true">
  <div class="mdc-circular-progress__spinner-layer">
    <div class="mdc-circular-progress__circle-clipper mdc-circular-progress__circle-left">
      <ng-container [ngTemplateOutlet]="circle"></ng-container>
    </div>
    <div class="mdc-circular-progress__gap-patch">
      <ng-container [ngTemplateOutlet]="circle"></ng-container>
    </div>
    <div class="mdc-circular-progress__circle-clipper mdc-circular-progress__circle-right">
      <ng-container [ngTemplateOutlet]="circle"></ng-container>
    </div>
  </div>
</div>
`,styles:[`.mat-mdc-progress-spinner {
  --mat-progress-spinner-animation-multiplier: 1;
  display: block;
  overflow: hidden;
  line-height: 0;
  position: relative;
  direction: ltr;
  transition: opacity 250ms cubic-bezier(0.4, 0, 0.6, 1);
}
.mat-mdc-progress-spinner circle {
  stroke-width: var(--mat-progress-spinner-active-indicator-width, 4px);
}
.mat-mdc-progress-spinner._mat-animation-noopable, .mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__determinate-circle {
  transition: none !important;
}
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__indeterminate-circle-graphic,
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__spinner-layer,
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__indeterminate-container {
  animation: none !important;
}
.mat-mdc-progress-spinner._mat-animation-noopable .mdc-circular-progress__indeterminate-container circle {
  stroke-dasharray: 0 !important;
}
@media (forced-colors: active) {
  .mat-mdc-progress-spinner .mdc-circular-progress__indeterminate-circle-graphic,
  .mat-mdc-progress-spinner .mdc-circular-progress__determinate-circle {
    stroke: currentColor;
    stroke: CanvasText;
  }
}

.mat-progress-spinner-reduced-motion {
  --mat-progress-spinner-animation-multiplier: 1.25;
}

.mdc-circular-progress__determinate-container,
.mdc-circular-progress__indeterminate-circle-graphic,
.mdc-circular-progress__indeterminate-container,
.mdc-circular-progress__spinner-layer {
  position: absolute;
  width: 100%;
  height: 100%;
}

.mdc-circular-progress__determinate-container {
  transform: rotate(-90deg);
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__determinate-container {
  opacity: 0;
}

.mdc-circular-progress__indeterminate-container {
  font-size: 0;
  letter-spacing: 0;
  white-space: nowrap;
  opacity: 0;
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__indeterminate-container {
  opacity: 1;
  animation: mdc-circular-progress-container-rotate calc(1568.2352941176ms * var(--mat-progress-spinner-animation-multiplier)) linear infinite;
}

.mdc-circular-progress__determinate-circle-graphic,
.mdc-circular-progress__indeterminate-circle-graphic {
  fill: transparent;
}

.mat-mdc-progress-spinner .mdc-circular-progress__determinate-circle,
.mat-mdc-progress-spinner .mdc-circular-progress__indeterminate-circle-graphic {
  stroke: var(--mat-progress-spinner-active-indicator-color, var(--mat-sys-primary));
}
@media (forced-colors: active) {
  .mat-mdc-progress-spinner .mdc-circular-progress__determinate-circle,
  .mat-mdc-progress-spinner .mdc-circular-progress__indeterminate-circle-graphic {
    stroke: CanvasText;
  }
}

.mdc-circular-progress__determinate-circle {
  transition: stroke-dashoffset 500ms cubic-bezier(0, 0, 0.2, 1);
}

.mdc-circular-progress__gap-patch {
  position: absolute;
  top: 0;
  left: 47.5%;
  box-sizing: border-box;
  width: 5%;
  height: 100%;
  overflow: hidden;
}

.mdc-circular-progress__gap-patch .mdc-circular-progress__indeterminate-circle-graphic {
  left: -900%;
  width: 2000%;
  transform: rotate(180deg);
}
.mdc-circular-progress__circle-clipper .mdc-circular-progress__indeterminate-circle-graphic {
  width: 200%;
}
.mdc-circular-progress__circle-right .mdc-circular-progress__indeterminate-circle-graphic {
  left: -100%;
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__circle-left .mdc-circular-progress__indeterminate-circle-graphic {
  animation: mdc-circular-progress-left-spin calc(1333ms * var(--mat-progress-spinner-animation-multiplier)) cubic-bezier(0.4, 0, 0.2, 1) infinite both;
}
.mdc-circular-progress--indeterminate .mdc-circular-progress__circle-right .mdc-circular-progress__indeterminate-circle-graphic {
  animation: mdc-circular-progress-right-spin calc(1333ms * var(--mat-progress-spinner-animation-multiplier)) cubic-bezier(0.4, 0, 0.2, 1) infinite both;
}

.mdc-circular-progress__circle-clipper {
  display: inline-flex;
  position: relative;
  width: 50%;
  height: 100%;
  overflow: hidden;
}

.mdc-circular-progress--indeterminate .mdc-circular-progress__spinner-layer {
  animation: mdc-circular-progress-spinner-layer-rotate calc(5332ms * var(--mat-progress-spinner-animation-multiplier)) cubic-bezier(0.4, 0, 0.2, 1) infinite both;
}

@keyframes mdc-circular-progress-container-rotate {
  to {
    transform: rotate(360deg);
  }
}
@keyframes mdc-circular-progress-spinner-layer-rotate {
  12.5% {
    transform: rotate(135deg);
  }
  25% {
    transform: rotate(270deg);
  }
  37.5% {
    transform: rotate(405deg);
  }
  50% {
    transform: rotate(540deg);
  }
  62.5% {
    transform: rotate(675deg);
  }
  75% {
    transform: rotate(810deg);
  }
  87.5% {
    transform: rotate(945deg);
  }
  100% {
    transform: rotate(1080deg);
  }
}
@keyframes mdc-circular-progress-left-spin {
  from {
    transform: rotate(265deg);
  }
  50% {
    transform: rotate(130deg);
  }
  to {
    transform: rotate(265deg);
  }
}
@keyframes mdc-circular-progress-right-spin {
  from {
    transform: rotate(-265deg);
  }
  50% {
    transform: rotate(-130deg);
  }
  to {
    transform: rotate(-265deg);
  }
}
`]}]}],()=>[],{color:[{type:r.Input}],_determinateCircle:[{type:r.ViewChild,args:["determinateSpinner"]}],mode:[{type:r.Input}],value:[{type:r.Input,args:[{transform:r.numberAttribute}]}],diameter:[{type:r.Input,args:[{transform:r.numberAttribute}]}],strokeWidth:[{type:r.Input,args:[{transform:r.numberAttribute}]}]});const _=c;class m{static \u0275fac=function(t){return new(t||m)};static \u0275mod=r.\u0275\u0275defineNgModule({type:m});static \u0275inj=r.\u0275\u0275defineInjector({imports:[o.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&r.\u0275setClassMetadata(m,[{type:r.NgModule,args:[{imports:[c,_],exports:[c,_,o.BidiModule]}]}],null,null)}}]);
