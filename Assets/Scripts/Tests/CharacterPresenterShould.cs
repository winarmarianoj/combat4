using Characters.domain.impl;
using Characters.factory;
using Characters.factory.impl;
using Exception;
using Factions.domain;
using Factions.factory;
using Factories;
using Login.DTO;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class CharacterPresenterShould
    {
        private Character _character;
        private IFactory _factory;
        private IFactionFactory _factionFactory;
        private IFaction _blade;
        private IFaction _gun;
        private IFaction _medicine;

        [SetUp]
        public void Setup()
        {
            _factory = new Factory();
            _character = _factory.CreateNewCharacter();
            _blade = Substitute.For<IFaction>();
            _gun = Substitute.For<IFaction>();
            _medicine = Substitute.For<IFaction>();
        }
        
        [Test]
        public void CreatedNewCharacter()
        {
            Assert.AreEqual(1000, _character.Hp);
            Assert.AreEqual(1, _character.Level);
            Assert.AreEqual(true, _character.Alive);
        }

        [Test]
        public void HurtOthersCharactersAndIsDamageMajorHpWhenIsDead()
        {
            var target = _factory.CreateNewCharacter();
            target.Position = 5;
            _character.Position = 16;
            
            _character.DealDamage(target, 100);
            Assert.AreEqual(900, target.Hp);
        }

        [Test]
        public void HealACharactersButNotMajorHealToHpAndIsDeadNotHealed()
        {
            var target = _factory.CreateNewCharacter();
            _character.DealHeal(target, 100);
            Assert.AreEqual(1000, target.Hp);
        }

        [Test]
        public void CanNotHurtHimSelf()
        {
            var target = _factory.CreateNewCharacter();
            _character.DealDamage(target, 100);
            Assert.AreEqual(1000, _character.Hp);
        }

        [Test]
        public void CanOnlyHealHimSelf()
        {
            var target = _factory.CreateNewCharacter();
            _character.DealDamage(target, 100);
            _character.DealHeal(target, 100);
            
            Assert.AreEqual(1000, _character.Hp);
        }

        [Test]
        public void DoDamageAccordingToLevelMajorAFive()
        {
            var target = _factory.CreateNewCharacter();
            _character.Level = 8;
            target.Position = 5;
            _character.Position = 16;
            
            _character.DealDamage(target, 100);
            Assert.AreEqual(950, target.Hp);
        }
        
        [Test]
        public void DoDamageAccordingToLevelMinorAFive()
        {
            var target = _factory.CreateNewCharacter();
            _character.Level = -8;
            target.Position = 5;
            _character.Position = 16;
            
            _character.DealDamage(target, 100);
            Assert.AreEqual(850, target.Hp);
        }

        [Test]
        public void FightFaceToFace()
        {
            var target = _factory.CreateNewCharacter();
            target.Position = 5;
            _character.Position = 16;
            
            var result = _character.PositionWar(target);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddFactionOnCharacter()
        {
            _character.AddFactions(_blade);
            
            var result = _character.FactionContainsList(_blade);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void DeleteFactionOnCharacter()
        {
            _character.DeleteFactions(_blade);
            
            var result = _character.FactionNotContainsList(_blade);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void BeAbleToDealDamageProps()
        {
            /*IRival rival = new Rival();
            
            _character.DealDamage(accesory, 500);
            Assert.AreEqual(500, accesory.GetHp());*/
        }
        
    }
}
