namespace Events.Api.Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Presenter { get; set; }
        public int Duration { get; set; }
        public string  Level { get; set; }
        public string Abstract { get; set; }
        public string[] Voters { get; set; }
        
    }
}