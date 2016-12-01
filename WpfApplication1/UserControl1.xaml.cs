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
using Reactive.Bindings.Extensions;

namespace WpfApplication1
{
    public class UserCtlViewModel
    {
        public ReactiveProperty<string> Text { get; private set; }

        public UserCtlViewModel(ReactiveProperty<string> rp)
        {
            this.Text = rp;
        }
    }

    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private UserCtlViewModel _vm;

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(UserControl1),
                new PropertyMetadata(
                "default text",
                (d, e) => MessageBox.Show("update prop")));

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { MessageBox.Show("test"); this.SetValue(TextProperty, value); }
        }

        public UserControl1()
        {
            InitializeComponent();

            this._vm = new UserCtlViewModel(
                    this.ToReactiveProperty<string>(TextProperty)
                );

            this.DataContext = _vm;
        }
    }
}
