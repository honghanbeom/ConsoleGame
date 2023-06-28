using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Item
    {
        Variable v = new Variable();

        public void Get(Variable var_)
        {
            this.v = var_;
        }
        public string itemName;
        public int itemPrice;


        public void ItemInit(string itemName, int itemPrice)
        { 
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }
           


        public void AddItem()
        {
            v.itemAll.Add("성공 포션", 50); // 성공 +1
            v.itemAll.Add("체력 포션", 50); // 체력 +20
            v.itemAll.Add("철갑 방어구", 50); // 방어구 +1
            v.itemAll.Add("미스릴 방어구 ", 100); // 방어구 +3
            v.itemAll.Add("아이언 메이스", 100); // 공격력 +10
            v.itemAll.Add("마검", 150); // 공격력 + 20
            v.itemAll.Add("고기", 100); // 체력이 50% 이하 -> 체력 +50
            v.itemAll.Add("배", 70); // 최대체력 +10
            v.itemAll.Add("꾸깃한 복권", 0); // +10원
            v.itemAll.Add("신기한 버섯", 30); // 랜덤 성공+3, 실패 -3
            v.itemAll.Add("노예 상인의 목걸이", 200); // Elite, Boss 공격력+5,방어구+2
            v.itemAll.Add("수리 단검", 300); // userDelay 증가
        }

        public void ItemEffectOnInven()
        {
            Console.WriteLine("[보유 아이템]");
            for (int i = 0; i < v.itemInven.Count; i++)
            {
                switch (v.shopList[i])
                //--------------------------상점목록-------------------------------------
                //v.itemAll.Add("성공 포션"); // 성공 +1
                //v.itemAll.Add("체력 포션"); // 체력 +20
                //v.itemAll.Add("철갑 방어구"); // 방어구 +1
                //v.itemAll.Add("미스릴 방어구 "); // 방어구 +3
                //v.itemAll.Add("아이언 메이스"); // 공격력 +10
                //v.itemAll.Add("마검"); // 공격력 + 20
                //v.itemAll.Add("고기"); // 체력이 50% 이하 -> 체력 +50
                //v.itemAll.Add("배"); // 최대체력 +10
                //v.itemAll.Add("꾸깃한 복권"); // +10원
                //v.itemAll.Add("신기한 버섯"); // 랜덤 성공+3, 실패 -3
                //v.itemAll.Add("바람의 목걸이"); // userDelay 증가
                //----------------------------------------------------------------------
                //v.itemAll.Add("노예 상인의 목걸이"); // Elite, Boss 공격력+5,방어구+2(되면)
                //----------------------------------------------------------------------
                {
                    case "성공 포션":
                        Console.WriteLine("[아이템 효과]");
                        Console.WriteLine("[성공확률 +1]");
                        v.userProb.Insert(1, v.success);
                        int userSuccessCount = v.userProb.Count(x => x == v.success);
                        Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);
                        break;
                    case "체력 포션":
                        Console.WriteLine("[아이템 효과]");
                        Console.WriteLine("[체력 +20]");
                        if (v.userMaxHP < v.userCurrentHP + 20)
                        {
                            v.userCurrentHP = v.userMaxHP;
                            Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                        }
                        else
                        {
                            v.userCurrentHP = +20;
                            Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                        }

                        break;
                    case "철갑 방어구":
                        Console.WriteLine("[아이템 효과]");

                        Console.WriteLine("[방어력 +1]");
                        v.userArmor += 1;
                        Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);


                        break;
                    case "미스릴 방어구":
                        Console.WriteLine("[아이템 효과]");
                        Console.WriteLine("[방어력 +3]");
                        v.userArmor += 3;
                        Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);

                        break;
                    case "아이언 메이스":
                        Console.WriteLine("[아이템 효과]");
                        Console.WriteLine("[공격력 +10]");
                        v.userDamage += 10;
                        Console.WriteLine("[현재 공격력  : {0}]", v.userDamage);
                        break;
                    case "마검":
                        Console.WriteLine("[아이템 효과]");

                        Console.WriteLine("[공격력 +20]");
                        v.userDamage += 20;
                        Console.WriteLine("[현재 공격력  : {0}]", v.userDamage);

                        break;
                    case "고기":
                        Console.WriteLine("[아이템 효과]");
                        Console.WriteLine("[체력이 50% 이하 -> 체력 +50]");
                        if (v.userMaxHP >= v.userCurrentHP * 0.5)
                        {
                            v.userCurrentHP += 50;
                            Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                        }
                        else
                        {
                            Console.WriteLine("[체력이 50%이상임으로 적용되지 않습니다.]");
                        }

                        break;
                    case "배":
                        Console.WriteLine("[아이템 효과]");

                        Console.WriteLine("[최대 체력 +10]");
                        v.userMaxHP += 10;
                        Console.WriteLine("[최대 체력  : {0}]", v.userMaxHP);
                        Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);

                        break;
                    case "꾸깃한 복권":
                        Console.WriteLine("[아이템 효과]");
                        Console.WriteLine("[골드 + 10]");

                        v.userGold += 10;
                        Console.WriteLine("[유저 골드  : {0}]", v.userGold);

                        break;
                    case "신기한 버섯":
                        Console.WriteLine("[아이템 효과]");

                        Console.WriteLine("[50% 확률로 랜덤 성공+3 or 실패 -3]");
                        Random random = new Random();
                        int mushroomRandom = random.Next(0, 1);
                        if (mushroomRandom == 0)
                        {
                            Console.WriteLine("3개의 실패확률+.");
                            v.userProb.Add(v.fail);
                            v.userProb.Add(v.fail);
                            v.userProb.Add(v.fail);
                        }
                        else
                        {
                            v.userProb.Insert(1, v.success);
                            v.userProb.Insert(1, v.success);
                            v.userProb.Insert(1, v.success);
                            Console.WriteLine("[성공확률 + 3]");
                            userSuccessCount = v.userProb.Count(x => x == v.success);
                            Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);

                        }

                        break;
                    case "노예 상인의 목걸이":
                        Console.WriteLine("[아이템 효과]");

                        Console.WriteLine("[Elite, Boss 공격력+5,방어구+2]");
                        Console.WriteLine("아직 미구현임!");

                        break;
                    case "바람의 목걸이":
                        Console.WriteLine("[아이템 효과]");
                        Console.WriteLine("[userDelay  100 증가]");
                        v.userDelay += 100;
                        Console.WriteLine("[바 이동 속도 : {0}]",v.userDelay);

                        break;
                }


            }
        }
       
    }
}
