﻿using System.ComponentModel.DataAnnotations;

namespace Fiorello_AdminPanel.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        public List<FlowerCategory> flowerCategories { get; set; }
    }
}
