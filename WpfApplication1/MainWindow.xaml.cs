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
using Reactive.Bindings;

namespace WpfApplication1
{
    public class ViewModel
    {
        public ReactiveProperty<string> Text { get; private set; } = new ReactiveProperty<string>("bbbb");

        public ViewModel()
        {

        }
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();

            this._vm = new ViewModel();

            this.DataContext = this._vm;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this._vm.Text.Value = "hogehoge";
        }
    }
}
