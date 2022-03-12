using Framework.Interfaces;
using Framework.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Framework.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var _serviceProvider = services.BuildServiceProvider();
            var numberService = _serviceProvider.GetService<INumberService>();

            System.Console.Clear();
            System.Console.WriteLine("Digite um número:");
            var read = System.Console.ReadLine();
            if (!int.TryParse(read, out int number) || number <= 0)
            {
                PrintResult($"O valor digitado não é válido. Valor digitado: {number}");
            }
            
            var task = numberService.Calculate(number);
            task.Wait();

            string resultFormated = $"Número de Entrada: {number}{Environment.NewLine}";
            resultFormated += $"Números Divisores: {string.Join(",", task.Result.Dividers)}{Environment.NewLine}";
            resultFormated += $"Divisores Primos: {string.Join(",", task.Result.Primes)}";

            PrintResult(resultFormated);
        }

        public static void PrintResult(string message)
        {
            System.Console.Clear();
            System.Console.WriteLine($"\r\n{message}");
            System.Console.Write("\r\nPressione Enter para sair");
            System.Console.ReadLine();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<INumberService, NumberService>();
        }
    }
}
