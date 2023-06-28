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
        public string normal = "ⓜ";
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
        public bool spaceBar = false;





        // Character
        public int userCurrentHP;
        public int userDelay;
        public int userGold;
        public int userDamage;
        public int userArmor;
        public string userJob;
        public int userMaxHP;
        public int userCri;
        public int userSelectCount = 0;
        public List<string> userProb = new List<string>();
        public List<string> userCopy = new List<string>();



        // Shop
        public List<string> itemInven = new List<string>();
        public List<string> shopListAll;
        public List<string> shopList;
        public Dictionary<string, int> itemAll = new Dictionary<string, int>();




        public void CharacterInit(string userJob, int userMaxHP, int userDamage, int userGold, 
                                    int userDelay, int userCurrentHP, int userArmor)
        {
            this.userJob = userJob;
            this.userMaxHP = userMaxHP;
            this.userDamage = userDamage;
            this.userGold = userGold;
            this.userDelay = userDelay;  
            this.userCurrentHP = userCurrentHP;
            this.userArmor = userArmor;

        }



        public void CharacterPrint(string userJob, int userMaxHP, int userArmor, int userDamage, int userGold, int userDelay)
        {
            Console.WriteLine("[직업 : {0}]", userJob);
            Console.WriteLine("[체력 : {0}]", userMaxHP);
            Console.WriteLine("[방어력 : {0}]", userArmor);
            Console.WriteLine("[공격력 : {0}]", userDamage);
            Console.WriteLine("[골드 : {0}]", userGold);
            Console.WriteLine("[바 속도 : {0}]", userDelay);
        }

        public void Select()
        {
            while (userSelectCount != 1)
            {
                Console.WriteLine("[1. 전사] [2. 도적] [3. 마법사]");
                Console.WriteLine("원하시는 직업을 보시려면 번호를 눌러주세요");
                ConsoleKeyInfo charInfo = Console.ReadKey(true);
                switch (charInfo.Key)
                {
                    case ConsoleKey.D1:
                        CharacterPrint("전사", 100, 10, 2, 100, 20);
                        Console.WriteLine("체력이 많고, 가장 무난한 초보자용 캐릭터입니다.");

                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");

                        ConsoleKeyInfo charSelect1 = Console.ReadKey(true);
                        switch (charSelect1.Key)
                        {
                            case ConsoleKey.Y:
                                WarriorAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                break;
                        }
                        break;
                    case ConsoleKey.D2:
                        CharacterPrint("도적", 80, 7, 1, 200, 15);
                        Console.WriteLine("성공확률, 골드가 높은 대신 공격력과 아머, 체력이 낮습니다.");

                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        ConsoleKeyInfo charSelect2 = Console.ReadKey(true);
                        switch (charSelect2.Key)
                        {
                            case ConsoleKey.Y:
                                TheifAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                break;
                        }
                        break;
                    case ConsoleKey.D3:
                        CharacterPrint("마법사", 60, 20, 0, 120, 15);
                        Console.WriteLine("골드, 공격력이 높은 대신 아머와 체력, 성공확률이 낮습니다.");
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        ConsoleKeyInfo charSelect3 = Console.ReadKey(true);
                        switch (charSelect3.Key)
                        {
                            case ConsoleKey.Y:
                                MagicianAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("잘못된 입력값입니다.");
                        break;
                }
            }
        }


        //(string userJob, int userMaxHP, int userDamage, int userGold,
        //                            int userDelay, int userCurrentHP, int userArmor)
        public void WarriorAdd()
        {
            // 무난추
            CharacterInit("전사", 100, 10, 100, 20, 100, 2);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
        }

        public void TheifAdd()
        {
            // 바속도+, 골드+, 확률+, 데미지-, 아머-, 체력-
            CharacterInit("도적", 80, 7, 200, 15, 80, 1);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
        }

        public void MagicianAdd()
        {
            // 바속도+, 골드+, 확률+, 데미지+, 아머-, 체력-
            CharacterInit("마법사", 60, 20, 150, 15, 60, 0);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
        }

    


    }
}
