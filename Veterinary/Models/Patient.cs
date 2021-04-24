using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Veterinary.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string ResimYolu { get; set; }
        public string Sahibi { get; set; }
        public string Cins { get; set; }
        public string Tani { get; set; }
    }
}