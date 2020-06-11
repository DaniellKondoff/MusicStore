using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Models.ArtistViewModels;
using MusicStoreWeb.Services.Contracts;
using System.Threading.Tasks;

namespace MusicStoreWeb.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public async Task<IActionResult> ListAll(int page = 1)
        {
            var allArtist = await this.artistService.AllAsync(page);

            return View(new ArtistListingViewModel
            {
                AllArtists = allArtist,
                TotalArtists = await this.artistService.TotalAsync(),
                CurrentPage = page
            });
        }
    }
}
