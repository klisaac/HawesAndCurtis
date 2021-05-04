using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using MediatR;
using AutoMapper;
using HawesAndCurtis.Core.Logging;
using HawesAndCurtis.Core.Specifications;
using HawesAndCurtis.Core.Repository;
using HawesAndCurtis.Application.Common.Helpers;
using HawesAndCurtis.Application.Commands;

namespace HawesAndCurtis.Application.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHawesAndCurtisLogger<LoginUserCommandHandler> _logger;
        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IHawesAndCurtisLogger<LoginUserCommandHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetSingleAsync(new UserSpecification(request.UserName));

            // check if username exists and the password is correct
            if ((user == null) || (!Password.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)))
            {
                _logger.LogError($"Username or password is incorrect");
                return false;
            }
            else
                return true;
        }
    }
}
