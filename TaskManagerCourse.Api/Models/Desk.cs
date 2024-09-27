﻿using TaskManagerCourse.Api.Models.Abstractions;

namespace TaskManagerCourse.Api.Models
{
    public class Desk : CommonObject
    {
        public bool IsPrivate { get; set; }
        public string Columns { get; set; }
        public User Admin { get; set; }
    }
}
