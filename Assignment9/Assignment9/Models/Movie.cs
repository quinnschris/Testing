using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment9.Models
{
    public class Movie
    {
        // Model used to create a table for the Movie Database

        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter category.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter year.")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Please enter director.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; } = false;

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
