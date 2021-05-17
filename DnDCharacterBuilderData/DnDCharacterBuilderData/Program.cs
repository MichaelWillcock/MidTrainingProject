using System;
using System.Linq;

namespace DnDCharacterBuilderData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var barbarian = db.Class.Find(2);
                barbarian.Level1Abilities = "Rage, Unarmoured Defense";
                barbarian.Level2Abilities = "Reckless Attack, Danger Sense";
                var bard = db.Class.Find(3);
                bard.Level1Abilities = "Spellcasting, Bardic Inspiration";
                bard.Level2Abilities = "Jack of All Trades, Song of Rest";
                var cleric = db.Class.Find(4);
                cleric.Level1Abilities = "Spellcasting, Divine Domain";
                cleric.Level2Abilities = "Channel Divinity, Divine Domain Feature";
                var druid = db.Class.Find(5);
                druid.Level1Abilities = "Druidic, Spellcasting";
                druid.Level2Abilities = "Wild Shape, Druid Cirlce";
                var fighter = db.Class.Find(6);
                fighter.Level1Abilities = "Fighting Style, Second Wind";
                fighter.Level2Abilities = "Action Surge";
                var monk = db.Class.Find(7);
                monk.Level1Abilities = "Unarmoured Defense, Martial Arts";
                monk.Level2Abilities = "Ki, Unarmoured Movement";
                var paladin = db.Class.Find(8);
                paladin.Level1Abilities = "Divine Sense, Lay on Hands";
                paladin.Level2Abilities = "Fighting Style, Spellcasting, Divine Smite";
                var ranger = db.Class.Find(9);
                ranger.Level1Abilities = "Favoured Enemy, Natural Explorer";
                ranger.Level2Abilities = "Fighting Style, Spellcasting";
                var rogue = db.Class.Find(10);
                rogue.Level1Abilities = "Expertise, Sneak Attack, Thieves Cant";
                rogue.Level2Abilities = "Cunning Action";
                var sorcerer = db.Class.Find(11);
                sorcerer.Level1Abilities = "Spellcasting, Sorcerous Origin";
                sorcerer.Level2Abilities = "Font of Magic";
                var warlock = db.Class.Find(12);
                warlock.Level1Abilities = "Otherworldly Patron, Pact Magic";
                warlock.Level2Abilities = "Eldritch Invocations";
                var wizard = db.Class.Find(13);
                wizard.Level1Abilities = "Spellcasting, Arcane Recovery";
                wizard.Level2Abilities = "Arcane Tradition";

                db.SaveChanges();
            }
        }
    }
}
