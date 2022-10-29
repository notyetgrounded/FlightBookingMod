namespace EuroTrip2.ModelView
{
    public class MakeBookingView
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int TripId { get; set; }
        public List<PassengerView> Passengers { get; set; }
    }
}
