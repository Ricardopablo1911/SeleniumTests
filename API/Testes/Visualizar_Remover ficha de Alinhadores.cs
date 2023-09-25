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

    public class VisualizarRemoverFicha
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public VisualizarRemoverFicha(TestFixture fixture)
        {
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();
        }

        [Fact]

        public static void VisualizarRemoverFichaAlinhadores()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "VisualizarRemoverFicha"))
            {

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "VisualizarRemoverFicha");
            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "VisualizarRemoverFicha", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "VisualizarRemoverFicha", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "VisualizarRemoverFicha", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Alinhadores", "PesquisaPacientes", "VisualizarRemoverFicha", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "VisualizarRemoverFicha", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Alinhadores");

                Funcoes.AssercaoFichaEspecialidades(driver, "FichaEspecialidades", "VisualizarRemoverFicha", "Não consegui abrir a ficha de especialidades.");

                Funcoes.AssercaoFichaCriada(driver, "", "", "Não conseugi encontrar a ficha criada.");

                Funcoes.Btn3pontosDocumentos(driver, "3Pontos", "VisualizarRemoverFicha", "Não consegui abrir as opções para excluir a ficha.");

                Funcoes.ExcluirNovaFicha(driver, "Excluir", "VisualizarRemoverFicha", "Não consegui clicar para excluir a ficha.");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "VisualizarRemoverFicha", "Não consegui confirmar a exclusão da ficha.");

                Funcoes.carregamento(driver, "Loading", "VisualizarRemoverFicha", "");

                Funcoes.AssercaoSemDocumentos(driver, "FichaExcluida", "VisualizarRemoverFicha", "A ficha não foi excluída.");

                Funcoes.BtnNovaFicha(driver, "NovaFicha", "VisualizarRemoverFicha", "Não consegui clicar no botão para adicionar nova ficha de especialdiades.");

                Funcoes.PreencherNovaFicha(driver, "Clinica", "Simplificada", "Dados", "VisualizarRemoverFicha", "Não consegui preencher a nova ficha.");

                Funcoes.BtnOk(driver, "Confirma", "VisualizarRemoverFicha", "Não consegui confirmar a criação de uma nova ficha.");

                Funcoes.carregamento(driver, "Loading", "VisualizarRemoverFicha", "");

                Funcoes.AssercaoFichaAlinhadores(driver, "CriarTratamento", "Avaliacao", "StatusTratamento", "VisualizarRemoverFicha", "Não consegui visualizar a ficha de alinhadores.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "VisualizarRemoverFicha" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "VisualizarRemoverFicha");

                sendMessage("Erro em teste [Visualizar/RemoverFicha de Alinhadores]", e.Message + Funcoes.body.ToString(), VisualizarRemoverFicha.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "VisualizarRemoverFicha" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "VisualizarRemoverFicha" + "/" + nome + ".png"));

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
            VisualizarRemoverFicha.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


