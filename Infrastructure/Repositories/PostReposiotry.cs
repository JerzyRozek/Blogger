using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostReposiotry : IPostRepository
    {
        //tworzymy nową kolekcję postów i inicjalizujemy ją 3 postami
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post(1, "Tytuł 1", "treść 1"),
            new Post(2, "Tytuł 2", "treść 2"),
            new Post(3, "Tytuł 3", "treść 3"),
        };


        public IEnumerable<Post> GetAll()
        {
            //zwracamy całą kolekcje
            return _posts;
        }

        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(x=>x.Id == id);
        }

        public Post Add(Post post)
        {
            post.Id = _posts.Count() + 1;
            post.Created = DateTime.UtcNow;
            _posts.Add(post); //dodajemy
            return post; //zwracamy nowo dodany post
        }

        public void Update(Post post)
        {
            post.LastModifed = DateTime.UtcNow;//tylko inicjalizujemy właściwość last modifiedbo dane są przeechiowywane w pamięci
        }

        public void Delete(Post post)
        {
           _posts.Remove(post); //usuwamy post z kolekcji przechowującej dane w pamięci
        }
    }
}
