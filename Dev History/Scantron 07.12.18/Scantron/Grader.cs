﻿// Grader.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles button click events on the GUI.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scantron
{
    class Grader
    {
        // Holds the raw data split up by card.
        private List<string> cards = new List<string>();
        // Holds the students to be graded.
        private List<Card> students = new List<Card>();
        // Holds the answer key to compare to student responses.
        private List<Question> answer_key = new List<Question>(); // may need to be converted to a Dictionary<int, List<questions>> as well

        public Grader()
        {

        }

        public List<Card> Students
        {
            get
            {
                return students;
            }
        }

        public List<Question> AnswerKey
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

        // This method creates student objects and adds them to the students list.
        public void CreateStudents(string raw_scantron_output)
        {
            // Sets each reference value in cards equal to exactly one scantron card.
            cards = raw_scantron_output.Split('$').ToList<string>();

            // For each index/value in cards, create a student object and add to the list students.
            for (int i = 0; i < cards.Count - 1; i++)
            {
                students.Add(new Card(cards[i]));
            }
        }

        // Check student answers against the answer key. Canvas grading
        public void GradeStudents()
        {
            foreach (Card student in students)
            {
                for (int i = 0; i < answer_key.Count; i++)
                {
                    student.Response[i].Grade(answer_key[i]);
                }
            }
        }

        // Convert the students' grades into a CSV file to be uploaded to the Canvas gradebook.
        public override string ToString()
        {
            float points_possible = 0;
            foreach (Question question in answer_key)
            {
                points_possible += question.Points;
            }

            string info = "Student,ID,SIS User ID,SIS Login ID,Section," + answer_key.Count + Environment.NewLine +
                            "Points Possible,,,,," + points_possible + Environment.NewLine;
            int count = 0;

            foreach (Card student in students)
            {
                count++;
                info += "Scantron Card(s): " + count + ",," + student.WID + ",,," + student.Score();
            }

            return info;
        }
    }
}