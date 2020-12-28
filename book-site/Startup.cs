using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_site.Data;
using book_site.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using book_site.Data.Repository;
using book_site.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace book_site
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("DBSettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<DBObjects>();
            services.AddTransient<IBooks, BooksRepository>();
            services.AddTransient<IBooksAuthor, AuthorRepository>();
            services.AddTransient<IBooksGenre, GenreRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IAdress, AdressRepository>();
            services.AddTransient<IReviews, ReviewsRepository>();
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDBContent>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                //настройки требований к паролю
                //Обязательность использования цифр
                opt.Password.RequireDigit = false;

                //Минимальная длинна пароля
                opt.Password.RequiredLength = 3;

                //Обязательность использования неалфавитных символов
                opt.Password.RequireNonAlphanumeric = false;

                //Настройка требований к пользователю
                //Уникальность почты
                opt.User.RequireUniqueEmail = false;

                //Настройка правил блокировки пользователей
                //Все пользователи изначально разблокированы
                opt.Lockout.AllowedForNewUsers = true;

                //Максимальное количество попыток ввода пароля
                opt.Lockout.MaxFailedAccessAttempts = 10;

                //Время блокировки аккаунта
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.ConfigureApplicationCookie(opt =>
            {
                //Настройка Cookie
                //Имя
                opt.Cookie.Name = "Book-site";

                //Протокол передачи данных
                opt.Cookie.HttpOnly = true;

                //Время жизни Cookie-файлов
                //opt.Cookie.Expiration= TimeSpan.FromDays(10);
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                //Перенаправление пользователя на страницу входа при посещении страниц для авторизованных пользователей
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";

                //Перенаправление на страницу при отказе в доступе
                opt.AccessDeniedPath = "/Account/AccessDenied";

                //Изменение идентификатора сессии при авторизации пользователя
                opt.SlidingExpiration = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(obj => ShopBasket.GetBasket(obj));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, book_site.Data.DBObjects dB)
        {
            dB.Initial();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "category", template: "Catalog/{action}/{filter?}", defaults: new { controller = "Catalog", action = "Books" });
                
            });
        }
    }
}
