using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyExercise.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            //ToTable("tbl_Genres");
            HasKey(g => g.Id);

            Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(255);
        }
    }
}
