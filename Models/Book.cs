﻿using System.ComponentModel.DataAnnotations;

namespace BookLibraryApi.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailableForLoan { get; set; }
    }
}
