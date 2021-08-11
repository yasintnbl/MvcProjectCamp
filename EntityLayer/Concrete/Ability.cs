﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Ability
    {
        [Key]
        public int AbiltyID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string AbiltyName { get; set; }
        public int AbiltyPoint { get; set; }



   
    }
}
