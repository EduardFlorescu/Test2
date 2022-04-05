using System;
using System.Collections.Generic;
using System.Text;

namespace Exercices.Model
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public QuestionTypeEnum QuestionType { get; set; }
    }
}
