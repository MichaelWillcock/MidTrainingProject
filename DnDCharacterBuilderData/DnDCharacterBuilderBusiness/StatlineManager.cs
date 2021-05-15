using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderData;

namespace DnDCharacterBuilderBusiness
{
    public class StatlineManager
    {
        public void AddStatlineToCharacter(int charID, int str, int dex, int con, int inte, int wis, int cha)
        {
            var statLine = new StatLine() { CharacterId = charID, Strength = str, Dexterity = dex, Constitution = con, Intelligence = inte, Wisdom = wis, Charisma = cha };
            using (var db = new DnDCharacterBuilderDataContext())
            {
                db.Stats.Add(statLine);
                db.SaveChanges();
            }
        }
    }
}
