using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOrganizer.Models;

namespace MyOrganizer.ViewModels
{
    public class TasksViewModel
    {
        public List<MyTask> Tasks { get; set; }
        public SelectList Categories { get; set; }
        public AppUser AppUser { get; set; }
        public PageViewModel Paginator { get; set; }
        public SelectList StatusStates { get; set; }
        public SelectList TimeRange { get; set; }

    }
}
