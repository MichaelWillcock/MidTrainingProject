using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterBuilderData
{
    public partial class DnDCharacterBuilderDataContext : DbContext
    {
        public static DnDCharacterBuilderDataContext Instance { get; } = new DnDCharacterBuilderDataContext();

        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Classes> Class { get; set; }
        public DbSet<Races> Race { get; set; }
        public DbSet<StatLine> Stats { get; set; }
        public DbSet<LoggedIn> loggedIns { get; set; }
        public DbSet<ActiveCharacter> activeCharacters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = DndCharacterBuilder;");
            }
        }
    }
}