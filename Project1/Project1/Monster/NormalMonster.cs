using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    public class NormalMonster
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
        Item i = new Item();
        #endregion

        #region 객체 초기화 메소드
        public void Get(Variable v, MonsterCreate mc_, AttackSystem attack_,GamePrint print, Item i_)
        { 
            this.v = v;
            this.att = attack_;
            this.g = print;
            this.mc = mc_;
            this.i = i_;
        }
        #endregion

        #region 일반 몬스터 초기화 메소드
        public void MonsterAdd()
        {
            Random random = new Random();
            int mRandomIndex = random.Next(0,5);
            switch (mRandomIndex)
            {
                case 0:
                    {
                        mc.MonsterInit("거미", 5, 20, 30, 1);
                        mc.NormalMonsterPrint("거미", 5, 20, 1);
                    }
                    break;
                case 1:
                    {
                        // 영혼의 망토 드롭
                        mc.MonsterInit("좀비", 2, 10, 20, 0);
                        mc.NormalMonsterPrint("좀비", 2, 10, 0);

                    }
                    break;
                case 2:
                    {
                        mc.MonsterInit("늑대", 7, 15, 15, 1);
                        mc.NormalMonsterPrint("늑대", 7, 15, 1);
                    }
                    break;
                case 3:
                    {                      
                        mc.MonsterInit("박쥐", 3, 12, 12, 0);
                        mc.NormalMonsterPrint("박쥐", 3, 12, 0);

                    }
                    break;
                case 4:
                    {
                        // 스켈레톤 갑옷 드롭
                        mc.MonsterInit("스켈레톤", 6, 10, 15, 2);
                        mc.NormalMonsterPrint("스켈레톤", 6, 10, 2);
                    }
                    break;
            }
        }
        #endregion

        #region 일반 몬스터 전투 & 아이템 드롭 메소드
        public void Fight()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();

            MonsterAdd();

            Console.SetCursorPosition(17, 2);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterName);
            Console.ResetColor();
            Console.Write("와(과) 전투를 시작합니다!]");

            Console.SetCursorPosition(20, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Fight]");
            Console.ResetColor();
            _getch();
            while (mc.monsterHP > 0 && v.userCurrentHP > 0)
            {

                Console.SetCursorPosition(5, 28);
                Console.WriteLine("                                        ");

                att.AttackControl();
                Thread.Sleep(1000);
                mc.MonsterDamage();
                v.spaceBar = false;
                v.index = 0;


            }
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
                if (mc.monsterName == "스켈레톤")
                {
                    Random random = new Random();
                    int skeletonRandom = random.Next(0, 10);
                    // 40%의 확률
                    if (skeletonRandom >= 6 && !v.itemInven.Contains("스켈레톤 갑옷"))
                    {
                        Console.SetCursorPosition(14, 9);
                        Console.Write("[");
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.Write("스켈레톤");
                        Console.ResetColor();
                        Console.Write("이 아이템을 떨어뜨렸다!]");
                        Thread.Sleep(1000);

                        Console.SetCursorPosition(20, 11);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("스켈레톤 갑옷");
                        Console.ResetColor();
                        Console.Write(" 획득]");
                        v.itemInven.Add("스켈레톤 갑옷");

                        Console.SetCursorPosition(20, 28);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ResetColor();
                        _getch();
                        i.ItemEffectOnInven();


                    }
                }
                if (mc.monsterName == "좀비")
                {
                    Random random = new Random();
                    int slimeRandom = random.Next(0, 10);
                    // 30%의 확률
                    if (slimeRandom >= 7 && !v.itemInven.Contains("영혼의 망토"))
                    {
                        Console.SetCursorPosition(14, 9);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("좀비");
                        Console.ResetColor();
                        Console.Write("가 아이템을 떨어뜨렸다!]");
                        Thread.Sleep(1000);

                        Console.SetCursorPosition(20, 11);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("영혼의 망토");
                        Console.ResetColor();
                        Console.Write(" 획득]");
                        v.itemInven.Add("영혼의 망토");

                        Console.SetCursorPosition(17, 28);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ResetColor();
                        _getch();
                        i.ItemEffectOnInven();

                    }
                }
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
    }
}
