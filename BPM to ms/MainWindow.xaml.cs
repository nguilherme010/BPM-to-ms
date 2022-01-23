using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Diagnostics;
using AutoUpdaterDotNET;

namespace BPMtoms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty WhosOnProperty =
            DependencyProperty.Register("WhosOn", typeof(string), typeof(MainWindow), 
                new PropertyMetadata(WhosOnChanged));

        public string WhosOn
        {
            get { return (string)GetValue(WhosOnProperty); }
            set { SetValue(WhosOnProperty, value); }
        }

        public static readonly DependencyProperty WhosOn2Property =
            DependencyProperty.Register("WhosOn2", typeof(string), typeof(MainWindow),
                new PropertyMetadata(WhosOn2Changed));

        public string WhosOn2
        {
            get { return (string)GetValue(WhosOn2Property); }
            set { SetValue(WhosOn2Property, value); }
        }


        public MainWindow()
        {
            AutoUpdater.UpdateFormSize = new System.Drawing.Size(600, 300);
            AutoUpdater.Start("https://github.com/nguilherme010/BPMtoms/raw/main/appcast/autoupdate.xml");
            InitializeComponent();



        }
        private static void WhosOnChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
                MainWindow form = o as MainWindow;
                if (form != null)
                {
                    form.WhosOnChanged((string)e.OldValue, (string)e.NewValue);
                }
        }
        public double tritted = 1;
        protected virtual void WhosOnChanged(string OldValue, string NewValue)
        {

            if (WhosOn != "Botão6")
            {
                Botão6OFF.Visibility = Visibility.Visible;
                Botão6ON.Visibility = Visibility.Hidden;
            }

            if (WhosOn != "Botão5")
            {
                Botão5OFF.Visibility = Visibility.Visible;
                Botão5ON.Visibility = Visibility.Hidden;
            }

            if (WhosOn != "Botão4")
            {
                Botão4OFF.Visibility = Visibility.Visible;
                Botão4ON.Visibility = Visibility.Hidden;
            }

            if (WhosOn != "Botão3")
            {
                Botão3OFF.Visibility = Visibility.Visible;
                Botão3ON.Visibility = Visibility.Hidden;
            }

            if (WhosOn != "Botão2")
            {
                Botão2ON.Visibility = Visibility.Hidden;
                Botão2OFF.Visibility = Visibility.Visible;
            }

            if(WhosOn != "Botão1")
            {
                Botão1OFF.Visibility = Visibility.Visible;
                Botão1ON.Visibility = Visibility.Hidden;
            }

            TextoResult.Text = Convert.ToString(Math.Round((60000 / Convert.ToDouble(BPM.Content) ) * MultString(WhosOn) * tritted));
        }


        private static void WhosOn2Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MainWindow form = o as MainWindow;
            if (form != null)
            {
                form.WhosOn2Changed((string)e.OldValue, (string)e.NewValue);
            }
        }
        protected virtual void WhosOn2Changed(string OldValue, string NewValue)
        {
            if (WhosOn2 != "Triplet")
            {
                TripletOFF.Visibility = Visibility.Visible;
                TripletON.Visibility = Visibility.Hidden;
            }

            if (WhosOn2 != "Dotted")
            {
                DottedOFF.Visibility = Visibility.Visible;
                DottedON.Visibility = Visibility.Hidden;
            }

            TextoResult.Text = Convert.ToString(Math.Round((60000 / Convert.ToDouble(BPM.Content)) * MultString(WhosOn) * tritted));
        }

            private double MultString(string str)
        {
               switch (str)
            {
                case "Botão1":
                    return 4;

                case "Botão2":
                    return 2;

                case "Botão3":
                    return 1;

                case "Botão4":
                    return 0.5;

                case "Botão5":
                    return 0.25;
                    
                case "Botão6":
                    return 0.125;
                    

                default:
                    return 0;
                    
            }
        }
        public double tempResult;
        public bool valid = false;
        
        private void Copy_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CopyOFF.Visibility = Visibility.Hidden;
            CopyON.Visibility = Visibility.Visible;
            if (TextoResult.Text != "")
            {
                while (valid == false)
                {
                    if (InAnimation == false)
                    {
                        valid = double.TryParse(TextoResult.Text, out tempResult);
                        if (TextoResult.Text != "")
                        {
                            Clipboard.SetText(TextoResult.Text);
                            CopiedAnimation();
                            TheEnclosingMethod();
                        }
                        else
                        {

                        }
                    }
                    else { }

                }
            }
        }
        public bool InAnimation;
        public async void CopiedAnimation()
        {
            
            InAnimation = true;
            TextoResult.Text = "      C";
            await Task.Delay(75);
            TextoResult.Text = "     Co";
            await Task.Delay(75);
            TextoResult.Text = "    Cop";
            await Task.Delay(75);
            TextoResult.Text = "   Copi";
            await Task.Delay(75);
            TextoResult.Text = "  Copie";
            await Task.Delay(75);
            TextoResult.Text = " Copied";
            await Task.Delay(75);
            TextoResult.Text = "Copied!";
            InAnimation = false;

        }
        public async void TheEnclosingMethod()
        {
            TextoResult.LineHeight = 72;
            await Task.Delay(1000);
            TextoResult.FontSize = 72;
            TextoResult.Text = Convert.ToString(tempResult);
            valid = false;

        }

        private void Copy_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CopyOFF.Visibility = Visibility.Visible;
            CopyON.Visibility = Visibility.Hidden;
        }

        private void Botão1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WhosOn = "Botão1";
            Botão1ON.Visibility = Visibility.Visible;
            Botão1OFF.Visibility = Visibility.Hidden;
        }

        private void Botão2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WhosOn = "Botão2";
            Botão2ON.Visibility = Visibility.Visible;
            Botão2OFF.Visibility = Visibility.Hidden;
        }

        private void Botão3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WhosOn = "Botão3";
            Botão3ON.Visibility = Visibility.Visible;
            Botão3OFF.Visibility = Visibility.Hidden;
        }

        private void Botão4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WhosOn = "Botão4";
            Botão4ON.Visibility = Visibility.Visible;
            Botão4OFF.Visibility = Visibility.Hidden;
        }

        private void Botão5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WhosOn = "Botão5";
            Botão5ON.Visibility = Visibility.Visible;
            Botão5OFF.Visibility = Visibility.Hidden;
        }

        private void Botão6_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WhosOn = "Botão6";
            Botão6ON.Visibility = Visibility.Visible;
            Botão6OFF.Visibility = Visibility.Hidden;
        }

        private void Dotted_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DottedON.Visibility == Visibility.Hidden)
            {
                tritted = 1.5;
                WhosOn2 = "Dotted";
                DottedON.Visibility = Visibility.Visible;
                DottedOFF.Visibility = Visibility.Hidden;
                TripletON.Visibility = Visibility.Hidden;
                TripletOFF.Visibility = Visibility.Visible;
            }
            else if (DottedON.Visibility == Visibility.Visible)
            {
                tritted = 1;
                WhosOn2 = "Normal";
                DottedON.Visibility = Visibility.Hidden;
                DottedOFF.Visibility = Visibility.Visible;
            }
        }

        private void Triplet_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TripletON.Visibility == Visibility.Hidden)
            {
                tritted = 0.66666666;
                WhosOn2 = "Triplet";
                TripletON.Visibility = Visibility.Visible;
                TripletOFF.Visibility = Visibility.Hidden;
                DottedON.Visibility = Visibility.Hidden;
                DottedOFF.Visibility = Visibility.Visible;
            }
            else if (TripletON.Visibility == Visibility.Visible)
            {
                tritted = 1;
                WhosOn2 = "Normal";
                TripletON.Visibility = Visibility.Hidden;
                TripletOFF.Visibility = Visibility.Visible;
            }
        }

        private void BPMTexto_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            TextoResult.Text = Convert.ToString(Math.Round((60000 / Convert.ToDouble(BPM.Content)) * MultString(WhosOn) * tritted));
        }

        private void Credit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/nguilherme010/BPMtoms");
        }
    }

}

