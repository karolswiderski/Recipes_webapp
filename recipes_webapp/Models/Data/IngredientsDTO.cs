﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recipes_webapp.Models.Data
{
    [Table("Ingredients")]
    public class IngredientsDTO
    {
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
    }
}