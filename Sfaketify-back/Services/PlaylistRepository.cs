using Sfaketify.Models;
using Microsoft.EntityFrameworkCore;

namespace Sfaketify.Services
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly AlbumDbContext _dbContext;

        public PlaylistRepository(AlbumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Playlist> AddPlaylistAsync(Playlist playlist)
        {
            playlist.PlaylistId = _dbContext.Playlists.OrderByDescending(x => x.PlaylistId).FirstOrDefault().PlaylistId + 1;
            _dbContext.Playlists.Add(playlist);
            await _dbContext.SaveChangesAsync();
            return playlist;
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
        {
            var playslits = await _dbContext.Playlists.Include(p => p.Tracks)
                .ToListAsync();

            return playslits;
        }

        public async Task<Playlist> GetPlaylistByIdAsync(long playlistId)
        {
            return await _dbContext.Playlists.Include(x => x.Tracks).FirstOrDefaultAsync(a => a.PlaylistId == playlistId);
        }
    }
}
