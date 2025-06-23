using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MusicWebAPI.Controllers
{
    public class TracksController : ControllerBase
    {
        private readonly MusicContext _context;

        public TracksController(MusicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddTrack([FromBody] TrackDto trackDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (trackDto == null)
            {
                return BadRequest("Track data is required.");
            }
            var track = new Track
            {
                Name = trackDto.Name,
                Artist = trackDto.Artist,
                Album = trackDto.Album,
                Duration = trackDto.Duration,
                Genre = trackDto.Genre, // Default value, can be modified later
                ReleaseDate = DateTime.UtcNow // Set to current date and time
            };
            _context.Track.Add(track);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrackById), new { id = track.Id }, track);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackById(int id)
        {
            var track = await _context.Track.FindAsync(id);

            if (track == null)
            {
                return NotFound("Sorry, track not found!");
            }

            return Ok(track);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTracks()
        {
            var tracks = await _context.Track.ToListAsync();
            if (tracks == null || !tracks.Any())
            {
                return NotFound("No tracks found.");
            }
            return Ok(tracks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await _context.Track.FindAsync(id);
            if (track == null)
            {
                return NotFound("Track not found.");
            }
            _context.Track.Remove(track);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
    //private readonly TracksController ()
}
