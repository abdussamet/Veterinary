using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinary.Helpers;
using Veterinary.Models;
using System.Data.SqlClient;

namespace Veterinary.Helpers
{
    public class DBCRUD
    {
        public int Create(Patient Pent)
        {
            int Result = 0;
            SqlConnection conn = new DBConnect().Connect();
            string insertQry = "insert into patient(Adi,ResimYolu,Sahibi,Cins,Tani)values(@Adi,@ResimYolu,@Sahibi,@Cins,@Tani)";
            SqlCommand cmd = new SqlCommand(insertQry, conn);
            cmd.Parameters.AddWithValue("@Adi", Pent.Adi);
            cmd.Parameters.AddWithValue("@ResimYolu", Pent.ResimYolu);
            cmd.Parameters.AddWithValue("@Sahibi", Pent.Sahibi);
            cmd.Parameters.AddWithValue("@Cins", Pent.Cins);
            cmd.Parameters.AddWithValue("@Tani", Pent.Tani);
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                Result = 1;
            }
            conn.Close();
            return Result;
        }

        internal List<Patient> List()
        {
            List<Patient> PList = new List<Patient>();
            SqlConnection conn = new DBConnect().Connect();
            string ListQry = "select * from patient";
            SqlCommand cmd = new SqlCommand(ListQry,conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PList.Add(new Patient {
                    ID = dr.GetInt32(0),
                    Adi = dr.GetString(1),
                    ResimYolu = dr.GetString(2),
                    Sahibi = dr.GetString(3),
                    Cins = dr.GetString(4),
                    Tani = dr.GetString(5)
                });
            }
            dr.Close();
            conn.Close();
            return PList;
        }

        public void Read(Patient Pent)
        {
            List<Patient> Paent = new List<Patient>();
            SqlConnection conn = new DBConnect().Connect();
            string ReadQRY = "select * from patient";
            SqlCommand cmd = new SqlCommand(ReadQRY, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Paent.Add(new Patient
                {
                    ID = dr.GetInt32(0),
                    Adi = dr.GetString(1),
                    ResimYolu = dr.GetString(2),
                    Sahibi = dr.GetString(3),
                    Cins = dr.GetString(4),
                    Tani = dr.GetString(5)
                });
            }
            dr.Close();
            conn.Close();
        }

        public int Update(int ID, Patient Pent)
        {
            int Result = 0;
            SqlConnection conn = new DBConnect().Connect();
            string UpdateQry = "update patient set Adi=@Adi,Sahibi=@Sahibi,Cins=@Cins,Tani=@Tani where ID=@ID";
            SqlCommand cmd = new SqlCommand(UpdateQry, conn);
            cmd.Parameters.AddWithValue("@Adi", Pent.Adi);
            cmd.Parameters.AddWithValue("@Sahibi", Pent.Sahibi);
            cmd.Parameters.AddWithValue("@Cins", Pent.Cins);
            cmd.Parameters.AddWithValue("@Tani", Pent.Tani);
            cmd.Parameters.AddWithValue("@ID", ID);
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                Result = 1;
            }
            conn.Close();
            return Result;
        }

        public int Delete(int ID)
        {
            int Result = 0;
            SqlConnection conn = new DBConnect().Connect();
            string DeleteQry = "delete from patient where ID = @ID";
            SqlCommand cmd = new SqlCommand(DeleteQry, conn);
            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                Result = 1;
            }
            conn.Close();
            return Result;
        }

        internal void Search(string Text)
        {
            List<Patient> Pent = new List<Patient>();
            SqlConnection conn = new DBConnect().Connect();
            string SearchQry = "select * from patient where (Adi like '%@text%' or Sahibi like '%@Text%' or Cins '%@Text%' or Tani '%@Text%')";
            SqlCommand cmd = new SqlCommand(SearchQry, conn);
            cmd.Parameters.AddWithValue("@Text", Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pent.Add(new Patient
                {
                    ID = dr.GetInt32(0),
                    Adi = dr.GetString(1),
                    ResimYolu = dr.GetString(2),
                    Sahibi = dr.GetString(3),
                    Cins = dr.GetString(4),
                    Tani = dr.GetString(5)
                });
            }
            dr.Close();
            conn.Close();
        }

    }
}