using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Map;
using DevExpress.XtraMap;

namespace TravelTimeDistance {
    public partial class Form1 : Form {

        static string BingKey = "Insert your Bing key";

        InformationLayer RouteLayer { get { return mapControl1.Layers[1] as InformationLayer; } }
        BingRouteDataProvider RouteDataProvider { get { return RouteLayer.DataProvider as BingRouteDataProvider; } }
        MapItemStorage PushpinAdapter { get { return ((VectorItemsLayer)mapControl1.Layers[2]).Data as MapItemStorage; } }

        List<RouteWaypoint> wayPoints = new List<RouteWaypoint>();

        public Form1() {
            InitializeComponent();
            RouteDataProvider.BingKey = BingKey;
            BingMapDataProvider tileProvider = ((ImageTilesLayer)mapControl1.Layers[0]).DataProvider as BingMapDataProvider;
            tileProvider.BingKey = BingKey;

            mapControl1.ZoomLevel = 12.0;
            mapControl1.CenterPoint = new GeoPoint(51.5, -0.1);

            RouteDataProvider.RouteCalculated += RouteDataProvider_RouteCalculated;
            RouteDataProvider.LayerItemsGenerating += RouteDataProvider_LayerItemsGenerating;

            RouteLayer.ItemStyle.StrokeWidth = 3;
            RouteLayer.ItemStyle.Stroke = Color.Yellow;
        }

        void RouteDataProvider_LayerItemsGenerating(object sender, LayerItemsGeneratingEventArgs e) {
            foreach (MapItem item in e.Items)
                if (item is MapPushpin)
                    item.Visible = false;
        }

        void RouteDataProvider_RouteCalculated(object sender, BingRouteCalculatedEventArgs e) {
            double distance = 0;
            TimeSpan time = new TimeSpan();
            foreach (BingRouteResult res in e.CalculationResult.RouteResults) {
                distance += res.Distance;
                time += res.Time;
            }
            label1.Text = "Distance " + distance.ToString();
            label2.Text = "Time " + time.ToString();
        }

        private void mapControl1_MouseDown(object sender, MouseEventArgs e) {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
                CoordPoint point = mapControl1.ScreenPointToCoordPoint(e.Location);
                PushpinAdapter.Items.Add(new MapPushpin() { Location = point, Text = PushpinAdapter.Items.Count.ToString() });
                listBox1.Items.Add(point);
            }
        }

        void button1_Click(object sender, System.EventArgs e) {
            wayPoints.Clear();
            foreach (object point in listBox1.SelectedItems)
                wayPoints.Add(new RouteWaypoint("", point as GeoPoint));
            RouteDataProvider.CalculateRoute(wayPoints);
        }

        void button2_Click(object sender, EventArgs e) {
            wayPoints.Clear();
            listBox1.Items.Clear();
            PushpinAdapter.Items.Clear();
            RouteLayer.ClearResults();
            mapControl1.ForceRender();
        }
    }
}
