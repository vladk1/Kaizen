using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.IO;
using System.Threading.Tasks;
using System.Device.Location;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Media;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Windows.Devices.Geolocation;
using System.IO.IsolatedStorage;
using Windows.UI;

namespace modelOne
{


    public partial class MainPage : PhoneApplicationPage
    {
        string[][] firstFourBuildingsInfo;

        //GeoLocation related variables
        Geolocator geolocator = null;
        bool tracking = false;
        ProgressIndicator pi;

        MapLayer PushpinMapLayer;
        MapOverlay MyOverlay;

        GeoCoordinate positionCoord;

        int firstRun = 0;

        

        // Indexes into the array of ApplicationBar.Buttons
        const int downloadButton = 0;
        //const int playButton = 1;
        const int shareButton = 2;

        const int nextButton = 3;


        public double Latitude;
        public double Longitude;


       // int mediaNumber = 0;

        // Constructor
        public MainPage()
        {


            InitializeComponent();

            updateLocationMarker();

            getLocation();



            pi = new ProgressIndicator();
            pi.IsIndeterminate = true;
            pi.IsVisible = false;

        }


        // Creating a MapLayer and adding the MapOverlay to it
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // PushpinMapLayer = new MapLayer();
            // Map.Layers.Add(PushpinMapLayer);


            updatePlayPauseButtons();



            base.OnNavigatedTo(e);
        }



        # region <<<<< Navigation  part  of  the  project >>>>>


        // Sweet function which finds user's current location
        private void getLocation()
        {
            if (!tracking)
            {
                geolocator = new Geolocator();
                geolocator.DesiredAccuracy = PositionAccuracy.High;
                geolocator.MovementThreshold = 20; // The units are meters.

                geolocator.StatusChanged += geolocator_StatusChanged;
                geolocator.PositionChanged += geolocator_PositionChanged;

                tracking = true;
                // TrackLocationButton.Content = "stop tracking";

                this.Map.ResolveCompleted += MapResolveCompleted;
            }
            else
            {
                geolocator.PositionChanged -= geolocator_PositionChanged;
                geolocator.StatusChanged -= geolocator_StatusChanged;
                geolocator = null;

                tracking = false;
                //  TrackLocationButton.Content = "track location";
                // StatusTextBlock.Text = "stopped";

                this.Map.ResolveCompleted -= MapResolveCompleted;
            }


            

        }


        // Look up Status change, by status I mean geoTracker <Disabled>/<Initializing>/<NoData>... notifications
        // actually might not need it
        void geolocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            string status = "";

            switch (args.Status)
            {
                case PositionStatus.Disabled:
                    // the application does not have the right capability or the location master switch is off
                    status = "location is disabled in phone settings";
                    break;
                case PositionStatus.Initializing:
                    // the geolocator started the tracking operation
                    status = "initializing";
                    break;
                case PositionStatus.NoData:
                    // the location service was not able to acquire the location
                    status = "no data";
                    break;
                case PositionStatus.Ready:
                    // the location service is generating geopositions as specified by the tracking parameters
                    status = "ready";
                    break;
                case PositionStatus.NotAvailable:
                    status = "not available";
                    // not used in WindowsPhone, Windows desktop uses this value to signal that there is no hardware capable to acquire location information
                    break;
                case PositionStatus.NotInitialized:
                    // the initial state of the geolocator, once the tracking operation is stopped by the user the geolocator moves back to this state

                    break;
            }

           // Dispatcher.BeginInvoke(() =>
           // {
           //     statusUpdate.Text = status;
           // });
        }


        // For a current position change, set it up on the map by drawing a push pin object and zooms in to it.
        // Also checks if a current position satisfies to the marked audio zones, by calling <checkCoordinates> function which makes all comparison (look in audioPlayer part)
        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {

                Latitude = args.Position.Coordinate.Latitude;
                Longitude = args.Position.Coordinate.Longitude;



                // Unfortunately, the Location API works with Windows.Devices.Geolocation.Geocoordinate objeccts
                // and the Maps controls use System.Device.Location.GeoCoordinate objects so we have to do a
                // conversion before we do anything with it on the map
                GeoCoordinate positionCoord = new GeoCoordinate()
                {
                    Altitude = args.Position.Coordinate.Altitude.HasValue ? args.Position.Coordinate.Altitude.Value : 0.0,
                    Course = args.Position.Coordinate.Heading.HasValue ? args.Position.Coordinate.Heading.Value : 0.0,
                    HorizontalAccuracy = args.Position.Coordinate.Accuracy,
                    Latitude = args.Position.Coordinate.Latitude,
                    Longitude = args.Position.Coordinate.Longitude,
                    Speed = args.Position.Coordinate.Speed.HasValue ? args.Position.Coordinate.Speed.Value : 0.0,
                    VerticalAccuracy = args.Position.Coordinate.AltitudeAccuracy.HasValue ? args.Position.Coordinate.AltitudeAccuracy.Value : 0.0
                };



                // Center the map on the new location
                this.Map.Center = positionCoord;

                this.Map.ZoomLevel = 19;


                if (MyOverlay != null)
                    this.PushpinMapLayer.Remove(MyOverlay);

                // firstRun = 1;

                MyOverlay = new MapOverlay();
                TakeUserPushPin takePushpin = new TakeUserPushPin();

                // DrawUserPushPin.DrawPushpin(positionCoord, MyOverlay);
                MyOverlay = takePushpin.DrawPushpin(positionCoord, MyOverlay);

                // Add the MapOverlay containing the pushpin to the MapLayer
                this.PushpinMapLayer.Add(MyOverlay);

                locationDrawPushpin(args);



                // this two lines produsing all the work related to 
                // checking and identifying if any song should be played in this particular place
                LocationCheck locationCheck = new LocationCheck();

                firstFourBuildingsInfo = new string[4][]; // setting up an array to get information about current location

               firstFourBuildingsInfo =  locationCheck.startAnalysis(sender, args);
               if (firstFourBuildingsInfo != null)
               {
                   item_ONE_name.Text = firstFourBuildingsInfo[0][0];
                   item_ONE_dist.Text = firstFourBuildingsInfo[0][1];

                   item_TWO_name.Text = firstFourBuildingsInfo[1][0];
                   item_TWO_dist.Text = firstFourBuildingsInfo[1][1];

                   item_THREE_name.Text = firstFourBuildingsInfo[2][0];
                   item_THREE_dist.Text = firstFourBuildingsInfo[2][1];

                   item_FOUR_name.Text = firstFourBuildingsInfo[3][0];
                   item_FOUR_dist.Text = firstFourBuildingsInfo[3][1];
               }


                


                // Show progress indicator while map resolves to new position
                pi.IsVisible = true;
                pi.IsIndeterminate = true;
                pi.Text = "Resolving...";
                SystemTray.SetProgressIndicator(this, pi);
            });
        }


        void locationDrawPushpin(PositionChangedEventArgs args)
        {
            // Unfortunately, the Location API works with Windows.Devices.Geolocation.Geocoordinate objeccts
            // and the Maps controls use System.Device.Location.GeoCoordinate objects so we have to do a
            // conversion before we do anything with it on the map
            positionCoord = new GeoCoordinate()
            {
                Altitude = args.Position.Coordinate.Altitude.HasValue ? args.Position.Coordinate.Altitude.Value : 0.0,
                Course = args.Position.Coordinate.Heading.HasValue ? args.Position.Coordinate.Heading.Value : 0.0,
                HorizontalAccuracy = args.Position.Coordinate.Accuracy,
                Latitude = args.Position.Coordinate.Latitude,
                Longitude = args.Position.Coordinate.Longitude,
                Speed = args.Position.Coordinate.Speed.HasValue ? args.Position.Coordinate.Speed.Value : 0.0,
                VerticalAccuracy = args.Position.Coordinate.AltitudeAccuracy.HasValue ? args.Position.Coordinate.AltitudeAccuracy.Value : 0.0
            };

            //CurrentLocationSave currentLocationSave = new CurrentLocationSave();
            //currentLocationSave.currentLocationCoord = positionCoord;
            (App.Current as App).lastUserLocation = positionCoord;

            // Center the map on the new location
           
            this.Map.Center = positionCoord;

            this.Map.ZoomLevel = 19;

            //// Shorthand way of doing the above
            //GeoCoordinateEx gex = new GeoCoordinateEx();
            //gex = args.Position.Coordinate;
            //this.MyMap.Center = gex.GeoCoordinate;
            //// ... or using the Map extension method:
            //this.MyMap.SetCenter(args.Position.Coordinate);    

            if (MyOverlay != null)
                this.PushpinMapLayer.Remove(MyOverlay);

            MyOverlay = putOverlayOnMap(positionCoord, MyOverlay);

            this.PushpinMapLayer.Add(MyOverlay);  

        }


        private MapOverlay putOverlayOnMap(GeoCoordinate positionCoord, MapOverlay MyOverlay)
        {
            
            MyOverlay = new MapOverlay();
            // firstRun = 1;
            TakeUserPushPin takePushpin = new TakeUserPushPin();


            // DrawUserPushPin.DrawPushpin(positionCoord, MyOverlay);
            MyOverlay = takePushpin.DrawPushpin(positionCoord, MyOverlay);
            return MyOverlay;
            // Add the MapOverlay containing the pushpin to the MapLayer
           
        }


        private void MapResolveCompleted(object sender, MapResolveCompletedEventArgs e)
        {
            // Hide progress indicator
            pi.IsVisible = false;
            pi.IsIndeterminate = false;
            SystemTray.SetProgressIndicator(this, null);
        }


        #endregion



        // we have this function so after user will come back to the main menu, he will see last geolocation, while current one is updating
        private void updateLocationMarker()
        {
            PushpinMapLayer = new MapLayer();
            Map.Layers.Add(PushpinMapLayer);

            positionCoord = (App.Current as App).lastUserLocation;
            if (positionCoord != null)
            {

                Map.Center = positionCoord;

                Map.ZoomLevel = 19;

                if (MyOverlay != null)
                    PushpinMapLayer.Remove(MyOverlay);

                MyOverlay = putOverlayOnMap(positionCoord, MyOverlay);

                PushpinMapLayer.Add(MyOverlay);
            }
        }




        #region <<<<< Buttons  Click  Capture >>>>>

        // identify application bar button, if musicPlay(global bool variable responsible to identify audio file is playing or not) 
        //is true then make a pause button and vice versa
        private void updatePlayPauseButtons()
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if ((App.Current as App).musicPlay == true)
            {
                btn.IconUri = new Uri("/Assets/transport.pause.png", UriKind.Relative);
                btn.Text = "pause";
            }
            else if ((App.Current as App).musicPlay == false)
            {
                btn.IconUri = new Uri("/Assets/transport.play.png", UriKind.Relative);
                btn.Text = "play";
            }
            else
            {
                (App.Current as App).musicPlay = false;
                btn.IconUri = new Uri("/Assets/transport.play.png", UriKind.Relative);
                btn.Text = "play";
            }
        }

        private void player_button_click(object sender, EventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];

            if (btn.Text == "play")
            {
                (App.Current as App).musicPlay = true;
                btn.Text = "pause";
                btn.IconUri = new Uri("/Assets/transport.pause.png", UriKind.Relative);
            }
            else if (btn.Text == "pause")
            {
                (App.Current as App).musicPlay = false;
                btn.Text = "play";
                btn.IconUri = new Uri("/Assets/transport.play.png", UriKind.Relative);
            }
        }

        private void Road_Click(object sender, EventArgs args)
        {
            Map.CartographicMode = MapCartographicMode.Road;
        }

        // ITEM_LOCATION PRESSED
        private void first_Closest_Building_Pressed(object sender, RoutedEventArgs e)
        {


            if (MyOverlay != null)
                this.PushpinMapLayer.Remove(MyOverlay);

            //(App.Current as App).currentAudioPlaylistNumber = 0;
            
            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailedView_v2.xaml?selectedItem=" + item_ONE_name.Text, UriKind.Relative));
        }

        private void second_Closest_Building_Pressed(object sender, RoutedEventArgs e)
        {


            if (MyOverlay != null)
                this.PushpinMapLayer.Remove(MyOverlay);
            

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailedView_v2.xaml?selectedItem=" + item_TWO_name.Text, UriKind.Relative));
        }

        private void third_Closest_Building_Pressed(object sender, RoutedEventArgs e)
        {

            if (MyOverlay != null)
                this.PushpinMapLayer.Remove(MyOverlay);
            
            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailedView_v2.xaml?selectedItem=" + item_THREE_name.Text, UriKind.Relative));
        }

        #endregion
    }
}








    
