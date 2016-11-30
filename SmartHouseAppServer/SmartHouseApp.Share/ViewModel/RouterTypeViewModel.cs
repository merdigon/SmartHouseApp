using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.ViewModel
{
    public class RouterTypeViewModel
    {
        public virtual int Id { get; set; }
        public virtual string VisibleName { get; set; }

        public override string ToString()
        {
            return VisibleName;
        }
    }
}
