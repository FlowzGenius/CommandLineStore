using System;
using System.ComponentModel.DataAnnotations;

namespace CommandLineStoreDTOs
{
    public class CommandLineCreateDto
    {
        [Required(ErrorMessage ="This field is required")]
        public string HowTo { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Line { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string PlatForm { get; set; }
    }

    public class CommandLineOperationDto
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string HowTo { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Line { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string PlatForm { get; set; }
    }

    public class CommandLineViewDto
    {
        public string Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string PlatForm { get; set; }
    }
}
