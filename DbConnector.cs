using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Finance {
    public class DbConnector {

        private SqlConnection GetConnection() {
            SqlConnection sqlConnection = new SqlConnection(DBUtils.Connection());
            try {
                sqlConnection.Open();
            } catch (SqlException ex) {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "SQL connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return sqlConnection;
        }

        public string LoadStartDeposit() {
            string data = "0";

            string cmdText = "SELECT Start_deposit From Report ";
            SqlConnection connection = this.GetConnection();
            SqlCommand command = new SqlCommand(cmdText, connection);

            data = Convert.ToString(command.ExecuteScalar());
            return data;
        }

        public string LoadDeposit() {
            string data = "0";

            string cmdText = "SELECT Deposit From Report ";
            SqlConnection connection = this.GetConnection();
            SqlCommand command = new SqlCommand(cmdText, connection);

            data = Convert.ToString(command.ExecuteScalar());
            return data;
        }

        public string LoadPercentDeposit(float SD, float D) {

            return (((D - SD) / SD) * 100).ToString();
        }

        public string FuturesFilter(string futures) {
            string data = "0";

            string cmdText = "select sum(profit) from Finance where futures = @futures";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@futures", SqlDbType.VarChar).Value = (object)futures;
            data = Convert.ToString(sqlCommand.ExecuteScalar());
            return (float.Parse(data) + float.Parse(LoadStartDeposit())).ToString();
        }

        public string DateFilters(string firstDate, string secondDate) {
            string data = "0";

            string cmdText = "select sum(profit) from Finance where date_now >= @firstDate and date_now <= @secondDate";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@firstDate", SqlDbType.Date).Value = (object)firstDate;
            sqlCommand.Parameters.Add("@secondDate", SqlDbType.Date).Value = (object)secondDate;
            data = Convert.ToString(sqlCommand.ExecuteScalar());
            return (float.Parse(data) + float.Parse(LoadStartDeposit())).ToString();
        }

        public string AllFilters(string futures, string firstDate, string secondDate) {
            string data = "0";

            string cmdText = "select sum(profit) from Finance where futures = @futures and date_now >= @firstDate and date_now <= @secondDate";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@futures", SqlDbType.VarChar).Value = (object)futures;
            sqlCommand.Parameters.Add("@firstDate", SqlDbType.Date).Value = (object)firstDate;
            sqlCommand.Parameters.Add("@secondDate", SqlDbType.Date).Value = (object)secondDate;
            data = Convert.ToString(sqlCommand.ExecuteScalar());
            return (float.Parse(data) + float.Parse(LoadStartDeposit())).ToString();
        }

        public void AddFutures(string futures) {
            string cmdText = "INSERT INTO Futures (Name) VALUES (@futures)";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@futures", SqlDbType.VarChar).Value = (object)futures;
            try {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Added Successfully!", "Futures Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } catch (SqlException ex) {
                if (ex.Number == 2627) {

                } else {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add Futures", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
            connection.Close();
        }

        public void DeleteFutures(string futures) {
            string cmdText = "DELETE FROM Futures WHERE Name = @futures";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@futures", SqlDbType.VarChar).Value = (object)futures;
            try {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Delete Successfully!", "Futures deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } catch (SqlException ex) {
                if (ex.Number == 2627) {

                } else {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Delete Futures", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
            connection.Close();
        }

        public void EditFutures(string futures, string newFutures) {
            string cmdText = "Update Futures Set Name = @newFutures where Name = @Futures";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@futures", SqlDbType.VarChar).Value = (object)futures;
            sqlCommand.Parameters.Add("@newFutures", SqlDbType.VarChar).Value = (object)newFutures;
            try {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Edit Successfully!", "Futures edited", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } catch (SqlException ex) {
                if (ex.Number == 2627) {

                } else {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Edit Futures", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

            }
            connection.Close();
        }

        public bool AddProfit(string date_now, string profit, string futures) {
            string cmdText = "INSERT INTO Finance (date_now, profit, futures) VALUES (@date_now, @profit, @futures)";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@date_now", SqlDbType.Date).Value = (object)date_now;
            sqlCommand.Parameters.Add("@profit", SqlDbType.Float).Value = (object)profit;
            sqlCommand.Parameters.Add("@futures", SqlDbType.VarChar).Value = (object)futures;
            try {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Added Successfully!", "Finance Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } catch (SqlException ex) {
                if (ex.Number == 2627) {

                } else {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add Finance", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool AddDeposite() {
            string data = "0";
            string start_data = "0";
            string cmdText = "select sum(profit) from Finance";
            SqlConnection connection = this.GetConnection();
            SqlCommand command = new SqlCommand(cmdText, connection);
            data = Convert.ToString(command.ExecuteScalar());
            start_data = LoadStartDeposit();
            data = (float.Parse(LoadStartDeposit()) + float.Parse(data)).ToString();
            cmdText = "Update Report set Deposit =@data where id='1'";
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@data", SqlDbType.VarChar).Value = (object)data;
            try {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Added Successfully!", "Deposit Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } catch (SqlException ex) {
                if (ex.Number == 2627) {

                } else {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add deposit", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public void edidStartDeposit(string StartDeposit) {
            string cmdText = "UPDATE Report SET Start_deposit = @Start_deposit where id = '1'";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@Start_deposit", SqlDbType.Float).Value = (object)StartDeposit;
            try {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Updated Successfully!", "Report Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } catch (SqlException ex) {

                int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Update Report", MessageBoxButtons.OK, MessageBoxIcon.Hand);


            }
            connection.Close();

        }

    }
}

        
