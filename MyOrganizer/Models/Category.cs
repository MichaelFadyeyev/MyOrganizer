using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyOrganizer.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Категорія")]
        public string Name { get; set; }

        // навігаційні властивості
        #region navigation props
        public virtual List<MyTask> Tasks { get; set; }
        #endregion
    }
}
