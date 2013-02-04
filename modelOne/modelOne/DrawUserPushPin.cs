
using Microsoft.Phone.Maps.Controls;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace modelOne
{
    class TakeUserPushPin
    {

        MapOverlay MyOverlay;
        MapLayer PushpinMapLayer;


        // draws current location on the map
        public MapOverlay DrawPushpin(GeoCoordinate coord, MapOverlay MyOverlay)
        {

            var aPushpin = CreatePushpinObject();

            //Creating a MapOverlay and adding the Pushpin to it.

           // if (firstRun == 1)
           // {
           //     this.PushpinMapLayer.Remove(MyOverlay);

           // }
           // firstRun = 1;
           
            MyOverlay.Content = aPushpin;
            MyOverlay.GeoCoordinate = coord;
            MyOverlay.PositionOrigin = new Point(0, 0.5);

            return MyOverlay;
        }


        // creates object to be drawn on the map
        private Grid CreatePushpinObject()
        {

            //Creating a Grid element.
            Grid MyGrid = new Grid();
            MyGrid.RowDefinitions.Add(new RowDefinition());
            MyGrid.RowDefinitions.Add(new RowDefinition());
            MyGrid.Background = new SolidColorBrush(Colors.Transparent);

            //Creating a Rectangle
            Rectangle MyRectangle = new Rectangle();
            MyRectangle.Fill = new SolidColorBrush(Color.FromArgb(0xF9, 0x00, 0x68, 0));
            MyRectangle.Height = 20;
            MyRectangle.Width = 20;
            MyRectangle.SetValue(Grid.RowProperty, 0);
            MyRectangle.SetValue(Grid.ColumnProperty, 0);

            //Adding the Rectangle to the Grid
            MyGrid.Children.Add(MyRectangle);

            //Creating a Polygon
            Polygon MyPolygon = new Polygon();
            MyPolygon.Points.Add(new Point(2, 0));
            MyPolygon.Points.Add(new Point(22, 0));
            MyPolygon.Points.Add(new Point(2, 40));
            MyPolygon.Stroke = new SolidColorBrush(Colors.Black);
            MyPolygon.Fill = new SolidColorBrush(Colors.Black);
            MyPolygon.SetValue(Grid.RowProperty, 1);
            MyPolygon.SetValue(Grid.ColumnProperty, 0);

            //Adding the Polygon to the Grid
            MyGrid.Children.Add(MyPolygon);
            return MyGrid;
        }
    }
}
