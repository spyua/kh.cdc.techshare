namespace sample.code.di.PoorInject.Sample
{
    public class PaymentServiceInjectWithConstruct
    {
        private readonly ILogger _logger;

        // 建構子注入 ILogger 介面
        public PaymentService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void ProcessPayment(decimal amount)
        {
            _logger.Log($"Processing payment of {amount}.");
            Console.WriteLine("Payment processed.");
        }
    }


    /* Context usage sample
    // 使用範例
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            PaymentService paymentService = new PaymentService(logger);

            paymentService.ProcessPayment(100.50m);
        }
    }
    */
}
