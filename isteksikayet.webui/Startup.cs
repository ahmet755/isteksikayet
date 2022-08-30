using isteksikayet.Business.Abstract;
using isteksikayet.Business.Concrete;
using isteksikayet.Data.Abstract;
using isteksikayet.Data.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isteksikayet.webui
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
            // add data
            services.AddScoped<IComplaintRepository, EfComplaintepository>();
            services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
            services.AddScoped<IComplaintReplyRepository, EfComplaintReplyRepository>();

            // add Business
            services.AddScoped<IComplaintService, ComplaintManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IComplaintReplyService, ComplaintReplyManager>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
