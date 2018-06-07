using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Vcc.SocialNetwork.Domain.Model.Entities;

namespace Vcc.SocialNetwork.Domain.Model
{
    public class AppContext : DbContext
    {
        static AppContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var converter = new EnumToStringConverter<PositionEnum>();

            //modelBuilder
            //    .Entity<User>()
            //    .Property(e => e.Position)
            //    .HasCoversion<string>();

            // seeding Postions entities
            if(Positions != null)
            {
                var posType = typeof(PositionEnum);     
                
                foreach (PositionEnum val in Enum.GetValues(posType))
                {
                    if (!Positions.Any(u => u.Id == (short)val))
                    {
                        // if it doesn't exist
                        Positions.Add(new Position(val));
                    }                    
                }
            }
                
        }
    }
}
