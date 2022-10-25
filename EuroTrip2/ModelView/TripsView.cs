namespace EuroTrip2.ModelView
{
    public class TripsView
    {
        public string AirLines { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime SourceTime { get; set; }
        public DateTime DestinationTime { get; set; }

        public int Price { get; set; }
        public int Stops { get; set; }
        
        public IEnumerable<TripView> Trips { get; set; }
    }
}
