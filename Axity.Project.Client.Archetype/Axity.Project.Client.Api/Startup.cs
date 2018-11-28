using Axity.Project.infrastructure.Persistence;
using Axity.Project.Services.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Axity.Project.Client.Api
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

            services.AddServices(Configuration);

            //var connection = @"Server=192.168.0.16;Database=ArchetypeDB;user id=sa;password=solmary150183";
            var connection = @"server=localhost;User Id=root;Password=;Database=test";
            services.AddDbContext<Context>
                (options => options.UseMySql(connection));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Api Archetype",
                    Description = "Arquetipo de servicio Api NetCore",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Alejandro Ojeda",
                        Email = "alejandro.ojeda@axity.com",
                        Url = "https://twitter.com/snop_shot"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Archetype");
            });
            app.UseMvc();
        }
    }
}
