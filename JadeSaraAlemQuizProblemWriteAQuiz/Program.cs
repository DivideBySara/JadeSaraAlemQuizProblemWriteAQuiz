using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

/*
 * Sara Jade
 * 9/11/17
 * 
 * Alemneh Asefa gave me this problem to solve:
 * 
 * Write a program that allows the user to create a simple quiz.
 * 1) Prompt the user for a name for the quiz and how many questions should be on it.
 * 2) The prompt the user for each question and its answer to store in a data structure.
 * 3) After all questions and answer have been submitted, print the name of the quiz.
 * 4) Then show each quiz question, prompting the user for answers.
 * 5) Score the quiz.
 * 
 */ 

namespace JadeSaraAlemQuizProblemWriteAQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string quizName = string.Empty;
            Dictionary<string, int> myQuiz = new Dictionary<string, int>();

            WriteLine("Welcome to the Math Quiz Creator!");
            GetQuizInfo(quizName, myQuiz);
            StartQuiz(quizName, myQuiz);
            ScoreQuiz(myQuiz);

            ReadKey();
        }

        private static void ScoreQuiz(Dictionary<string, int> myQuiz)
        {
            int correctAnswers = 0;

            foreach (KeyValuePair<string, int> item in myQuiz)
            {
                if (item.Value == 1)
                {
                    ++correctAnswers;
                } // else do nothing
            }

            WriteLine($"\nYou scored {correctAnswers} out of {myQuiz.Count} correct");
        }

        private static void StartQuiz(string quizName, Dictionary<string, int> myQuiz)
        {
            int answer = 0;

            WriteLine($"\n{quizName}");

            for (int i = 0; i < myQuiz.Count; ++i)
            {
                Write($"#{i + 1}: {myQuiz.Keys.ElementAt(i)} ");
                answer = Int32.Parse(ReadLine());

                if (answer == myQuiz.Values.ElementAt(i))
                {
                    myQuiz[myQuiz.Keys.ElementAt(i)] = 1;
                }
                else
                {
                    myQuiz[myQuiz.Keys.ElementAt(i)] = 0;
                }
            }
        }

        private static void GetQuizInfo
            (string quizName, Dictionary<string, int> myQuiz)
        {
            int numQuestions = 0;
            string question = string.Empty;
            int answer = 0;
            
            Write("\nWhat is the name of your math quiz? ");
            quizName = ReadLine();
            Write("How many questions are on your quiz? " +
                "Enter a number from 1 to 10: ");
            numQuestions = Int32.Parse(ReadLine());

            for (int i = 0; i < numQuestions; ++i)
            {
                Write($"\nMath problem #{i + 1}: ");
                question = ReadLine();
                Write($"Enter the answer to #{i + 1} as an integer: ");
                answer = Int32.Parse(ReadLine());

                myQuiz.Add(question, answer);
            }
        }
    }
}
