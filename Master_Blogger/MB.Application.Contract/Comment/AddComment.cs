namespace MB.Application.Contract.Comment
{
    public class AddComment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long ArticleId { get; set; }
        public string Message { get; set; }

     }
}
