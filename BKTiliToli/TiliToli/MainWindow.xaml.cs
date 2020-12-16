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

namespace TiliToli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Üdvözöllek! Az ablak bezárása után keverj, majd játssz!", "Tologatós játék");
        }
        int[] allas = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        int[] kesz = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        int lepesek = 0;
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button ezGomb = sender as Button;
            Button nullaGomb = (Button)FindName("Button0");
            
            var fTav = Math.Abs(ezGomb.Margin.Top - nullaGomb.Margin.Top);
            var vTav = Math.Abs(ezGomb.Margin.Left - nullaGomb.Margin.Left);

            //A tömbben elfoglalt pozició
            int ezGombFelirat = int.Parse(ezGomb.Content.ToString());
            int ezGombIndex = Array.IndexOf(allas, ezGombFelirat);
            int nullaGombIndex = Array.IndexOf(allas, 0);

            if ((fTav == 100 && vTav == 0) || (vTav == 100 && fTav == 0)) {
                var seged = ezGomb.Margin;
                ezGomb.Margin = nullaGomb.Margin;
                nullaGomb.Margin = seged;

                allas[nullaGombIndex] = allas[ezGombIndex];
                allas[ezGombIndex] = 0;

                lepesek++;
                lepesekmw.Content = lepesek;

                //Mikor lesz vége?
                if (allas.SequenceEqual(kesz))
                {
                    //Mit csináljon ha kész
                    MessageBoxResult result = MessageBox.Show("Sikerült megoldanod a kirakóst, gratulálok! " + lepesek + " lépésbe telt. Akar újat játszani?", "Siker!", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        lepesekmw.Content = 0;
                        lepesek = 0;
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }
                }
                
            }
        }

        private void keveres_Click(object sender, RoutedEventArgs e)
        {
            if (!allas.SequenceEqual(kesz))
            {
                   MessageBoxResult result = MessageBox.Show("Biztosan új játékot akarsz kezdeni?", "Új játék?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    lepesek = 0;
                    lepesekmw.Content = 0;
                    Random r = new Random();
                    int keveres1 = r.Next(60, 401);
                    for (int i = 0; i < keveres1;)
                    {
                        int valaszt = r.Next(1, 9);
                        Convert.ToString(valaszt);
                        Button gomb = (Button)FindName("Button" + valaszt);
                        Button nullagomb = (Button)FindName("Button0");
                        var fTav = Math.Abs(gomb.Margin.Top - nullagomb.Margin.Top);
                        var vTav = Math.Abs(gomb.Margin.Left - nullagomb.Margin.Left);

                        int gombfelirat = int.Parse(gomb.Content.ToString());
                        int gombIndex = Array.IndexOf(allas, gombfelirat);
                        int nullagombindex = Array.IndexOf(allas, 0);

                        if ((fTav == 100 && vTav == 0) || (fTav == 0 && vTav == 100))
                        {
                            var cserehez = gomb.Margin;
                            gomb.Margin = nullagomb.Margin;
                            nullagomb.Margin = cserehez;

                            allas[nullagombindex] = allas[gombIndex];
                            allas[gombIndex] = 0;
                            i++;
                        }
                    }
                }
            }
            else
            {
                lepesek = 0;
                lepesekmw.Content = 0;
                Random r = new Random();
                int keveres1 = r.Next(60, 401);
                for (int i = 0; i < keveres1;)
                {
                    int valaszt = r.Next(1, 9);
                    Convert.ToString(valaszt);
                    Button gomb = (Button)FindName("Button" + valaszt);
                    Button nullagomb = (Button)FindName("Button0");
                    var fTav = Math.Abs(gomb.Margin.Top - nullagomb.Margin.Top);
                    var vTav = Math.Abs(gomb.Margin.Left - nullagomb.Margin.Left);

                    int gombfelirat = int.Parse(gomb.Content.ToString());
                    int gombIndex = Array.IndexOf(allas, gombfelirat);
                    int nullagombindex = Array.IndexOf(allas, 0);

                    if ((fTav == 100 && vTav == 0) || (fTav == 0 && vTav == 100))
                    {
                        var cserehez = gomb.Margin;
                        gomb.Margin = nullagomb.Margin;
                        nullagomb.Margin = cserehez;

                        allas[nullagombindex] = allas[gombIndex];
                        allas[gombIndex] = 0;
                        i++;
                    }
                }
            }
        }
    }
}
