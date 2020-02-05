using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contraband
{
    class Car
    {
        public int passengers;
        public int contrabandAmount;
        public bool alreadyChecked;        
        public static Random generator = new Random();


        public bool Examine()
        {
            alreadyChecked = true;

            if (contrabandAmount>0)
            {
                if (generator.Next(1,6)<=contrabandAmount)
                {                   
                    return true;
                }
            }
            return false;
        }
    }
}
