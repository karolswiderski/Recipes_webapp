using recipes_webapp.Models.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class IngredientsVM
    {
        public IngredientsVM() { }

        public IngredientsVM(IngredientsDTO row) {
            Id_Ingredient = row.Id_Ingredient;
            Ingredient_1 = row.Ingredient_1;
            Ingredient_2 = row.Ingredient_2;
            Ingredient_3 = row.Ingredient_3;
            Ingredient_4 = row.Ingredient_4;
            Ingredient_5 = row.Ingredient_5;
            Ingredient_6 = row.Ingredient_6;
            Ingredient_7 = row.Ingredient_7;
            Ingredient_8 = row.Ingredient_8;
            Ingredient_9 = row.Ingredient_9;
            Ingredient_10 = row.Ingredient_10;
            Ingredient_11 = row.Ingredient_11;
            Ingredient_12 = row.Ingredient_12;
            Ingredient_13 = row.Ingredient_13;
            Ingredient_14 = row.Ingredient_14;
            Ingredient_15 = row.Ingredient_15;
        }

        [Key]
        public int Id_Ingredient { get; set; }
        public string Ingredient_1 { get; set; }
        public string Ingredient_2 { get; set; }
        public string Ingredient_3 { get; set; }
        public string Ingredient_4 { get; set; }
        public string Ingredient_5 { get; set; }
        public string Ingredient_6 { get; set; }
        public string Ingredient_7 { get; set; }
        public string Ingredient_8 { get; set; }
        public string Ingredient_9 { get; set; }
        public string Ingredient_10 { get; set; }
        public string Ingredient_11 { get; set; }
        public string Ingredient_12 { get; set; }
        public string Ingredient_13 { get; set; }
        public string Ingredient_14 { get; set; }
        public string Ingredient_15 { get; set; }

        public IEnumerable<string> IngredientsList { get; set; }
    }
}