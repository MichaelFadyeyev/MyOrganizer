using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOrganizer.Models
{
    public class MyTask
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        [Display(Name = "Опис задачи")]
        public string Content { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Запланована дата")]
        public DateTime PublishDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Запланований час")]
        public DateTime PublishTime { get; set; }

        //[Required]
        [Display(Name = "Категорія задачи")]
        public int CategoryId { get; set; }

        //[Required]
        [Display(Name = "Власник")]
        public string AppUserId { get; set; }

        [Required]
        [Display(Name = "Статус")]
        public bool IsDone { get; set; }

        // навігаційні властивості
        #region navigation props
        [ForeignKey("CategoryId")]
        [Display(Name = "Категорія задачи")]

        public virtual Category Category { get; set; }

        [ForeignKey("AppUserId")]
        [Display(Name = "Власник")]
        public virtual AppUser AppUser { get; set; }
        #endregion
    }
}
