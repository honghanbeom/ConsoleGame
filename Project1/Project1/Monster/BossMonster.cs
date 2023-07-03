using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Project1
{
    public class BossMonster
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
        Random random = new Random();
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

        #region 보스 몬스터 초기화 메소드
        public void MonsterAdd()
        {
            mc.MonsterInit("뱀파이어", 20, 250, 0, 5);
        }
        #endregion

        #region 전투 & 스킬 메소드
        public void Fight()
        {
            g.BossPrint();
            MonsterAdd();

            Console.SetCursorPosition(20, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Fight]");
            Console.ResetColor();

            _getch();

            // 공격 2번중 한번은 반드시 일반공격 
            // 회피 (8,9) 흡혈 (6,7) 석화(0,1) 일반(2,3,4,5)
            // <공격 패턴>
            // 일반 100%
            // 스킬 60% 일반 40%
            // <공격 패턴>

            // 전투 로직
            while (mc.monsterHP > 0 && v.userCurrentHP > 0)
            {
                int skillRandom = random.Next(0, 10);

                // 회피 20%
                if (skillRandom >= 8)
                {
                    AttackPrint();
                    Avoid();
                    mc.MonsterDamage();
                    v.index = 0;
                    v.spaceBar = false;
                    Thread.Sleep(2000);

                }
                // 20% 흡혈
                else if (skillRandom < 8 && skillRandom >= 6)
                { 
                    BloodSucking();
                    Thread.Sleep(1500);
                }

                //10 % 석화
                else if (skillRandom == 0 || skillRandom == 1) 
                {
                    Console.Clear();
                    att.petrificationCount++;
                    AttackPrint();
                    att.AttackControl();
                    mc.MonsterDamage();
                    v.index = 0;
                    v.spaceBar = false;
                    Thread.Sleep(1700);
                    att.petrificationCount--;

                }
                AttackPrint();
                att.AttackControl();
                mc.MonsterDamage();
                v.index = 0;
                v.spaceBar = false;
                Thread.Sleep(2000);
            }
            // 승리 로직
            if (mc.monsterHP <= 0 && v.userCurrentHP > 0)
            {
                g.GameClear();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            // 패배 로직
            if (v.userCurrentHP <= 0)
            {
                g.GameOver();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        #endregion

        #region 보스 몬스터 출력 메소드
        public void AttackPrint()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();
            g.DraculaPrint();

            Console.SetCursorPosition(26, 2);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("뱀파이어");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 19);
            Console.Write("[몬스터체력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterHP);
            Console.ResetColor();
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("250");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 20);
            Console.Write("[몬스터 방어력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterArmor);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(13, 22);
            Console.Write("[몬스터 특수효과 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("흡열");
            Console.ResetColor();
            Console.Write(",");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("석화");
            Console.ResetColor();
            Console.Write(",");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("밤의 날개");
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

        #region 보스 회피 메소드
        public void Avoid()
        {
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

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(18, 5);
            Console.Write("[뱀파이어의 특수효과 : 밤의 날개]");
            Console.ResetColor();

            Console.SetCursorPosition(12, 6);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("유저의 공격을 뱀파이어가 회피했습니다.");
            Console.ResetColor();

            Console.SetCursorPosition(68, 15);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("특수효과 : 밤의 날개");
            Console.ResetColor();
            Console.Write("]");
        }
        #endregion

        #region 보스 흡혈 메소드
        public void BloodSucking()
        {
            // 흡혈 5~10 랜덤 데미지
            int bloodRandom = random.Next(5, 11);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            g.GameMapPrint();
            g.GameMonsterPrint();
            Console.ResetColor();

            Console.SetCursorPosition(18, 5);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[뱀파이어의 특수효과 : 흡혈]");
            Console.ResetColor();

            Console.SetCursorPosition(10, 6);
            Console.Write("유저의 HP를 ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", bloodRandom);
            Console.ResetColor();        
            Console.Write("만큼 뱀파이어가 흡혈했습니다.");

            v.userCurrentHP -= bloodRandom;

            Console.SetCursorPosition(68, 15);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("특수효과 : 흡혈");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 7);
            Console.Write("[현재 HP : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", v.userCurrentHP);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(21, 8);
            Console.Write("[몬스터 HP : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}", mc.monsterHP);
            Console.ResetColor();
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("250");
            Console.ResetColor();
            Console.Write("]");
            Thread.Sleep(2000);
        }
        #endregion
    }
}
