using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public partial class Character
    {
        public override string ToString()
        {
            return $"{CharacterId}-{CharacterName}-{Class}-{Race}";
        }
    }
    public partial class Classes
    {
        public override string ToString()
        {
            return $"{ClassName}";
        }
    }
    public partial class Races
    {
        public override string ToString()
        {
            if (SubRaceName != null)
            {
                return $"{SubRaceName} {RaceName}";
            }
            else
            {
                return $"{RaceName}";
            }
            
        }
    }
}
