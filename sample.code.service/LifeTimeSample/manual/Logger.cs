using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.code.service.LifeTimeSample.manual
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        // 私有建構子，防止外部直接實例化
        private Logger() { }

        // 提供單例存取的靜態方法
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
