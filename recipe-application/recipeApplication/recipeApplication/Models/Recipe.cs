using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace recipeApplication.Models
{
    public class Recipe
    {
        private string name;
        private string ingredients;
        private long id;

        Recipe(string name, String ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;
        }

        public string Ingredients { get ; set ; }
        public string Name { get; set; }
        public long Id { get => id; set => id = value; }

     
    }
}