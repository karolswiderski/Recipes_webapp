using recipes_webapp.Models.DTO;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class CategoriesVM
    {
        public CategoriesVM() { }

        public CategoriesVM(CategoriesDTO row) {
            Id_Category = row.Id_Category;
            Name = row.Name;
        }

        public int Id_Category { get; set; }
        public string Name { get; set; }
    }
}