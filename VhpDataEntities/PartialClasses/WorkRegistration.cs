using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VhpDataEntities
{
    partial class WorkRegistration
    {
        public override string ToString()
        {
            return string.Format("{0} {1} {3} {4} ", this._ID, this.Project, this.Activity, this.Description, this.TimeSpent);
        }
    }
}
