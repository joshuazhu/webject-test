using Application;
using Application.Interface;
using Application.Profile;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interface;
using Swashbuckle.AspNetCore.Swagger;
using WebjectTest.Middleware;
using WebjectTest.Profile;

namespace WebjectTest
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Movie API", Version = "v1" });
            });

            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new ApplicationMappingProfile());
                x.AddProfile(new WebjetMappingProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ICinemaWorldService, CinemaWorldService>();
            services.AddSingleton<IFilmWorldService, FilmWorldService>();

            services.AddSingleton<ICinemaWorldRepository, CinemaWorldRepository>();
            services.AddSingleton<IFilmWorldRepository, FilmWorldRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API");
            });

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
            {
                appBuilder.UseMiddleware<AuthenticationMiddleware>();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
