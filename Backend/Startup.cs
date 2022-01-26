using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Chatty.Data;
using Chatty.Core;
using Chatty.Utils;

namespace Chatty
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(op => op.UseMySQL(Configuration.GetConnectionString("Default")));
            services.AddScoped<UserRepository>();
            services.AddScoped<ContactRepository>();
            services.AddScoped<MessageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors(op => {
                op.AddPolicy("All", p => {
                        p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(op => op.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
