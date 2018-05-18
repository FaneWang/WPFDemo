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

namespace CommandDemo1_1
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

        private void new_CanExecute(Object sender,CanExecuteRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void new_Executed(Object sender,ExecutedRoutedEventArgs e)
        {
            string name = this.textBox1.Text;
            if(e.Parameter.ToString() == "student")
            {
                this.listBox1.Items.Add(string.Format("New student {0},人丑更改多读书。", name));
            }else if(e.Parameter.ToString() == "teacher")
            {
                this.listBox1.Items.Add(string.Format("New teacher {0},毁人不倦。", name));
            }
        }
    }
}
