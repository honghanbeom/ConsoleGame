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


        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();

        Variable v = new Variable();
        MonsterCreate mc = new MonsterCreate();
        //Character ch = new Character();
        AttackSystem att = new AttackSystem();
        GamePrint print = new GamePrint();

        public void Get(Variable v, MonsterCreate monsterCreate_, AttackSystem attack_,
            GamePrint print_)
        {
            this.v = v;
            this.mc = monsterCreate_;
            //this.ch = character_;
            this.att = attack_;
            this.print = print_;
        }

        public void MonsterAdd()
        {
            // 보스 특수효과 흡혈, 피뿌리기(확률안보이게)
            mc.MonsterInit("뱀파이어", 50, 500, 0, 10);
            mc.BossMonsterPrint("뱀파이어", 50, 500, 10);
        }

        public void Fight()
        {
            MonsterAdd();
            Console.WriteLine("[{0}와 전투를 시작합니다!]", mc.monsterName);
            Console.WriteLine("[Press Any Key To Fight]");
            _getch();
            while (v.userCurrentHP > 0)
            {

                MonsterAdd();
                Console.WriteLine("[{0}와 전투를 시작합니다!]", mc.monsterName);
                Console.WriteLine("[Press Any Key To Fight]");
                _getch();
                while (mc.monsterHP > 0 && v.userCurrentHP > 0)
                {
                    att.AttackControl();
                    Thread.Sleep(1000);
                    mc.MonsterDamage();
                    v.index = 0;
                    v.spaceBar = false;
                }
                if (mc.monsterHP <= 0 && v.userCurrentHP > 0)
                {
                    Console.WriteLine("전투가 완료되었습니다.");
                    print.GameClear();
                    Thread.Sleep(2000);
                    Environment.Exit(0);

                }
                if (v.userCurrentHP <= 0)
                {
                    print.GameOver();
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }

            }
        }

    }
}
