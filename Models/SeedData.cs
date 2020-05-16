using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using v3x.Data;
using System;
using System.Linq;

namespace v3x.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new v3xContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<v3xContext>>()))
            {
                // Look for any movies.
                if (context.People.Any())
                {
                    return;   // DB has been seeded
                }

                context.People.AddRange(
                    new People
                    {
                        Name = "Lee Keen Shen",
                        Password = "12345",
                        Email = "lawrencelee0205@gmail.com",
                        Role = "superadmin",
                        Tel = "016-5654444",
                        Nationality = "Malaysian",
                        DateOfBirth = "01/02/1950",
                        Address = "Ipoh Perak"
                    },
                    new People
                    {
                        Name = "CS",
                        Password = "12345",
                        Email = "sulphate@gmail.com",
                        Role = "admin",
                        Tel = "016-999999",
                        Nationality = "Malaysian",
                        DateOfBirth = "31/02/2030",
                        Address = "Penang"
                    },
                    new People
                    {
                        Name = "yen ping",
                        Password = "12345",
                        Email = "yp@gmail.com",
                        Role = "employee",
                        Tel = "016-111111",
                        Nationality = "Malaysian",
                        DateOfBirth = "01/02/1888",
                        Address = "Johor Tebrau"
                    }


                );
                context.SaveChanges();
            }
        }
      }
}
