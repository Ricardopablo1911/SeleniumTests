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
using Xunit;

namespace Exemplo_2.Testes
{
    [Collection("Chrome Driver")]

    public class VisualizarOdontograma
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email; 

        public VisualizarOdontograma(TestFixture fixture)
        {
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();
        }

        [Fact]

        public static void VerOdontograma()
        {

            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "VisualizarOdontograma"))
            {

            }
            else
            {

                Directory.CreateDirectory(pasta + "" + "VisualizarOdontograma");

            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "VisualizarOdontograma", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "VisualizarOdontograma", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "VisualizarOdontograma", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Paciente Odontograma", "PesquisaPacientes", "VisualizarOdontograma", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "VisualizarOdontograma", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Paciente Odontograma");

                Funcoes.AssercaoOdontograma(driver, "AbreOdontograma", "OdontogramaAberto", "VisualizarOdontograma", "Não consegui abrir o odontograma do paciente.");

                Funcoes.Denticao(driver, "DentesDeciduos", "VisualizarOdontograma", "Não consegui visualizar os dentes deciduos do paciente.");

                Funcoes.BtnOk(driver, "VoltaOdontograma", "VisualizarOdontograma", "Não consegui clicar no Ok dos dentes deciduos.");

                Funcoes.ZoomOdontograma(driver, "Zoom", "ZoomOut", "VisualizarOdontograma", "Não consegui dar zoom no odontograma.");

                Funcoes.AddProcedimento(driver, "AddProcedimento", "VisualizarOdontograma", "Não consegui clicar em Adicionar Procedimento no odontograma.");

                Funcoes.BtnCancelar(driver, "BtnCancelar", "Cancelado", "VisualizarOdontograma", "Não consegui clicar no cancelar do adicionar procedimento.");

                Funcoes.ImprimirOdontograma(driver, "Imprimir", "VisualizarOdontograma", "Não consegui clicar em Imprimir Odontograma.");

                Funcoes.BtnCancelar(driver, "BtnCancelarImpressao", "ImpressaoCancelada", "VisualizarOdontograma", "Não consegui clicar no cancelar do imprimir odontograma.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "VisualizarOdontograma" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "VisualizarOdontograma");

                sendMessage("Erro em teste [Visualizar Odontograma]", e.Message + Funcoes.body.ToString(), VisualizarOdontograma.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "VisualizarOdontograma" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "VisualizarOdontograma" + "/" + nome + ".png"));
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
            VisualizarOdontograma.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


