using Sfaketify.Models;
using Sfaketify.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sfaketify
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _artistRepository.GetAllArtistsAsync();

            var result = artists.Select(playlist => new
            {
                playlist.ArtistId,
                playlist.Name,
                TotalAlbums = playlist.Albums.Count()
            });

            return Ok(result);
        }

        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetArtistById(long artistId)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(artistId);
            if (artist == null)
            {
                return NotFound();
            }

            var result = new
            {
                artist.ArtistId,
                artist.Name,
                Albums = artist.Albums
                        .Select(album => new
                        {
                            album.AlbumId,
                            album.Title
                        }).ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddArtist(Artist artist)
        {
            await _artistRepository.AddArtistAsync(artist);
            return CreatedAtAction(nameof(GetArtistById), new { artistId = artist.ArtistId }, artist);
        }

        [HttpPut("{artistId}")]
        public async Task<IActionResult> UpdateArtist(long artistId, Artist artist)
        {
            if (artistId != artist.ArtistId)
            {
                return BadRequest();
            }

            await _artistRepository.UpdateArtistAsync(artist);
            return NoContent();
        }

        [HttpDelete("{artistId}")]
        public async Task<IActionResult> DeleteArtist(long artistId)
        {
            await _artistRepository.DeleteArtistAsync(artistId);
            return NoContent();
        }
    }
}
