// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using sample.code.service.LifeTimeSample;

Console.WriteLine("Hello, World!");

// 建立服務容器
var serviceCollection = new ServiceCollection();

// 設定生命週期（改成 AddSingleton 或 AddScoped 來比較）
serviceCollection.AddScoped<CounterService>();

var serviceProvider = serviceCollection.BuildServiceProvider();

// 模擬多個請求

var tasks = new Task[5];
for (int i = 0; i < 5; i++)
{
    tasks[i] = Task.Run(() =>
    {
        // 每個"請求"都從容器中獲取 CounterService
        var counterService = serviceProvider.GetService<CounterService>();
        var count = counterService.IncrementAndGet();
        Console.WriteLine($"Request {i + 1}: Count = {count}");
    });
}


/*
 // 模擬多個請求，每個請求都建立一個新的範圍
var tasks = new Task[5];
for (int i = 0; i < 5; i++)
{
    tasks[i] = Task.Run(() =>
    {
        // 使用 CreateScope 來模擬一個新的請求範圍
        using (var scope = serviceProvider.CreateScope())
        {
            var counterService = scope.ServiceProvider.GetService<CounterService>();
            var count = counterService.IncrementAndGet();
            Console.WriteLine($"Request {i + 1}: Count = {count}");
        }
    });
}
 */

// 等待所有請求完成
await Task.WhenAll(tasks);


