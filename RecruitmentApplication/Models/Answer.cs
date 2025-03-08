using RecruitmentApplication.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentApplication.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string AnswerText { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}