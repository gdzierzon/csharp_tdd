using System;
using System.Dynamic;
using Mocking.Common.Services;
using Mocking.Services;

namespace Mocking.Factories
{
    public static class CreditCardProcessorFactory
    {
        private static ICreditCardProcessor processor = null;

        public static ICreditCardProcessor Processor
        {
            get
            {
                if (processor == null) processor = new CreditCardProcessor();

                return processor;
            }
        }
    }
}