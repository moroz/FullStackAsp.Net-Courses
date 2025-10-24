using Courses.Grpc;
using Courses.Middleware;
using Courses.Models;
using Courses.Repository;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using User = Courses.Grpc.User;

namespace Courses.Services;

public partial class CoursesService
{
    public override async Task<SignInResponse> SignInWithPassword(SignInWithPasswordRequest request,
        ServerCallContext context)
    {
        var userRepository = new UserRepository(dbContext);
        var userTokenRepository = new UserTokenRepository(dbContext);

        var user = await userRepository.AuthenticateUserByEmailPassword(request.Email, request.Password);
        if (user == null)
        {
            return new SignInResponse
            {
                Success = false,
                AccessToken = ByteString.Empty,
                Errors =
                {
                    new ErrorMessage
                    {
                        Key = "email",
                        Msg = "Invalid email/password combination."
                    }
                }
            };
        }

        var token = await userTokenRepository.IssueAccessTokenForUser(user);
        return new SignInResponse
        {
            AccessToken = ByteString.CopyFrom(token.Token),
            Success = true,
        };
    }

    public override Task<GetCurrentUserResponse> GetCurrentUser(EmptyRequest request,
        ServerCallContext context)
    {
        var user = context.GetCurrentUser();

        if (user == null)
        {
            return Task.FromResult(new GetCurrentUserResponse());
        }

        return Task.FromResult(new GetCurrentUserResponse
        {
            User = user.ToGrpcUser()
        });
    }

    public override async Task<SignOutResponse> SignOut(EmptyRequest request, ServerCallContext context)
    {
        var repo = new UserTokenRepository(dbContext);
        var token = context.GetCurrentAccessToken();
        if (token == null)
        {
            return new SignOutResponse
            {
                Success = false,
            };
        }

        return new SignOutResponse
        {
            Success = await repo.RevokeAccessToken(token),
        };
    }

    public override async Task<UserRegistrationResponse> RegisterUser(UserRegistrationRequest request,
        ServerCallContext context)
    {
        var repo = new UserRepository(dbContext);
        var (user, result) = await repo.RegisterUser(new UserRegistrationParams
        {
            Email = request.Email,
            GivenName = request.GivenName,
            FamilyName = request.FamilyName,
            Password = request.Password,
            PasswordConfirmation = request.PasswordConfirmation
        });

        var errors = result?.Errors.Select(e => new ErrorMessage
        {
            Key = e.PropertyName[..1].ToLower() + e.PropertyName[1..], Msg = e.ErrorMessage,
        }) ?? [];

        return new UserRegistrationResponse
        {
            Success = user != null,
            Errors = { errors },
            User = user?.ToGrpcUser(),
        };
    }
}