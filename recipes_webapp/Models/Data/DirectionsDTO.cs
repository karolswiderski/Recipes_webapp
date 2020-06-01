using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recipes_webapp.Models.Data
{
    [Table("Directions")]
    public class DirectionsDTO
    {
        [Key]
        public int Id_Direction { get; set; }
        public string Step_1_Title { get; set; }
        public string Step_1_Content { get; set; }
        public string Step_2_Title { get; set; }
        public string Step_2_Content { get; set; }
        public string Step_3_Title { get; set; }
        public string Step_3_Content { get; set; }
        public string Step_4_Title { get; set; }
        public string Step_4_Content { get; set; }
        public string Step_5_Title { get; set; }
        public string Step_5_Content { get; set; }
        public string Step_6_Title { get; set; }
        public string Step_6_Content { get; set; }
        public string Step_7_Title { get; set; }
        public string Step_7_Content { get; set; }
        public string Step_8_Title { get; set; }
        public string Step_8_Content { get; set; }
        public string Step_9_Title { get; set; }
        public string Step_9_Content { get; set; }
        public string Step_10_Title { get; set; }
        public string Step_10_Content { get; set; }

    }
}