using System.Collections.Generic;
using relation.Models;

namespace relation.ViewModels
{
    public class HeroPowerViewModel
    {
        public Hero Hero { get; set; }
        public List<Power> Powers { get; set; }
    }
}