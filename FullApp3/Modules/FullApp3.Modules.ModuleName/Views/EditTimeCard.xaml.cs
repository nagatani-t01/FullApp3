using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace FullApp3.Modules.TimeCard.Views
{
    /// <summary>
    /// Interaction logic for EditTimeCard.xaml
    /// </summary>
    public partial class EditTimeCard : UserControl
    {
        public EditTimeCard()
        {
            InitializeComponent();
        }
        private void CopyStartText_Click(object sender, RoutedEventArgs e)
        {
            ClipboardHelper.SetTextWithRetry(StartText.Text);
        }
        private void CopyEndText_Click(object sender, RoutedEventArgs e)
        {
            ClipboardHelper.SetTextWithRetry(EndText.Text);
        }
    }

    public static class ClipboardHelper
    {
        public static void SetTextWithRetry(string text, int retryCount = 10, int delayMilliseconds = 100)
        {
            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    Clipboard.SetText(text);
                    return;
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    Thread.Sleep(delayMilliseconds); // 少し待ってリトライ
                }
            }

            MessageBox.Show("クリップボードにアクセスできませんでした。");
        }
    }
}
