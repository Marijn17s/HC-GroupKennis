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

        public int Year { get; init; }

        public CvItem(string name, Groups.MainGroupType mainGroup, Groups.SubGroupType subGroup, int year)
        {
            Name = name;
            MainGroup = mainGroup;
            SubGroup = subGroup;
            Year = year;
        }
    }
}
