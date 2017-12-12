using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_Nico_Priya
{
    class Options
    {
        public string option;
        public Action RelatedAction { get; set; }
        public string Description;

        public void ExecuteEntry()
        {
            RelatedAction.Invoke();
        }
    }
}