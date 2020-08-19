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
    /// Interaction logic for Finish.xaml
    /// </summary>
    public partial class Finish : Window
    {
        public Finish()
        {
            InitializeComponent();
            this.Opacity = Class1.brightness / 1850;                       //Brightness
            MediaFinish.Volume = Class1.Volume;                            //Volume Movie
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)    //Media End - Close Project
        {                                                                  //Media End - Close Project
            Application.Current.Shutdown();                                //Media End - Close Project
        }                                                                  //Media End - Close Project

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)                                        //IF ShutDown ESC
                Application.Current.Shutdown();                            //IF ShutDown ESC
    }
    }
}
