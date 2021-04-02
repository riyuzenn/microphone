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
using System.Text.RegularExpressions;
using CSCore.SoundOut;
using System.ComponentModel;
using System.IO;
using CSCore;
using CSCore.MediaFoundation;
using System.Speech.Synthesis;



namespace Serum_Microphone.View
{
    class PlayerSettings
    {
        public string text
        {
            get; set;
        }
        public int deviceId
        {
            get; set;
        }
        public int speakerId
        {
            get; set;
        }
        public bool is_playing
        {
            get; set;
        }
    }
    public partial class PlayerView : Page
    {

        PlayerSettings config = new PlayerSettings();

        public PlayerView()
        {
            InitializeComponent();
            

        }

        private void do_work(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker newWorker = new BackgroundWorker();
            newWorker.DoWork += do_new_work;

            using (var stream = new MemoryStream())
            using (var speechEngine = new SpeechSynthesizer())
            {
                foreach (var device in WaveOutDevice.EnumerateDevices())
                {


                    string devices = $"{device.DeviceId}: {device.Name}";

                    if (devices.Contains("CABLE"))
                    {
                        string resultString = Regex.Match(devices, @"\d+").Value;
                        config.deviceId = Int32.Parse(resultString);

                    }
                    else if (devices.Contains("Speaker"))
                    {
                        string _speakerId = Regex.Match(devices, @"\d+").Value;
                        config.speakerId = Int32.Parse(_speakerId);
                    }
                }
                speechEngine.SetOutputToWaveStream(stream);
                speechEngine.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                speechEngine.Speak(config.text);
                using (var waveOut = new WaveOut { Device = new WaveOutDevice(config.deviceId) })
                using (var waveSource = new MediaFoundationDecoder(stream))
                {
                    waveOut.Initialize(waveSource);
                    waveOut.Play();
                    //config.is_playing = true;
                    newWorker.RunWorkerAsync();
                    waveOut.WaitForStopped();
                   

                }
            }

        }


        private void do_new_work(object sender, DoWorkEventArgs e)
        {
            using (var stream = new MemoryStream())
            using (var speechEngine = new SpeechSynthesizer())
            {
                speechEngine.SetOutputToWaveStream(stream);
                speechEngine.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                speechEngine.Speak(config.text);

                using (var waveOut = new WaveOut { Device = new WaveOutDevice(config.speakerId) })
                using (var waveSource = new MediaFoundationDecoder(stream))
                {
                    waveOut.Initialize(waveSource);
                    waveOut.Play();
                    //config.is_playing = true;
                    waveOut.WaitForStopped();


                }
            }
        }

        private void work_completed(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            config.text = _text.Text;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += do_work;
            worker.RunWorkerCompleted += work_completed;
            worker.RunWorkerAsync();


        }
    }
}
