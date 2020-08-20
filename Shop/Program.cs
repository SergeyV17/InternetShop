using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Shop
{
    /// <summary>
    /// Класс точки входа
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args">аргументы</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Метод создания хоста
        /// </summary>
        /// <param name="args">аргументы</param>
        /// <returns>хост</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
