using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMargalitProj
{
    /// <summary>
    /// Interaction logic for SelectGame.xaml
    /// </summary>
    public partial class SelectGame : Window
    {
        public SelectGame()
        {
            InitializeComponent();
            this.Opacity = Class1.brightness / 1850;

            if (Class1.Game[0] == true)
            {
                DoneJ1.Visibility = Visibility.Visible;
                Journey.IsEnabled = false;
            }
            if (Class1.Game[1] == true)
            {
                DoneJ2.Visibility = Visibility.Visible;
                Margabot.IsEnabled = false;
            }
            if (Class1.Game[2] == true)
            {
                DoneJ3.Visibility = Visibility.Visible;
                TolyBot.IsEnabled = false;
            }
            if (Class1.Game[3] == true)
            {
                DoneJ4.Visibility = Visibility.Visible;
                Collaboration.IsEnabled = false;
            }
            Wait.Play();

            Wait.Volume = Class1.Volume;


        }

        private void Journey_MouseEnter(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/Journey.png", UriKind.Relative));

        }

        private void Journey_MouseLeave(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/SelectGame.png", UriKind.Relative));

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/TolyBorg.png", UriKind.Relative));

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/SelectGame.png", UriKind.Relative));

        }

        private void Margabot_MouseEnter(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/Margabot.png", UriKind.Relative));

        }

        private void Margabot_MouseLeave(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/SelectGame.png", UriKind.Relative));

        }

        private void TolyBot_MouseEnter(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/TolyBot.png", UriKind.Relative));

        }

        private void TolyBot_MouseLeave(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/SelectGame.png", UriKind.Relative));

        }

        private void TolyBot_Copy_MouseEnter(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/Collaboration.png", UriKind.Relative));

        }

        private void TolyBot_Copy_MouseLeave(object sender, MouseEventArgs e)
        {
            Gridi.ImageSource = new BitmapImage(new Uri(@"image/Other/SelectGame.png", UriKind.Relative));

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Journey_Click(object sender, RoutedEventArgs e)
        {
            Journey j = new Journey();
            j.Show();                             //Go To Journey
            this.Close();                         //Window Close
        }

        private void TolyBot_Click(object sender, RoutedEventArgs e)
        {
            Class1.Bots = true;                   //TolyBot
            Cyborg cyborg = new Cyborg();
            cyborg.Show();                        //Go To Game
            this.Close();                         //Close This Window
        }

        private void Margabot_Click(object sender, RoutedEventArgs e)
        {
            Class1.Bots = false;                        //MargaBot
            Cyborg cyborg = new Cyborg();
            cyborg.Show();                              //Go To Game
            this.Close();                               //Close This Window
        }

        private void Collaboration_Click(object sender, RoutedEventArgs e)
        {
            Collaboration coll = new Collaboration();                                                       
            coll.Show();                                                                                    //Go To Game
            this.Close();                                                                                   //Close This Window
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)                                     //Restart Music
        {                                                                                                   //Restart Music
            Wait.Stop();                                                                                    //Restart Music
            Wait.Play();                                                                                    //Restart Music
        }
    }
}
