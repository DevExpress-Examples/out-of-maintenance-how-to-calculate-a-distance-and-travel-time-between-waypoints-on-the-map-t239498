Namespace TravelTimeDistance
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim imageTilesLayer2 As New DevExpress.XtraMap.ImageLayer()
            Dim bingMapDataProvider2 As New DevExpress.XtraMap.BingMapDataProvider()
            Dim informationLayer2 As New DevExpress.XtraMap.InformationLayer()
            Dim bingRouteDataProvider2 As New DevExpress.XtraMap.BingRouteDataProvider()
            Dim vectorItemsLayer2 As New DevExpress.XtraMap.VectorItemsLayer()
            Dim mapItemStorage2 As New DevExpress.XtraMap.MapItemStorage()
            Me.mapControl1 = New DevExpress.XtraMap.MapControl()
            Me.listBox1 = New System.Windows.Forms.ListBox()
            Me.button1 = New System.Windows.Forms.Button()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.button2 = New System.Windows.Forms.Button()
            DirectCast(Me.mapControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' mapControl1
            ' 
            imageTilesLayer2.DataProvider = bingMapDataProvider2
            informationLayer2.DataProvider = bingRouteDataProvider2
            vectorItemsLayer2.Data = mapItemStorage2
            Me.mapControl1.Layers.Add(imageTilesLayer2)
            Me.mapControl1.Layers.Add(informationLayer2)
            Me.mapControl1.Layers.Add(vectorItemsLayer2)
            Me.mapControl1.Location = New System.Drawing.Point(0, 0)
            Me.mapControl1.Name = "mapControl1"
            Me.mapControl1.Size = New System.Drawing.Size(694, 565)
            Me.mapControl1.TabIndex = 0
            ' 
            ' listBox1
            ' 
            Me.listBox1.FormattingEnabled = True
            Me.listBox1.Location = New System.Drawing.Point(712, 0)
            Me.listBox1.Name = "listBox1"
            Me.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
            Me.listBox1.Size = New System.Drawing.Size(286, 316)
            Me.listBox1.TabIndex = 1
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(712, 323)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(286, 24)
            Me.button1.TabIndex = 2
            Me.button1.Text = "Calculate"
            Me.button1.UseVisualStyleBackColor = True
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(712, 376)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(35, 13)
            Me.label1.TabIndex = 3
            Me.label1.Text = "label1"
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(712, 405)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(35, 13)
            Me.label2.TabIndex = 4
            Me.label2.Text = "label2"
            ' 
            ' button2
            ' 
            Me.button2.Location = New System.Drawing.Point(896, 542)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(102, 23)
            Me.button2.TabIndex = 5
            Me.button2.Text = "Clear"
            Me.button2.UseVisualStyleBackColor = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1010, 577)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.listBox1)
            Me.Controls.Add(Me.mapControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.mapControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private WithEvents mapControl1 As DevExpress.XtraMap.MapControl
        Private listBox1 As System.Windows.Forms.ListBox
        Private WithEvents button1 As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private WithEvents button2 As System.Windows.Forms.Button
    End Class
End Namespace

