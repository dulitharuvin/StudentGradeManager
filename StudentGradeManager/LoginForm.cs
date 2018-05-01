using StudentDataModel.DTO;
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
            var loggedInStudent = AuthenticateStudentUser();
            if (loggedInStudent != null)
            {
                this.Hide();
                mainForm = new MainForm(loggedInStudent);
                mainForm.Closed += (s, args) => this.Close();
                mainForm.ShowDialog();
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

        public StudentDTO AuthenticateStudentUser()
        {
            var loggedInStudent = studentService.StudentLoginValidate(userName.Text.Trim(), password.Text);
            return loggedInStudent;
        }

        public void ClearLoginForm()
        {
            userName.Text = "";
            password.Text = "";
        }

    }
}
