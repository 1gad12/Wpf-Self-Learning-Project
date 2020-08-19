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
using System.Windows.Threading;

namespace SuperMargalitProj
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        Control draggedItem;
        Point itemRelativePosition;
        bool IsDragging;

        private DispatcherTimer SelectorTimer;

        public Options()
        {
            InitializeComponent();

            this.Opacity = Class1.brightness / 1850;
            Canvas.SetLeft(Selector, Class1.brightness);

            Option.Volume = Class1.Volume;

            SelectorTimer = new DispatcherTimer();
            SelectorTimer.Interval = TimeSpan.FromMilliseconds(Convert.ToDouble(1));
            SelectorTimer.Tick += RenderingSelect;

            if (Class1.BVoice == false)                                                                                             //voice showing
            {                                                                                                       //voice showing
                var brush = new ImageBrush();                                                                       //voice showing
                brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Voice.png", UriKind.Relative));                 //voice showing
                Voice1.Background = brush;                                                                          //voice showing
                Class1.Volume = 1.0;                                                                                       //voice showing
            }                                                                                                       //voice showing
            else                                                                                                    //voice showing
            {                                                                                                       //voice showing
                var brush = new ImageBrush();                                                                       //voice showing
                brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Mute.png", UriKind.Relative));                  //voice showing
                Voice1.Background = brush;                                                                          //voice showing
                Class1.Volume = 0;                                                                                         //voice showing
            }
            Option.Play();

        }

        private void RenderingSelect(object sender, EventArgs e)
        {
            if (Canvas.GetLeft(Selector) >= 1850)
                Canvas.SetLeft(Selector, Canvas.GetLeft(Selector) + (1850 - Canvas.GetLeft(Selector)));

            if (Canvas.GetLeft(Selector) <= 975)
                Canvas.SetLeft(Selector, Canvas.GetLeft(Selector) + (975 - Canvas.GetLeft(Selector)));
        }

        private void Back_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Back.png", UriKind.Relative));
            Back.Background = brush;
        }

        private void Back_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new ImageBrush();
            brush.ImageSource = null;
            Back.Background = brush;
        }

        private void Voice_Click(object sender, RoutedEventArgs e)
        {
            if(Class1.BVoice)
            {
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Voice.png", UriKind.Relative));
                Voice1.Background = brush;
                Class1.BVoice = false;
                Class1.Volume = 1.0;
            }
            else
            {
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(@"image\Other\Mute.png", UriKind.Relative));
                Voice1.Background = brush;
                Class1.BVoice = true;
                Class1.Volume = 0;
            }
            Option.Volume = Class1.Volume;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Selector_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDragging)
                return;

            Point canvasRelativePosition = e.GetPosition(Gridi);
            if (Canvas.GetLeft(Selector) >= 975 && Canvas.GetLeft(Selector) <= 1850)
            {
                Canvas.SetLeft(draggedItem, canvasRelativePosition.X - itemRelativePosition.X);
                SelectorTimer.Stop();
                Class1.brightness = Canvas.GetLeft(Selector);
                this.Opacity = Class1.brightness / 1850;

            }
        }

        private void Selector_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsDragging = true;
            draggedItem = (Button)sender;
            itemRelativePosition = e.GetPosition(draggedItem);
        }

        private void Selector_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsDragging)
                return;

            SelectorTimer.Start();


            IsDragging = false;
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Option.Stop();
            Option.Play();
        }
    }
}
