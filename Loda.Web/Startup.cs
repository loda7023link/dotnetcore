using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loda.BLL.Implements;
using Loda.BLL.Interfaces;
using Loda.DAL.Implements;
using Loda.DAL.Interfaces;
using Loda.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Loda.Web
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
            // 配置数据库实体依赖注入
            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));

            DIRegister(services);

            services.AddMvc();
        }

        // 配置依赖注入映射关系
        public void DIRegister(IServiceCollection services)
        {

            services.AddTransient(typeof(IDalService<>), typeof(DalService<>));

            services.AddTransient(typeof(IDT_UserService), typeof(DT_UserService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
}
