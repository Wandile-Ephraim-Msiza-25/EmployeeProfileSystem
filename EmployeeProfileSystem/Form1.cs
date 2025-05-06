using System.Data;
using System.Data.SqlClient;

namespace EmployeeProfileSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-ABNI55JM\\SQLEXPRESS;Initial Catalog=TestSP_DB;Integrated Security=True;TrustServerCertificate=True");

        private void button1_Click(object sender, EventArgs e)
        {

            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, contact = textBox7.Text, sex = "";
            double age = double.Parse(textBox4.Text);
            DateTime startdate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec InsertEmp_SP '" + empid + "','" + empname + "','" + city + "','" + age + "','" + sex + "','" + startdate + "','" + contact + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Employee Successfully Inserted...");
            GetEmpList();


        }

        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec ListEmp_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, contact = textBox7.Text, sex = "";
            double age = double.Parse(textBox4.Text);
            DateTime startdate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { sex = "Male"; } else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateEmp_SP '" + empid + "','" + empname + "','" + city + "','" + age + "','" + sex + "','" + startdate + "','" + contact + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Employee Details Successfully Updated...");
            GetEmpList();

        }
    }
}
