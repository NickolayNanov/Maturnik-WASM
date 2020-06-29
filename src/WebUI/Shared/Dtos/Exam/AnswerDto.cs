namespace Maturnik.WebUI.Shared.Dtos.Exam
{
    public class AnswerDto
    {
        public bool IsSelected { get; set; }

        public string Content { get; set; }

        public int NumberInQuestion { get; set; }

        public string BackgroundColor { get; set; } = "white";
    }
}
