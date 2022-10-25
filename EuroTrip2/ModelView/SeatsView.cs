namespace EuroTrip2.ModelView
{
    public class SeatsView
    {
        public int TripId   { get; set; }
        public string TripName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }
        public IEnumerable<SeatStatus> Seats { get; set; }
    }
}
