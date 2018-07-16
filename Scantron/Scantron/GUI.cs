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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //Requires .Net 4
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace Scantron
{
    class GUI
    {
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        private string raw_scantron_output;
        // Test Data. Has two students for a 150 question exam. One has blank questions.
        //private string raw_scantron_output = "b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa00C#Q0#\\Fb#T0#\\Fa#D0D#O0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0C#J0#\\Fa#I0C#J0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#E0E#I0#\\Fb#T0#\\Fa000F000F#L0#\\Fb#T0#\\Fa00F#J0E#F0#\\Fb#T0#\\Fa0D#R0#\\FaD#S0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0C#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E#G0#\\Fb#T0#\\Fa0E#D0F#D0C#H0#\\FaE#D0D#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0F#D0B#E0#\\Fb#T0#\\Fa000D#D0E#D0D#F0#\\Fb#T0#\\Fa00D#D0F#D0E#G0#\\Fb#T0#\\Fa0D#D0F#D0F#H0#\\FaD#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E0005000#\\Fb#T0#\\Fa0E#D0E#D0D#D06000#\\FaE#D0E#D0D#I0#\\F$b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000F#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0F#M0#\\Fb#T0#\\Fa#I0E#J0#\\Fb#T0#\\FaE#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0E#J0#\\Fb#T0#\\FaD0F0F#E0F#I0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa0F#E0F#E0E#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa00D#G0F00D#F0#\\Fb#T0#\\FaD#D0C0F0E0D#H0#\\Fb#T0#\\Fa0D0D#D0E#K0#\\Fb#T0#\\Fb#T0#\\Fb#T0#\\Fa#F0F#G0D#E0#\\Fa#D0D#G0E#G0#\\Fb#T0#\\Fb#T0#\\Fa0F#G0D#J0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#E0F#F0C0C#E0#\\Fb#T0#\\Fa#D0F0C0D0D00C#F0#\\FaF0EF#G0C#H0#\\Fb#T0#\\Fb#T0#\\FaE#F0E#H07000#\\Fb#T0#\\Fa0C#D0D0D#E0C#E0#\\Fb#T0#\\Fa00D00C000D00F#G0#\\Fb#T0#\\Fa#D0C#E0E#I0#\\Fa000C#G0E0E004000#\\F$b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0D#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0D#J0#\\Fb#T0#\\Fb#T0#\\FaFBFFF00F00E#I0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#M0F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0EEEFE#E0#\\Fb#T0#\\Fa#E0DFFFD#J0#\\Fb#T0#\\FaEEDEE#O0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#E0FFFEF#J0#\\Fb#T0#\\FaFFFDE#O0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#J0FEEFF#E0#\\Fb#T0#\\Fb#T0#\\Fa#P07000#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0DDFFC03000#\\Fb#T0#\\Fa#E0FFDFD#J0#\\FaF#DE#O0#\\F$b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0F#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0D#J0#\\Fa#H0D#K0#\\Fb#T0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0F00F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#Q0300#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#S03#\\F$b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00D#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0D#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#H0E#K0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#G0F00F00F#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\F$b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0D#R0#\\Fb#T0#\\Fa00C#Q0#\\Fb#T0#\\Fa#F0F#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0F#N0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#I0D#J0#\\Fa#H0D#K0#\\Fb#T0#\\Fb#T0#\\Fa#G05#L0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#J0F00F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#Q0300#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\F$";
        private Form scantron_form;
        private TextBox uxInstructionBox;
        private Panel uxStudentResponsePanel;
        private ComboBox uxStudentSelector;
        private Panel uxAnswerKeyPanel;
        private List<Control> question_panels = new List<Control>();

        private Grader grader;

        public GUI(Form scantron_form)
        {
            this.scantron_form = scantron_form;
            
            uxInstructionBox = (TextBox) scantron_form.Controls.Find("uxInstructionBox", true)[0];
            uxStudentResponsePanel = (Panel)scantron_form.Controls.Find("uxStudentResponsePanel", true)[0];
            uxStudentSelector = (ComboBox) scantron_form.Controls.Find("uxStudentSelector",true)[0];
            uxAnswerKeyPanel = (Panel) scantron_form.Controls.Find("uxAnswerKeyPanel", true)[0];

            foreach (Control control in uxAnswerKeyPanel.Controls)
            {
                question_panels.Add(control);
            }

            uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                    "then click on 'Start' within this window.";

            grader = new Grader(this);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
        
        public void Start()
        {
            if (!serial_port.IsOpen)
            {
                serial_port.Open();
            }

            /*uxInstructionBox.Text = "Now press Start on the Machine to begin scanning." + Environment.NewLine +
                                        "Once all the cards have successfully scanned, " + Environment.NewLine +
                                        "press the 'Stop' within this window.";*/
            uxInstructionBox.Text = "";
            raw_scantron_output = "";
            
            serial_port.Write(">");
            serial_port.Write("+");
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        // This method is an event handler for the serial port.
        // Rewrote this in anticipation for manually controlling the Scantron machine. Might no work at all lol.
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serial_port = (SerialPort)sender;
            string data = serial_port.ReadExisting();

            if (data.Length > 1)
            {
                raw_scantron_output += data;
                uxInstructionBox.Text += data;
                serial_port.Write("+");
            }
            else
            {
                serial_port.Write("<");
            }
        }

        public void Stop()
        {
            if (serial_port.IsOpen)
            {
                serial_port.Close();
            }

            grader.CreateCards(raw_scantron_output);
            grader.CreateStudents();

            // If no students were created, (this should already be taken care of in the Stop event handler), 
            // we want to set the state back to the start button and start over.
            if (grader.Students.Count == 0)
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";

                MessageBox.Show("Something went wrong when scanning the cards." + Environment.NewLine +
                                Environment.NewLine +
                                "Please ensure the cards are not stuck together," + Environment.NewLine +
                                "backwards, or reversed and reload the hopper.");
            }

            // We cannot create students if raw_scantron_output is empty.
            // Sets the program to initial state of the program.
            if (raw_scantron_output.Equals(""))
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";

                MessageBox.Show("Something went wrong when scanning the cards." + Environment.NewLine +
                                Environment.NewLine +
                                "Please ensure the cards are not stuck together," + Environment.NewLine +
                                "backwards, or reversed and reload the hopper.");
            }
            else
            {
                uxInstructionBox.Text = "Please insert a USB drive into the computer" + Environment.NewLine +
                                        "Then press 'Create File' to create and save" + Environment.NewLine +
                                        "a file onto the USB drive";
            }
        }

        public void Restart()
        {
            uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                    "then click on 'Start' within this window.";
        }

        public void Enter()
        {
            TextBox uxNumberOfQuestions = (TextBox) scantron_form.Controls.Find("uxNumberOfQuestions",true)[0];

            int number_of_questions = Convert.ToInt32(uxNumberOfQuestions.Text);

            if (number_of_questions <= 250 && number_of_questions > 0)
            {
                uxAnswerKeyPanel.Controls.Clear();

                for (int i = 0; i < number_of_questions; i++)
                {
                    Panel panel = new Panel
                    {
                        BackColor = Color.MediumPurple,
                        Location = new Point(3, 3 + 26 * i),
                        Size = new Size(420, 22)
                    };

                    for (int j = 0; j < 5; j++)
                    {
                        CheckBox checkbox = new CheckBox
                        {
                            Location = new Point(73 + 39 * j, 3),
                            Size = new Size(33, 17),
                            Text = ((char)(j + 65)).ToString()
                        };
                        panel.Controls.Add(checkbox); // Checkboxes are added first so they are indices 0-4.
                    }

                    NumericUpDown updown = new NumericUpDown
                    {
                        Location = new Point(268, 1),
                        Minimum = 1,
                        DecimalPlaces = 2,
                        Size = new Size(58, 20)
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
                        Text = "Question" + (i + 1)
                    };

                    panel.Controls.Add(updown); // Index 5
                    panel.Controls.Add(partial_credit); // Index 6
                    panel.Controls.Add(label); // Index 7

                    uxAnswerKeyPanel.Controls.Add(panel);
                }
            }
            else
            {
                MessageBox.Show("Enter a number from 1-150.");
            }
        }

        public void CreateAnswerKey()
        {
            grader.AnswerKey = new List<Question>();

            CheckBox checkbox;
            NumericUpDown updown;

            int number_of_questions = uxAnswerKeyPanel.Controls.Count;
            char[] answer = new char[5];
            float points = 0;
            bool partial_credit = false;

            for (int i = 0; i < number_of_questions; i++)
            {
                answer = new char[5];

                // This loop cycles through the first 5 controls in the current question panel, which are the checkboes for A-E.
                for (int j = 0; j < 5; j++)
                {
                    checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[j];
                    if (checkbox.Checked)
                    {
                        answer[j] = (char)(65 + j);
                    }
                    else
                    {
                        answer[j] = ' ';
                    }
                }

                updown = (NumericUpDown)uxAnswerKeyPanel.Controls[i].Controls[5];
                points = (float)updown.Value;

                // Checks the current question panel's partial credit checkbox.
                checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[6];
                if (checkbox.Checked)
                {
                    partial_credit = true;
                }
                else
                {
                    partial_credit = false;
                }

                grader.AnswerKey.Add(new Question(answer, points, partial_credit));
            }

            MessageBox.Show("Answer key created!");
        }

        public void Grade()
        {
            if(grader.GradeStudents())
            {
                WriteFile();

                uxStudentSelector.Items.Clear();
                foreach (Student student in grader.Students)
                {
                    uxStudentSelector.Items.Add(student.WID);
                }
            }
            else
            {
                return;
            }
        }

        // Write the file to be uploaded to the Canvas gradebook.
        private void WriteFile()
        {
            string file = "";

            // We want to write to a file and use what StudentExamInfo returns to print to a file.
            foreach (Student student in grader.Students)
            {
                file += grader.ToString();
            }

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

        // Populates the student answer panel with question panels that show the selected student's response.
        public void SelectStudent()
        {
            Student student = grader.Students.Find(item => item.WID == uxStudentSelector.Text);

            uxStudentResponsePanel.Controls.Clear();

            for (int i = 0; i < grader.AnswerKey.Count; i++)
            {
                Panel panel = new Panel
                {
                    BackColor = Color.Green,
                    Location = new Point(3, 3 + 26 * i),
                    Size = new Size(268, 22)
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

                    if (student.Response[i].Answer[j] != ' ')
                    {
                        checkbox.Checked = true;
                    }

                    panel.Controls.Add(checkbox); // Checkboxes are added first so their indices are 0-4.
                }

                Label label = new Label
                {
                    Location = new Point(3, 3),
                    Size = new Size(70, 13),
                    Text = "Question" + (i + 1)
                };

                for (int k = 0; k < 5; k++)
                {
                    CheckBox response_checkbox = (CheckBox)panel.Controls[k];
                    CheckBox answer_key_checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[k];

                    if (response_checkbox.Checked != answer_key_checkbox.Checked)
                    {
                        panel.BackColor = Color.Red;
                        break;
                    }
                }

                panel.Controls.Add(label);

                uxStudentResponsePanel.Controls.Add(panel);
            }
        }

        /// <summary>
        /// Displays the "next" students responses in the uxStudentResponsePanel
        /// </summary>
        /// <param name="location">Keeps track of the position in the list</param>
        public void NextStudent(ref int location)
        {
            if (grader.Students[location + 1] == null)
            {
                throw new IndexOutOfRangeException();
            }
            
            else
            {
                Student student = grader.Students[location + 1];

                uxStudentResponsePanel.Controls.Clear();

                for (int i = 0; i < grader.AnswerKey.Count; i++)
                {
                    Panel panel = new Panel
                    {
                        BackColor = Color.Green,
                        Location = new Point(3, 3 + 26 * i),
                        Size = new Size(268, 22)
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

                        if (student.Response[i].Answer[j] != ' ')
                        {
                            checkbox.Checked = true;
                        }

                        panel.Controls.Add(checkbox); // Checkboxes are added first so their indices are 0-4.
                    }

                    Label label = new Label
                    {
                        Location = new Point(3, 3),
                        Size = new Size(70, 13),
                        Text = "Question" + (i + 1)
                    };

                    for (int k = 0; k < 5; k++)
                    {
                        CheckBox response_checkbox = (CheckBox)panel.Controls[k];
                        CheckBox answer_key_checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[k];

                        if (response_checkbox.Checked != answer_key_checkbox.Checked)
                        {
                            panel.BackColor = Color.Red;
                            break;
                        }
                    }

                    panel.Controls.Add(label);

                    uxStudentResponsePanel.Controls.Add(panel);

                }
            }
        }

        /// <summary>
        /// Displays the "previous" students responses in the uxStudentResponsePanel
        /// </summary>
        /// <param name="location">Keeps track of the position in the list</param>
        public void PreviousStudent(ref int location)
        {
                throw new NotImplementedException();
        }
    }
}
