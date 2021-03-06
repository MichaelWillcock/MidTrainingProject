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
        public void DeleteStatsWhenCharacterDeleted(int charID)
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from s in db.Stats
                    where s.CharacterId == charID
                    select s;
                foreach (var item in query)
                {
                    db.Stats.Remove(item);
                }
                db.SaveChanges();
            }
        }
        public void AddedRacialModifieresToStatLine(int charID, string race)
        {
            int statID = 0;
            string PrimaryASI = "";
            int PrimaryIncrease = 0;
            string SecondaryASI = "";
            int SecondaryIncrease = 0;
            if (race.Contains("Human"))
            {
                using (var db = new DnDCharacterBuilderDataContext())
                {
                    var statIdQuery =
                    from s in db.Stats
                    where s.CharacterId == charID
                    select s.StatLineId;
                    foreach (var number in statIdQuery)
                    {
                        statID = number;
                    }
                    var statline = db.Stats.Find(statID);
                    statline.Strength += 1;
                    statline.Dexterity += 1;
                    statline.Constitution += 1;
                    statline.Intelligence += 1;
                    statline.Wisdom += 1;
                    statline.Charisma += 1;
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new DnDCharacterBuilderDataContext())
                {
                    var statIdQuery =
                        from s in db.Stats
                        where s.CharacterId == charID
                        select s.StatLineId;
                    foreach (var number in statIdQuery)
                    {
                        statID = number;
                    }
                    var raceQuery =
                        from r in db.Race
                        where r.SubRaceName + " " + r.RaceName == race || r.RaceName == race
                        select new { r.PrimaryASI, r.PrimaryIncrease, r.SecondayASI, r.SecondaryIncrease };
                    foreach (var data in raceQuery)
                    {
                        PrimaryASI = data.PrimaryASI;
                        PrimaryIncrease = data.PrimaryIncrease;
                        SecondaryASI = data.SecondayASI;
                        SecondaryIncrease = data.SecondaryIncrease;
                    }
                    AddModifiersToStats(statID, PrimaryASI, PrimaryIncrease);
                    AddModifiersToStats(statID, SecondaryASI, SecondaryIncrease);
                }
            }
        }
        public void AddModifiersToStats(int statID, string ASI, int Increase)
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var statline = db.Stats.Find(statID);
                if (ASI.Contains("Strength"))
                { statline.Strength += Increase; }
                else if (ASI.Contains("Dexterity"))
                { statline.Dexterity += Increase; }
                else if (ASI.Contains("Constitution"))
                { statline.Constitution += Increase; }
                else if (ASI.Contains("Intelligence"))
                { statline.Intelligence += Increase; }
                else if (ASI.Contains("Wisdom"))
                { statline.Wisdom += Increase; }
                else { statline.Charisma += Increase; }
                db.SaveChanges();
            }
        }
        public void AddModifiersToHalfElf(int statID, string ASI)
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var statline = db.Stats.Find(statID);
                if (ASI.Contains("Strength"))
                { statline.Strength += 1; }
                else if (ASI.Contains("Dexterity"))
                { statline.Dexterity += 1; }
                else if (ASI.Contains("Constitution"))
                { statline.Constitution += 1; }
                else if (ASI.Contains("Intelligence"))
                { statline.Intelligence += 1; }
                else { statline.Wisdom += 1; }
                db.SaveChanges();
            }
        }
        public void HalfElfOrVariantASI(string ASI1, string ASI2)
        {
            int charID = 0;
            int statID = 0;
            string race = "";
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.activeCharacters
                    select new { c.CharacterId, c.Race };
                foreach (var character in query)
                {
                    charID = character.CharacterId;
                    race = character.Race;
                }
                var statIdQuery =
                        from s in db.Stats
                        where s.CharacterId == charID
                        select s.StatLineId;
                foreach (var number in statIdQuery)
                {
                    statID = number;
                }
                if (race.Contains("Half Elf"))
                {
                    var character = db.Stats.Find(statID);
                    character.Charisma += 2;
                    AddModifiersToHalfElf(statID, ASI1);
                    AddModifiersToHalfElf(statID, ASI2);
                }
                else
                {
                    AddModifiersToStats(statID, ASI1, 1);
                    AddModifiersToStats(statID, ASI2, 1);
                }
                db.SaveChanges();
            }

        }
        public List<string> ReturnStrengthAndModifier(int characterID)
        {

            List<string> strength = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from s in db.Stats
                    where s.CharacterId == characterID
                    select s.Strength;
                foreach (var score in query)
                {
                    strength.Add(score.ToString());
                    if (score < 10)
                    {
                        strength.Add($"- {(((score - 11) *(-1) )/ 2).ToString()}");
                    }
                    else
                    {
                        strength.Add($"+{((score - 10) / 2).ToString()}");
                    }
                }
            }
            return strength;
        }
        public List<string> ReturnDexterityScoreAndModifier(int characterID)
        {
            List<string> dexterity = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from s in db.Stats
                    where s.CharacterId == characterID
                    select s.Dexterity;
                foreach (var score in query)
                {
                    dexterity.Add(score.ToString());
                    if (score < 10)
                    {
                        dexterity.Add($"- {(((score - 11) * (-1)) / 2).ToString()}");
                    }
                    else
                    {
                        dexterity.Add($"+{((score - 10) / 2).ToString()}");
                    }
                }
            }
            return dexterity;
        }
        public List<string> ReturnConsitutionScoreAndModifier(int characterID)
        {
            List<string> constitution = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from s in db.Stats
                    where s.CharacterId == characterID
                    select s.Constitution;
                foreach (var score in query)
                {
                    constitution.Add(score.ToString());
                    if (score < 10)
                    {
                        constitution.Add($"- {(((score - 11) * (-1)) / 2).ToString()}");
                    }
                    else
                    {
                        constitution.Add($"+{((score - 10) / 2).ToString()}");
                    }
                }
            }
            return constitution;
        }
        public List<string> ReturnIntelligenceScoreAndModifier(int characterID)
        {
            List<string> intelligence = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from s in db.Stats
                    where s.CharacterId == characterID
                    select s.Intelligence;
                foreach (var score in query)
                {
                    intelligence.Add(score.ToString());
                    if (score < 10)
                    {
                        intelligence.Add($"- {(((score - 11) * (-1)) / 2).ToString()}");
                    }
                    else
                    {
                        intelligence.Add($"+{((score - 10) / 2).ToString()}");
                    }
                }
            }
            return intelligence;
        }
        public List<string> ReturnWisdomScoreAndModifier(int characterID)
        {
            List<string> wisdom = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from s in db.Stats
                    where s.CharacterId == characterID
                    select s.Wisdom;
                foreach (var score in query)
                {
                    wisdom.Add(score.ToString());
                    if (score < 10)
                    {
                        wisdom.Add($"- {(((score - 11) * (-1)) / 2).ToString()}");
                    }
                    else
                    {
                        wisdom.Add($"+{((score - 10) / 2).ToString()}");
                    }
                }
            }
            return wisdom;
        }
        public List<string> ReturnCharismaScoreAndModifier(int characterID)
        {
            List<string> charisma = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                   from s in db.Stats
                   where s.CharacterId == characterID
                   select s.Charisma;
                foreach (var score in query)
                {
                    charisma.Add(score.ToString());
                    if (score < 10)
                    {
                        charisma.Add($"- {(((score - 11) * (-1)) / 2).ToString()}");
                    }
                    else
                    {
                        charisma.Add($"+{((score - 10) / 2).ToString()}");
                    }
                }
            }
            return charisma;
        }
    }
}
