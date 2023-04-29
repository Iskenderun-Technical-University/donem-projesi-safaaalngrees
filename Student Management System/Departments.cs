using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_managment_system
{
    public partial class Departments : Form
    {
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
                    MessageBox.Show("Departmen Added |||");
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
