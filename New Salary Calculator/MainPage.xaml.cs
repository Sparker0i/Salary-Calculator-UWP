using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sample.Data
{
    /*class TableFiller : ObservableCollection<TableData>
    {
        public TableFiller()
        {
            this.Add(new TableData()
            {
                UserName = "user1",
                FirstName = "FN1",
                LastName = "LN1",
                Email = "user1@nowhere.local"
            });

            this.Add(new TableData()
            {
                UserName = "user2",
                FirstName = "FN2",
                LastName = "LN2",
                Email = "user2@nowhere.local"
            });

            this.Add(new TableData()
            {
                UserName = "user3",
                FirstName = "FN3",
                LastName = "LN3",
                Email = "user3@nowhere.local"
            });
        }
    }*/

    
}

namespace New_Salary_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    
    public class TableData
    {
        public Double Basic { get; set; }
        public Double Fbp { get; set; }
        public Double Inh { get; set; }
        public Double Ars { get; set; }
        public Double Cur { get; set; }

        public TableData(Double basic , Double fbp , Double inh , Double ars , Double cur)
        {
            Basic = basic;
            Fbp = fbp;
            Inh = inh;
            Ars = ars;
            Cur = cur;
        }
    }

    public sealed partial class MainPage : Page
    {
        private ObservableCollection<TableData> Data;
        public MainPage()
        {
            this.InitializeComponent();
            Data = new ObservableCollection<TableData>();
            dataGrid.ItemsSource = Data;
        }

        private void calculate_click(object sender, RoutedEventArgs e)
        {
            int years = Convert.ToInt32(yearInput.Text) - 1;
            for (int i = 1; i <= years; ++i)
            {
                double pow = Math.Pow(1.09, years);
                double basic = Math.Round(Convert.ToDouble(basicInput.Text) * pow),
                    fbp = Math.Round(basic * Convert.ToDouble(fbpInput.Text) / 100),
                    pf = Math.Round(basic * Convert.ToDouble(pfInput.Text) / 100),
                    grat = Math.Round(basic * Convert.ToDouble(gratInput.Text) / 100);

                double inh = Math.Floor(basic + fbp), ars = Math.Round(fbp + basic + pf + grat);

                double rent = Math.Round(Convert.ToDouble(rentInput.Text) * 12),
                    food = Math.Round(Convert.ToDouble(foodInput.Text) * pow),
                    investments = Math.Round(Convert.ToDouble(investmentsInput.Text) * pow),
                    ins = 100000;

                Double cur = inh - rent - food - investments - ins;
                Data.Add(new TableData(basic, fbp, inh, ars, cur));
            }
        }
    }
}
