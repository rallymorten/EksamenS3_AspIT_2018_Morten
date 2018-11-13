using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace IO
{
    public class ClassDB
    {
        private SqlConnection myConnection;

        public ClassDB()
        {

        }
        public ClassDB(string inConString)
        {
            SetCon(inConString);
        }
        protected void SetCon(string strCon)
        {
            myConnection = new SqlConnection(strCon);
        }


        private void OpenDB()
        {
            try
            {
                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                else
                {
                    if (myConnection == null)
                    {
                        MessageBox.Show("Der er ikke oprettet nogen 'Connectionstring'");
                    }
                    else
                    {
                        CloseDB();
                        OpenDB();
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }
        }
        private void CloseDB()
        {
            try
            {
                myConnection.Close();
            }
            catch (SqlException)
            {

                throw;
            }
        }
        protected DataTable FunctionExecuteStoredProcedures(string storedProcedure)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenDB();
                using (var cmd = new SqlCommand(storedProcedure, myConnection))
                using (var da = new SqlDataAdapter(cmd))
                {                
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
                CloseDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        protected DataTable FunctionExecuteStoredProcedures(string storedProcedure, string parameterId_1, string parameter_1)
        {
            DataTable dt = new DataTable();
            try
            {

                OpenDB();
                using (var cmd = new SqlCommand(storedProcedure, myConnection))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue(parameterId_1, parameter_1);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
                CloseDB();

                //SqlCommand cmd = new SqlCommand();



                //cmd.CommandText = storedProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue(parameterId_1, parameter_1);
                //OpenDB();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);

                //da.Fill(dt);

                //CloseDB();



            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        protected DataTable FunctionExecuteStoredProcedures(string storedProcedure, string parameterId_1, string parameter_1, string parameterId_2, string parameter_2)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenDB();
                using (var cmd = new SqlCommand(storedProcedure, myConnection))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue(parameterId_1, parameter_1);
                    cmd.Parameters.AddWithValue(parameterId_2, parameter_2);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        protected DataTable FunctionExecuteStoredProcedures(string storedProcedure, string parameterId_1, string parameter_1, string parameterId_2, string parameter_2, string parameterId_3, string parameter_3)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenDB();
                using (var cmd = new SqlCommand(storedProcedure, myConnection))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue(parameterId_1, parameter_1);
                    cmd.Parameters.AddWithValue(parameterId_2, parameter_2);
                    cmd.Parameters.AddWithValue(parameterId_3, parameter_3);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        protected DataTable FunctionExecuteStoredProcedures(string storedProcedure, string parameterId_1, string parameter_1, string parameterId_2, string parameter_2, string parameterId_3, string parameter_3, string parameterId_4, string parameter_4, string parameterId_5, string parameter_5, string parameterId_6, string parameter_6, string parameterId_7, string parameter_7, string parameterId_8, string parameter_8, string parameterId_9, string parameter_9, string parameterId_10, string parameter_10, string parameterId_11, string parameter_11)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenDB();
                using (var cmd = new SqlCommand(storedProcedure, myConnection))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue(parameterId_1, parameter_1);
                    cmd.Parameters.AddWithValue(parameterId_2, parameter_2);
                    cmd.Parameters.AddWithValue(parameterId_3, parameter_3);
                    cmd.Parameters.AddWithValue(parameterId_4, parameter_4);
                    cmd.Parameters.AddWithValue(parameterId_5, parameter_5);
                    cmd.Parameters.AddWithValue(parameterId_6, parameter_6);
                    cmd.Parameters.AddWithValue(parameterId_7, parameter_7);
                    cmd.Parameters.AddWithValue(parameterId_8, parameter_8);
                    cmd.Parameters.AddWithValue(parameterId_9, parameter_9);
                    cmd.Parameters.AddWithValue(parameterId_10, parameter_10);
                    cmd.Parameters.AddWithValue(parameterId_11, parameter_11);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        protected DataTable FunctionExecuteStoredProcedures(string storedProcedure, string parameterId_1, string parameter_1, string parameterId_2, string parameter_2, string parameterId_3, string parameter_3, string parameterId_4, string parameter_4, string parameterId_5, string parameter_5, string parameterId_6, string parameter_6, string parameterId_7, string parameter_7, string parameterId_8, string parameter_8, string parameterId_9, string parameter_9, string parameterId_10, string parameter_10, string parameterId_11, string parameter_11, string parameterId_12, string parameter_12, string parameterId_13, string parameter_13)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenDB();
                using (var cmd = new SqlCommand(storedProcedure, myConnection))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue(parameterId_1, parameter_1);
                    cmd.Parameters.AddWithValue(parameterId_2, parameter_2);
                    cmd.Parameters.AddWithValue(parameterId_3, parameter_3);
                    cmd.Parameters.AddWithValue(parameterId_4, parameter_4);
                    cmd.Parameters.AddWithValue(parameterId_5, parameter_5);
                    cmd.Parameters.AddWithValue(parameterId_6, parameter_6);
                    cmd.Parameters.AddWithValue(parameterId_7, parameter_7);
                    cmd.Parameters.AddWithValue(parameterId_8, parameter_8);
                    cmd.Parameters.AddWithValue(parameterId_9, parameter_9);
                    cmd.Parameters.AddWithValue(parameterId_10, parameter_10);
                    cmd.Parameters.AddWithValue(parameterId_11, parameter_11);
                    cmd.Parameters.AddWithValue(parameterId_12, parameter_12);
                    cmd.Parameters.AddWithValue(parameterId_13, parameter_13);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        protected void FunctionExecuteNonQuery(string strSql)
        {
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                {
                    com.ExecuteNonQuery();
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        protected DataTable DbReturnDataTable(string strsql)
        {
            DataTable dtRes = new DataTable();
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strsql, myConnection))
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    OpenDB();
                    da.Fill(dtRes);
                }
                CloseDB();

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dtRes;
        }
        protected string DbReturnString(string strSql)
        {
            string res = "";
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        res = reader.GetValue(0).ToString();
                    }
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return res;
        }

        protected List<string> DbReturnListString(string strSql)
        {
            List<string> ListRes = new List<string>();

            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                {
                    com.CommandText = strSql;
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                ListRes.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                }
                CloseDB();
            }
            catch (SqlException)
            {

                throw;
            }
            return ListRes;
        }

        protected bool DbReturnBool(string strSql)
        {
            bool res = false;
            try
            {
                OpenDB();
                using (SqlCommand com = new SqlCommand(strSql, myConnection))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        res = Convert.ToBoolean(reader.GetValue(0).ToString());
                    }
                }
                CloseDB();
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return res;
        }
    }
}
