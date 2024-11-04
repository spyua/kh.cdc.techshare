namespace sample.code.service.PoorInject.Sample
{
    public class PaymentServiceInjectWithProperty
    {
        public ILogger Logger { get; set; }  // 屬性注入

        public void GenerateReport(string reportContent)
        {
            Logger?.Log("Generating report...");
            Console.WriteLine($"Report: {reportContent}");
            Logger?.Log("Report generated.");
        }
    }

    /* Context usage sample
     // 使用範例
        public class Program
        {
            public static void Main(string[] args)
            {
                ReportService reportService = new ReportService();

                // 設置 Logger 依賴
                reportService.Logger = new ConsoleLogger();
        
                reportService.GenerateReport("Annual Sales Report");
            }
        } 
     */
}
