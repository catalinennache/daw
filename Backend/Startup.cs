using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        { services.AddControllers().AddNewtonsoftJson();
         //services.AddRepositories(); //aici voi adauga toate repo-urile
            //services.AddServices();//aici toate serviciile
            services.AddDbContext<ApplicationContext>(op => op.UseMySQL(Configuration.GetConnectionString("Default")));
            services.AddTransient<UserRepository>();
            services.AddTransient<ContactRepository>();
            services.AddTransient<MessageRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddCors(op =>
            {
                op.AddPolicy("All", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
         //Auto Mapper
            services.AddAutoMapper(typeof(Startup));
            
             //services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
            //}
    
           // app.UseHttpsRedirection();

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
