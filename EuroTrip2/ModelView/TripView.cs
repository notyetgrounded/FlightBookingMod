namespace EuroTrip2.ModelView
{
    public class TripView
    {
        public List<int> TripIds { get; set; } = new List<int>();
        public string FlightName { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public int stops { get; set; }

        public int Price { get; set; }
        public string Source { get; set; }
        public string SourceIOTA { get; set; }

        public string Destination { get; set; }
        public string DestinationIOTA { get; set; }
        public DateTime SourceTime { get; set; }
        public DateTime DestinationTime { get; set; }
        //public int Route_Id { get; set; }
    }
}
