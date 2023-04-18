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
using System.IO;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy DodajWindow.xaml
    /// </summary>
    public partial class DodajWindow : Window
    {
        public DodajWindow()
        {
            InitializeComponent();
        }

        private void DodajNowePolaczenie(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dane", "rozklad_jazdy.txt");


            string nowePolaczenieRazem = godzinaWyjazdu.Text + nowePolaczenie.Text;

            File.AppendAllText(path, nowePolaczenieRazem + Environment.NewLine);

            


        }
    }
}
