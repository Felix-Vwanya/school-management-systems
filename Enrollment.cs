using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoolmanagements
{
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=schoolsdbs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("INSERT INTO entab VALUES(@eid, @studentname, @section, @enrolldate)", con);
                cnn.Parameters.AddWithValue("@eid", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
                cnn.Parameters.AddWithValue("@section", textBox3.Text);
                cnn.Parameters.AddWithValue("@enrolldate", dateTimePicker2.Text);

                cnn.ExecuteNonQuery();
                MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=schoolsdbs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=schoolsdbs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("UPDATE entab SET studentname=@studentname, section=@section, enrolldate=@enrolldate WHERE eid=@eid", con);
                cnn.Parameters.AddWithValue("@eid", int.Parse(textBox1.Text));
                cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
                cnn.Parameters.AddWithValue("@section", textBox3.Text);
                cnn.Parameters.AddWithValue("@enrolldate", dateTimePicker2.Text);

                cnn.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=schoolsdbs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("DELETE FROM entab WHERE eid=@eid", con);
                cnn.Parameters.AddWithValue("@eid", int.Parse(textBox1.Text));

                cnn.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=schoolsdbs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void Enrollment_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=schoolsdbs;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("SELECT * FROM entab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
    }
}
