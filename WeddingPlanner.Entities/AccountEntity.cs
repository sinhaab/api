﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Entities
{
    public class AccountEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public DateTime WeddingDate { get; set; }
        public TimeSpan WeddingTime { get; set; }

    }
}
