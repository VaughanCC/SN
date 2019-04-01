using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vcc.SocialNet.Domain.Model.Entities
{
    /// <summary>
    /// Represents a message entity
    /// </summary>
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int WriterId { get; set; }
        [NotMapped]
        public string Writer { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

    }
}
