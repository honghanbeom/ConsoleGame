using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class GamePrint
    {
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();




        public void PressKey()
        {
            Console.WriteLine("게임 시작");
            Console.WriteLine("Press Any Key To Start");
            _getch();
        }

        public void GameClear()
        { 
            Console.WriteLine("축하합니다! 승리하셨습니다.");
        }

        public void GameOver()
        {
            Console.WriteLine("패배하셨습니다.");
        }



    }
}
