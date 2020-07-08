using recipes_webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class AddNewRecipeVM
    {
        public AddNewRecipeVM() { }

        public AddNewRecipeVM(CategoriesDTO catRow, DirectionsDTO dirRow, DishesDTO disRow, GalleryDTO galRow, IngredientsDTO ingRow)
        {
            Categories = new CategoriesVM(catRow);
            Directions = new DirectionsVM(dirRow);
            Dishes = new DishesVM(disRow);
            Gallery = new GalleryVM(galRow);
            Ingredients = new IngredientsVM(ingRow);
        }
       
        public CategoriesVM Categories { get; set; }
        public DirectionsVM Directions { get; set; }
        public DishesVM Dishes { get; set; }
        public GalleryVM Gallery { get; set; }
        public IngredientsVM Ingredients { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> CategoriesList { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> LevelList { get; set; }
    }
}