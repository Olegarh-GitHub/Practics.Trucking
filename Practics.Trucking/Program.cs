using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practics.Trucking.Forms;
using System;
using Practics.Trucking.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practics.Trucking.Application.Services;
using System.IO;
using Practics.Trucking.Services;

namespace Practics.Trucking
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IConfiguration Configuration { get; set; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();

        public static void Configure(this IServiceCollection services)
        {
            services.AddAutoMapper(Configuration);
            services.AddEntityFrameworkCoreORM(Configuration);

            services.AddTransient<UserService>();
            services.AddTransient<ProducerService>();
            services.AddTransient<SessionService>();
            services.AddTransient<ProductService>();
            services.AddTransient<OrderService>();

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            services.Configure();

            var userService = ServiceProvider.GetRequiredService<UserService>();
            var producerService = ServiceProvider.GetRequiredService<ProducerService>();
            var sessionService = ServiceProvider.GetService<SessionService>();
            var productService = ServiceProvider.GetRequiredService<ProductService>();
            var orderService = ServiceProvider.GetRequiredService<OrderService>();

            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Login(userService, producerService, sessionService, productService, orderService));
        }
    }
}
