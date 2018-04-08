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

namespace templates
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void get_logicaltree (object dobject, TreeViewItem tvi)
        {
            
            string name = dobject.GetType().FullName;
            
            TreeViewItem tvi2 = new TreeViewItem();
            tvi2.Header = name;
            tvi.Items.Add(tvi2);

            
            if (dobject is DependencyObject)
            {
                IEnumerable childs = LogicalTreeHelper.GetChildren((DependencyObject)dobject);
                foreach (var item in childs)
                {
                    get_logicaltree(item, tvi2);
                }
            }
           
        }

        public void get_visualtree(object dobject, TreeViewItem tvi)
        {

            string name = dobject.GetType().FullName;

            TreeViewItem tvi2 = new TreeViewItem();
            int nbchilds = VisualTreeHelper.GetChildrenCount((DependencyObject)dobject);
            tvi2.Header = name+" ("+nbchilds.ToString()+" ch)";
            tvi.Items.Add(tvi2);

            if (dobject is DependencyObject)
            {
                
                for (int i = 0; i < nbchilds; i++)
                {
                    get_visualtree(VisualTreeHelper.GetChild((DependencyObject)dobject,i), tvi2);
                }
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            string n = "";
            //IEnumerable i = LogicalTreeHelper.GetChildren(b1);
            //foreach (object item in i)
            //{
            //    n = item.GetType().FullName;
            //}

            tv1.Items.Clear();
            TreeViewItem tvi = new TreeViewItem();
            tvi.Header = "root";
            tv1.Items.Add(tvi);
            get_logicaltree(sp1, tvi);

           


            //DataTemplate dt = b1.ContentTemplate;
            //object o = b1.Content;
            //bool b = b1.HasContent;
            //Style s = b1.Style;

            //tv1.Items.Add("toto");
            //tv1.Items.Add("tata");

            //TreeViewItem tvi1 = new TreeViewItem();
            //tvi1.Header = "group1";
            //tvi1.Name = "groupe1";

            //TreeViewItem tvi2 = new TreeViewItem();
            //tvi2.Header = "group2";
            //tvi2.Name = "groupe2";


            //tv1.Items.Add(tvi1);
            //tv1.Items.Add(tvi2);

            //tv1.SelectedValuePath = "groupe1";

            //tv1.SelectedValuePath = "";
            //int a = 1;

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            //int a = VisualTreeHelper.GetChildrenCount(b2);
            //tbl1.Text = a.ToString();
            tv2.Items.Clear();
            TreeViewItem tvi2 = new TreeViewItem();
            tvi2.Header = "root";
            tv2.Items.Add(tvi2);
            get_visualtree(tbl1, tvi2);
            DataTemplate dt = b2.ContentTemplate;
        }
    }
}
