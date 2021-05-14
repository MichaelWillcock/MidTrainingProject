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
            return $"{CharacterName}-{Class}-{Race}";
        }
    }
}
