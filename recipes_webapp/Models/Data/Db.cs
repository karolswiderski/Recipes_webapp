﻿using System.Data.Entity;

namespace recipes_webapp.Models.Data
{
    public class Db : DbContext
    {
        public Db() : base("RecipesDB")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<DishesDTO> Dishes { get; set; }
        public DbSet<CategoriesDTO> Categories { get; set; }
        public DbSet<DirectionsDTO> Directions { get; set; }
        public DbSet<IngredientsDTO> Ingredients { get; set; }
        public DbSet<UsersDTO> Users { get; set; }
        public DbSet<ArticlesDTO> Articles { get; set; }
        public DbSet<Recipe_FollowersDTO> Recipe_Followers { get; set; }
        public DbSet<User_FollowersDTO> User_Followers { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Dishes.DishesVM> DishesVMs { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Dishes.CategoriesVM> CategoriesVMs { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Dishes.IngredientsVM> IngredientsVMs { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Dishes.DirectionsVM> DirectionsVMs { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Articles.ArticlesVM> ArticlesVMs { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Account.LoginUserVM> LoginUserVMs { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Account.UsersVM> UsersVMs { get; set; }

        public System.Data.Entity.DbSet<recipes_webapp.Models.ViewModels.Account.RecipeFollowersVM> RecipeFollowersVMs { get; set; }
    }
}

