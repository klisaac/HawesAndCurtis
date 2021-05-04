﻿using MediatR;

namespace HawesAndCurtis.Application.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
