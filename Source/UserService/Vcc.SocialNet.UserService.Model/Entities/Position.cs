// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Text;
// using Vcc.SocialNetwork.Domain.Model.Extension;

// namespace Vcc.SocialNetwork.Domain.Model.Entities
// {
//     /// <summary>
//     /// Represents a Position in Church
//     /// </summary>
//     public class Position
//     {
//         public Position(PositionEnum @enum)
//         {
//             Id = (int)@enum;
//             Name = @enum.ToString();
//             Description = @enum.GetEnumDescription();
//         }

//         protected Position() { } //For EF

//         [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
//         public int Id { get; set; }

//         [Required, MaxLength(30)]
//         public string Name { get; set; }

//         [Column(TypeName = "nvarchar(10)")]
//         public string Description { get; set; }

//         public static implicit operator Position(PositionEnum @enum) => new Position(@enum);

//         public static implicit operator PositionEnum(Position Position) => (PositionEnum)Position.Id;
//     }
// }
