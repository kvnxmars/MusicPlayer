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
    }
    //private readonly TracksController ()
}
