using System.Collections.Generic;
using MyOrganizer.Models;



namespace MyOrganizer.ViewModels.Templates
{
    public class StatusStatesTemplate : ItemsTemplate
    {
        static readonly string[] template = new string[]
        {
            "Всі задачи",
            "Заплановані",
            "Завершені"
        };

        public StatusStatesTemplate() : base (template) {}
    }
}
