namespace CinemaBooking.ViewModels
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int AccountId { get; set; }
        public string AuthorName { get; set; }
        public byte Status { get; set; }
        public List<BlogCommentDto> Comments { get; set; } = new List<BlogCommentDto>();
    }

    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AccountId { get; set; }
    }

    public class BlogCommentDto
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string FullName { get; set; }
        public byte Status { get; set; }
        public byte CommentType { get; set; } // = 2 for blog comments
    }
}