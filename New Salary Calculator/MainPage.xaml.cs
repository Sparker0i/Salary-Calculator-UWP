using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace New_Salary_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            sender.Text = new String(sender.Text.Where(char.IsDigit).ToArray());
        }

        private void calculate_click(object sender, RoutedEventArgs e)
        {
            int years = Convert.ToInt32(yearInput.Text) - 1;
            Double pow = Math.Pow(1.09, years);
            Double basic = Math.Round(Convert.ToDouble(basicInput.Text) * pow),
                fbp = Math.Round(basic * Convert.ToDouble(fbpInput.Text) / 100),
                pf = Math.Round(basic * Convert.ToDouble(pfInput.Text) / 100),
                grat = Math.Round(basic * Convert.ToDouble(gratInput.Text) / 100);

            Double inh = Math.Floor(basic + fbp), ars = Math.Round(fbp + basic + pf + grat);

            Double rent = Math.Round(Convert.ToDouble(rentInput.Text) * 12),
                food = Math.Round(Convert.ToDouble(foodInput.Text) * pow),
                investments = Math.Round(Convert.ToDouble(investmentsInput.Text) * pow),
                ins = 100000;

            Double cur = inh - rent - food - investments - ins;
            inhandOutput.Text = Convert.ToString(Math.Round(cur));
            inhandMonthOutput.Text = Convert.ToString(Math.Round(cur/12));
            arsOutput.Text = Convert.ToString(ars);
        }
    }
}
