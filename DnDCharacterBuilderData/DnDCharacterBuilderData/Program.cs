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
                //db.Add(new Classes { ClassName = "Barbarian", HitDice = 12, WeaponProficiencies = "All Weapons", ArmourProficiencies = "Light, Medium, Shields", Level1Abilities = "Rage, Unarmoured Defense", Level2Abilities = "Reckless Attack, Danger Sense" });
                //db.Add(new Classes { ClassName = "Bard", HitDice = 8, WeaponProficiencies = "Simple Weapons, Hand Crossbow, Longsword, Rapier, Shortsword", ArmourProficiencies = "Light", Level1Abilities = "Spellcasting, Bardic Inspiration", Level2Abilities = "Jack of All Trades, Song of Rest" });
                //db.Add(new Classes { ClassName = "Cleric", HitDice = 8, WeaponProficiencies = "Simple Weapons", ArmourProficiencies = "Light, Medium, Shields", Level1Abilities = "Spellcasting, Divine Domain", Level2Abilities = "Channel Divinity, Divine Domain Feature" });
                //db.Add(new Classes { ClassName = "Druid", HitDice = 8, WeaponProficiencies = "Clubs, Dagger, Dart, Javelin, Mace, Quaterstaff, Scimitar, Sickle, Sling, Spear", ArmourProficiencies = "Light, Medium, Shields", Level1Abilities = "Druidic, Spellcasting", Level2Abilities = "Wild Shape, Druid Cirlce" });
                //db.Add(new Classes { ClassName = "Fighter", HitDice = 10, WeaponProficiencies = "All Weapons ", ArmourProficiencies = "All Armour, Shields", Level1Abilities = "Fighting Style, Second Wind", Level2Abilities = "Action Surge" });
                //db.Add(new Classes { ClassName = "Monk", HitDice = 8, WeaponProficiencies = "Simple Weapons, Shortsword", ArmourProficiencies = "None", Level1Abilities = "Unarmoured Defense, Martial Arts", Level2Abilities = "Ki, Unarmoured Movement" });
                //db.Add(new Classes { ClassName = "Paladin", HitDice = 10, WeaponProficiencies = "All Weapons", ArmourProficiencies = "All Armour, Shields", Level1Abilities = "Divine Sense, Lay on Hands", Level2Abilities = "Fighting Style, Spellcasting, Divine Smite" });
                //db.Add(new Classes { ClassName = "Ranger", HitDice = 10, WeaponProficiencies = "All Weapons", ArmourProficiencies = "Light, Medium, Shields", Level1Abilities = "Favoured Enemy, Natural Explorer", Level2Abilities = "Fighting Style, Spellcasting" });
                //db.Add(new Classes { ClassName = "Rogue", HitDice = 8, WeaponProficiencies = "Simple Weapons, Hand Crossbow, Longsword, Rapier, Shortsword", ArmourProficiencies = "Light", Level1Abilities = "Expertise, Sneak Attack, Thieves Cant", Level2Abilities = "Cunning Action" });
                //db.Add(new Classes { ClassName = "Sorcerer", HitDice = 6, WeaponProficiencies = "Dagger, Dart, Sling, Quarterstaff, Light Crossbow", ArmourProficiencies = "None", Level1Abilities = "Spellcasting, Sorcerous Origin", Level2Abilities = "Font of Magic" });
                //db.Add(new Classes { ClassName = "Warlock", HitDice = 8, WeaponProficiencies = "Simple Weapons", ArmourProficiencies = "Light", Level1Abilities = "Otherworldly Patron, Pact Magic", Level2Abilities = "Eldritch Invocations" });
                //db.Add(new Classes { ClassName = "Wizard", HitDice = 6, WeaponProficiencies = "Dagger, Dart, Sling, Quarterstaff, Light Crossbow", ArmourProficiencies = "None", Level1Abilities = "Spellcasting, Arcane Recovery", Level2Abilities = "Arcane Tradition" });

                //db.Add(new Races { RaceName = "Dwarf", SubRaceName = "Hill", Languages = "Common, Dwavish", PrimaryASI = "Constitution", PrimaryIncrease = 2, SecondayASI = "Wisdom", SecondaryIncrease =1, Abilities = "Darkvision, Dwarven Resilience, Dwarven Combat Training, Tool Proficiency, Stonecunning, Dwaven Toughness" });
                //db.Add(new Races { RaceName = "Dwarf", SubRaceName = "Mountain", Languages = "Common, Dwavish", PrimaryASI = "Constitution", PrimaryIncrease =2, SecondayASI = "Strength", SecondaryIncrease =2, Abilities = "Darkvision, Dwarven Resilience, Dwarven Combat Training, Tool Proficiency, Stonecunning, Dwarven Armour Training" });
                //db.Add(new Races { RaceName = "Elf", SubRaceName = "High", Languages = "Common, ELvish", PrimaryASI = "Dexterity", PrimaryIncrease =2, SecondayASI = "Intelligence", SecondaryIncrease =1, Skills = "Perception", Abilities = "Darkvision, Fey Ancestry, Trance, Elf Weapon Training, Cantrip, Extra Language" });    
                //db.Add(new Races { RaceName = "Elf", SubRaceName = "Wood", Languages = "Common, ELvish", PrimaryASI = "Dexterity", PrimaryIncrease =2, SecondayASI = "Wisdom", SecondaryIncrease =1, Skills = "Perception", Abilities = "Darkvision, Fey Ancestry, Trance, Elf Weapon Training, Fleet of Foot, Mask of the Wild" }); 
                //db.Add(new Races { RaceName = "Elf", SubRaceName = "Dark", Languages = "Common, ELvish", PrimaryASI = "Dexterity", PrimaryIncrease =2, SecondayASI = "Charisma", SecondaryIncrease =1, Skills = "Perception", Abilities = "Darkvision, Fey Ancestry, Trance, Superior Darkvision, Sunlight Sensitivity, Drow Magic, Drow Weapon Training" });
                //db.Add(new Races { RaceName = "Halfling", SubRaceName = "LightFoot", Languages = "Common, Halfling", PrimaryASI = "Dexterity", PrimaryIncrease =2, SecondayASI = "Charisma", SecondaryIncrease =1, Abilities = "Lucky, Brave, Halfling Nimbleness, Naturally Stealthy" });
                //db.Add(new Races { RaceName = "Halfling", SubRaceName = "Stout", Languages = "Common, Halfling", PrimaryASI = "Dexterity", PrimaryIncrease =2, SecondayASI = "Constitution", SecondaryIncrease =1, Abilities = "Lucky, Brave, Halfling Nimbleness, Stout Resilience" });
                //db.Add(new Races { RaceName = "Human", Languages = "Common", PrimaryASI = "All", PrimaryIncrease = 1 });
                //db.Add(new Races { RaceName = "Human", SubRaceName = "Varient", Languages = "Common", PrimaryASI = "Choice", PrimaryIncrease = 1, SecondayASI = "Choice", SecondaryIncrease = 1, Skills = "Choose Skill", Abilities = "Choose Feat" });
                //db.Add(new Races { RaceName = "Dragonborn", Languages = "Common, Draconic", PrimaryASI = "Strength", PrimaryIncrease =2, SecondayASI = "Charisma", SecondaryIncrease =1, Abilities = "Draconic Ancestry, Breath Weapon, Damage Resistance" });
                //db.Add(new Races { RaceName = "Gnome", SubRaceName = "Forest", Languages = "Common, Gnomish", PrimaryASI = "Intelligence", PrimaryIncrease =2, SecondayASI = "Dexterity", SecondaryIncrease =1, Abilities = "Darkvision, Gnome Cunning, Natural Illusionist, Speak with Small Beasts" });
                //db.Add(new Races { RaceName = "Gnome", SubRaceName = "Rock", Languages = "Common, Gnomish", PrimaryASI = "Intelligence", PrimaryIncrease =2, SecondayASI = "Constitution", SecondaryIncrease =1, Abilities = "Darkvision, Gnome Cunning, Artificer's Lore, Tinker" });
                //db.Add(new Races { RaceName = "Half Elf", Languages = "Common, Elvish", PrimaryASI = "Charisma", PrimaryIncrease =2, SecondayASI = "Choose 2", SecondaryIncrease =1, Skills = "Skill Choice", Abilities = "Darkvision, Fey Ancestry" });
                //db.Add(new Races { RaceName = "Half Orc", Languages = "Common, Orcish", PrimaryASI = "Strength", PrimaryIncrease =2, SecondayASI = "Constitution", SecondaryIncrease =1, Skills = "Intimidation", Abilities = "Darkvision, Relentless Endurance, Savage Attacks" });
                //db.Add(new Races { RaceName = "Tiefling", Languages = "Common, Infernal", PrimaryASI = "Charisma", PrimaryIncrease =2, SecondayASI = "Intelligence", SecondaryIncrease =1, Abilities = "Darkvision, Hellish Resistance, Infernal Legacy" });
                //db.SaveChanges();
            }
        }
    } 
}
