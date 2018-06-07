using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Place : CardType
    {
        public static string Bathroom { get; } = "Bathroom";
        public string Library { get; } = "Library";
        public string GameRoom { get; } = "GameRoom"; 
        public string Garage { get; } = "Garage";
        public string Bedroom { get; } = "Bedroom";
        public string Hall { get; } = "Hall";
        public string Kitchen { get; } = "Kitchen";
        public string Courtyard { get; } = "Courtyard";
        public string DiningRoom { get; } = "DiningRoom";
    }
}
