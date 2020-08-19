using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SuperMargalitProj
{


    public partial class Journey : Window
    {
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RightTimer.Stop();
            LeftTimer.Stop();
            JumpTimer.Stop();
            PhysicTimer.Stop();

        }
        private DispatcherTimer RightTimer;
        private DispatcherTimer LeftTimer;
        private DispatcherTimer JumpTimer;
        private DispatcherTimer PhysicTimer;
        Random rnd;
        Rect rectF1;
        Rect rectF2;
        Rect rectF3;
        Rect rectF4;
        Rect rect41;
        Rect rect56;
        Rect rectEnd;
        Image[] W;
        Image[] F;
        Image[] Q;
        int[] Qopen;
        Image[] P;
        Image[] B;
        Image[] E;
        Image[] Bounds;
        int live = 3;
        int Quesrnd;
        int Boundslen;
        int Qlen;
        int Wlen;
        int Elen;
        int animate = 0;
        double gravity = 0.2;
        double fall = 10;
        double jump = 10;
        double PointCurrect;
        bool DirB1 = false;
        bool DirB2 = false;
        bool DirB3 = false;
        bool DirB4 = false;
        bool DirB5 = false;
        bool DirB6 = false;
        bool DirB7 = false;
        bool DirF = false;
        bool ShiledB = false;
        bool OnFloor = false;
        bool BoundRight = false;
        bool BoundLeft = false;
        bool BoundDown = false;
        bool BoundDownToDown = false;
        public Journey()
        {
            InitializeComponent();

            this.Opacity = Class1.brightness / 1850;

            RightTimer = new System.Windows.Threading.DispatcherTimer();
            RightTimer.Interval = TimeSpan.FromMilliseconds(1);
            RightTimer.Tick += RightTimer_Tick;

            LeftTimer = new System.Windows.Threading.DispatcherTimer();
            LeftTimer.Interval = TimeSpan.FromMilliseconds(1);
            LeftTimer.Tick += LeftTimer_Tick;

            JumpTimer = new System.Windows.Threading.DispatcherTimer();
            JumpTimer.Interval = TimeSpan.FromMilliseconds(1);
            JumpTimer.Tick += JumpTimer_Tick;

            PhysicTimer = new System.Windows.Threading.DispatcherTimer();
            PhysicTimer.Interval = TimeSpan.FromMilliseconds(1);
            PhysicTimer.Tick += PhysicTimer_Tick;
            PhysicTimer.Start();

            if (animate == 0)
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/1.png"));




            Q = new Image[14];
            W = new Image[27];
            P = new Image[6];
            B = new Image[24];
            F = new Image[4];
            E = new Image[7];
            Qopen = new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            E[0] = Bad1;
            E[1] = Bad2;
            E[2] = Bad3;
            E[3] = Bad4;
            E[4] = Bad5;
            E[5] = Bad6;
            E[6] = Bad7;


            F[0] = Floor1;
            F[1] = Floor2;
            F[2] = Floor3;
            F[3] = Floor4;

            P[0] = P1;
            P[1] = P2;
            P[2] = P3;
            P[3] = P4;
            P[4] = P5;
            P[5] = P6;

            Q[0] = Q1;
            Q[1] = Q2;
            Q[2] = Q3;
            Q[3] = Q4;
            Q[4] = Q5;
            Q[5] = Q6;
            Q[6] = Q7;
            Q[7] = Q8;
            Q[8] = Q9;
            Q[9] = Q10;
            Q[10] = Q11;
            Q[11] = Q12;
            Q[12] = Q13;
            Q[13] = Q14;


            W[0] = W1;
            W[1] = W2;
            W[2] = W3;
            W[3] = W4;
            W[4] = W5;
            W[5] = W6;
            W[6] = W7;
            W[7] = W8;
            W[8] = W9;
            W[9] = W10;
            W[10] = W11;
            W[11] = W12;
            W[12] = W13;
            W[13] = W14;
            W[14] = W15;
            W[15] = W16;
            W[16] = W17;
            W[17] = W18;
            W[18] = W19;
            W[19] = W20;
            W[20] = W21;
            W[21] = W22;
            W[22] = W23;
            W[23] = W24;
            W[24] = W25;
            W[25] = W26;
            W[26] = W27;

            B[0] = Brick11;
            B[1] = Brick12;
            B[2] = Brick13;
            B[3] = Brick14;
            B[4] = Brick21;
            B[5] = Brick22;
            B[6] = Brick23;
            B[7] = Brick24;
            B[8] = Brick31;
            B[9] = Brick32;
            B[10] = Brick33;
            B[11] = Brick34;
            B[12] = Brick41;
            B[13] = Brick42;
            B[14] = Brick43;
            B[15] = Brick44;
            B[16] = Brick51;
            B[17] = Brick52;
            B[18] = Brick53;
            B[19] = Brick54;
            B[20] = Brick55;
            B[21] = Brick56;
            B[22] = Brick57;
            B[23] = Brick58;

            Bounds = new Image[] { P1,P2,P3,P4,P5,P6,
                Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, Q12, Q13, Q14,
                W1, W2, W3, W4, W5, W6, W7, W8, W9, W10, W11, W12, W13, W14, W15, W16, W17, W18, W19, W20, W21, W22, W23, W24, W25, W26, W27,
                Brick11,Brick12,Brick13,Brick14,Brick21,Brick22,Brick23,Brick24,Brick31,Brick32,Brick33,Brick34,Brick41,Brick42,Brick43,Brick44,Brick51,Brick52,Brick53,Brick54,Brick55,Brick56,Brick57,Brick58};

            Boundslen = Bounds.Length;
            Qlen = Q.Length;
            Wlen = W.Length;
            Elen = E.Length;

            rnd = new Random();
            rectF1 = new Rect(Canvas.GetLeft(Floor1), Canvas.GetTop(Floor1), Floor1.Width, Floor1.Height);
            rectF2 = new Rect(Canvas.GetLeft(Floor2), Canvas.GetTop(Floor2), Floor2.Width, Floor2.Height);
            rectF3 = new Rect(Canvas.GetLeft(Floor3), Canvas.GetTop(Floor3), Floor3.Width, Floor3.Height);
            rectF4 = new Rect(Canvas.GetLeft(Floor4), Canvas.GetTop(Floor4), Floor4.Width, Floor4.Height);

            rect41 = new Rect(Canvas.GetLeft(Brick41), Canvas.GetTop(Brick41), Brick41.Width, Brick41.Height);
            rect56 = new Rect(Canvas.GetLeft(Brick56), Canvas.GetTop(Brick56), Brick56.Width, Brick56.Height);
            
            rectEnd = new Rect(Canvas.GetLeft(End), Canvas.GetTop(End), End.Width, End.Height);

            Journey1.Volume = Class1.Volume;

            Journey1.Play();


        }



        private void PhysicTimer_Tick(object sender, EventArgs e)
        {

            Cs.Content = Cammo;
            Class1.Dir(ref DirB1, Bad1, 1570, 1782,3);
            Class1.Dir(ref DirB2, Bad2, 3650, 4264,3);
            Class1.Dir(ref DirB3, Bad3, 12528, 13527,3);
            Class1.Dir(ref DirB4, Bad4, 12875, 12960, 3);
            Class1.Dir(ref DirB5, Bad5, 6771, 10096,3);
            Class1.Dir(ref DirB6, Bad6, 5399, 6452,3);
            Class1.Dir(ref DirB7, Bad7, 6771, 10096,3);

            if (Canvas.GetLeft(FireShoot) >= 15720)
                DirF = false;

            if (DirF)
                Canvas.SetLeft(FireShoot, 15720);
            else
            {
                Canvas.SetLeft(FireShoot, Canvas.GetLeft(FireShoot) - 7);
                if (Canvas.GetLeft(FireShoot) <= 14392)
                    DirF = true;
            }



            if (live == 15)
                liveLbl.Content = "15";
            else if (live == 14)
                liveLbl.Content = "14";
            else if (live == 13)
                liveLbl.Content = "13";
            else if (live == 12)
                liveLbl.Content = "12";
            else if (live == 11)
                liveLbl.Content = "11";
            else if (live == 10)
                liveLbl.Content = "10";
            else if (live == 9)
                liveLbl.Content = "9";
            else if (live == 8)
                liveLbl.Content = "8";
            else if (live == 7)
                liveLbl.Content = "7";
            else if (live == 6)
                liveLbl.Content = "6";
            else if (live == 5)
                liveLbl.Content = "♥♥♥♥♥";
            else if (live == 4)
                liveLbl.Content = "♥♥♥♥";
            else if (live == 3)
                liveLbl.Content = "♥♥♥";
            else if (live == 2)
                liveLbl.Content = "♥♥";
            else if (live == 1)
                liveLbl.Content = "♥";
            else
            {
                PhysicTimer.Stop();
                JumpTimer.Stop();
                RightTimer.Stop();
                LeftTimer.Stop();
                MessageBox.Show("GameOver");
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }

            if (Canvas.GetTop(Margalit) > 1080)
                dead();




            Rect rectS = new Rect(Canvas.GetLeft(Shiled), Canvas.GetTop(Shiled), Shiled.Width, Shiled.Height);
            Rect rectF = new Rect(Canvas.GetLeft(FireShoot), Canvas.GetTop(FireShoot), FireShoot.Width, FireShoot.Height);
            Rect rectM = new Rect(Canvas.GetLeft(Margalit), Canvas.GetTop(Margalit), Margalit.Width, Margalit.Height);
            Rect rectMU = new Rect(Canvas.GetLeft(Margalit) + 100, Canvas.GetTop(Margalit) + 7, 25, 1);
            Rect rectMR = new Rect(Canvas.GetLeft(Margalit) + 162, Canvas.GetTop(Margalit) + 58, 1, 105);
            Rect rectML = new Rect(Canvas.GetLeft(Margalit) + 47, Canvas.GetTop(Margalit) + 58, 1, 105);
            Rect rectMD = new Rect(Canvas.GetLeft(Margalit) + 48, Canvas.GetTop(Margalit) + 213, 114, 1);
            Rect rectCS = new Rect(Canvas.GetLeft(CShoot), Canvas.GetTop(CShoot), CShoot.Width, CShoot.Height);

            if (rectM.IntersectsWith(rectEnd))
            {
                PhysicTimer.Stop();
                RightTimer.Stop();
                LeftTimer.Stop();
                MessageBox.Show("Victory");
                Class1.Game[0] = true;
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }

            if (rectF.IntersectsWith(rectM))
                dead();

            if (rectF.IntersectsWith(rectS) || rectF.IntersectsWith(rectCS))
                Canvas.SetLeft(FireShoot, 15720);



            for (int i = 0; i < Elen; i++)
            {
                if (E[i] != null)
                {
                    Rect rectE = new Rect(Canvas.GetLeft(E[i]), Canvas.GetTop(E[i]), E[i].Width, E[i].Height);
                    if (rectMD.IntersectsWith(rectE))
                    {
                        E[i].Visibility = Visibility.Hidden;
                        E[i] = null;
                        if (i == 1 || i == 5 || i == 4 || i == 6)
                            jump = 12;
                        else
                            jump = 6;
                        JumpTimer.Start();
                    }
                    else if (rectMU.IntersectsWith(rectE) || rectMR.IntersectsWith(rectE) || rectML.IntersectsWith(rectE))
                        dead();

                    if (rectCS.IntersectsWith(rectE))
                    {
                        if (MoveC == 1)
                            Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit) + 150);
                        else if (MoveC == 2)
                            Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit));
                        MoveC = 0;
                        CShoot.Visibility = Visibility.Hidden;
                        E[i].Visibility = Visibility.Hidden;
                        E[i] = null;


                    }
                }
            }


            OnFloor = false;
            if (rectM.IntersectsWith(rectF1) || rectM.IntersectsWith(rectF2) || rectM.IntersectsWith(rectF3) || rectM.IntersectsWith(rectF4))
                OnFloor = true;

            if (Canvas.GetTop(Margalit) >= 710 && OnFloor && !((Canvas.GetLeft(Margalit) > 11515 && Canvas.GetLeft(Margalit) < 11630) || (Canvas.GetLeft(Margalit) > 6420 && Canvas.GetLeft(Margalit) < 6625) || (Canvas.GetLeft(Margalit) > 5150 && Canvas.GetLeft(Margalit) < 5261)))
            {
                PointCurrect = 0;
                Canvas.SetTop(Margalit, 712);
                fall = 10;
            }

            if ((((Canvas.GetLeft(Margalit) > 11515 && Canvas.GetLeft(Margalit) < 11630) || (Canvas.GetLeft(Margalit) > 6420 && Canvas.GetLeft(Margalit) < 6625) || (Canvas.GetLeft(Margalit) > 5150 && Canvas.GetLeft(Margalit) < 5261)) || (Canvas.GetTop(Margalit) != 712 && BoundDownToDown == false)) && JumpTimer.IsEnabled == false)
            {
                Canvas.SetTop(Margalit, Canvas.GetTop(Margalit) + fall);
                fall += gravity;
            }

            BoundRight = false;
            BoundLeft = false;

            BoundDownToDown = false;
            if (MoveC == 1)
            {
                CShoot.Visibility = Visibility.Visible;
                Canvas.SetLeft(CShoot, Canvas.GetLeft(CShoot) + 16);
            }
            else if (MoveC == 2)
            {
                CShoot.Visibility = Visibility.Visible;
                Canvas.SetLeft(CShoot, Canvas.GetLeft(CShoot) - 16);
                if (Canvas.GetLeft(CShoot) < 0)
                {
                    if (MoveC == 1)
                        Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit) + 150);
                    else if (MoveC == 2)
                        Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit));
                    MoveC = 0;
                    CShoot.Visibility = Visibility.Hidden;
                }
            }

            for (int i = 0; i < Boundslen; i++)
            {
                if (Bounds[i] != null)
                {
                    Rect rectB = new Rect(Canvas.GetLeft(Bounds[i]), Canvas.GetTop(Bounds[i]), Bounds[i].Width, Bounds[i].Height);
                    Rect rectBD = new Rect(Canvas.GetLeft(Bounds[i]), Canvas.GetTop(Bounds[i]), Bounds[i].Width, 12);

                    if (rectMR.IntersectsWith(rectB))
                        BoundRight = true;
                    if (rectML.IntersectsWith(rectB))
                        BoundLeft = true;
                    if (rectMD.IntersectsWith(rectBD))
                    {
                        BoundDown = true;
                        BoundDownToDown = true;
                        fall = 6;
                        PointCurrect = Canvas.GetTop(Bounds[i]);
                    }

                    if (rectCS.IntersectsWith(rectB))
                    {
                        if (MoveC == 1)
                            Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit) + 150);
                        else if (MoveC == 2)
                            Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit));
                        MoveC = 0;
                        CShoot.Visibility = Visibility.Hidden;
                    }
                }
            }
          
            for (int i = 0; i < Qlen; i++)
            {
                Rect rectQ = new Rect(Canvas.GetLeft(Q[i]), Canvas.GetTop(Q[i]), Q[i].Width, Q[i].Height);
                if (rectMU.IntersectsWith(rectQ))
                {
                    Canvas.SetTop(Margalit, Canvas.GetTop(Margalit) + 12);
                    if (Qopen[i] != 5 && Qopen[i] == 0)
                    {
                        Q[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/EmptyQ.png"));
                        Quesrnd = rnd.Next(1, 5);
                        if (Quesrnd == 1)
                            Q[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/QSpike.png"));
                        else if (Quesrnd == 2)
                            Q[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Qheart.png"));
                        else if (Quesrnd == 3)
                            Q[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/QC.png"));
                        else if (Quesrnd == 4)
                            Q[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/QSpike.png"));

                        Q[i].Height = 156;
                        Canvas.SetTop(Q[i], Canvas.GetTop(Q[i]) - 78);

                        Qopen[i] = Quesrnd;
                    }
                    jump = -10;
                }
                else if (Qopen[i] != 0)
                {
                    Rect rectQopen = new Rect(Canvas.GetLeft(Q[i]), Canvas.GetTop(Q[i]), Q[i].Width, Q[i].Height - 78);
                    if (rectMU.IntersectsWith(rectQopen) || rectMD.IntersectsWith(rectQopen) || rectMR.IntersectsWith(rectQopen) || rectML.IntersectsWith(rectQopen))
                    {
                        if (Qopen[i] != 5)
                        {
                            if (Qopen[i] == 2)
                                live++;
                            else if (Qopen[i] == 3)
                                Cammo++;

                            if (Qopen[i] == 4 || Qopen[i] == 1)
                                dead();
                            else
                            {
                                Canvas.SetTop(Q[i], Canvas.GetTop(Q[i]) + 78);
                                Q[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/EmptyQ.png"));
                                Qopen[i] = 5;
                                Q[i].Height = 78;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < Wlen; i++)
            {
                if (W[i] != null)
                { 
                    Rect rectW = new Rect(Canvas.GetLeft(W[i]), Canvas.GetTop(W[i]), W[i].Width, W[i].Height);

                    if (rectMU.IntersectsWith(rectW))
                    {
                        if (i != 1)
                        {
                            W[i].Visibility = Visibility.Hidden;
                            W[i] = null;
                            Bounds[i + 20] = null;
                        }
                        else
                            W[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/EmptyQ.png"));
                        jump -= 10;
                    }
                }


            }

        }

        private void JumpTimer_Tick(object sender, EventArgs e)
        {
            if (BoundDown == false)
            {
                if (OnFloor)
                {
                    jump = 10;
                    JumpTimer.Stop();
                }
                else
                {
                    Canvas.SetTop(Margalit, Canvas.GetTop(Margalit) - jump);
                    jump -= gravity;
                    if (ShiledB)
                        Canvas.SetTop(Shiled, Canvas.GetTop(Margalit));
                }
            }
            else
            {
                if (OnFloor)
                {
                    jump = 10;
                    BoundDown = false;
                    JumpTimer.Stop();
                }
                else if (BoundDownToDown)
                {
                    //Canvas.SetTop(Margalit, PointCurrect - Margalit.Height);
                    JumpTimer.Stop();
                    jump = 10;
                }
                else
                {
                    Canvas.SetTop(Margalit, Canvas.GetTop(Margalit) - jump);
                    jump -= gravity;
                    if (ShiledB)
                        Canvas.SetTop(Shiled, Canvas.GetTop(Margalit));
                }
            }
        }

        int Speed = 6;
        private void LeftTimer_Tick(object sender, EventArgs e)
        {

            if (BoundLeft == false)
            {
                if (Canvas.GetLeft(Margalit) > 0)
                    Canvas.SetLeft(Margalit, Canvas.GetLeft(Margalit) - Speed);

                if (Canvas.GetLeft(Margalit) < 900 - Canvas.GetLeft(Gridi) && Canvas.GetLeft(Gridi) < -6)
                {
                    Canvas.SetLeft(Gridi, Canvas.GetLeft(Gridi) + Speed);
                    Canvas.SetLeft(liveLbl, Canvas.GetLeft(liveLbl) - Speed);
                    Canvas.SetLeft(liveTitleLbl, Canvas.GetLeft(liveTitleLbl) - Speed);
                    Canvas.SetLeft(Cs, Canvas.GetLeft(Cs) - Speed);
                    Canvas.SetLeft(CSharpImg, Canvas.GetLeft(CSharpImg) - Speed);
                    Canvas.SetLeft(lblCS, Canvas.GetLeft(lblCS) - Speed);
                }
            }
            if (!ShiledB)
            {
                Speed = 6;
                if (animate == 0)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/1.png"));
                else if (animate == 5)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/2.png"));
                else if (animate == 10)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/3.png"));
                else if (animate == 15)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/4.png"));
                else if (animate == 20)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/5.png"));
                else if (animate == 25)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/6.png"));
                else if (animate == 30)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/7.png"));
                else if (animate == 35)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/8.png"));
                else if (animate == 40)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/9.png"));
                else if (animate == 45)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/10.png"));
                else if (animate == 50)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/11.png"));
                else if (animate == 55)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/12.png"));
                else if (animate == 60)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/13.png"));
                else if (animate == 65)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/14.png"));
                else if (animate == 70)
                {
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Left/15.png"));
                    animate = 0;
                }
                animate++;
            }
            else
            {
                ScaleTransform scaleTransform1 = new ScaleTransform(-1, 1, 1, 1);
                Shiled.RenderTransform = scaleTransform1;
                Speed = 3;
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/‏‏ShiledPosL.png"));
                Canvas.SetLeft(Shiled, Canvas.GetLeft(Margalit) - 20);
                Canvas.SetTop(Shiled, Canvas.GetTop(Margalit));
                Shiled.Visibility = Visibility.Visible;
            }
        }

        private void RightTimer_Tick(object sender, EventArgs e)
        {
            if (BoundRight == false)
            {

                if (Canvas.GetLeft(Margalit) < 15675)
                    Canvas.SetLeft(Margalit, Canvas.GetLeft(Margalit) + Speed);
                if (Canvas.GetLeft(Margalit) > 900 + Canvas.GetLeft(Gridi) && Canvas.GetLeft(Gridi) > -14000)
                {
                    Canvas.SetLeft(Gridi, Canvas.GetLeft(Gridi) - Speed);
                    Canvas.SetLeft(liveLbl, Canvas.GetLeft(liveLbl) + Speed);
                    Canvas.SetLeft(liveTitleLbl, Canvas.GetLeft(liveTitleLbl) + Speed);
                    Canvas.SetLeft(Cs, Canvas.GetLeft(Cs) + Speed);
                    Canvas.SetLeft(CSharpImg, Canvas.GetLeft(CSharpImg) + Speed);
                    Canvas.SetLeft(lblCS, Canvas.GetLeft(lblCS) + Speed);
                }
            }


            if (!ShiledB)
            {
                Speed = 6;
                if (animate == 0)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/1.png"));
                else if (animate == 5)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/2.png"));
                else if (animate == 10)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/3.png"));
                else if (animate == 15)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/4.png"));
                else if (animate == 20)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/5.png"));
                else if (animate == 25)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/6.png"));
                else if (animate == 30)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/7.png"));
                else if (animate == 35)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/8.png"));
                else if (animate == 40)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/9.png"));
                else if (animate == 45)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/10.png"));
                else if (animate == 50)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/11.png"));
                else if (animate == 55)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/12.png"));
                else if (animate == 60)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/13.png"));
                else if (animate == 65)
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/14.png"));
                else if (animate == 70)
                {
                    Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/15.png"));
                    animate = 0;
                }
                animate++;
            }
            else
            {
                ScaleTransform scaleTransform1 = new ScaleTransform(1, 1, 1, 1);
                Shiled.RenderTransform = scaleTransform1;
                Speed = 3;
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/ShiledPosR.png"));
                Canvas.SetLeft(Shiled, Canvas.GetLeft(Margalit) + 176);
                Canvas.SetTop(Shiled, Canvas.GetTop(Margalit));
                Shiled.Visibility = Visibility.Visible;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
                RightTimer.Start();
            else if (e.Key == Key.Left)
                LeftTimer.Start();
            else if (e.Key == Key.Space)
            {
                if (JumpTimer.IsEnabled == false && (BoundDownToDown == true || OnFloor || Canvas.GetTop(Margalit) == 712))
                {
                    if (PointCurrect != 0)
                        Canvas.SetTop(Margalit, PointCurrect - Margalit.Height);
                    jump = 10;
                    JumpTimer.Start();
                }

            }
            else if (e.Key == Key.Escape)
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else if (e.Key == Key.K)
                dead();
            else if (e.Key == Key.X)
            {
                ShiledB = true;
            }
            
            if (e.Key == Key.C && MoveC == 0)
            {
                if (Cammo > 0)
                {
                    MoveC = 1;
                    Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit) + 150);
                    Canvas.SetTop(CShoot, Canvas.GetTop(Margalit) + 18);
                    Cammo--;
                }
            }
            else if (e.Key == Key.Z && MoveC == 0)
            {
                if (Cammo > 0)
                {
                    MoveC = 2;
                    Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit));
                    Canvas.SetTop(CShoot, Canvas.GetTop(Margalit) + 18);

                    Cammo--;
                }
            }
            else if (e.Key == Key.R || e.Key == Key.V)
            {
                if (Cammo > 0)
                {
                    MoveC = 0;
                    Canvas.SetLeft(CShoot, Canvas.GetLeft(Margalit) + 150);
                    Canvas.SetTop(CShoot, Canvas.GetTop(Margalit) + 18);
                    CShoot.Visibility = Visibility.Hidden;
                }
            }
        }
        int Cammo = 8;
        int MoveC = 0;
        public void dead()
        {
       

            Canvas.SetLeft(Margalit, 0);
            Canvas.SetTop(Margalit, 712);
            Canvas.SetLeft(Gridi, -12);
            Canvas.SetLeft(liveLbl, 175);
            Canvas.SetLeft(liveTitleLbl, 5);
            Canvas.SetLeft(Cs, 555);
            Canvas.SetLeft(CSharpImg, 435);
            Canvas.SetLeft(lblCS, 525);

            BoundDown = false;
            BoundDownToDown = false;

            jump = 10;
            Cammo = 8;
            PointCurrect = 0;

            PhysicTimer.Stop();
            JumpTimer.Stop();

            E[0] = Bad1;
            E[1] = Bad2;
            E[2] = Bad3;
            E[3] = Bad4;
            E[4] = Bad5;
            E[5] = Bad6;
            E[6] = Bad7;

            Q[0] = Q1;
            Q[1] = Q2;
            Q[2] = Q3;
            Q[3] = Q4;
            Q[4] = Q5;
            Q[5] = Q6;
            Q[6] = Q7;
            Q[7] = Q8;
            Q[8] = Q9;
            Q[9] = Q10;
            Q[10] = Q11;
            Q[11] = Q12;
            Q[12] = Q13;
            Q[13] = Q14;

            W[0] = W1;
            W[1] = W2;
            W[2] = W3;
            W[3] = W4;
            W[4] = W5;
            W[5] = W6;
            W[6] = W7;
            W[7] = W8;
            W[8] = W9;
            W[9] = W10;
            W[10] = W11;
            W[11] = W12;
            W[12] = W13;
            W[13] = W14;
            W[14] = W15;
            W[15] = W16;
            W[16] = W17;
            W[17] = W18;
            W[18] = W19;
            W[19] = W20;
            W[20] = W21;
            W[21] = W22;
            W[22] = W23;
            W[23] = W24;
            W[24] = W25;
            W[25] = W26;
            W[26] = W27;

            Qopen = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Bounds = new Image[] { P1,P2,P3,P4,P5,P6,
                Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, Q12, Q13, Q14,
                W1, W2, W3, W4, W5, W6, W7, W8, W9, W10, W11, W12, W13, W14, W15, W16, W17, W18, W19, W20, W21, W22, W23, W24, W25, W26, W27,
                Brick11,Brick12,Brick13,Brick14,Brick21,Brick22,Brick23,Brick24,Brick31,Brick32,Brick33,Brick34,Brick41,Brick42,Brick43,Brick44,Brick51,Brick52,Brick53,Brick54,Brick55,Brick56,Brick57,Brick58};

            for (int i = 0; i < Qlen; i++)
            {
                Q[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Ques.png"));
                Q[i].Height = 78;

               if (i != 1 && i != 5 && i != 10 && i != 11 && i != 12)
                   Canvas.SetTop(Q[i], 617);
               else
                   Canvas.SetTop(Q[i], 308);

            }
            for (int i = 0; i < Wlen; i++)
            {
                if(i == 1)
                   W[i].Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Wall.png"));

                W[i].Visibility = Visibility.Visible;
                W[i].IsEnabled = true;
            }
            for (int i = 0; i < Elen; i++)
            {
                E[i].Visibility = Visibility.Visible;
                E[i].IsEnabled = true;
            }
            live--;
            PhysicTimer.Start();
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
                RightTimer.Stop();
            else if (e.Key == Key.Left)
                LeftTimer.Stop();
            else if (e.Key == Key.X)
            {
                Margalit.Source = new BitmapImage(new Uri(@"pack://application:,,,/image/Journey/Right/1.png"));
                ShiledB = false;
                Shiled.Visibility = Visibility.Hidden;
                Canvas.SetTop(Shiled, 0);
            }
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Journey1.Stop();
            Journey1.Play();
        }
    }
}
