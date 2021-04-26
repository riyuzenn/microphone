## Serum Microphone
> [back](https://github.com/serumstudio/microphone/tree/main/docs) 

Serum microphone is text to speech program that act as your microphone. It was fully written in C# with WPF and compiled with Visual Studio 2019.

## How it works?

Serum microphone is powered by [VB Audio Cable](https://vb-audio.com/Cable/), it won't work unless you installed it.
Serum Microphone works by changing the audio output of the text to speech. The text to speech was powered by Microsoft built-in text to speech.
You can access it in by using the namespace `using System.Speech`. 

The code from [PlayerView.xaml.cs](https://github.com/serumstudio/microphone/blob/main/Serum%20Microphone/View/PlayerView.xaml.cs) is just an example on how the app works. It takes the text and parse it to `SpeechSynthesizer` and then change the audio output from default to VB Cable in order to us to use it as an input cable (microphone). It's awesome how easy it is. You can create your own in just a simple code given below.
```csharp
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
    waveOut.WaitForStopped();
                   

    }
}
```
