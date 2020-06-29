using Maturnik.Domain.Common;

namespace Maturnik.Domain.Entities
{
    public class Answer : BaseEntity<int>
    {

        public Answer()
        {

        }

        public Answer(string content)
        {
            Content = content;
        }

        public string Content { get; set; }
        public int AnswerNumber { get; set; }
        public int QuestinId { get; set; }
        public Question Question { get; set; }
    }
}
