using Courses.Grpc;
using Courses.Middleware;
using Courses.Repository;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

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
            User = new User
            {
                Id = new UUID { Value = user.Id.ToString(), },
                Email = user.Email,
                Company = user.Company ?? "",
                Country = user.Country ?? "",
                CreatedAt = Timestamp.FromDateTime(user.CreatedAt),
                FamilyName = user.FamilyName,
                GivenName = user.GivenName,
                LastLoginAt = user.LastLoginAt == null ? null : Timestamp.FromDateTime((DateTime)user.LastLoginAt),
                LastLoginIp = user.LastLoginIp?.ToString() ?? "",
                Organization = user.Organization ?? "",
                Profession = user.Profession ?? "",
                Salutation = user.Salutation ?? "",
                UpdatedAt = Timestamp.FromDateTime(user.UpdatedAt)
            }
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
}