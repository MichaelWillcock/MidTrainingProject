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
    }
}
