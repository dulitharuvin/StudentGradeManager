using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGradeManager
{
    public partial class LoginForm : Form
    {
        private StudentRegisterForm studentRegForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            studentRegForm = new StudentRegisterForm();
            studentRegForm.Activate();
            studentRegForm.ShowDialog();
        }
    }
}
