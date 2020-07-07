using recipes_webapp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class AddNewRecipeVM
    {/*
        public AddNewRecipeVM() { }

        public AddNewRecipeVM(CategoriesDTO catRow, DirectionsDTO dirRow, DishesDTO disRow, GalleryDTO galRow, IngredientsDTO ingRow)
        {
            Dishes.Level = disRow.Level;
        }
        */
        public CategoriesVM Categories { get; set; }
        public DirectionsVM Directions { get; set; }
        public DishesVM Dishes { get; set; }
        public GalleryVM Gallery { get; set; }
        public IngredientsVM Ingredients { get; set; }

        public IEnumerable<SelectListItem> CategoriesList { get; set; }
        public IEnumerable<SelectListItem> LevelList { get; set; }
    }
}