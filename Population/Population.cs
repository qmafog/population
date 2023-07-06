using System;
#pragma warning disable

namespace PopulationTask
{
    public static class Population
    {
        /// <summary>
        /// Calculates the count of years which the town need to see its population greater or equal to currentPopulation inhabitants.
        /// </summary>
        /// <param name="initialPopulation">The population at the beginning of a year.</param>
        /// <param name="percent">The percentage of growth per year.</param>
        /// <param name="visitors">The visitors (new inhabitants per year) who come to live in the town.</param>
        /// <param name="currentPopulation">The population at present.</param>
        /// <returns>The count of years which the town need to see its population greater or equal to currentPopulation inhabitants.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when initial population is less or equals 0
        /// - or -
        /// the count of visitors cannot be less 0
        /// - or -
        /// the current population is less or equals 0
        /// - or -
        /// the current population is less than initial population.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if the value of percents is less then 0% or more then 100%.</exception>
        public static int GetYears(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            if (currentPopulation <= 0)
            {
                throw new ArgumentException("Wrong value of current population");
            }

            if (initialPopulation <= 0)
            {
                throw new ArgumentException("Wrong value of initial populataion");
            }

            if (currentPopulation < initialPopulation)
            {
                throw new ArgumentException("Wrong value of current population (less than initial populataion)");
            }

            if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException("Value of percent cannot be less then 0% or more then 100%");
            }

            if (visitors < 0)
            {
                throw new ArgumentException("Wrong value of visitors");
            }

            int years = 0;
            int population = initialPopulation;

            while (population < currentPopulation)
            {
                population += (int)(population * (percent / 100)) + visitors;
                years++;
            }

            return years;
        }
    }
}
