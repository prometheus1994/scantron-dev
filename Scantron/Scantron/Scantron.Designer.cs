﻿namespace Scantron
{
    partial class Scantron
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
            this.uxStart = new System.Windows.Forms.Button();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxRestart = new System.Windows.Forms.Button();
            this.uxGradeStudents = new System.Windows.Forms.Button();
            this.uxStudentResponsePanel = new System.Windows.Forms.Panel();
            this.uxCouldNotBeGradedLabel = new System.Windows.Forms.Label();
            this.uxStudentSelector = new System.Windows.Forms.ComboBox();
            this.uxMainTabControl = new System.Windows.Forms.TabControl();
            this.uxScanTab = new System.Windows.Forms.TabPage();
            this.uxScanInstructionLabel = new System.Windows.Forms.Label();
            this.uxHorizontalDivider = new System.Windows.Forms.Label();
            this.uxGradeTab = new System.Windows.Forms.TabPage();
            this.uxExamNameLabel = new System.Windows.Forms.Label();
            this.uxExamName = new System.Windows.Forms.TextBox();
            this.uxGradeInstructionLabel = new System.Windows.Forms.Label();
            this.uxVerticalDivider = new System.Windows.Forms.Label();
            this.uxHorizontalDivider2 = new System.Windows.Forms.Label();
            this.uxNumberOfVersionsLabel = new System.Windows.Forms.Label();
            this.uxNumberOfQuestionsLabel = new System.Windows.Forms.Label();
            this.uxAllPartialCredit = new System.Windows.Forms.CheckBox();
            this.uxAllQuestionPointsLabel = new System.Windows.Forms.Label();
            this.uxAllQuestionPoints = new System.Windows.Forms.NumericUpDown();
            this.uxVersionLabel = new System.Windows.Forms.Label();
            this.uxNumberOfQuestions = new System.Windows.Forms.NumericUpDown();
            this.uxPreviousStudent = new System.Windows.Forms.Button();
            this.uxNextStudent = new System.Windows.Forms.Button();
            this.uxStudentResponseLabel = new System.Windows.Forms.Label();
            this.uxNumberOfVersions = new System.Windows.Forms.NumericUpDown();
            this.uxAnswerKeyLabel = new System.Windows.Forms.Label();
            this.uxAnswerKeyTabControl = new System.Windows.Forms.TabControl();
            this.uxVersion1Tab = new System.Windows.Forms.TabPage();
            this.uxVersion2Tab = new System.Windows.Forms.TabPage();
            this.uxVersion3Tab = new System.Windows.Forms.TabPage();
            this.uxScoreLabel = new System.Windows.Forms.Label();
            this.uxMainTabControl.SuspendLayout();
            this.uxScanTab.SuspendLayout();
            this.uxGradeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxAllQuestionPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfVersions)).BeginInit();
            this.uxAnswerKeyTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStart.Location = new System.Drawing.Point(14, 215);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(85, 65);
            this.uxStart.TabIndex = 0;
            this.uxStart.Tag = "";
            this.uxStart.Text = "Start";
            this.uxStart.UseVisualStyleBackColor = false;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // uxStop
            // 
            this.uxStop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxStop.Location = new System.Drawing.Point(105, 215);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(85, 65);
            this.uxStop.TabIndex = 4;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = false;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxRestart
            // 
            this.uxRestart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.5F);
            this.uxRestart.Location = new System.Drawing.Point(196, 215);
            this.uxRestart.Name = "uxRestart";
            this.uxRestart.Size = new System.Drawing.Size(124, 65);
            this.uxRestart.TabIndex = 8;
            this.uxRestart.Text = "Restart";
            this.uxRestart.UseVisualStyleBackColor = false;
            this.uxRestart.Click += new System.EventHandler(this.uxRestart_Click);
            // 
            // uxGradeStudents
            // 
            this.uxGradeStudents.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxGradeStudents.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxGradeStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxGradeStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxGradeStudents.Location = new System.Drawing.Point(195, 245);
            this.uxGradeStudents.Name = "uxGradeStudents";
            this.uxGradeStudents.Size = new System.Drawing.Size(90, 40);
            this.uxGradeStudents.TabIndex = 14;
            this.uxGradeStudents.Text = "Grade Students";
            this.uxGradeStudents.UseVisualStyleBackColor = false;
            this.uxGradeStudents.Click += new System.EventHandler(this.uxGradeStudents_Click);
            // 
            // uxStudentResponsePanel
            // 
            this.uxStudentResponsePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxStudentResponsePanel.AutoScroll = true;
            this.uxStudentResponsePanel.BackColor = System.Drawing.SystemColors.Control;
            this.uxStudentResponsePanel.Location = new System.Drawing.Point(490, 312);
            this.uxStudentResponsePanel.Name = "uxStudentResponsePanel";
            this.uxStudentResponsePanel.Size = new System.Drawing.Size(475, 282);
            this.uxStudentResponsePanel.TabIndex = 15;
            // 
            // uxCouldNotBeGradedLabel
            // 
            this.uxCouldNotBeGradedLabel.AutoSize = true;
            this.uxCouldNotBeGradedLabel.BackColor = System.Drawing.Color.Red;
            this.uxCouldNotBeGradedLabel.Location = new System.Drawing.Point(629, 296);
            this.uxCouldNotBeGradedLabel.Name = "uxCouldNotBeGradedLabel";
            this.uxCouldNotBeGradedLabel.Size = new System.Drawing.Size(188, 13);
            this.uxCouldNotBeGradedLabel.TabIndex = 0;
            this.uxCouldNotBeGradedLabel.Text = "Student could not be graded correctly.";
            this.uxCouldNotBeGradedLabel.Visible = false;
            // 
            // uxStudentSelector
            // 
            this.uxStudentSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxStudentSelector.DisplayMember = "Student";
            this.uxStudentSelector.FormattingEnabled = true;
            this.uxStudentSelector.ItemHeight = 13;
            this.uxStudentSelector.Location = new System.Drawing.Point(632, 270);
            this.uxStudentSelector.Name = "uxStudentSelector";
            this.uxStudentSelector.Size = new System.Drawing.Size(193, 21);
            this.uxStudentSelector.TabIndex = 16;
            this.uxStudentSelector.Text = "Choose Student...";
            this.uxStudentSelector.SelectedIndexChanged += new System.EventHandler(this.uxStudentSelector_SelectedIndexChanged);
            // 
            // uxMainTabControl
            // 
            this.uxMainTabControl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uxMainTabControl.Controls.Add(this.uxScanTab);
            this.uxMainTabControl.Controls.Add(this.uxGradeTab);
            this.uxMainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxMainTabControl.HotTrack = true;
            this.uxMainTabControl.ItemSize = new System.Drawing.Size(488, 30);
            this.uxMainTabControl.Location = new System.Drawing.Point(-6, 0);
            this.uxMainTabControl.Name = "uxMainTabControl";
            this.uxMainTabControl.SelectedIndex = 0;
            this.uxMainTabControl.Size = new System.Drawing.Size(1036, 649);
            this.uxMainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uxMainTabControl.TabIndex = 9;
            // 
            // uxScanTab
            // 
            this.uxScanTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxScanTab.Controls.Add(this.uxScanInstructionLabel);
            this.uxScanTab.Controls.Add(this.uxHorizontalDivider);
            this.uxScanTab.Controls.Add(this.uxStart);
            this.uxScanTab.Controls.Add(this.uxStop);
            this.uxScanTab.Controls.Add(this.uxRestart);
            this.uxScanTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.uxScanTab.Location = new System.Drawing.Point(4, 34);
            this.uxScanTab.Name = "uxScanTab";
            this.uxScanTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxScanTab.Size = new System.Drawing.Size(1028, 611);
            this.uxScanTab.TabIndex = 0;
            this.uxScanTab.Text = "Scan";
            // 
            // uxScanInstructionLabel
            // 
            this.uxScanInstructionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uxScanInstructionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxScanInstructionLabel.Location = new System.Drawing.Point(6, 3);
            this.uxScanInstructionLabel.Name = "uxScanInstructionLabel";
            this.uxScanInstructionLabel.Size = new System.Drawing.Size(963, 189);
            this.uxScanInstructionLabel.TabIndex = 31;
            // 
            // uxHorizontalDivider
            // 
            this.uxHorizontalDivider.BackColor = System.Drawing.Color.SlateBlue;
            this.uxHorizontalDivider.Location = new System.Drawing.Point(7, 202);
            this.uxHorizontalDivider.Name = "uxHorizontalDivider";
            this.uxHorizontalDivider.Size = new System.Drawing.Size(962, 10);
            this.uxHorizontalDivider.TabIndex = 10;
            // 
            // uxGradeTab
            // 
            this.uxGradeTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxGradeTab.Controls.Add(this.uxScoreLabel);
            this.uxGradeTab.Controls.Add(this.uxCouldNotBeGradedLabel);
            this.uxGradeTab.Controls.Add(this.uxExamNameLabel);
            this.uxGradeTab.Controls.Add(this.uxExamName);
            this.uxGradeTab.Controls.Add(this.uxGradeInstructionLabel);
            this.uxGradeTab.Controls.Add(this.uxVerticalDivider);
            this.uxGradeTab.Controls.Add(this.uxHorizontalDivider2);
            this.uxGradeTab.Controls.Add(this.uxNumberOfVersionsLabel);
            this.uxGradeTab.Controls.Add(this.uxNumberOfQuestionsLabel);
            this.uxGradeTab.Controls.Add(this.uxAllPartialCredit);
            this.uxGradeTab.Controls.Add(this.uxAllQuestionPointsLabel);
            this.uxGradeTab.Controls.Add(this.uxAllQuestionPoints);
            this.uxGradeTab.Controls.Add(this.uxVersionLabel);
            this.uxGradeTab.Controls.Add(this.uxNumberOfQuestions);
            this.uxGradeTab.Controls.Add(this.uxPreviousStudent);
            this.uxGradeTab.Controls.Add(this.uxNextStudent);
            this.uxGradeTab.Controls.Add(this.uxStudentResponseLabel);
            this.uxGradeTab.Controls.Add(this.uxNumberOfVersions);
            this.uxGradeTab.Controls.Add(this.uxStudentSelector);
            this.uxGradeTab.Controls.Add(this.uxAnswerKeyLabel);
            this.uxGradeTab.Controls.Add(this.uxGradeStudents);
            this.uxGradeTab.Controls.Add(this.uxAnswerKeyTabControl);
            this.uxGradeTab.Controls.Add(this.uxStudentResponsePanel);
            this.uxGradeTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.uxGradeTab.Location = new System.Drawing.Point(4, 34);
            this.uxGradeTab.Name = "uxGradeTab";
            this.uxGradeTab.Padding = new System.Windows.Forms.Padding(3);
            this.uxGradeTab.Size = new System.Drawing.Size(1028, 611);
            this.uxGradeTab.TabIndex = 1;
            this.uxGradeTab.Text = "Grade";
            // 
            // uxExamNameLabel
            // 
            this.uxExamNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxExamNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxExamNameLabel.Location = new System.Drawing.Point(291, 245);
            this.uxExamNameLabel.Name = "uxExamNameLabel";
            this.uxExamNameLabel.Size = new System.Drawing.Size(130, 20);
            this.uxExamNameLabel.TabIndex = 32;
            this.uxExamNameLabel.Text = "Exam Name:";
            this.uxExamNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxExamName
            // 
            this.uxExamName.Location = new System.Drawing.Point(291, 266);
            this.uxExamName.Name = "uxExamName";
            this.uxExamName.Size = new System.Drawing.Size(170, 20);
            this.uxExamName.TabIndex = 31;
            // 
            // uxGradeInstructionLabel
            // 
            this.uxGradeInstructionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.uxGradeInstructionLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGradeInstructionLabel.Location = new System.Drawing.Point(6, 3);
            this.uxGradeInstructionLabel.Name = "uxGradeInstructionLabel";
            this.uxGradeInstructionLabel.Size = new System.Drawing.Size(963, 189);
            this.uxGradeInstructionLabel.TabIndex = 30;
            // 
            // uxVerticalDivider
            // 
            this.uxVerticalDivider.BackColor = System.Drawing.Color.SlateBlue;
            this.uxVerticalDivider.Location = new System.Drawing.Point(471, 212);
            this.uxVerticalDivider.Name = "uxVerticalDivider";
            this.uxVerticalDivider.Size = new System.Drawing.Size(12, 381);
            this.uxVerticalDivider.TabIndex = 0;
            // 
            // uxHorizontalDivider2
            // 
            this.uxHorizontalDivider2.BackColor = System.Drawing.Color.SlateBlue;
            this.uxHorizontalDivider2.Location = new System.Drawing.Point(7, 202);
            this.uxHorizontalDivider2.Name = "uxHorizontalDivider2";
            this.uxHorizontalDivider2.Size = new System.Drawing.Size(962, 10);
            this.uxHorizontalDivider2.TabIndex = 29;
            // 
            // uxNumberOfVersionsLabel
            // 
            this.uxNumberOfVersionsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumberOfVersionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNumberOfVersionsLabel.Location = new System.Drawing.Point(3, 264);
            this.uxNumberOfVersionsLabel.Name = "uxNumberOfVersionsLabel";
            this.uxNumberOfVersionsLabel.Size = new System.Drawing.Size(130, 21);
            this.uxNumberOfVersionsLabel.TabIndex = 19;
            this.uxNumberOfVersionsLabel.Text = "Number of Versions:";
            this.uxNumberOfVersionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxNumberOfQuestionsLabel
            // 
            this.uxNumberOfQuestionsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumberOfQuestionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNumberOfQuestionsLabel.Location = new System.Drawing.Point(4, 239);
            this.uxNumberOfQuestionsLabel.Name = "uxNumberOfQuestionsLabel";
            this.uxNumberOfQuestionsLabel.Size = new System.Drawing.Size(130, 20);
            this.uxNumberOfQuestionsLabel.TabIndex = 23;
            this.uxNumberOfQuestionsLabel.Text = "Number of Questions:";
            this.uxNumberOfQuestionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxAllPartialCredit
            // 
            this.uxAllPartialCredit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxAllPartialCredit.AutoSize = true;
            this.uxAllPartialCredit.BackColor = System.Drawing.Color.Transparent;
            this.uxAllPartialCredit.Location = new System.Drawing.Point(325, 291);
            this.uxAllPartialCredit.Name = "uxAllPartialCredit";
            this.uxAllPartialCredit.Size = new System.Drawing.Size(99, 17);
            this.uxAllPartialCredit.TabIndex = 0;
            this.uxAllPartialCredit.Text = "All Partial Credit";
            this.uxAllPartialCredit.UseVisualStyleBackColor = false;
            this.uxAllPartialCredit.CheckedChanged += new System.EventHandler(this.uxAllPartialCredit_CheckedChanged);
            // 
            // uxAllQuestionPointsLabel
            // 
            this.uxAllQuestionPointsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxAllQuestionPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.uxAllQuestionPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAllQuestionPointsLabel.Location = new System.Drawing.Point(178, 291);
            this.uxAllQuestionPointsLabel.Name = "uxAllQuestionPointsLabel";
            this.uxAllQuestionPointsLabel.Size = new System.Drawing.Size(93, 20);
            this.uxAllQuestionPointsLabel.TabIndex = 27;
            this.uxAllQuestionPointsLabel.Text = "All Questions:";
            this.uxAllQuestionPointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uxAllQuestionPoints
            // 
            this.uxAllQuestionPoints.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxAllQuestionPoints.DecimalPlaces = 2;
            this.uxAllQuestionPoints.Location = new System.Drawing.Point(269, 291);
            this.uxAllQuestionPoints.Name = "uxAllQuestionPoints";
            this.uxAllQuestionPoints.Size = new System.Drawing.Size(50, 20);
            this.uxAllQuestionPoints.TabIndex = 26;
            this.uxAllQuestionPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxAllQuestionPoints.ValueChanged += new System.EventHandler(this.uxAllQuestionPoints_ValueChanged);
            // 
            // uxVersionLabel
            // 
            this.uxVersionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxVersionLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxVersionLabel.Location = new System.Drawing.Point(533, 234);
            this.uxVersionLabel.Name = "uxVersionLabel";
            this.uxVersionLabel.Size = new System.Drawing.Size(65, 22);
            this.uxVersionLabel.TabIndex = 25;
            this.uxVersionLabel.Text = "Version: ";
            this.uxVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxNumberOfQuestions
            // 
            this.uxNumberOfQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumberOfQuestions.Location = new System.Drawing.Point(139, 243);
            this.uxNumberOfQuestions.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.uxNumberOfQuestions.Name = "uxNumberOfQuestions";
            this.uxNumberOfQuestions.Size = new System.Drawing.Size(50, 20);
            this.uxNumberOfQuestions.TabIndex = 24;
            this.uxNumberOfQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxNumberOfQuestions.ValueChanged += new System.EventHandler(this.uxNumberOfQuestions_ValueChanged);
            // 
            // uxPreviousStudent
            // 
            this.uxPreviousStudent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxPreviousStudent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxPreviousStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxPreviousStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxPreviousStudent.Location = new System.Drawing.Point(536, 264);
            this.uxPreviousStudent.Name = "uxPreviousStudent";
            this.uxPreviousStudent.Size = new System.Drawing.Size(90, 30);
            this.uxPreviousStudent.TabIndex = 21;
            this.uxPreviousStudent.Text = "Previous";
            this.uxPreviousStudent.UseVisualStyleBackColor = false;
            this.uxPreviousStudent.Click += new System.EventHandler(this.uxPreviousStudent_Click);
            // 
            // uxNextStudent
            // 
            this.uxNextStudent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNextStudent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uxNextStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uxNextStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxNextStudent.Location = new System.Drawing.Point(831, 264);
            this.uxNextStudent.Name = "uxNextStudent";
            this.uxNextStudent.Size = new System.Drawing.Size(90, 30);
            this.uxNextStudent.TabIndex = 10;
            this.uxNextStudent.Text = "Next";
            this.uxNextStudent.UseVisualStyleBackColor = false;
            this.uxNextStudent.Click += new System.EventHandler(this.uxNextStudent_Click);
            // 
            // uxStudentResponseLabel
            // 
            this.uxStudentResponseLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxStudentResponseLabel.AutoSize = true;
            this.uxStudentResponseLabel.BackColor = System.Drawing.SystemColors.Control;
            this.uxStudentResponseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxStudentResponseLabel.Location = new System.Drawing.Point(643, 216);
            this.uxStudentResponseLabel.Name = "uxStudentResponseLabel";
            this.uxStudentResponseLabel.Size = new System.Drawing.Size(165, 24);
            this.uxStudentResponseLabel.TabIndex = 18;
            this.uxStudentResponseLabel.Text = "Student Response";
            // 
            // uxNumberOfVersions
            // 
            this.uxNumberOfVersions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxNumberOfVersions.Location = new System.Drawing.Point(139, 266);
            this.uxNumberOfVersions.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.uxNumberOfVersions.Name = "uxNumberOfVersions";
            this.uxNumberOfVersions.Size = new System.Drawing.Size(50, 20);
            this.uxNumberOfVersions.TabIndex = 20;
            this.uxNumberOfVersions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxNumberOfVersions.ValueChanged += new System.EventHandler(this.uxNumberOfVersions_ValueChanged);
            // 
            // uxAnswerKeyLabel
            // 
            this.uxAnswerKeyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxAnswerKeyLabel.AutoSize = true;
            this.uxAnswerKeyLabel.BackColor = System.Drawing.SystemColors.Control;
            this.uxAnswerKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.uxAnswerKeyLabel.Location = new System.Drawing.Point(174, 216);
            this.uxAnswerKeyLabel.Name = "uxAnswerKeyLabel";
            this.uxAnswerKeyLabel.Size = new System.Drawing.Size(111, 24);
            this.uxAnswerKeyLabel.TabIndex = 17;
            this.uxAnswerKeyLabel.Text = "Answer Key";
            // 
            // uxAnswerKeyTabControl
            // 
            this.uxAnswerKeyTabControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion1Tab);
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion2Tab);
            this.uxAnswerKeyTabControl.Controls.Add(this.uxVersion3Tab);
            this.uxAnswerKeyTabControl.Location = new System.Drawing.Point(7, 292);
            this.uxAnswerKeyTabControl.Name = "uxAnswerKeyTabControl";
            this.uxAnswerKeyTabControl.SelectedIndex = 0;
            this.uxAnswerKeyTabControl.Size = new System.Drawing.Size(458, 301);
            this.uxAnswerKeyTabControl.TabIndex = 22;
            // 
            // uxVersion1Tab
            // 
            this.uxVersion1Tab.AutoScroll = true;
            this.uxVersion1Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion1Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion1Tab.Name = "uxVersion1Tab";
            this.uxVersion1Tab.Padding = new System.Windows.Forms.Padding(3);
            this.uxVersion1Tab.Size = new System.Drawing.Size(450, 275);
            this.uxVersion1Tab.TabIndex = 0;
            this.uxVersion1Tab.Text = "Version 1";
            // 
            // uxVersion2Tab
            // 
            this.uxVersion2Tab.AutoScroll = true;
            this.uxVersion2Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion2Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion2Tab.Name = "uxVersion2Tab";
            this.uxVersion2Tab.Padding = new System.Windows.Forms.Padding(3);
            this.uxVersion2Tab.Size = new System.Drawing.Size(450, 275);
            this.uxVersion2Tab.TabIndex = 1;
            this.uxVersion2Tab.Text = "Version 2";
            // 
            // uxVersion3Tab
            // 
            this.uxVersion3Tab.AutoScroll = true;
            this.uxVersion3Tab.BackColor = System.Drawing.SystemColors.Control;
            this.uxVersion3Tab.Location = new System.Drawing.Point(4, 22);
            this.uxVersion3Tab.Name = "uxVersion3Tab";
            this.uxVersion3Tab.Size = new System.Drawing.Size(450, 275);
            this.uxVersion3Tab.TabIndex = 2;
            this.uxVersion3Tab.Text = "Version 3";
            // 
            // uxScoreLabel
            // 
            this.uxScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uxScoreLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.uxScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.uxScoreLabel.Location = new System.Drawing.Point(841, 239);
            this.uxScoreLabel.Name = "uxScoreLabel";
            this.uxScoreLabel.Size = new System.Drawing.Size(65, 22);
            this.uxScoreLabel.TabIndex = 33;
            this.uxScoreLabel.Text = "Score: ";
            this.uxScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Scantron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(975, 642);
            this.Controls.Add(this.uxMainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 375);
            this.Name = "Scantron";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "File Generator";
            this.uxMainTabControl.ResumeLayout(false);
            this.uxScanTab.ResumeLayout(false);
            this.uxGradeTab.ResumeLayout(false);
            this.uxGradeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxAllQuestionPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfVersions)).EndInit();
            this.uxAnswerKeyTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxRestart;
        private System.Windows.Forms.Button uxGradeStudents;
        private System.Windows.Forms.Panel uxStudentResponsePanel;
        private System.Windows.Forms.ComboBox uxStudentSelector;
        private System.Windows.Forms.TabControl uxMainTabControl;
        private System.Windows.Forms.TabPage uxScanTab;
        private System.Windows.Forms.TabPage uxGradeTab;
        private System.Windows.Forms.Label uxStudentResponseLabel;
        private System.Windows.Forms.Label uxAnswerKeyLabel;
        private System.Windows.Forms.NumericUpDown uxNumberOfVersions;
        private System.Windows.Forms.Label uxNumberOfVersionsLabel;
        private System.Windows.Forms.Button uxPreviousStudent;
        private System.Windows.Forms.Button uxNextStudent;
        private System.Windows.Forms.TabControl uxAnswerKeyTabControl;
        private System.Windows.Forms.NumericUpDown uxNumberOfQuestions;
        private System.Windows.Forms.Label uxNumberOfQuestionsLabel;
        private System.Windows.Forms.Label uxVersionLabel;
        private System.Windows.Forms.NumericUpDown uxAllQuestionPoints;
        private System.Windows.Forms.CheckBox uxAllPartialCredit;
        private System.Windows.Forms.Label uxAllQuestionPointsLabel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label uxHorizontalDivider;
        private System.Windows.Forms.Label uxVerticalDivider;
        private System.Windows.Forms.Label uxHorizontalDivider2;
        private System.Windows.Forms.TabPage uxVersion1Tab;
        private System.Windows.Forms.TabPage uxVersion2Tab;
        private System.Windows.Forms.TabPage uxVersion3Tab;
        private System.Windows.Forms.Label uxGradeInstructionLabel;
        private System.Windows.Forms.Label uxScanInstructionLabel;
        private System.Windows.Forms.TextBox uxExamName;
        private System.Windows.Forms.Label uxExamNameLabel;
        private System.Windows.Forms.Label uxCouldNotBeGradedLabel;
        private System.Windows.Forms.Label uxScoreLabel;
    }
}

