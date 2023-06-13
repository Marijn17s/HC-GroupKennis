using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCGroupKennis.Classes
{
    internal class CvItem
    {
        public string Name { get; init; }

        public Groups.MainGroupType MainGroup { get; init; }

        public Groups.SubGroupType SubGroup { get; init; }

        public DateTime Year { get; init; }

        public double Rating { get; init; }

        public CvItem(string name, Groups.MainGroupType mainGroup, Groups.SubGroupType subGroup, DateTime year, double rating)
        {
            // Rating moet tussen de 1 en de 10 sterren liggen
            if (rating < 1 || rating > 10)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating moet tussen de 1 en de 10 liggen");
            Name = name;
            MainGroup = mainGroup;
            SubGroup = subGroup;
            Year = year;
            Rating = rating;
        }
    }
}
