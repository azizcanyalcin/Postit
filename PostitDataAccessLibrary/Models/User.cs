﻿using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PostitDataAccessLibrary.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreatedOn { get; set;}
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ICollection<Note>? Notes { get; set; }

    }
}
