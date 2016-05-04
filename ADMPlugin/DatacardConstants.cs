namespace ADMPlugin
{
    public class DatacardConstants
    {
        public static string DocumentsFolder = "documents";
        public static string PluginFolderAndExtension = "adm";
        public static string LoggedDataFile = "LoggedData{0}." + PluginFolderAndExtension;
        public static string GuidanceAllocationFile = "GuidanceAllocation{0}." + PluginFolderAndExtension;
        public static string PlanFile = "Plan{0}." + PluginFolderAndExtension;
        public static string RecommendationFile = "Recommendation{0}." + PluginFolderAndExtension;
        public static string WorkItemOperationFile = "WorkItemOperation{0}." + PluginFolderAndExtension;
        public static string WorkItemFile = "WorkItem{0}." + PluginFolderAndExtension;
        public static string WorkOrderFile = "WorkOrder{0}." + PluginFolderAndExtension;
        public static string SummariesFile = "Summaries." + PluginFolderAndExtension;
        public static string SectionFile = "Section{0}." + PluginFolderAndExtension;
        public static string MeterFile = "Meter{0}." + PluginFolderAndExtension;
        public static string OperationDataFile = "OperationData{0}." + PluginFolderAndExtension;
        public static string FileFormat = "{0}." + PluginFolderAndExtension;

        public static string ConvertToSearchPattern(string filePattern)
        {
            return filePattern.Replace("{0}", "*");
        }
    }
}