﻿using System;
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
using ModernWpf.Controls;
using System.Net;

namespace Serum_Microphone.Dialog
{
    /// <summary>
    /// Interaction logic for UpdateDialog.xaml
    /// </summary>
    public partial class UpdateDialog : ContentDialog
    {
        public UpdateDialog()
        {

            InitializeComponent();

            WebClient webClient = new WebClient();
            string _version = webClient.DownloadString("https://raw.githubusercontent.com/serumstudio/microphone/main/version.txt");
            ChangeVersion($"New Update is out now v{_version}");
        }

        private void ChangeVersion(string text)
        {
            ver.Text = text;
        }
    }
}
