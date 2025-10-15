using Courses.Grpc;
using Courses.Repository;
using Google.Protobuf;
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
}