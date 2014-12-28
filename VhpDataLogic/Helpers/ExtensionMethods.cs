using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic;
using VhpDataEntities;

namespace DataLogic.Helpers
{
    public static class ExtensionMethods
    {
        public static WorkRegistration CopyTo(this WorkRegistration source,WorkRegistration target)
        {
            target.Project = source.Project;
            target.Activity = source.Activity;
            target.Description = source.Description;
            target.TimeSpent = source.TimeSpent;
            target.DateModified = DateTime.Now;
            target.WorkedFrom= source.WorkedFrom;
            target.WorkedTo = source.WorkedTo;

            return target;
        }
    }
}
