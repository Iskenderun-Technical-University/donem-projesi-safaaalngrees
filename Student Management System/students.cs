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
        private void AddBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
