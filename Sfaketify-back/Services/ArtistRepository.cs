using Sfaketify.Models;
using Microsoft.EntityFrameworkCore;

namespace Sfaketify.Services
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly AlbumDbContext _dbContext;
        public ArtistRepository(AlbumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            var artists = await _dbContext.Artists
                .Include(a => a.Albums)
                .ToListAsync();

            return artists;
        }

        public async Task<Artist> GetArtistByIdAsync(long artistId)
        {
            return await _dbContext.Artists.Include(x => x.Albums).FirstOrDefaultAsync(a => a.ArtistId == artistId);
        }

        public async Task AddArtistAsync(Artist artist)
        {
            _dbContext.Artists.Add(artist);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            _dbContext.Artists.Update(artist);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteArtistAsync(long artistId)
        {
            var artist = await GetArtistByIdAsync(artistId);
            if (artist != null)
            {
                _dbContext.Artists.Remove(artist);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
