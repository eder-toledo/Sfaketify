using Microsoft.AspNetCore.Mvc;
using Sfaketify.Models;
using Sfaketify.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sfaketify.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var albums = await _albumRepository.GetAllAlbumsAsync();

            var result = albums.Select(a => new
            {
                a.AlbumId,
                a.Title,
                TotalTracks = a.Tracks.Count()
            });

            return Ok(result);
        }

        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetAlbumById(long albumId)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(albumId);
            if (album == null)
            {
                return NotFound();
            }

            var result = new
            {
                
                album.AlbumId,
                album.Title,
                Tracks = album.Tracks
                        .Select(track => new
                        {
                            track.TrackId,
                            track.Name
                        }).ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum(Album album)
        {
            await _albumRepository.AddAlbumAsync(album);
            return CreatedAtAction(nameof(GetAlbumById), new { albumId = album.AlbumId }, album);
        }

        [HttpPut("{artistId}")]
        public async Task<IActionResult> UpdateAlbum(long albumId, Album album)
        {
            if (albumId != album.ArtistId)
            {
                return BadRequest();
            }

            await _albumRepository.UpdateAlbumAsync(album);
            return NoContent();
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> DeleteArtist(long albumId)
        {
            await _albumRepository.DeleteAlbumAsync(albumId);
            return NoContent();
        }
    }
}
