namespace ASPNetCoreWebAPI_Reactjs.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }


        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //This the actual key which used for relation
        //form the relation in the database by entity framework
        public int? PostId { get; set; }
    }
}
