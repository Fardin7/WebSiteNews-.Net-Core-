using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interface;
using Service.Service;
using DAL;
using Model;
using Repository.Inerface;
using Repository.Repository;
using Microsoft.AspNetCore.Authorization;
using Site.CustomAuthorization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Site
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

            services.AddDbContext<Context>(options =>
                    options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
             //services.AddDistributedMemoryCache();
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSession(

            options =>
            {
                options.IdleTimeout = System.TimeSpan.FromMinutes(6);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }
            );



            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();

           // services.Add(new ServiceDescriptor(typeof(IUnitOfWork), new UnitOfWork(null)));
         
            //services.AddSingleton<UserManager<ApplicationUser>, ApplicationUserManager>();
            // services.AddSingleton<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            services.AddTransient<INewsService, NewsService>();

            services.AddTransient<Iservice<News>, GenericService<News>>();
            services.AddTransient<IRepository<News>, GenericRepository<News>>();
            services.AddTransient<Iservice<Category>, GenericService<Category>>();
            services.AddTransient<IRepository<Category>, GenericRepository<Category>>();

            services.AddTransient<Iservice<NewsFile>, GenericService<NewsFile>>();
            services.AddTransient<IRepository<NewsFile>, GenericRepository<NewsFile>>();
            services.AddTransient<INewsFileService, NewsFileService>();
            services.AddTransient<INewsFileRepository, NewsFileRepository>();
            services.AddTransient<Iservice<Subcategory>, GenericService<Subcategory>>();
            services.AddTransient<IRepository<Subcategory>, GenericRepository<Subcategory>>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISubCategoryService, SubCategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();

            services.AddTransient<Iservice<Comment>, GenericService<Comment>>();
            services.AddTransient<IRepository<Comment>, GenericRepository<Comment>>();

            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddTransient<Iservice<NewsLetter>, GenericService<NewsLetter>>();
            services.AddTransient<IRepository<NewsLetter>, GenericRepository<NewsLetter>>();

            services.AddTransient<INewsLetterService, NewsLetterService>();
            services.AddTransient<INewsLetterRepository, NewsLetterRepository>();

            services.AddTransient<Iservice<Contact>, GenericService<Contact>>();
            services.AddTransient<IRepository<Contact>, GenericRepository<Contact>>();

            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddTransient<Iservice<NewsSubCategory>, GenericService<NewsSubCategory>>();
            services.AddTransient<IRepository<NewsSubCategory>, GenericRepository<NewsSubCategory>>();
            services.AddTransient<Iservice<NewsCategory>, GenericService<NewsCategory>>();
            services.AddTransient<IRepository<NewsCategory>, GenericRepository<NewsCategory>>();
            services.AddTransient<INewsCategoryService, NewsCategoryService>();
            services.AddTransient<INewsSubCategoryService, NewsSubCategoryService>();
            services.AddTransient<INewsCategoryRepository, NewsCategoryRepository>();
            services.AddTransient<INewsSubCategoryRepository, NewsSubCategoryRepository>();

            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
           
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "AdminArea",
                areaName: "admin",
                pattern: "admin/{controller=Home}/{action=Index}/{id?}"                
                );

                endpoints.MapControllerRoute(
                      "newsofallnewscategory",
                      "همه دسته بندی ها-{type}-{newscount}",
                       new { controller = "NewsCategory", action = "IndexNewsOfNewsCategory" }

                  );

                endpoints.MapControllerRoute(
                            "news",
                            "{cattegory}-{newscattegory}-{id}-{type}",
                             new { controller = "News", action = "Details" }
                        );
                endpoints.MapControllerRoute(
                            "newsofnewscategory",
                            " سرار جهان-{type}-{newscategoryname}",
                             new { controller = "News", action = "Index" }
                        );
                endpoints.MapControllerRoute(
                              "newsofcategory",
                              "دسته های خبری-{type}-{categoryname}",
                               new { controller = "News", action = "Index" }
                          );


                endpoints.MapControllerRoute(
                            "newsofnewscategoryandcategory",
                            "{type}-{categoryname}-{newscategoryname}",
                             new { controller = "News", action = "Index", categoryname =string.Empty, newscategoryname = string.Empty }
                        );

                endpoints.MapControllerRoute(
                            "contactus",
                            "تماس با ما",
                             new { controller = "Contact", action = "Index" }
                        );
                endpoints.MapControllerRoute(
                           "aboutus",
                           "درباره ما",
                            new { controller = "AboutUs", action = "Index" }
                           
                       );



                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");



        //        endpoints.MapControllerRoute("blog_route", "Manage/{controller}/{action}/{id?}",
        //defaults: new { area = "Blog" }, constraints: new { area = "Blog" });
        //        endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
