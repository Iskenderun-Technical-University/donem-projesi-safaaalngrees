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
    public partial class students : Form
    {
        Functions con;
        public students()
        {
            InitializeComponent();
            con = new Functions();
            showStudents();
            GetDepartment();

        }
        private void showStudents()
        {
            string Query = "select * from studentTb1";
            Studentslist.DataSource = Functions.GetData(Query);
        }
        private void GetDepartment()
        {
            string Query = "select * from DepartmentTb1";
            DepCb.DisplayMember = Functions.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Functions.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Functions.GetData(Query);
        }
        private void clear()
        {
            StNameTb.Text = "";
            StPhoneTb.Text = "";
            StParentTb.Text = "";
            StAddTb.Text = "";
            GenCb.SelectedIndex = -1;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || StPhoneTb.Text == "" ||StParentTb.Text == "" ||StAddTb.Text == "" || DepCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = StPhoneTb.Text;
                    string Parent = StParentTb.Text;
                    string Address = StAddTb.Text;
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "insert into studentTb1 valuse('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, TName, Gender,Phone,Parent,Address,Dep);
                 
                    showStudents();
                    MessageBox.Show("Student Added !!!");
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
