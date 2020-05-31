using recipes_webapp.Models.DTO;

namespace recipes_webapp.Models.ViewModels.Dishes
{
    public class DirectionsVM
    {
        public DirectionsVM() { }

        public DirectionsVM(DirectionsDTO row)
        {
            Id_Direction = row.Id_Direction;
            Step_1_Title = row.Step_1_Title;
            Step_1_Content = row.Step_1_Content;
            Step_2_Title = row.Step_2_Title;
            Step_2_Content = row.Step_2_Content;
            Step_3_Title = row.Step_3_Title;
            Step_3_Content = row.Step_3_Content;
            Step_4_Title = row.Step_4_Title;
            Step_4_Content = row.Step_4_Content;
            Step_5_Title = row.Step_5_Title;
            Step_5_Content = row.Step_5_Content;
            Step_6_Title = row.Step_6_Title;
            Step_6_Content = row.Step_6_Content;
            Step_7_Title = row.Step_7_Title;
            Step_7_Content = row.Step_7_Content;
            Step_8_Title = row.Step_8_Title;
            Step_8_Content = row.Step_8_Content;
            Step_9_Title = row.Step_9_Title;
            Step_9_Content = row.Step_9_Content;
            Step_10_Title = row.Step_10_Title;
            Step_10_Content = row.Step_10_Content;
        }

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