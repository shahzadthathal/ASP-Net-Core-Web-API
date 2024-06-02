using ASPNetCoreWebAPI_Reactjs.Dtos.Comment;
using ASPNetCoreWebAPI_Reactjs.Models;

namespace ASPNetCoreWebAPI_Reactjs.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.CommentId,
                Content = commentModel.Content,
                CreatedAt = commentModel.CreatedAt,
                

            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Content = commentDto.Content,
                PostId = (int)commentDto.PostId
            };
        }

        public static Comment ToCommentFromUpdateDto(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Content = commentDto.Content,
            };
        }
    }
}
