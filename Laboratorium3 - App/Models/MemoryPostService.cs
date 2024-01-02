namespace Laboratorium3___App.Models
{
    public class MemoryPostService : IPostService
    {
        private readonly Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        private readonly IDateTimeProvider _timeProvider;

        public MemoryPostService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public int Add(Post post)
        {
            int id = _posts.Keys.Count != 0 ? _posts.Keys.Max() + 1 : 1;
            post.Id = id;
            post.Created = _timeProvider.GetCurrentTime(); // Ustawienie czasu utworzenia
            _posts.Add(id, post);
            return id;
        }

        public Post? FindById(int id)
        {
            _posts.TryGetValue(id, out var post);
            return post;
        }

        public List<Post> FindAll()
        {
            return _posts.Values.ToList();
        }

        public void Delete(int id)
        {
            _posts.Remove(id);
        }

        public void Update(Post post)
        {
            if (post == null || !_posts.ContainsKey(post.Id))
            {
                throw new ArgumentException("Post not found");
            }

            _posts[post.Id] = post;
        }
    }


}
