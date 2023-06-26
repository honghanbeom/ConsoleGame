using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Project1
{
    public class AttackSystem
    {
        // 색깔 시스템

        Variable v = new Variable();

        public void Get(Variable var_)
        {
            this.v = var_;
        }





        //public void WarriorAdd()
        //{
        //    userProb.Add(userSelect);
        //    userProb.Add(success);
        //    userProb.Add(success);
        //    userProb.Add(success);
        //    userProb.Add(success);
        //    userProb.Add(fail);
        //    userProb.Add(fail);
        //    userProb.Add(fail);
        //    userProb.Add(fail);
        //}








        public void AttackControl()
        {
            RandomUserDamage();
            Spacebar();
            userView();
        }






        public void userView()
        {
            //int userSelectIndex = userDamage.IndexOf(userSelect);
            //int failIndex = userDamage.IndexOf(fail);
            //int successIndex = userDamage.IndexOf(success);


            foreach (var n in v.userProb)
            {
                Console.Write(n);
            }
            Console.WriteLine();


            int userSelectIndex = v.userProb.IndexOf(v.userSelect);
            int upFailIndex = v.userProb.FindIndex(userSelectIndex + 1, x => x == v.fail);
            int upSuccessIndex = v.userProb.FindIndex(userSelectIndex + 1, x => x == v.success);
            int downFailIndex = v.userProb.FindIndex(userSelectIndex - 1, x => x == v.fail);
            int downSuccessIndex = v.userProb.FindIndex(userSelectIndex - 1, x => x == v.success);

            if (userSelectIndex + 1 == upFailIndex && userSelectIndex - 1 == downFailIndex)
            {
                Console.WriteLine("데미지 실패");
            }

            else if (userSelectIndex + 1 == upSuccessIndex && userSelectIndex - 1 == downSuccessIndex)
            {
                Console.WriteLine("데미지 성공");
            }

        }


        public void RandomUserDamage()
        {
            Random random = new Random();
            // fail의 갯수 = countFail
            int countFail = v.userProb.Where(x => x.Equals(v.fail)).Count();
            // 1 ~ fail의 갯수 중 랜덤 숫자 하나 생성(최소 한개)
            int failmove = random.Next(1, countFail);

            // bar가 존재하기 때문에 index는 (+ 1) -> 이게 없음
            v.userProb.RemoveRange(v.userProb.Count - failmove, failmove);

            // bar가 0의 위치에 있다는 것을 생각하고, 제거한 것 만큼 추가
            for (int i = 0; i <= failmove; i++)
                
            {
                v.userProb.Insert(i+1, v.fail);
            }
        
        }








        public void Spacebar()
        {
            Thread thread1 = new Thread(Select);
            thread1.Start();
            userInput();
        }


        public void userInput()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    v.spaceBar = true;
                    break;
                }
            }
        }

        public void Select()
        {
            while (!v.spaceBar)
            {

                v.index = v.userProb.IndexOf(v.userSelect);
                if (v.index == 0)
                {
                    //foreach (string n in userDamage)
                    //{
                    //    Console.Write("{0}", n);
                    //}
                    //Console.WriteLine();
                    //Thread.Sleep(1000);


                    for (int i = 0; i < v.userProb.Count - 1; i++)
                    {
                        if (v.spaceBar)  // spaceBar가 true인 경우 종료
                        {
                            return;
                        }
                        Swap(i, i + 1);
                        foreach (string n in v.userProb)
                        {
                            Console.Write("{0}", n);
                        }
                        Console.WriteLine();
                        Thread.Sleep(v.userBlink);
                        //Console.Clear();
                        v.index++;
                    }
                }

                if (v.index == v.userProb.Count - 1)
                {
                    for (int i = v.userProb.Count - 1; i >= 1; i--)
                    {
                        if (v.spaceBar)  // spaceBar가 true인 경우 종료
                        {
                            return;
                        }
                        Swap(i, i - 1);
                        foreach (string n in v.userProb)
                        {
                            Console.Write("{0}", n);
                        }
                        Console.WriteLine();
                        Thread.Sleep(v.userBlink);
                        //Console.Clear();
                        v.index--;
                    }
                }
            }
        }


        public void Swap(int listOne, int listTwo)
        {
            string temp = v.userProb[listOne];
            v.userProb[listOne] = v.userProb[listTwo];
            v.userProb[listTwo] = temp;
        }

    }
}
