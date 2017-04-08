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
using EncryptionGUI.Util;

namespace EncryptionGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region methods
        void EncryptText()
        {
            if (!string.IsNullOrWhiteSpace(txtEncrypt.Text))
            {
                txtDecrypt.Text = Encryiption.Encode(txtEncrypt.Text, "key_value", offset: 10_000);
            }
        }

        void DecryptText()
        {
            if (!string.IsNullOrWhiteSpace(txtDecrypt.Text))
            {
                txtEncrypt.Text = Encryiption.Decode(txtDecrypt.Text, "key_value", offset: 10_000);
            }
        }
        #endregion

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            EncryptText();
        }

        private void txtEncrypt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                EncryptText();
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            DecryptText();
        }

        private void txtDecrypt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DecryptText();
            }
        }
    }
}
