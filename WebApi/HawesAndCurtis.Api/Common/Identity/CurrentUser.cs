using System;
using Microsoft.AspNetCore.Http;
using HawesAndCurtis.Application.Common.Identity;

namespace HawesAndCurtis.Api.Common.Identity
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        public string UserName => _accessor.HttpContext.User.Identity.Name;
    }
}
