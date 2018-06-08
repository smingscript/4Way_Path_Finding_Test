using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class Place : ClueType
    {
        public static string Bathroom { get; } = "Bathroom";
        public static string Library { get; } = "Library";
        public static string GameRoom { get; } = "GameRoom"; 
        public static string Garage { get; } = "Garage";
        public static string Bedroom { get; } = "Bedroom";
        public static string Hall { get; } = "Hall";
        public static string Kitchen { get; } = "Kitchen";
        public static string Courtyard { get; } = "Courtyard";
        public static string DiningRoom { get; } = "DiningRoom";
    }
}
