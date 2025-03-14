using FluentEmail.Core;

namespace Progetto_BE_S5L5.Services
{
    public class EmailServices
    {

        private readonly IFluentEmail _fluentEmail;
        public EmailServices(IFluentEmail fluentemail)
        { _fluentEmail = fluentemail; }


        public async Task<bool> SendNotify(string cognome, string nome, Guid numeroverbale)
        {
            var result = await _fluentEmail.To("Email.Destinatario@email.com").Subject("Confermata Contestazione").Body($"Gentile {cognome} {nome} , abbiamo ricevuto la sua email di contestazione al verbale n#. {numeroverbale}").SendAsync();
            return result.Successful;
        }


    }
}
