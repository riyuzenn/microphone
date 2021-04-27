using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Serum_Microphone.View;
using ModernWpf.Controls;
using System.Net;
using Serum_Microphone.Dialog;
using System.Deployment.Application;
using System.Reflection;
using DiscordRPC;

namespace Serum_Microphone
{
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DiscordRP rp = new DiscordRP();
            rp.Initialize();
            
        }

        private Version GetVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        private async void CheckForUpdate()
        {
            try
            {
                WebClient webClient = new WebClient();

                

                string _version = webClient.DownloadString("https://drive.google.com/uc?export=download&id=1a1PKfAfUl_6jUUAZrii-8pDkuOUJyTrp");
                var version = GetVersion();

                // mainWindow.Title = $"Serum Microphone - {version.ToString()}";

                if (version.ToString() == _version)
                {
                    
                }
                else if (version.ToString() != _version)
                {
                    UpdateDialog dialog = new UpdateDialog();
                    await dialog.ShowAsync();
                }
                

            }
            catch (Exception ex)
            {

            }
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(PlayerView));
            
        }

        private void NavigationView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

         
            switch (item.Tag.ToString())
            {
                case "playerview":
                    ContentFrame.Navigate(typeof(PlayerView));
                    break;

                case "aboutview":
                    ContentFrame.Navigate(typeof(AboutView));
                    break;

                    
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckForUpdate();
        }
    }
}
