define("DeduplicationConstants", [], function() {
	return {
		serviceName: "DeduplicationService",
		findDuplicatesMethodName: "FindDuplicatesOnSave",
		setDuplicatesMethodName: "SetDuplicatesOnSave",
		features: {
			bulkDeduplication: "BulkESDeduplication",
			getIsLazyDuplicatesPageEnabled: function() {
				return Terrasoft.Features.getIsEnabled("BulkESDeduplication") 
					&& Terrasoft.Features.getIsEnabled("LazyLoadDeduplicationResult") 
			}
		}
	};
});
