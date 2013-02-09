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

namespace modelOne
{

    public partial class PivotPage1 : PhoneApplicationPage
    {
        string[] updatePlayerArray;
       

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


            updatePlayPauseButtons();
        }

        public void Instance_PlayStateChanged(object sender, EventArgs e)
        {

            switch ((App.Current as App).MainAudioPlayer.PlayerState)
            {

                case PlayState.Playing:
                    positionIndicator.IsIndeterminate = false;
                    positionIndicator.Maximum = (App.Current as App).mediaElement.Duration.TotalSeconds;

                    UpdateState(null, null);
                    _timer.Start();
                    break;

                case PlayState.Paused:

                    UpdateState(null, null);
                    _timer.Stop();

                    break;

            }

        }
            
         
       



        #region <<<<< Buttons  Click  Capture >>>>>

        private void updatePlayPauseButtons()
        {
            if ((App.Current as App).musicPlay == true)
            {
                mediaButtonPlay.Visibility = System.Windows.Visibility.Collapsed;
                mediaButtonPause.Visibility = System.Windows.Visibility.Visible;
            }
            else if ((App.Current as App).musicPlay == false)
            {
                mediaButtonPlay.Visibility = System.Windows.Visibility.Visible;
                mediaButtonPause.Visibility = System.Windows.Visibility.Collapsed;
            }
            else (App.Current as App).musicPlay = false;
        }

        private void first_track_Pressed(object sender, RoutedEventArgs e)
        {
               
        }

        private void second_track_Pressed(object sender, RoutedEventArgs e)
        {

        }

        private void third_track_Pressed(object sender, RoutedEventArgs e)
        {

        }

        private void recorder_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/VoiceRecorder.xaml", UriKind.Relative));
        }


        private void play_pause_Button(object sender, RoutedEventArgs e)
        {


            if ((App.Current as App).musicPlay == true)
            {
               // play_btn.Text = "pause";
               // play_btn.IconUri = new Uri("/Assets/transport.pause.png", UriKind.Relative);
                mediaButtonPlay.Visibility = System.Windows.Visibility.Visible;
                mediaButtonPause.Visibility = System.Windows.Visibility.Collapsed;
                (App.Current as App).musicPlay = false;
                
            }
            else if ((App.Current as App).musicPlay == false)
            {
                mediaButtonPlay.Visibility = System.Windows.Visibility.Collapsed;
                mediaButtonPause.Visibility = System.Windows.Visibility.Visible;
                (App.Current as App).musicPlay = true;
            }
        }
       


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            // do some stuff ...
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            // cancel the navigation
           //e.Cancel = true;
        }

        #endregion 
    }
}