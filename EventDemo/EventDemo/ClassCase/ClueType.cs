using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public class ClueType
    {
        public static List<string> GetAllItem(ClueType clueType)
        {
            return clueType.GetType()
                     .GetProperties()
                     .Select(field => (string) field.GetValue(clueType))
                     .ToList();
        }
    }
}
