using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Threading;


namespace Project1
{
    public class AttackSystem
    {
        // 색깔 시스템

        Variable v = new Variable();
        MonsterCreate mc = new MonsterCreate();
        public Thread thread1;
        public Thread thread2;

        // 원 리스트 v.userProb
        // 복사 리스트 v.userCopy


        public void Get(Variable var_, MonsterCreate monster_)
        {
            this.v = var_;
            this.mc = monster_;
        }


        public void AttackControl()
        {
            Copy();
            RandomUserDamage();
            Spacebar();
            UserView();
            ResultDelete();
        }


        // 유저의 확률(userProb)를 userCopy로 복사
        public void Copy()
        {
            foreach (string n in v.userProb)
            {
                v.userCopy.Add(n);
            }
        }


        // Copy 함수의 끝을 랜덤으로 짤라서 앞으로 이동
        public void RandomUserDamage()
        {

            Random random = new Random();
            // fail의 갯수 = countFail
            int countFail = v.userCopy.Where(x => x.Equals(v.fail)).Count();
            // 1 ~ fail의 갯수 중 랜덤 숫자 하나 생성(최소 한개)
            int failmove = random.Next(1, countFail);

            // bar가 존재하기 때문에 index는 (+ 1) -> 이게 없음
            v.userCopy.RemoveRange(v.userCopy.Count - failmove, failmove);

            // bar가 0의 위치에 있다는 것을 생각하고, 제거한 것 만큼 추가
            for (int i = 0; i <= failmove; i++)

            {
                v.userCopy.Insert(i + 1, v.fail);
            }

        }


        // UserInput과 Select의 함수를 thread로 실행시킴
        public void Spacebar()
        {
            thread1 = new Thread(Select);
            thread2 = new Thread(UserInput);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();


        }

        // Spacebar 입력시 thread2 종료
        public void UserInput()
        {
            while (!v.spaceBar)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    v.spaceBar = true;
                    // 강제종료
                    thread2.Abort();
                    break;
                }
            }
        }

        // bar의 위치를 한칸씩 앞으로 이동시킴 -> spacebar 누른 list를 userShow 넣기
        public void Select()
        {
            while (!v.spaceBar)
            {
                v.index = v.userCopy.IndexOf(v.userSelect);

                // bar가 0에 있는 경우
                if (v.index == 0)
                {
                    for (int i = 0; i < v.userCopy.Count - 1; i++)
                    {
                        if (v.spaceBar)
                        {
                            //foreach(string n in v.userCopy)
                            //{
                            //    v.userShow.Add(n);
                            //}

                            thread1.Abort();
                            return;
                        }

                        if (i + 1 < v.userCopy.Count)
                        {
                            Swap(i, i + 1);
                            foreach (string n in v.userCopy)
                            {
                                Console.Write("{0}", n);
                            }
                            Console.WriteLine();
                            Thread.Sleep(v.userDelay);
                            v.index++;
                        }
                    }
                }

                // bar가 끝에 있는 경우
                if (v.index == v.userCopy.Count - 1)
                {
                    for (int i = v.userCopy.Count - 1; i >= 1; i--)
                    {
                        if (v.spaceBar)
                        {
                            //foreach (string n in v.userCopy)
                            //{
                            //    v.userShow.Add(n);
                            //}

                            thread1.Abort();
                            return;
                        }

                        if (i - 1 >= 0)
                        {
                            Swap(i, i - 1);
                            foreach (string n in v.userCopy)
                            {
                                Console.Write("{0}", n);
                            }
                            Console.WriteLine();
                            Thread.Sleep(v.userDelay);
                            v.index--;
                        }
                    }
                }
            }
        }


        // bar의 인덱스 이동을 위해 스왑
        public void Swap(int listOne, int listTwo)
        {
            string temp = v.userCopy[listOne];
            v.userCopy[listOne] = v.userCopy[listTwo];
            v.userCopy[listTwo] = temp;
        }


        // UserCopy의 마지막을 판단
        public void UserView()
        {
            //int userSelectIndex = userDamage.IndexOf(userSelect);
            //int failIndex = userDamage.IndexOf(fail);
            //int successIndex = userDamage.IndexOf(success);

            // bar의 위치가 있는 함수를 출력
            foreach (string n in v.userCopy)
            {
                Console.Write(n);
            }

            //bar 위치를 찾기 bar의 한칸 앞, 뒤 도 판단
            int userSelectIndex = v.userCopy.IndexOf(v.userSelect);
            int upFailIndex = v.userCopy.FindIndex(userSelectIndex + 1, x => x == v.fail);
            int upSuccessIndex = v.userCopy.FindIndex(userSelectIndex + 1, x => x == v.success);
            int downFailIndex = v.userCopy.FindIndex(userSelectIndex - 1, x => x == v.fail);
            int downSuccessIndex = v.userCopy.FindIndex(userSelectIndex - 1, x => x == v.success);

            //실패
            if (userSelectIndex + 1 == upFailIndex && userSelectIndex - 1 == downFailIndex)
            {
                Console.WriteLine("공격 실패");
            }

            // 성공
            else if (userSelectIndex + 1 == upSuccessIndex && userSelectIndex - 1 == downSuccessIndex)
            {
                mc.PlayerDamage();
            }
            else
            {
                Random random = new Random();
                int randomAttackIndex = random.Next(0, 1);
                switch (randomAttackIndex)
                {
                    case 0:
                        Console.WriteLine("공격 실패");
                        break;
                    case 1:
                        mc.PlayerDamage();
                        break;
                }
            }

        }

        // 초기에 존재하는 userShow와 userCopy 삭제
        public void ResultDelete()
        {
            v.userCopy.Clear();
        }
    }
}




//public void Select()
//{
//    while (!v.spaceBar)
//    {
//        // bar가 0 에 있는 경우
//        v.index = v.userCopy.IndexOf(v.userSelect);
//        if (v.index == 0)
//        {
//            //foreach (string n in userDamage)
//            //{
//            //    Console.Write("{0}", n);
//            //}
//            //Console.WriteLine();
//            //Thread.Sleep(1000);


//            for (int i = 0; i < v.userCopy.Count - 1; i++)
//            {
//                if (v.spaceBar)  // spaceBar가 true인 경우 종료
//                {
//                    //thread1 강제종료
//                    thread1.Abort();
//                    return;
//                }
//                Swap(i, i + 1);
//                foreach (string n in v.userCopy)
//                {
//                    Console.Write("{0}", n);
//                }
//                Console.WriteLine();
//                Thread.Sleep(v.userDelay);
//                //Console.Clear();
//                v.index++;
//            }
//        }
//        // bar가 끝에 있는 경우
//        if (v.index == v.userCopy.Count - 1)
//        {
//            for (int i = v.userCopy.Count - 1; i >= 1; i--)
//            {
//                if (v.spaceBar)  // spaceBar가 true인 경우 종료
//                {
//                    //thread1 강제종료
//                    thread1.Abort();
//                    return;
//                }
//                Swap(i, i - 1);
//                foreach (string n in v.userCopy)
//                {
//                    Console.Write("{0}", n);
//                }
//                Console.WriteLine();
//                Thread.Sleep(v.userDelay);
//                //Console.Clear();
//                v.index--;
//            }
//        }
//    }
//}

#region LEGACY

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Project1
//{
//    public class AttackSystem
//    {
//        // 색깔 시스템

//        Variable v = new Variable();
//        MonsterCreate mc = new MonsterCreate();

//        public void Get(Variable var_, MonsterCreate monster_)
//        {
//            this.v = var_;
//            this.mc = monster_;
//        }

//        // userProb -> bar선택까지 기다리는 출력
//        // userShow -> 결과출력

//        public int mix = 0;

//        //public void AttackControl()
//        //{
//        //    if (mix == 0)
//        //    {
//        //        RandomUserDamage();
//        //    }
//        //    Spacebar();
//        //    ResultCopy();
//        //    UserView();
//        //    ResultDelete();
//        //    v.index = 0;
//        //}

//        public void ResultCopy()
//        {
//            v.userShow.AddRange(v.userProb);
//        }

//        public void ResultDelete()
//        {
//            v.userShow.Clear();
//        }

//        public void UserView()
//        {
//            foreach (var n in v.userShow)
//            {
//                Console.Write(n);
//            }
//            Console.WriteLine();

//            int userSelectIndex = v.userShow.IndexOf(v.userSelect);
//            int upFailIndex = v.userShow.FindIndex(userSelectIndex + 1, x => x == v.fail);
//            int upSuccessIndex = v.userShow.FindIndex(userSelectIndex + 1, x => x == v.success);
//            int downFailIndex = v.userShow.FindIndex(userSelectIndex - 1, x => x == v.fail);
//            int downSuccessIndex = v.userShow.FindIndex(userSelectIndex - 1, x => x == v.success);

//            // 실패
//            if (userSelectIndex + 1 == upFailIndex && userSelectIndex - 1 == downFailIndex)
//            {
//                Console.WriteLine("공격 실패");
//            }

//            // 성공
//            else if (userSelectIndex + 1 == upSuccessIndex && userSelectIndex - 1 == downSuccessIndex)
//            {
//                mc.PlayerDamage();
//            }
//            else
//            {
//                Random random = new Random();
//                int randomAttackIndex = random.Next(0, 1);
//                switch (randomAttackIndex)
//                {
//                    case 0:
//                        Console.WriteLine("공격 실패");
//                        break;
//                    case 1:
//                        mc.PlayerDamage();
//                        break;
//                }
//            }
//        }

//        public void RandomUserDamage()
//        {
//            Random random = new Random();
//            int countFail = v.userProb.Where(x => x.Equals(v.fail)).Count();
//            int failmove = random.Next(1, countFail);

//            v.userProb.RemoveRange(v.userProb.Count - failmove, failmove);

//            for (int i = 0; i <= failmove; i++)
//            {
//                v.userProb.Insert(i + 1, v.fail);
//            }
//            mix++;
//        }


//        public CancellationTokenSource cancellationTokenSource;

//        public void Spacebar()
//        {
//            if (cancellationTokenSource != null)
//            {
//                cancellationTokenSource.Cancel();
//                cancellationTokenSource.Dispose();
//            }

//            cancellationTokenSource = new CancellationTokenSource();

//            ThreadPool.QueueUserWorkItem(_ =>
//            {
//                Select(cancellationTokenSource.Token);
//            });

//            while (true)
//            {
//                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//                if (keyInfo.Key == ConsoleKey.Spacebar)
//                {
//                    cancellationTokenSource.Cancel();
//                    v.spaceBar = true;
//                    break;
//                }
//            }
//        }

//        public void Select(CancellationToken cancellationToken)
//        {
//            while (!cancellationToken.IsCancellationRequested)
//            {
//                while (!v.spaceBar)
//                {

//                    v.index = v.userProb.IndexOf(v.userSelect);
//                    if (v.index == 0)
//                    {
//                        //foreach (string n in userDamage)
//                        //{
//                        //    Console.Write("{0}", n);
//                        //}
//                        //Console.WriteLine();
//                        //Thread.Sleep(1000);


//                        for (int i = 0; i < v.userProb.Count - 1; i++)
//                        {
//                            //if (v.spaceBar)  // spaceBar가 true인 경우 종료
//                            //{
//                            //    // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//                            //    return;
//                            //}
//                            Swap(i, i + 1);
//                            foreach (string n in v.userProb)
//                            {
//                                Console.Write("{0}", n);
//                            }
//                            Console.WriteLine();
//                            Thread.Sleep(v.userDelay);
//                            //Console.Clear();
//                            v.index++;
//                        }
//                    }

//                    if (v.index == v.userProb.Count - 1)
//                    {
//                        for (int i = v.userProb.Count - 1; i >= 1; i--)
//                        {
//                            //if (v.spaceBar)  // spaceBar가 true인 경우 종료
//                            //{
//                            //    // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//                            //    return;
//                            //}
//                            Swap(i, i - 1);
//                            foreach (string n in v.userProb)
//                            {
//                                Console.Write("{0}", n);
//                            }
//                            Console.WriteLine();
//                            Thread.Sleep(v.userDelay);
//                            //Console.Clear();
//                            v.index--;
//                        }
//                    }
//                }
//            }
//        }



//        public void Swap(int listOne, int listTwo)
//        {
//            string temp = v.userProb[listOne];
//            v.userProb[listOne] = v.userProb[listTwo];
//            v.userProb[listTwo] = temp;
//        }

//    }

//}

//public void Select()
//{
//while (!v.spaceBar)
//{

//    v.index = v.userProb.IndexOf(v.userSelect);
//    if (v.index == 0)
//    {
//        //foreach (string n in userDamage)
//        //{
//        //    Console.Write("{0}", n);
//        //}
//        //Console.WriteLine();
//        //Thread.Sleep(1000);


//        for (int i = 0; i < v.userProb.Count - 1; i++)
//        {
//            //if (v.spaceBar)  // spaceBar가 true인 경우 종료
//            //{
//            //    // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//            //    return;
//            //}
//            Swap(i, i + 1);
//            foreach (string n in v.userProb)
//            {
//                Console.Write("{0}", n);
//            }
//            Console.WriteLine();
//            Thread.Sleep(v.userDelay);
//            //Console.Clear();
//            v.index++;
//        }
//    }

//    if (v.index == v.userProb.Count - 1)
//    {
//        for (int i = v.userProb.Count - 1; i >= 1; i--)
//        {
//            //if (v.spaceBar)  // spaceBar가 true인 경우 종료
//            //{
//            //    // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//            //    return;
//            //}
//            Swap(i, i - 1);
//            foreach (string n in v.userProb)
//            {
//                Console.Write("{0}", n);
//            }
//            Console.WriteLine();
//            Thread.Sleep(v.userDelay);
//            //Console.Clear();
//            v.index--;
//        }
//    }
//}
//}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Markup;
//using System.Threading;
//using Microsoft.Win32.SafeHandles;
//using System.Timers;

//namespace Project1
//{
//    public class AttackSystem
//    {
//        // 색깔 시스템

//        Variable v = new Variable();
//        MonsterCreate mc = new MonsterCreate();



//        public void Get(Variable var_, MonsterCreate monster_)
//        {
//            this.v = var_;
//            this.mc = monster_;
//        }

//        // userProb -> bar선택까지 기다리는 출력
//        // userShow -> 결과출력

//        public int mix = 0;


//        public void AttackControl()
//        {

//            if (mix == 0)
//            {
//                RandomUserDamage();
//            }
//            Spacebar();
//            ResultCopy();
//            UserView();
//            ResultDelete();
//            v.index = 0;
//            //스레드 정리
//            //thread1.DisableComObjectEagerCleanup();
//            //thread2.DisableComObjectEagerCleanup();     
//        }

//        public void ResultCopy()
//        {
//            v.userShow.AddRange(v.userProb);
//        }

//        public void ResultDelete()
//        {
//            v.userShow.Clear();
//        }

//        // class 안에서 함수 만들고 객체생성후 함수 호출 객체를 초기화
//        public void UserView()
//        {
//            //int userSelectIndex = userDamage.IndexOf(userSelect);
//            //int failIndex = userDamage.IndexOf(fail);
//            //int successIndex = userDamage.IndexOf(success);


//            foreach (var n in v.userShow)
//            {
//                Console.Write(n);
//            }
//            Console.WriteLine();


//            int userSelectIndex = v.userShow.IndexOf(v.userSelect);
//            int upFailIndex = v.userShow.FindIndex(userSelectIndex + 1, x => x == v.fail);
//            int upSuccessIndex = v.userShow.FindIndex(userSelectIndex + 1, x => x == v.success);
//            int downFailIndex = v.userShow.FindIndex(userSelectIndex - 1, x => x == v.fail);
//            int downSuccessIndex = v.userShow.FindIndex(userSelectIndex - 1, x => x == v.success);

//            // 실패
//            if (userSelectIndex + 1 == upFailIndex && userSelectIndex - 1 == downFailIndex)
//            {
//                Console.WriteLine("공격 실패");
//            }

//            // 성공
//            else if (userSelectIndex + 1 == upSuccessIndex && userSelectIndex - 1 == downSuccessIndex)
//            {
//                mc.PlayerDamage();
//            }
//            else
//            {
//                Random random = new Random();
//                int randomAttackIndex = random.Next(0, 1);
//                switch (randomAttackIndex)
//                {
//                    case 0:
//                        Console.WriteLine("공격 실패");
//                        break;
//                    case 1:
//                        mc.PlayerDamage();
//                        break;
//                }
//            }

//        }


//        public void RandomUserDamage()
//        {
//            Random random = new Random();
//            // fail의 갯수 = countFail
//            int countFail = v.userProb.Where(x => x.Equals(v.fail)).Count();
//            // 1 ~ fail의 갯수 중 랜덤 숫자 하나 생성(최소 한개)
//            int failmove = random.Next(1, countFail);

//            // bar가 존재하기 때문에 index는 (+ 1) -> 이게 없음
//            v.userProb.RemoveRange(v.userProb.Count - failmove, failmove);

//            // bar가 0의 위치에 있다는 것을 생각하고, 제거한 것 만큼 추가
//            for (int i = 0; i <= failmove; i++)

//            {
//                v.userProb.Insert(i + 1, v.fail);
//            }
//            mix++;

//        }


//        public class MySelect();
//        {
//            private ManualResetEvent selectCompleted = new ManualResetEvent(false);
//            private bool spaceBar = false; // 스페이스바를 종료 조건으로 사용하는 변수

//            public void Spacebar()
//            {
//                ThreadPool.QueueUserWorkItem(_ =>
//                {
//                    Select(); // Select 메서드를 ThreadPool에서 실행
//                });

//                // Spacebar를 누를 때까지 대기합니다.
//                while (true)
//                {
//                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//                    if (keyInfo.Key == ConsoleKey.Spacebar)
//                    {
//                        spaceBar = true; // 스페이스바가 눌렸음을 표시
//                        selectCompleted.Set(); // selectCompleted 이벤트를 설정하여 Select 메서드 종료를 알림
//                        break;
//                    }
//                }

//                // 이후에 필요한 작업을 수행합니다.
//            }
//            //public void Spacebar()
//            //{


//            //    ThreadPool.QueueUserWorkItem(_ =>
//            //    {
//            //        Select(); // Select 메서드를 ThreadPool에서 실행
//            //    });



//            //    // Spacebar를 누를 때까지 대기합니다.
//            //    while (true)
//            //    {
//            //        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//            //        if (keyInfo.Key == ConsoleKey.Spacebar)
//            //        {

//            //            selectCompleted.Set();
//            //            break;
//            //        }
//            //    }

//            //    // 이후에 필요한 작업을 수행합니다.
//            //}

//            //public void UserInput(ManualResetEvent userInputCompleted)
//            //{
//            //    while (!userInputCompleted.WaitOne(0))
//            //    {
//            //        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//            //        if (keyInfo.Key == ConsoleKey.Spacebar)
//            //        {
//            //            // spacebar를 누르면 UserInput 종료
//            //            break;
//            //        }
//            //    }
//            //    userInputCompleted.Set(); // UserInput이 종료되었음을 신호로 보냅니다.
//            //}

//            public void Select()
//        {
//while (!v.spaceBar)
//{

//    v.index = v.userProb.IndexOf(v.userSelect);
//    if (v.index == 0)
//    {
//        //foreach (string n in userDamage)
//        //{
//        //    Console.Write("{0}", n);
//        //}
//        //Console.WriteLine();
//        //Thread.Sleep(1000);


//        for (int i = 0; i < v.userProb.Count - 1; i++)
//        {
//            if (v.spaceBar)  // spaceBar가 true인 경우 종료
//            {
//                // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//                return;
//            }
//            Swap(i, i + 1);
//            foreach (string n in v.userProb)
//            {
//                Console.Write("{0}", n);
//            }
//            Console.WriteLine();
//            Thread.Sleep(v.userDelay);
//            //Console.Clear();
//            v.index++;
//        }
//    }

//    if (v.index == v.userProb.Count - 1)
//    {
//        for (int i = v.userProb.Count - 1; i >= 1; i--)
//        {
//            if (v.spaceBar)  // spaceBar가 true인 경우 종료
//            {
//                // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//                return;
//            }
//            Swap(i, i - 1);
//            foreach (string n in v.userProb)
//            {
//                Console.Write("{0}", n);
//            }
//            Console.WriteLine();
//            Thread.Sleep(v.userDelay);
//            //Console.Clear();
//            v.index--;
//        }
//    }
//}
//        }

//        public void Swap(int listOne, int listTwo)
//{
//    string temp = v.userProb[listOne];
//    v.userProb[listOne] = v.userProb[listTwo];
//    v.userProb[listTwo] = temp;
//}
















//        //public void Spacebar()
//        //{
//        //    ManualResetEvent userInputCompleted = new ManualResetEvent(false); // UserInput이 완료되었음을 나타내는 이벤트
//        //    if (!userInputCompleted.WaitOne(0))
//        //    {
//        //        // UserInput이 진행 중이면 ThreadPool을 종료합니다.
//        //        ThreadPool.SetMaxThreads(0, 0);
//        //        userInputCompleted.WaitOne(); // UserInput이 완료될 때까지 대기합니다.
//        //    }

//        //    // ThreadPool을 재설정하여 새로운 작업을 수행합니다.
//        //    ThreadPool.SetMaxThreads(10, 10);
//        //    userInputCompleted.Reset();

//        //    ThreadPool.QueueUserWorkItem(_ =>
//        //    {
//        //        UserInput(); // ThreadPool에서 UserInput 메서드 시작

//        //        // UserInput이 완료되면 spaceBar 플래그를 true로 설정하고 이벤트를 신호로 보냅니다.
//        //        v.spaceBar = true;
//        //        userInputCompleted.Set();
//        //    });
//        //}

//        //public void UserInput()
//        //{
//        //    while (true)
//        //    {
//        //        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//        //        if (keyInfo.Key == ConsoleKey.Spacebar)
//        //        {

//        //            v.spaceBar = true;

//        //            // 0.1초 뒤에 thread2를 죽이는 코드 삽입한다.
//        //            break;
//        //        }
//        //    }
//        //}

//        //public void Select()
//        //{
//        //    while (!v.spaceBar)
//        //    {

//        //        v.index = v.userProb.IndexOf(v.userSelect);
//        //        if (v.index == 0)
//        //        {
//        //            //foreach (string n in userDamage)
//        //            //{
//        //            //    Console.Write("{0}", n);
//        //            //}
//        //            //Console.WriteLine();
//        //            //Thread.Sleep(1000);


//        //            for (int i = 0; i < v.userProb.Count - 1; i++)
//        //            {
//        //                if (v.spaceBar)  // spaceBar가 true인 경우 종료
//        //                {
//        //                    // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//        //                    return;
//        //                }
//        //                Swap(i, i + 1);
//        //                foreach (string n in v.userProb)
//        //                {
//        //                    Console.Write("{0}", n);
//        //                }
//        //                Console.WriteLine();
//        //                Thread.Sleep(v.userDelay);
//        //                //Console.Clear();
//        //                v.index++;
//        //            }
//        //        }

//        //        if (v.index == v.userProb.Count - 1)
//        //        {
//        //            for (int i = v.userProb.Count - 1; i >= 1; i--)
//        //            {
//        //                if (v.spaceBar)  // spaceBar가 true인 경우 종료
//        //                {
//        //                    // 0.1초 뒤에 thread1를 죽이는 코드 삽입한다.

//        //                    return;
//        //                }
//        //                Swap(i, i - 1);
//        //                foreach (string n in v.userProb)
//        //                {
//        //                    Console.Write("{0}", n);
//        //                }
//        //                Console.WriteLine();
//        //                Thread.Sleep(v.userDelay);
//        //                //Console.Clear();
//        //                v.index--;
//        //            }
//        //        }
//        //    }
//        //}


//        //public void Swap(int listOne, int listTwo)
//        //{
//        //    string temp = v.userProb[listOne];
//        //    v.userProb[listOne] = v.userProb[listTwo];
//        //    v.userProb[listTwo] = temp;
//        //}
//    }

//    //public void Spacebar()
//    //{
//    //    Thread thread2 = new Thread(Select);
//    //    Thread thread1 = new Thread(UserInput);

//    //    thread1.Start();
//    //    thread2.Start();

//    //    thread1.Join();
//    //    thread2.Join();

//    //}


//    //public void Dispose()
//    //{
//    //    // 타이머를 사용해서 1초 뒤에 thread 삭제하는 매써드
//    //    // 객체 생성
//    //    int mytime = 1000;
//    //    System.Timers.Timer timer = new System.Timers.Timer();
//    //    timer.Interval = mytime;
//    //    if ()
//    //    { 
//    //        thread1.
//    //    }
//    //}






//}
#endregion
