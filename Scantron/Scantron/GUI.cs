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
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Scantron
{
    public class GUI
    {
        private Grader grader;

        // GUI objects that we need data from.
        private Form scantron_form;
        private Label uxAnswerKeyInstructionLabel;
        private Label uxScanInstructionLabel;
        private Label uxGradeInstructionLabel;
        private Panel uxStudentResponsePanel;
        private ComboBox uxStudentSelector;
        private TabControl uxAnswerKeyTabControl;
        private TextBox uxExamNameTextBox;
        private NumericUpDown uxNumberOfQuestionsNumericUpDown;
        private NumericUpDown uxNumberOfVersionsNumericUpDown;
        private NumericUpDown uxAllQuestionPointsNumericUpDown;
        private CheckBox uxAllPartialCreditCheckBox;
        private Button uxPreviousButton;
        private Button uxNextButton;
        private Label uxVersionLabel;
        private Label uxScoreLabel;
        private Label uxCouldNotBeGradedLabel;
        private TextBox uxCardListTextBox;
        private TextBox uxStatusTextBox;
        private TabControl uxMainTabControl;
        private TabPage uxStartTabPage;
        private TabPage uxAnswerKeyTabPage;
        private TabPage uxScanTabPage;
        private TabPage uxGradeTabPage;
        private TabPage uxCreateFileTabPage;
        private TextBox uxStartInstructionTextBox;
        private Label uxCreateFileInstructionLabel;
        private Button uxFinishButton;

        // Holds the raw card data from the Scantron.
        private List<string> raw_cards = new List<string>();

        // Scanner communication fields
        private ScannerCom scannerCom;
        private bool toAbort = true;
        Task<List<string>> task;
        private bool ScantronCardAnswerKey = false;

        public GUI(Form scantron_form)
        {
            this.scantron_form = scantron_form;
            scannerCom = new ScannerCom();
            grader = new Grader(this);

            uxAnswerKeyInstructionLabel = (Label) scantron_form.Controls.Find("uxAnswerKeyInstructionLabel", true)[0];
            uxScanInstructionLabel = (Label) scantron_form.Controls.Find("uxScanInstructionLabel", true)[0];
            uxGradeInstructionLabel = (Label) scantron_form.Controls.Find("uxGradeInstructionLabel", true)[0];
            uxStudentResponsePanel = (Panel) scantron_form.Controls.Find("uxStudentResponsePanel", true)[0];
            uxStudentSelector = (ComboBox) scantron_form.Controls.Find("uxStudentSelectorComboBox",true)[0];
            uxAnswerKeyTabControl = (TabControl) scantron_form.Controls.Find("uxAnswerKeyTabControl", true)[0];
            uxExamNameTextBox = (TextBox) scantron_form.Controls.Find("uxExamNameTextBox", true)[0];
            uxNumberOfQuestionsNumericUpDown = (NumericUpDown)scantron_form.Controls.Find("uxNumberOfQuestionsNumericUpDown", true)[0];
            uxNumberOfVersionsNumericUpDown = (NumericUpDown) scantron_form.Controls.Find("uxNumberOfVersionsNumericUpDown", true)[0];
            uxAllQuestionPointsNumericUpDown = (NumericUpDown) scantron_form.Controls.Find("uxAllQuestionPointsNumericUpDown", true)[0];
            uxAllPartialCreditCheckBox = (CheckBox) scantron_form.Controls.Find("uxAllPartialCreditCheckBox", true)[0];
            uxPreviousButton = (Button) scantron_form.Controls.Find("uxPreviousButton", true)[0];
            uxNextButton = (Button) scantron_form.Controls.Find("uxNextButton", true)[0];
            uxVersionLabel = (Label) scantron_form.Controls.Find("uxVersionLabel", true)[0];
            uxScoreLabel = (Label) scantron_form.Controls.Find("uxScoreLabel", true)[0];
            uxCouldNotBeGradedLabel = (Label) scantron_form.Controls.Find("uxCouldNotBeGradedLabel", true)[0];
            uxCardListTextBox = (TextBox) scantron_form.Controls.Find("uxCardListTextBox", true)[0];
            uxStatusTextBox = (TextBox) scantron_form.Controls.Find("uxStatusTextBox", true)[0];
            uxMainTabControl = (TabControl) scantron_form.Controls.Find("uxMainTabControl", true)[0];
            uxStartTabPage = (TabPage) scantron_form.Controls.Find("uxStartTabPage", true)[0];
            uxAnswerKeyTabPage = (TabPage) scantron_form.Controls.Find("uxAnswerKeyTabPage", true)[0];
            uxScanTabPage = (TabPage) scantron_form.Controls.Find("uxScanTabPage", true)[0];
            uxGradeTabPage = (TabPage) scantron_form.Controls.Find("uxGradeTabPage", true)[0];
            uxCreateFileTabPage = (TabPage) scantron_form.Controls.Find("uxCreateFileTabPage", true)[0];
            uxStartInstructionTextBox = (TextBox) scantron_form.Controls.Find("uxStartInstructionTextBox", true)[0];
            uxCreateFileInstructionLabel = (Label) scantron_form.Controls.Find("uxCreateFileInstructionLabel", true)[0];
            uxFinishButton = (Button) scantron_form.Controls.Find("uxFinishButton", true)[0];

            InsertInstructionText();
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
        /// Updates main instruction boxes with text.
        /// </summary>
        public void InsertInstructionText()
        {
            uxStartInstructionTextBox.Text =    "Welcome to the new Scantron program!" + Environment.NewLine + Environment.NewLine +
                                                "This program is intended to have the same functionality as CanConvert and the previous Scantron program all in one location." + Environment.NewLine +
                                                "If you used CanConvert, follow the steps for grading within this program. If you are going to use the Canvas Scantron tool that utilizes Quizzes, there will be notes throughout telling you which steps you may skip." + Environment.NewLine + Environment.NewLine +
                                                "If you have any feedback regarding the appearance or workflow of the Scantron progam, please email schweer@ksu.edu and we will attempt to incorporate it within the semester if it is feasible. We need intructors to use and test the program to see if it suits their needs, so all feedback is welcome." + Environment.NewLine + Environment.NewLine +
                                                "To begin, set your Scantron cards in the tray by following the pictures to the right:" + Environment.NewLine +
                                                "1. Blow out any dust that could be on the scanner." + Environment.NewLine +
                                                "2. Set the cards in the scanner flush against the wall." + Environment.NewLine +
                                                "3. Place the guider lined up against the stack of cards as straight as possible." + Environment.NewLine + Environment.NewLine +
                                                "Click on the Answer Key tab along the top and follow the instructions to continue.";

            uxAnswerKeyInstructionLabel.Text =  "1. Click Reset to ensure no data is leftover from the last person to use this program.\n" +
                                                "2. Enter the name for the exam as you want it to appear in the Canvas gradebook.\n" +
                                                "3. Specify the number of versions and questions the exam has. If you are using the Canvas Scantron tool, skip to step 7.\n" +
                                                "4. Specify how many points each questions is worth, and if a question has multiple correct answers, specify if students will be given partial credit.\n" +
                                                "5. There are options to change the points for all questions in the exam and to make them all partial credit.\n" +
                                                "6. Fill in the answer key by checking the correct answers for each question on all versions you have made.\n" +
                                                "7. Click Create Answer Key, then go to the Scan tab.";

            uxScanInstructionLabel.Text =       "1. Click Start within this Window.\n" +
                                                "2. After your cards have finished scanning, they will appear in the Scanned Cards panel.\n" +
                                                "3. The Errors panel will tell you which cards have WIDs that were filled out incorrectly, test versions that are higher than the number you specified, or if a card has an unanswered question.\n" +
                                                "4. You can correct anything in the Scanned Cards panel by erasing and typing like you would any normal text. Be careful not to type in more characters than you deleted or you will likely need to re-scan your cards.\n" +
                                                "5. Once you have made corrections, click Save Changes, then click Create Students.\n" +
                                                "6. If you are grading here, click on the Grade tab. If you are using the Canvas Scantron Tool, click on the Create File tab.\n\n" +
                                                "You may click Pause to halt the Scantron at any time and click Resume to continue scanning.\n" +
                                                "The Stop button is for aborting the entire card scanning process.";

            uxGradeInstructionLabel.Text =      "1. Click Grade Students. You will be asked to give a name to the .csv file you will upload to the Canvas Gradebook.\n" +
                                                "2. The panel will populate with student responses. You can navigate them with the drop down box or with the Previous and Next buttons.\n" +
                                                "3. Questions highlighted in green were given full points, questions highlighted in orange were given partial credit, and questions highlighted in red were given 0 points.\n" +
                                                "4. Once you are done reviewing the student responses, click the Create File tab.";

            uxCreateFileInstructionLabel.Text = "1. Click the Gradebook button if you have graded within this program, otherwise click one of the Scantron Tool buttons.\n" +
                                                "2. If your exam has questions that have more than one answer, click the Multiple Answer button. The Single Andwer button will make a file with only one line per card.\n" +
                                                "3. The Gradebook method with give you a .csv file. Go to your course, go to Grades, then click import and select the file to upload it.\n" +
                                                "4. The Canvas Scantron tool has a separate set of instructions here: https://public.online.k-state.edu/tools/scantron/index.html" + ".\n" +
                                                "5. Once you are confident your file is saved, click the Finish button to put the program back at the beginning.";
        }

        /// <summary>
        /// Opens the serial port; begins scanning the cards.
        /// Ref: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport.open(v=vs.110).aspx
        /// </summary>
        public void Start()
        {
            if (grader.AnswerKey.Count < 1 && ScantronCardAnswerKey == false)
            {
                DisplayMessage("You have not created an answer key. Go back to the Answer Key tab and follow the instructions.");
                return;
            }

            ScannerCom.ToAbort.Set();

            try
            {
                scannerCom.Start();
            }
            catch(IOException)
            {
                DisplayMessage("Scantron machine is not connected to computer by port COM1.");
                return;
            }

            task = new Task<List<string>>(() => scannerCom.Run(raw_cards));
            task.Start();
            task.Wait();

            grader.CreateCards(raw_cards);
            UpdateCardList();
        }

        /// <summary>
        /// Close the serial port.
        /// </summary>
        public void Stop()
        {
            scannerCom.Stop();
        }

        /// <summary>
        /// Pauses the scantron.
        /// </summary>
        public void Pause()
        {
            ScannerCom.ToAbort.Reset(); //Aborts & Stops
            toAbort = false;
        }

        /// <summary>
        /// Resumes the scantron.
        /// </summary>
        public void Resume()
        {
            ScannerCom.ToAbort.Set(); // Does NOT Abort & Stop
            toAbort = true;
        }

        /// <summary>
        /// Reset program to initial state.
        /// </summary>
        public void Reset()
        {
            Panel panel;

            raw_cards.Clear();
            grader.Cards.Clear();
            grader.Students.Clear();
            grader.PartialWids.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 250; j++)
                {
                    panel = (Panel) uxAnswerKeyTabControl.TabPages[i].Controls[j];
                    panel.Visible = false;
                }
            }
            for (int i = 0; i < 250; i++)
            {
                panel = (Panel) uxStudentResponsePanel.Controls[i];
                panel.Visible = false;
            }

            uxExamNameTextBox.Text = "";
            uxNumberOfVersionsNumericUpDown.Value = 0;
            uxNumberOfQuestionsNumericUpDown.Value = 0;
            uxAnswerKeyTabControl.Enabled = true;
            uxAllQuestionPointsNumericUpDown.Value = 0;
            uxAllPartialCreditCheckBox.Checked = false;
            uxCardListTextBox.Text = "";
            uxStatusTextBox.Text = "";
            uxStudentSelector.Items.Clear();
            uxStudentSelector.Text = "";
            uxVersionLabel.Text = "Version: ";
            uxScoreLabel.Text = "Score: ";
            uxCouldNotBeGradedLabel.Visible = false;
            uxNextButton.Enabled = false;
            uxPreviousButton.Enabled = false;

            DisplayMessage("Data has been reset!");
        }

        /// <summary>
        /// Fill raw cards list with test data.
        /// </summary>
        public void TestData()
        {
            raw_cards = new List<string>();
            // Test Data. Has two students for a 150 question exam. One has blank answers.
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa00C#Q0#\\Fb#T0#\\Fa#D0D#O0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0C#J0#\\Fa#I0C#J0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#E0E#I0#\\Fb#T0#\\Fa000F000F#L0#\\Fb#T0#\\Fa00F#J0E#F0#\\Fb#T0#\\Fa0D#R0#\\FaD#S0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0C#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E#G0#\\Fb#T0#\\Fa0E#D0F#D0C#H0#\\FaE#D0D#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0F#D0B#E0#\\Fb#T0#\\Fa000D#D0E#D0D#F0#\\Fb#T0#\\Fa00D#D0F#D0E#G0#\\Fb#T0#\\Fa0D#D0F#D0F#H0#\\FaD#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E0005000#\\Fb#T0#\\Fa0E#D0E#D0D#D06000#\\FaE#D0E#D0D#I0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000F#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0F#M0#\\Fb#T0#\\Fa#I0E#J0#\\Fb#T0#\\FaE#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0E#J0#\\Fb#T0#\\FaD0F0F#E0F#I0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa0F#E0F#E0E#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa00D#G0F00D#F0#\\Fb#T0#\\FaD#D0C0F0E0D#H0#\\Fb#T0#\\Fa0D0D#D0E#K0#\\Fb#T0#\\Fb#T0#\\Fb#T0#\\Fa#F0F#G0D#E0#\\Fa#D0D#G0E#G0#\\Fb#T0#\\Fb#T0#\\Fa0F#G0D#J0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#E0F#F0C0C#E0#\\Fb#T0#\\Fa#D0F0C0D0D00C#F0#\\FaF0EF#G0C#H0#\\Fb#T0#\\Fb#T0#\\FaE#F0E#H07000#\\Fb#T0#\\Fa0C#D0D0D#E0C#E0#\\Fb#T0#\\Fa00D00C000D00F#G0#\\Fb#T0#\\Fa#D0C#E0E#I0#\\Fa000C#G0E0E004000#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0D#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0D#J0#\\Fb#T0#\\Fb#T0#\\FaFBFFF00F00E#I0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#M0F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0EEEFE#E0#\\Fb#T0#\\Fa#E0DFFFD#J0#\\Fb#T0#\\FaEEDEE#O0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#E0FFFEF#J0#\\Fb#T0#\\FaFFFDE#O0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#J0FEEFF#E0#\\Fb#T0#\\Fb#T0#\\Fa#P07000#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0DDFFC03000#\\Fb#T0#\\Fa#E0FFDFD#J0#\\FaF#DE#O0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0F#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0D#J0#\\Fa#H0D#K0#\\Fb#T0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0F00F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#Q0300#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#S03#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00D#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0D#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#H0E#K0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#G0F00F00F#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\F$");
            
            grader.CreateCards(raw_cards);
            UpdateCardList();
        }

        private static void ThreadAbort()
        {
            //This is an empty method for the dummy thread
        }

        private void UpdateCardList()
        {
            Card card;
            uxCardListTextBox.Text = "";
            string cards = "";
            string wid = "";
            int test_version = 1;
            string bad_wids = "";
            string bad_test_versions = "";
            string bad_answers = "";

            for (int i = 0; i < grader.Cards.Count; i++)
            {
                card = grader.Cards[i];

                wid = card.WID;
                test_version = card.TestVersion;

                cards += (i + 1) + ". WID: " + wid + " Test Version: " + test_version + " Sheet Number: " + card.SheetNumber + Environment.NewLine;
                
                if (wid.Contains("-") || wid[0] != '8')
                {
                    bad_wids += (i + 1) + " ";
                }

                if (test_version > grader.AnswerKey.Count || test_version <= 0)
                {
                    bad_test_versions += (i + 1) + " ";
                }

                foreach(Question question in card.Response)
                {
                    if (question.Answer == "     ")
                    {
                        bad_answers += (i + 1) + " ";
                        break;
                    }
                }
            }

            uxCardListTextBox.Text = cards;

            uxStatusTextBox.Text =  "Incomplete WIDs: " + bad_wids + Environment.NewLine + Environment.NewLine +
                                    "Invalid Test Versions: " + bad_test_versions + Environment.NewLine + Environment.NewLine +
                                    "Empty Answers: " + bad_answers;
        }

        /// <summary>
        /// Save changes made to WIDss, test version,and sheet numbers on cards list.
        /// </summary>
        public void SaveChanges()
        {
            if (grader.Cards.Count < 1)
            {
                DisplayMessage("No cards found. Follow the instructions on this page from the beginning.");
                return;
            }

            int wid_index;
            int version_index;
            int sheet_number_index;
            string wid;
            int version;
            int sheet_number;
            string card_line;

            List<string> card_list = new List<string>();
            char[] splitter = new char[] { '\n' };
            card_list = uxCardListTextBox.Text.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < card_list.Count; i++)
            {
                card_line = card_list[i];

                // Make sure the user didn't delete things.
                if (!(card_line.Contains(" WID: ") && card_line.Contains(" Version: ") && card_line.Contains(" Sheet Number: ")))
                {
                    DisplayMessage("Be sure to only edit the numbers.");
                    UpdateCardList();
                    return;
                }

                wid_index = card_line.IndexOf("WID:") + 5;
                version_index = card_line.IndexOf("Version:") + 9;
                sheet_number_index = card_line.IndexOf("Sheet Number:") + 14;

                wid = card_line.Substring(wid_index, 9);
                grader.Cards[i].WID = wid;

                version = (int)Char.GetNumericValue(card_line[version_index]);
                grader.Cards[i].TestVersion = version;

                sheet_number = (int)Char.GetNumericValue(card_line[sheet_number_index]);
                grader.Cards[i].SheetNumber = sheet_number;
            }


            DisplayMessage("Changes saved!");
            UpdateCardList();
        }

        /// <summary>
        /// Merges all cards with the same WIDs into one student.
        /// </summary>
        public void CreateStudents()
        {
            if (grader.Cards.Count == 0)
            {
                DisplayMessage("No cards found. Follow the instructions on this page from the beginning.");
                return;
            }

            grader.CreateStudents();
        }

        public void UseScantronCardAnswerKey()
        {
            // Use a button on first page
        }

        /// <summary>
        /// Create the answer key form with the specified number of questions and versions.
        /// </summary>
        public void UpdateAnswerForm()
        {
            CheckBox checkbox;

            foreach (TabPage tabpage in uxAnswerKeyTabControl.TabPages)
            {
                foreach (Panel panel in tabpage.Controls)
                {
                    panel.Visible = false;
                    
                    for (int i = 0; i < 5; i++)
                    {
                        checkbox = (CheckBox) panel.Controls[i];
                        checkbox.Checked = false;
                    }

                    checkbox = (CheckBox)panel.Controls[6];
                    checkbox.Checked = false;
                }
            }

            uxAllQuestionPointsNumericUpDown.Value = 1;
            uxAllPartialCreditCheckBox.Checked = false;

            int number_of_versions = (int) uxNumberOfVersionsNumericUpDown.Value;
            int number_of_questions = (int) uxNumberOfQuestionsNumericUpDown.Value;

            TabPage answer_key_tabpage;

            for (int i = 0; i < number_of_versions; i++)
            {
                answer_key_tabpage = uxAnswerKeyTabControl.TabPages[i];

                for (int j = 0; j < number_of_questions; j++)
                {
                    answer_key_tabpage.Controls[j].Visible = true;
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
                    updown.Value = uxAllQuestionPointsNumericUpDown.Value;
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
                    checkbox.Checked = uxAllPartialCreditCheckBox.Checked;
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
                Panel question_panel = new Panel
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
                    question_panel.Controls.Add(checkbox); // Checkboxes are added first so they are indices 0-4.
                }

                NumericUpDown points_updown = new NumericUpDown
                {
                    Location = new Point(268, 1),
                    DecimalPlaces = 2,
                    Size = new Size(58, 20),
                    Value = 1
                };

                CheckBox partial_credit_checkbox = new CheckBox
                {
                    Location = new Point(330, 3),
                    Size = new Size(100, 17),
                    Text = "Partial Credit"
                };

                Label question_label = new Label
                {
                    Location = new Point(3, 3),
                    Size = new Size(70, 13),
                    Text = "Question " + (j + 1)
                };

                question_panel.Controls.Add(points_updown); // Index 5
                question_panel.Controls.Add(partial_credit_checkbox); // Index 6
                question_panel.Controls.Add(question_label); // Index 7

                tabpage.Controls.Add(question_panel);
            }
        }

        /// <summary>
        /// Create the answer key from the filled out form.
        /// </summary>
        /// <returns>True if successful.</returns>
        public void CreateAnswerKey()
        {
            int number_of_versions = (int)uxNumberOfVersionsNumericUpDown.Value;
            int number_of_questions = (int)uxNumberOfQuestionsNumericUpDown.Value;

            if (uxExamNameTextBox.Text == "")
            {
                DisplayMessage("Enter a name for the exam.");
                return;
            }

            if (number_of_versions == 0 || number_of_questions == 0)
            {
                DisplayMessage("You have not created an answer key. Select the number of questions and versions" +
                                ", then fill out the answer key form.");
                return;
            }

            grader.AnswerKey = new Dictionary<int, List<Question>>();

            Panel question_panel;
            CheckBox checkbox;
            NumericUpDown points_updown;

            string answer = "";
            float points = 0;
            bool partial_credit = false;

            for (int i = 0; i < number_of_versions; i++)
            {
                grader.AnswerKey.Add(i, new List<Question>());
                
                for (int j = 0; j < number_of_questions; j++)
                {
                    answer = "";

                    question_panel = (Panel) uxAnswerKeyTabControl.TabPages[i].Controls[j];

                    // This loop cycles through the first 5 controls in the current question panel, which are the checkboes for A-E.
                    for (int k = 0; k < 5; k++)
                    {
                        checkbox = (CheckBox) question_panel.Controls[k];
                        if (checkbox.Checked)
                        {
                            answer += k + 1;
                        }
                        else
                        {
                            answer += " ";
                        }
                    }
                    
                    points_updown = (NumericUpDown) question_panel.Controls[5];
                    points = (float) points_updown.Value;
                    
                    // Checks the current question panel's partial credit checkbox.
                    checkbox = (CheckBox) question_panel.Controls[6];
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

            DisplayMessage("Answer Key successfully created!");
        }

        /// <summary>
        /// Grade the students.
        /// </summary>
        public void GradeStudents()
        {
            if (grader.AnswerKey.Count < 1)
            {
                DisplayMessage("You have not created an answer key. Go back to the Answer Key tab and follow the instructions.");
                return;
            }

            if (grader.Students.Count < 1)
            {
                DisplayMessage("No students found. Go back to the Scan tab and follow the instructions.");
                return;
            }

            grader.GradeStudents(uxExamNameTextBox.Text);
            uxStudentSelector.Items.Clear();
            foreach (Student student in grader.Students)
            {
                uxStudentSelector.Items.Add(student.WID);
            }

            uxNextButton.Enabled = true;
            uxPreviousButton.Enabled = true;
            NextStudent(); // Displays the first student in the index
        }

        /// <summary>
        /// Write the file to be uploaded to the Canvas gradebook.
        /// </summary>
        public void WriteFile(string type)
        {
            string file = "";
            string filter = "txt files (*.txt)|*.txt";

            if (type == "gradebook")
            {
                file = grader.GradebookFile();
                filter = "csv files (*.csv)|*.csv";
            }
            if (type == "single")
            {
                file = grader.ScantronToolSingleAnswerFile();
            }
            if (type == "multiple")
            {
                file = grader.ScantronToolMultipleAnswerFile();
            }

            // Then we have to start a file dialog to save the string to a file.
            SaveFileDialog uxSaveFileDialog = new SaveFileDialog
            {
                // Could be used to select the default directory ex. "C:\Users\Public\Desktop".
                InitialDirectory = "c:\\desktop",
                // Filter is the default file extensions seen by the user.
                Filter = filter,
                // FilterIndex sets what the user initially sees ex: 2nd index of the filter is ".txt".
                FilterIndex = 1
            };

            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = uxSaveFileDialog.FileName;
                // Stores the location of the file we want to save; use filenames for multiple.
                if (path.Equals(""))
                {
                    MessageBox.Show("You must enter a filename and select\n" +
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
                    MessageBox.Show("Student responses have been successfully recorded!");
                }
            }
            /*
            else
            {
                MessageBox.Show("An error occured while trying to save,\n" +
                                "The format for filenames should not include\n" +
                                "slashes, parentheticals, or symbols\n" +
                                "Please reload the hopper and ensure the\n" +
                                "cards are not stuck together, backwards,\n" +
                                "or reversed. ");
                //throw new IOException();
            }
            */
        }

        /// <summary>
        /// Populates the student answer panel with question panels that show the selected student's response.
        /// </summary>
        public void SelectStudent()
        {
            DisplayStudent(grader.Students.Find(student => student.WID == uxStudentSelector.Text));
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
                Panel question_panel = new Panel
                {
                    Location = new Point(3, 3 + 26 * i),
                    Size = new Size(350, 22),
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

                    question_panel.Controls.Add(checkbox); // Checkboxes are added first so their indices are 0-4.
                }

                Label points_label = new Label
                {
                    Location = new Point(268, 3),
                    Size = new Size(80, 13),
                    Text = "Points: 0"
                };

                Label question_label = new Label
                {
                    Location = new Point(3, 3),
                    Size = new Size(70, 13),
                    Text = "Question " + (i + 1)
                };

                question_panel.Controls.Add(points_label); // Index 5
                question_panel.Controls.Add(question_label); // Index 6

                uxStudentResponsePanel.Controls.Add(question_panel);
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
                uxPreviousButton.Enabled = false;
            }
            else
            {
                uxPreviousButton.Enabled = true;
            }

            if (uxStudentSelector.SelectedIndex == uxStudentSelector.Items.Count -1)
            {
                uxNextButton.Enabled = false;
            }
            else
            {
                uxNextButton.Enabled = true;
            }

            int test_version = student.TestVersion;
            uxVersionLabel.Text = "Version: " + test_version;
            uxScoreLabel.Text = "Score: " + student.Score();
            uxCouldNotBeGradedLabel.Visible = false;
            Panel question_panel;
            CheckBox response_checkbox;
            CheckBox answer_key_checkbox;

            foreach (Control control in uxStudentResponsePanel.Controls)
            {
                control.Visible = false;
            }

            if (grader.AnswerKey[0].Count > student.Response.Count || test_version > grader.AnswerKey.Keys.Count || test_version <= 0)
            {
                uxCouldNotBeGradedLabel.Visible = true;
                return;
            }
            else
            {
                // uxCouldNotBeGraded wasn't turning off on the students who were graded correctly
                uxCouldNotBeGradedLabel.Visible = false;
            }

            for (int i = 0; i < Math.Min(grader.AnswerKey[test_version - 1].Count, student.Response.Count); i++)
            {
                question_panel = (Panel)uxStudentResponsePanel.Controls[i];
                question_panel.Visible = true;

                if (student.Response[i].Points == grader.AnswerKey[test_version - 1][i].Points)
                {
                    question_panel.BackColor = Color.Green;
                }
                else if(student.Response[i].Points == 0)
                {
                    question_panel.BackColor = Color.Red;
                }
                else
                {
                    question_panel.BackColor = Color.Orange;
                }

                for (int j = 0; j < 5; j++)
                {
                    response_checkbox = (CheckBox)question_panel.Controls[j];
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

                question_panel.Controls[5].Text = "Points: " + student.Response[i].Points.ToString("0.00");
            }
        }

        public void Finish()
        {
            uxMainTabControl.SelectTab(uxStartTabPage);
            Reset();
        }
    }
}
