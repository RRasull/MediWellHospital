using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
   public class PatientComment
    {
        [Required]
        public int Id { get; set; }
        [Required,MaxLength(255)]

        public string Comment { get; set; }
        [Required,NotMapped]
        public IFormFile Photo { get; set; }
        [Required]

        public string Image { get; set; }
        [Required,MaxLength(100)]
        public string Fullname { get; set; }
        [Required,MaxLength(50)]

        public string Profession { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
