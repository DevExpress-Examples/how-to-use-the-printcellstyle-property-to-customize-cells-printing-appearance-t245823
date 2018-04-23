Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Resources
Imports System.Windows.Media.Imaging
Imports System.Collections.Generic
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Printing
Imports SLGridExample.Model

Namespace SLGridExample
    Partial Public Class MainPage
        Inherits UserControl

        Public Sub New()
            InitializeComponent()

            AddHandler Loaded, AddressOf MainPage_Loaded
        End Sub

        Private Sub MainPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            grid.ItemsSource = New List(Of TestData)() From { _
                New TestData() With {.PlainText = "LMA AG", .MemoText = "Mercedes-Benz SLK " & ControlChars.Lf & " 2004 " & ControlChars.Lf & " Silver", .BooleanMember = True, .Image = GetImage("/SLGridExample;component/Images/1.png")}, _
                New TestData() With {.PlainText = "Western Motors", .MemoText ="Rolls-Royce Corniche " & ControlChars.Lf & " 1975 " & ControlChars.Lf & " Snowy whight", .BooleanMember = False, .Image = GetImage("/SLGridExample;component/Images/2.png")}, _
                New TestData() With {.PlainText = "Sun car rent", .MemoText = "Ford Ranger FX-4" & ControlChars.Lf & " 1999 " & ControlChars.Lf & " Red rock", .BooleanMember = True, .Image = GetImage("/SLGridExample;component/Images/3.png")} _
            }
        End Sub

        Private Function GetImage(ByVal path As String) As ImageSource

            Dim sr As StreamResourceInfo = Application.GetResourceStream(New Uri(path, UriKind.Relative))
            Dim bmp As New BitmapImage()
            bmp.SetSource(sr.Stream)

            Return bmp
        End Function

        Private Sub PrintButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ShowPrintPreview(grid)
        End Sub

        Private Sub ShowPrintPreview(ByVal grid As GridControl)
            Dim preview As New DocumentPreview()
            Dim link As New PrintableControlLink(TryCast(grid.View, IPrintableControl))
            link.ExportServiceUri = "../ExportService.svc"
            Dim model As New LinkPreviewModel(link)
            preview.Model = model

            link.CreateDocument(True)
            Dim dlg As New DXDialog()
            dlg.Content = preview
            dlg.Height = 640
            dlg.Left = 150
            dlg.Top = 150
            dlg.ShowDialog()
        End Sub
    End Class
End Namespace