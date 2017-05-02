namespace Baskerville.Services.Contracts
{
    public interface IVerificationService
    {
        bool VerificateSubscribtionCode(string code);

        void SendWelcomeEmail();

        bool VerificateUnsubscribeCode(string code);
    }
}
