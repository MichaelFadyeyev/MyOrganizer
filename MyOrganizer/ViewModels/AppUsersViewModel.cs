﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOrganizer.Models;

namespace MyOrganizer.ViewModels
{
    public class AppUsersViewModel
    {
        public List<MyTask> Tasks { get; set; }
        public SelectList Categories { get; set; }
    }
}
