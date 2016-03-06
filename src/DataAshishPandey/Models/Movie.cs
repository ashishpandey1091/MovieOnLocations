using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DataAshishPandey.Models
{
    public class Movie
    {
      
        [ScaffoldColumn(false)]
        public int MovieID { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }
       
        [Display(Name = "Contact")]
        public int contact { get; set; }

        [Display(Name = "emailID")]
        public string emailID { get; set; }
        
        [Display(Name = "Number of Theaters")]
        public int numberOfTheaters { get; set; }


        [ScaffoldColumn(true)]
        public int? LocationID { get; set; }

        public virtual Location Location { get; set; }
        public List<Location> officeSets { get; set; }

        public static List<Movie> ReadAllFromCSV(string filepath)
        {
            List<Movie> lst = File.ReadAllLines(filepath)
                                        .Skip(1)
                                        .Select(v => Movie.OneFromCsv(v))
                                        .ToList();
            return lst;
        }

        public static Movie OneFromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Movie item = new Movie();

            int i = 0;
           // item.branchName = Convert.ToString(values[i++]);
            item.LocationID = Convert.ToInt32(values[i++]);
            item.MovieName = Convert.ToString(values[i++]);
            item.emailID = Convert.ToString(values[i++]);
            item.contact = Convert.ToInt32(values[i++]);
           // item.departments = Convert.ToString(values[i++]);      
            item.numberOfTheaters = Convert.ToInt32(values[i++]);

            return item;
        }

    }

}