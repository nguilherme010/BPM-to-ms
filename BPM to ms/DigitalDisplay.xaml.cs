using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace quaselaeuespero
{
    /// <summary>
    /// Interaction logic for DigitalDisplay.xaml
    /// </summary>
    public partial class DigitalDisplay : UserControl
    {
        public static readonly DependencyProperty BPMProperty = DependencyProperty.Register("BPM", typeof(Double), typeof(TextBox));

        public string BPM
        {
            get
            {
                return this.GetValue(BPMProperty) as string;
            }
            set
            {
                this.SetValue(BPMProperty, value);
            }
        }
        public DigitalDisplay()
        {
            InitializeComponent();
            
        }
    }
}
