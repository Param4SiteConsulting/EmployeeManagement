using EmployeeManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;

        }
                
        public void ConfigureServices(IServiceCollection services)
        {                  
            services.AddMvc().AddXmlDataContractSerializerFormatters();

            // Register services for dependency injection
            services.AddTransient<ISoapResponseService, SoapResponseService>();
            services.AddTransient<IJsonResponseService, JsonResponseService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env,
                              ILogger<Startup> logger)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {               
                endpoints.MapDefaultControllerRoute();               
            });



        }
    }
}
