﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text "")
            {
                MessageBox.Show("Missing Data!!!");
            }else if (UNameTb.Text == "Admin" && PasswordTb.Text == "Password")
            {
                students Obj = new students();
                Obj.Show();
                this.Hide();
            }else  
            {
                UNameTb.Text = "";
                PasswordTb.Text = "";

            }
        }
    }
}
