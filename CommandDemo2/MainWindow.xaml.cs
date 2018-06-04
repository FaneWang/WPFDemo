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

namespace CommandDemo2
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

        //这里的问题是：只有一个Requery按钮，但是有两个文本输入框，这里的需求如果是不同时保存两个文本框
        //的内容，就不能通过CommandParameter的方式实现了，此时的CommandBinding是绑定在window上的，
        //这种绑定方式满足不了要求，此时应该将命令绑定分别绑定到两个文本框上，分别绑定存在一些问题

        //第一个问题是需要分别使用两个CommandBinding，实际上可以使用一个，这可以通过资源解决

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            MessageBox.Show("About to save: " + text);
            isDirty[sender] = false;
        }

        private Dictionary<Object, bool> isDirty = new Dictionary<Object, bool>();

        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("属性变化");
            isDirty[sender] = true;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
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



        //private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    string text = ((TextBox)sender).Text;
        //    if (string.IsNullOrEmpty(text))
        //    {
        //        e.CanExecute = false;
        //    }
        //    else
        //    {
        //        e.CanExecute = true;
        //    }
        //}

        //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    string text = ((TextBox)sender).Text;
        //    MessageBox.Show(sender.ToString() + " : " + text);
        //}
    }

    // 利用RoutedUICommand类自定义命令
    public class CustomCommands
    {
        private static RoutedUICommand requery;

        static CustomCommands()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control));
            requery = new RoutedUICommand("Requery", "Requery", typeof(CustomCommands), inputs);
        }

        public static RoutedUICommand Requery
        {
            get { return requery; }
        }
    }

}
