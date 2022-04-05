using System;
using System.Collections.Generic;
using System.Text;

namespace Exercices.Model
{
    public class Survey
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
