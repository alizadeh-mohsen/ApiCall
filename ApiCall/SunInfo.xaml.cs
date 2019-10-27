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
using HelperLibrary;

namespace ApiCall
{
    /// <summary>
    /// Interaction logic for SunInfo.xaml
    /// </summary>
    public partial class SunInfo : Window
    {
        public SunInfo()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, RoutedEventArgs e)
        {
            LoadSunInfo();
        }

        private async void LoadSunInfo()
        {
            SunHelper sunHelper = new SunHelper();
            var sunModel = await sunHelper.LoadSunInfo(36.7201600, 4.4203400);
            if (sunModel.Status.ToLower().Equals("ok"))
            {
                lblResult.Content = $"sunrise is { sunModel.Results.Sunrise.ToLocalTime().ToShortTimeString()}";
                lblResult.Content += "\n" + $"sunset is {sunModel.Results.Sunset.ToLocalTime().ToShortTimeString()}";
            }
        }
    }
}
