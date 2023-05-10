namespace CoachLife.Domain.DTOs.Response
{
    public class CreateUserResponse
    {
        public string Session { get; }

        public CreateUserResponse(string session) { Session = session; }

        public CreateUserResponse() { }
    }
}
