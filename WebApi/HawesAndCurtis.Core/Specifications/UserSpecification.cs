﻿using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Specifications.Base;

namespace HawesAndCurtis.Core.Specifications
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification() : base(null)
        {
        }
        public UserSpecification(string userName)
            : base(u => u.UserName == userName)
        {
        }

        public UserSpecification(int userId)
            : base(u => u.UserId == userId)
        {
        }

    }
}
