using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public partial class Character
    {
        public Character()
        {
            Stats = new HashSet<StatLine>();
            //Race = new HashSet<Races>();
            //Class = new HashSet<Classes>();
            Level = new HashSet<Levels>();
        }
        public int CharacterId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CharacterName { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public virtual ICollection<Levels> Level { get; set; }
        //public virtual ICollection<Races> Race { get; set; }
        //public virtual ICollection<Classes> Class { get; set; }
        public virtual ICollection<StatLine> Stats { get; set; }
    }
}