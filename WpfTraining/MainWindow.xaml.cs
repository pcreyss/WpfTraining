using System;
using System.Collections;
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

namespace WpfTraining
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string info;
        public static int n = 0;
        static public void EnumVisual(Visual myVisual)
        {
            n += 1;
            int cc = VisualTreeHelper.GetChildrenCount(myVisual);
            info += "niveau " + n.ToString() + Environment.NewLine;
            string typename = myVisual.GetType().Name;
            Type t = myVisual.GetType();
            if (t.FullName == "System.Windows.Controls.Border")
            {
                Border b = (Border)myVisual;
                string name = b.Name;
                Thickness th = (Thickness) b.GetValue(BorderThicknessProperty);
                SolidColorBrush scb = new SolidColorBrush(Colors.Magenta);
                var v = b.GetValue(BackgroundProperty);
                b.SetValue(BackgroundProperty, scb);
                t = v.GetType();
                n += 1;
            }
            if (myVisual is System.Windows.Controls.Border)
            info += " visual : " + myVisual.GetType().Name+" childs:"+ cc.ToString()+ Environment.NewLine;
            
            for (int i = 0; i < cc; i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                // Do processing of the child visual object.
                info += "......"+i.ToString()+ ".."+childVisual.GetType().Name+Environment.NewLine;
                // Enumerate children of the child visual object.
                EnumVisual(childVisual);
            }
            n -= 1;
        }

        public MainWindow()
        {
            InitializeComponent();

            //EnumVisual(lb1);


            int a = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //EnumVisual(lb1);
            //tb2.Text = info;
        }
    }
}
