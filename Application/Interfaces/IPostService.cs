using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
  public  interface IPostService
    {
        //dodajemy sygnaturę metody GetAllPosts odpowiedzialnej za pobieranie wszystkich postów
        //   IEnumerable<Post> GetAllPosts();
        IEnumerable<PostDto> GetAllPosts(); // teraz zwraca obiekty Dto
        //  Post GetPostById(int id); //metody z serwisów  nie mogą zwracać modelów domenowych
        PostDto GetPostById(int id);

      //  PostDto AddNewPost(PostDto newPost); //sygnatura metody opowiedzialnej za dodanie nowego posta
                                             //Id generowany jest po stronie serwera. Dlatego tworzymy nową klasę CreatePostDto
        PostDto AddNewPost(CreatePostDto newPost);
       // void UpdatePost();//sygnatura metody odpowiedzialnej za aktualizację
        void UpdatePost(UpdatePostDto updatePost);

        void DeletePost(int id);
    }
}
