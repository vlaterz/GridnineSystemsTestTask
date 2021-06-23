using System;
using System.Collections.Generic;
using System.Linq;
using Gridnine.FlightCodingTest;

namespace GridNineSis.Code
{
    static class ListOfFlightsExtensions
    {
        /// <summary>
        /// Правило, которое отсортировывает полеты у которых вылет до текущего момента времени
        /// </summary>
        /// <typeparam name="T">Flight</typeparam>
        /// <param name="flights">Flights</param>
        /// <returns></returns>
        public static IList<T> ApplyOldFlightExcludeRule<T>(this IList<T> flights) where T : Flight
        {
            (flights as List<T>)?.RemoveAll(a => a.Segments[0].DepartureDate < DateTime.Now);
            return flights;
        }

        /// <summary>
        /// Правило, которое отсортировывает полеты у которых имеются сегменты с датой прилёта раньше даты вылета
        /// </summary>
        /// <typeparam name="T">Flight</typeparam>
        /// <param name="flights">Flights</param>
        /// <returns></returns>
        public static IList<T> ApplyFlyTimeErrorExcludeRule<T>(this IList<T> flights) where T : Flight
        {
            (flights as List<T>)?.RemoveAll(a => a.Segments.All(b => b.DepartureDate > b.ArrivalDate));
            return flights;
        }

        /// <summary>
        /// Правило, которое отсортировывает полеты у которых
        /// общее время, проведённое на земле превышает два часа
        /// (время на земле — это интервал между прилётом одного сегмента и вылетом следующего за ним)
        /// </summary>
        /// <typeparam name="T">Flight</typeparam>
        /// <param name="flights">Flights</param>
        /// <returns></returns>
        public static IList<T> ApplyStayTimeErrorExcludeRule<T>(this IList<T> flights) where T : Flight
        {
            (flights as List<T>)?.RemoveAll(a =>
            {
                for (var i = 0; i < a.Segments.Count - 1; i++)
                    if (a.Segments[i + 1].DepartureDate - a.Segments[i].ArrivalDate >= TimeSpan.FromHours(2))
                        return true;
                return false;
            });
            return flights;
        }
    }
}
