Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Map
Imports DevExpress.XtraMap

Namespace TravelTimeDistance
    Partial Public Class Form1
        Inherits Form

        Private Shared BingKey As String = "Insert your Bing key"

        Private ReadOnly Property RouteLayer() As InformationLayer
            Get
                Return TryCast(mapControl1.Layers(1), InformationLayer)
            End Get
        End Property
        Private ReadOnly Property RouteDataProvider() As BingRouteDataProvider
            Get
                Return TryCast(RouteLayer.DataProvider, BingRouteDataProvider)
            End Get
        End Property
        Private ReadOnly Property PushpinAdapter() As MapItemStorage
            Get
                Return TryCast(CType(mapControl1.Layers(2), VectorItemsLayer).Data, MapItemStorage)
            End Get
        End Property

        Private wayPoints As New List(Of RouteWaypoint)()

        Public Sub New()
            InitializeComponent()
            RouteDataProvider.BingKey = BingKey
            Dim tileProvider As BingMapDataProvider = TryCast(CType(mapControl1.Layers(0), ImageLayer).DataProvider, BingMapDataProvider)
            tileProvider.BingKey = BingKey

            mapControl1.ZoomLevel = 12.0
            mapControl1.CenterPoint = New GeoPoint(51.5, -0.1)

            AddHandler RouteDataProvider.RouteCalculated, AddressOf RouteDataProvider_RouteCalculated
            AddHandler RouteDataProvider.LayerItemsGenerating, AddressOf RouteDataProvider_LayerItemsGenerating

            RouteLayer.ItemStyle.StrokeWidth = 3
            RouteLayer.ItemStyle.Stroke = Color.Yellow
        End Sub

        Private Sub RouteDataProvider_LayerItemsGenerating(ByVal sender As Object, ByVal e As LayerItemsGeneratingEventArgs)
            For Each item As MapItem In e.Items
                If TypeOf item Is MapPushpin Then
                    item.Visible = False
                End If
            Next item
        End Sub

        Private Sub RouteDataProvider_RouteCalculated(ByVal sender As Object, ByVal e As BingRouteCalculatedEventArgs)
            Dim distance As Double = 0
            Dim time As New TimeSpan()
            For Each res As BingRouteResult In e.CalculationResult.RouteResults
                distance += res.Distance
                time = time + res.Time
            Next res
            label1.Text = "Distance " & distance.ToString()
            label2.Text = "Time " & time.ToString()
        End Sub

        Private Sub mapControl1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mapControl1.MouseDown
            If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                Dim point As CoordPoint = mapControl1.ScreenPointToCoordPoint(e.Location)
                PushpinAdapter.Items.Add(New MapPushpin() With {.Location = point, .Text = PushpinAdapter.Items.Count.ToString()})
                listBox1.Items.Add(point)
            End If
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            wayPoints.Clear()
            For Each point As Object In listBox1.SelectedItems
                wayPoints.Add(New RouteWaypoint("", TryCast(point, GeoPoint)))
            Next point
            RouteDataProvider.CalculateRoute(wayPoints)
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            wayPoints.Clear()
            listBox1.Items.Clear()
            PushpinAdapter.Items.Clear()
            RouteLayer.ClearResults()
            mapControl1.ForceRender()
        End Sub
    End Class
End Namespace
