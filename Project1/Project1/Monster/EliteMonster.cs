using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    public class EliteMonster
    {

        #region P/Invoke 선언
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        #endregion

        #region 인스턴스화
        Variable v = new Variable();
        MonsterCreate mc = new MonsterCreate();
        AttackSystem att = new AttackSystem();
        GamePrint g = new GamePrint();
        #endregion

        #region 객체 초기화 메소드
        public void Get(Variable v, MonsterCreate monsterCreate_, AttackSystem attack_,
            GamePrint print_)
        {
            this.v = v;
            this.mc = monsterCreate_;
            this.att = attack_;
            this.g = print_;  
        }
        #endregion

        #region 엘리트 몬스터 초기화 메소드
        public void MonsterAdd()
        {
            Random random = new Random();
            int mRandomIndex = random.Next(0, 3);
            switch (mRandomIndex)
            {
                case 0:
                    {
                        mc.MonsterInit("좀비 오크", 8, 70, 90, 2);
                        mc.EliteMonsterPrint("좀비 오크", 8, 70, 2);
                    }
                    break;
                case 1:
                    {
                        // 스톤골렘 특수효과로 스턴
                        mc.MonsterInit("스톤 골렘", 5, 60, 100, 5);
                        mc.EliteMonsterPrint("스톤 골렘", 5, 60, 5);
                    }
                    break;
                case 2:
                    {
                        // 와이번 특수효과로 회피
                        mc.MonsterInit("가고일", 15, 30, 120, 2);
                        mc.EliteMonsterPrint("가고일", 15, 30, 2);
                    }
                    break;
            }
        }
        #endregion

        #region 엘리트 몬스터 전투 메소드
        public void Fight()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();

            MonsterAdd();

            Console.SetCursorPosition(17, 2);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0}", mc.monsterName);
            Console.ResetColor();
            Console.Write("와(과) 전투를 시작합니다!]");

            Console.SetCursorPosition(20, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Fight]");
            Console.ResetColor();

            _getch();

            // 골렘 스턴 카운트
            int golemStun = 0;

            // 전투 로직
            while (mc.monsterHP > 0 && v.userCurrentHP > 0)
            {
                // 좀비 오크
                if (golemStun == 0 && mc.monsterName == "좀비 오크")
                {
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    g.OakPrint();

                    OakPrint();
                    Console.SetCursorPosition(5, 28);
                    Console.WriteLine("                                        ");

                    // 전투 로직
                    att.AttackControl();
                    mc.MonsterDamage();
                    Thread.Sleep(1000);
                    v.spaceBar = false;
                    v.index = 0;
                }

                // 스톤골렘
                if (golemStun == 0 && mc.monsterName == "스톤 골렘")
                {
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    g.stoneGolemPrint();
                    StoneGolemPrint();


                    Console.SetCursorPosition(5, 28);
                    Console.WriteLine("                                        ");

                    // 전투 로직
                    att.AttackControl();
                    mc.MonsterDamage();
                    Thread.Sleep(1000);
                    v.spaceBar = false;
                    v.index = 0;
                }

                // 골렘 스톤 스턴 효과
                if (golemStun == 1)
                {

                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    g.GameMapPrint();
                    g.GameMonsterPrint();
                    Console.ResetColor();

                    // 몬스터 정보 칸에 출력
                    Console.SetCursorPosition(68, 15);
                    Console.Write("[");
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.Write("골렘 스턴");
                    Console.ResetColor();
                    Console.Write("]");


                    // 전투 로직
                    mc.MonsterDamage();
                    Thread.Sleep(1500);
                    v.index = 0;
                    v.spaceBar = false;
                    golemStun--;
                    Console.Clear();
            
                }
                if (mc.monsterName == "스톤 골렘")
                {
                    Random random = new Random();
                    int stoneRandom = random.Next(0, 10);
                    // 30%의 확률
                    if (stoneRandom >= 7)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed; 
                        g.GameMapPrint();
                        Console.SetCursorPosition(14, 5);
                        Console.Write("[골렘의 특수효과 : 스턴]");
                        Console.ResetColor();

                        Console.SetCursorPosition(14, 7);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("유저는 이번 턴 공격할 수 없습니다.");
                        Console.ResetColor();

                        Thread.Sleep(2000);
                        Console.Clear();
                        golemStun++;
                    }
                }
                if (mc.monsterName == "가고일")
                {
                    Random random = new Random();
                    int wyvernRandom = random.Next(0, 10);
                    // 40%의 확률 회피
                    if (wyvernRandom >= 6)
                    {
                        Console.Clear();
                        g.GameMapPrint();
                        g.GameInfoPrint();

                        g.WyvernPrint();
                        GagoylePrint();

                        // 결과에 생산하지않는 더미
                        att.Copy();
                        att.RandomUserDamage();
                        att.Spacebar();
                        att.ResultDelete();

                        
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        g.GameMapPrint();
                        g.GameMonsterPrint();
                        Console.ResetColor();

 
                        Console.ForegroundColor= ConsoleColor.DarkRed;
                        Console.SetCursorPosition(21, 5);
                        Console.Write("[가고일의 특수효과 : 회피]");
                        Console.ResetColor();
                        Console.SetCursorPosition(14, 6);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("유저의 공격을 가고일이 회피했습니다.");
                        Console.ResetColor();



                        Console.SetCursorPosition(68, 15);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("가고일 회피");
                        Console.ResetColor();
                        Console.Write("]");

                        mc.MonsterDamage();
                        Thread.Sleep(2000);
                        v.index = 0;
                        v.spaceBar = false;
                        Console.Clear();

                    }
                    else 
                    {
                        // 평소
                        Console.Clear();
                        g.GameMapPrint();
                        g.GameInfoPrint();

                        g.WyvernPrint();

                        GagoylePrint();
                        Console.SetCursorPosition(5, 28);
                        Console.WriteLine("                                        ");

                        att.AttackControl();
                        mc.MonsterDamage();
                        Thread.Sleep(1000);

                        v.spaceBar = false;
                        v.index = 0;
                    }
                }
            }

            // 전투 완료 로직
            if (mc.monsterHP <= 0 && v.userCurrentHP > 0)
            {
                Console.Clear();
                g.GameMapPrint();
                g.GameInfoPrint();
                Console.SetCursorPosition(24, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[전투 완료]");
                Console.ResetColor();

                v.userGold += mc.monsterMoney;

                Console.SetCursorPosition(22, 6);
                Console.Write("[유저 HP : ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("{0}", v.userCurrentHP);
                Console.ResetColor();
                Console.Write("]");

                Console.SetCursorPosition(20, 7);
                Console.Write("[유저 골드 : ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("{0}", v.userGold);
                Console.ResetColor();
                Console.Write("]");

                Console.SetCursorPosition(20, 28);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press Any Key To Continue");
                Console.ResetColor();

                _getch();
            }
            // 게임 오버 로직
            if (v.userCurrentHP <= 0)
            {
                g.GameOver();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        #endregion

        #region 가고일 정보 출력 메소드
        public void GagoylePrint()
        {
            Console.SetCursorPosition(26, 5);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("가고일");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 17);
            Console.Write("[몬스터체력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterHP);
            Console.ResetColor();
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("30");
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(21, 19);
            Console.Write("[몬스터 방어력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterArmor);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 18);
            Console.Write("[몬스터 공격력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterDamage);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 20);
            Console.Write("[몬스터 특수효과 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("회피");
            Console.ResetColor();
            Console.Write("]");
        }
        #endregion

        #region 골렘 스톤 정보 출력 메소드
        public void StoneGolemPrint()
        {
            Console.SetCursorPosition(26, 5);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("스톤 골렘");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 17);
            Console.Write("[몬스터 HP : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterHP);
            Console.ResetColor();
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("60");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 19);
            Console.Write("[몬스터 방어력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterArmor);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 18);
            Console.Write("[몬스터 공격력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterDamage);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 20);
            Console.Write("[몬스터 특수효과 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("스턴");
            Console.ResetColor();
            Console.Write("]");
        }
        #endregion

        #region 좀비오크 정보 출력 메소드
        public void OakPrint()
        {
            Console.SetCursorPosition(26, 5);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("좀비 오크");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 19);
            Console.Write("[몬스터 HP : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterHP);
            Console.ResetColor();
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("70");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 20);
            Console.Write("[몬스터 방어력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterArmor);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 21);
            Console.Write("[몬스터 공격력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterDamage);
            Console.ResetColor();
            Console.Write("]");
        }
        #endregion
    }
}
