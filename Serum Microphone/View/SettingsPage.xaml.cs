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

namespace Serum_Microphone.View
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            MessageBox.Show($"{Properties.Settings.Default.discord_presence}");
        }

        private void CreateSettings(bool value)
        {
            /* 
            var property = new System.Configuration.SettingsProperty("discord_presence");
            property.PropertyType = typeof(bool);
            property.DefaultValue = value;
            Properties.Settings.Default.Properties.Add(property);
            Properties.Settings.Default.Save(); 
            */

            Properties.Settings.Default.discord_presence = value;
        }

        /*
        private bool ReadRichPresence()
        {
            if (SwitchPresence.IsOn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ModernWpf.Controls.ToggleSwitch toggleSwitch = sender as ModernWpf.Controls.ToggleSwitch;
            DiscordRP rp = new DiscordRP();

            
            try
            {
                if (toggleSwitch != null)
                {
                    if (toggleSwitch.IsOn == true)
                    {
                        CreateSettings(true);
                        rp.Initialize();
                    }
                    else if (toggleSwitch.IsOn == false)
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                CreateSettings(false);
                rp.DeInitialize();
                //MessageBox.Show(ex.ToString());
            }
            
            
            


            //CreateSettings(ReadRichPresence());
            //MessageBox.Show($"{Properties.Settings.Default.discord_presence}");
        }
    }
}
