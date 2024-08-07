using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Business.Abstract;
using Business.Concrete;
using System;
using System.Windows.Forms;

namespace ControlUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create the host for dependency injection and background service
            var host = CreateHostBuilder().Build();

            // Run the background services
            host.StartAsync();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Create a scope to resolve the main form and run the application
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var initialForm = services.GetRequiredService<InitialForm>();
                Application.Run(initialForm);
            }

            // Stop the background services when the application exits
            host.StopAsync().Wait();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Register your services and background service
                    services.AddSingleton<ICpuService, CpuManager>();
                    services.AddSingleton<IRamService, RamManager>();
                    services.AddSingleton<IDriveService, DriveManager>();
                    services.AddSingleton<IUserService, UserManager>();
                    services.AddSingleton<InitialForm>();

                    services.AddHostedService<Business.Concrete.BackgroundService>();
                });
    }
}
