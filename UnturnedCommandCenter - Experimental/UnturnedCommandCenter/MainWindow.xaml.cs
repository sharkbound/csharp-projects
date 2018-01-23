using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
using UCC.Extensions;
using UCC.Utilites;
using UCC.ExtraWindows;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace UCC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TcpClient client { get; private set; }
        public static NetworkStream NwStream { get; private set; }
        public static MainWindow Instance { get; private set; }
        public static bool IgnoreNextRecieved = false;

        int lastVisableLine = 0;
        int lastCmdHistoryIndex = 0;
        List<string> commandHistory = new List<string>();
        bool cmdTextboxFocusWasLost = false;
        DateTime forceScrollDT = DateTime.Now;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region functions
        public void Log(string txt)
        {
            //txtServerLog.Document.Blocks.Add(new Paragraph(new Run(txt)));
            txtServerLog.Text += $"{txt}\n";
        }

        public int GetNextHistoryIndex(string mode, int indexOfMatch)
        {
            int index = -1;
            switch (mode.ToLower())
            {
                case "up":
                    if (indexOfMatch > 0)
                    {
                        index = indexOfMatch - 1;
                    }
                    return index;
                case "down":
                    if (indexOfMatch < commandHistory.Count - 1)
                    {
                        index = indexOfMatch + 1;
                    }
                    return index;
                default:
                    return -1;
            }
        }

        public void ClearLog()
        {
            txtServerLog.Text = string.Empty;
        }

        public string[] GetServerLogText(bool stripNL)
        {
            string[] array = txtServerLog.Text.Split('\n').Skip(2).ToArray();
            if (stripNL)
            {
                for (int i = 0; i < array.Length; i++)
                    array[i] = array[i].Trim();
            }
            return array;
        }
        #endregion

        static int reconnectTries = 0;
        private async void Window_Initialized(object sender, EventArgs e)
        {
            txtServerLog.GotFocus += (s, e2) => txtCommandInput.Focus();
            txtCommandInput.LostFocus += (s, e2) => cmdTextboxFocusWasLost = true;
            Instance = this;

            ClearLog();

            Log("\nTrying to connect to RCON...");
            while (true)
            {
                try
                {
                    await Init();
                }
                catch
                {
                    if (reconnectTries > 10)
                    {
                        MessageBox.Show("Could not connect after 10 tries, Check that you have entered the connection info correctly in the config file!\n\n Press OK to exit the program...", "CONNECTION ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        Close();
                    }

                    reconnectTries++;
                    Log($"Connection error. Attempting to reconnect in 5 seconds...");
                    await Task.Delay(5000);
                    ClearLog();
                    Log($"\nAttemping to reconnecting... Try #{reconnectTries}");
                }
            }

        }

        private async Task Init()
        {
            UserConfig.LoadConfig();
            txtServerLog.Background = ColorUtil.GetSolidColorBrushFromHex(UserConfig.Instance.ConsoleBGColor);
            txtServerLog.Foreground = ColorUtil.GetSolidColorBrushFromHex(UserConfig.Instance.TextColor);

            client = new TcpClient();
            await client.ConnectAsync(UserConfig.Instance.Ip, UserConfig.Instance.Port);

            NwStream = client.GetStream();
            string textReceived = await client.Receive();

            ClearLog();
            Log(textReceived.Trim('\n'));

            reconnectTries = 0;

            if (!string.IsNullOrEmpty(textReceived) && textReceived.ToLower().Substring(0, 10) == "rocketrcon")
            {
                await client.SendText($"login {UserConfig.Instance.ServerPass}");
                if (client.Connected)
                    Log($"Connected To RCON!"); //{client.GetEndPointIP()}:{client.GetEndPointPort()}");

                await listenLoop();
            }
        }
        
        private async Task listenLoop()
        {
            while (true)
            {
                string txt = await client.Receive(trimNL: true);
                if (!txt.ToLower().Contains("client has executed command") && !IgnoreNextRecieved)
                    Log(txt);
                IgnoreNextRecieved = false;
            }
        }

        Stopwatch sw = new Stopwatch();
        private void txtServerLog_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmServerLogTextbox == null) return;
            if (!txtServerLog.IsMouseOver || cmServerLogTextbox.IsOpen || DateTime.Now.Subtract(forceScrollDT).TotalSeconds <= 1)
            {
                txtServerLog.ScrollToEnd();
                lastVisableLine = txtServerLog.GetLastVisibleLineIndex();
            }
        }

        private async void txtCommandInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    if (string.IsNullOrEmpty(txtCommandInput.Text)) return;

                    if (currentChatMode == "command")
                        await client.SendText(txtCommandInput.Text);
                    else if (currentChatMode == "broadcast")
                        await client.SendText($"broadcast {txtCommandInput.Text}");

                    if (commandHistory.Contains(txtCommandInput.Text))
                    {
                        commandHistory.RemoveAt(commandHistory.IndexOf(txtCommandInput.Text));
                    }
                    commandHistory.Add(txtCommandInput.Text);
                    txtCommandInput.Text = string.Empty;
                    break;
                case Key.Escape:
                    btnToggleInputMode.Focus();
                    break;
            }
        }

        private void txtCommandInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool clear = false;
            switch (e.Key)
            {
                case Key.Up:
                    if (commandHistory.Count == 0) return;

                    if (cmdTextboxFocusWasLost)
                        lastCmdHistoryIndex = commandHistory.Count == 1 ? 0 : commandHistory.Count - 1;

                    int index = lastCmdHistoryIndex;
                    string text = txtCommandInput.Text.Trim();

                    if (commandHistory.Contains(text))
                    {
                        int indexOfMatch = commandHistory.IndexOf(text);
                        index = GetNextHistoryIndex("up", indexOfMatch);

                        if (index == -1)
                            clear = true;
                        else
                            txtCommandInput.Text = commandHistory[index];
                    }
                    else
                    {
                        txtCommandInput.Text = commandHistory.Count > 0 ? commandHistory[commandHistory.Count - 1] : commandHistory[0];
                    }

                    e.Handled = true;
                    cmdTextboxFocusWasLost = false;
                    break;

                case Key.Down:
                    if (commandHistory.Count == 0) return;

                    if (cmdTextboxFocusWasLost)
                        lastCmdHistoryIndex = commandHistory.Count == 1 ? 0 : commandHistory.Count - 1;

                    index = lastCmdHistoryIndex;
                    text = txtCommandInput.Text.Trim();

                    if (commandHistory.Contains(text))
                    {
                        int indexOfMatch = commandHistory.IndexOf(text);
                        index = GetNextHistoryIndex("down", indexOfMatch);

                        if (index == -1)
                            clear = true;
                        else
                            txtCommandInput.Text = commandHistory[index];
                    }
                    else
                    {
                        txtCommandInput.Text = commandHistory[0];
                    }

                    e.Handled = true;
                    cmdTextboxFocusWasLost = false;
                    break;
            }

            if (clear)
                txtCommandInput.Text = string.Empty;
            clear = false;
        }

        string currentChatMode = "command";
        private void btnToggleInputMode_Click(object sender, RoutedEventArgs e)
        {
            if (currentChatMode == "command")
            {
                currentChatMode = "broadcast";
                btnToggleInputMode.Content = "Broadcast";
            }
            else
            {
                currentChatMode = "command";
                btnToggleInputMode.Content = "Command";
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow().Show();
        }

        private void btnClearChatLog_Click(object sender, RoutedEventArgs e)
        {
            ClearLog();
        }
        
        private void btnDumpChatLog_Click(object sender, RoutedEventArgs e)
        {
            DirUtil.CreateDirectoryIfNotExist("ServerChatDump");
            File.WriteAllLines("ServerChatDump/serverchatdump.txt", GetServerLogText(true));
        }

        private async void cmCommandPlayers_Click(object sender, RoutedEventArgs e)
        {
            await client.SendText("players");
            forceScrollDT = DateTime.Now;
        }

        private async void cmCommandOnline_Click(object sender, RoutedEventArgs e)
        {
            await client.SendText("online");
            forceScrollDT = DateTime.Now;
        }

        private void TxtCommandInput_cmClearText_Click(object sender, RoutedEventArgs e)
        {
            txtCommandInput.Text = string.Empty;
        }
    }
}
