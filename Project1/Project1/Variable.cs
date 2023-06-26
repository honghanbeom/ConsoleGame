using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Variable
    {
        // Map
        public int moveCount = 11;
        public string heal = "♨";
        public string shop = "$";
        public string monster = "ⓜ";
        public string elite = "ⓔ";
        public string randomEvent = "♬";
        public string userPosition = "㉯";
        public string boss = "ⓑ";
        public string clearStage = "X";
        public string[] mapCreate = new string[12];





        // AttackSystem
        public string fail = "□";
        public string success = "■";
        public string userSelect = "│";
        public int index;
        public int userBlink = 1000;
        public bool spaceBar = false;





        // Character
        public int userHP;
        public int userDelay;
        public int userGold;
        public int userDamage;
        public string userJob;
        public int userMaxHP;
        public int userSelectCount = 0;
        public List<string> userProb = new List<string>();
        public List<string> userShow = new List<string>(0);






    }
}
