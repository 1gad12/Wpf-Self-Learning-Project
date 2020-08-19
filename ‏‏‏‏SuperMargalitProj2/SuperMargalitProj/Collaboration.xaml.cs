
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SuperMargalitProj
{
    /// <summary>
    /// Interaction logic for Collaboration.xaml
    /// </summary>
    public partial class Collaboration : Window
    {

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PhysicsTimer.Stop();                //When Window Close Stop All Threads                                                           
            JumpTimerM.Stop();                  //When Window Close Stop All Threads                                                           
            JumpTimerT.Stop();                  //When Window Close Stop All Threads                                                           
            RightTimerM.Stop();                 //When Window Close Stop All Threads                                                           
            LeftTimerM.Stop();                  //When Window Close Stop All Threads                                                           
            RightTimerT.Stop();                 //When Window Close Stop All Threads                                                           
            LeftTimerT.Stop();                  //When Window Close Stop All Threads                                                           
        }

        private DispatcherTimer PhysicsTimer; // Timer Physics

        private DispatcherTimer JumpTimerM;   // Timer JumpMargalit
        private DispatcherTimer JumpTimerT;   // Timer Anatoly

        private DispatcherTimer RightTimerM;  // Timer Move Right Margalit
        private DispatcherTimer LeftTimerM;   // Timer Move Left Margalit
        private DispatcherTimer RightTimerT;  // Timer Move Right Toly
        private DispatcherTimer LeftTimerT;   // Timer Move Left Toly

        double gravity = 0.2;                 // Gravity For Jumping
        double jumpM = 6;                     // Jump Margalit var
        double jumpT = 6;                     // Jump Toly var
        double Angle = 0;                     //Angle For Ball

        int animateM = 0;                     //Var For Animations Margalit
        int animateA = 0;                     //Var For Animations Toly
        int Timer = 0;                        //Timer For CouldDown On The Begining

        int Slen;                             //Length Of Spikes

        bool CanJumpM = true;                 //True If Margalit Can Jump
        bool CanJumpT = true;                 //True If Toly Can Jump

        bool MR = true, ML = true;            //True If Margalit Can Go Right/Left
        bool TR = true, TL = true;
        //True If Toly Can Go Right/Left
        Image[] Spikes;                       //Array For Spikes
        Image[] Buttons;                      //Array For Buttons


        public Collaboration()
        {
            InitializeComponent();                                                    //Set Timer(all 1ms)
            PhysicsTimer = new System.Windows.Threading.DispatcherTimer();            //Set Timer(all 1ms)
            PhysicsTimer.Interval = TimeSpan.FromMilliseconds(1);                     //Set Timer(all 1ms)
            PhysicsTimer.Tick += PhysicsTimer_Tick;                                   //Set Timer(all 1ms)
            PhysicsTimer.Start();                                                     //Set Timer(all 1ms)
                                                                                      //Set Timer(all 1ms)
            JumpTimerM = new System.Windows.Threading.DispatcherTimer();              //Set Timer(all 1ms)
            JumpTimerM.Interval = TimeSpan.FromMilliseconds(1);                       //Set Timer(all 1ms)
            JumpTimerM.Tick += JumpTimerM_Tick;                                       //Set Timer(all 1ms)
                                                                                      //Set Timer(all 1ms)
            JumpTimerT = new System.Windows.Threading.DispatcherTimer();              //Set Timer(all 1ms)
            JumpTimerT.Interval = TimeSpan.FromMilliseconds(1);                       //Set Timer(all 1ms)
            JumpTimerT.Tick += JumpTimerT_Tick;                                       //Set Timer(all 1ms)
                                                                                      //Set Timer(all 1ms)
            RightTimerM = new System.Windows.Threading.DispatcherTimer();             //Set Timer(all 1ms)
            RightTimerM.Interval = TimeSpan.FromMilliseconds(1);                      //Set Timer(all 1ms)
            RightTimerM.Tick += RightTimerM_Tick;                                     //Set Timer(all 1ms)
                                                                                      //Set Timer(all 1ms)
            LeftTimerM = new System.Windows.Threading.DispatcherTimer();              //Set Timer(all 1ms)
            LeftTimerM.Interval = TimeSpan.FromMilliseconds(1);                       //Set Timer(all 1ms)
            LeftTimerM.Tick += LeftTimerM_Tick;                                       //Set Timer(all 1ms)
                                                                                      //Set Timer(all 1ms)
            RightTimerT = new System.Windows.Threading.DispatcherTimer();             //Set Timer(all 1ms)
            RightTimerT.Interval = TimeSpan.FromMilliseconds(1);                      //Set Timer(all 1ms)
            RightTimerT.Tick += RightTimerT_Tick;                                     //Set Timer(all 1ms)
                                                                                      //Set Timer(all 1ms)
            LeftTimerT = new System.Windows.Threading.DispatcherTimer();              //Set Timer(all 1ms)
            LeftTimerT.Interval = TimeSpan.FromMilliseconds(1);                       //Set Timer(all 1ms)
            LeftTimerT.Tick += LeftTimerT_Tick;                                       //Set Timer(all 1ms)

            Spikes = new Image[] { Spike1, Spike2, Spike3, Spike4 };                  //Array For Spikes
            Buttons = new Image[] { Button1, Button2, Button3, Button4 };             //Array For Buttons

            this.Opacity = Class1.brightness / 1850;                                  //Options Brightness


            Slen = Spikes.Length;                                                     //Length Of Spikes
            Call.Volume = Class1.Volume;                                              //Volume Music
            Call.Play();                                                              //Play Music
        }

        private void JumpTimerT_Tick(object sender, EventArgs e)
        {
            Jumping(Toly, 690, 590, JumpTimerT, ref CanJumpT, ref jumpT);             //Jump Function To Toly
        }

        private void JumpTimerM_Tick(object sender, EventArgs e)
        {
            Jumping(Margalit, 225, 125, JumpTimerM, ref CanJumpM, ref jumpM);        //Jump Function To Margalit
        }

        public void Jumping(Image Victum, int Max, int Min, DispatcherTimer timer, ref bool Canjump, ref double jump)
        {
            if (Canvas.GetTop(Victum) <= Max)                           //Check If Victum(Margalit Or Toly) Isn't On Min Height(Floor) //Jump Victum
            {                                                                                                                          //Jump Victum
                Canjump = false;                                        //CanJunp False Because Character On Air                       //Jump Victum
                jump -= gravity;                                        //Jump Until Jump Is Negative And Character Fall Down          //Jump Victum
                Canvas.SetTop(Victum, Canvas.GetTop(Victum) - jump);    //Move Victum                                                  //Jump Victum
            }
            else if (Canvas.GetTop(Victum) <= Min)                      //If Victum On Top Go Negative Jump To Pool Down Victum        //Pool Down Victum
                jump = -6;                                              //Negative Jump to Pool Down Victum                            //Pool Down Victum

            else if (Canvas.GetTop(Victum) > Max)                       //If Victum On Floor                                            
            {                                                                                                                          //Prepare Victum To Next Jump 
                Canjump = true;                                         //Victum Can Jump Because He Is On The Ground                  //Prepare Victum To Next Jump 
                timer.Stop();                                           //Stop Jumping                                                 //Prepare Victum To Next Jump 
                Canvas.SetTop(Victum, Max);                             //Set Victum Ground To Next Jump                               //Prepare Victum To Next Jump 
                jump = 6;                                               //Set Jump To 6 For The Next Jump                              //Prepare Victum To Next Jump 
            }

        }


        private void PhysicsTimer_Tick(object sender, EventArgs e)
        {

            if (Canvas.GetLeft(Gridi) <= -18080)             //If Canvas -18080 You Win
            {                                               //Stop Timer Because Win
                LeftTimerM.Stop();                          //Stop Timer Because Win
                LeftTimerT.Stop();                          //Stop Timer Because Win
                RightTimerM.Stop();                         //Stop Timer Because Win
                RightTimerT.Stop();                         //Stop Timer Because Win
                PhysicsTimer.Stop();                        //Stop Timer Because Win
                Class1.Game[3] = true;                      //Show lbl Done Because Win
                MessageBox.Show("Victory");                 //Show Victory
                MainWindow main = new MainWindow();          //Return Menu
                main.Show();                                 //Return Menu
                this.Close();                                //Close This Window
            }

            if (Timer == 100)                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            {                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeA.Content = "3";                                            //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeM.Content = "3";                                            //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                Timer++;                                                           //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            }                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            else if (Timer == 200)                                                 //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            {                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeA.Content = "2";                                            //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeM.Content = "2";                                            //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                Timer++;                                                           //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            }                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            else if (Timer == 300)                                                 //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            {                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeA.Content = "1";                                            //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeM.Content = "1";                                            //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                Timer++;                                                           //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            }                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            else if (Timer == 300)                                                 //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            {                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeA.Content = "Go!";                                          //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeM.Content = "Go!";                                          //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                Timer++;                                                           //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            }                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            else if (Timer == 350)                                                 //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            {                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeA.Visibility = Visibility.Hidden;                           //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                lblTimeM.Visibility = Visibility.Hidden;                           //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + 4.5);                  //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                Angle++;                                                           //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                RotateTransform rotate = new RotateTransform(Angle);               //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
                Ball.RenderTransform = rotate;                                     //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            }                                                                      //Show 3,2,1,Go! Before Start Game And When Finish Start Moving Ball
            else
                Timer++;




            Rect rectMargalit = new Rect(Canvas.GetLeft(Margalit), Canvas.GetTop(Margalit), Margalit.Width, Margalit.Height);        //Make Rect To Check Intersect
            Rect rectBall = new Rect(Canvas.GetLeft(Ball), Canvas.GetTop(Ball), Ball.Width - 152, Ball.Height);                        //Make Rect To Check Intersect
            Rect rectToly = new Rect(Canvas.GetLeft(Toly), Canvas.GetTop(Toly), Toly.Width, Toly.Height);                            //Make Rect To Check Intersect



            if (rectMargalit.IntersectsWith(rectBall))        //If There IS Intersect With The Ball Game End
                End();                                        //If There IS Intersect With The Ball Game End
            else if (rectToly.IntersectsWith(rectBall))       //If There IS Intersect With The Ball Game End
                End();                                        //If There IS Intersect With The Ball Game End



            for (int i = 0; i < Slen; i++)                    //Loop SLen Times
            {
                if (Buttons[i] != null)                       //If There Is Button ON The Map Continue
                {
                    Rect rectSpikes = new Rect(Canvas.GetLeft(Spikes[i]) + 115, Canvas.GetTop(Spikes[i]), 1, Spikes[i].Height);        //Make Rect To Check Intersect
                    Rect rectButton = new Rect(Canvas.GetLeft(Buttons[i]) + 5, Canvas.GetTop(Buttons[i]), Buttons[i].Width - 5, 5);  //Make Rect To Check Intersect

                    if (rectMargalit.IntersectsWith(rectSpikes) || rectToly.IntersectsWith(rectSpikes))                              //If There IS Intersect With Spikes Game End
                        End();
                    else if (rectMargalit.IntersectsWith(rectButton) || rectToly.IntersectsWith(rectButton))                         //If There IS Intersect With Button
                    {
                        Buttons[i].IsEnabled = false;                                                                                //Hide Button And Spike And Get Out From Array
                        Buttons[i].Visibility = Visibility.Hidden;                                                                   //Hide Button And Spike And Get Out From Array
                        Buttons[i] = null;                                                                                           //Hide Button And Spike And Get Out From Array
                                                                                                                                     //Hide Button And Spike And Get Out From Array
                        Spikes[i].IsEnabled = false;                                                                                 //Hide Button And Spike And Get Out From Array
                        Spikes[i].Visibility = Visibility.Hidden;                                                                    //Hide Button And Spike And Get Out From Array
                        Spikes[i] = null;                                                                                            //Hide Button And Spike And Get Out From Array
                    }
                }
            }


            Rect rectPush1 = new Rect(Canvas.GetLeft(PushButton1), Canvas.GetTop(PushButton1), PushButton1.Width, PushButton1.Height);        //Make Rect To Check Intersect
            Rect rectPush2 = new Rect(Canvas.GetLeft(PushButton2), Canvas.GetTop(PushButton2), PushButton2.Width, PushButton2.Height);        //Make Rect To Check Intersect

            if (rectToly.IntersectsWith(rectPush1))                      //If Toly Intersect Push1                                                 
            {
                if (Canvas.GetTop(Block) > -200)                         //If Block Isn't Too Much UpStairs Go Up                                                  
                    Canvas.SetTop(Block, Canvas.GetTop(Block) - 7);      //Go UP
            }
            else if (Canvas.GetTop(Block) < 145)                         //If No Intersect And block Isn't Too Much Down Go Down
                Canvas.SetTop(Block, Canvas.GetTop(Block) + 7);          //Go Down

            if (rectMargalit.IntersectsWith(rectPush2))                     //If Toly Intersect Push2                            
            {
                if (Canvas.GetTop(Block2) < 940)                            //If Block2 Isn't Too Much UpStairs Go Up             
                    Canvas.SetTop(Block2, Canvas.GetTop(Block2) + 7);       //Go UP
            }
            else if (Canvas.GetTop(Block2) > 605)                           //If No Intersect And Block2 Isn't Too Much Down Go Down
                Canvas.SetTop(Block2, Canvas.GetTop(Block2) - 7);           //Go Down
                                                                                                                      //Make Rect To Check Intersect
            Rect rectBlockR = new Rect(Canvas.GetLeft(Block), Canvas.GetTop(Block), 20, Block.Height);                //Make Rect To Check Intersect
            Rect rectBlockL = new Rect(Canvas.GetLeft(Block) + 136, Canvas.GetTop(Block), 20, Block.Height);          //Make Rect To Check Intersect
            Rect rectBlock2R = new Rect(Canvas.GetLeft(Block2), Canvas.GetTop(Block2), 20, Block2.Height);            //Make Rect To Check Intersect
            Rect rectBlock2L = new Rect(Canvas.GetLeft(Block2) + 136, Canvas.GetTop(Block2), 20, Block2.Height);      //Make Rect To Check Intersect

            MR = true;                     //Make True Because if There Is Intersect Make False
            ML = true;                     //Make True Because if There Is Intersect Make False

            if (rectMargalit.IntersectsWith(rectBlockR)) //If Intersect Make False
                MR = false;
            if (rectMargalit.IntersectsWith(rectBlockL)) //If Intersect Make False
                ML = false;

            TR = true;                     //Make True Because if There Is Intersect Make False
            TL = true;                     //Make True Because if There Is Intersect Make False

            if (rectToly.IntersectsWith(rectBlock2R))   //If Intersect Make False
                TR = false;
            if (rectToly.IntersectsWith(rectBlock2L))   //If Intersect Make False
                TL = false;


        }
        public void End()
        {
            LeftTimerM.Stop();                           //Stop Timer Because End
            LeftTimerT.Stop();                           //Stop Timer Because End
            RightTimerM.Stop();                          //Stop Timer Because End
            RightTimerT.Stop();                          //Stop Timer Because End
            PhysicsTimer.Stop();                         //Stop Timer Because End
            MessageBox.Show("You failed :(, try again"); //Cheer Message

            Lose lose = new Lose();                      //Go To Lose Because Lose
            lose.Show();                                 //Go To Lose Because Lose
            this.Close();                                //Close This Window
        }
        private void LeftTimerT_Tick(object sender, EventArgs e)
        {
            if (TL)                                              //If Can Go Left Go Left
                Canvas.SetLeft(Toly, Canvas.GetLeft(Toly) - 6);  //Go Left

            if (animateA == 0)                                                                                         //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/1.png"));      //Animation
            else if (animateA == 5)                                                                                    //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/2.png"));      //Animation
            else if (animateA == 10)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/3.png"));      //Animation
            else if (animateA == 15)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/4.png"));      //Animation
            else if (animateA == 20)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/5.png"));      //Animation
            else if (animateA == 25)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/6.png"));      //Animation
            else if (animateA == 30)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/7.png"));      //Animation
            else if (animateA == 35)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/8.png"));      //Animation
            else if (animateA == 40)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/9.png"));      //Animation
            else if (animateA == 45)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/10.png"));     //Animation
            else if (animateA == 50)                                                                                   //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/11.png"));     //Animation
            else if (animateA == 55)                                                                                   //Animation
            {                                                                                                          //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Left/12.png"));     //Animation
                animateA = 0;                                                                                          //Animation
            }                                                                                                          //Animation
            animateA++;                                                                                                //Animation
        }
        private void RightTimerT_Tick(object sender, EventArgs e)
        {


            if (TR) //If Can Go Right Go Right
            {
                Canvas.SetLeft(Toly, Canvas.GetLeft(Toly) + 6);    //Go Right
                if ((Canvas.GetLeft(Toly) >= 1290 && Canvas.GetLeft(Margalit) >= 1290 && Canvas.GetLeft(Toly) <= 1600 - Canvas.GetLeft(Gridi)) || Canvas.GetLeft(Toly) >= 1590 - Canvas.GetLeft(Gridi) && Canvas.GetLeft(Margalit) >= 1590 - Canvas.GetLeft(Gridi)) //If Toly Right Canvas Go LEft
                    Canvas.SetLeft(Gridi, Canvas.GetLeft(Gridi) - 3); //Canvas Go Left
            }
            if (animateA == 0)                                                                                       //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/1.png"));   //Animation
            else if (animateA == 5)                                                                                  //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/2.png"));   //Animation
            else if (animateA == 10)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/3.png"));   //Animation
            else if (animateA == 15)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/4.png"));   //Animation
            else if (animateA == 20)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/5.png"));   //Animation
            else if (animateA == 25)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/6.png"));   //Animation
            else if (animateA == 30)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/7.png"));   //Animation
            else if (animateA == 35)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/8.png"));   //Animation
            else if (animateA == 40)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/9.png"));   //Animation
            else if (animateA == 45)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/10.png"));  //Animation
            else if (animateA == 50)                                                                                 //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/11.png"));  //Animation
            else if (animateA == 55)                                                                                 //Animation
            {                                                                                                        //Animation
                Toly.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Collaboration/Right/12.png"));  //Animation
                animateA = 0;                                                                                        //Animation
            }                                                                                                        //Animation
            animateA++;                                                                                              //Animation
        }
        private void LeftTimerM_Tick(object sender, EventArgs e)
        {
            if (ML)                                                        //If Can Go Left Go Left
                Canvas.SetLeft(Margalit, Canvas.GetLeft(Margalit) - 6);    //Go Left

            if (animateM == 0)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/1.png"));      //Animation
            else if (animateM == 5)                                                                                  //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/2.png"));      //Animation
            else if (animateM == 10)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/3.png"));      //Animation
            else if (animateM == 15)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/4.png"));      //Animation
            else if (animateM == 20)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/5.png"));      //Animation
            else if (animateM == 25)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/6.png"));      //Animation
            else if (animateM == 30)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/7.png"));      //Animation
            else if (animateM == 35)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/8.png"));      //Animation
            else if (animateM == 40)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/9.png"));      //Animation
            else if (animateM == 45)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/10.png"));     //Animation
            else if (animateM == 50)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/11.png"));     //Animation
            else if (animateM == 55)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/12.png"));     //Animation
            else if (animateM == 60)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/13.png"));     //Animation
            else if (animateM == 65)                                                                                 //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/14.png"));     //Animation
            else if (animateM == 70)                                                                                 //Animation
            {                                                                                                        //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/15.png"));     //Animation
                animateM = 0;                                                                                        //Animation
            }                                                                                                        //Animation
            animateM++;                                                                                              //Animation
        }

        private void RightTimerM_Tick(object sender, EventArgs e)
        {


            if (MR)     //If Can Go Right Go Right
            {
                Canvas.SetLeft(Margalit, Canvas.GetLeft(Margalit) + 6); //Go Right
                if ((Canvas.GetLeft(Toly) >= 1290 && Canvas.GetLeft(Margalit) >= 1290 && Canvas.GetLeft(Margalit) <= 1600 - Canvas.GetLeft(Gridi)) || Canvas.GetLeft(Toly) >= 1590 - Canvas.GetLeft(Gridi) && Canvas.GetLeft(Margalit) >= 1590 - Canvas.GetLeft(Gridi))//If Toly Right Canvas Go LEft
                    Canvas.SetLeft(Gridi, Canvas.GetLeft(Gridi) - 3);//Canvas Go Left
            }

            if (animateM == 0)                                                                                     //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/1.png"));   //Animation
            else if (animateM == 5)                                                                                //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/2.png"));   //Animation
            else if (animateM == 10)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/3.png"));   //Animation
            else if (animateM == 15)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/4.png"));   //Animation
            else if (animateM == 20)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/5.png"));   //Animation
            else if (animateM == 25)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/6.png"));   //Animation
            else if (animateM == 30)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/7.png"));   //Animation
            else if (animateM == 35)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/8.png"));   //Animation
            else if (animateM == 40)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/9.png"));   //Animation
            else if (animateM == 45)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/10.png"));  //Animation
            else if (animateM == 50)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/11.png"));  //Animation
            else if (animateM == 55)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/12.png"));  //Animation
            else if (animateM == 60)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/13.png"));  //Animation
            else if (animateM == 65)                                                                               //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/14.png"));  //Animation
            else if (animateM == 70)                                                                               //Animation
            {                                                                                                      //Animation
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/15.png"));  //Animation
                animateM = 0;                                                                                      //Animation
            }                                                                                                      //Animation
            animateM++;                                                                                            //Animation
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Call.Stop();                                                    //If Media End, Start
            Call.Play();                                                    //If Media End, Start
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Timer >= 300)                                              //If Time Is Ok Check Key Down
            {
                if (e.Key == Key.Right)  //If Right
                    RightTimerM.Start(); // Right
                if (e.Key == Key.Left)   //IF left
                    LeftTimerM.Start(); //Left
                if (e.Key == Key.Up || e.Key == Key.Space && CanJumpM) //If Space/Up and Can Jump 
                    JumpTimerM.Start();                                //Jump


                if (e.Key == Key.A)              //If A 
                    LeftTimerT.Start();          //LEft
                if (e.Key == Key.D)              //If D
                    RightTimerT.Start();         //Right
                if (e.Key == Key.W && CanJumpT)  //If W And CanJump 
                    JumpTimerT.Start();          //Jump
            }
            if (e.Key == Key.Escape)                 //If Esc
            {                                        //Timer Stop
                LeftTimerM.Stop();                   //Timer Stop
                LeftTimerT.Stop();                   //Timer Stop
                RightTimerM.Stop();                  //Timer Stop
                RightTimerT.Stop();                  //Timer Stop
                PhysicsTimer.Stop();                 //Timer Stop
                MainWindow main = new MainWindow();  //Main Show
                main.Show();                         //Main Show
                this.Close();                        //Window Hide
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right) //Stop Right if KeyUp
                RightTimerM.Stop(); //StopRight
            if (e.Key == Key.Left)  //Stop Left if KeyUp
                LeftTimerM.Stop();  //StopRight



            if (e.Key == Key.A)      //Stop D if KeyUp
                LeftTimerT.Stop();   //StopLeft
            if (e.Key == Key.D)      //Stop D if KeyUp
                RightTimerT.Stop();  //StopRight
        }


    }
}