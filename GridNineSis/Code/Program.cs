using System;
using Gridnine.FlightCodingTest;

namespace GridNineSis.Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new FlightBuilder();
            var flights = builder.GetFlights();
            var oldFlightslessFlights = builder.GetFlights().ApplyOldFlightExcludeRule();
            var timeErrorlessFlights = builder.GetFlights().ApplyFlyTimeErrorExcludeRule();
            var stayErrorlessFlights = builder.GetFlights().ApplyStayTimeErrorExcludeRule();
        }
    }
}
