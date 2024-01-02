using Data.Entities;
using Laboratorium3___App.Models;
namespace Laboratorium3___App.Models
{
    public class PostMappercs
    {
        public static PostEntity GetEntityFromModel(Post post)
        {
            return new PostEntity()
            {
                Id = post.Id,
                Content = post.Content,
                Author = post.Author,
                PublicationDate = post.PublicationDate,
                Tags = post.Tags,
                Comment = post.Comment
            };
        }

        public static Post GetModelFromEntity(PostEntity entity)
        {
            return new Post()
            {
                Id = entity.Id,
                Content = entity.Content,
                Author = entity.Author,
                PublicationDate = entity.PublicationDate,
                Tags = entity.Tags,
                Comment = entity.Comment
            };
        }
    }
}
