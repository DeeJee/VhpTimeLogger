using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VhpTimeLogger.Interfaces
{
    public interface IObservable
    {
        void Notify();
        void Attach(IObserver observer);
        void Detach(IObserver observer);
    }
}
