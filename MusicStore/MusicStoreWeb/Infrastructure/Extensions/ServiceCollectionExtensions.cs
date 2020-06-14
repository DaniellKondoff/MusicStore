using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicStoreWeb.Areas.Admin.Services.Contracts;
using MusicStoreWeb.Areas.Admin.Services.Implementations;
using MusicStoreWeb.Data;
using MusicStoreWeb.Services.Contracts;
using MusicStoreWeb.Services.Implementation;

namespace MusicStoreWeb.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IArtistService, ArtistService>()
                .AddTransient<ISongService, SongService>()
                .AddTransient<IAlbumService, AlbumService>()
                .AddTransient<IAdminArtistService, AdminArtistService>()
                .AddTransient<IAdminSongService, AdminSongService>()
                .AddTransient<IAdminAlbumService, AdminAlbumService>()
                .AddTransient<IShoppingService, ShoppingService>()
                .AddSingleton<IShoppingCartManager, ShoppingCartManager>();

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MusicStoreDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                    .AddDbContext<MusicStoreDbContext>(options => options
                        .UseSqlServer(configuration.GetDefaultConnectionString()));
        }
    }
}
