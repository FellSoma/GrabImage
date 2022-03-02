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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            DragDrop.DoDragDrop(img,img.Source, DragDropEffects.Copy);
        }

        private void Target_Drop(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
            //((Grid)sender).DataContext = (Image)e.Data.GetData(DataFormats.MetafilePicture);
        }

        private void txtTarget_Drop(object sender, DragEventArgs e)
        {
            ((Image)sender).Source = (Decoder)e.Data.GetData(DataFormats.);
          //  e.Effects = DragDropEffects.Copy;
          //  e.Handled = true;
        }
    }
}
