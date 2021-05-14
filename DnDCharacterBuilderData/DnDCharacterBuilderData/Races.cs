using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public partial class Races
    {
        public int RacesId { get; set; }
        public string RaceName { get; set; }
        public string SubRaceName { get; set; }
        public string Languages { get; set; }
        public string PrimaryASI { get; set; }
        public int PrimaryIncrease { get; set; }
        public string SecondayASI { get; set; }
        public int SecondaryIncrease { get; set; }
        public string Skills { get; set; }
        public string Abilities { get; set; }
    }
}