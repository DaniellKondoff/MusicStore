using MusicStoreWeb.Services.Models.Arists;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStoreWeb.Services.Contracts
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<IEnumerable<ArtistListingServiceModel>> FindAsync(string searchText);
    }
}
