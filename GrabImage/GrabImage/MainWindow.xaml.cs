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

namespace GrabImage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object[] clearElemnts = new object[100];
        bool elementTest=false;
        int k = 0;
        int[] pointsX;
        int[] pointsY;
        object link;
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private void right_MouseMove(object sender, MouseEventArgs e)
        {
          //  if(e.LeftButton == MouseButtonState.Pressed)
           // {
                Image img = (Image)sender;
                DragDrop.DoDragDrop(img, new DataObject(DataFormats.Serializable, img), DragDropEffects.Move);
        //    }
        }

        private void screen_Drop(object sender, DragEventArgs e)
        {
          object  data = e.Data.GetData(DataFormats.Serializable);

            if(data is UIElement element)
            {
                Point dropPoint = e.GetPosition(screen);
                Canvas.SetLeft(element, dropPoint.X);
                Canvas.SetTop(element, dropPoint.Y);
                warpP.Children.Remove(element);
                screen.Children.Remove(element);
                screen.Children.Add(element);
                for (int i = 0; i < clearElemnts.Length; i++)
                {
                    if(clearElemnts[i]!=element)
                     elementTest=true; 
                    else
                    {
                     elementTest=false;
                        break;
                    }
                }
                if(elementTest)
                {
                    clearElemnts[k] = element;
                    k++;
                }
            }
        }

        private void warp_DragLeave(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is UIElement element)
            {
                warpP.Children.Remove(element);
            }
        }

        private void left_MouseMove(object sender, MouseEventArgs e)
        {
          if (e.LeftButton == MouseButtonState.Pressed)
          {
             Image img = (Image)sender;
             DragDrop.DoDragDrop(img, new DataObject(DataFormats.Serializable, img), DragDropEffects.Move);
          }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(clearElemnts!=null)
            {
                for (int i = 0; i < clearElemnts.Length; i++)
                {
                    if (clearElemnts[i] is UIElement element)
                    {
                      link=element;
                        traval();
                    }
                }
            }    
        }
        private void traval()
        {
            if (link is UIElement element)
            {
                Canvas.SetLeft(element, 0);
                Canvas.SetTop(element, 0);
                screen.Children.Remove(element);
                warpP.Children.Add(element);
            }
        }

        private void select(object sender, SelectionChangedEventArgs e)
        {
            switch(Shops.SelectedIndex)
            {
                case 0:
                    image1.Visibility = Visibility.Visible;
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Hidden;
                    image4.Visibility = Visibility.Hidden;
                    image5.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    image1.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Visible;
                    image3.Visibility = Visibility.Hidden;
                    image4.Visibility = Visibility.Hidden;
                    image5.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    image1.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Visible;
                    image4.Visibility = Visibility.Hidden;
                    image5.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    image1.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Hidden;
                    image4.Visibility = Visibility.Visible;
                    image5.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    image1.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Hidden;
                    image4.Visibility = Visibility.Hidden;
                    image5.Visibility = Visibility.Visible;
                    break;

                default:
                    image1.Visibility = Visibility.Hidden;
                    image2.Visibility = Visibility.Hidden;
                    image3.Visibility = Visibility.Hidden;
                    image4.Visibility = Visibility.Hidden;
                    image5.Visibility = Visibility.Hidden;
                    break;
                    
            }
        }

    }
}
