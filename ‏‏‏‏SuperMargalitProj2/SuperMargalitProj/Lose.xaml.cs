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
    /// Interaction logic for Lose.xaml
    /// </summary>
    public partial class Lose : Window
    {
        public Lose()
        {
            InitializeComponent();
            this.Opacity = Class1.brightness / 1850;                        //Brightness
            Lose1.Volume = Class1.Volume;                                   //Volume Of Music
            Lose1.Play();                                                   //Music Play
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)                                       //If Esc Go Menu
            {                                                             
                MainWindow main = new MainWindow();                       
                main.Show();                                              //Go Menu
                this.Close();                                             //Close This Window
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();                          
            main.Show();                                                 //Go Menu
            this.Close();                                                //Close This Window
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Lose1.Stop();                                               //Restart Music
            Lose1.Play();                                               //Restart Music
        }
    }
}
