using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentApplication.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Question text is required.")]
        public string Text { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}