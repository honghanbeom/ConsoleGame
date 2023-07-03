using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Variable
    {
        #region 지역변수
        // Map
        public int moveCount = 11;
        public string heal = "♨";
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
        public string userSelect = "┃";
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
        public int userSelectCount = 0;
        // (유저 공격 리스트)
        public List<string> userProb = new List<string>();
        public List<string> userCopy = new List<string>();

        // Shop
        public List<string> itemInven = new List<string>(); // 중복 없는 인벤의 아이템
        public List<string> shopListAll; // 아이템 이름의 Key
        public List<string> shopList = new List<string>(); // shopListAll에서 중복없이 4개
        // 전체 아이템 이름, 아이템 가격
        public Dictionary<string, int> itemAll = new Dictionary<string, int>();
        public int outCount = 0;
        public int resetCount = 0;

        // (Restrict of Items) 
        public int itemOn1 = 0;
        public int itemOn2 = 0;
        public int itemOn7 = 0;
        public int itemOn9 = 0;
        public int initialCount1 = 0;
        public int initialCount2 = 0;
        public int initialCount3 = 0;
        public int initialCount4 = 0;
        public bool itemOn3 = false;
        public bool itemOn4 = false;
        public bool itemOn5 = false;
        public bool itemOn6 = false;
        public bool itemOn8 = false;
        public bool itemOn10 = false;
        public bool itemOn11 = false;
        public bool itemOn12 = false;
        public bool itemOn13 = false;
        public bool itemOn14 = false;
        public bool itemOn15 = false;
        public bool itemOn16 = false;
        #endregion

        #region 인스턴스화
        GamePrint g = new GamePrint();
        #endregion

        #region 객체 초기화 메소드
        public void Get(GamePrint g_)
        { 
            this.g = g_;
        }
        #endregion

        #region 캐릭터 초기화 메소드
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
        #endregion

        #region 케릭터 프린트 메소드
        public void CharacterPrint(string userJob, int userMaxHP, int userArmor, int userDamage, int userGold, int userDelay)
        {
            Console.SetCursorPosition(38, 11);

            Console.WriteLine("[직업 : {0}]", userJob);
            Console.SetCursorPosition(38, 12);

            Console.WriteLine("[체력 : {0}]", userMaxHP);
            Console.SetCursorPosition(38, 13);

            Console.WriteLine("[방어력 : {0}]", userArmor);
            Console.SetCursorPosition(38, 14);

            Console.WriteLine("[공격력 : {0}]", userDamage);
            Console.SetCursorPosition(38, 15);

            Console.WriteLine("[골드 : {0}]", userGold);
            Console.SetCursorPosition(34, 16);

            Console.WriteLine("[바 이동속도 : {0}초]", userDelay*0.001);
        }
        #endregion

        #region 케릭터 선택 메소드
        public void Select()
        {
            while (userSelectCount != 1)
            {
                g.GameConsolePrint();

                Console.SetCursorPosition(38, 5);
                Console.WriteLine("[캐릭터 선택창]");
                Console.SetCursorPosition(29, 6);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("[1. 전사]  ");
                Console.ResetColor();

                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("[2. 도적]  ");
                Console.ResetColor();

                Console.ForegroundColor= ConsoleColor.Blue;
                Console.Write("[3. 마법사] ");
                Console.ResetColor();

                Console.SetCursorPosition(24, 7);
                Console.WriteLine("원하시는 직업을 보시려면 번호를 눌러주세요");

                // 유저 키 입력
                ConsoleKeyInfo charInfo = Console.ReadKey(true);

                switch (charInfo.Key)
                {
                    // 전사
                    case ConsoleKey.D1:

                        Console.SetCursorPosition(38, 10);
                        CharacterPrint("전사", 120, 2 ,10, 100, 40) ;

                        Console.SetCursorPosition(22, 17);
                        Console.WriteLine("체력이 많고, 가장 무난한 초보자용 캐릭터입니다.");

                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();

                        // 케릭터 확정 키 입력
                        ConsoleKeyInfo charSelect1 = Console.ReadKey(true);
                        switch (charSelect1.Key)
                        {
                            case ConsoleKey.Y:
                                WarriorAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();
                                break;
                        }
                        break;

                    // 도적
                    case ConsoleKey.D2:

                        Console.SetCursorPosition(38, 10);
                        CharacterPrint("도적", 80, 1, 12, 300, 30);
   
                        Console.SetCursorPosition(22, 17);
                        Console.WriteLine("성공확률, 골드가 높은 대신 공격력과 아머, 체력이 낮습니다.");

                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();

                        // 케릭터 확정 키 입력
                        ConsoleKeyInfo charSelect2 = Console.ReadKey(true);
                        switch (charSelect2.Key)
                        {
                            case ConsoleKey.Y:
                                TheifAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();

                                break;
                        }
                        break;

                    // 마법사
                    case ConsoleKey.D3:
                        Console.SetCursorPosition(38, 10);
                        CharacterPrint("마법사", 70, 1, 30, 150, 25);

                        Console.SetCursorPosition(22, 17);
                        Console.WriteLine("골드, 공격력이 높은 대신 아머와 체력, 성공확률이 낮습니다.");

                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();

                        // 케릭터 확정 키 입력
                        ConsoleKeyInfo charSelect3 = Console.ReadKey(true);
                        switch (charSelect3.Key)
                        {
                            case ConsoleKey.Y:
                                MagicianAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();
                                break;
                        }
                        break;

                    // 개발자
                    case ConsoleKey.Tab:
                        Console.SetCursorPosition(38, 10);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("[개발자 모드]");
                        Console.ResetColor();

                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();

                        // 케릭터 확정 키 입력
                        ConsoleKeyInfo charSelect4 = Console.ReadKey(true);
                        switch (charSelect4.Key)
                        {
                            case ConsoleKey.Y:
                                DevelopAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();
                                break;
                        }
                        break;

                    // 잘못된 입력 처리
                    default:
                        Console.SetCursorPosition(38, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("잘못된 입력값입니다.");
                        Console.ResetColor();
                        Console.Clear();
                        break;
                }
            }
        }
        #endregion

        #region 전사특성 메소드

        public void WarriorAdd()
        {
            //(string userJob, int userMaxHP, int userDamage, int userGold,
            // int userDelay, int userCurrentHP, int userArmor)           
            CharacterInit("전사", 120, 10, 100, 40, 120, 2);
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
        #endregion

        #region 도적특성 메소드
        public void TheifAdd()
        {
            //(string userJob, int userMaxHP, int userDamage, int userGold,
            // int userDelay, int userCurrentHP, int userArmor)
            CharacterInit("도적", 80, 12, 300, 30, 80, 1);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
        }
        #endregion

        #region 마법사특성 메소드
        public void MagicianAdd()
        {
            //(string userJob, int userMaxHP, int userDamage, int userGold,
            // int userDelay, int userCurrentHP, int userArmor)
            CharacterInit("마법사", 70, 30, 150, 25, 70, 1);
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
        #endregion

        #region 개발자특성 메소드
        public void DevelopAdd()
        {
            //(string userJob, int userMaxHP, int userDamage, int userGold,
            // int userDelay, int userCurrentHP, int userArmor)
            CharacterInit("개발자", 1000, 10, 100_000, 100, 1000, 1);
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
        #endregion

        #region 스텟 출력 메소드
        public void Stat()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();

            Console.SetCursorPosition(23, 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[유저 정보]");
            Console.ResetColor();

            Console.SetCursorPosition(18,5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[유저 직업 : ");
            Console.ResetColor();

            // 케릭터별 출력 색 조절
            if (userJob == "전사")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");

            }
            if (userJob == "도적")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");


            }
            if (userJob == "마법사")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");


            }
            if (userJob == "개발자")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");


            }
            Console.SetCursorPosition(18, 6);
            Console.Write("[현재 체력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userCurrentHP);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(18, 7);
            Console.Write("[최대 체력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userMaxHP);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 8);

            Console.Write("[공격력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userDamage);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(18, 9);
            Console.Write("[방어력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userArmor);
            Console.ResetColor();
            Console.Write("]");

            // 성공, 실패 갯수 카운트
            int userSuccessCount = userProb.Count(x => x == success);
            int userfailCount = userProb.Count(x => x == fail);

            Console.SetCursorPosition(18, 10);
            Console.Write("[성공 확률 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userSuccessCount);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(18, 11);
            Console.Write("[실패 확률 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userfailCount);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(18, 12);
            Console.Write("[바 이동속도 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userDelay*0.001);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(18, 13);
            Console.Write("[소지금 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userGold);
            Console.ResetColor();
            Console.Write("]");
        }
        #endregion
    }
}
