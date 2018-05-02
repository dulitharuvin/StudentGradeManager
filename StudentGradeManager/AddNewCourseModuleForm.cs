using StudentDataModel;
using StudentDataModel.DTO;
using StudentGradeManager.CourseModuleServiceReference;
using System;
using System.Windows.Forms;
using static StudentDataModel.Enums.CourseModuleEnum;

namespace StudentGradeManager
{
    public partial class AddNewCourseModuleForm : Form
    {
        public CourseModuleServiceClient courseModuleService = new CourseModuleServiceClient();

        private int moduleSaveStatus;
        public int ModuleSaveStatus { get => moduleSaveStatus; set => moduleSaveStatus = value; }

        private string selectedCourseLevel;
        public string SelectedCourseLevel { get => selectedCourseLevel; set => selectedCourseLevel = value; }

        public Guid selectedCourseId;

        public AddNewCourseModuleForm()
        {
            InitializeComponent();
        }

        public AddNewCourseModuleForm(Guid courseId)
        {
            this.selectedCourseId = courseId;
            InitializeComponent();
            SetLevelComboBox();
            SetModuleTypeComboBox();
        }

        public int SaveCourseModuleToDB()
        {
            var newCourseModule = new CourseModuleDTO
            {
                CourseModuleID = Guid.NewGuid(),
                CourseID = this.selectedCourseId,
                CourseModuleTitle = courseModuleTitleTextBox.Text.Trim(),
                CourseModuleCode = courseModuleCodeTextBox.Text.Trim(),
                CourseModuleDescription = courseModuleDescriptionTextBox.Text.Trim(),
                CourseModuleCreditValue = Convert.ToDouble(courseModuleCreditValueNumericUpDown.Value),
                Level = (int)Enum.Parse(typeof(CourseLevel), levelComboBox.SelectedItem.ToString()),
                ModuleType = (int)Enum.Parse(typeof(ModuleType), moduleTypeComboBox.SelectedItem.ToString()),
                ContributedToFinal = contributedToFinalCheckBox.Checked
            };

            var courseModuleEntity = AutoMapper.Mapper.Map<CourseModule>(newCourseModule);

            return courseModuleService.SaveCourseModule(courseModuleEntity);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            var result = SaveCourseModuleToDB();
            ModuleSaveStatus = result;
            if (result == 1)
            {
                var confirmResult = MessageBox.Show("New Courese Module Creation Success, Do you want to add another", 
                    "Course Module Added Successfully",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (confirmResult == DialogResult.Yes)
                {
                    Utilities.Utilities.ResetAllControls(this);
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("New Courese Module Creation Error",
                    "Something Went Wrong While Adding a New Course Module!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void levelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (levelComboBox.SelectedIndex != -1)
            {
                SelectedCourseLevel = levelComboBox.SelectedItem.ToString();
            }
        }

        public void SetLevelComboBox()
        {
            var levelList = Enum.GetNames(typeof(CourseLevel));
            levelComboBox.DataSource = levelList;
        }

        public void SetModuleTypeComboBox()
        {
            var moduleTypeList = Enum.GetNames(typeof(ModuleType));
            moduleTypeComboBox.DataSource = moduleTypeList;
        }

    }
}
