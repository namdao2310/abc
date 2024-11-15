using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_ban_quanao
{
    internal class Ketnoi
    {
        SqlConnection conn;
        public void openConnect()
        {
            string ckn = "Data Source=DESKTOP-J6CIU8L;Initial Catalog=Quanlyquanao;Integrated Security=True";
            conn = new SqlConnection(ckn);
            conn.Open();
        }
        public void closeConnect()
        {
            conn.Close();
        }
        public DataTable readData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnect();
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        dt.Load(rd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnect();
            }
            return dt;
        }
        public void IUD(string sql, SqlParameter[]parameters)
        {
            try
            {
                openConnect() ;
                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters!= null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnect();
            }
        }

        public bool Kttontai(string sql, SqlParameter[] parameters)
        {
            openConnect();
            bool kt = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        kt = rd.HasRows;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnect();
            }
            return kt;
        }
        public DataTable Loc(string sql, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnect(); 
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader rd = cmd.ExecuteReader()) 
                    {
                        dt.Load(rd); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);  
            }
            finally
            {
                closeConnect();  
            }

            return dt;
        }
        
    }
}
