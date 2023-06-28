using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Shop
    {
        Item i = new Item();
        Variable v = new Variable();

        public void Get(Variable var_, Item i_)
        { 
            this.v = var_;
            this.i = i_;
        }

        public void AddRandomItemsToShop()
        {
            // 중복을 제외한 아이템 선택을 위한 HashSet
            v.shopListAll = new List<string>(v.itemAll.Keys);

            // itemAll 리스트에서 중복되지 않는 4개의 아이템 선택
            Random random = new Random();
            int randomInput = random.Next(0, v.shopListAll.Count);
            int shopCount = 0;
            while (shopCount < 4)
            {
                string item = v.shopListAll[randomInput];

                // 중복된 아이템이 없는 경우에만 추가
                if (!v.shopList.Contains(item))
                {
                    v.shopList.Add(item);
                    shopCount++;
                }
            }
        }


        public void PrintShop()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write("[{0}][{1}]", i + 1, v.shopList[i]);
            }
        }

        public void FindValues(string name)
        {
            foreach (string str in v.itemAll.Keys)
            {
                if (v.shopList.Contains(name))
                { 
                        Console.WriteLine("[아이템 가격 : {0}]", v.itemAll.Values);
                }
            }
        }

        public void ExplainItem()
        {
            Console.WriteLine("[아이템 설명]");
            for (int j = 0; j < v.shopList.Count; j++)
            {
                switch (v.shopList[j])
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
                //v.itemAll.Add("노예 상인의 목걸이"); // Elite, Boss 공격력+5,방어구+2(되면)
                //v.itemAll.Add("수리 단검"); // 공격시 2번 공격(되면)
                {
                    case "성공 포션":
                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.WriteLine("[성공 +1]");
                        FindValues(v.shopList[j]);
                        break;
                    case "체력 포션":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[체력 +20]");
                        FindValues(v.shopList[j]);



                        break;
                    case "철갑 방어구":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[방어력 +1]");
                        FindValues(v.shopList[j]);


                        break;
                    case "미스릴 방어구":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[방어력 +3]");
                        FindValues(v.shopList[j]);


                        break;
                    case "아이언 메이스":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[공격력 +10]");
                        FindValues(v.shopList[j]);


                        break;
                    case "마검":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[공격력 +20]");
                        FindValues(v.shopList[j]);


                        break;
                    case "고기":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[체력이 50% 이하 -> 체력 +50]");
                        FindValues(v.shopList[j]);


                        break;
                    case "배":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[최대체력 +10]");
                        FindValues(v.shopList[j]);


                        break;
                    case "꾸깃한 복권":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[돈 +10]");
                        FindValues(v.shopList[j]);


                        break;
                    case "신기한 버섯":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[50% 확률로 랜덤 성공+3 or 실패 -3]");
                        FindValues(v.shopList[j]);


                        break;
                    case "노예 상인의 목걸이":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[Elite, Boss 공격력+5,방어구+2]");
                        FindValues(v.shopList[j]);


                        break;
                    case "수리 단검":
                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.WriteLine("[공격시 2번 공격]");
                        FindValues(v.shopList[j]);


                        break;
                }
            }


        }

        public void BuyFromShop()
        {
            Console.WriteLine("구매하실 아이템 번호를 입력해주세요");
            Console.WriteLine("[나가기 : N]");
            ConsoleKeyInfo shopSel = Console.ReadKey(true); 
            switch (shopSel.Key)
            {
                case ConsoleKey.D1:
                    if (v.userGold >= v.itemAll[v.shopList[0]])
                    {
                        v.itemInven.Add(v.shopList[0]);
                        Console.WriteLine("[{0}를 구매했습니다.]", v.shopList[0]);
                        v.userGold -= i.itemPrice;
                        Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                        v.itemInven.Remove(v.shopList[0]);
                        
                    }
                    else
                    { 
                        Console.WriteLine("소지금이 부족합니다!");
                    }

          
                    break;
                case ConsoleKey.D2:
                    if (v.userGold >= v.itemAll[v.shopList[1]])
                    {
                        v.itemInven.Add(v.shopList[1]);
                        Console.WriteLine("[{0}를 구매했습니다.]", v.shopList[1]);
                        v.userGold -= i.itemPrice;
                        Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                        v.itemInven.Remove(v.shopList[1]);

                    }
                    else
                    {
                        Console.WriteLine("소지금이 부족합니다!");
                    }

                    break;
                case ConsoleKey.D3:
                    if (v.userGold >= v.itemAll[v.shopList[2]])
                    {
                        v.itemInven.Add(v.shopList[2]);
                        Console.WriteLine("[{0}를 구매했습니다.]", v.shopList[2]);
                        v.userGold -= i.itemPrice;
                        Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                        v.itemInven.Remove(v.shopList[2]);

                    }
                    else
                    {
                        Console.WriteLine("소지금이 부족합니다!");
                    }

                    break;
                case ConsoleKey.D4:
                    if (v.userGold >= v.itemAll[v.shopList[3]])
                    {
                        v.itemInven.Add(v.shopList[3]);
                        Console.WriteLine("[{0}를 구매했습니다.]", v.shopList[3]);
                        v.userGold -= i.itemPrice;
                        Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                        v.itemInven.Remove(v.shopList[3]);
                    }
                    else
                    {
                        Console.WriteLine("소지금이 부족합니다!");
                    }

                    break;
                case ConsoleKey.N:
                    break;

            }
        }



    }
}
