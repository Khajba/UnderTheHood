﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uth.Common.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
    }
}
