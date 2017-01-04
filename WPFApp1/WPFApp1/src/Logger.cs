using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;
using System;
using System.Threading;

namespace App.logging
{
    public class Logger
    {
        TextBlock log = null;
        Dispatcher disp = null;

        public Logger()
        {
            check();
        }

        public void ClearLog()
        {
            disp.Invoke(() =>
            {
                log.Text = string.Empty;
            });
        }

        public void ClearLog(int delay)
        {
            Task.Run(() =>
            {
                Task.WaitAll(Task.Delay(delay));
                disp.Invoke(() => ClearLog());
            });
        }

        public void Log(string msg, bool clear = false, int delay = 2000)
        {
            disp.Invoke(() =>
            {
                log.Text = msg;
                if (clear)
                    ClearLog(delay);
            });
        }

        public string GetLogText()
        {
            disp.Invoke(() =>
            {
                return log.Text;
            });
            return "";
        }

        void check()
        {
            if (log == null)
            {
                log = ((MainWindow)Application.Current.MainWindow).OutputTextBlock;
            }

            if (disp == null)
            {
                disp = ((MainWindow)Application.Current.MainWindow).Dispatcher;
            }
        }
    }
}
