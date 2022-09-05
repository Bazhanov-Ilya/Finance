using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Hotel
{
    public class DbConnector
    {
        private bool check = false;
        

        private SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(DBUtils.Connection());
            try
            {
                sqlConnection.Open();
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "SQL connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return sqlConnection;
        }

        public bool IsValidNamePass(string Username, string Password)
        {
            try
            {
                string cmdText = "SELECT User_Name, User_Password FROM User_Table WHERE User_Name = '" + Username + "' AND User_Password = '" + GetHashString(Password) + "'";
                SqlConnection connection = this.GetConnection();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(cmdText, connection));
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();
                if (dataTable.Rows.Count > 0)
                    this.check = true;
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Username and Password", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return this.check;
        }

        public bool IsAdmin(string Username)
        {
            string cmdText = "SELECT User_Name FROM User_Table WHERE User_Name = '" + Username + "' AND User_Is_Admin = 'Yes'";
            SqlConnection connection = this.GetConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(cmdText, connection));
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            connection.Close();
            if (dataTable.Rows.Count > 0)
                this.check = true;
            return this.check;
        }

        public bool AddUser(string Username, string Password, string Admin)
        {
            string cmdText = "INSERT INTO User_Table VALUES (@User_Name, @User_Password, @User_Is_Admin)";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@User_Name", SqlDbType.VarChar).Value = (object)Username;
            sqlCommand.Parameters.Add("@User_Password", SqlDbType.VarChar).Value = (object)GetHashString(Password);
            sqlCommand.Parameters.Add("@User_Is_Admin", SqlDbType.VarChar).Value = (object)Admin;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Added Successfully!", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Username already exist.", nameof(Username), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add User", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool UpdateUser(string ID, string Username, string Password, string Admin)
        {
            string cmdText = "UPDATE User_Table SET User_Name = @UserName, User_Password = @UserPassword, User_Is_Admin = @UserIsAdmin WHERE User_ID = @UserID";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = (object)ID;
            sqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = (object)Username;
            sqlCommand.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = (object)GetHashString(Password);
            sqlCommand.Parameters.Add("@UserIsAdmin", SqlDbType.VarChar).Value = (object)Admin;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Updated Successfully!", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Username already exist.", nameof(Username), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Update User", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool DeleteUser(string ID)
        {
            string cmdText = "DELETE FROM User_Table WHERE User_ID = @UserID";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = (object)ID;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Deleted Successfully!", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            connection.Close();
            return true;
        }

        public void DisplayAndSearch(string query, DataGridView dgv)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(query, this.GetConnection()));
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dgv.DataSource = (object)dataTable;
        }

        public bool AddClient(string FirstName, string LastName, string Phone, string Address)
        {
            string cmdText = "INSERT INTO Client_Table VALUES (@Client_FirstName, @Client_LastName, @Client_Phone, @Client_Address)";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@Client_FirstName", SqlDbType.VarChar).Value = (object)FirstName;
            sqlCommand.Parameters.Add("@Client_LastName", SqlDbType.VarChar).Value = (object)LastName;
            sqlCommand.Parameters.Add("@Client_Phone", SqlDbType.VarChar).Value = (object)Phone;
            sqlCommand.Parameters.Add("@Client_Address", SqlDbType.VarChar).Value = (object)Address;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Added Successfully!", "Client Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Phone No. already exist.", "Phone No.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool UpdateClient(
          string ID,
          string FirstName,
          string LastName,
          string Phone,
          string Address)
        {
            string cmdText = "UPDATE Client_Table SET Client_FirstName = @ClientFirstName, Client_LastName = @ClientLastName, Client_Phone = @ClientPhone, Client_Address = @ClientAddress WHERE Client_ID = @ClientID";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@ClientID", SqlDbType.Int).Value = (object)ID;
            sqlCommand.Parameters.Add("@ClientFirstName", SqlDbType.VarChar).Value = (object)FirstName;
            sqlCommand.Parameters.Add("@ClientLastName", SqlDbType.VarChar).Value = (object)LastName;
            sqlCommand.Parameters.Add("@ClientPhone", SqlDbType.VarChar).Value = (object)Phone;
            sqlCommand.Parameters.Add("@ClientAddress", SqlDbType.VarChar).Value = (object)Address;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Updated Successfully!", "Client Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Phone No. already exist.", "Phone No.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Update Client", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool DeleteClient(string ID)
        {
            string cmdText = "DELETE FROM Client_Table WHERE Client_ID = @ClientID";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@ClientID", SqlDbType.Int).Value = (object)ID;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Deleted Successfully!", "Client Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            connection.Close();
            return true;
        }

        public bool AddRoom(string Type, string Phone, string Free, string Price)
        {
            string cmdText = "INSERT INTO Room_Table VALUES (@Type, @Phone, @Free, @Price)";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = (object)Type;
            sqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar).Value = (object)Phone;
            sqlCommand.Parameters.Add("@Free", SqlDbType.VarChar).Value = (object)Free;
            sqlCommand.Parameters.Add("@Price", SqlDbType.Int).Value = (object)Price;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Added Successfully!", "Room Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Phone No. already exist.", "Phone No.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool UpdateRoom(string No, string Type, string Phone, string Free, string Price)
        {
            string cmdText = "UPDATE Room_Table SET Room_Type = @RoomType, Room_Phone = @RoomPhone, Room_Free = @RoomFree, Room_Price = @Price WHERE Room_Number = @RoomNumber";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@RoomNumber", SqlDbType.Int).Value = (object)No;
            sqlCommand.Parameters.Add("@RoomType", SqlDbType.VarChar).Value = (object)Type;
            sqlCommand.Parameters.Add("@RoomPhone", SqlDbType.VarChar).Value = (object)Phone;
            sqlCommand.Parameters.Add("@RoomFree", SqlDbType.VarChar).Value = (object)Free;
            sqlCommand.Parameters.Add("@Price", SqlDbType.Int).Value = (object)Price;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Updated Successfully!", "Room Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Phone No. already exist.", "Phone No.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Update Room", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool DeleteRoom(string No)
        {
            string cmdText = "DELETE FROM Room_Table WHERE Room_Number = @RoomNumber";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@RoomNumber", SqlDbType.Int).Value = (object)No;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Deleted Successfully!", "Room Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            connection.Close();
            return true;
        }

        public void RoomTypeAndNo(string query, ComboBox cb)
        {
            SqlDataReader sqlDataReader = new SqlCommand(query, this.GetConnection()).ExecuteReader();
            cb.Items.Clear();
            cb.Items.Add((object)"Please select ...");
            cb.SelectedIndex = 0;
            while (sqlDataReader.Read())
                cb.Items.Add(sqlDataReader[0]);
        } 

        public int ReceivePrice(string query, int days)
        {
            int price = 0;
            
            SqlDataReader DataReader = new SqlCommand(query, this.GetConnection()).ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    price= DataReader.GetInt32(0);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            DataReader.Close();

            
            price *= days;

            return price;
            
        }


        public void ItemFromTable(string query, DateTime date)
        {
            SqlDataReader sqlDataReader = new SqlCommand(query, this.GetConnection()).ExecuteReader();
            
            while (sqlDataReader.Read())
                date.Add((TimeSpan)sqlDataReader[0]);
        }
        public void ClientLastName(string query, ComboBox cb)
        {
            SqlDataReader sqlDataReader = new SqlCommand(query, this.GetConnection()).ExecuteReader();
            cb.Items.Clear();
            cb.Items.Add((object)"Please select ...");
            cb.SelectedIndex = 0;
            while (sqlDataReader.Read())
                cb.Items.Add(sqlDataReader[0]);
        }
        public void ClientFirstName(string query, ComboBox cb)
        {
            SqlDataReader sqlDataReader = new SqlCommand(query, this.GetConnection()).ExecuteReader();
            cb.Items.Clear();
            cb.Items.Add((object)"Please select ...");
            cb.SelectedIndex = 0;
            while (sqlDataReader.Read())
                cb.Items.Add(sqlDataReader[0]);
        }

        public void UpdateReservationRoom(string No, string Free)
        {
            string cmdText = "UPDATE Room_Table SET Room_Free = @RoomFree WHERE Room_Number = @RoomNumber";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@RoomNumber", SqlDbType.Int).Value = (object)No;
            sqlCommand.Parameters.Add("@RoomFree", SqlDbType.VarChar).Value = (object)Free;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Update Reservation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            connection.Close();
        }

        public bool AddReservation(string Type, string No, string CID, DateTime In, DateTime Out, string Price)
        {
            string cmdText = "INSERT INTO Reservation_Table VALUES (@Type, @No, @CID, @In, @Out, @Price)";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = (object)Type;
            sqlCommand.Parameters.Add("@No", SqlDbType.Int).Value = (object)No;
            sqlCommand.Parameters.Add("@CID", SqlDbType.Int).Value = (object)CID;
            sqlCommand.Parameters.Add("@In", SqlDbType.DateTime).Value = (object)In;
            sqlCommand.Parameters.Add("@Out", SqlDbType.DateTime).Value = (object)Out;
            sqlCommand.Parameters.Add("@Price", SqlDbType.Int).Value = (object)Price;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Added Successfully!", "Reservation Added", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Client ID already exist.", "Client ID", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool UpdateReservation(
          string RID,
          string Type,
          string No,
          string CID,
          DateTime In,
          DateTime Out)
        {
            string cmdText = "UPDATE Reservation_Table SET Reservation_Room_Type = @ReservationRoomType, Reservation_Room_Number = @ReservationRoomNumber, Reservation_Client_ID = @ReservationClientID, Reservation_In = @ReservationIn, Reservation_Out = @ReservationOut WHERE Reservation_ID = @ReservationID";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@ReservationID", SqlDbType.Int).Value = (object)RID;
            sqlCommand.Parameters.Add("@ReservationRoomType", SqlDbType.VarChar).Value = (object)Type;
            sqlCommand.Parameters.Add("@ReservationRoomNumber", SqlDbType.Int).Value = (object)No;
            sqlCommand.Parameters.Add("@ReservationClientID", SqlDbType.Int).Value = (object)CID;
            sqlCommand.Parameters.Add("@ReservationIn", SqlDbType.DateTime).Value = (object)In;
            sqlCommand.Parameters.Add("@ReservationOut", SqlDbType.DateTime).Value = (object)Out;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Updated Successfully!", "Reservation Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    int num1 = (int)MessageBox.Show("Client ID already exist.", "Client ID", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int num2 = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Update Reservation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                return false;
            }
            connection.Close();
            return true;
        }

        public bool AddHistory(string CID)
        {
            string cmdText = "INSERT INTO History_Table SELECT Reservation_Table.Reservation_ID, Client_Table.Client_FirstName, Client_Table.Client_LastName, Client_Table.Client_Phone, Client_Table.Client_Address, Reservation_Table.Reservation_Room_Type, Reservation_Table.Reservation_Room_Number, Reservation_Table.Reservation_In, Reservation_Table.Reservation_Out, Reservation_Table.Reservation_Price FROM Client_Table INNER JOIN Reservation_Table ON Client_Table.Client_ID = Reservation_Table.Reservation_Client_ID WHERE Client_ID= @Client_ID";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@Client_ID", SqlDbType.Int).Value = (object)CID;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Add History Reservation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            connection.Close();
            return true;
        }

        public bool DeleteReservation(string ID)
        {
            string cmdText = "DELETE FROM Reservation_Table WHERE Reservation_ID = @ReservationID";
            SqlConnection connection = this.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@ReservationID", SqlDbType.Int).Value = (object)ID;
            try
            {
                sqlCommand.ExecuteNonQuery();
                int num = (int)MessageBox.Show("Canceled Successfully!", "Reservation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException ex)
            {
                int num = (int)MessageBox.Show("Error! \n" + ex.ToString(), "Canceled Reservation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            connection.Close();
            return true;
        }

        public int Count(string query) => (int)new SqlCommand(query, this.GetConnection()).ExecuteScalar();

        string GetHashString(string s)
        {
            
            byte[] bytes = Encoding.Unicode.GetBytes(s);

       
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

             
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

             
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
