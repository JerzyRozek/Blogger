using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
   public class MappingProfile : Profile
    {
        //opdowiada za poprawne wywołanie zdefinowanych przez nas mapowań
        public MappingProfile()
        {
            //bezparametrowy konstruktor
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly()); //wywołujemy metodę mapping
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            //test
            var types1 = assembly.GetExportedTypes().ToList();

            //wyszukiwanie w projekcie wszystkch klas dto. Utworzenie ich instancji. Wywołanie metody mapping w przypadku użycia danego
            var types = assembly.GetExportedTypes().Where(x => typeof(IMap).IsAssignableFrom(x) && !x.IsInterface).ToList(); //otrzymujemy 3 typy: CeratePostDto, PostDto, UpdatePostDto

            foreach (var type in types) //
            {
                var instance = Activator.CreateInstance(type); //tworzymy instancje tych typów
                var methodInfo = type.GetMethod("Mapping");    //wywołujemy metodę mapping
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
