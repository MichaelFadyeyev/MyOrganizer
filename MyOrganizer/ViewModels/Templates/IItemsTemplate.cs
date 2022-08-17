using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrganizer.Models;

namespace MyOrganizer.ViewModels.Templates
{
    public class ItemsTemplate
    {
        List<Category> items = new List<Category>();

        public ItemsTemplate (string[] template)
        {
            for (int i = 0; i < template.Length; i++)
            {
                items.Insert(i, new Category { Id = i, Name = template[i] });
            }
        }

        public List<Category> Template { get { return items; } }
    }
}
