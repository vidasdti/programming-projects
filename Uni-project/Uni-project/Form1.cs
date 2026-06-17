using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Uni_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void myrefresh1()
        {
            //refreshplus stud
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Stud";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView1.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void myrefresh2()
        {
            //refreshplus crs
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Crs";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView2.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void myrefresh3()
        {
            //refreshplus prof
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Prof";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView3.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void myrefresh4()
        {
            //refreshplus clg
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Clg";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView4.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void myrefresh5()
        {
            //refreshplus sec
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Sec";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView5.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uniDataSet6.stud' table. You can move, or remove it, as needed.
            this.studTableAdapter1.Fill(this.uniDataSet6.stud);

            // TODO: This line of code loads data into the 'uniDataSet5.sec' table. You can move, or remove it, as needed.
            this.secTableAdapter.Fill(this.uniDataSet5.sec);
            // TODO: This line of code loads data into the 'uniDataSet4.clg' table. You can move, or remove it, as needed.
            this.clgTableAdapter.Fill(this.uniDataSet4.clg);
            // TODO: This line of code loads data into the 'uniDataSet3.prof' table. You can move, or remove it, as needed.
            this.profTableAdapter1.Fill(this.uniDataSet3.prof);
            // TODO: This line of code loads data into the 'uniDataSet2.prof' table. You can move, or remove it, as needed.
            this.profTableAdapter.Fill(this.uniDataSet2.prof);
            // TODO: This line of code loads data into the 'uniDataSet1.crs' table. You can move, or remove it, as needed.
            this.crsTableAdapter.Fill(this.uniDataSet1.crs);
            // TODO: This line of code loads data into the 'uniDataSet.stud' table. You can move, or remove it, as needed.
         //   this.studTableAdapter.Fill(this.uniDataSet.stud);
           
        }

     

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //for select a row in data grid view
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }


        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //for select a row in data grid view
            textBox12.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void DataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //for select a row in data grid view
            textBox17.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox16.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox15.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox14.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox13.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();

        }

        private void DataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //for select a row in data grid view
            textBox22.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox21.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox20.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox19.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
        }

        private void DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //for select a row in data grid view
            textBox29.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            textBox28.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            textBox27.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            textBox26.Text = dataGridView5.CurrentRow.Cells[3].Value.ToString();
            textBox25.Text = dataGridView5.CurrentRow.Cells[4].Value.ToString();
            textBox24.Text = dataGridView5.CurrentRow.Cells[5].Value.ToString();
        }

        private void DELETEstud_Click(object sender, EventArgs e)
        {
            //delete stud
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from stud where S#=@S#";
                cmd.Parameters.AddWithValue("@S#", dataGridView1.CurrentRow.Cells["sDataGridViewTextBoxColumn"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("delete successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void DELETEcrs_Click_1(object sender, EventArgs e)
        {
            //delete crs
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from crs where C#=@C#";
                cmd.Parameters.AddWithValue("@C#", dataGridView2.CurrentRow.Cells["cDataGridViewTextBoxColumn"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("delete successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
        private void DELETEprof_Click(object sender, EventArgs e)
        {
            //delete prof
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from prof where Pname=@Pname";
                cmd.Parameters.AddWithValue("@Pname", dataGridView3.CurrentRow.Cells["pnameDataGridViewTextBoxColumn"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("delete successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void DELETEclg_Click(object sender, EventArgs e)
        {
            //delete clg
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from clg where Clg#=@Clg#";
                cmd.Parameters.AddWithValue("@Clg#", dataGridView4.CurrentRow.Cells["clgDataGridViewTextBoxColumn3"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("delete successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void DELETEsec_Click(object sender, EventArgs e)
        {
            //delete sec
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Sec where Sec#=@Sec#";
                cmd.Parameters.AddWithValue("@Sec#", dataGridView5.CurrentRow.Cells["secDataGridViewTextBoxColumn"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("delete successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void INSERTstud_Click_1(object sender, EventArgs e)
        {
            //save stud
            try
            {
                SqlConnection cmd = new SqlConnection();
                cmd.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand mycommand = new SqlCommand();
                mycommand.Connection = cmd;
                mycommand.CommandText = "insert into Stud(S#,Sname,City,Avg,Clg#) values (@S#,@Sname,@City,@Avg,@Clg#)";
                mycommand.Parameters.AddWithValue("@S#", textBox1.Text);
                mycommand.Parameters.AddWithValue("@Sname", textBox2.Text);
                mycommand.Parameters.AddWithValue("@City", textBox3.Text);
                mycommand.Parameters.AddWithValue("@Avg", Convert.ToDouble(textBox4.Text));
                mycommand.Parameters.AddWithValue("@Clg#", textBox5.Text);

                cmd.Open();
                mycommand.ExecuteNonQuery();
                cmd.Close();
                MessageBox.Show("Saved Successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void INSERTcrs_Click_1(object sender, EventArgs e)
        {
            //save crs
            try
            {
                SqlConnection cmd = new SqlConnection();
                cmd.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand mycommand = new SqlCommand();
                mycommand.Connection = cmd;
                mycommand.CommandText = "insert into Crs(C#,Cname,Unit,Clg#) values (@C#,@Cname,@Unit,@Clg#)";
                mycommand.Parameters.AddWithValue("@C#", textBox12.Text);
                mycommand.Parameters.AddWithValue("@Cname", textBox11.Text);
                mycommand.Parameters.AddWithValue("@Unit", textBox10.Text);
                mycommand.Parameters.AddWithValue("@Clg#", textBox9.Text);

                cmd.Open();
                mycommand.ExecuteNonQuery();
                cmd.Close();
                MessageBox.Show("Saved Successfully!");

            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }


        private void INSERTprof_Click_1(object sender, EventArgs e)
        {
            //save prof
            try
            {
                SqlConnection cmd = new SqlConnection();
                cmd.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand mycommand = new SqlCommand();
                mycommand.Connection = cmd;
                mycommand.CommandText = "insert into Prof(Pname,Office,Degree,Esp,Clg#) values (@Pname,@Office,@Degree,@Esp,@Clg#)";
                mycommand.Parameters.AddWithValue("@Pname", textBox17.Text);
                mycommand.Parameters.AddWithValue("@Office", textBox16.Text);
                mycommand.Parameters.AddWithValue("@Degree", textBox15.Text);
                mycommand.Parameters.AddWithValue("@Esp", textBox14.Text);
                mycommand.Parameters.AddWithValue("@Clg#", textBox13.Text);

                cmd.Open();
                mycommand.ExecuteNonQuery();
                cmd.Close();
                MessageBox.Show("Saved Successfully!");
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void INSERTclg_Click_1(object sender, EventArgs e)
        {
            //save clg
            try
            {
                SqlConnection cmd = new SqlConnection();
                cmd.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand mycommand = new SqlCommand();
                mycommand.Connection = cmd;
                mycommand.CommandText = "insert into Clg(Clg#,Clgname,Pname,City) values (@Clg#,@Clgname,@Pname,@City)";
                mycommand.Parameters.AddWithValue("@Clg#", textBox22.Text);
                mycommand.Parameters.AddWithValue("@Clgname", textBox21.Text);
                mycommand.Parameters.AddWithValue("@Pname", textBox20.Text);
                mycommand.Parameters.AddWithValue("@City", textBox19.Text);

                cmd.Open();
                mycommand.ExecuteNonQuery();
                cmd.Close();
                MessageBox.Show("Saved Successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

      

        private void INSERTsec_Click_1(object sender, EventArgs e)
        {
            //save sec
            try
            {
                SqlConnection cmd = new SqlConnection();
                cmd.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand mycommand = new SqlCommand();
                mycommand.Connection = cmd;
                mycommand.CommandText = "insert into Sec(Sec#,C#,S#,Term,Pname,Score) values (@Sec#,@C#,@S#,@Term,@Pname,@Score)";
                mycommand.Parameters.AddWithValue("@Sec#", textBox29.Text);
                mycommand.Parameters.AddWithValue("@C#", textBox28.Text);
                mycommand.Parameters.AddWithValue("@S#", textBox27.Text);
                mycommand.Parameters.AddWithValue("@Term", textBox26.Text);
                mycommand.Parameters.AddWithValue("@Pname", textBox25.Text);
                mycommand.Parameters.AddWithValue("@Score", Convert.ToDouble(textBox24.Text));

                cmd.Open();
                mycommand.ExecuteNonQuery();
                cmd.Close();
                MessageBox.Show("Saved Successfully!");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Edit stud
            try
            {
              //  string s1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=";
              //  string s2 = Application.StartupPath +  @" uni.mdf;Integrated Security=True;Connect Timeout=30";
              //  s1 = s1 + s2;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update  Stud set S# = @S#  ,Sname = @Sname , City =@City , Avg = @Avg, Clg# = @Clg#    Where S#=@S# ";
                

                cmd.Parameters.AddWithValue("@S#", textBox1.Text);
                cmd.Parameters.AddWithValue("@Sname", textBox2.Text);
                cmd.Parameters.AddWithValue("@City", textBox3.Text);
                cmd.Parameters.AddWithValue("@Avg", Convert.ToDouble(textBox4.Text));
                cmd.Parameters.AddWithValue("@Clg#", textBox5.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edited Successfully!");
                
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            myrefresh1();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //Edit crs
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Crs Set C#=@C#, Cname=@Cname , Unit=@Unit , Clg#=@Clg# Where C#=@C#";

                cmd.Parameters.AddWithValue("@C#", textBox12.Text);
                cmd.Parameters.AddWithValue("@Cname", textBox11.Text);
                cmd.Parameters.AddWithValue("@Unit", textBox10.Text);
                cmd.Parameters.AddWithValue("@Clg#", textBox9.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edited Successfully!");
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            //Edit prof
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Prof Set Pname=@Pname, Office=@Office, Degree=@Degree , Esp=@Esp, Clg#=@Clg# Where Pname=@Pname";

                cmd.Parameters.AddWithValue("@Pname", textBox17.Text);
                cmd.Parameters.AddWithValue("@Office", textBox16.Text);
                cmd.Parameters.AddWithValue("@Degree", textBox15.Text);
                cmd.Parameters.AddWithValue("@Esp", textBox14.Text);
                cmd.Parameters.AddWithValue("@Clg#", textBox13.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edited Successfully!");
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void Button14_Click(object sender, EventArgs e)
        {
            //Edit clg
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Clg Set Clg#=@Clg#, Clgname=@Clgname, Pname=@Pname, City=@City Where Clg#=@Clg#";

                cmd.Parameters.AddWithValue("@Clg#", textBox22.Text);
                cmd.Parameters.AddWithValue("@Clgname", textBox21.Text);
                cmd.Parameters.AddWithValue("@Pname", textBox20.Text);
                cmd.Parameters.AddWithValue("@City", textBox19.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edited Successfully!");
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            //Edit sec
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Sec Set Sec#=@Sec#, C#=@C#, S#=@S#, Term=@Term, Pname=@Pname, Score=@Score Where Sec#=@Sec#";

                cmd.Parameters.AddWithValue("@Sec#", textBox29.Text);
                cmd.Parameters.AddWithValue("@C#", textBox28.Text);
                cmd.Parameters.AddWithValue("@S#", textBox27.Text);
                cmd.Parameters.AddWithValue("@Term", textBox26.Text);
                cmd.Parameters.AddWithValue("@Pname", textBox25.Text);
                cmd.Parameters.AddWithValue("@Score", Convert.ToDouble(textBox24.Text));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edited Successfully!");
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }


        private void Button4_Click(object sender, EventArgs e)
        {
            //refresh stud
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Stud";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView1.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //refresh crs
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Crs";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView2.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            //refresh prof
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Prof";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView3.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            //refresh clg
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Clg";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView4.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            //refresh sec
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\uni.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Sec";
                DataTable ved = new DataTable();
                SqlDataAdapter ned = new SqlDataAdapter();
                ned.SelectCommand = cmd;
                ned.Fill(ved);
                dataGridView5.DataSource = ved;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Stud_Click(object sender, EventArgs e)
        {

        }

        private void CrsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
