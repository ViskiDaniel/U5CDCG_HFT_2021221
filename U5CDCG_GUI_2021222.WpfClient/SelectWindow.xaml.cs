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

namespace U5CDCG_GUI_2021222.WpfClient
{
    /// <summary>
    /// Interaction logic for SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        public SelectWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Visibility = Visibility.Visible;
            mw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerWindow cw = new CustomerWindow();
            this.Visibility = Visibility.Visible;
            cw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LibraryWindow lw = new LibraryWindow();
            this.Visibility = Visibility.Visible;
            lw.Show();
        }
    }
}
