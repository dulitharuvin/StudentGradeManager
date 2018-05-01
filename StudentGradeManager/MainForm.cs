using StudentDataModel.DTO;
using StudentGradeManager.CourseModuleServiceReference;
using StudentGradeManager.StudentServiceReference;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentGradeManager
{
    public partial class MainForm : Form
    {
        public StudentServiceClient studentService = new StudentServiceClient();
        public CourseModuleServiceClient courseService = new CourseModuleServiceClient();
        public StudentDTO loggedInStudent;
        private List<CourseDTO> studentCourseList;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(StudentDTO loggedInStudent)
        {
            this.loggedInStudent = loggedInStudent;
            InitializeComponent();
            this.studentCourseList = GetStudentCourseList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SummaryForm sm = new SummaryForm();
            sm.Show();
            sm.BringToFront();
        }

        public List<CourseDTO> GetStudentCourseList()
        {
            var studentCourseList = studentService.GetStudentEnrolledCourses(loggedInStudent.StudentID);
            return new List<CourseDTO>(studentCourseList);
        }

        private void newCourseBtn_Click(object sender, EventArgs e)
        {
            AddNewCourseForm newCourseForm = new AddNewCourseForm(loggedInStudent.StudentID);
            newCourseForm.ShowDialog();
            newCourseForm.BringToFront();
            if(newCourseForm.CourseSaveStatus == 1)
            {
                studentCourseList = GetStudentCourseList();
            }
        }
    }
}
