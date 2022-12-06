using E_Commerce_CasaDoCodigo.Context;
using E_Commerce_CasaDoCodigo.Repositories.Cadastro;
using E_Commerce_CasaDoCodigo.Repositories.ItemPedido;
using E_Commerce_CasaDoCodigo.Repositories.Pedido;
using E_Commerce_CasaDoCodigo.Repositories.Pedido.Interface;
using E_Commerce_CasaDoCodigo.Repositories.Produto;
using E_Commerce_CasaDoCodigo.Repositories.Produto.Interface;
using E_Commerce_CasaDoCodigo.Services;
using E_Commerce_CasaDoCodigo.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace E_Commerce_CasaDoCodigo
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
            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();

            services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddTransient<IDataService, DataService>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Pedido}/{action=Carrossel}/{codigo?}");
            });

            // Garante que database sera criado ao executar a aplicacao
            serviceProvider.GetService<IDataService>().InicializaDb();
        }
    }
}
