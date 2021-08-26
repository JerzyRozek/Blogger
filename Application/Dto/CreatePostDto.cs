using Application.Mappings;
using Domain.Entities;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
  public  class CreatePostDto : IMap
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDto, Post>();//def odpowiednie mapowanie
        }
        //właściwości Id nie dodajemy, bo nie oczekujemy że przyjdzie
    }
}
