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

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy PolaczeniaWindow.xaml
    /// </summary>
    
    public partial class PolaczeniaWindow : Window
    {
        private int currentLine = 0;
        public List<string> polaczeniaList { get; set; }
        public PolaczeniaWindow(List<string> polaczeniaList)
        {
            InitializeComponent();

            
            if (polaczeniaList != null)
            {
                polaczenieWysietlTextBlock.Text = polaczeniaList[currentLine];
            }
            
        }
        
        private void Nastepne_Click(object sender, RoutedEventArgs e)
        {
            if (currentLine < polaczeniaList.Count - 1)
            {
                currentLine++;
                polaczenieWysietlTextBlock.Text = polaczeniaList[currentLine];
            }
        }

        private void Poprzednie_Click(object sender, RoutedEventArgs e)
        {
            if (currentLine > 0)
            {
                currentLine--;
                polaczenieWysietlTextBlock.Text = polaczeniaList[currentLine];
            }
        }
    }
}
