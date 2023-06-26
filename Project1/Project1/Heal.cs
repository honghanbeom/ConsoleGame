using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Heal
    {

        Variable v = new Variable();

        public void Get(Variable var_)
        {
            this.v = var_;
        }



        public void HealHP()
        {
            Console.WriteLine("유저의 체력 40%을 회복합니다.");
            if (v.userMaxHP < v.userHP * 0.4)
            {
                v.userHP = v.userMaxHP;
                Console.WriteLine("[체력  : {0}]", v.userHP);
            }
            else
            {
                v.userHP = (int)(v.userHP * 1.4);
                Console.WriteLine("[체력  : {0}]", v.userHP);
            }

        }
    }
}
