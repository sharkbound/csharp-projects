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
using System.Data;

namespace Metro2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static bool WindowInitialized = false;
        public static DataTable Table = new DataTable();

        (byte a, byte r, byte g, byte b) currColor = (255, 0, 0, 0);

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
            dt.Tick += tickAction;
            dt.Start();

            DispatcherTimer dt2 = new DispatcherTimer();
            dt2.Interval = TimeSpan.FromMilliseconds(500);
            dt2.Tick += rainbowSettings;
            dt2.Start();

            DataGrid1.DataContext = Table.DefaultView;
            Table.Columns.Add("Placeholder");
            Table.Rows.Add("placeholder");

            void tickAction(object tickSender, EventArgs tickArgs)
            {
                double currentVal = ProgBar.Value;
                ProgBar.Value = currentVal >= 90 ? 0 : currentVal + 5;
            }

            void rainbowSettings(object tickSender, EventArgs tickArgs)
            {
                currColor.r = Convert.ToByte(currColor.r + 1);
                currColor.g = Convert.ToByte(currColor.g + 1);
                //currColor.b = Convert.ToByte(currColor.b + 1);
                SettingsTab.Background = ColorUtil.GetSolidColorBrushFromRBG(currColor.a, currColor.r, currColor.g, currColor.b);
            }
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F:
                    ProgBarFlyout.IsOpen = !ProgBarFlyout.IsOpen;
                    break;
            }
        }
    }
}
