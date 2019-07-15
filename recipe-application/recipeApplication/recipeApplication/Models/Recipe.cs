using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApplication.Models
{
    public class Recipe
    {
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }

        public long Id { get; set; }
    }
}
