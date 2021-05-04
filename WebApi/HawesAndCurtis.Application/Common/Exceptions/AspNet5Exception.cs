using System;

namespace HawesAndCurtis.Application.Common.Exceptions
{
    public class AspNet5Exception : Exception
    {
        public AspNet5Exception()
        {
        }
        public AspNet5Exception(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
