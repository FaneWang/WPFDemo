using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace WPFDemo
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = this.FindResource("person") as Person;
            if(person != null)
            {
                MessageBox.Show(person.Child.Name);
            }
        }


    }

    [TypeConverterAttribute(typeof(ConvertStringToChildProperty))]
    public class Person
    {
        public string Name { get; set; }
        public Person Child { get; set; }
    }

    public class ConvertStringToChildProperty : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string name = value.ToString();
            Person child = new Person();
            child.Name = name;
            return child;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if(sourceType == typeof(string))
            {
                return true;
            }
            return false;
        }
    }
}
