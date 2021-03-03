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

namespace MVVM_exp
{
    /// <summary>
    /// Interaction logic for MyListItemControl.xaml
    /// </summary>
    public partial class MyListItemControl : UserControl
    {
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation", typeof(string), typeof(MyListItemControl), new PropertyMetadata("Horizontal"));

        public string Orientation
        {
            get { return (string) GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public MyListItemControl()
        {
            InitializeComponent();
        }
    }
}
