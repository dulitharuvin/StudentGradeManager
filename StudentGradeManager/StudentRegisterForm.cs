using System.Windows.Forms;
using StudentGradeManager.StudentServiceReference;
using StudentDataModel.DTO;
using System;
using StudentDataModel;

namespace StudentGradeManager
{
    public partial class StudentRegisterForm : Form
    {
        public StudentServiceClient studentService = new StudentServiceClient();

        public StudentRegisterForm()
        {
            InitializeComponent();
        }

        public int SaveStudentToDB()
        {
            var newStudent = new StudentDTO
            {
                StudentID = Guid.NewGuid(),
                FirstName = firstNameTxt.Text.Trim(),
                LastName = lastNameTxt.Text.Trim(),
                Email = emailTxt.Text.Trim(),
                Nic = nicTxt.Text.Trim(),
                UserName = userNameTxt.Text.Trim(),
                Password = passwordTxt.Text
            };

            var studentEntity = AutoMapper.Mapper.Map<Student>(newStudent);

            return studentService.SaveStudent(studentEntity);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            var result = SaveStudentToDB();
            if (result == 1)
            {
                MessageBox.Show("Successfully Registered With Student Grade Manager",
                    "Registration Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Something Went Wrong While Registering to Student Grade Manager",
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
