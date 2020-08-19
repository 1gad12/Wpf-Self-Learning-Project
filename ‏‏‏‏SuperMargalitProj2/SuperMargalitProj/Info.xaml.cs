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
using System.Windows.Shapes;

namespace SuperMargalitProj
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            this.Opacity = Class1.brightness / 1850;         //Brightness
            Info1.Volume = Class1.Volume;                    //Volume Music
            Info1.Play();                                    //Play Music
        }

        private void Back_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();                                                                 //Button Back Image
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\BackI.png", UriKind.Relative));     //Button Back Image       
            Back.Background = brush;                                                                      //Button Back Image
        }

        private void Back_MouseLeave(object sender, MouseEventArgs e)                                     //Button Back Image
        {                                                                                                 //Button Back Image
            var brush = new ImageBrush();                                                                 //Button Back Image
            brush.ImageSource = null;                                                                     //Button Back Image
            Back.Background = brush;                                                                      //Button Back Image
        }

        private void Back_Click(object sender, RoutedEventArgs e)                                         //Back To MainMenu
        {                                                                                                 //Back To MainMenu
            MainWindow main = new MainWindow();                                                           //Back To MainMenu
            main.Show();                                                                                  //Back To MainMenu
            this.Close();                                                                                 //Back To MainMenu
        }                                                                                                 //Back To MainMenu

        private void media_MediaEnded(object sender, RoutedEventArgs e)                                   //ReStart The Music
        {                                                                                                 //ReStart The Music
            Info1.Stop();                                                                                 //ReStart The Music
            Info1.Play();                                                                                 //ReStart The Music
        }                                                                                                 //ReStart The Music
    }                                                                                                     
}
