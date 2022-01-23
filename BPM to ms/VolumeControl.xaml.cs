using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BPMtoms
{
    /// <summary>
    /// Interaction logic for VolumeControl.xaml
    /// </summary>
    public partial class VolumeControl : UserControl
    {
        public static readonly DependencyProperty AngleProperty =
        DependencyProperty.Register("Angle", typeof(double), typeof(VolumeControl), new PropertyMetadata());
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value);  }
        }

        public VolumeControl()
        {
            InitializeComponent();
            this.Angle = 120;
            this.MouseLeftButtonDown += new MouseButtonEventHandler(OnMouseLeftButtonDown);
            this.MouseUp += new MouseButtonEventHandler(OnMouseUp);
            this.MouseMove += new MouseEventHandler(OnMouseMove);
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(this);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
        }

        public async void TheEnclosingMethod()
        {
            await Task.Delay(2000);
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.Captured == this)
            {
                double CaptAngle = this.Angle;

                // Get the current mouse position relative to the volume control
                Point currentLocation = Mouse.GetPosition(this);

                // We want to rotate around the center of the knob, not the top corner
                Point knobCenter = new Point(this.ActualHeight / 2, this.ActualWidth / 2);

                // Calculate an angle
                double radians = Math.Atan((currentLocation.Y - knobCenter.Y) /
                                           (currentLocation.X - knobCenter.X));

                this.Angle = radians * 180 / Math.PI;

                this.Angle = CaptAngle + (this.Angle - CaptAngle);

                // Apply a 180 degree shift when X is negative so that we can rotate
                // all of the way around
                if (currentLocation.X - knobCenter.X < 0)
                {
                    this.Angle += 180;
                }

                while(this.Angle >= -90 && this.Angle <= -45)
                {
                    this.Angle = 270;
                }

                while (this.Angle >= -45 && this.Angle <= 0)
                {
                    this.Angle = 1;
                }
                this.Angle = Math.Round(this.Angle);
            }
        }
    }
}
