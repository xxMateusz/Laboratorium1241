namespace Laboratorium3___App.Models
{
    public interface IPostService
    {
        int Add(Post post);
        Post? FindById(int id);
        List<Post> FindAll();
        void Delete(int id);
        void Update(Post post);
    }
}
