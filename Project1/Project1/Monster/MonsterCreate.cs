using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    public class MonsterCreate
    {
        public string monsterName;
        public int monsterDamage;
        public int monsterHP;
        public int monsterMoney;
        public int monsterArmor;

        Variable v = new Variable();
        GamePrint g = new GamePrint();

        public void Get(Variable var_, GamePrint g_)
        {
            this.v = var_;
            this.g = g_;
        }

        public void MonsterInit(string MonsterName, int MonsterDamage, 
                                int MonsterHP, int monsterMoney, int monsterArmor)
        { 
            this.monsterName = MonsterName;
            this.monsterDamage = MonsterDamage; 
            this.monsterHP = MonsterHP;
            this.monsterMoney = monsterMoney;
            this.monsterArmor = monsterArmor;


        }

        public void NormalMonsterPrint(string monsterName, int monsterDamage, int monsterHP,
            int monsterArmor)
        {

            Console.SetCursorPosition(24, 5);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("일반  ");
            Console.ResetColor();
            Console.Write("몬스터]");

            Console.SetCursorPosition(21, 6);
            Console.Write("[몬스터 이름 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterName);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(23, 7);
            Console.Write("[몬스터 HP : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterHP);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(22, 8);
            Console.Write("[몬스터 방어력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterArmor);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(22, 9);
            Console.Write("[몬스터 데미지 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterDamage);
            Console.ResetColor();
            Console.Write("]");


        }

        public void EliteMonsterPrint(string monsterName, int monsterDamage,
            int monsterHP, int monsterArmor)
        {
            Console.SetCursorPosition(24, 5);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("엘리트  ");
            Console.ResetColor();
            Console.Write("몬스터]");

            Console.SetCursorPosition(23, 6);
            Console.Write("[몬스터 이름 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterName);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(23, 7);
            Console.Write("[몬스터 HP : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterHP);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(23, 8);
            Console.Write("[몬스터 방어력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterArmor);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(23, 9);
            Console.Write("[몬스터 데미지 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterDamage);
            Console.ResetColor();
            Console.Write("]");

        }

        public void BossMonsterPrint(string monsterName, int monsterDamage,
            int monsterHP, int monsterArmor)
        {
            Console.SetCursorPosition(24, 5);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("보스  ");
            Console.ResetColor();
            Console.Write("몬스터]");

            Console.SetCursorPosition(23, 6);
            Console.Write("[몬스터 이름 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterName);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(23, 7);
            Console.Write("[몬스터 HP : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterHP);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(23, 8);
            Console.Write("[몬스터 방어력 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterArmor);
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(23, 9);
            Console.Write("[몬스터 데미지 : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", monsterDamage);
            Console.ResetColor();
            Console.Write("]");
            // 보스몬스터 특수효과 추가 - 실명, 흡혈, 성공칸 감소, 실패 칸 증가
        }

        public void PlayerDamage()
        {

            Console.SetCursorPosition(26, 8);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("[유저 턴]");
            Console.ResetColor();
            Console.SetCursorPosition(22, 9);
            Console.Write("[유저 데미지 : ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("{0}", v.userDamage);
            Console.ResetColor();
            Console.Write("]");
            monsterHP -= v.userDamage;
            Console.SetCursorPosition(23, 10);
            Console.Write("[몬스터 HP : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", monsterHP);
            Console.ResetColor();
            Console.Write("]");
        }

        public void MonsterDamage()
        {
            Console.SetCursorPosition(23, 11);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[몬스터 턴]");
            Console.ResetColor();
            Console.SetCursorPosition(23, 12);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", monsterName);
            Console.ResetColor();
            Console.Write("]의 공격]");

            Console.SetCursorPosition(23, 13);
            Console.Write("[몬스터 데미지 : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", monsterDamage);
            Console.ResetColor();
            Console.Write("]");
            v.userCurrentHP -= monsterDamage + v.userArmor;

            Console.SetCursorPosition(23, 14);
            Console.Write("[유저 HP : ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("{0}", v.userCurrentHP);
            Console.ResetColor();
            Console.Write("]");

        }
    }
}
