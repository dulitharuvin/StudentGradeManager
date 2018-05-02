using StudentDataModel;
using StudentDataModel.DTO;
using StudentGradeManager.CourseModuleServiceReference;
using StudentGradeManager.StudentServiceReference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static StudentDataModel.Enums.CourseModuleEnum;

namespace StudentGradeManager
{
    public partial class MainForm : Form
    {
        public StudentServiceClient studentService = new StudentServiceClient();
        public CourseModuleServiceClient courseModuleService = new CourseModuleServiceClient();
        public StudentDTO loggedInStudent;
        public CourseDTO selectedCourse;
        private List<CourseDTO> studentCourseList;
        private List<CourseModuleDTO> level4CourseModuleList;
        private List<CourseModuleDTO> level5CourseModuleList;
        private List<CourseModuleDTO> level6CourseModuleList;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(StudentDTO loggedInStudent)
        {
            this.loggedInStudent = loggedInStudent;
            InitializeComponent();
            this.studentCourseList = GetStudentCourseList();
            SetCourseListDropDown();
            courseSelectCmbBox.SelectedIndex = -1;
            openCourseModule.Enabled = false;
        }

        private void openSummary_Click(object sender, EventArgs e)
        {
            SummaryForm sm = new SummaryForm();
            sm.Show();
            sm.BringToFront();
        }

        private void openCourseModule_Click(object sender, EventArgs e)
        {
            AddNewCourseModuleForm newCourseModule = new AddNewCourseModuleForm(selectedCourse.CourseID);
            newCourseModule.ShowDialog();
            newCourseModule.BringToFront();
            if (newCourseModule.ModuleSaveStatus == 1)
            {
                UpdateCourseModuleList(selectedCourse.CourseID, newCourseModule.SelectedCourseLevel);
            }
        }

        private void newCourseBtn_Click(object sender, EventArgs e)
        {
            AddNewCourseForm newCourseForm = new AddNewCourseForm(loggedInStudent.StudentID);
            newCourseForm.ShowDialog();
            newCourseForm.BringToFront();
            if (newCourseForm.CourseSaveStatus == 1)
            {
                studentCourseList = GetStudentCourseList();
                SetCourseListDropDown();
            }
        }

        private void courseSelectCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (courseSelectCmbBox.SelectedIndex != -1)
            {
                selectedCourse = (CourseDTO)courseSelectCmbBox.SelectedItem;
                EnableNewCourseModuleBtn();
                ProcessLevelTablesOnCourseSelect(selectedCourse.CourseID);
            }
        }

        public List<CourseDTO> GetStudentCourseList()
        {
            var studentCourseList = studentService.GetStudentEnrolledCourses(loggedInStudent.StudentID);
            return new List<CourseDTO>(studentCourseList);
        }

        public void ProcessLevelTablesOnCourseSelect(Guid selectedCourseId)
        {
            var levelList = Enum.GetNames(typeof(CourseLevel));
            foreach (string level in levelList)
            {
                UpdateCourseModuleList(selectedCourseId, level);
            }
        }

        public void UpdateCourseModuleList(Guid selectedCourseId, string selectedModuleLevel)
        {
            var moduleLevel = (int)Enum.Parse(typeof(CourseLevel), selectedModuleLevel);
            AssignCourseModuleLevelLists(selectedCourseId, selectedModuleLevel);
        }

        public void SetCourseListDropDown()
        {
            courseSelectCmbBox.DataSource = studentCourseList;
            courseSelectCmbBox.DisplayMember = "CourseTitle";
        }

        public void EnableNewCourseModuleBtn()
        {
            openCourseModule.Enabled = courseSelectCmbBox.SelectedIndex != -1;
        }

        public void AssignCourseModuleLevelLists(Guid selectedCourseId, string selectedModuleLevel)
        {
            var moduleLevel = (int)Enum.Parse(typeof(CourseLevel), selectedModuleLevel);

            var levelCourseModuleList = new List<CourseModuleDTO>(courseModuleService.GetModulesByCourseAndLevel(selectedCourseId, moduleLevel));

            switch (selectedModuleLevel)
            {
                case "Level4":
                    level4CourseModuleList = levelCourseModuleList;
                    ProcessLevel4Table();
                    break;
                case "Level5":
                    level5CourseModuleList = levelCourseModuleList;
                    ProcessLevel5Table();
                    break;
                case "Level6":
                    level6CourseModuleList = levelCourseModuleList;
                    ProcessLevel6Table();
                    break;
               default:
                    break;
            }
        }

        public void ProcessLevel4Table()
        {
            var tableRow = 1;
            level4TableLayoutPanel.RowCount = tableRow + 1;
            foreach (CourseModuleDTO module in level4CourseModuleList)
            {
                level4TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                Label titleLabel = new Label();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                titleLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                titleLabel.AutoSize = true;
                titleLabel.AutoEllipsis = true;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.Text = module.CourseModuleTitle;
                level4TableLayoutPanel.Controls.Add(titleLabel,0,tableRow);

                Label descriptionLabel = new Label();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                descriptionLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                descriptionLabel.AutoSize = true;
                descriptionLabel.AutoEllipsis = true;
                descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
                descriptionLabel.Text = module.CourseModuleDescription;
                level4TableLayoutPanel.Controls.Add(descriptionLabel, 1, tableRow);

                Label codeLabel = new Label();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                codeLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                codeLabel.AutoSize = true;
                codeLabel.AutoEllipsis = true;
                codeLabel.TextAlign = ContentAlignment.MiddleLeft;
                codeLabel.Text = module.CourseModuleCode;
                level4TableLayoutPanel.Controls.Add(codeLabel, 2, tableRow);

                Label creditLabel = new Label();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.09F));
                creditLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                creditLabel.AutoSize = true;
                creditLabel.AutoEllipsis = true;
                creditLabel.TextAlign = ContentAlignment.MiddleLeft;
                creditLabel.Text = module.CourseModuleCreditValue.ToString();
                level4TableLayoutPanel.Controls.Add(creditLabel, 3, tableRow);

                Label finalLabel = new Label();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.18F));
                finalLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                finalLabel.AutoSize = true;
                finalLabel.AutoEllipsis = true;
                finalLabel.TextAlign = ContentAlignment.MiddleLeft;
                if (module.ContributedToFinal)
                {
                    finalLabel.Text = "Yes";
                }
                else
                {
                    finalLabel.Text = "No";
                }
                level4TableLayoutPanel.Controls.Add(finalLabel, 4, tableRow);

                Label typeLabel = new Label();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.09F));
                typeLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                typeLabel.AutoSize = true;
                typeLabel.AutoEllipsis = true;
                typeLabel.TextAlign = ContentAlignment.MiddleLeft;
                typeLabel.Text = Enum.GetName(typeof(ModuleType), module.ModuleType);
                level4TableLayoutPanel.Controls.Add(typeLabel, 5, tableRow);

                Button newAssessmentBtn = new Button();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                newAssessmentBtn.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                newAssessmentBtn.AutoSize = true;
                newAssessmentBtn.Text = "Assessment +";
                newAssessmentBtn.TextAlign = ContentAlignment.MiddleLeft;
                newAssessmentBtn.Click += NewAssessmentBtn_Click;
                level4TableLayoutPanel.Controls.Add(newAssessmentBtn, 6, tableRow);
               
                tableRow++;
            }
        }

        public void ProcessLevel5Table()
        {
            var tableRow = 1;
            level5TableLayoutPanel.RowCount = tableRow + 1;
            foreach (CourseModuleDTO module in level5CourseModuleList)
            {
                level5TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                Label titleLabel = new Label();
                level5TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                titleLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                titleLabel.AutoSize = true;
                titleLabel.AutoEllipsis = true;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.Text = module.CourseModuleTitle;
                level5TableLayoutPanel.Controls.Add(titleLabel, 0, tableRow);

                Label descriptionLabel = new Label();
                level5TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                descriptionLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                descriptionLabel.AutoSize = true;
                descriptionLabel.AutoEllipsis = true;
                descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
                descriptionLabel.Text = module.CourseModuleDescription;
                level5TableLayoutPanel.Controls.Add(descriptionLabel, 1, tableRow);

                Label codeLabel = new Label();
                level5TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                codeLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                codeLabel.AutoSize = true;
                codeLabel.AutoEllipsis = true;
                codeLabel.TextAlign = ContentAlignment.MiddleLeft;
                codeLabel.Text = module.CourseModuleCode;
                level5TableLayoutPanel.Controls.Add(codeLabel, 2, tableRow);

                Label creditLabel = new Label();
                level5TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.09F));
                creditLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                creditLabel.AutoSize = true;
                creditLabel.AutoEllipsis = true;
                creditLabel.TextAlign = ContentAlignment.MiddleLeft;
                creditLabel.Text = module.CourseModuleCreditValue.ToString();
                level5TableLayoutPanel.Controls.Add(creditLabel, 3, tableRow);

                Label finalLabel = new Label();
                level5TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.18F));
                finalLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                finalLabel.AutoSize = true;
                finalLabel.AutoEllipsis = true;
                finalLabel.TextAlign = ContentAlignment.MiddleLeft;
                if (module.ContributedToFinal)
                {
                    finalLabel.Text = "Yes";
                }
                else
                {
                    finalLabel.Text = "No";
                }
                level5TableLayoutPanel.Controls.Add(finalLabel, 4, tableRow);

                Label typeLabel = new Label();
                level5TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.09F));
                typeLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                typeLabel.AutoSize = true;
                typeLabel.AutoEllipsis = true;
                typeLabel.TextAlign = ContentAlignment.MiddleLeft;
                typeLabel.Text = Enum.GetName(typeof(ModuleType), module.ModuleType);
                level5TableLayoutPanel.Controls.Add(typeLabel, 5, tableRow);

                Button newAssessmentBtn = new Button();
                level4TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                newAssessmentBtn.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                newAssessmentBtn.AutoSize = true;
                newAssessmentBtn.Text = "Assessment +";
                newAssessmentBtn.TextAlign = ContentAlignment.MiddleLeft;
                level5TableLayoutPanel.Controls.Add(newAssessmentBtn, 6, tableRow);
                newAssessmentBtn.Click += NewAssessmentBtn_Click;
                tableRow++;
            }
        }

        private void NewAssessmentBtn_Click(object sender, EventArgs e)
        {
            int row = 0;
            CourseModuleDTO cm = null;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    level4TableLayoutPanel.GetRow((Button)sender);
                    cm = level4CourseModuleList[row - 1];
                    break;
                case 1:
                    level5TableLayoutPanel.GetRow((Button)sender);
                    cm = level5CourseModuleList[row - 1];
                    break;
                case 2:
                    level6TableLayoutPanel.GetRow((Button)sender);
                    cm = level6CourseModuleList[row - 1];
                    break;
                default:
                    level4TableLayoutPanel.GetRow((Button)sender);
                    cm = level4CourseModuleList[row - 1];
                    break;
            }
            var courseModuleEntity = AutoMapper.Mapper.Map<CourseModule>(cm);

            AddAssessmentForm addAssessmentForm = new AddAssessmentForm(courseModuleEntity);
            addAssessmentForm.ShowDialog();
        }

        public void ProcessLevel6Table()
        {
            var tableRow = 1;
            level6TableLayoutPanel.RowCount = tableRow + 1;
            foreach (CourseModuleDTO module in level6CourseModuleList)
            {
                level4TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

                Label titleLabel = new Label();
                level6TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                titleLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                titleLabel.AutoSize = true;
                titleLabel.AutoEllipsis = true;
                titleLabel.TextAlign = ContentAlignment.MiddleLeft;
                titleLabel.Text = module.CourseModuleTitle;
                level6TableLayoutPanel.Controls.Add(titleLabel, 0, tableRow);

                Label descriptionLabel = new Label();
                level6TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.18F));
                descriptionLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                descriptionLabel.AutoSize = true;
                descriptionLabel.AutoEllipsis = true;
                descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
                descriptionLabel.Text = module.CourseModuleDescription;
                level6TableLayoutPanel.Controls.Add(descriptionLabel, 1, tableRow);

                Label codeLabel = new Label();
                level6TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                codeLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                codeLabel.AutoSize = true;
                codeLabel.AutoEllipsis = true;
                codeLabel.TextAlign = ContentAlignment.MiddleLeft;
                codeLabel.Text = module.CourseModuleCode;
                level6TableLayoutPanel.Controls.Add(codeLabel, 2, tableRow);

                Label creditLabel = new Label();
                level6TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.09F));
                creditLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                creditLabel.AutoSize = true;
                creditLabel.AutoEllipsis = true;
                creditLabel.TextAlign = ContentAlignment.MiddleLeft;
                creditLabel.Text = module.CourseModuleCreditValue.ToString();
                level6TableLayoutPanel.Controls.Add(creditLabel, 3, tableRow);

                Label finalLabel = new Label();
                level6TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.18F));
                finalLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                finalLabel.AutoSize = true;
                finalLabel.AutoEllipsis = true;
                finalLabel.TextAlign = ContentAlignment.MiddleLeft;
                if (module.ContributedToFinal)
                {
                    finalLabel.Text = "Yes";
                }
                else
                {
                    finalLabel.Text = "No";
                }
                level6TableLayoutPanel.Controls.Add(finalLabel, 4, tableRow);

                Label typeLabel = new Label();
                level6TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.09F));
                typeLabel.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                typeLabel.AutoSize = true;
                typeLabel.AutoEllipsis = true;
                typeLabel.TextAlign = ContentAlignment.MiddleLeft;
                typeLabel.Text = Enum.GetName(typeof(ModuleType), module.ModuleType);
                level6TableLayoutPanel.Controls.Add(typeLabel, 5, tableRow);

                Button newAssessmentBtn = new Button();
                level6TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.64F));
                newAssessmentBtn.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                newAssessmentBtn.AutoSize = true;
                newAssessmentBtn.Text = "Assessment +";
                newAssessmentBtn.TextAlign = ContentAlignment.MiddleLeft;
                level6TableLayoutPanel.Controls.Add(newAssessmentBtn, 6, tableRow);
                newAssessmentBtn.Click += NewAssessmentBtn_Click;
                tableRow++;
            }
        }
    }
}
