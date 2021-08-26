using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository; //aby raz przypsane pole w konstruktorze nie mogło być w jakijśc metodzie zmodyfikowne lub nadpisane
        private readonly IMapper _mapper;

        //interface IPostRepository ktory zostanie wstrzyknięty
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;

        }


        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            //return posts.Select(post => new PostDto
            //{
            //    Id = post.Id,
            //    Title = post.Title,
            //    Content = post.Content

            //});

            return _mapper.Map<IEnumerable<PostDto>>(posts);  //mapowane dane zwracane są w postaci PostDto
        }

        public PostDto GetPostById(int id) 
        {
            var post = _postRepository.GetById(id);
            //return new PostDto()   //ręczne mapowania
            //{
            //    Id = post.Id,
            //    Title = post.Title,
            //    Content = post.Content
            //};

            return _mapper.Map<PostDto>(post);

        }
        //Automatyczne mapownie modeli domenowych - automapper



        public PostDto AddNewPost(CreatePostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title)) //sprwdzamy czy właściwość Title nie jest pusta
            {
                throw new Exception("Post can't have an empty title");
            }

            var post = _mapper.Map<Post>(newPost);
            _postRepository.Add(post); //metoda Post z repozytorium
            return _mapper.Map<PostDto>(post);
        }

        public void UpdatePost(UpdatePostDto updatePost)
        {
           var existingPost = _postRepository.GetById(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost); //mapujemy zaktualizoany post na istniejacy post
            _postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }
    }
}
