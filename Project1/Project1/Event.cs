using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Event
    {
        Variable v = new Variable();

        public void Get(Variable var_)
        { 
            this.v = var_;
        }
    }
}
