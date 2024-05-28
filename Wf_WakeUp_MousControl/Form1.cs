using System.Diagnostics;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;

namespace Wf_WakeUp_MousControl
{
    public partial class Form1 : Form
    {
        private Thread autoKeyPressThread;
        private bool autoKeyPressEnabled = false;

        //타이머용 변수
        float time_start = 0;
        float time_current = 0;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out POINT lpPoint);
        [StructLayout(LayoutKind.Sequential)]


        public struct POINT
        {
            public int X;
            public int Y;
        }
        private Timer mouseMoveTimer;
        private Timer UIUpdateTimer;
        byte a = 0;
        Int32 interval = 225;//기본값

        public Form1()
        {
            MoveMouse(11, 11);

            InitializeComponent();
            MoveMouseCheckBox.Checked = true;
            //UI 업데이트 타이머 시작
            UIUpdateTimer = new Timer();
            UIUpdateTimer.Interval = 66; // 15Fps  30FPS로 업데이트 하기위해 = 실제로는 33.33 해야함
            UIUpdateTimer.Tick += UIUpdate;
            UIUpdateTimer.Start();

            MoveMouse(-11, -11);
        }
        private void InitializeTimer(bool a)
        {
            switch (a)
            {
                case true:
                    mouseMoveTimer = new Timer();                    
                    mouseMoveTimer.Interval = interval * 1000 + 1; //--0초 간격으로 실행
                    mouseMoveTimer.Tick += MouseMoveTimer_Tick;
                    mouseMoveTimer.Start();
                    break;
                case false:
                    mouseMoveTimer.Stop();
                    break;
            }
        }
        private void UIUpdate(object sender, EventArgs e)
        {
            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke(new Action(() =>
            //    {
            //        //UI관련 코드
            //        double Timeleftperc = 100 * (interval - time_current) / interval;
            //        if (Timeleftperc >= 0 && Timeleftperc <= 100) TimerProgressBar.Value = (int)Timeleftperc;
            //        else TimerProgressBar.Value = 0;
            //        TXTBA1B1.Text = "P:" + a + " interval:" + interval + " Timeleft:" + time_current;
            //    }));

            //}
            if(MoveMouseCheckBox.Checked) time_current = time_start - (float)System.DateTime.Now.TimeOfDay.TotalSeconds; //시간재기
            if (time_current < -0.1 || time_current > interval)//타이머 재서 current초에 1번씩|| 24시가 넘어가서 시간 꼬일때 다시 실행
            {       
                time_start = (float)System.DateTime.Now.TimeOfDay.TotalSeconds + interval;//명령 다 하면 interval만큼 타이밍 밀기
            }       

                double Timeleftperc = 100 * (interval - time_current) / interval;
            if (Timeleftperc >= 0 && Timeleftperc <= 100) TimerProgressBar.Value = (int)Timeleftperc;
            else TimerProgressBar.Value = 0;
            TXTBA1B1.Text = "P:" + a + " TimeStart:" + time_start+ " interval:" + interval + " Timeleft:" + time_current;           

        }

        private void MouseMoveTimer_Tick(object sender, EventArgs e)
        {
            if (MoveMouseCheckBox.Checked == true)
            {
                a++;
                switch (a)
                {
                    case 0:
                        MoveMouse(2, 0); // 2픽셀 이동
                        break;
                    case 1:
                        MoveMouse(-2, 0); // 2픽셀 이동
                        break;
                    case 2:
                        MoveMouse(0, 2); // 2픽셀 이동
                        break;
                    case 3:
                        MoveMouse(0, 2); // 2픽셀 이동
                        break;
                    case 4:
                        MoveMouse(2, 0); // 2픽셀 이동
                        break;
                    case 5:
                        MoveMouse(1, 1);
                        break;
                    case 6:
                        MoveMouse(-1, -1);
                        break;
                    case 7:
                        MoveMouse(1, -1);
                        break;
                    case 8:
                        MoveMouse(-1, 1);
                        break;
                    default:
                        a = 0;
                        MoveMouse(2, 2);
                        break;
                }
                interval = Convert.ToInt32(IntervalTXT.Text);
                if (interval <= 5)
                {
                    IntervalTXT.Text = "5";
                    interval = 5;
                }
                mouseMoveTimer.Interval = interval * 1000; //--0초 간격으로 실행
            }
            //나중에 마우스 위치가 먼저 바뀌엇으면 체크하고 않움직이는 모드도 추가, 대신 작동 인터벌은 짧게
            Console.WriteLine("Timer" + a);

        }

        private void MoveMouse(int deltaX, int deltaY)
        {
            try
            {
                // 현재 마우스 위치를 가져옴
                POINT cursorPosition;
                GetCursorPos(out cursorPosition);

                // 새로운 위치 계산
                Point newPosition = new Point(cursorPosition.X + deltaX, cursorPosition.Y + deltaY);
                Console.WriteLine(System.DateTime.Now.TimeOfDay.TotalSeconds + "," + cursorPosition.X + "," + deltaX + "," + cursorPosition.Y + "," + deltaY);
                // 마우스 위치 설정
                SetCursorPos((int)newPosition.X, (int)newPosition.Y);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error moving mouse: {ex.Message}");
            }
        }


        private void MoveMouseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (MoveMouseCheckBox.Checked)
            {
                case true:
                    if (IntervalTXT != null)
                    {
                        interval = Convert.ToInt32(IntervalTXT.Text);
                    }
                    else IntervalTXT.Text = "120";

                    Console.WriteLine("Set interval: " + interval);
                    InitializeTimer(true);                    // 체크박스가 체크되면 타이머 시작

                    automove_Start(true); //Auto moust thread start

                    time_start = (float)System.DateTime.Now.TimeOfDay.TotalSeconds + interval;
                    break;
                case false:
                    InitializeTimer(false);                    // 체크박스가 풀리되면 타머 정지

                    automove_Start(false); //Auto moust thread stop
                    time_start = (float)System.DateTime.Now.TimeOfDay.TotalSeconds + interval;
                    break;
            }
        }
        private void automove_Start(bool start)
        {
            switch (start)
            {
                case true:
                    autoKeyPressEnabled = true;
                    autoKeyPressThread = new Thread(AutoKeyPressThreadMethod);
                    autoKeyPressThread.IsBackground = true;
                    autoKeyPressThread.Start();
                    break;
                case false:
                    autoKeyPressEnabled = false;
                    break;
            }

        }
        private void AutoKeyPressThreadMethod()
        {
            while (autoKeyPressEnabled)
            {
                time_current = time_start - (float)System.DateTime.Now.TimeOfDay.TotalSeconds; //시간재기
                if (time_current < 0 || time_current > interval)//타이머 재서 current초에 1번씩|| 24시가 넘어가서 시간 꼬일때 다시 실행
                {
                    a++;
                    switch (a)
                    {
                        case 0:
                            MoveMouse(1, 0); // 1픽셀 이동
                            break;
                        case 1:
                            MoveMouse(-1, 0); // 1픽셀 이동
                            break;
                        case 2:
                            MoveMouse(0, 1); // 1픽셀 이동
                            break;
                        case 3:
                            MoveMouse(0, 1); // 1픽셀 이동
                            break;
                        case 4:
                            MoveMouse(1, 0); // 1픽셀 이동
                            break;
                        case 5:
                            MoveMouse(1, 1);
                            break;
                        case 6:
                            MoveMouse(-1, -1);
                            break;
                        case 7:
                            MoveMouse(1, -1);
                            break;
                        case 8:
                            MoveMouse(-1, 1);
                            break;
                        default:
                            a = 0;
                            MoveMouse(-2, -2);
                            break;
                    }
                    if(BoostcheckBox.Checked)
                    {
                        if (interval<5)interval = 5;
                        switch (a)
                        {
                            case 0:
                                MoveMouse(11, 0); // 1픽셀 이동
                                break;
                            case 1:
                                MoveMouse(-11, 0); // 1픽셀 이동
                                break;
                            case 2:
                                MoveMouse(0, 11); // 1픽셀 이동
                                break;
                            case 3:
                                MoveMouse(0, -11); // 1픽셀 이동
                                break;
                            case 4:
                                MoveMouse(12, 12); // 1픽셀 이동
                                break;
                            case 5:
                                MoveMouse(11, 11);
                                break;
                            case 6:
                                MoveMouse(-11, -11);
                                break;
                            case 7:
                                MoveMouse(11, -11);
                                break;
                            case 8:
                                MoveMouse(-11, 11);
                                break;
                            default:
                                a = 0;
                                MoveMouse(-12, -12);
                                break;
                        }
                    }
                    time_start = (float)System.DateTime.Now.TimeOfDay.TotalSeconds + interval;//명령 다 하면 interval만큼 타이밍 밀기
                    Console.WriteLine("thread-" + a);
                    Debug.WriteLine("thread-" + a);
                }
                Thread.Sleep(1000);//1sec sleeep

            }
        }

        void App_Exit()
        {
            autoKeyPressEnabled = false;
            autoKeyPressThread.Abort();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
            Environment.Exit(0);//강제종료
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
