using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class NormalMonster
    {
        Variable v = new Variable();

        public void Get(Variable var_)
        {
            this.v = var_;
        }



        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();

        MonsterCreate mc = new MonsterCreate();
        Character ch = new Character();

        public void Get(MonsterCreate monsterCreate_, Character character_)
        { 
            this.mc = monsterCreate_;
            this.ch = character_;
        }

        public void MonsterAdd()
        {
            // 랜덤으로 몬스터 생성 추가해야함
            mc.MonsterInit("고블린", 5, 20);
            mc.NormalMonsterPrint("고블린",5,20);
        }

        public void Fight()
        {
            while (v.userHP > 0)
            {
                Console.WriteLine("[{0}와 전투를 시작합니다!]",mc.monsterName);
                Console.WriteLine("[Press Any Key To Fight]");
                _getch();
                // 여기 뒤에 전투 시스템
           
            }
        }
        

    }
}
