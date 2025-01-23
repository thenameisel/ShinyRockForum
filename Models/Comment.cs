namespace ShinyRockForum.Models
{
    public class Comment
    {
        //int CommentId
        public int CommentId { get; set; }

        //string Content
        public string Content { get; set; } = string.Empty;
        //datatime CreateDate
        public DateTime CreateDate { get; set; } = DateTime.Now;

        //int DiscussionId(foreign key)
        public int DiscussionId { get; set; }
    }
}
