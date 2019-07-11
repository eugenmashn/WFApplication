using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAplicationVacation
{
    public class Team
    {
        public Guid Id { get; set; }
        public string TeamName { get; set; }
        public int Year { get; set; }
        public int MinNumberWorkers { get; set; }
    }
}
