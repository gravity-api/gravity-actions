using System;
using System.Reflection;

namespace Gravity.Plugins.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception GetFirstNonReflection(this Exception exception)
        {
            // setup
            var onException = exception is TargetInvocationException ? exception.InnerException : exception;

            // find last
            while (onException != null)
            {
                if (!(onException is TargetInvocationException))
                {
                    return onException;
                }
                onException = onException.InnerException;
            }

            // get last
            return onException;
        }
    }
}
