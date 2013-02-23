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
        string[][] firstFourBuildingsInfo= new string[5][];//will contain four buildings + 1)name 2)distance to it
        string[] specificBuildingsInfo;
       

        // check if current position satisfies a song's geo postion
        public string[][] checkCoordinates(Geolocator sender, PositionChangedEventArgs args, double[][] geoCoordinateCode, int mediaNumberOptions)
        {

            int getDecision;
            int successfullAudioPlay = 0;

            int order = 0;

            AudioGet getSong = new AudioGet();
            // checking for an audio file. will need to implement the algorithm with formulas here as well

            getDecision = getSong.getLocationCheck(sender, args, geoCoordinateCode);

            SelectBuildings selectionBuildings = new SelectBuildings();

            // if the song currently is not playing, play it
            if ((getDecision == 1) && ((App.Current as App).mediaNumber != mediaNumberOptions))
            {

                successfullAudioPlay = 1;
                (App.Current as App).mediaNumber = mediaNumberOptions;

                double[] currentPositionArrayInf =  {(App.Current as App).mediaNumber-1, 0};

                SetSongforPlayer(currentPositionArrayInf,0);

                order = 0;
                while (order < 5  )
                {
                    if (order != 0)  SetSongforPlayer(selectionBuildings.sortArray(order, sender, args), order);

                    
                    order++;
                }
                      
                //firstFourBuildingsInfo =  

            }
            else
            {
                while (order < 5 )
                {
                    SetSongforPlayer(selectionBuildings.sortArray(order, sender, args), order);
                    order++;
                }
            }
            return firstFourBuildingsInfo;
        }

        private void getPlayList(int orderBuilding,int value)
        {
            switch (orderBuilding)
                    {

                        case 0: 
                            (App.Current as App).AudioPlaylistNumber1 = value;
                            break;
                        case 1:
                            (App.Current as App).AudioPlaylistNumber2 = value;
                            break;
                        case 2:
                            (App.Current as App).AudioPlaylistNumber3 = value;
                            break;
                        case 3:
                            (App.Current as App).AudioPlaylistNumber4 = value;
                            break;
                        

                    }
        }

        // no, here we will choose audio_playlist to play
        private string[][] SetSongforPlayer(double[] input, int orderBuilding)
        {
            int counter = 0;
            int mediaNumber = (int)input[0]+1;

            specificBuildingsInfo = new string[2];
            switch (mediaNumber)
            {
                case 1:



                    //want to play acdc with an order 2 in the queue (queue starts from 0)
                    //while (counter < 2)
                    //{
                    //    BackgroundAudioPlayer.Instance.SkipNext();
                    //    counter++;
                   // }
                    //BackgroundAudioPlayer.Instance.Play();

                    // used to set up playlist automatically in case user will use default mode
                    (App.Current as App).currentAudioPlaylistNumber = 0;


                    getPlayList(orderBuilding,0); // order building is going to have / playlist the building assign to

                    //Assert.AreEqual("My home", firstFourBuildingsInfo[0][0]); 

                    specificBuildingsInfo[0] = "My home";
                    if (orderBuilding == 0) specificBuildingsInfo[1] = "nearby";
                    else specificBuildingsInfo[1] = ((int)input[1]).ToString() + " m";

                  break;

                case 2:

                  //want to play something with an order 1 in the queue
                   // while (counter < 1)
                   // {
                   //     BackgroundAudioPlayer.Instance.SkipNext();
                   // }
                   // BackgroundAudioPlayer.Instance.Play();
                  (App.Current as App).currentAudioPlaylistNumber = 1;

                  getPlayList(orderBuilding, 1);

                  specificBuildingsInfo[0] = "Roberts Building";
                  if (orderBuilding == 0) specificBuildingsInfo[1] = "nearby";
                  else specificBuildingsInfo[1] = ((int) input[1]).ToString() + " m";
                    
                 break;

               case 3:
                  //  if (myMediaElement3 != null) mediaElement = myMediaElement3;
                  //  findAndPlay();
                    (App.Current as App).currentAudioPlaylistNumber = 2;

                    getPlayList(orderBuilding, 2);

                  specificBuildingsInfo[0] = "Malet Place";
                  if (orderBuilding == 0) specificBuildingsInfo[1] = "nearby";
                  else specificBuildingsInfo[1] = ((int) input[1]).ToString() + " m";
                  
                  
                  break;

                case 4:

                  getPlayList(orderBuilding, 3);

                  //  if (myMediaElement4 != null) mediaElement = myMediaElement4;
                  //  findAndPlay();
                    (App.Current as App).currentAudioPlaylistNumber = 3;

                  specificBuildingsInfo[0] = "Pearson";
                  if (orderBuilding == 0) specificBuildingsInfo[1] = "nearby";
                  else specificBuildingsInfo[1] = ((int) input[1]).ToString() + " m";
                  
                  
                  break;
                // else if (mediaNumber == 5)

                case 5:
                     getPlayList(orderBuilding, 4);

                  //  if (myMediaElement4 != null) mediaElement = myMediaElement4;
                  //  findAndPlay();
                    (App.Current as App).currentAudioPlaylistNumber = 4;

                  specificBuildingsInfo[0] = "Science Library";
                  if (orderBuilding == 0) specificBuildingsInfo[1] = "nearby";
                  else specificBuildingsInfo[1] = ((int) input[1]).ToString() + " m";
                    
                    break;
            }
            updateState.UpdateState(null, null);

            firstFourBuildingsInfo[orderBuilding] = specificBuildingsInfo;

            

            return firstFourBuildingsInfo;
               
            // SortingBuildingList buildingSort = new SortingBuildingList();

                //buildingSort.sort((App.Current as App).mediaNumber)

        }


      
        }

    }

