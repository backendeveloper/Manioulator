using System;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommandLine;
using Common.Options;
using Contact.Dtos.Options;
using Data;
using Hangfire;
using Hangfire.MemoryStorage;
using Host.Services;
using Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Host
{
    public class Program
    {
        private static IContainer _container;

        private static void RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "DataDB"));
            services.AddHangfire(x => x.UseMemoryStorage());
            services.AddHangfireServer();
            
            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
            var builder = new ContainerBuilder();
            builder.RegisterModule<HostModule>();
            builder.RegisterType<ProductService>()?.As<IProductService>();
            builder.Populate(services);
            
            _container = builder.Build();
        }

        public static int Main(string[] args)
        {
            RegisterServices();
            
            string[] lines = File.ReadAllLines(args?[0] ?? throw new InvalidOperationException());

            foreach (string line in lines)
            {
                string[] commands = line.Split(' ');
                Console.WriteLine(line);

                IProductService productService = _container.Resolve<IProductService>();
                IOrderService orderService = _container.Resolve<IOrderService>();
                ICampaignService campaignService = _container.Resolve<ICampaignService>();

                Parser.Default.ParseArguments<CreateProductOptions, GetProductInfoOptions, CreateOrderOptions, CreateCampaignOptions, GetCampaignInfoOptions, IncreaseTimeOptions>(commands)
                    .MapResult(
                        (CreateProductOptions opts) => productService.CreateProduct(opts),
                        (GetProductInfoOptions opts) => productService.GetProduct(opts),
                        (CreateOrderOptions opts) => orderService.CreateOrder(opts),
                        (CreateCampaignOptions opts) => campaignService.CreateCampaign(opts),
                        (GetCampaignInfoOptions opts) => campaignService.GetCampaign(opts),
//                        (IncreaseTimeOptions opts) => IncreaseTime(opts),
                        errs => 1);
            }

            return 1;
        }
    }
}