using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SquaresWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random;
        //private Image myImage;
        private DrawingVisual drawingVisual;

        public MainWindow()
        {
            InitializeComponent();

            this.random = new Random();

            //this.myImage = new Image();
            this.drawingVisual = new DrawingVisual();
            //this.panel1.Children.Add(myImage);

           

            // this.DrawLine();
            //this.CreateBitmap();

            //this.DrawSquares(null);
        }

        private void CreateBitmap()
        {
            var myImage = new Image();
            var drawingVisual = new DrawingVisual();
            var drawingContext = drawingVisual.RenderOpen();
            //drawingContext.DrawText(text, new Point(2, 2));

            drawingContext.DrawRectangle(new SolidColorBrush(Color.FromRgb(255, 0, 0)), new Pen(), new Rect(new Size(10, 20)));
            drawingContext.Close();

            var bmp = new RenderTargetBitmap(180, 180, 120, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            myImage.Source = bmp;

            this.panel1.Children.Add(myImage);
        }

        private void DrawLine()
        {
            LineGeometry myLineGeometry = new LineGeometry
            {
                StartPoint = new Point(10, 20),
                EndPoint = new Point(100, 130)
            };

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;

            var d = new DrawingImage();
            Canvas.SetLeft(myPath, 120);
            Canvas.SetTop(myPath, 20);

            this.panel1.Children.Add(myPath);
        }

        private void Run(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer();

            
            timer.Tick += this.DrawSquares;
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Start();
        }

        private void DrawSquares(object sender, EventArgs e)
        {
            var s = Stopwatch.StartNew();
            var width = (int)this.panel1.ActualWidth;
            var height = (int)this.panel1.ActualHeight;

            var drawingContext = this.drawingVisual.RenderOpen();

            var numberOfSequares = 120 * 80;

            // drawingContext.DrawRectangle(new SolidColorBrush(Color.FromRgb(255, 255, 255)), null, new Rect(0, 0, width, height));

            for (int i = 0; i < numberOfSequares; i++)
            {
                var x = this.random.Next(width);
                var y = this.random.Next(height);

                var colorNr = this.random.Next(3);

                var r = (byte)this.random.Next(255);
                var g = (byte)this.random.Next(255);
                var b = (byte)this.random.Next(255);

                var color = Color.FromRgb(r, g, b);

                var sizeX = this.random.Next(5) + 5;
                var sizeY = this.random.Next(5) + 5;

                //drawingContext.DrawRectangle(new SolidColorBrush(color), null, new Rect(new Point(x, y), new Size(sizeX, sizeY)));
                drawingContext.DrawEllipse(new SolidColorBrush(color), null, new Point(x, y), sizeX, sizeY);
            }

            drawingContext.Close();
            //var bmp = new RenderTargetBitmap(width, height, 0, 0, PixelFormats.Pbgra32);        
            //bmp.Render(drawingVisual);
            //this.myImage.Source = drawingVisual;

            this.panel1.Children.Clear();
            this.panel1.Children.Add(new VisualHost { Visual = this.drawingVisual });
            s.Stop();
            this.Title = s.ElapsedMilliseconds.ToString();
        }

        public class VisualHost : UIElement
        {
            public Visual Visual { get; set; }

            protected override int VisualChildrenCount
            {
                get { return Visual != null ? 1 : 0; }
            }

            protected override Visual GetVisualChild(int index)
            {
                return Visual;
            }
        }
    }
}
