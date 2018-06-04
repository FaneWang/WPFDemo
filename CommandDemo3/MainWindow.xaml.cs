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

namespace CommandDemo3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            MessageBox.Show("About to save: " + text);
            isDirty[sender] = false;
        }

        private Dictionary<Object, bool> isDirty = new Dictionary<Object, bool>();
        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            isDirty[sender] = true;
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (isDirty.ContainsKey(sender) && isDirty[sender] == true)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}
