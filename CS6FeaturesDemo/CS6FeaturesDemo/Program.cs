using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS6FeaturesDemo
{
    class ArtistCollection : IEnumerable
    {
        List<Artist> artists = new List<Artist> { new Artist { Name="Ankit",Age=28},
        new Artist { Name="Aumeha", Age=26} };

        public IEnumerator<Artist> GetEnumerator()
        {
            return artists.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Artist Put(Artist anotherArtist)
        {
            artists.Add(anotherArtist);
            return anotherArtist;
        }
    }
    class Artist
    {
        string _name;
        int _age;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = "ankit";
            int age = 28;
            int salary = 50;
            Console.WriteLine($"Name : {name}, Age: {age}, Salary: {salary}");

            List<Artist> artists = new List<Artist> { new Artist { Name = "ankit", Age = 28 }, new Artist { Name = "Anu", Age = 25 } };
            int? count = artists?.Count ?? 0;
            Console.WriteLine($"Count is :{count}");
            Artist defArtist = artists?[0];
            Console.WriteLine($"Default artist: { defArtist?.Name}, Age: {artists?[0]?.Age}");


            var array = new[] { "Name", "ArtistType" };
            var thisArrayList = new List<string>(array)
            {
                [0] = "Ankit",
                [1] = "mafia"
            };

            var ArtistCollection = new ArtistCollection { new Artist { Name = "rahul", Age = 27 }, new Artist { Name = "rohan", Age = 27 } };
            foreach (var item in ArtistCollection)
            {
                Console.WriteLine($"{item?.Name} is {item?.Age} years old");
            }

            Console.ReadKey();
        }
    }

    static class ArtistExtensionStorage
    {
        public static Artist Add(this ArtistCollection collection, Artist anotherArtist)
        {
            collection.Put(anotherArtist);
            return anotherArtist;
        }
    }
}
