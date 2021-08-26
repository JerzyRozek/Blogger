using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService; // przypisujemy wstrzykniety inteface do prywanego pola

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [SwaggerOperation(Summary = "Retrieves all posts")] //inicjalizujemy właściwość Summary
        [HttpGet] //atrybut
        public IActionResult Get() //pobieramy posty za pomoca metody .GetAllPosts
        {
            var posts = _postService.GetAllPosts(); //serwis.metoda
            return Ok(posts); //zwracamy wynik w postaci Jasona
        }

        [SwaggerOperation(Summary = "Retrieves specific post by unique Id")]
        [HttpGet("{id}")] //argument id
        //metoda która zwróci post o podanym identyfiatorze
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound(); //jeśli nie istnieje to zwróć kod 200
            }
            return Ok(post);

        }

        [SwaggerOperation(Summary = "Tworzy nowy post")] //opis do endpointów
        [HttpPost]
        //metoda, ktora dodaje nowy Post
        public IActionResult Create(CreatePostDto newPost)
        {
            var post = _postService.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);//link do nowo utworzonego zasobu
        }

        [SwaggerOperation(Summary = "Aktualizuje post")] //opis do endpointów
        [HttpPut]
        public IActionResult Update(UpdatePostDto updatePost)  //paramer - obiekt typu UpdatePostDto
        {
            _postService.UpdatePost(updatePost);//aktualizacja posta
            return NoContent(); //204 - NoContent
        }

        [SwaggerOperation(Summary = "Kasuje specyficzny post")] //opis do endpointów
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return NoContent();
        }
    }
}
