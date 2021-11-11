using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    },
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    }
                );
                context.SaveChanges();
            }
            using (var context_Student = new MvcMovieContext(
                            serviceProvider.GetRequiredService<
                                DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context_Student.StudentsDatas.Any())
                {
                    return;   // DB has been seeded
                }

                context_Student.StudentsDatas.AddRange(
                    new StudentsData
                    {
                        Name = "Hieu Le Duy ",
                        Address = "Ha Noi ",
                    },

                  new StudentsData
                  {
                      Name = "Hieu Le Duy ",
                      Address = "Ha Noi ",
                  },

                   new StudentsData
                   {
                       Name = "Hieu Le Duy ",
                       Address = "Ha Noi ",
                   },

                  new StudentsData
                  {
                      Name = "Hieu Le Duy ",
                      Address = "Ha Noi ",
                  },
                       new StudentsData
                       {
                           Name = "Hieu Lê Duy ",
                           Address = "Ha Noi ",
                       }
                );
                context_Student.SaveChanges();
            }

            // Person
            using (var context_person = new MvcMovieContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<MvcMovieContext>>()))
            {
                if (context_person.Person.Any())
                {
                    return;   // DB has been seeded
                }

                context_person.Person.AddRange(
                    new Person
                    {
                        PersonId = "ps001",
                        PersonName = "Hiếu"
                    },
                    new Person
                    {
                        PersonId = "ps002",
                        PersonName = "Hiếu"
                    },
                    new Person
                    {
                        PersonId = "ps003",
                        PersonName = "Hiếu"
                    },
                    new Person
                    {
                        PersonId = "ps004",
                        PersonName = "Hiếu"
                    },
                    new Person
                    {
                        PersonId = "ps005",
                        PersonName = "Hiếu"
                    }
                );
                context_person.SaveChanges();
            }

            // Employee
            using (var context_employee = new MvcMovieContext(
               serviceProvider.GetRequiredService<
                   DbContextOptions<MvcMovieContext>>()))

            {
                if (context_employee.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context_employee.Employee.AddRange(
                    new Employee
                    {
                        EmployeeID = "epl001",
                        EmployeeName = "Hiếu",
                        PhoneNumber = 0231283
                    },
                    new Employee
                    {
                        EmployeeID = "epl002",
                        EmployeeName = "Hiếu",
                        PhoneNumber = 0231283
                    },
                    new Employee
                    {
                        EmployeeID = "epl003",
                        EmployeeName = "Hiếu",
                        PhoneNumber = 0231283
                    },
                    new Employee
                    {
                        EmployeeID = "epl004",
                        EmployeeName = "Hiếu",
                        PhoneNumber = 0231283
                    },
                    new Employee
                    {
                        EmployeeID = "epl005",
                        EmployeeName = "Hiếu",
                        PhoneNumber = 0231283
                    },
                    new Employee
                    {
                        EmployeeID = "epl006",
                        EmployeeName = "Hiếu",
                        PhoneNumber = 0231283
                    }
                );
                context_employee.SaveChanges();
            }

            using (var context_product = new MvcMovieContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<MvcMovieContext>>()))
            {
                if (context_product.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context_product.Product.AddRange(
                    new Product
                    {
                        ProductId = "prd001",
                        ProductName = "Bánh",
                        UnitPrice = 2,
                        Quantity = 1000
                    },
                    new Product
                    {
                        ProductId = "prd002",
                        ProductName = "Bánh",
                        UnitPrice = 2,
                        Quantity = 1000
                    },
                    new Product
                    {
                        ProductId = "prd003",
                        ProductName = "Bánh",
                        UnitPrice = 2,
                        Quantity = 1000
                    },
                    new Product
                    {
                        ProductId = "prd004",
                        ProductName = "Bánh",
                        UnitPrice = 2,
                        Quantity = 1000
                    },
                    new Product
                    {
                        ProductId = "prd005",
                        ProductName = "Bánh",
                        UnitPrice = 2,
                        Quantity = 1000
                    }
                );
                context_product.SaveChanges();
            }
        }
    }
}