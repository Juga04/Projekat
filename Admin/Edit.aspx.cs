using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class Edit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LL66673;Initial Catalog=Partizan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                using (conn)
                {
                    conn.Open();
                    ubacipodatke(conn);
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(ex);

            }
        }
        private void ubacipodatke(SqlConnection con)
        {

                string query = "SELECT * FROM igrac";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                GridView1.DataSource = reader;

                GridView1.DataBind();

                reader.Close();
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow != null)
            {
                Label10.Visible = false;
                Panel1.Visible = true;
                TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
                TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
                TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
                TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
                TextBox5.Text = GridView1.SelectedRow.Cells[5].Text;
                TextBox6.Text = GridView1.SelectedRow.Cells[6].Text;
                TextBox7.Text = GridView1.SelectedRow.Cells[7].Text;
                TextBox8.Text = GridView1.SelectedRow.Cells[8].Text;
                TextBox9.Text = GridView1.SelectedRow.Cells[9].Text;
            }
            else
            {
                Label10.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LL66673;Initial Catalog=Partizan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Update(conn,int.Parse(TextBox1.Text),TextBox2.Text,TextBox3.Text,float.Parse(TextBox4.Text),float.Parse(TextBox5.Text),float.Parse(TextBox6.Text),float.Parse(TextBox7.Text),TextBox8.Text,char.Parse(TextBox9.Text));
        }

        private void Update(SqlConnection con,int id, string ime, string prezime, float avgPts, float avgAst, float avgReb, float avgPIR, string BrDresa, char pozicija)
        {
            try {

                using (con) {
                    con.Open();

                    SqlParameter p1 = new SqlParameter();
                    SqlParameter p2 = new SqlParameter();
                    SqlParameter p3 = new SqlParameter();
                    SqlParameter p4 = new SqlParameter();
                    SqlParameter p5 = new SqlParameter();
                    SqlParameter p6 = new SqlParameter();
                    SqlParameter p7 = new SqlParameter();
                    SqlParameter p8 = new SqlParameter();
                    SqlParameter p9 = new SqlParameter();

                    p1.Value = id;
                    p2.Value = ime;
                    p3.Value = prezime;
                    p4.Value = avgPts;
                    p5.Value = avgAst;
                    p6.Value = avgReb;
                    p7.Value = avgPIR;
                    p8.Value = BrDresa;
                    p9.Value = pozicija;

                    p1.ParameterName = "@id";
                    p2.ParameterName = "@ime";
                    p3.ParameterName = "@prezime";
                    p4.ParameterName = "@avgPts";
                    p5.ParameterName = "@avgAst";
                    p6.ParameterName = "@avgReb";
                    p7.ParameterName = "@avgPIR";
                    p8.ParameterName = "@BrDresa";
                    p9.ParameterName = "@pozicija";

                    string query = "UPDATE igrac " +
                                    "SET Ime=@ime,Prezime=@prezime,avgPts=@avgPts,avgReb=@avgReb,avgPIR=@avgPIR,BrDresa=@BrDresa,pozicija=@pozicija" +
                                    " WHERE ID = @id";

                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Parameters.Add(p3);
                    command.Parameters.Add(p4);
                    command.Parameters.Add(p5);
                    command.Parameters.Add(p6);
                    command.Parameters.Add(p7);
                    command.Parameters.Add(p8);
                    command.Parameters.Add(p9);


                    command.ExecuteNonQuery();
                    ubacipodatke(con);
                    Panel1.Visible = false;
                } }
            catch (Exception ex)
            {
                ErrorLabel.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LL66673;Initial Catalog=Partizan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Obrisi(conn,int.Parse(TextBox1.Text));
        }

        private void Obrisi(SqlConnection con, int id)
        {
            try
            {
                using (con)
                {
                    con.Open();
                    string query = "Delete from igrac where ID=@id";
                    SqlParameter p1 = new SqlParameter();
                    p1.Value = id;
                    p1.ParameterName = "@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(p1);
                    cmd.ExecuteNonQuery();
                    ubacipodatke(con);
                    Panel1.Visible = false;
                }
            }
            catch(Exception ex)
            {
                ErrorLabel.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

        }
    }
}