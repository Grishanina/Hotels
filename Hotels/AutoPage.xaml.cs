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

namespace Hotels
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
            listTour.ItemsSource = ClassBase.BD.Tour.ToList();
            listTour.Background = new SolidColorBrush(Color.FromRgb(186, 227, 232));
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);

            List<Tour> TP = ClassBase.BD.Tour.Where(x => x.Id == index).ToList();

            foreach (Tour prd in TP)
            {
                if (prd.IsActual == false)
                {
                    tb.Foreground = Brushes.Red;
                    tb.Text = "Не актуален";

                }
                else if (prd.IsActual == true)
                {
                    tb.Foreground = Brushes.Green;
                    tb.Text = "Актуален";
                }
            }

        }
    }
}
