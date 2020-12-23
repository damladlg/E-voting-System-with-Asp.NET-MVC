using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_voting.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [DisplayName("Slider Title"), StringLength(50, ErrorMessage = "Can be up to 50 characters.")]
        public string Title { get; set; }

        [DisplayName("Slider Explanation"), StringLength(250, ErrorMessage = "Can be up to 250 characters.")]
        public string Explanation { get; set; }

        [DisplayName("Slider Photo")]
        public string PhotoURL { get; set; }
        public string PhotoPath { get; internal set; }
    }
}