using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VhpDataEntities
{
    public partial class Projects
    {
        public override string ToString()
        {
            return string.Format("{0} {1} {2} ",this._Id.ToString().PadRight(4), this.Name.PadRight(30), this.Active?"Actief":"Inactief");
        }
    }
}
