using Microsoft.AspNetCore.Mvc;
using Sfaketify.Models;
using Sfaketify.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sfaketify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistController(IPlaylistRepository playlistRepository) {
            _playlistRepository = playlistRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllPlaylists()
        {
            
                var playlists = await _playlistRepository.GetAllPlaylistsAsync();

                var result = playlists.Select(playlist => new
                {
                    playlist.PlaylistId,
                    playlist.Name,
                    TotalTracks = playlist.Tracks.Count()
                });

                return Ok(result);
        }

        [HttpGet("{playlistId}")]
        public async Task<IActionResult> GetPlaylistById(long playlistId)
        {
            var playlist = await _playlistRepository.GetPlaylistByIdAsync(playlistId);
            if (playlist == null)
            {
                return NotFound();
            }
            var result = new
            {
                playlist.PlaylistId,
                playlist.Name,
                Tracks = playlist.Tracks.SelectMany(album => playlist.Tracks)
                        .Select(track => new
                        {
                            track.Name,
                            track.Composer
                        }).ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlaylist(Playlist playlist)
        {
            var result = await _playlistRepository.AddPlaylistAsync(playlist);
            return Ok(result);
        }
    }
}
