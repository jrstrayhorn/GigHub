namespace GigHub.ViewModels
{
    public class GigDetailsViewModel
    {
        public string ArtistName { get; set; }
        public string ArtistId { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool UserFollowing { get; set; }
        public bool UserAttending { get; set; }
        public bool ShowActions { get; set; }
    }
}