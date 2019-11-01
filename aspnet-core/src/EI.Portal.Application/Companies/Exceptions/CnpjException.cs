using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Portal.Companies.Exceptions
{
    public class CnpjException : Exception
    {
        public CnpjException(string message) : base(message)
        {
        }
    }
}
