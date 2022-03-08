using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Project_Airline
{
    public partial class Airline
    {
      [Key]
        public int Id { get; set; }
        [Required, RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }


        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
       ErrorMessage = "Email format is incorret")]
        public string Email { get; set; }


        [Required, RegularExpression(@"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$",
       ErrorMessage = "Phone format is incorret")]
        public string Phone { get; set; }
      
        [Required, RegularExpression(@"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?",
       ErrorMessage = "Url format is incorret")]
        public string Website { get; set; }

        [Required]
        public string Logo { get; set; }
    }
}
