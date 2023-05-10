using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using CoachLife.Domain.Configuration;
using CoachLife.Domain.Models;
using CoachLife.Infra.Services.Interfaces;

namespace CoachLife.Infra.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly AwsConfiguration _awsConfiguration;
        private readonly IAmazonCognitoIdentityProvider _amazonCognitoIdentityProvider;

        public SignUpService(
            AwsConfiguration awsConfiguration,
            IAmazonCognitoIdentityProvider amazonCognitoIdentityProvider)
        {
            _awsConfiguration = awsConfiguration ?? throw new ArgumentNullException(nameof(awsConfiguration));
            _amazonCognitoIdentityProvider = amazonCognitoIdentityProvider ?? throw new ArgumentNullException(nameof(amazonCognitoIdentityProvider));
        }

        public async Task SignUp(User request, string password)
        {
            var secretHash = _awsConfiguration.GetSecretHash(request.UserEmail);

            var signUpRequest = new SignUpRequest
            {
                ClientId = _awsConfiguration.UserPoolClientId,
                SecretHash = secretHash,
                Username = request.UserEmail,
                Password = password
            };

            var authResp = await _amazonCognitoIdentityProvider.SignUpAsync(signUpRequest);

            if (authResp.HttpStatusCode != System.Net.HttpStatusCode.OK)
                throw new InternalErrorException("An error occurred while trying to create a user in Cognito.");

            var userIsConfirmedResponse = await _amazonCognitoIdentityProvider.AdminConfirmSignUpAsync(new AdminConfirmSignUpRequest
            {
                Username = request.UserEmail,
                UserPoolId = _awsConfiguration.UserPoolId
            });

            if (userIsConfirmedResponse.HttpStatusCode != System.Net.HttpStatusCode.OK)
                throw new InternalErrorException("An error occurred while trying to confirm a user in Cognito.");
        }
    }
}
