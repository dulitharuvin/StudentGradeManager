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
            LoadAssessmentFromDB();
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

        private void LoadAssessmentFromDB()
        {
            List<ModuleAssessment> maList = courseAssessmentService.GetData().ToList();
            var tableRow = 1;
            assessmentTableLayoutPanel.RowCount = tableRow + 1;
            foreach (ModuleAssessment assessment in maList)
            {
                assessmentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                Label titleLabel = new Label();
                assessmentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                titleLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                titleLabel.AutoSize = true;
                titleLabel.AutoEllipsis = true;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.Text = assessment.ModuleAssessmentTitle;
                assessmentTableLayoutPanel.Controls.Add(titleLabel, 0, tableRow);

                Label descriptionLabel = new Label();
                assessmentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                descriptionLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                descriptionLabel.AutoSize = true;
                descriptionLabel.AutoEllipsis = true;
                descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
                descriptionLabel.Text = assessment.ModuleAssessmentDescription;
                assessmentTableLayoutPanel.Controls.Add(descriptionLabel, 1, tableRow);

                Label typeLabel = new Label();
                assessmentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                typeLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                typeLabel.AutoSize = true;
                typeLabel.AutoEllipsis = true;
                typeLabel.TextAlign = ContentAlignment.MiddleLeft;
                typeLabel.Text = assessment.AssessmentType + "";
                assessmentTableLayoutPanel.Controls.Add(typeLabel, 2, tableRow);

                Label weightingLabel = new Label();
                assessmentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.09F));
                weightingLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                weightingLabel.AutoSize = true;
                weightingLabel.AutoEllipsis = true;
                weightingLabel.TextAlign = ContentAlignment.MiddleLeft;
                weightingLabel.Text = assessment.Weighting.ToString();
                assessmentTableLayoutPanel.Controls.Add(weightingLabel, 3, tableRow);

                Label resultsLabel = new Label();
                assessmentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.18F));
                resultsLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                resultsLabel.AutoSize = true;
                resultsLabel.AutoEllipsis = true;
                resultsLabel.TextAlign = ContentAlignment.MiddleLeft;
                resultsLabel.Text = "Results here";
                assessmentTableLayoutPanel.Controls.Add(resultsLabel, 4, tableRow);


                Button newAssessmentBtn = new Button();
                assessmentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                newAssessmentBtn.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                newAssessmentBtn.AutoSize = true;
                newAssessmentBtn.Text = "Results +";
                newAssessmentBtn.TextAlign = ContentAlignment.MiddleLeft;
                assessmentTableLayoutPanel.Controls.Add(newAssessmentBtn, 6, tableRow);
                tableRow++;
            }
        }
    }
}
