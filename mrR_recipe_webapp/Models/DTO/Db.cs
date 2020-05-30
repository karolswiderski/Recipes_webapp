using System.Data.Entity;

namespace mrR_recipe_webapp.Models.DTO
{
    public class Db : DbContext
    {
        public DbSet<CategoriesDTO> Categories { get; set; }
        public DbSet<DirectionsDTO> Directions { get; set; }
        public DbSet<IngredientsDTO> Ingredients { get; set; }
        public DbSet<GalleryDTO> Gallery { get; set; }
        public DbSet<UsersDTO> Users { get; set; }

        public System.Data.Entity.DbSet<mrR_recipe_webapp.Models.DTO.DishesDTO> DishesDTOes { get; set; }
    }
}