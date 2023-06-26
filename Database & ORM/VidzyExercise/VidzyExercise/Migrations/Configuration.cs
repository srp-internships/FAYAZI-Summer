namespace VidzyExercise.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VidzyExercise.VidzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VidzyExercise.VidzyContext context)
        {
            context.Genres.AddOrUpdate(g => g.Name,
                new Genre
                {
                    Name = "Action",
                    Videos = new Collection<Video>()
                    {
                        new Video { Name= "Avatar", ReleaseDate = new DateTime(2015, 05, 10) }
                    }
                }
                );
        }
    }
}
