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
            //check();
            log.Text = string.Empty;
        }

        public void ClearLog(int delay)
        {
            //check();
            Task clearTask = new Task(() =>
            {
                Task.WaitAll(Task.Delay(delay));
                disp.Invoke(() => ClearLog());
            });
            clearTask.Start();
        }
        
        public void Log(string msg, bool clear = false, int delay = 2000)
        {
            //check();
            log.Text = msg;
            if (clear)
                ClearLog(delay);
        }

        public string GetLogText()
        {
            //check();
            return log.Text;
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
