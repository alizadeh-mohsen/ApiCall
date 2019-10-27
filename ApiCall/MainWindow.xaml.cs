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
using HelperLibrary;

namespace ApiCall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentComicNumber = 0;
        private int MaxComicNumber = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            await LoadImage(currentComicNumber - 1);
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            await LoadImage(currentComicNumber + 1);
        }

        private void btnSunInfo_Click(object sender, RoutedEventArgs e)
        {
            SunInfo sunInfo=new SunInfo();
            sunInfo.Show();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {


            await LoadImage();

        }

        private async Task LoadImage(int comicNumber = 0)
        {
            lblLoading.Content = "loading image....";
            btnNext.IsEnabled = true;
            ComicHelper comicHelper = new ComicHelper();

            var comic = await comicHelper.LoadComicImage(comicNumber);

            lblLoading.Content = "";

            if (comicNumber == 0 || comicNumber == MaxComicNumber)
            {
                MaxComicNumber = comic.Num;
                btnNext.IsEnabled = false;
            }
            currentComicNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource);

        }
    }
}
