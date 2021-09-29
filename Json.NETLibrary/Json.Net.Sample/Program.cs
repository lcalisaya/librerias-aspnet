using Json.Net.Sample.Model;
using System;
using System.Collections.Generic;

namespace Json.Net.Sample
{
    public class Program
    {
        private static string _path = @"C:\Json Sample\Contacts.json";
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static List<Contact> GetContacts()
        {
            List<Contact> contactos = new List<Contact> {

                new Contact
                {
                    Name = "Francisco",
                    DateOfBirth = new DateTime(1980,05,12),
                    Phones = new List<Phone>{ 
                        new Phone { 
                            Name = "Home",
                            Number = "632142341"
                        },
                        new Phone {
                            Name = "Work",
                            Number = "576578653"
                        }
                    },
                    Address = new Address{ 
                        Street = "Av. Corrales",
                        Number = 121,
                        City = new City{ 
                            Name = "Buenos Aires",
                            Country = new Country { Code = "AR", Name = "Argentina"}
                        }
                    }
                },
                new Contact
                {
                    Name = "Luciana",
                    DateOfBirth = new DateTime(1990,01,17),
                    Phones = new List<Phone>{
                        new Phone {
                            Name = "Home",
                            Number = "234236543"
                        },
                        new Phone {
                            Name = "Work",
                            Number = "21321321"
                        }
                    },
                    Address = new Address{
                        Street = "Hipolito Irigoyen",
                        Number = 1546,
                        City = new City{
                            Name = "Santiago de Chile",
                            Country = new Country { Code = "CH", Name = "Chile"}
                        }
                    }
                },
                new Contact
                {
                    Name = "Malena",
                    DateOfBirth = new DateTime(1998,03,27),
                    Phones = new List<Phone>{
                        new Phone {
                            Name = "Home",
                            Number = "214318907"
                        },
                        new Phone {
                            Name = "Work",
                            Number = "21312454"
                        }
                    },
                    Address = new Address{
                        Street = "Av. de la Victoria",
                        Number = 7886,
                        City = new City{
                            Name = "La Paz",
                            Country = new Country { Code = "BO", Name = "Bolivia"}
                        }
                    }
                }

            };

            return contactos;
        }
    }
}
