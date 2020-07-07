using System;
using System.ComponentModel.DataAnnotations;

namespace CommandLineStore.Entities
{
    public class CommandLine
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string HowTo { get; set; }
        [Required]
        [MaxLength(100)]
        public string Line { get; set; }
        [Required]
        [MaxLength(250)]
        public string PlatForm { get; set; }
    }
}
