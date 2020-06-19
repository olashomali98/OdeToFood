using OdeTofood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
   public  interface IResturantData
    {
        IEnumerable<Resturant> GetResturantsByName(string name);
        Resturant GetById(int id);
        Resturant Update(Resturant updatedResturant);
        int commit();
     
    }
    public class InMemoryRestutantData : IResturantData
    {
        List<Resturant> resturants;
        public InMemoryRestutantData() {
            resturants = new List<Resturant>()
            {
                new Resturant { Id= 1, Name= "Zeva's Pizza" , Location="Roma" , Cuisine= CuisineType.Italian},
            new Resturant { Id = 2, Name = "Lia's Pizza", Location = "cyndia", Cuisine = CuisineType.Indian },
                new Resturant { Id= 3, Name= "Ola's Pizza" , Location="Bethlehem" , Cuisine= CuisineType.Mexican}
            };
        }
        public Resturant GetById(int id)
        {
            return resturants.SingleOrDefault(r => r.Id == id);
        }

        public Resturant Update(Resturant updatedResturant)
        {
            var resturant = resturants.SingleOrDefault(r => r.Id == updatedResturant.Id); // problem is here!!!!  hdjs
            if(resturant != null){

                resturant.Name = updatedResturant.Name;
                resturant.Location = updatedResturant.Location;
                resturant.Cuisine = updatedResturant.Cuisine;

            }
            return resturant;
        }

        public int Commit()
        {
            return 0;
        }
         IEnumerable<Resturant> IResturantData.GetResturantsByName(string name)
        {
            return from r in resturants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
                   
        }

        public int commit()
        {
            throw new NotImplementedException();
        }
    }
}
