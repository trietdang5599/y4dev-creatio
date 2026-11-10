define("ConfActivityLogDiffRuntimeResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NoFilesTitle: "No files to compare",
		NoFilesMeta: "The selected log entry does not have comparable files.",
		NoOldContent: "No old file content.",
		NoNewContent: "No new file content.",
		NoChangedContent: "No changed file content.",
		ModeContentUnavailable: " content is not available for this log entry.",
		LargeContentTitle: "File is too large to compare",
		LargeContentMeta: "The selected file is too large to render safely in the browser.",
		LargeContentPane: "Content is too large to render.",
		Added: "Added",
		Removed: "Removed",
		Modified: "Modified",
		SourceCode: "Source code",
		Metadata: "Metadata",
		Descriptor: "Descriptor",
		EnterFullscreen: "Expand",
		ExitFullscreen: "Collapse",
		HiddenUnchangedLinesSuffix: " unchanged line(s) hidden ...",
		ModeNoFilesPrefix: "The selected log entry does not contain ",
		ModeNoFilesSuffix: " files.",
		OldLinesLabel: "old lines: ",
		NewLinesLabel: "new lines: ",
		PreviousVersion: "Previous version:",
		CurrentVersion: "Current version:",
		NoPreviousVersion: "No previous version",
		NoPreviousVersionDeletedDuringCleanup: "No previous version because it was deleted during old log cleanup"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});