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

        public void MonsterInit(string MonsterName, int MonsterDamage, int MonsterHP)
        { 
            this.monsterName = MonsterName;
            this.monsterDamage = MonsterDamage; 
            this.monsterHP = MonsterHP; 

        }

        public void NormalMonsterPrint(string monsterName, int monsterDamage, int monsterHP)
        {
            Console.WriteLine("[일반 몬스터]");
            Console.WriteLine("[몬스터 이름 : {0}]",monsterName);
            Console.WriteLine("[몬스터 체력 : {0}]",monsterHP);
            Console.WriteLine("[몬스터 데미지 : {0}]",monsterDamage);

        }

        public void EliteMonsterPrint(string monsterName, int monsterDamage, int monsterHP)
        {
            Console.WriteLine("[엘리트 몬스터]");
            Console.WriteLine("[몬스터 이름 : {0}]", monsterName);
            Console.WriteLine("[몬스터 체력 : {0}]", monsterHP);
            Console.WriteLine("[몬스터 데미지 : {0}]", monsterDamage);
            // 엘리스 이름별 몬스터 특수효과 추가

        }

        public void BossMonsterPrint(string monsterName, int monsterDamage, int monsterHP)
        {
            Console.WriteLine("[보스 몬스터]");
            Console.WriteLine("[몬스터 이름 : {0}]", monsterName);
            Console.WriteLine("[몬스터 체력 : {0}]", monsterHP);
            Console.WriteLine("[몬스터 데미지 : {0}]", monsterDamage);
            // 보스몬스터 특수효과 추가
        }
    }
}
