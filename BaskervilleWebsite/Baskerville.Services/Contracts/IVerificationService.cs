namespace Baskerville.Services.Contracts
{
    public interface IVerificationService : IMultilingual
    {
        bool VerificateSubscribtionCode(string code);

        void SendWelcomeEmail();

        bool VerificateUnsubscribeCode(string code);
    }
}
