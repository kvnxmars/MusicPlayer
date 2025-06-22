using Microsoft.AspNetCore.Mvc;

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
                Genre = "Unknown", // Default value, can be modified later
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
    }
    //private readonly TracksController ()
}
