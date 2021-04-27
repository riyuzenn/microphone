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
using Serum_Microphone.Dialog;

namespace Serum_Microphone.View
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : Page
    {
        public AboutView()
        {
            InitializeComponent();
            CopyrightNotice.Text = $"Copyright © 2020-{DateTime.Now.Year.ToString()}, Serum Studio. All rights reserved.";
        }

        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            await dialog.ShowAsync();
        }
    }
}
