using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Castory : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }// Title or name of the castory item
        public string? Content { get; set; } //Detailed info about the item
        public string? ImageURL { get; set; }
        public int Year { get; set; } //item's year of date
        public int? Month { get; set; } //item's month of date
        public int? Day { get; set; } //item's day of date
        public string UserId { get; set; } //id of user who adds the item
        public bool IsPublic { get; set; } //IsPublic or IsPrivate. It is about to publish it explicitly or not
        public DateTime AddedTime { get; set; }
    }
}
