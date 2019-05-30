using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoCars.Domain
{
    public class Car
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Brand Brand { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Model { get; set; }

        [Required]
        [Range(1950, 2019)]
        public int Year { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Please enter greater than 0")]
        public int Mileage { get; set; }

        [Required]
        public BodyStyle BodyStyle { get; set; }

        [Required]
        public Fuel Fuel { get; set; }

        [Required]
        public float EnginePower { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, 20000000)]
        public decimal Price { get; set; }

        public Guid UserId { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Car()
        {
            UpdateAt = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
