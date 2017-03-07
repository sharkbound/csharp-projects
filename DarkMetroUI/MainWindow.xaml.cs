using MahApps.Metro.Controls;
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
using MahApps.Metro.Controls.Dialogs;
using Utilities;
using System.Timers;
using System.Threading;
using System.Windows.Threading;

using Timer = System.Timers.Timer;

namespace Metro2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static bool WindowInitialized = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            MetroDialogOptions.AnimateShow = false;
            MetroDialogOptions.AnimateHide = false;
            WindowInitialized = true;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(700);
            dt.Tick += (ss, ee) => ProgBar.Value += 1;
            dt.Start();
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F)
                flyout1.IsOpen = !flyout1.IsOpen;
        }
    }
}
