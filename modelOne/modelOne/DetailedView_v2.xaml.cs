using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.BackgroundAudio;
using System.Windows.Threading;

using AudioPlaybackAgent2;

namespace modelOne
{

    public partial class PivotPage1 : PhoneApplicationPage
    {
        string[] updatePlayerArray;

        bool musicPlay;
        int playList;
        // Timer for updating the UI
        DispatcherTimer _timer;

        public PivotPage1()
        {
            
            InitializeComponent();

             // Initialize a time to update every half-second
            _timer = new DispatcherTimer();

            UpdatePlayerState updateVariable = new UpdatePlayerState();

            _timer.Interval = TimeSpan.FromSeconds(0.5);
            _timer.Tick += new EventHandler(UpdateState);


            //SetSongforPlayer(mediaNumber);

          //  UpdateState(null, null);

        }

        void UpdateState(object sender, EventArgs e)
        {
            UpdatePlayerState updateState = new UpdatePlayerState();
            updatePlayerArray = updateState.UpdateState(null, null);

            trackTitle.Text = updatePlayerArray[0];


            positionIndicator.Value = Double.Parse(updatePlayerArray[1]);
            //string positionIndicator = ""; // positionIndicator.Value

            textPosition.Text = updatePlayerArray[2];

            textRemaining.Text = updatePlayerArray[3];

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
           
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                detailed_page_title.Title = selectedIndex;
                // DataContext = App.ViewModel.Items[index];
            }

            musicPlay = (App.Current as App).musicPlay;
            playList = (App.Current as App).currentAudioPlaylistNumber;

            AudioTrack track;

           // track = BackgroundAudioPlayer.Instance.Track;
           // set_AudioList_Track_number(1);
            

            checkOut();

            updatePlayPauseButtons();
        }

        public void checkOut()
        {
            AudioTrack track1 = null;
            AudioTrack track2 = null;
            AudioTrack track3 = null;

            track1 = AudioPlayer._playList1[0];
            track2 = AudioPlayer._playList1[1];
            track3 = AudioPlayer._playList1[2];


            
            item_ONE_name.Text = track1.Title;
            item_TWO_name.Text = track2.Title;
            item_THREE_name.Text = track3.Title;
        }

        public void Instance_PlayStateChanged(object sender, EventArgs e)
        {

            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {

                case PlayState.Playing:
                    positionIndicator.IsIndeterminate = false;
                    positionIndicator.Maximum = BackgroundAudioPlayer.Instance.Track.Duration.TotalSeconds; //.Duration.TotalSeconds

                    musicPlay = true;

                    UpdateState(null, null);
                    _timer.Start();
                    break;

                case PlayState.Paused:

                    musicPlay = false;

                    UpdateState(null, null);
                    _timer.Stop();
                    break;

            }

        }

        private void set_AudioList_Track_number(int trackNumber)
        {
            int counter = 0;
           // AudioTrack track;
           // track = BackgroundAudioPlayer.Instance.Track;
            while (counter < playList) // choose playList
            {
                BackgroundAudioPlayer.Instance.SkipPrevious();
                counter++;
            }
            counter = 0;
            while (counter < trackNumber-1) // chooseSongNumber
            {
                BackgroundAudioPlayer.Instance.SkipNext();
                counter++;
            }
            //BackgroundAudioPlayer.Instance.SkipNext();

           
        }
       



        #region <<<<< Buttons  Click  Capture >>>>>


        private void first_track_Pressed(object sender, RoutedEventArgs e)
        {
            (App.Current as App).currentAudioPlaylistNumber = (App.Current as App).AudioPlaylistNumber1;
            playList = (App.Current as App).currentAudioPlaylistNumber;

            BackgroundAudioPlayer.Instance.Rewind();
            set_AudioList_Track_number(1); // will play track 0  
            BackgroundAudioPlayer.Instance.Play();
            musicPlay = true;
            updatePlayPauseButtons();
        }

        private void second_track_Pressed(object sender, RoutedEventArgs e)
        {
            (App.Current as App).currentAudioPlaylistNumber = (App.Current as App).AudioPlaylistNumber2;
            playList = (App.Current as App).currentAudioPlaylistNumber;

            BackgroundAudioPlayer.Instance.Rewind();
            set_AudioList_Track_number(2); // will play track 1
            BackgroundAudioPlayer.Instance.Play();
            musicPlay = true;
            updatePlayPauseButtons();
        }

        private void third_track_Pressed(object sender, RoutedEventArgs e)
        {
            (App.Current as App).currentAudioPlaylistNumber = (App.Current as App).AudioPlaylistNumber3;
            playList = (App.Current as App).currentAudioPlaylistNumber;

            BackgroundAudioPlayer.Instance.Rewind();
            set_AudioList_Track_number(3); // will play track 2
            BackgroundAudioPlayer.Instance.Play();
            musicPlay = true;
            updatePlayPauseButtons();
        }


        

        


        private void recorder_Button_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).musicPlay = musicPlay;
            NavigationService.Navigate(new Uri("/VoiceRecorder.xaml", UriKind.Relative));
        }


        private void play_pause_Button(object sender, RoutedEventArgs e)
        {
            if (musicPlay == true)
            {
                // play_btn.Text = "pause";
                // play_btn.IconUri = new Uri("/Assets/transport.pause.png", UriKind.Relative);
                mediaButtonPlay.Visibility = System.Windows.Visibility.Visible;
                mediaButtonPause.Visibility = System.Windows.Visibility.Collapsed;
                musicPlay = false;

                BackgroundAudioPlayer.Instance.Pause();

            }
            else if (musicPlay == false)
            {
                mediaButtonPlay.Visibility = System.Windows.Visibility.Collapsed;
                mediaButtonPause.Visibility = System.Windows.Visibility.Visible;
                musicPlay = true;

                BackgroundAudioPlayer.Instance.Play();
            }
        }

        // if audio is playing that change some layout
        private void updatePlayPauseButtons()
        {
            if (musicPlay == true)
            {
                mediaButtonPlay.Visibility = System.Windows.Visibility.Collapsed;
                mediaButtonPause.Visibility = System.Windows.Visibility.Visible;
            }
            else if (musicPlay == false)
            {
                mediaButtonPlay.Visibility = System.Windows.Visibility.Visible;
                mediaButtonPause.Visibility = System.Windows.Visibility.Collapsed;
            }
            else musicPlay = false;
            

        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            // do some stuff ...
            (App.Current as App).musicPlay = musicPlay;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            // cancel the navigation
           //e.Cancel = true;
        }

        #endregion 
    }
}