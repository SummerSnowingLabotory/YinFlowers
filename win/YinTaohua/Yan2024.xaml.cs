using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace YinTaohua
{
    /// <summary>
    /// Sp214Window.xaml 的交互逻辑
    /// </summary>
    public partial class Yan2024 : Window
    {
        public Yan2024()
        {
            InitializeComponent();
        }
        public static DependencyObject GetScrollViewer(DependencyObject o)
        {
            // Return the DependencyObject if it is a ScrollViewer
            if (o is ScrollViewer)
            { return o; }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var child = VisualTreeHelper.GetChild(o, i);

                var result = GetScrollViewer(child);
                if (result == null)
                {
                    continue;
                }
                else
                {
                    return result;
                }
            }

            return null;
        }
        private void FlowDocumentScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            DependencyObject scrollHost = sender as DependencyObject;
            var scrollViewer = GetScrollViewer(scrollHost) as ScrollViewer;
            if (scrollViewer != null)
            {
                double offset = scrollViewer.VerticalOffset - (e.Delta * 5d / 6);
                if (offset < 0)
                {
                    scrollViewer.ScrollToVerticalOffset(0);
                }
                else if (offset > scrollViewer.ScrollableHeight)
                {
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.ScrollableHeight);
                }
                else
                {
                    scrollViewer.ScrollToVerticalOffset(offset);
                }

                e.Handled = true;
            }
        }

        static readonly string particles = "吗嘛么喵";
        static readonly string[] emoji = new string[] { "///", "XD", "OwO" };
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!MainWindow.Closing)
            {
                double r = new Random().NextDouble();
                for (int n = r < 0.05 ? 1 : (int)(r * 3) + 2; n > 0; n--)
                {
                    if (MessageBox.Show($"真的要关闭{particles[new Random().Next(0, particles.Length)]}？", "魇桃花", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                        MessageBox.Show("这才对嘛！请继续欣赏“魇桃花”" + emoji[new Random().Next(0, emoji.Length)]);
                        return;
                    }
                }
            }
            base.OnClosing(e);
        }
    }
}
