
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ms_common_model.nonFinanceLog;
using producer_2_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace producer_2._1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddMassTransit(x =>
            {
               
                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
                {
                    c.Host(Configuration["RabbitMQ:HostUrl"]);
                    c.ConfigureEndpoints(context);
                  
                }));
                x.AddRequestClient<NonFinanceLogRequest>();
            });

            //services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            //services.AddSingleton<IHostedService, BusService>();
            //bus.Start();

            //bus.Publish(new NonFinanceLogRequest { CIF = "123" });



            //----------------------------------------------------------




            //services.AddMassTransit(x =>
            //{
            //    x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
            //    {
            //        c.Host(Configuration["RabbitMQ:HostUrl"]);
            //        c.ConfigureEndpoints(context);
            //    }));
            //    x.AddRequestClient<NonFinanceLogRequest>(TimeSpan.FromSeconds(80));
            //});



            //services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            //services.AddSingleton<IHostedService, BusService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
