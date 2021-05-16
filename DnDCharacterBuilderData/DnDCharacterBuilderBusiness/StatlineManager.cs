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
            if (race.Contains("Human") || race.Contains("Half Elf"))
            {
                if (race.Contains("Human") && race.Length <= 5)
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
                    }
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
                    var statline = db.Stats.Find(statID);
                    if (PrimaryASI.Contains("Strength"))
                    { statline.Strength += PrimaryIncrease; }
                    else if (PrimaryASI.Contains("Dexterity"))
                    { statline.Dexterity += PrimaryIncrease; }
                    else if (PrimaryASI.Contains("Constitution"))
                    { statline.Constitution += PrimaryIncrease; }
                    else if (PrimaryASI.Contains("Intelligence"))
                    { statline.Intelligence += PrimaryIncrease; }
                    else if (PrimaryASI.Contains("Wisdom"))
                    { statline.Wisdom += PrimaryIncrease; }
                    else { statline.Charisma += PrimaryIncrease; }

                    if (SecondaryASI.Contains("Strength"))
                    { statline.Strength += SecondaryIncrease; }
                    else if (SecondaryASI.Contains("Dexterity"))
                    { statline.Dexterity += SecondaryIncrease; }
                    else if (SecondaryASI.Contains("Constitution"))
                    { statline.Constitution += SecondaryIncrease; }
                    else if (SecondaryASI.Contains("Intelligence"))
                    { statline.Intelligence += SecondaryIncrease; }
                    else if (SecondaryASI.Contains("Wisdom"))
                    { statline.Wisdom += SecondaryIncrease; }
                    else { statline.Charisma += SecondaryIncrease; }
                    db.SaveChanges();
                }
            }
        }
        public List<List<string>> ReturnAbilityScoresAndModifiers(int characterID)
        {
            List<List<string>> abilities = new List<List<string>>();
            List<string> strength = new List<string>();
            List<string> dexterity = new List<string>();
            List<string> constitution = new List<string>();
            List<string> intelligence = new List<string>();
            List<string> wisdom = new List<string>();
            List<string> charisma = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from s in db.Stats
                    where s.CharacterId == characterID
                    select new { s.Strength, s.Dexterity, s.Constitution, s.Intelligence, s.Wisdom, s.Charisma };
                foreach (var score in query)
                {
                    strength.Add(score.Strength.ToString());
                    if (score.Strength < 10)
                    {
                        strength.Add($"- {((score.Strength - 10) / 2).ToString()}");
                    }
                    else
                    {
                        strength.Add($"+{((score.Strength - 10) / 2).ToString()}");
                    }
                    dexterity.Add(score.Dexterity.ToString());
                    if (score.Dexterity < 10)
                    {
                        dexterity.Add($"- {((score.Dexterity - 10) / 2).ToString()}");
                    }
                    else
                    {
                        dexterity.Add($"+{((score.Dexterity - 10) / 2).ToString()}");
                    }
                    constitution.Add(score.Constitution.ToString());
                    if (score.Constitution < 10)
                    {
                        constitution.Add($"- {((score.Constitution - 10) / 2).ToString()}");
                    }
                    else
                    {
                        constitution.Add($"+{((score.Constitution - 10) / 2).ToString()}");
                    }
                    intelligence.Add(score.Intelligence.ToString());
                    if (score.Intelligence < 10)
                    {
                        intelligence.Add($"- {((score.Intelligence - 10) / 2).ToString()}");
                    }
                    else
                    {
                        intelligence.Add($"+{((score.Intelligence - 10) / 2).ToString()}");
                    }
                    wisdom.Add(score.Wisdom.ToString());
                    if (score.Wisdom < 10)
                    {
                        wisdom.Add($"- {((score.Wisdom - 10) / 2).ToString()}");
                    }
                    else
                    {
                        wisdom.Add($"+{((score.Wisdom - 10) / 2).ToString()}");
                    }
                    charisma.Add(score.Charisma.ToString());
                    if (score.Charisma < 10)
                    {
                        charisma.Add($"- {((score.Charisma - 10) / 2).ToString()}");
                    }
                    else
                    {
                        charisma.Add($"+{((score.Charisma - 10) / 2).ToString()}");
                    }
                }
            }
            return abilities;
        }
    }
}
