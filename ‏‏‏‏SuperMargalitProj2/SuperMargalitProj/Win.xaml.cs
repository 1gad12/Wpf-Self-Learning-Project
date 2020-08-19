using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SuperMargalitProj
{
    /// <summary>
    /// Interaction logic for Win.xaml
    /// </summary>
    public partial class Win : Window
    {
        private DispatcherTimer PhysicsTimer;           //Thread To Physics On Game
                                                       
        private DispatcherTimer JumpTimerM;             //Thread To Jump Margalit
        private DispatcherTimer JumpTimerT;             //Thread To Jump Toly

        private DispatcherTimer RightTimerM;            //Thread To Move Maralit Right
        private DispatcherTimer LeftTimerM;             //Thread To Move Margalit Left
        private DispatcherTimer RightTimerT;            //Thread To Move Toly Right
        private DispatcherTimer LeftTimerT;             //Thread To Move Toly Left
        double gravity = 0.2;                           //Gravity To Jump
        double jumpM = 9;                               //Jump Var For Margalit          
        double jumpT = 9;                               //Jump Var For Toly
        int animateM = 0;                               //Var For Animate Margalit 
        int animateA = 0;                               //Var For Animate  
       
        bool CanJumpM = true;                           //True If Margalit Can Jump
        bool CanJumpT = true;                           //True If Toly Can Jump

        bool Dir = false;                               //var To Move Enemy
        int wait = 0;                                   //Wait For Shoot
        bool shoot = false;                             //Bool For Know If Can Shoot
        double f = 0.1;                                 //Var To Sub Victory
        int StepI = 0;                                  //Var To Step Shoot Toly
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PhysicsTimer.Stop();                         //Close Thread Because Window Closed
            JumpTimerM.Stop();                           //Close Thread Because Window Closed
            JumpTimerT.Stop();                           //Close Thread Because Window Closed
            RightTimerM.Stop();                          //Close Thread Because Window Closed
            RightTimerT.Stop();                          //Close Thread Because Window Closed
            LeftTimerT.Stop();                           //Close Thread Because Window Closed
            LeftTimerM.Stop();                           //Close Thread Because Window Closed
            WE.Stop();                                   //Close Thread Because Window Closed
        }

        public Win()
        {
            InitializeComponent();
            PhysicsTimer = new System.Windows.Threading.DispatcherTimer();               //Set Timer(all 1ms)
            PhysicsTimer.Interval = TimeSpan.FromMilliseconds(1);                        //Set Timer(all 1ms)
            PhysicsTimer.Tick += PhysicsTimer_Tick;                                      //Set Timer(all 1ms)
                                                                                         //Set Timer(all 1ms)
            JumpTimerM = new System.Windows.Threading.DispatcherTimer();                 //Set Timer(all 1ms)
            JumpTimerM.Interval = TimeSpan.FromMilliseconds(1);                          //Set Timer(all 1ms)
            JumpTimerM.Tick += JumpTimerM_Tick;                                          //Set Timer(all 1ms)
                                                                                         //Set Timer(all 1ms)
            JumpTimerT = new System.Windows.Threading.DispatcherTimer();                 //Set Timer(all 1ms)
            JumpTimerT.Interval = TimeSpan.FromMilliseconds(1);                          //Set Timer(all 1ms)
            JumpTimerT.Tick += JumpTimerT_Tick;                                          //Set Timer(all 1ms)
                                                                                         //Set Timer(all 1ms)
            RightTimerM = new System.Windows.Threading.DispatcherTimer();                //Set Timer(all 1ms)
            RightTimerM.Interval = TimeSpan.FromMilliseconds(1);                         //Set Timer(all 1ms)
            RightTimerM.Tick += RightTimerM_Tick;                                        //Set Timer(all 1ms)
                                                                                         //Set Timer(all 1ms)
            LeftTimerM = new System.Windows.Threading.DispatcherTimer();                 //Set Timer(all 1ms)
            LeftTimerM.Interval = TimeSpan.FromMilliseconds(1);                          //Set Timer(all 1ms)
            LeftTimerM.Tick += LeftTimerM_Tick;                                          //Set Timer(all 1ms)
                                                                                         //Set Timer(all 1ms)
            RightTimerT = new System.Windows.Threading.DispatcherTimer();                //Set Timer(all 1ms)
            RightTimerT.Interval = TimeSpan.FromMilliseconds(1);                         //Set Timer(all 1ms)
            RightTimerT.Tick += RightTimerT_Tick;                                        //Set Timer(all 1ms)
                                                                                         //Set Timer(all 1ms)
            LeftTimerT = new System.Windows.Threading.DispatcherTimer();                 //Set Timer(all 1ms)
            LeftTimerT.Interval = TimeSpan.FromMilliseconds(1);                          //Set Timer(all 1ms)
            LeftTimerT.Tick += LeftTimerT_Tick;                                          //Set Timer(all 1ms)
            rnd = new Random();                                                          //Set Timer(all 1ms)
            rand = rnd.Next(10, 16);                                                     //Set Timer(all 1ms)

             this.Opacity = Class1.brightness / 1850;                                     //Brightness
             WE.Volume = Class1.Volume;                                                   //Volume Music
             WE.Play();                                                                   //Start Music
        }
        Random rnd;
        int rand;
        private void JumpTimerT_Tick(object sender, EventArgs e)
        {
            Jumping(Toly, 855, JumpTimerT, ref CanJumpT, ref jumpT, PressT, MoveLbl);     //Jump Function To Toly
        }

        private void JumpTimerM_Tick(object sender, EventArgs e)
        {
            Jumping(Margalit, 845, JumpTimerM, ref CanJumpM, ref jumpM, PressM, MoveLbl); //Jump Function To Margalit

        }

        public void Jumping(Image Victim, int Max, DispatcherTimer timer, ref bool Canjump, ref double jump, Label lbl, bool Move)
        {
            if (Canvas.GetTop(Victim) <= Max)                                    //Check If Victum(Margalit Or Toly) Isn't On Min Height(Floor) //Jump Victum
            {                                                                                                                                   //Jump Victum
                Canjump = false;                                                 //CanJunp False Because Character On Air                       //Jump Victum
                jump -= gravity;                                                 //Jump Until Jump Is Negative And Character Fall Down          //Jump Victum
                Canvas.SetTop(Victim, Canvas.GetTop(Victim) - jump);             //Move Victum                                                  //Jump Victum
                if (Move)
                    Canvas.SetTop(lbl, Canvas.GetTop(lbl) - jump);               //If Victum On Top Go Negative Jump To Pool Down Victum        //Pool Down Victum
            }                                                                    //Negative Jump to Pool Down Victum                            //Pool Down Victum
            else if (Canvas.GetTop(Victim) > Max)
            {                                                                    //If Victum On Floor                                            
                Canjump = true;                                                                                                                 //Prepare Victum To Next Jump
                timer.Stop();                                                    //Victum Can Jump Because He Is On The Ground                  //Prepare Victum To Next Jump
                Canvas.SetTop(Victim, Max);                                      //Stop Jumping                                                 //Prepare Victum To Next Jump
                Canvas.SetTop(lbl, Max-50);                                         //Set Victum Ground To Next Jump                               //Prepare Victum To Next Jump
                jump = 9;                                                        //Set Jump To 6 For The Next Jump                              //Prepare Victum To Next Jump
            }

        }


        private void PhysicsTimer_Tick(object sender, EventArgs e)
        {
            if (shootM)                                                          //If Shoot True Shoot
            {
                Canvas.SetTop(Algo, Canvas.GetTop(Algo) - 10);                  //Shoot
                if (Canvas.GetTop(Algo) < -200)                                 //If Shoot Up Dont Shoot
                    shootM = false;
            }
            if (shootT)                                                         //If Shoot True Shoot
            {
                Step.Content = "Step: " + StepI;                                //Change Steps Toly
                Canvas.SetTop(Step, Canvas.GetTop(Step) - 10);                  //Shoot
                if (Canvas.GetTop(Step) < -200)                                 //If Shoot Up Dont Shoot
                    shootT = false;
            }
            Rect rectStep = new Rect(Canvas.GetLeft(Step), Canvas.GetTop(Step), Step.Width, Step.Height);   //Rects
            Rect rectAlgo = new Rect(Canvas.GetLeft(Algo), Canvas.GetTop(Algo), Algo.Width, Algo.Height);   //Rects
            Rect rectGad = new Rect(Canvas.GetLeft(Gad), Canvas.GetTop(Gad), Gad.Width, Gad.Height);        //Rects
            if (rectStep.IntersectsWith(rectGad))               //If Gad Intersects Step life -10
            {
                life.Value -= 10;                               //Life -10
                Canvas.SetTop(Step, -200);                      //Return Step Up
            }
            if (rectAlgo.IntersectsWith(rectGad))              //If Gad Intersects Algo life -5
            {
                life.Value -= 5;                               //Life -5
                Canvas.SetTop(Algo, -200);                     //Return Step Up
            }
            if (WinShow.Height > 1)                            //If Win Height > 1 Sub Height and Width
            {                                                  
                WinShow.Height -= f * 2;                       //Sub Height
                WinShow.Width -= f * 2;                        //Sub Width
                Canvas.SetLeft(WinShow, Canvas.GetLeft(WinShow) + f); //Stay Center
                Canvas.SetTop(WinShow, Canvas.GetTop(WinShow) + f);   //Stay Center
                f += 0.001;                                           //Up Var
            }
            else
            {
                start = true;                                       //
                PressM.Visibility = Visibility.Hidden;
                PressT.Visibility = Visibility.Hidden;
                MoveLbl = false;
                lblEsc.Visibility = Visibility.Hidden;
                WinShow.Visibility = Visibility.Hidden;
                Class1.Dir(ref Dir, Gad, 0, 1540,8);
                if (wait == rand * 25)
                {
                    Canvas.SetLeft(Rain, Canvas.GetLeft(Gad) + 135);
                    Canvas.SetTop(Rain, Canvas.GetTop(Gad) + 400);
                    shoot = true;
                    wait = 0;
                    rand = rnd.Next(10, 16);
                }
                else
                    wait++;

                if (shoot)
                {
                    Rain.Visibility = Visibility.Visible;
                    Canvas.SetTop(Rain, Canvas.GetTop(Rain) + 8);
                    if (Canvas.GetTop(Rain) > 1300)
                    {
                        Rain.Visibility = Visibility.Hidden;
                        shoot = false;
                    }
                }
            }
            Rect rectToly = new Rect(Canvas.GetLeft(Toly), Canvas.GetTop(Toly), Toly.Width, Toly.Height);
            Rect rectMarg = new Rect(Canvas.GetLeft(Margalit) + 80, Canvas.GetTop(Margalit), 50, Margalit.Height);
            Rect rectRain = new Rect(Canvas.GetLeft(Rain), Canvas.GetTop(Rain), Rain.Width, Rain.Height);
            if (rectMarg.IntersectsWith(rectRain) || rectToly.IntersectsWith(rectRain))
                dead();

            if (life.Value <= 0)
                Over();

        }
        public void dead()
        {
            PhysicsTimer.Stop();
            JumpTimerM.Stop();
            JumpTimerT.Stop();
            RightTimerM.Stop();
            RightTimerT.Stop();
            LeftTimerT.Stop();
            LeftTimerM.Stop();
            MessageBox.Show("You Lose Try Again");
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        public void Over()
        {
            PhysicsTimer.Stop();
            JumpTimerM.Stop();
            JumpTimerT.Stop();
            RightTimerM.Stop();
            RightTimerT.Stop();
            LeftTimerT.Stop();
            LeftTimerM.Stop();
            MessageBox.Show("You Win!!!");
            Finish finish = new Finish();
            finish.Show();
            this.Close();
        }
        private void LeftTimerT_Tick(object sender, EventArgs e)
        {

            if (Canvas.GetLeft(Toly) >= 0)
            {
                Canvas.SetLeft(Toly, Canvas.GetLeft(Toly) - 6);
                if (MoveLbl)
                    Canvas.SetLeft(PressT, Canvas.GetLeft(PressT) - 6);
            }


            if (animateA == 0)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/1.png"));
            else if (animateA == 5)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/2.png"));
            else if (animateA == 10)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/3.png"));
            else if (animateA == 15)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/4.png"));
            else if (animateA == 20)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/5.png"));
            else if (animateA == 25)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/6.png"));
            else if (animateA == 30)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/7.png"));
            else if (animateA == 35)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/8.png"));
            else if (animateA == 40)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/9.png"));
            else if (animateA == 45)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/10.png"));
            else if (animateA == 50)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/11.png"));
            else if (animateA == 55)
            {
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/12.png"));
                animateA = 0;
            }
            animateA++;
        }
        private void RightTimerT_Tick(object sender, EventArgs e)
        {
            if (Canvas.GetLeft(Toly) <= 1780)
            {
                Canvas.SetLeft(Toly, Canvas.GetLeft(Toly) + 6);
                if (MoveLbl)
                    Canvas.SetLeft(PressT, Canvas.GetLeft(PressT) + 6);
            }
            if (animateA == 0)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/1.png"));
            else if (animateA == 5)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/2.png"));
            else if (animateA == 10)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/3.png"));
            else if (animateA == 15)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/4.png"));
            else if (animateA == 20)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/5.png"));
            else if (animateA == 25)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/6.png"));
            else if (animateA == 30)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/7.png"));
            else if (animateA == 35)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/8.png"));
            else if (animateA == 40)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/9.png"));
            else if (animateA == 45)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/10.png"));
            else if (animateA == 50)
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/11.png"));
            else if (animateA == 55)
            {
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/12.png"));
                animateA = 0;
            }
            animateA++;
        }
        private void LeftTimerM_Tick(object sender, EventArgs e)
        {
            if (Canvas.GetLeft(Margalit) >= 0)
            {
                Canvas.SetLeft(Margalit, Canvas.GetLeft(Margalit) - 6);
                if (MoveLbl)
                    Canvas.SetLeft(PressM, Canvas.GetLeft(PressM) - 6);
            }
            if (animateM == 0)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/1.png"));
            else if (animateM == 5)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/2.png"));
            else if (animateM == 10)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/3.png"));
            else if (animateM == 15)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/4.png"));
            else if (animateM == 20)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/5.png"));
            else if (animateM == 25)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/6.png"));
            else if (animateM == 30)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/7.png"));
            else if (animateM == 35)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/8.png"));
            else if (animateM == 40)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/9.png"));
            else if (animateM == 45)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/10.png"));
            else if (animateM == 50)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/11.png"));
            else if (animateM == 55)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/12.png"));
            else if (animateM == 60)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/13.png"));
            else if (animateM == 65)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/14.png"));
            else if (animateM == 70)
            {
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/15.png"));
                animateM = 0;
            }
            animateM++;
        }

        private void RightTimerM_Tick(object sender, EventArgs e)
        {
            if (Canvas.GetLeft(Margalit) <= 1780)
            {
                Canvas.SetLeft(Margalit, Canvas.GetLeft(Margalit) + 6);
                if (MoveLbl)
                    Canvas.SetLeft(PressM, Canvas.GetLeft(PressM) + 6);
            }
            if (animateM == 0)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/1.png"));
            else if (animateM == 5)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/2.png"));
            else if (animateM == 10)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/3.png"));
            else if (animateM == 15)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/4.png"));
            else if (animateM == 20)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/5.png"));
            else if (animateM == 25)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/6.png"));
            else if (animateM == 30)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/7.png"));
            else if (animateM == 35)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/8.png"));
            else if (animateM == 40)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/9.png"));
            else if (animateM == 45)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/10.png"));
            else if (animateM == 50)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/11.png"));
            else if (animateM == 55)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/12.png"));
            else if (animateM == 60)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/13.png"));
            else if (animateM == 65)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/14.png"));
            else if (animateM == 70)
            {
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/15.png"));
                animateM = 0;
            }
            animateM++;
        }
        bool MoveLbl = false;
        bool shootM = false;
        bool shootT = false;
        bool start = false;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Right)
                RightTimerM.Start();
            if (e.Key == Key.Left)
                LeftTimerM.Start();
            if (e.Key == Key.Up || e.Key == Key.Space && CanJumpM)
                JumpTimerM.Start();
            if (e.Key == Key.Escape)
            {
                if (PhysicsTimer.IsEnabled == false)
                {
                    PhysicsTimer.Start();
                    lblEsc.Content = "Oops ;(";
                    PressM.Visibility = Visibility.Visible;
                    PressT.Visibility = Visibility.Visible;
                    Canvas.SetLeft(PressM, Canvas.GetLeft(Margalit) - 25);
                    Canvas.SetTop(PressM, Canvas.GetTop(Margalit) - 40);

                    Canvas.SetLeft(PressT, Canvas.GetLeft(Toly) - 70);
                    Canvas.SetTop(PressT, Canvas.GetTop(Toly) - 60);

                    MoveLbl = true;
                    WE.Stop();
                }
            }
            if (start)
            {
                if (shootM == false)
                {
                    if (e.Key == Key.Enter)
                    {
                        shootM = true;
                        Canvas.SetTop(Algo, Canvas.GetTop(Margalit));
                        Canvas.SetLeft(Algo, Canvas.GetLeft(Margalit));

                    }
                }
                if (shootT == false)
                {
                    if (e.Key == Key.G)
                    {
                        StepI++;
                        shootT = true;
                        Canvas.SetTop(Step, Canvas.GetTop(Toly));
                        Canvas.SetLeft(Step, Canvas.GetLeft(Toly));
                    }
                }
            }
            if (e.Key == Key.A)
                LeftTimerT.Start();
            if (e.Key == Key.D)
                RightTimerT.Start();
            if (e.Key == Key.W && CanJumpT)
                JumpTimerT.Start();
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
                RightTimerM.Stop();
            if (e.Key == Key.Left)
                LeftTimerM.Stop();



            if (e.Key == Key.A)
                LeftTimerT.Stop();
            if (e.Key == Key.D)
                RightTimerT.Stop();


        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            WE.Stop();
            WE.Play();
        }
    }
}
