using CustomerInviter.Entities;

namespace CustomerInviter.Abstractions
{
    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculates the distance as km.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns></returns>
        double CalculateDistanceAsKm(Location from, Location to);
    }
}
