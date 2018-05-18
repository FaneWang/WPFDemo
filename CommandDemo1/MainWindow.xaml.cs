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

namespace CommandDemo1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommmand();
        }

        //创建命令
        private RoutedCommand command = new RoutedCommand("New", typeof(MainWindow));

        //初始化命令的方法
        private void InitializeCommmand()
        {
            //把命令给命令源
            this.button1.Command = this.command;
            this.button2.Command = this.command;
            //给命令指定快捷键
            this.command.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
            //指定命令目标，一个指定，一个不指定，测试是否仍可以运行
            this.button1.CommandTarget = this.textBox1;
            //附带额外信息，用于Excute方法分别执行相同命令的不同动作
            this.button1.CommandParameter = "student";
            this.button2.CommandParameter = "teacher";

            //创建命令关联
            CommandBinding binding = new CommandBinding();
            //指定该关联只关注command这个命令
            binding.Command = this.command;
            //指定命令关联的canExcute处理程序
            binding.CanExecute += new CanExecuteRoutedEventHandler(new_CanExcute);
            binding.Executed += new ExecutedRoutedEventHandler(new_Excuted);

            //将命令关联绑定到外层对象grid上
            this.grid1.CommandBindings.Add(binding);
        }

        private void new_Excuted(object sender, ExecutedRoutedEventArgs e)
        {
            string name = this.textBox1.Text;
            //如果CommandParameter是student执行新建student，是teacher执行teacher
            if(e.Parameter.ToString() == "student")
            {
                this.listBox1.Items.Add(string.Format("New student:{0},人丑更应该学习。",name));
            }else if(e.Parameter.ToString() == "teacher")
            {
                this.listBox1.Items.Add(string.Format("New teacher:{0},毁人不倦。",name));
            }
        }

        private void new_CanExcute(object sender, CanExecuteRoutedEventArgs e)
        {
            //如果第一个文本框没有值命令不可用
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }
    }
}
