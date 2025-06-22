namespace MusicWebAPI
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Duration { get; set; } // Duration in seconds
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow; // ISO 8601 format (e.g., "2023-10-01")
    }
}
