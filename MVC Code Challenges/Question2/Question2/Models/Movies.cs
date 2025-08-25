using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Question2.Models
{
    public class Movies
    {
        [Key]
        public int Mid { get; set; }

        public string Moviename { get; set; }

        public string DirectorName { get; set; }

        public DateTime DateofRelease { get; set; }

    }
}