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
           
            
        }

        private void ChangeDiscordPresenceSettings(bool value)
        {
          
            Properties.Settings.Default.discord_presence = value;
            Properties.Settings.Default.Save();
        }

        private void ChangeVoiceAgeSettings(int value)
        {

            Properties.Settings.Default.voice_age = value;
            Properties.Settings.Default.Save();
        }

        private void ChangeVoiceGenderSettings(int value)
        {

            Properties.Settings.Default.voice_gender = value;
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

        private void voiceAgeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            ChangeVoiceAgeSettings(index);
        }

        private void voiceAgeComboBox_Initialized(object sender, EventArgs e)
        {

            voiceAgeComboBox.SelectedIndex = Properties.Settings.Default.voice_age;
        }

        private void SwitchPresence_Initialized(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.discord_presence)
            {
                SwitchPresence.IsOn = true;
            }
            else if (Properties.Settings.Default.discord_presence == false)
            {
                SwitchPresence.IsOn = false;
            }
        }

        private void voiceGenderComboBox_Initialized(object sender, EventArgs e)
        {
            voiceGenderComboBox.SelectedIndex = Properties.Settings.Default.voice_gender;
        }

        private void voiceGenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (sender as ComboBox).SelectedIndex;
            ChangeVoiceGenderSettings(index);
        }
    }
}
