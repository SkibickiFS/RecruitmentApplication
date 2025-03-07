using System.ComponentModel.DataAnnotations;

public class Question
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Question text is required.")]
    public string Text { get; set; }

}
