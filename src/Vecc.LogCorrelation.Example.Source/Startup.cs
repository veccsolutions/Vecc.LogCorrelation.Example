using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vecc.LogCorrelation.Example.Source.Services;
using Vecc.LogCorrelation.Example.Source.Services.Internal;
using Vecc.LogCorrelation.Example.Source.Services.Middleware;

namespace Vecc.LogCorrelation.Example.Source
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
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions((options) => options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented);

            services.AddTransient<DefaultRequestIdMessageHandler>();
            services.AddHttpClient<TargetHeadersClient>((client) => client.BaseAddress = new System.Uri("https://localhost:44324"))
                .AddHttpMessageHandler<DefaultRequestIdMessageHandler>();

            services.AddHttpContextAccessor();
            services.AddTransient<ISessionIdAccessor, DefaultSessionIdAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<LogHeaderMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
