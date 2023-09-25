using Exemplo_2.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net.Mail;
using Assert = Xunit.Assert;
using System.ComponentModel.Design;
using Usar;
using OpenQA.Selenium.Chrome;
using Exemplo_2.Helpers;
using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace Exemplo_2.Testes
{
    [Collection("Chrome Driver")]

    public class ResetSenha
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public static string linkSistema;

        private static Configuration config;

        private static readonly long TimeoutMillis = 30_000L;

        private static Email _email;

        private static InboxIdItem _inbox;

        private static InboxByEmailAddressResult inbox;

        private static readonly string YourApiKey = "c78a758f35e98083c2a42829218c1b262b56ef72f9c5ee910f1c7616a7cda19a";

        private static String _confirmationCode;

        public ResetSenha(TestFixture fixture)
        {
            driver = fixture.Driver;

            driver.Manage().Window.Maximize();
        }

            [Fact]


            public static void ResetdeSenha()
            {

                 pasta = TestHelpers.pasta;

                 email = TestHelpers.email;

                 ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

                 driver.Manage().Window.Maximize();

                 DateTime startTime = DateTime.Now;

                 IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                 if (Directory.Exists(pasta + "" + "ResetSenha"))
                 {

                 }
                 else
                 {
                    Directory.CreateDirectory(pasta + "" + "ResetSenha");
                 }

                try
                {
                    // ************************* LOGIN

                    var timeout = TimeSpan.FromMilliseconds(TimeoutMillis);

                    var config = new Configuration();

                    config.ApiKey.Add("x-api-key", "c78a758f35e98083c2a42829218c1b262b56ef72f9c5ee910f1c7616a7cda19a");

                    var apiInstance = new InboxControllerApi(config);

                    var inboxControllerApi = new InboxControllerApi(config);

                    inbox = inboxControllerApi.GetInboxByEmailAddress("f95f8de8-0348-4af7-b829-b5a479ccc0c8@mailslurp.mx");

                    Funcoes.PaginaInicial(driver, "PaginaInicial", "ResetSenha", " Não consegui encontrar o seja bem vindo na página inicial.");

                    Funcoes.LoginIncorreto(driver, "reset@qms", "asdasd", "UsuarioSenha", "Incorreto", "ResetSenha", "Sistema não deu a mensagem de login incorreto.");

                    Funcoes.EsqueciSenha(driver, "EsqueciSenha", "Assercoes", "SenhaEnviada", "ResetSenha", "Não consegui enviar a nova senha.");

                    Funcoes.VoltarparaLogin(driver, "VoltarLogin", "voltouLogin", "ResetSenha", "Não consegui clicar no botão de voltar para o login.");

                    Funcoes.PaginaInicial(driver, "PaginaInicial2", "ResetSenha", " Não consegui encontrar o seja bem vindo na página inicial.");

                     var waitForControllerApi = new WaitForControllerApi(config);

                    _email = waitForControllerApi.WaitForLatestEmail(inbox.InboxId, unreadOnly: true);

                    EmailRecebido(driver, "Não recebi o e-mail com a nova senha", "Nova Senha Clinicorp");

                    CanExtractConfirmationCode();                  

                    Funcoes.NovaSenha(driver, "reset@qms", _confirmationCode, "Usuario", "Senha", "NovaSenha", "ResetSenha", "Não consegui resetar a senha.");

                    DateTime endTime = DateTime.Now;

                    double duration = (endTime - startTime).TotalSeconds;

                    int minutes = (int)(duration / 60);

                    int seconds = (int)(duration % 60);

                    string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                    string filePath = pasta + "" + "ResetSenha" + "/" + "tempo_de_teste.txt";

                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.Write(outputStr);
                    }

                    driver.Quit();

                }
                catch (Exception e)
                {
                    printScreen(driver, "Erro", "ResetSenha");

                    sendMessage("Erro em teste [Reset de Senha]", e.Message + Funcoes.body.ToString(), ResetSenha.name);

                    DateTime endTime = DateTime.Now;

                    double duration = (endTime - startTime).TotalSeconds;

                    int minutes = (int)(duration / 60);

                    int seconds = (int)(duration % 60);

                    string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                    string filePath = pasta + "" + "ResetSenha" + "/" + "tempo_de_teste.txt";

                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.Write(outputStr);
                    }

                    driver.Quit();
                }

            }
            private static void sendMessage(string Subject, string Body, string nome)
            {

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

                client.Host = "smtp.outlook.com";

                client.EnableSsl = false;

                client.Port = 587;

                client.UseDefaultCredentials = false;

                client.EnableSsl = true;

                client.Credentials = new System.Net.NetworkCredential("confirmtests@outlook.com", "Pr102030!");

                MailMessage mail = new MailMessage();

                mail.Sender = new System.Net.Mail.MailAddress("confirmtests@outlook.com", "Pablo");

                mail.From = new MailAddress("confirmtests@outlook.com");

                mail.To.Add(new MailAddress(email));

                mail.Subject = Subject;

                mail.Body = Body;

                mail.IsBodyHtml = true;

                mail.Priority = MailPriority.High;

                mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "ResetSenha" + "/" + nome + ".png"));
                try
                {
                    client.Send(mail);
                }
                catch (System.Exception erro)
                {

                }
                finally
                {
                        mail = null;
                }
            }

            private static void printScreen(IWebDriver driver, string name, string folder)
            {
                ResetSenha.name = name;

                var print = ((ITakesScreenshot)driver).GetScreenshot();

                print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");
            }

        public static void EmailRecebido(IWebDriver driver, string body, string assunto)
        {

            Funcoes.body = body;
            
            Assert.True(_email.Subject.Contains(assunto));
        }

        public static void CanExtractConfirmationCode()
        {
            var rx = new Regex(@".*Senha: (\w{6}).*", RegexOptions.Compiled);

            var match = rx.Match(_email.Body);

            _confirmationCode = match.Groups[1].Value;

            Assert.Equal(6, _confirmationCode.Length);
        }

    }
}



