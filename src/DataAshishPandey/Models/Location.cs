using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAshishPandey.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }
        public string Country { get; set; }

        [Display]
        public string Place { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static List<Location> ReadAllFromCSV(string filepath)
        {
            List<Location> lst = File.ReadAllLines(filepath)
                                         .Skip(1)
                                         .Select(v => Location.OneFromCsv(v))
                                         .ToList();
            return lst;
        }


        public static Location OneFromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Location item = new Location();

            int i = 0;
            item.LocationID = Convert.ToInt32(values[i++]);
            item.Country = Convert.ToString(values[i++]);
            item.County = Convert.ToString(values[i++]);
            item.Latitude = Convert.ToDouble(values[i++]);
            item.Longitude = Convert.ToDouble(values[i++]);
            item.Place = Convert.ToString(values[i++]);
            item.State = Convert.ToString(values[i++]);
            item.StateAbbreviation = Convert.ToString(values[i++]);
            item.ZipCode = Convert.ToString(values[i++]);


            return item;
        }
    }
}
