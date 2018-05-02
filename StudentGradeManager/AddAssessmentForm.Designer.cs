namespace StudentGradeManager
{
    partial class AddAssessmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label assessmentTypeLabel;
            System.Windows.Forms.Label moduleAssessmentDescriptionLabel;
            System.Windows.Forms.Label moduleAssessmentTitleLabel;
            System.Windows.Forms.Label passingMarkLabel;
            System.Windows.Forms.Label weightingLabel;
            this.moduleAssessmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assessmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.moduleAssessmentDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.moduleAssessmentTitleTextBox = new System.Windows.Forms.TextBox();
            this.passingMarkTextBox = new System.Windows.Forms.TextBox();
            this.weightingTextBox = new System.Windows.Forms.TextBox();
            this.saveAssessmentsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            assessmentTypeLabel = new System.Windows.Forms.Label();
            moduleAssessmentDescriptionLabel = new System.Windows.Forms.Label();
            moduleAssessmentTitleLabel = new System.Windows.Forms.Label();
            passingMarkLabel = new System.Windows.Forms.Label();
            weightingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.moduleAssessmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // moduleAssessmentBindingSource
            // 
            this.moduleAssessmentBindingSource.DataSource = typeof(StudentDataModel.ModuleAssessment);
            // 
            // assessmentTypeLabel
            // 
            assessmentTypeLabel.AutoSize = true;
            assessmentTypeLabel.Location = new System.Drawing.Point(163, 24);
            assessmentTypeLabel.Name = "assessmentTypeLabel";
            assessmentTypeLabel.Size = new System.Drawing.Size(93, 13);
            assessmentTypeLabel.TabIndex = 1;
            assessmentTypeLabel.Text = "Assessment Type:";
            // 
            // assessmentTypeComboBox
            // 
            this.assessmentTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleAssessmentBindingSource, "AssessmentType", true));
            this.assessmentTypeComboBox.FormattingEnabled = true;
            this.assessmentTypeComboBox.Location = new System.Drawing.Point(333, 21);
            this.assessmentTypeComboBox.Name = "assessmentTypeComboBox";
            this.assessmentTypeComboBox.Size = new System.Drawing.Size(243, 21);
            this.assessmentTypeComboBox.TabIndex = 2;
            // 
            // moduleAssessmentDescriptionLabel
            // 
            moduleAssessmentDescriptionLabel.AutoSize = true;
            moduleAssessmentDescriptionLabel.Location = new System.Drawing.Point(163, 51);
            moduleAssessmentDescriptionLabel.Name = "moduleAssessmentDescriptionLabel";
            moduleAssessmentDescriptionLabel.Size = new System.Drawing.Size(160, 13);
            moduleAssessmentDescriptionLabel.TabIndex = 3;
            moduleAssessmentDescriptionLabel.Text = "Module Assessment Description:";
            // 
            // moduleAssessmentDescriptionTextBox
            // 
            this.moduleAssessmentDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleAssessmentBindingSource, "ModuleAssessmentDescription", true));
            this.moduleAssessmentDescriptionTextBox.Location = new System.Drawing.Point(333, 48);
            this.moduleAssessmentDescriptionTextBox.Name = "moduleAssessmentDescriptionTextBox";
            this.moduleAssessmentDescriptionTextBox.Size = new System.Drawing.Size(243, 20);
            this.moduleAssessmentDescriptionTextBox.TabIndex = 4;
            // 
            // moduleAssessmentTitleLabel
            // 
            moduleAssessmentTitleLabel.AutoSize = true;
            moduleAssessmentTitleLabel.Location = new System.Drawing.Point(163, 77);
            moduleAssessmentTitleLabel.Name = "moduleAssessmentTitleLabel";
            moduleAssessmentTitleLabel.Size = new System.Drawing.Size(127, 13);
            moduleAssessmentTitleLabel.TabIndex = 5;
            moduleAssessmentTitleLabel.Text = "Module Assessment Title:";
            // 
            // moduleAssessmentTitleTextBox
            // 
            this.moduleAssessmentTitleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleAssessmentBindingSource, "ModuleAssessmentTitle", true));
            this.moduleAssessmentTitleTextBox.Location = new System.Drawing.Point(333, 74);
            this.moduleAssessmentTitleTextBox.Name = "moduleAssessmentTitleTextBox";
            this.moduleAssessmentTitleTextBox.Size = new System.Drawing.Size(243, 20);
            this.moduleAssessmentTitleTextBox.TabIndex = 6;
            // 
            // passingMarkLabel
            // 
            passingMarkLabel.AutoSize = true;
            passingMarkLabel.Location = new System.Drawing.Point(163, 103);
            passingMarkLabel.Name = "passingMarkLabel";
            passingMarkLabel.Size = new System.Drawing.Size(74, 13);
            passingMarkLabel.TabIndex = 7;
            passingMarkLabel.Text = "Passing Mark:";
            // 
            // passingMarkTextBox
            // 
            this.passingMarkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleAssessmentBindingSource, "PassingMark", true));
            this.passingMarkTextBox.Location = new System.Drawing.Point(333, 100);
            this.passingMarkTextBox.Name = "passingMarkTextBox";
            this.passingMarkTextBox.Size = new System.Drawing.Size(243, 20);
            this.passingMarkTextBox.TabIndex = 8;
            // 
            // weightingLabel
            // 
            weightingLabel.AutoSize = true;
            weightingLabel.Location = new System.Drawing.Point(163, 129);
            weightingLabel.Name = "weightingLabel";
            weightingLabel.Size = new System.Drawing.Size(58, 13);
            weightingLabel.TabIndex = 9;
            weightingLabel.Text = "Weighting:";
            // 
            // weightingTextBox
            // 
            this.weightingTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.moduleAssessmentBindingSource, "Weighting", true));
            this.weightingTextBox.Location = new System.Drawing.Point(333, 126);
            this.weightingTextBox.Name = "weightingTextBox";
            this.weightingTextBox.Size = new System.Drawing.Size(243, 20);
            this.weightingTextBox.TabIndex = 10;
            // 
            // saveAssessmentsButton
            // 
            this.saveAssessmentsButton.Location = new System.Drawing.Point(467, 167);
            this.saveAssessmentsButton.Name = "saveAssessmentsButton";
            this.saveAssessmentsButton.Size = new System.Drawing.Size(109, 23);
            this.saveAssessmentsButton.TabIndex = 11;
            this.saveAssessmentsButton.Text = "saveAssessments";
            this.saveAssessmentsButton.UseVisualStyleBackColor = true;
            this.saveAssessmentsButton.Click += new System.EventHandler(this.saveAssessmentsButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.32938F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.67062F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 224);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(759, 272);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // AddAssessmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.saveAssessmentsButton);
            this.Controls.Add(assessmentTypeLabel);
            this.Controls.Add(this.assessmentTypeComboBox);
            this.Controls.Add(moduleAssessmentDescriptionLabel);
            this.Controls.Add(this.moduleAssessmentDescriptionTextBox);
            this.Controls.Add(moduleAssessmentTitleLabel);
            this.Controls.Add(this.moduleAssessmentTitleTextBox);
            this.Controls.Add(passingMarkLabel);
            this.Controls.Add(this.passingMarkTextBox);
            this.Controls.Add(weightingLabel);
            this.Controls.Add(this.weightingTextBox);
            this.Name = "AddAssessmentForm";
            this.Text = "AddAssessmentForm";
            this.Load += new System.EventHandler(this.AddAssessmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.moduleAssessmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource moduleAssessmentBindingSource;
        private System.Windows.Forms.ComboBox assessmentTypeComboBox;
        private System.Windows.Forms.TextBox moduleAssessmentDescriptionTextBox;
        private System.Windows.Forms.TextBox moduleAssessmentTitleTextBox;
        private System.Windows.Forms.TextBox passingMarkTextBox;
        private System.Windows.Forms.TextBox weightingTextBox;
        private System.Windows.Forms.Button saveAssessmentsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}