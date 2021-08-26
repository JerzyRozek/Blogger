using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities; //dodany

namespace Domain.Interfaces
{
   public interface IPostRepository
    {
        //sygnatury metod odpowiedzialnych za wyk operacji na modelu reprezentującym post
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Add(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
