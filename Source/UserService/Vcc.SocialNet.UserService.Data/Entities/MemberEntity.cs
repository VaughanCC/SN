using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vcc.SocialNet.UserService.Common;

namespace Vcc.SocialNet.UserService.Data.Entities
{
    /// <summary>
    /// Represents a Member entity
    /// </summary>
    public class MemberEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set;}

        [Required]
        [Column(TypeName = "nvarchar(6)")] // ensure the Enum string is stored instead of number (EF Core 2.1)
        public GenderEnum Gender { get; set; }

        [Required]
        public PositionEnum Position { get; set; }

        [MaxLength(15)]
        public string CellPhone { get; set; }
        [MaxLength(15)]
        public string HomePhone { get; set; }

        [MaxLength(15)]
        public string City { get; set; }
        [MaxLength(2)]
        public string Province { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

    }
}
