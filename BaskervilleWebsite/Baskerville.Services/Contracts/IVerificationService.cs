namespace Baskerville.Services.Contracts
{
    public interface IVerificationService
    {
        bool VerificateSubscribtionCode(string code);

        void SendWelcomeEmail(string code);

        bool VerificateUnsubscribeCode(string code);
    }
}
