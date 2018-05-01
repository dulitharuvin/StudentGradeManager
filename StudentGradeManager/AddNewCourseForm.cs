using StudentDataModel;
using StudentDataModel.DTO;
using StudentGradeManager.CourseServiceReference;
using System;
using System.Windows.Forms;

namespace StudentGradeManager
{
    public partial class AddNewCourseForm : Form
    {
        public CourseServiceClient courseService = new CourseServiceClient();

        private int courseSaveStatus;
        public int CourseSaveStatus { get => courseSaveStatus; set => courseSaveStatus = value; }

        public Guid loggedInStudentID;

        public AddNewCourseForm()
        {
            InitializeComponent();
        }

        public AddNewCourseForm(Guid studentId)
        {
            this.loggedInStudentID = studentId;
            InitializeComponent();
        }

        public int SaveCourseToDB()
        {
            var newCourse = new CourseDTO
            {
                CourseID = Guid.NewGuid(),
                StudentID = this.loggedInStudentID,
                CourseTitle = courseTitleTextBox.Text.Trim(),
                CourseDescription = courseDescriptionTextBox.Text.Trim()
            };

            var courseEntity = AutoMapper.Mapper.Map<Course>(newCourse);

            return courseService.SaveCourse(courseEntity);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            var result = SaveCourseToDB();
            CourseSaveStatus = result;
            if (result == 1)
            {
                MessageBox.Show("Course Added Successfully",
                    "New Courese Creation Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Something Went Wrong While Adding a New Course!",
                    "New Courese Creation Error",
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
