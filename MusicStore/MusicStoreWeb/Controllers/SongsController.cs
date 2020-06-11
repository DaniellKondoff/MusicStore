using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStoreWeb.Models.SongViewModels;
using MusicStoreWeb.Services.Contracts;
using System.Threading.Tasks;

namespace MusicStoreWeb.Controllers
{
    [Authorize]
    public class SongsController : Controller
    {
        private readonly ISongService songService;
        public SongsController(ISongService songService)
        {
            this.songService = songService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> ListAll(int page = 1)
        {
            var allSongs = await this.songService.AllAsync(page);

            return View(new SongListingViewModel
            {
                AllSongs = allSongs,
                CurrentPage = page,
                TotalSongs = await this.songService.TotalAsync()
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var song = await this.songService.DetailsAsync(id);

            if (song == null)
            {
                return BadRequest();
            }

            return View(song);
        }
    }
}
