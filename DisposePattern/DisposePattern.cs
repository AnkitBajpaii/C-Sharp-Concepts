using System;
using System.Collections.Generic;
using System.Linq;

namespace DisposeDemo
{
    //The general pattern for implementing the dispose pattern for a class that overrides System.Object.Finalize
    public class BaseClass : IDisposable
    {
        bool isDisposed;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);

            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed)
                return;

            if (isDisposing)
            {
                //free managed resources

            }

            //free unmanaged resources

            isDisposed = true;
        }

        ~BaseClass()
        {
            Dispose(false);
        }
    }

    //The general pattern for implementing the dispose pattern for a derived class that overrides System.Object.Finalize
    public class DerivedClass : BaseClass
    {
        bool isDisposed;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);

            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
                return;

            if (isDisposing)
            {
                //free managed resources

            }

            //free unmanaged resources

            isDisposed = true;
            base.Dispose(isDisposing);
        }

        ~DerivedClass()
        {
            Dispose(false);
        }
    }
}
