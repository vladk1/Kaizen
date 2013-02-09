using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Windows.Threading;
using Microsoft.Xna.Framework;

using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace modelOne
{

    public partial class Page1 : PhoneApplicationPage
    {
        Microphone mic = Microphone.Default;
        byte[] data = null;
        MemoryStream audio = null;

        // Constructor
        public Page1()
        {
            InitializeComponent();
            mic.BufferReady += new EventHandler<EventArgs>(mic_BufferReady);
        }

        void mic_BufferReady(object sender, EventArgs e)
        {
            mic.GetData(data);
            audio.Write(data, 0, data.Length);
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            if (mic.State == MicrophoneState.Stopped)
            {
                mic.BufferDuration = TimeSpan.FromMilliseconds(100);
                data = new byte[mic.GetSampleSizeInBytes(mic.BufferDuration)];
                audio = new MemoryStream();
                mic.Start();
               // this.PageTitle.Text = "recording...";
                btnRecord.Content = "Stop";
            }
            else
            {
                mic.Stop();
             //   this.PageTitle.Text = "playing";
                btnRecord.Content = "Record";
                btnRecord.IsEnabled = false;
                PlayRecordedAudio();
               // this.PageTitle.Text = "ready";
            }
        }


        private void PlayRecordedAudio()
        {
            SoundEffect se = new SoundEffect(audio.ToArray(), mic.SampleRate,
            AudioChannels.Stereo);
            se.Play(1.0f, -1.0f, 0.0f);
            btnRecord.IsEnabled = true;
        }
    }


    public class XNADispatcherService : IApplicationService
    {
        private DispatcherTimer frameworkDispatcherTimer;
        public void StartService(ApplicationServiceContext context)
        {
            this.frameworkDispatcherTimer.Start();
        }
        public void StopService()
        {
            this.frameworkDispatcherTimer.Stop();
        }
        public XNADispatcherService()
        {
            this.frameworkDispatcherTimer = new DispatcherTimer();
            this.frameworkDispatcherTimer.Interval = TimeSpan.FromTicks(333333);
            this.frameworkDispatcherTimer.Tick += frameworkDispatcherTimer_Tick;
            FrameworkDispatcher.Update();
        }
        void frameworkDispatcherTimer_Tick(object sender, EventArgs e)
        {
            FrameworkDispatcher.Update();
        }
    }
}