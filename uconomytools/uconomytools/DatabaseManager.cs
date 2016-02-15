using MySql.Data.MySqlClient;
using Rocket.Core.Logging;
using System;

namespace uconomytools
{
    public class DatabaseManager
    {
        public int port = UcTools.instance.Configuration.Instance.port;
        public string Address = UcTools.instance.Configuration.Instance.ServerAddress;
        public string username = UcTools.instance.Configuration.Instance.username;
        public string password = UcTools.instance.Configuration.Instance.password;

        internal DatabaseManager()
        {
            new I18N.West.CP1250(); //Workaround for database encoding issues with mono
            CheckSchema();
        }

        internal void CheckSchema()
        {
            try
            {
                MySqlConnection connection = createConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "show tables like '" + "uconomy" + "'";
                connection.Open();
                object test = command.ExecuteScalar();

                if (test == null)
                {
                    command.CommandText = "CREATE TABLE `" + "uconomy" + "` (`steamId` varchar(32) NOT NULL,`balance` decimal(15,2) NOT NULL DEFAULT '25.00',`lastUpdated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,PRIMARY KEY (`steamId`)) ";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        private MySqlConnection createConnection()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(String.Format("SERVER=" + Address + ";DATABASE=unturned;UID=" + username + ";PASSWORD=" + password + ";PORT=" + port.ToString() +";"));
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return connection;
        }

        /// <summary>
        /// returns the current balance of an account
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public decimal GetBalance(string id)
        {
            decimal output = 0;
            try
            {
                MySqlConnection connection = createConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select `balance` from `" + "uconomy" + "` where `steamId` = '" + id.ToString() + "';";
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) Decimal.TryParse(result.ToString(), out output);
                connection.Close();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return output;
        }

        public void SetBalance(string id, int value)
        {
            decimal output = 0;
            try
            {
                MySqlConnection connection = createConnection();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "update uconomy set balance = '" + value.ToString() + "' where steamId = '" + id + "';";
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) Decimal.TryParse(result.ToString(), out output);
                connection.Close();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            return;
        }

        /// <summary>
        /// Increasing balance to increaseBy (can be negative)
        /// </summary>
        /// <param name="steamId">steamid of the accountowner</param>
        /// <param name="increaseBy">amount to change</param>
        /// <returns>the new balance</returns>
    }
}
