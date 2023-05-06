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
    public partial class Departments : Form
    {
        int key = 0;

        public Departments()
        {
            InitializeComponent();
            showDepartments();
        }

        private void showDepartments()
        {
            string Query = "select * from DepartmentTb1";
            Departmentslist.DataSource = Functions.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == "" || DetailsTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "insert into DepartmentTb1 values ('{0}','{1}')";
                    Query = string.Format(Query, DName, Details);
                    Functions.SetData(Query);
                    showDepartments();
                    MessageBox.Show("Department Added !!!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Departmentslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = Departmentslist.SelectedRows[0].Cells[1].Value.ToString();
            DetailsTb.Text = Departmentslist.SelectedRows[0].Cells[2].Value.ToString();

            if (DepNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Departmentslist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == "" || DetailsTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "Update  DepartmentTb1 set DepName = '{0}', DepDetails = '{1}' where DepId = {2}";
                    Query = string.Format(Query, DName, Details, key);
                    Functions.SetData(Query);
                    showDepartments();
                    MessageBox.Show("Department Updated !!!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Department to Delete!!");
            }
            else
            {
                try
                {
                    string Query = "delete from DepartmentTb1 where DepId =" + key + "";
                    Functions.SetData(Query);
                    showDepartments();
                    MessageBox.Show("Department Deleted !!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            DepNameTb.Text = "";
            DetailsTb.Text = "";
            key = 0;
        }

        private void label24_Click(object sender, EventArgs e)
        {
            Login  Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void StudentLb1_Click(object sender, EventArgs e)
        {
            students Obj = new students();
            Obj.Show();
            this.Close();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
          Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Close();
        }
    }
}