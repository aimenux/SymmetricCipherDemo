using Microsoft.Extensions.Options;
using Spectre.Console;

namespace App
{
    public interface IService
    {
        void RenderCipherResults();
    }

    public class Service : IService
    {
        private readonly IFactory _factory;
        private readonly IOptions<Settings> _options;

        public Service(IFactory factory, IOptions<Settings> options)
        {
            _factory = factory;
            _options = options;
        }

        public void RenderCipherResults()
        {
            var ciphers = _factory.GetCiphers();

            var table = new Table()
                .BorderColor(Color.White)
                .Border(TableBorder.Square)
                .AddColumn(new TableColumn("[u]Name[/]").Centered())
                .AddColumn(new TableColumn("[u]ClearText[/]").Centered())
                .AddColumn(new TableColumn("[u]Encrypted[/]").Centered())
                .AddColumn(new TableColumn("[u]Decrypted[/]").Centered());

            foreach (var cipher in ciphers)
            {
                var name = cipher.Name;
                var clearText = _options.Value.SecretMessage;
                var encrypted = cipher.Encrypt(clearText);
                var decrypted = cipher.Decrypt(encrypted);
                table.AddRow(name, clearText, encrypted, decrypted);
            }

            AnsiConsole.WriteLine();
            AnsiConsole.Render(table);
            AnsiConsole.WriteLine();
        }
    }
}
