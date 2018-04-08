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
using System.Collections;
using System.Diagnostics;

namespace tabcontrol
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ControlTemplate cttc1 = tc1.Template;
            
            IEnumerable ch = LogicalTreeHelper.GetChildren(tc1);
            foreach (var item in ch)
            {
                string s =item.GetType().FullName;
                Debug.WriteLine(s);
            }
            TemplateContent tc=  cttc1.Template;
            object r = cttc1.Resources;
            
            
        }
    }
}
