using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diary
{
    internal class DatesManager
    {
        public Date dates = new Date();

        public Date FindByDateTime(DateTime selectedDateTime)
        {

            int index = dates.datetime.FindIndex(date => date == selectedDateTime);

            if (index != -1)
            {
                
                return dates;
            }
            else
            {
                return null;
            }
        }


        public void Add(DateTime date) 
        {
            this.dates.datetime.Add(date);
        }
    }
}
