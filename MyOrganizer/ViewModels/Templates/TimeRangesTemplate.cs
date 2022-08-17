using System.Collections.Generic;
using MyOrganizer.Models;



namespace MyOrganizer.ViewModels.Templates
{
    public class TimeRangesTemplate : ItemsTemplate
    {
        static readonly string[] template = new string[]
        {
            "Весь час",
            "Вчора",
            "Сьогодні",
            "Завтра",
            "Тиждень",
            "Місяць"
        };

        public TimeRangesTemplate() : base(template) { }
    }


}
