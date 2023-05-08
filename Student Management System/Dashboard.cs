using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Dashboard : Form
    {
        Functions con;
        public Dashboard()
        {
            InitializeComponent();
            con = new Functions();
            Countstudents();
            CountDepartments();
            CountMale();
        }
        private void Countstudents()
        {
            string Query = "select count (*) as Stud from StudentTb1";
            foreach(DataRow dr in Functions.GetData(Query).Rows)
            {
                StudNumLb1.Text = dr["Stud"].ToString();
            }
          
        }
        private void CountDepartments()
        {
            string Query = "select count (*) as Dep from DepartmentTb1";
            foreach (DataRow dr in Functions.GetData(Query).Rows)
            {
                DepNumLb1.Text = dr["Dep"].ToString();
            }

        }
        private void CountMale()
        {
            string Gen = "Male";
            string Query = "select count (*) as Male from StudentTb1 where StGen= '{0}'";
            Query = string.Format(Query, Gen);
            foreach (DataRow dr in Functions.GetData(Query).Rows)
            {
               MaleStudLb1.Text = dr["Male"].ToString();
            }

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void StudentLb1_Click(object sender, EventArgs e)
        {
        students Obj = new students();
            Obj.Show();
            this.Close();
        }

        private void DepLb1_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

        private void label24_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void StudNumLb1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
