//using EuroTrip2.Contexts;
//using EuroTrip2.Models;

//namespace EuroTrip2.ManagementLayer
//{
//    public class AdminOperations: IAdminOperationsRepository
//    {
//        protected FlightDBContext _context;
//        public AdminOperations(FlightDBContext context)
//        {
//            _context = context;
//        }
//        public Flight GetFlight(int id)
//        {
//            return _context.Flights.FirstOrDefault(x => x.Id == id);
//        }
//        public Flight CreateFlight(Flight flight)
//        {
//            _context.Flights.Add(flight);
//            return flight;
//        }
//        public Flight 
//    }
//}
