﻿// Grader.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles creation and grading of students.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Scantron
{
    class Grader
    {
        GUI gui;

        // Holds the cards used to create the students.
        private List<Card> cards = new List<Card>();
        // Hold the list of students to be graded
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private Dictionary<int, List<Question>> answer_key = new Dictionary<int, List<Question>>();
        
        public Grader(GUI gui)
        {
            this.gui = gui;
        }
        
        public List<Student> Students
        {
            get
            {
                return students;
            }
        }
        
        public Dictionary<int, List<Question>> AnswerKey
        {
            get
            {
                return answer_key;
            }
            set
            {
                answer_key = value;
            }
        }

        /// <summary>
        /// Creates the students based off of the list of raw card data.
        /// </summary>
        /// <param name="raw_cards">Raw card data read in from Scantron.</param>
        /// <param name="partial_wids">Holds potential partial_wids; Null if no partial wids are found</param>
        public void CreateStudents(List<string> raw_cards, ref List<string> partial_wids)
        {
            for (int i = 0; i < raw_cards.Count; i++)
            {
                cards.Add(new Card(raw_cards[i]));
            }

            foreach (Card card in cards)
            {
                // Checks for a partial wid on the card; 
                // We want to create a student regardless to retain the scores read in (at this point);
                if (card.WID.Contains('-'))
                {
                    partial_wids.Add(card.WID);
                }

                Student student = new Student(card);

                if (students.Exists(item => item.WID == card.WID))
                {
                    student = students.Find(item => item.WID == card.WID);
                    student.Cards.Add(card);
                }
                else
                {
                    students.Add(student);
                }
            }

            foreach (Student student in students)
            {
                student.CreateResponse();
            }
        }

        /// <summary>
        /// Check student answers against the answer key.
        /// </summary>
        /// <returns>True if no errors occurred.</returns>
        public bool GradeStudents()
        {
            foreach (Student student in students)
            {
                int test_version = student.TestVersion;

                try
                {
                    for (int i = 0; i < answer_key[0].Count; i++)
                    {
                        student.Response[i].Grade(answer_key[test_version - 1][i]);
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    gui.DisplayMessage("Student " + student.WID + " has " + student.Response.Count + " questions associated with them."
                                        + " If this is too few, the student filled out the WID on one or more of their cards incorrectly."
                                        + " If this is the correct number, you may have entered too many questions on the answer key.");
                    return false;
                }
                catch (KeyNotFoundException e)
                {
                    gui.DisplayMessage("Student " + student.WID + " wrote down Test Version " + test_version + "."
                                        + " You did not create this many versions. Student cannot be graded.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Convert the students' grades into a CSV file to be uploaded to the Canvas gradebook.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            float points_possible = answer_key[0].Sum(question => question.Points);

            string info = "Student,ID,SIS User ID,SIS Login ID,Section," + answer_key.Count + Environment.NewLine +
                            "Points Possible,,,,," + points_possible + Environment.NewLine;
            int count = 0;

            foreach (Student student in students)
            {
                count++;
                info += "Scantron Card(s): " + count + ",," + student.WID + ",,," + student.Score() + Environment.NewLine;
            }

            return info;
        }
    }
}