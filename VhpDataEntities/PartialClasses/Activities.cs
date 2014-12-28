using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VhpDataEntities
{
    partial class Activities
    {
        public override string ToString()
        {
            return string.Format("{0} {1} {2} ", this._Id, this._Name, this.Active);
        }
    }
}
