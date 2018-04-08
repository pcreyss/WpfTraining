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
using System.ComponentModel;
//using System.Collections.ObjectModel;

namespace WpfEvent
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Hive h;
        public MainWindow()
        {
            InitializeComponent();
             h = new Hive("Registry32");


            Binding b = new Binding();
            b.Path = new PropertyPath("RegHive");
            b.Mode = BindingMode.TwoWay;
            CustomConverter cus2converter = new CustomConverter();
            b.Converter = cus2converter;
            b.Source = h;
            cb1.SetBinding(ComboBox.SelectedItemProperty, b);
            

        }

        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {
            textbox1.AppendText("textbox cliqué" + Environment.NewLine);
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox1.AppendText("previous mouse down"+Environment.NewLine);
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            textbox1.AppendText("mouse up" + Environment.NewLine);
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            
            object s = e.OriginalSource;
            object o = e.Source;
            textbox1.AppendText("clic de bouton dans stack panel" + Environment.NewLine);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            h.RegHive = "Registry32";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            h.RegHive = "Registry64";
        }
    }
}
