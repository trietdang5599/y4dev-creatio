Terrasoft.configuration.Structures["ModalUtils"] = {innerHierarchyStack: ["ModalUtils"]};
 define("ModalUtils", function() {
   Ext.define("Terrasoft.manager.ModalUtils", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.ModalUtils",
		singleton: true,

       disposeOverlay: function() {
           this.overlayRef?.dispose();
       },
       
       getModalContainer: function() {
           const disableUseOverlayFor7xModals = Terrasoft.Features.getIsEnabled('DisableUseOverlayFor7xModals');
           if (disableUseOverlayFor7xModals || !window.createOverlay) {
                return Ext.getBody();
            }
            this.overlayRef = window.createOverlay({
                hasBackdrop: true
            });
           return Ext.get(this.overlayRef.overlayElement);
       }
     });
     
   return Terrasoft.ModalUtils;
 });

