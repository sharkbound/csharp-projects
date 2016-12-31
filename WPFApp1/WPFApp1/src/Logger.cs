using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml;

namespace WPFApp1.src
{
    public class Logger
    {
        TextBlock log;
        Dispatcher disp;

        public Logger(ref TextBlock blk, Dispatcher disp)
        {
            log = blk;
            this.disp = disp;

        }

        public void ClearLog()
        {
            log.Text = string.Empty;
        }

        public void ClearLog(int delay)
        {
            Task clearTask = new Task(() =>
            {
                Task.WaitAll(Task.Delay(delay));
                disp.Invoke(() => ClearLog());
            });
            clearTask.Start();
        }

        public void Log(string msg, bool clear = false, int delay = 2000)
        {
            log.Text = msg;
            if (clear)
                ClearLog(delay);
        }

        public void SetColor()
        {

        }

        public string GetLogText()
        {
            return log.Text;
        }

        public void LogToXml(string dir)
        {
        }
    }
}
