using StudentDataModel;
using StudentGradeManager.ModuleAssessmentServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentDataModel.Enums.CourseModuleEnum;

namespace StudentGradeManager
{
    public partial class AddAssessmentForm : Form
    {

        public ModuleAssessmentServiceClient courseAssessmentService = new ModuleAssessmentServiceClient();

        private int courseSaveStatus;
        public int CourseSaveStatus { get => courseSaveStatus; set => courseSaveStatus = value; }

        private CourseModule courseModule;

        public int SaveAsessmentToDB()
        {
            var newAssessment = new ModuleAssessment
            {
                ModuleAssessmentID = Guid.NewGuid(),
                CourseModule = courseModule,
                ModuleAssessmentTitle = moduleAssessmentTitleTextBox.Text.Trim(),
                ModuleAssessmentDescription = moduleAssessmentDescriptionTextBox.Text.Trim(),
                Weighting = double.Parse(weightingTextBox.Text.Trim()),
                AssessmentType = (int)Enum.Parse(typeof(CourseLevel), assessmentTypeComboBox.SelectedItem.ToString())
            };

            var moduleEntity = AutoMapper.Mapper.Map<ModuleAssessment>(newAssessment);

            return courseAssessmentService.SaveAssessment(moduleEntity);
        }

        public AddAssessmentForm(CourseModule courseModule)
        {
            this.courseModule = courseModule;
            InitializeComponent();
        }

        private void AddAssessmentForm_Load(object sender, EventArgs e)
        {
            SetAssesmentCombobox();
        }

        private void SetAssesmentCombobox()
        {
            var levelList = Enum.GetNames(typeof(Assessments));
            assessmentTypeComboBox.DataSource = levelList;
        }

        private void saveAssessmentsButton_Click(object sender, EventArgs e)
        {
            var result = SaveAsessmentToDB();
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

        private void submitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
