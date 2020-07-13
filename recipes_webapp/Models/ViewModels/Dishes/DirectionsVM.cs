using recipes_webapp.Models.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class DirectionsVM
    {
        public DirectionsVM() { }

        public DirectionsVM(DirectionsDTO row)
        {
            Id_Direction = row.Id_Direction;
            Step_1_Content = row.Step_1_Content;
            Step_2_Content = row.Step_2_Content;
            Step_3_Content = row.Step_3_Content;
            Step_4_Content = row.Step_4_Content;
            Step_5_Content = row.Step_5_Content;
            Step_6_Content = row.Step_6_Content;
            Step_7_Content = row.Step_7_Content;
            Step_8_Content = row.Step_8_Content;
            Step_9_Content = row.Step_9_Content;
            Step_10_Content = row.Step_10_Content;
        }

        [Key]
        public int Id_Direction { get; set; }
        public string Step_1_Content { get; set; }
        public string Step_2_Content { get; set; }
        public string Step_3_Content { get; set; }
        public string Step_4_Content { get; set; }
        public string Step_5_Content { get; set; }
        public string Step_6_Content { get; set; }
        public string Step_7_Content { get; set; }
        public string Step_8_Content { get; set; }
        public string Step_9_Content { get; set; }
        public string Step_10_Content { get; set; }

        public IEnumerable<string> DirectionsList { get; set; }
    }
}