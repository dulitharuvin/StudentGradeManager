using StudentGradeManager.StudentServiceReference;
using System;
using System.Windows.Forms;

namespace StudentGradeManager
{
    public partial class LoginForm : Form
    {
        private StudentRegisterForm studentRegForm;
        private MainForm mainForm;
        public StudentServiceClient studentService = new StudentServiceClient();

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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (AuthenticateStudentUser())
            {
                this.Hide();
                mainForm = new MainForm();
                mainForm.Closed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Username or Password Incorrect",
                   "User Credentials Incorrect",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ClearLoginForm();
        }

        public bool AuthenticateStudentUser()
        {
            var isUserAuthenticated = studentService.StudentLoginValidate(userName.Text.Trim(), password.Text);
            return isUserAuthenticated;
        }

        public void ClearLoginForm()
        {
            userName.Text = "";
            password.Text = "";
        }

    }
}
