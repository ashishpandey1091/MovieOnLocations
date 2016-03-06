using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using System.Reflection;
using System.IO;
using System.Data;

using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.PlatformAbstractions;


namespace DataAshishPandey.Models
{
    public static class AppSeedData
    {

        public static void Initialize(IServiceProvider serviceProvider,string appPath)
        {
            string relPath = appPath + "//Models//SeedData//";
            var context = serviceProvider.GetService<AppDbContext>();
            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }


            context.movies.RemoveRange(context.movies);
            context.Locations.RemoveRange(context.Locations);
            context.SaveChanges();

            SeedLocationsFromCsv(relPath, context);
            SeedOfficesFromCsv(relPath, context);
            //    var l1 = context.Locations.Add(new Location() { Latitude = 17.4126272, Longitude = 78.268675, Place = "Missouri", Country = "USA" });
            //    var l2 = context.Locations.Add(new Location() { Latitude = 36.47558772, Longitude = 78.8797, Place = "New York", Country = "USA" });
            //    var l3 = context.Locations.Add(new Location() { Latitude = 34.4126272, Longitude = 78.675858, Place = "California", Country = "USA" });
            //    var l4 = context.Locations.Add(new Location() { Latitude = 67.4789576, Longitude = 78.746453, Place = "Hyderabad", Country = "India" });
            //    var l5 = context.Locations.Add(new Location() { Latitude = 89.67894900, Longitude = 78.267686, Place = "Patna", Country = "India" });
            //    var l6 = context.Locations.Add(new Location() { Latitude = 90.4756782, Longitude = 78.978575, Place = "Ahmedabad", Country = "India" });
            //    var l7 = context.Locations.Add(new Location() { Latitude = 56.890786562, Longitude = 78.256575, Place = "Bangalore", Country = "India" });



            //context.offices.AddRange(   
            // new Office() { branchName = "Hinjewadi", companyName = "IGATE",  emailID = "hr@hinjewadi.igate.com" , contact = 345789234, departments = "Medical", numberOfEmployees = 1000  },
            // new Office() { branchName = "Airoli", companyName = "IGATE", emailID = "hr@airoli.accenture.com", contact = 345789234, departments = "BioMedical", numberOfEmployees = 2000 },
            // new Office() { branchName = "CEZ", companyName = "IGATE", emailID = "hr@cez.infosys.com", contact = 345789234, departments = "Software", numberOfEmployees = 1200 },
            // new Office() { branchName = "Seepz", companyName =  "IGATE", emailID = "hr@seepz.igate.com", contact = 345789234, departments = "Application", numberOfEmployees = 1100 },
            // new Office() { branchName = "Bangalore", companyName = "Accenture", emailID = "hr@banglaore.accenture.com", contact = 345789234, departments = "Mobile Apps", numberOfEmployees = 1200 },
            // new Office() { branchName = "CampusDining", companyName = "Aramark", emailID = "hr@aramark.com", contact = 345789234, departments = "Food", numberOfEmployees = 1300 },
            // new Office() { branchName = "GHMC", companyName = "IGATE", emailID = "hr@ghmc.igate.com", contact = 345789234, departments = "Health", numberOfEmployees = 1500 }
            // );
            //    context.SaveChanges();
            //    throw new Exception("Db is null");

        }

        private static void SeedOfficesFromCsv(string relPath, AppDbContext context)
        {
            string source = relPath + "Movies.csv";
            if (!File.Exists(source))
            {
                throw new Exception("Cannot find file " + source);
            }
            Movie.ReadAllFromCSV(source);
            List<Movie> lst = Movie.ReadAllFromCSV(source);
            context.movies.AddRange(lst.ToArray());
            context.SaveChanges();
        }

        private static void SeedLocationsFromCsv(string relPath, AppDbContext context)
        {
            string source = relPath + "location.csv";
            if (!File.Exists(source))
            {
                throw new Exception("Cannot find file " + source);
            }
            List<Location> lst = Location.ReadAllFromCSV(source);
            context.Locations.AddRange(lst.ToArray());
            context.SaveChanges();
        }
    }

      
    }


