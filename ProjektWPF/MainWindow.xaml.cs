using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }


        

        private void Button_Click(object sender, RoutedEventArgs e)
        {




            try
            {
                string wyjazd, przyjazd, czas, miejscowosc, miejscowoscW, miejscowoscP;


                wyjazd = wyjazdZ.Text;
                przyjazd = przyjazdDo.Text;


                //string path = @"rozklad_jazdy.txt";
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dane", "rozklad_jazdy.txt");
                
                //string dataW = data.Text;

                int czasInt, godzinaInt, minutaInt, czasUser;


                List<string> znalezionePolaczenia = new List<string>();

                if (File.Exists(path))
                {
                    string[] dane = File.ReadAllLines(path);

                    foreach (string polaczenie in dane)
                    {
                        int kropka = polaczenie.IndexOf(".");
                        int nowaLinia = polaczenie.IndexOf('\n');

                        czas = polaczenie.Substring(0, kropka);
                        miejscowosc = polaczenie.Substring(kropka);
                        miejscowoscW = polaczenie.Substring(kropka, 15);
                        miejscowoscP = polaczenie.Substring(kropka);

                        czasInt = Int32.Parse(czas);

                        string godzina = godzinaPobranaText.Text;
                        string minuta = minutaPobranaText.Text;

                        godzinaInt = Int32.Parse(godzina);
                        minutaInt = Int32.Parse(minuta);

                        if (minutaInt == 0)
                        {
                            minutaInt = Int32.Parse(minutaInt.ToString() + 10);
                        }

                        czasUser = int.Parse(godzinaInt.ToString() + minutaInt.ToString());


                        if (czasInt >= czasUser && miejscowoscW.Contains(wyjazd) && miejscowoscP.Contains(przyjazd))
                        {
                            int indexPrzyjazd = miejscowoscP.IndexOf(przyjazd);
                            miejscowoscW = miejscowoscP.Substring(0, indexPrzyjazd + przyjazd.Length + 5);
                            miejscowoscP = miejscowoscP.Substring(0, indexPrzyjazd + przyjazd.Length + 5);
                            miejscowosc = miejscowoscW + miejscowoscP;
                            znalezionePolaczenia.Add(czas + miejscowosc);
                        }
                    }

                    if (znalezionePolaczenia.Count > 0)
                    {
                        // WYSWIETLANIE POLACZENIA W NOWYM OKNIEs
                        PolaczeniaWindow polaczeniaokno = new PolaczeniaWindow(znalezionePolaczenia);
                        polaczeniaokno.polaczeniaList = znalezionePolaczenia;
                        polaczeniaokno.Show();

                    }
                    else
                    {
                        MessageBox.Show("Brak połączenia!");
                    }
                }
                else
                {
                    MessageBox.Show("Plik nie istnieje");

                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nie znaleziono sciezki!");
            }


            //MessageBox.Show(wyjazd);

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tempPierwsza = wyjazdZ.Text;
            string tempDruga = przyjazdDo.Text;

            wyjazdZ.Text = tempDruga;
            przyjazdDo.Text = tempPierwsza;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           

            RozkladWindow rozklad = new RozkladWindow();
            rozklad.Show();

           
        }

        //private void Next(int lines, List<string> znalezionePolaczenia, int currentline)
        //{
        //    if(znalezionePolaczenia.Count > 0)
        //    {
        //        RozkladWindow.rozkladjazdyWyswietl.Text = dane[i];
        //    }
        //    if (this.customers.Count - 1 > this.currentCustomer)
        //    {
        //        this.currentCustomer++;
        //        this.OnPropertyChanged("Current");
        //        this.IsAtStart = false;
        //        this.IsAtEnd = (this.customers.Count - 1 == this.currentCustomer);
        //    }
        //}
        //private void Previous(int lines)
        //{
        //    if (this.currentCustomer > 0)
        //    {
        //        this.currentCustomer--;
        //        this.OnPropertyChanged("Current");
        //        this.IsAtEnd = false;
        //        this.IsAtStart = (this.currentCustomer == 0);
        //    }
        //}

        private void wyjazd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
