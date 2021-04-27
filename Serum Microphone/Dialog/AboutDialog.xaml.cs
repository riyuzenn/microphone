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
using System.Deployment.Application;
using System.Reflection;
using ModernWpf.Controls;

namespace Serum_Microphone.Dialog
{
    /// <summary>
    /// Interaction logic for AboutDialog.xaml
    /// </summary>
 
    
    public partial class AboutDialog : ContentDialog
    {

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

        public AboutDialog()
        {
            InitializeComponent();
            versionText.Text = $"Version: {GetVersion().ToString()}";
        }
    }
}
