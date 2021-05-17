using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderData;

namespace DnDCharacterBuilderBusiness
{
    public class DetailManager
    {
        public List<string> ReturnRacialAndLevel1Abilities(int characterID, int level)
        {
            List<string> abilities = new List<string>();
            string race = "";
            string dndclass = "";
            string raceabilities = "";
            string classAbilities1 = "";
            string classAbilities2 = "";
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var activecharID =
                    from c in db.activeCharacters
                    select c;
                foreach(var character in activecharID)
                {
                    race = character.Race;
                    dndclass = character.Class;
                }
                var class1AbilityQuery =
                    from c in db.Class
                    where c.ClassName == dndclass
                    select c;
                foreach(var ability in class1AbilityQuery)
                {
                    classAbilities1 = ability.Level1Abilities;
                }
                var class2AbilityQuery =
                    from c in db.Class
                    where c.ClassName == dndclass
                    select c;
                foreach (var ability in class2AbilityQuery)
                {
                    classAbilities2 = ability.Level2Abilities;
                }
                var raceAbilityQuery =
                    from r in db.Race
                    where r.SubRaceName + " " + r.RaceName == race || r.RaceName == race
                    select r;
                foreach(var ability in raceAbilityQuery)
                {
                    raceabilities = ability.Abilities;
                }
                string[] class1abilities = classAbilities1.Split(",");
                string[] class2abilities = classAbilities2.Split(",");
                string[] racialabilities = raceabilities.Split(",");
                foreach (string ability in racialabilities)
                {
                    abilities.Add(ability.Trim());
                }
                foreach (string ability in class1abilities)
                {
                    abilities.Add(ability.Trim());
                }
                if (level == 2)
                {
                    foreach (string ability in class2abilities)
                    {
                        abilities.Add(ability.Trim());
                    }
                }
            }
            return abilities;
        }
        public void AssignFirstLevelAndHitPoints()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int hitpoints = 0;
                int hitDice = 0;
                int conScore = 0;
                int charID = 0;
                int activecharID = 0;
                string dndClass = "";
                var activecharacerquery =
                    from c in db.activeCharacters
                    select c;
                foreach (var character in activecharacerquery)
                {
                    activecharID = character.ActiveCharacterId;
                    charID = character.CharacterId;
                    dndClass = character.Class;
                }
                var classquery =
                    from c in db.Class
                    where c.ClassName == dndClass
                    select c.HitDice;
                foreach (var dice in classquery)
                { hitDice = dice; }
                var conquery =
                    from s in db.Stats
                    where s.CharacterId == charID
                    select s.Constitution;
                foreach (var score in conquery)
                { conScore = score; }
                if (conScore < 10)
                { hitpoints = hitDice; }
                else { hitpoints = hitDice + ((conScore - 10) / 2); }
                var assignLeveltochar = db.Characters.Find(charID);
                assignLeveltochar.Level = 1;
                assignLeveltochar.HitPoints = hitpoints;
                var assignLeveltoactivechar = db.activeCharacters.Find(activecharID);
                assignLeveltoactivechar.Level = 1;
                assignLeveltoactivechar.HitPoints = hitpoints;
                db.SaveChanges();
            }
        }
        public void ChangeLevelAndUpdateHitPOints(int level)
        {
            int charID = 0;
            int activeCharID = 0;
            int hitDice = 0;
            int hitPoints = 0;
            string dndClass = "";
            int conScore = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var activecharquery =
                    from c in db.activeCharacters
                    select c;
                foreach (var c in activecharquery)
                {
                    activeCharID = c.ActiveCharacterId;
                    charID = c.CharacterId;
                    dndClass = c.Class;
                }
                var classquery =
                    from c in db.Class
                    where c.ClassName == dndClass
                    select c.HitDice;
                foreach (var dice in classquery)
                { hitDice = dice; }
                var conquery =
                    from s in db.Stats
                    where s.CharacterId == charID
                    select s.Constitution;
                foreach (var score in conquery)
                { conScore = score; }
                if (conScore < 10)
                { hitPoints = hitDice/2; }
                else { hitPoints = (hitDice/2) + ((conScore - 10) / 2); }
                var character = db.Characters.Find(charID);
                character.Level = level;
                character.HitPoints += hitPoints;
                var activeCharacter = db.activeCharacters.Find(activeCharID);
                activeCharacter.Level = level;
                activeCharacter.HitPoints += hitPoints;
                db.SaveChanges();
            }
        }
    }
}
