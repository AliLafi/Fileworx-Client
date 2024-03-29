﻿using System;
using System.Data.SqlClient;

namespace FileworxObjects
{
    public partial class File 
    {
        public override void DBUpdate()
        {          
                if (ID > -1)
                {
                    base.DBUpdate();
                    q = $"UPDATE  dbo.T_File SET C_body =\'{Body}\', C_contact = \'{ContactID}\' WHERE ID = \'{ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    base.DBUpdate();
                    q = $"INSERT INTO dbo.T_File (C_body,ID,C_contact) VALUES(\'{Body}\',\'{ID}\',\'{ContactID}\');";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
            }
          
        public override void DBDelete()
        {
            if (ID > -1)
            {
                try
                {
                    q = $"DELETE FROM dbo.T_File WHERE ID =\'{ID}\'";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                    base.DBDelete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public override void DBRead()
        {
            base.DBRead();
            q = $"select * from dbo.T_File where ID = {ID}";
            cmd = new SqlCommand(q,conn);

            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Body = r["C_body"].ToString();
                if (! (r["C_contact"] is null))
                ContactID =int.Parse( r["C_contact"].ToString());
            }

            r.Close();
        }
    }
}
