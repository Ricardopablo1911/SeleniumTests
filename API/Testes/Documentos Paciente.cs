using Xunit;
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
using System;
using System.IO;
namespace Exemplo_2.Testes

{
    [Collection("Chrome Driver")]

    public class DocumentosPaciente
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public DocumentosPaciente(TestFixture fixture)
        {

            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();

        }

        [Fact]

        public static void DocumentosDoPaciente()

        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "DocumentosPaciente"))
            {

            }

            else
            {

                Directory.CreateDirectory(pasta + "" + "DocumentosPaciente");

            }

            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "DocumentosPaciente", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "DocumentosPaciente", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "DocumentosPaciente", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Pablo Testes", "PesquisaPacientes", "DocumentosPaciente", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "DocumentosPaciente", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Testes");

                Funcoes.AssercaoDocumentos(driver, "AbrirDocumentos", "DocumentosPaciente", "Não consegui abrir a aba de documentos do paciente.");

                Funcoes.AdicionarDocumento(driver, "AddDocumento", "DocumentosPaciente", "Não consegui clicar no botão de adicionar documento.");

                Funcoes.EscolherDocumento(driver, "Matricula", "Matrícula", "DocumentosPaciente", "Não consegui encontrar ou abrir o documento requerido.");

                Funcoes.DadosDocumento(driver, "LateralDireito", "NomeCelular", "LateralEsquerda", "AddAssinatura", "Signatario", "TipoAss", "Selecionados", "DocumentosPaciente", "Não consegui concluir o processo de adicionar assinatura eletrônica do paciente.");

                Funcoes.BtnOk(driver, "ConfirmaAss", "DocumentosPaciente", "Não consegui confirmar a adição da assinatura eletrônica do paciente.");

                Funcoes.BtnSalvar(driver, "Salvar", "DocumentosPaciente", "Não consegui salvar o documento.");

                Funcoes.BtnCancelar(driver, "BtnFechar", "Fechado", "DocumentosPaciente", "Não consegui fehar a tela de assinaturas.");

                Funcoes.AssercaoDocInserido(driver, "DocPronto", "DocumentosPaciente", "Não consegui encontrar o documento inserido.");

                Funcoes.Btn3pontosDocumentos(driver, "3Pontos", "DocumentosPaciente", "Não consegui clicar nos 3 pontos para ver as opções.");

                Funcoes.ExcluirNovaFicha(driver, "Remover", "DocumentosPaciente", "Não consegui clicar no remover documento.");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "DocumentosPaciente", "Não consegui confirmar a exclusão do documento.");

                Funcoes.carregamento(driver, "carregando", "DocumentosPaciente", "");

                Funcoes.AssercaoSemDocumentos(driver, "DocVazio", "DocumentosPaciente", "O documento não foi removido.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "DocumentosPaciente" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "DocumentosPaciente");

                sendMessage("Erro em teste [Documentos Paciente]", e.Message + Funcoes.body.ToString(), DocumentosPaciente.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "DocumentosPaciente" + "/" + "tempo_de_teste.txt";

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
            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "DocumentosPaciente" + "/" + nome + ".png"));
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
            DocumentosPaciente.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


