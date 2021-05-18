using NUnit.Framework;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;
using System.Linq;
using System.Collections.Generic;

namespace DnDCharacterBuilderTests
{
    class StatlineManagerTests
    {
        UserManager _userManager;
        LoginManager _loginManager;
        CharacterManager _characterManager;
        StatlineManager _statlineManager;

        [SetUp]
        public void Setup()
        {
            _userManager = new UserManager();
            _loginManager = new LoginManager();
            _characterManager = new CharacterManager();
            _statlineManager = new StatlineManager();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from u in db.Users
                    where u.UserName == "TestName" || u.UserName == "NewTestName"
                    select u;
                db.Users.RemoveRange(query);
                db.SaveChanges();
            }
            _loginManager.DeleteLoggedInUser();
            _userManager.AddUser("TestUser", "Password");
            _loginManager.AddUserToLoggedIn("TestUser");
            _characterManager.AddCharacter("TestName", "TestClass", "TestRace");
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = db.Characters.Where(c => c.UserName == "TestUser");
                foreach (var ID in query)
                { CharID = ID.CharacterId; }
            }
            _characterManager.AddCharacterToActiveCharacters(CharID);
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddStatlineToCharacter(CharID, 10, 10, 10, 10, 10, 10);
        }
        [Test]
        public void DeleteStatLineInPrepForCharacterDeletion()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int charID = 0;
                int preDelete = db.Stats.Count();
                var query = from c in db.activeCharacters select c;
                foreach (var id in query) { charID = id.CharacterId; }
                _statlineManager.DeleteStatsWhenCharacterDeleted(charID);
                int postDelete = db.Stats.Count();
                Assert.AreEqual(preDelete, postDelete + 1);
            }
        }
        [Test]
        public void HillDwarfIncreasesConBy2AndWisBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Hill Dwarf");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Constitution; actualstat2 = stat.Wisdom; }
            }    
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void MountainDwarfIncreasesConBy2AnStrsBy2()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 12;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Mountain Dwarf");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Constitution; actualstat2 = stat.Strength; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void HighElfIncreasesDexBy2AndIntBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "High Elf");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Dexterity; actualstat2 = stat.Intelligence; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void WoodElfIncreasesDexBy2AndWisBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Wood Elf");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Dexterity; actualstat2 = stat.Wisdom; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void DarkElfIncreasesDexBy2AndChaBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Dark Elf");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Dexterity; actualstat2 = stat.Charisma; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void LightfootHalfingIncreasesDexBy2AndChaBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "LightFoot Halfling");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Dexterity; actualstat2 = stat.Charisma; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void StoutHalfingIncreasesDexBy2AndConBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Stout Halfling");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Dexterity; actualstat2 = stat.Constitution; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void HumanIncreasesAllBy1()
        {
            int CharID = 0;
            int updatedStats = 66;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Human");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                int actual = 0;
                foreach (var stat in query)
                { actual = stat.Strength + stat.Dexterity + stat.Constitution + stat.Intelligence + stat.Wisdom + stat.Charisma; }
                Assert.AreEqual(updatedStats, actual);
            }
        }
        [Test]
        public void DragonbornIncreasesStrBy2AndChaBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Dragonborn");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Strength; actualstat2 = stat.Charisma; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void ForestGnomeIncreasesIntBy2AndDexBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Forest Gnome");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Intelligence; actualstat2 = stat.Dexterity; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void RockGnomeIncreasesIntBy2AndConBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Rock Gnome");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Intelligence; actualstat2 = stat.Constitution; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void HalfOrcIncreasesStrBy2AndConBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Half Orc");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Strength; actualstat2 = stat.Constitution; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void TieFlingIncreasesChaBy2AndIntBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddedRacialModifieresToStatLine(CharID, "Tiefling");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Charisma; actualstat2 = stat.Intelligence; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void HalfElfIncreasesChaBy2AndTwoOthersBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 12; int expectedstat2 = 11; int expectedstat3 = 11;
            int actualstat1 = 0; int actualstat2 = 0; int actualstat3 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _characterManager.UdateCharacterDetails("CharacterName", "Class", "Half Elf");
            _statlineManager.HalfElfOrVariantASI("Strength", "Dexterity");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Charisma; actualstat2 = stat.Strength; actualstat3 = stat.Dexterity; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2 && expectedstat3 == actualstat3) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void VariantHumanIncreasesTwoBy1()
        {
            int CharID = 0;
            bool updatedStats = false;
            int expectedstat1 = 11; int expectedstat2 = 11;
            int actualstat1 = 0; int actualstat2 = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _characterManager.UdateCharacterDetails("CharacterName", "Class", "Half Elf");
            _statlineManager.HalfElfOrVariantASI("Strength", "Dexterity");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == CharID select s;
                foreach (var stat in query) { actualstat1 = stat.Dexterity; actualstat2 = stat.Strength; }
            }
            if (expectedstat1 == actualstat1 && expectedstat2 == actualstat2) { updatedStats = true; }
            Assert.AreEqual(updatedStats, true);
        }
        [Test]
        public void StrengthIs10AndModifierIsZero()
        {
            string expected = "10+0";
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            List<string> ability = new List<string> (_statlineManager.ReturnStrengthAndModifier(CharID));
            string actual = ability[0] + ability[1];
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DexterityIs10AndModifierIsZero()
        {
            string expected = "10+0";
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            List<string> ability = new List<string>(_statlineManager.ReturnDexterityScoreAndModifier(CharID));
            string actual = ability[0] + ability[1];
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ConsitutionIs10AndModifierIsZero()
        {
            string expected = "10+0";
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            List<string> ability = new List<string>(_statlineManager.ReturnConsitutionScoreAndModifier(CharID));
            string actual = ability[0] + ability[1];
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void IntelligenceIs10AndModifierIsZero()
        {
            string expected = "10+0";
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            List<string> ability = new List<string>(_statlineManager.ReturnIntelligenceScoreAndModifier(CharID));
            string actual = ability[0] + ability[1];
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void WisdomIs10AndModifierIsZero()
        {
            string expected = "10+0";
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            List<string> ability = new List<string>(_statlineManager.ReturnWisdomScoreAndModifier(CharID));
            string actual = ability[0] + ability[1];
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CharismaIs10AndModifierIsZero()
        {
            string expected = "10+0";
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            List<string> ability = new List<string>(_statlineManager.ReturnCharismaScoreAndModifier(CharID));
            string actual = ability[0] + ability[1];
            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void TearDown()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from u in db.Users
                    where u.UserName == "TestName" || u.UserName == "NewTestName" || u.UserName == "TestUser"
                    select u;
                db.Users.RemoveRange(query);
                db.SaveChanges();
            }
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.Characters
                    where c.UserName == "TestUser"
                    select c;
                db.Characters.RemoveRange(query);
                db.SaveChanges();
            }
            _loginManager.DeleteLoggedInUser();
            _characterManager.DeleteActiveCharacter();
        }
    }
}
