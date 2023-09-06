using Sfaketify.Models;
using Microsoft.EntityFrameworkCore;

namespace Sfaketify.Services
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AlbumDbContext _dbContext;
        public AlbumRepository(AlbumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            var albums = await _dbContext.Albums
                .ToListAsync();

            return albums;
        }

        public async Task<Album> GetAlbumByIdAsync(long albumId)
        {
            return await _dbContext.Albums.Include(x => x.Tracks).FirstOrDefaultAsync(a => a.AlbumId == albumId);
        }

        public async Task AddAlbumAsync(Album album)
        {
            _dbContext.Albums.Add(album);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            _dbContext.Albums.Update(album);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAlbumAsync(long albumId)
        {
            var album = await GetAlbumByIdAsync(albumId);
            if (album != null)
            {
                _dbContext.Albums.Remove(album);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
