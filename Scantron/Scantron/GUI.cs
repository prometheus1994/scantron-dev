﻿// GUI.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles GUI changing methods.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO; 

namespace Scantron
{
    public class GUI
    {
        private Grader grader;

        // GUI objects that we need data from.
        private Form scantron_form;
        private TextBox uxScanInstructionBox;
        private TextBox uxGradeInstructionBox;
        private Panel uxStudentResponsePanel;
        private ComboBox uxStudentSelector;
        private TabControl uxAnswerKeyTabControl;
        private NumericUpDown uxNumberOfQuestions;
        private NumericUpDown uxNumberOfVersions;
        private NumericUpDown uxAllQuestionPoints;
        private CheckBox uxAllPartialCredit;
        private Button uxPreviousStudent;
        private Button uxNextStudent;
        private Label uxVersionLabel;
        // Holds the raw card data from the Scantron.
        private List<string> raw_cards;
        // Holds the partial misread WID's
        private List<string> partial_wids;

        public GUI(Form scantron_form)
        {
            // Test Data. Has two students for a 150 question exam. One has blank answers.
            raw_cards = new List<string>();
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa00C#Q0#\\Fb#T0#\\Fa#D0D#O0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0C#J0#\\Fa#I0C#J0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#E0E#I0#\\Fb#T0#\\Fa000F000F#L0#\\Fb#T0#\\Fa00F#J0E#F0#\\Fb#T0#\\Fa0D#R0#\\FaD#S0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0C#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E#G0#\\Fb#T0#\\Fa0E#D0F#D0C#H0#\\FaE#D0D#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0F#D0B#E0#\\Fb#T0#\\Fa000D#D0E#D0D#F0#\\Fb#T0#\\Fa00D#D0F#D0E#G0#\\Fb#T0#\\Fa0D#D0F#D0F#H0#\\FaD#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E0005000#\\Fb#T0#\\Fa0E#D0E#D0D#D06000#\\FaE#D0E#D0D#I0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000F#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0F#M0#\\Fb#T0#\\Fa#I0E#J0#\\Fb#T0#\\FaE#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0E#J0#\\Fb#T0#\\FaD0F0F#E0F#I0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa0F#E0F#E0E#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa00D#G0F00D#F0#\\Fb#T0#\\FaD#D0C0F0E0D#H0#\\Fb#T0#\\Fa0D0D#D0E#K0#\\Fb#T0#\\Fb#T0#\\Fb#T0#\\Fa#F0F#G0D#E0#\\Fa#D0D#G0E#G0#\\Fb#T0#\\Fb#T0#\\Fa0F#G0D#J0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#E0F#F0C0C#E0#\\Fb#T0#\\Fa#D0F0C0D0D00C#F0#\\FaF0EF#G0C#H0#\\Fb#T0#\\Fb#T0#\\FaE#F0E#H07000#\\Fb#T0#\\Fa0C#D0D0D#E0C#E0#\\Fb#T0#\\Fa00D00C000D00F#G0#\\Fb#T0#\\Fa#D0C#E0E#I0#\\Fa000C#G0E0E004000#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0D#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0D#J0#\\Fb#T0#\\Fb#T0#\\FaFBFFF00F00E#I0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#M0F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0EEEFE#E0#\\Fb#T0#\\Fa#E0DFFFD#J0#\\Fb#T0#\\FaEEDEE#O0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#E0FFFEF#J0#\\Fb#T0#\\FaFFFDE#O0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#J0FEEFF#E0#\\Fb#T0#\\Fb#T0#\\Fa#P07000#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0DDFFC03000#\\Fb#T0#\\Fa#E0FFDFD#J0#\\FaF#DE#O0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0F#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0D#J0#\\Fa#H0D#K0#\\Fb#T0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0F00F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#Q0300#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#S03#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00D#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0D#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#H0E#K0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#G0F00F00F#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0D#R0#\\Fb#T0#\\Fa00C#Q0#\\Fb#T0#\\Fa#F0F#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0F#N0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#I0D#J0#\\Fa#H0D#K0#\\Fb#T0#\\Fb#T0#\\Fa#G05#L0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#J0F00F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#Q0300#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\F$");

            this.scantron_form = scantron_form;
           
            uxScanInstructionBox = (TextBox) scantron_form.Controls.Find("uxScanInstructionBox", true)[0];
            uxGradeInstructionBox = (TextBox) scantron_form.Controls.Find("uxGradeInstructionBox", true)[0];
            uxStudentResponsePanel = (Panel) scantron_form.Controls.Find("uxStudentResponsePanel", true)[0];
            uxStudentSelector = (ComboBox) scantron_form.Controls.Find("uxStudentSelector",true)[0];
            uxAnswerKeyTabControl = (TabControl) scantron_form.Controls.Find("uxAnswerKeyTabControl", true)[0];
            uxNumberOfQuestions = (NumericUpDown)scantron_form.Controls.Find("uxNumberOfQuestions", true)[0];
            uxNumberOfVersions = (NumericUpDown) scantron_form.Controls.Find("uxNumberOfVersions", true)[0];
            uxAllQuestionPoints = (NumericUpDown) scantron_form.Controls.Find("uxAllQuestionPoints", true)[0];
            uxAllPartialCredit = (CheckBox) scantron_form.Controls.Find("uxAllPartialCredit", true)[0];
            uxPreviousStudent = (Button) scantron_form.Controls.Find("uxPreviousStudent", true)[0];
            uxNextStudent = (Button) scantron_form.Controls.Find("uxNextStudent", true)[0];
            uxVersionLabel = (Label) scantron_form.Controls.Find("uxVersionLabel", true)[0];

            uxScanInstructionBox.Text =     "You may click Restart at any time to start at the beginning of these instructions." +
                                            Environment.NewLine + Environment.NewLine +
                                            "Scan tab instructions: " +
                                            Environment.NewLine + Environment.NewLine +
                                            "1. Load the Scantron hopper and use the guider to make sure they are straight." +
                                            Environment.NewLine +
                                            "2. Click Start within this Window." +
                                            Environment.NewLine +
                                            "3. After your cards have finished scanning, click the Grade tab." +
                                            Environment.NewLine + Environment.NewLine;

            uxGradeInstructionBox.Text =    "Grade tab instructions: " +
                                            Environment.NewLine + Environment.NewLine +
                                            "1. Specify the number of questions and versions the exam has, then click Create Answer Form." +
                                            Environment.NewLine +
                                            "2. Fill in the answer key for each version with the check boxes and specify their points and if they are worth partial credit for multiple answer questions." +
                                            Environment.NewLine +
                                            "3. Click Grade Students and name the .csv file you will upload to your course's gradebook. You may review each student's response in the window on the right.";

            grader = new Grader(this);
        }

        /// <summary>
        /// Displays messages via Message Box.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Opens the serial port; begins scanning the cards. The most common exceptions with serial ports are handled. 
        /// Ref: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport.open(v=vs.110).aspx
        /// </summary>
        public void Start()
        {
            ScannerCom.Start();
            raw_cards = ScannerCom.Run(raw_cards);
        }

        /// <summary>
        /// Close the serial port and create list of students from scanned in data.
        /// </summary>
        public void Stop()
        {
            grader.CreateStudents(raw_cards, ref partial_wids);
        }

        /// <summary>
        /// Reset all fields to initial states.
        /// </summary>
        public void Restart()
        {
            
        }

        /// <summary>
        /// Create the answer key form with the specified number of questions and versions.
        /// </summary>
        public void CreateAnswerForm()
        {
            foreach (TabPage tp in uxAnswerKeyTabControl.TabPages)
            {
                foreach (Panel panel in tp.Controls)
                {
                    panel.Visible = false;
                }
            }

            uxAllQuestionPoints.Value = 1;
            uxAllPartialCredit.Checked = false;

            int number_of_versions = (int) uxNumberOfVersions.Value;
            int number_of_questions = (int) uxNumberOfQuestions.Value;

            TabPage tabpage;

            for (int i = 0; i < number_of_versions; i++)
            {
                tabpage = uxAnswerKeyTabControl.TabPages[i];

                for (int j = 0; j < number_of_questions; j++)
                {
                    tabpage.Controls[j].Visible = true;
                }
            }
        }

        /// <summary>
        /// Updates points for all questions in the exam.
        /// </summary>
        public void UpdateAllQuestionPoints()
        {
            foreach (TabPage tabpage in uxAnswerKeyTabControl.TabPages)
            {
                foreach (Control control in tabpage.Controls)
                {
                    NumericUpDown updown = (NumericUpDown)control.Controls[5];
                    updown.Value = uxAllQuestionPoints.Value;
                }
            }
        }

        /// <summary>
        /// Updates partial credit for all questions in the exam.
        /// </summary>
        public void UpdateAllPartialCredit()
        {
            foreach (TabPage tabpage in uxAnswerKeyTabControl.TabPages)
            {
                foreach (Control control in tabpage.Controls)
                {
                    CheckBox checkbox = (CheckBox)control.Controls[6];
                    checkbox.Checked = uxAllPartialCredit.Checked;
                }
            }
        }

        /// <summary>
        /// Create the answer key form to be filled out by the instructor.
        /// </summary>
        /// <param name="tabpage">Current version being created.</param>
        public void InstantiateAnswerKeyForm(TabPage tabpage)
        {
            for (int j = 0; j < 250; j++)
            {
                Panel panel = new Panel
                {
                    BackColor = Color.MediumPurple,
                    Location = new Point(3, 3 + 26 * j),
                    Size = new Size(420, 22),
                    Visible = false
                };

                for (int k = 0; k < 5; k++)
                {
                    CheckBox checkbox = new CheckBox
                    {
                        Location = new Point(73 + 39 * k, 3),
                        Size = new Size(33, 17),
                        Text = ((char)(k + 65)).ToString()
                    };
                    panel.Controls.Add(checkbox); // Checkboxes are added first so they are indices 0-4.
                }

                NumericUpDown updown = new NumericUpDown
                {
                    Location = new Point(268, 1),
                    DecimalPlaces = 2,
                    Size = new Size(58, 20),
                    Value = 1
                };

                CheckBox partial_credit = new CheckBox
                {
                    Location = new Point(330, 3),
                    Size = new Size(100, 17),
                    Text = "Partial Credit"
                };

                Label label = new Label
                {
                    Location = new Point(3, 3),
                    Size = new Size(70, 13),
                    Text = "Question" + (j + 1)
                };

                panel.Controls.Add(updown); // Index 5
                panel.Controls.Add(partial_credit); // Index 6
                panel.Controls.Add(label); // Index 7

                tabpage.Controls.Add(panel);
            }
        }

        /// <summary>
        /// Create the answer key from the filled out form.
        /// </summary>
        public void CreateAnswerKey()
        {
            if (uxAnswerKeyTabControl.TabPages[0].Controls.Count == 0)
            {
                DisplayMessage("You have not created an answer key. Enter the number of questions on the exam"
                                + ", click Enter, then fill out the answer key.");
                return;
            }

            grader.AnswerKey = new Dictionary<int, List<Question>>();

            Panel panel;
            CheckBox checkbox;
            NumericUpDown updown;

            int number_of_versions = (int) uxNumberOfVersions.Value;
            int number_of_questions = (int) uxNumberOfQuestions.Value;
            char[] answer = new char[5];
            float points = 0;
            bool partial_credit = false;

            for (int i = 0; i < number_of_versions; i++)
            {
                grader.AnswerKey.Add(i, new List<Question>());
                
                for (int j = 0; j < number_of_questions; j++)
                {
                    answer = new char[5];

                    panel = (Panel) uxAnswerKeyTabControl.TabPages[i].Controls[j];

                    // This loop cycles through the first 5 controls in the current question panel, which are the checkboes for A-E.
                    for (int k = 0; k < 5; k++)
                    {
                        checkbox = (CheckBox) panel.Controls[k];
                        if (checkbox.Checked)
                        {
                            answer[k] = (char)(65 + k);
                        }
                        else
                        {
                            answer[k] = ' ';
                        }
                    }
                    
                    updown = (NumericUpDown) panel.Controls[5];
                    points = (float)updown.Value;
                    
                    // Checks the current question panel's partial credit checkbox.
                    checkbox = (CheckBox) panel.Controls[6];
                    if (checkbox.Checked)
                    {
                        partial_credit = true;
                    }
                    else
                    {
                        partial_credit = false;
                    }
                    
                    grader.AnswerKey[i].Add(new Question(answer, points, partial_credit));
                }
            }
        }

        /// <summary>
        /// Grade the students.
        /// </summary>
        public void GradeStudents()
        {
            if (grader.Students.Count == 0)
            {
                DisplayMessage("You have not scanned in the student responses. Go back to the Scan tab"
                                + " and follow the instructions.");
                return;
            }

            CreateAnswerKey();

            if (grader.GradeStudents())
            {
                WriteFile();

                uxStudentSelector.Items.Clear();
                foreach (Student student in grader.Students)
                {
                    uxStudentSelector.Items.Add(student.WID);
                }

                // Displays the first student in the index
                NextStudent();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Write the file to be uploaded to the Canvas gradebook.
        /// </summary>
        private void WriteFile()
        {
            string file = grader.ToString();

            // Then we have to start a file dialog to save the string to a file.
            SaveFileDialog uxSaveFileDialog = new SaveFileDialog
            {
                // Could be used to select the default directory ex. "C:\Users\Public\Desktop".
                InitialDirectory = "c:\\desktop",
                // Filter is the default file extensions seen by the user.
                Filter = "csv files (*.csv)|*.csv",
                // FilterIndex sets what the user initially sees ex: 2nd index of the filter is ".txt".
                FilterIndex = 1
            };

            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = uxSaveFileDialog.FileName;
                // Stores the location of the file we want to save; use filenames for multiple.
                if (path.Equals(""))
                {
                    MessageBox.Show("You must enter a filename and select" + Environment.NewLine +
                                    "a file path for the exam record!");
                    throw new IOException();
                }
                else
                {
                    // "using" opens and close the StreamWriter.
                    using (StreamWriter file_generator = new StreamWriter(path))
                    {
                        // Adds everything in the 'file' given to the streamwriter.
                        file_generator.Write(file);
                    }
                    MessageBox.Show("Student responses have been successfully recorded!" + Environment.NewLine +
                                    "You may now upload the student responses to Canvas" + Environment.NewLine +
                                    "using the file generated.");
                }
            }
            else
            {
                MessageBox.Show("An error occured while trying to save," + Environment.NewLine +
                                "The format for filenames should not include" + Environment.NewLine +
                                "slashes, parentheticals, or symbols" +
                                Environment.NewLine +
                                "Please reload the hopper and ensure the" + Environment.NewLine +
                                "cards are not stuck together, backwards," + Environment.NewLine +
                                "or reversed. ");
                throw new IOException();
            }
        }

        /// <summary>
        /// Populates the student answer panel with question panels that show the selected student's response.
        /// </summary>
        public void SelectStudent()
        {
            DisplayStudent(grader.Students.Find(item => item.WID == uxStudentSelector.Text));
        }

        /// <summary>
        /// Displays the next student's responses in the uxStudentResponsePanel.
        /// </summary>
        public void NextStudent()
        {
            string wid = (string)uxStudentSelector.Items[uxStudentSelector.SelectedIndex + 1];
            uxStudentSelector.SelectedItem = wid;
        }

        /// <summary>
        /// Displays the previous student's responses in the uxStudentResponsePanel.
        /// </summary>
        public void PreviousStudent()
        {
            string wid = (string)uxStudentSelector.Items[uxStudentSelector.SelectedIndex - 1];
            uxStudentSelector.SelectedItem = wid;
        }

        /// <summary>
        /// 
        /// </summary>
        public void InstantiateStudentDisplay()
        {
            for (int i = 0; i < 250; i++)
            {
                Panel panel = new Panel
                {
                    Location = new Point(3, 3 + 26 * i),
                    Size = new Size(268, 22),
                    Visible = false
                };

                for (int j = 0; j < 5; j++)
                {
                    CheckBox checkbox = new CheckBox
                    {
                        Enabled = false,
                        Location = new Point(73 + 39 * j, 3),
                        Size = new Size(33, 17),
                        Text = ((char)(j + 65)).ToString()
                    };

                    panel.Controls.Add(checkbox); // Checkboxes are added first so their indices are 0-4.
                }

                Label label = new Label
                {
                    Location = new Point(3, 3),
                    Size = new Size(70, 13),
                    Text = "Question" + (i + 1)
                };

                panel.Controls.Add(label); // Index 5

                uxStudentResponsePanel.Controls.Add(panel);
            }
        }

        /// <summary>
        /// Display the selected student's response in uxStudentResponsePanel.
        /// </summary>
        /// <param name="student">Selected student.</param>
        private void DisplayStudent(Student student)
        {
            if (uxStudentSelector.SelectedIndex == 0)
            {
                uxPreviousStudent.Enabled = false;
            }
            else
            {
                uxPreviousStudent.Enabled = true;
            }

            if (uxStudentSelector.SelectedIndex == uxStudentSelector.Items.Count -1)
            {
                uxNextStudent.Enabled = false;
            }
            else
            {
                uxNextStudent.Enabled = true;
            }

            int test_version = student.TestVersion;
            uxVersionLabel.Text = "Version: " + test_version;
            Panel panel;
            CheckBox response_checkbox;
            CheckBox answer_key_checkbox;

            foreach (Control control in uxStudentResponsePanel.Controls)
            {
                control.Visible = false;
            }

            for (int i = 0; i < grader.AnswerKey[test_version - 1].Count; i++)
            {
                panel = (Panel)uxStudentResponsePanel.Controls[i];
                panel.Visible = true;

                if (student.Response[i].Points == grader.AnswerKey[test_version - 1][i].Points)
                {
                    panel.BackColor = Color.DarkGreen;
                }
                else
                {
                    panel.BackColor = Color.Red;
                }

                for (int j = 0; j < 5; j++)
                {
                    response_checkbox = (CheckBox)panel.Controls[j];
                    answer_key_checkbox = (CheckBox)uxAnswerKeyTabControl.TabPages[test_version - 1].Controls[i].Controls[j];

                    if (student.Response[i].Answer[j] == ' ')
                    {
                        response_checkbox.Checked = false;
                    }
                    else
                    {
                        response_checkbox.Checked = true;
                    }
                }
            }
        }
    }
}
