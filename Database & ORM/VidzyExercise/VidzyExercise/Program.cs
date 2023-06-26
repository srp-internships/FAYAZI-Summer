﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new VidzyContext();
            var ganries = db.Genres.Include(g => g.Videos).Where(g=>g.Id==2);
            foreach (var ganry in ganries)
            {
                Console.WriteLine($"{ganry.Name}:");
                foreach (var v in ganry.Videos)
                {
                    Console.WriteLine(v.Name);
                }
            }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }

        public Classification Classification { get; set; }
    }

    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public IList<Video> Videos { get; set; }
    }

    public enum Classification
    {
        Silver = 3,
        Gold = 2,
        Platinum = 1
    }

    public class VidzyContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
