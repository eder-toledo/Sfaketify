using Sfaketify.Models;

namespace Sfaketify.Services
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();
        Task<Playlist> GetPlaylistByIdAsync(long playlistId);
        Task<Playlist> AddPlaylistAsync(Playlist playlist);
    }
}
