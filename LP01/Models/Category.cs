using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LP01.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage = "Display order for category must be greater than 0 and less than 2147483647")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
