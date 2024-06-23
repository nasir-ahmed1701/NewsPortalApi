using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Api.Models;
using NewsPortal.Business.IServices;
using NewsPortal.Business.Services;
using NewsPortal.Business.Validators;
using NewsPortal.Data;
using NewsPortal.Data.IRepositories;
using NewsPortal.Data.Repositories;

namespace NewsPortal.Api.Helpers
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ArticleService));
            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<NewsPortalDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, CorsConfiguration corsConfiguration)
        {
            if (corsConfiguration is null)
            {
                throw new ArgumentNullException(nameof(corsConfiguration));
            }


            services.AddCors(options =>
            {
                options.AddPolicy(name: corsConfiguration.PolicyName, builder =>
                {
                    builder.WithOrigins(corsConfiguration.AllowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<GetAllArticlesRequestValidator>();
            return services;
        }

    }
}
