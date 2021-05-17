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
        }
        public int CharacterId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CharacterName { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public virtual ICollection<StatLine> Stats { get; set; }
    }
}