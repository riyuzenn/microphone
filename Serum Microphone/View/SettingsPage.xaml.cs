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
            //MessageBox.Show($"{Properties.Settings.Default.discord_presence}");
            if (Properties.Settings.Default.discord_presence)
            {
                SwitchPresence.IsOn = true;
            }
            else if (Properties.Settings.Default.discord_presence == false)
            {
                SwitchPresence.IsOn = false;
            }
        }

        private void ChangeDiscordPresenceSettings(bool value)
        {
          
            Properties.Settings.Default.discord_presence = value;
            Properties.Settings.Default.Save();
        }

       
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

            if (SwitchPresence.IsOn == true)
            {
                ChangeDiscordPresenceSettings(true);
            }
            else
            {
                ChangeDiscordPresenceSettings(false);
            }

            

        }
    }
}
