using System.Collections.Generic;
using MyOrganizer.Models;



namespace MyOrganizer.ViewModels.Templates
{
    public class TasksOnPageTemplate : ItemsTemplate
    {
        static readonly string[] template = new string[]
        {
            "Всі задачи",
            "Три",
            "П'ять",
            "Десять"
        };

        public TasksOnPageTemplate() : base(template) { }
    }


}
