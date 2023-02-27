using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileworxObjects
{
    public partial class File 
    {
   
        public override void DBUpdate()
        {
           

                if (this.ID > -1)
                {
                    base.DBUpdate();
                    q = $"UPDATE  dbo.T_File SET C_body =\'{this.Body}\' WHERE ID = \'{this.ID}\'; ";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    base.DBUpdate();

                    q = $"INSERT INTO dbo.T_File (C_body,ID) VALUES(\'{this.Body}\',\'{this.ID}\');";
                    cmd = new SqlCommand(q, conn);
                    cmd.ExecuteNonQuery();
                }
            }
          
        public override void DBDelete()
        {
            if (this.ID > -1)
            {
                try
                {



                    q = $"DELETE FROM dbo.T_File WHERE ID =\'{this.ID}\'";
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
            q = $"select * from dbo.T_File where ID = {this.ID}";
            cmd = new SqlCommand(q);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                this.Body = r["C_body"].ToString();

            }
        
        }

    }

}
