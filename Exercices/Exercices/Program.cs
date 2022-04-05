using Exercices.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercices
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Survey survey = new Survey();
            survey.Questions = new List<Question> {
                 new Question
                 {
                     QuestionId = "Q1",
                     Text = "Do you have a car? (Single answer)",
                     QuestionType = QuestionTypeEnum.SingleAnswer
                 },
                 new Question
                 {
                     QuestionId = "Q2",
                     Text = "Which of the following cars would you buy? (Multiple answer)",
                     QuestionType = QuestionTypeEnum.MultipleAnswers
                 }
            };

            survey.Answers = new List<Answer>{
                new Answer
                {
                    AnswerId = "Q1_A1",
                    QuestionId = "Q1",
                    Code = "1",
                    Text = "Yes, I have a car."
                },
                new Answer
                {
                    AnswerId = "Q1_A2",
                    QuestionId = "Q1",
                    Code = "2",
                    Text = "No, I don't have a car."
                },
                new Answer
                {
                    AnswerId = "Q1_A3",
                    QuestionId = "Q1",
                    Code = "3",
                    Text = "No, I don't have a car, but I plan to buy one."
                },
                //////
                 new Answer
                {
                    AnswerId = "Q2_A1",
                    QuestionId = "Q2",
                    Code = "1",
                    Text = "Opel"
                },
                new Answer
                {
                    AnswerId = "Q2_A2",
                    QuestionId = "Q2",
                    Code = "2",
                    Text = "Audi"
                },
                new Answer
                {
                    AnswerId = "Q2_A3",
                    QuestionId = "Q2",
                    Code = "3",
                    Text = "BMW"
                },
                 new Answer
                {
                    AnswerId = "Q2_A4",
                    QuestionId = "Q2",
                    Code = "4",
                    Text = "Volkswagen"
                },
                new Answer
                {
                    AnswerId = "Q2_A5",
                    QuestionId = "Q2",
                    Code = "5",
                    Text = "None of these cars."
                }
            };

            Dictionary<Question, List<Answer>> surveyResults = new Dictionary<Question, List<Answer>>();

            foreach (var question in survey.Questions)
            {
                Console.WriteLine($"{question.QuestionId}. {question.Text}");
                //
                var answers = survey.Answers.Where(a => a.QuestionId == question.QuestionId);
                foreach (var answer in answers)
                {
                    Console.WriteLine($"{answer.Code}. {answer.Text}");
                }
                var userInput = Console.ReadLine();
                if (question.QuestionType == QuestionTypeEnum.SingleAnswer)
                {
                    surveyResults.Add(question, new List<Answer> { answers.FirstOrDefault(a => a.Code == userInput) });
                }
                else if (question.QuestionType == QuestionTypeEnum.MultipleAnswers)
                {
                    foreach (var ans in answers)
                    {
                        if (userInput.Contains(ans.Code))
                        {
                            if (surveyResults.ContainsKey(question))
                            {
                                surveyResults[question].Add(ans);
                            }
                            else
                            {
                                surveyResults[question] = new List<Answer> { ans };
                            }
                        }
                    }
                }
            }

            foreach (var sRes in surveyResults)
            {
                var str = string.Join(",", sRes.Value.Select(a => a.AnswerId).ToList());
                Console.WriteLine($"{sRes.Key.QuestionId}, {str}");
            }


        }
    }
}
