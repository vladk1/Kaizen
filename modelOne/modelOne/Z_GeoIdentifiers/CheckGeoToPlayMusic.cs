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



        // no, here we will choose audio_playlist to play
        private void SetSongforPlayer()
        {
            int counter = 0;
            switch ((App.Current as App).mediaNumber)
            {
                case 1:



                    //want to play acdc with an order 2 in the queue (queue starts from 0)
                    //while (counter < 2)
                    //{
                    //    BackgroundAudioPlayer.Instance.SkipNext();
                    //    counter++;
                   // }
                    //BackgroundAudioPlayer.Instance.Play();
                    (App.Current as App).currentAudioPlaylistNumber = 0;
                  
                  break;

                case 2:

                  //want to play something with an order 1 in the queue
                   // while (counter < 1)
                   // {
                   //     BackgroundAudioPlayer.Instance.SkipNext();
                   // }
                   // BackgroundAudioPlayer.Instance.Play();
                  (App.Current as App).currentAudioPlaylistNumber = 1;
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


      



       




       

        }







    }

