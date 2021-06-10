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
using System.IO;
using System.Reflection;

namespace TestJunRoboKommerc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = tb1.Text.Trim();
                string[] file_list = Directory.GetFiles(path, "*.dll");
                foreach (string file_to_reader in file_list)
                {
                    Assembly ass = Assembly.LoadFrom(file_to_reader);
                    tb2.Text += ass.GetName() + "\n";
                    foreach (Type oType in ass.GetTypes())
                    {
                        tb2.Text += oType.Name + "\n";
                        foreach (MethodInfo members in oType.GetMethods())
                        {
                            if (members.IsFamily || members.IsPublic)
                            {
                                tb2.Text += "-" + members.Name + "\n";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tb2.Text += ex.Message;
            }
        }
    }
}
