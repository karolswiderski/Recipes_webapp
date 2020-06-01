using recipes_webapp.Models.Data;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class GalleryVM
    {
        public GalleryVM() { }

        public GalleryVM(GalleryDTO row) {
            Id_Gallery = row.Id_Gallery;
            Img_Path_Main = row.Img_Path_Main;
            Img_Path_1 = row.Img_Path_1;
            Img_Path_2 = row.Img_Path_2;
            Img_Path_3 = row.Img_Path_3;
            Img_Path_4 = row.Img_Path_4;
            Img_Path_5 = row.Img_Path_5;
        }

        public int Id_Gallery { get; set; }
        public string Img_Path_Main { get; set; }
        public string Img_Path_1 { get; set; }
        public string Img_Path_2 { get; set; }
        public string Img_Path_3 { get; set; }
        public string Img_Path_4 { get; set; }
        public string Img_Path_5 { get; set; }
    }
}