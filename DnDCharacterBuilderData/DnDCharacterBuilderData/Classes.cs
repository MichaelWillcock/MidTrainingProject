using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public partial class Classes
    {
        public int ClassesId { get; set; }
        public string ClassName { get; set; }
        public int HitDice { get; set; }
        public string WeaponProficiencies { get; set; }
        public string ArmourProficiencies { get; set; }
        public string Level1Abilities { get; set; }
        public string Level2Abilities { get; set; }
    }
}