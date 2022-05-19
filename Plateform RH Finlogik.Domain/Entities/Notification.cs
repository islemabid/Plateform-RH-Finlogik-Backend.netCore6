﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Domain.Entities
{
    public class Notification
    {

        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }

    }
}
