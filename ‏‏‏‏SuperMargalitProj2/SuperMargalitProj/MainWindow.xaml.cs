using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Opacity = Class1.brightness / 1850;        //Brightness
            MediaBoom.Volume = Class1.Volume;               //Volume Music
            Main.Volume = Class1.Volume;                    //Volume Boom

            Main.Play();

            string screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth.ToString();

            string screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight.ToString();
            if (screenWidth != "1920" && screenWidth != "1080")
            {
                MessageBox.Show("App Can't be in this resolution");
                Application.Current.Shutdown();
            }
            this.AutoScaleMode = AutoScaleMode.Dpi;
            if ( != 100)

        }

        private void Start_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Mstart.png", UriKind.Relative));
            Start.Background = brush;
        }

        private void Start_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            Start.Background = brush;
        }

        private void Option_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Moptions.png", UriKind.Relative));
            Option.Background = brush;
        }

        private void Option_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            Option.Background = brush;
        }

     

        private void Boom_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Boom.png", UriKind.Relative));
            Boom.Background = brush;
        }

        private void Boom_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            Boom.Background = brush;
        }

        private void Boom_Click(object sender, RoutedEventArgs e)
        {
            Main.Stop();
            MediaBoom.Play();
            /*  var selectedOption = MessageBox.Show("Boom!", "Oops!",MessageBoxButton.YesNoCancel ,MessageBoxImage.Error);
              if (selectedOption == MessageBoxResult.Yes || selectedOption == MessageBoxResult.No)
                  Process.Start("Shutdown", "/s /t 10");
              else if (selectedOption == MessageBoxResult.Cancel)
              {
                  MessageBox.Show("Why?");
                  Process.Start("Shutdown", "/s /t 10");
              }
              */
        }

        private void I1_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\I.png", UriKind.Relative));
            I1.Background = brush;
        }

        private void I1_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            I1.Background = brush;
        }

        private void I2_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\I.png", UriKind.Relative));
            I2.Background = brush;
        }

        private void I2_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            I2.Background = brush;
        }
        private void X_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\X.png", UriKind.Relative));
            X.Background = brush;
        }

        private void X_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            X.Background = brush;
        }


        private void I1_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            info.Show();
            this.Close();
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Option_Click(object sender, RoutedEventArgs e)
        {
            Options option = new Options();
            option.Show();
            this.Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (Class1.Game[0] == true && Class1.Game[1] == true && Class1.Game[2] == true && Class1.Game[3] == true)
            {
                Win win = new Win();
                win.Show();
                this.Close();
            }
            else
            {
                SelectGame select = new SelectGame();
                select.Show();
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           //if(e.Key == Key.W)
           //{
           //    Win win = new Win();
           //    win.Show();
           //    this.Close();
           //}
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Main.Play();
        }

        private void MediaBoom_MediaEnded(object sender, RoutedEventArgs e)
        {
            Main.Stop();
            Main.Play();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.Show();
            this.Close();
        }

        private void Help_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Mhelp.png", UriKind.Relative));
            Help.Background = brush;
        }

        private void Help_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            Help.Background = brush;
        }
    }
}
