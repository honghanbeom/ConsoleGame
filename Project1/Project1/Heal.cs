using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Heal
    {

        #region 인스턴스화
        Variable v = new Variable();
        GamePrint g = new GamePrint();
        #endregion

        #region P/Invoke 선언
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        #endregion

        #region 객체 초기화 메소드
        public void Get(Variable var_, GamePrint g_)
        {
            this.v = var_;
            this.g = g_;
        }
        #endregion

        #region 힐 메소드
        public void HealHP()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            g.GameMapPrint();
            g.GameInfoPrint();
            Console.ResetColor();

            Console.SetCursorPosition(27, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[체력 회복]");
            Console.ResetColor();

            g.HealPrint();

            Console.SetCursorPosition(17, 4);
            Console.Write("유저의 체력 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("40%");
            Console.ResetColor();
            Console.Write("을 회복합니다.");

            // 회복 로직
            if (v.userMaxHP < v.userCurrentHP * 1.4)
            {
                v.userCurrentHP = v.userMaxHP;

                Console.SetCursorPosition(23, 5);
                Console.Write("[체력  : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", v.userCurrentHP);
                Console.ResetColor();
                Console.Write("]");
            }
            else
            {
                Console.SetCursorPosition(23, 5);
                v.userCurrentHP = (int)(v.userCurrentHP * 1.4);
                Console.Write("[체력  : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", v.userCurrentHP);
                Console.ResetColor();
                Console.Write("]");
            }

            Console.SetCursorPosition(20, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[Press Any Key To Continue]");
            Console.ResetColor();

            _getch();
        }
        #endregion
    }
}
