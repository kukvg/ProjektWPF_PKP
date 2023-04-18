using System;
using System.Collections.Generic;
using System.IO;
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

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy RozkladWindow.xaml
    /// </summary>
    public partial class RozkladWindow : Window
    {

        private int currentLine = 0;
        public RozkladWindow()
        {
            InitializeComponent();

            //string path = @"rozklad_jazdy.txt";

            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dane", "rozklad_jazdy.txt");

            string[] dane = File.ReadAllLines(path);


            if (dane.Length -1 > 0)     
            {
                rozkladjazdyWyswietl.Text = dane[currentLine];
            }
        }
       

        private void Nastepne_Click(object sender, RoutedEventArgs e)
        {

                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dane", "rozklad_jazdy.txt");

                string[] dane = File.ReadAllLines(path);
                
                
                if(currentLine < dane.Length -1)
                {
                    currentLine++;
                    rozkladjazdyWyswietl.Text = dane[currentLine];
               }
                

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dane", "rozklad_jazdy.txt");

            string[] dane = File.ReadAllLines(path);

            

            if (currentLine > 0)
            {
                currentLine--;
                rozkladjazdyWyswietl.Text = dane[currentLine];
            }

        }

        private void Dodajpolaczenie_Click(object sender, RoutedEventArgs e)
        {
            DodajWindow dodaj= new DodajWindow();
            dodaj.Show();
        }
    }
}
