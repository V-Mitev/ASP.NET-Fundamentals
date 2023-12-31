﻿using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidations.Category;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}
