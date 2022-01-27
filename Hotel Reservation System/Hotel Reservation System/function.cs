using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotel_Reservation_System
{
    public class function
    {
        //Establishing Connection with Database
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\old\database\HotelReservationSystem.mdf;Integrated Security=True;Connect Timeout=30");
           
            return con;
        }

        //Get Data from Database
        public DataSet getData(String query) 
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //Populate data from user's end to database
        public void setData(String query, String message) 
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(" '"+message+"'","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }   

    }
}

