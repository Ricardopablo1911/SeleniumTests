
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
using Xunit;


namespace Exemplo_2.Testes

{
    [Collection("Chrome Driver")]

    public class NovoUsuario
    {
        private IWebDriver driver;
        private string folder;
        public static string name;
        public static string pasta;
        public static string email;


        private static Configuration config;
        private static readonly long TimeoutMillis = 30_000L;
        private static Email _email;
        private static InboxIdItem _inbox;
        private static InboxDto inbox;
        private static readonly string YourApiKey = "c78a758f35e98083c2a42829218c1b262b56ef72f9c5ee910f1c7616a7cda19a";

        public NovoUsuario(TestFixture fixture)
        {

            driver = fixture.Driver;

            driver.Manage().Window.Maximize();
           
        }

            [Fact]


            public static void CriarNovoUsuario()

            {
                 pasta = TestHelpers.pasta;

                 email = TestHelpers.email;

                 ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

                 driver.Manage().Window.Maximize();

                 DateTime startTime = DateTime.Now;

                 IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                if (Directory.Exists(pasta + "" + "NovoUsuario"))
                {

                }

                else
                {

                    Directory.CreateDirectory(pasta + "" + "NovoUsuario");

                }

                try
                {

                    // ************************* LOGIN

                    var timeout = TimeSpan.FromMilliseconds(TimeoutMillis);

                    var config = new Configuration();

                    config.ApiKey.Add("x-api-key", "c78a758f35e98083c2a42829218c1b262b56ef72f9c5ee910f1c7616a7cda19a");

                    var apiInstance = new InboxControllerApi(config);

                    var inboxControllerApi = new InboxControllerApi(config);

                    inbox = inboxControllerApi.CreateInbox();

                    string final = inbox.EmailAddress;

                    Funcoes.PaginaInicial(driver, "PaginaInicial", "NovoUsuario", " Não consegui encontrar o seja bem vindo na página inicial.");

                    Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "NovoUsuario", " Não consegui efetuar o login no sistema.");

                    Funcoes.MenuLateral(driver, "MenuLateral", "NovoUsuario", "Não consegui abrir o menu lateral.");

                    Funcoes.UsuariosPermissoes(driver, "BtnUsuariosPermissoes", "Assercao", "NovoUsuario", "Não consegui abrir Usuários e Permissões.");

                    Funcoes.NovoUsuario(driver, "BtnNovo", "JanelaNovoUsuario", "NovoUsuario", "Não consegui abrir a janela para adicionar um novo usuário.");
                  
                    Funcoes.DadosUsuario(driver, "DadosUsuario", "NovoUsuario", "Não consegui preencher os dados para criar um novo usuário.", final);

                    Funcoes.BtnOk(driver, "ConfirmaCriacao", "NovoUsuario", "Não consegui confirmar a criação de um novo usuário.");

                    Funcoes.carregamento(driver, "loading", "NovoUsuario", "");

                    Funcoes.AssercaoNovoUsuario(driver, "UsuarioCriado", "NovoUsuario", "Não consegui encontrar o novo usuário criado.");

                    var waitForControllerApi = new WaitForControllerApi(config);

                    _email = waitForControllerApi.WaitForLatestEmail(inboxId: inbox.Id, unreadOnly: true);

                    EmailRecebido(driver, "Não recebi o e-mail de novo usuário", "Senha Inicial Clinicorp");

                    Funcoes.ExpandirTesteAutomatizado(driver, "VerUsuario", "NovoUsuario", "Não consegui expandir o novo usuário.");

                    Funcoes.InativarUsuario(driver, "BtnInativar", "Inativar", "NovoUsuario", "Não consegui clicar para inativar o usuário.");

                    Funcoes.ExcluirUsuario(driver, "BtnExcluir", "ExcluirUsuario", "NovoUsuario", "Não consegui clicar para excluir o usuário.");

                    Funcoes.BtnOk(driver, "ConfirmaExclusao", "NovoUsuario", "Não consegui confirmar a exclusão do usuário.");

                    Funcoes.carregamento(driver, "loading2", "NovoUsuario", "");

                    Funcoes.carregamento(driver, "loading3", "NovoUsuario", "");

                    Funcoes.AssercaoUsuarioExcluido(driver, "UsuarioExcluido", "NovoUsuario", "O usuário não foi excluído como deveria.");


                    DateTime endTime = DateTime.Now;

                    double duration = (endTime - startTime).TotalSeconds;

                    int minutes = (int)(duration / 60);

                    int seconds = (int)(duration % 60);

                    string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                    string filePath = pasta + "" + "NovoUsuario" + "/" + "tempo_de_teste.txt";

                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.Write(outputStr);
                    }

                    driver.Quit();



                }
                catch (Exception e)
                {
                    printScreen(driver, "Erro", "NovoUsuario");

                    sendMessage("Erro em teste Criar novo Usuário", e.Message + Funcoes.body.ToString(), NovoUsuario.name);

                    DateTime endTime = DateTime.Now;

                    double duration = (endTime - startTime).TotalSeconds;

                    int minutes = (int)(duration / 60);

                    int seconds = (int)(duration % 60);

                    string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                    string filePath = pasta + "" + "NovoUsuario" + "/" + "tempo_de_teste.txt";

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

                mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "NovoUsuario" + "/" + nome + ".png"));
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
                NovoUsuario.name = name;

                var print = ((ITakesScreenshot)driver).GetScreenshot();

                print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

            }

            public static void EmailRecebido(IWebDriver driver, string body, string assunto)
            {
                Funcoes.body = body;
            
                Assert.True(_email.Subject.Contains(assunto));

            }



    }
}



