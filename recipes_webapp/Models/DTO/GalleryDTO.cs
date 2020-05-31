using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recipes_webapp.Models.DTO
{
    [Table("Gallery")]
    public class GalleryDTO
    {
        [Key]
        public int Id_Gallery { get; set; }
        public string Img_Path_Main { get; set; }
        public string Img_Path_1 { get; set; }
        public string Img_Path_2 { get; set; }
        public string Img_Path_3 { get; set; }
        public string Img_Path_4 { get; set; }
        public string Img_Path_5 { get; set; }
    }
}