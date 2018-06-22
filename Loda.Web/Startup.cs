using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loda.BLL.Implements;
using Loda.BLL.Interfaces;
using Loda.DAL.Implements;
using Loda.DAL.Interfaces;
using Loda.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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

            // 添加Bearer Jwt验证
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidIssuer = "localhost:4002", //跟GetToken中一样
                        ValidAudience = "api",//跟GetToken中一样
                        ValidateIssuer = true, //是否验证Issuer
                        ValidateAudience = true, //是否验证Audience
                        ValidateLifetime = true,//验证失效时间
                        ValidateIssuerSigningKey = true,//验证签名
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SymmetricSecurityKey"]))//密钥
                    };
                });

            services.AddMvc();
        }

        // 配置依赖注入映射关系
        public void DIRegister(IServiceCollection services)
        {

            services.AddTransient(typeof(IDalService<>), typeof(DalService<>));

            services.AddTransient(typeof(IDT_UserService), typeof(DT_UserService));
        }

        public void BearerJwtConfigure()
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // 启用身份验证
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
}
