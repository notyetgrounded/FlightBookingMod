using System.Text.Json.Serialization;

namespace EuroTrip2.ModelView
{
    
    public class TripView
    {
        public int Id { get; set; }

        
        public string Name { get; set; }
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public string SourceName { get; set; }
        public string SourceIOTA { get; set; }
        public DateTime SourceTime { get; set; }
        public string DestinationName { get; set; }
        public string DestinationIOTA { get; set; }
        public DateTime DestinationTime { get; set; }
        public int Price { get; set; }
        public int PassengerCount { get; set; }
    }
}
