using EatDrinkApplication.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Helper
{
    public class IngredientIO
    {
        private readonly ApplicationDbContext _context;
        public IngredientIO(ApplicationDbContext context)
        {
            _context = context;

        } 
        public void ReadFile()
        {
            using (var reader = new StreamReader(@"C:\Users\jmanh\Desktop\ingredients.csv"))
            {
                while (!reader.EndOfStream) 
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    _context.Ingredients.Add(new Models.Ingredients()
                    {
                        Name = values[0],
                        IdIngredient = values[1]
                    });
                }
                _context.SaveChanges();
            }
        }

    }
}
