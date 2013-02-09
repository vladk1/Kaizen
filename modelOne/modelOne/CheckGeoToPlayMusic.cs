using AudioPlaybackAgent2;
using Microsoft.Phone.BackgroundAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Devices.Geolocation;

namespace modelOne
{
    class CheckGeoToPlayMusic
    {
        UpdatePlayerState updateState = new UpdatePlayerState();

        //void Main_Page_Loaded(object sender, RoutedEventArgs e)
        //{
           

       // }


        // check if current position satisfies a song's geo postion
        public int checkCoordinates(Geolocator sender, PositionChangedEventArgs args, double[][] geoCoordinateCode, int mediaNumberOptions)
        {

            int getDecision;
            int successfullAudioPlay = 0;

            AudioGet getSong = new AudioGet();
            // checking for an audio file. will need to implement the algorithm with formulas here as well

            getDecision = getSong.getLocationCheck(sender, args, geoCoordinateCode);


            // if the song currently is not playing, play it
            if ((getDecision == 1) && ((App.Current as App).mediaNumber != mediaNumberOptions))
            {

                successfullAudioPlay = 1;
                (App.Current as App).mediaNumber = mediaNumberOptions;
                SetSongforPlayer();
            
            }

            return successfullAudioPlay;
        }




        private void SetSongforPlayer()
        {
            int counter = 0;
            switch ((App.Current as App).mediaNumber)
            {
                case 1:

                    //if ((App.Current as App).myMediaElement1 != null) (App.Current as App).mediaElement = (App.Current as App).myMediaElement1;
                  // findAndPlay(); // potentially create seperate class for findAndPlay

                    //want to play acdc 
                    while (counter < 2)
                    {
                        BackgroundAudioPlayer.Instance.SkipNext();
                        counter++;
                    }
                    BackgroundAudioPlayer.Instance.Play();
                  // find song 
                  // assign 
                  // play 
                  
                  break;

                case 2:

                  //  if ((App.Current as App).myMediaElement2 != null) (App.Current as App).mediaElement = (App.Current as App).myMediaElement2;
                 //   findAndPlay();
                    while (counter < 2)
                    {
                        BackgroundAudioPlayer.Instance.SkipNext();
                    }
                    BackgroundAudioPlayer.Instance.Play();
                 
                 break;

              /*  case 3:
                    if (myMediaElement3 != null) mediaElement = myMediaElement3;
                    findAndPlay();
                    break;

                case 4:

                    if (myMediaElement4 != null) mediaElement = myMediaElement4;
                    findAndPlay();
                    break;
                // else if (mediaNumber == 5)

                case 5:

                    if (myMediaElement5 != null) mediaElement = myMediaElement5;
                    findAndPlay();
                    //SongFinder();
                    //playProcess();
                    break;*/
            }
            updateState.UpdateState(null, null);

        }


        private void findAndPlay()
        {
           // SongFinder(); // can call from main class
            playProcess(); // can call from the main class
        }

        // this function save song so we can always access previous one
        private void SongFinder()
        {
         /*   if (!prevSongChanger)
            {
                (App.Current as App).saveSong1 = (App.Current as App).mediaElement;
                prevSongChanger = true;

                if ((App.Current as App).saveSong2 != null) (App.Current as App).prev_mediaElement = (App.Current as App).saveSong2;
                else (App.Current as App).prev_mediaElement = (App.Current as App).saveSong1;
            }
            else
            {
                (App.Current as App).saveSong2 = (App.Current as App).mediaElement;
                prevSongChanger = false;
                if ((App.Current as App).saveSong1 != null) (App.Current as App).prev_mediaElement = (App.Current as App).saveSong1;
                else (App.Current as App).prev_mediaElement = (App.Current as App).saveSong2;
            }

            //PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState


            //(App.Current as App).mediaElement.CurrentStateChange += new RoutedEventHandler(Instance_PlayStateChange);
            BackgroundAudioPlayer.Instance.PlayStateChanged += new RoutedEventHandler(Instance_PlayStateChange);


            //if ((App.Current as App).mediaElement.CurrentState == MediaElementState.Playing)
            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                positionIndicator.IsIndeterminate = false;
                positionIndicator.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;

                if (nextSongAvailable) UpdateButtons(true, false, true, true);
                else UpdateButtons(true, false, true, false);
                //UpdateButtons(true, false, true, false);

                updateState.UpdateState(null, null);
            }
            */
        }


        void playProcess()
        {
           // BackgroundAudioPlayer MainAudioPlayer;
          


            if ((App.Current as App).mediaNumber != 0)
            {
                //if (nextSongAvailable) UpdateButtons()
               // else 

                //UpdateButtons(true);
                //updateState.UpdateState(null, null); might need

               // (App.Current as App).mediaElement.

                //player1.OnUserAction(audioplayer1, (App.Current as App).mediaElement, UserAction.Play, true );

           //     (App.Current as App).mediaElement.Duration = 21;

              //  TimeSpan hi;
               // hi = 11;


            //    (App.Current as App).mediaElement.BeginEdit();
            //    (App.Current as App).mediaElement.Duration = hi; 
            //    (App.Current as App).mediaElement.EndEdit();

            //    (App.Current as App).MainAudioPlayer.Track = (App.Current as App).mediaElement;

                var player = BackgroundAudioPlayer.Instance;
               // AudioTrack currentTrack = player.Track;
                PlayState playState = (App.Current as App).MainAudioPlayer.PlayerState;

              //  PlayState playState;
                if (playState == PlayState.BufferingStopped)

             //   if (BackgroundAudioPlayer.Instance.Track != null)

                {
                    (App.Current as App).MainAudioPlayer.Track = (App.Current as App).mediaElement;
                    (App.Current as App).MainAudioPlayer.Play();
                }
                else playProcess();
               
                //  (App.Current as App).MainAudioPlayer.Play();

                
     
            }


        }





       




       

        }







    }

