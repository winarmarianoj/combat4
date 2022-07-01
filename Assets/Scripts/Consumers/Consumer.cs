using Factories;
using UnityEngine;

namespace Consumers
{
    public class Consumer : MonoBehaviour
    {
        private IBeattleFactory _beattleFactory;

        public void Configure(IBeattleFactory beattleFactory)
        {
            _beattleFactory = beattleFactory;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F9)) _beattleFactory.CreateCharacter("Local");
            if (Input.GetKeyUp(KeyCode.F10)) _beattleFactory.CreateCharacter("Visitor1");
            
            if (Input.GetKeyUp(KeyCode.F1)) _beattleFactory.CreateWeapon("Blade");
            if (Input.GetKeyUp(KeyCode.F2)) _beattleFactory.CreateWeapon("Bomb");
            if (Input.GetKeyUp(KeyCode.F3)) _beattleFactory.CreateWeapon("Gun");
            if (Input.GetKeyUp(KeyCode.F4)) _beattleFactory.CreateWeapon("Knife");
            if (Input.GetKeyUp(KeyCode.F5)) _beattleFactory.CreateWeapon("MiniBlade");
            if (Input.GetKeyUp(KeyCode.F6)) _beattleFactory.CreateWeapon("SuperGun");
            if (Input.GetKeyUp(KeyCode.F7)) _beattleFactory.CreateWeapon("Medicine");
            
            if (Input.GetKeyUp(KeyCode.Q)) _beattleFactory.CreateFaction("Flag1");
            if (Input.GetKeyUp(KeyCode.W)) _beattleFactory.CreateFaction("Flag2");
            if (Input.GetKeyUp(KeyCode.E)) _beattleFactory.CreateFaction("Flag3");
            if (Input.GetKeyUp(KeyCode.R)) _beattleFactory.CreateFaction("Flag4");
            if (Input.GetKeyUp(KeyCode.T)) _beattleFactory.CreateFaction("Flag5");
            if (Input.GetKeyUp(KeyCode.Y)) _beattleFactory.CreateFaction("Flag6");
            if (Input.GetKeyUp(KeyCode.U)) _beattleFactory.CreateFaction("Flag7");
            if (Input.GetKeyUp(KeyCode.I)) _beattleFactory.CreateFaction("Flag8");
            if (Input.GetKeyUp(KeyCode.O)) _beattleFactory.CreateFaction("Flag9");
            
            if (Input.GetKeyUp(KeyCode.A)) _beattleFactory.CreateRival("Bug");
            if (Input.GetKeyUp(KeyCode.S)) _beattleFactory.CreateRival("Crab");
            if (Input.GetKeyUp(KeyCode.D)) _beattleFactory.CreateRival("Hyena");
            if (Input.GetKeyUp(KeyCode.F)) _beattleFactory.CreateRival("Mummy");
            if (Input.GetKeyUp(KeyCode.G)) _beattleFactory.CreateRival("Person");
            if (Input.GetKeyUp(KeyCode.H)) _beattleFactory.CreateRival("Scorpio");
            if (Input.GetKeyUp(KeyCode.J)) _beattleFactory.CreateRival("Snake");
        }
    }
}