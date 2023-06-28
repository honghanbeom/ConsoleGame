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

        public void Get(Variable var_)
        {
            this.v = var_;
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
            Console.WriteLine("[일반 몬스터]");
            Console.WriteLine("[몬스터 이름 : {0}]",monsterName);

            Console.WriteLine("[몬스터 HP : {0}]",monsterHP);
            Console.WriteLine("[몬스터 방어력 : {0}]", monsterArmor);
            Console.WriteLine("[몬스터 데미지 : {0}]",monsterDamage);


        }

        public void EliteMonsterPrint(string monsterName, int monsterDamage,
            int monsterHP, int monsterArmor)
        {
            Console.WriteLine("[엘리트 몬스터]");
            Console.WriteLine("[몬스터 이름 : {0}]", monsterName);
            Console.WriteLine("[몬스터 HP : {0}]", monsterHP);
            Console.WriteLine("[몬스터 방어력 : {0}]", monsterArmor);

            Console.WriteLine("[몬스터 데미지 : {0}]", monsterDamage);
            // 엘리스 이름별 몬스터 특수효과 추가

        }

        public void BossMonsterPrint(string monsterName, int monsterDamage,
            int monsterHP, int monsterArmor)
        {
            Console.WriteLine("[보스 몬스터]");
            Console.WriteLine("[몬스터 이름 : {0}]", monsterName);
            Console.WriteLine("[몬스터 HP : {0}]", monsterHP);
            Console.WriteLine("[몬스터 방어력 : {0}]", monsterArmor);

            Console.WriteLine("[몬스터 데미지 : {0}]", monsterDamage);
            // 보스몬스터 특수효과 추가 - 실명, 흡혈, 성공칸 감소, 실패 칸 증가
        }

        public void PlayerDamage()
        {
            Console.WriteLine("[유저의 턴]");
            Console.WriteLine("[유저 데미지 : {0}]", v.userDamage);
            monsterHP -= v.userDamage;
            Console.WriteLine("[몬스터 체력 : {0}]", monsterHP);
        }

        public void MonsterDamage()
        {
            Console.WriteLine("[몬스터의 턴]", monsterName);
            Console.WriteLine("[{0}의 공격]",monsterName);
            Console.WriteLine("[몬스터 데미지 : {0}]", monsterDamage);
            v.userCurrentHP -= monsterDamage + v.userArmor;
            Console.WriteLine("[플레이어 체력 : {0}]", v.userCurrentHP);

        }
    }
}
