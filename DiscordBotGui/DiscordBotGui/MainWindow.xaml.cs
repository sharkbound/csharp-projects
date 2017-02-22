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
using Newtonsoft.Json;
using DiscordBotGui.Bot;
using DiscordBotGui.Util;
using System.Diagnostics;
using System.IO;
using Discord;
using System.Data;

namespace DiscordBotGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DiscordBotInfo botInfo = new DiscordBotInfo();
        public static DataTable table = new DataTable();
        //public static 

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            if (!ConfigTool.ConfigExist())
                ConfigTool.CreateConfigFile();

            LogGrid.DataContext = table.DefaultView;

            table.Columns.Add("Source");
            table.Columns.Add("Event_Type");
            table.Columns.Add("User");
            table.Columns.Add("Message");

            botInfo.Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logger.ClearLogs();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Logger.LogWarning("testing log", "GUI");
        }
    }
}

/*
<DataGrid.Columns>
                <!--<DataGridTextColumn Header = "Source"  Width="60"/>
                <DataGridTextColumn Header = "Type" Width="50"/>
                <DataGridTextColumn Header = "User" Width="60"/>
                <DataGridTextColumn Header = "Message" Width="460"/>-->
            </DataGrid.Columns>*/