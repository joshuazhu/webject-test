using Application;
using Application.Interface;
using Application.Profile;
using AutoMapper;
using Infrastructure;
using Infrastructure.Interface;
using Infrastructure.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Webjet.Profile;

namespace Webjet
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
                x.AddProfile(new WebjetMappingProfile());
                x.AddProfile(new MappingProfile());
            });

            services.AddMemoryCache();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton(mappingConfig.CreateMapper());
            services.AddSingleton<IHttpClientService, HttpClientService>();
            services.AddSingleton<CinemaWorldService>();
            services.AddSingleton<FilmWorldService>();
            services.AddSingleton<IMovieService, MovieService>();

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

            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
