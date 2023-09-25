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

    public class ProcedimentoOdontograma
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email; 

        public ProcedimentoOdontograma(TestFixture fixture)
        {
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();
        }

        [Fact]

        public static void AdicionarProcedimentoOdontograma()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "ProcedimentoOdontograma"))
            {
		
            }
            else
            {

                Directory.CreateDirectory(pasta + "" + "ProcedimentoOdontograma");

            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "ProcedimentoOdontograma", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "ProcedimentoOdontograma", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "ProcedimentoOdontograma", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Pablo Testes", "PesquisaPacientes", "ProcedimentoOdontograma", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "ProcedimentoOdontograma", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Testes");

                Funcoes.AssercaoOdontograma(driver, "AbreOdontograma", "OdontogramaAberto", "ProcedimentoOdontograma", "Não consegui abrir o odontograma do paciente.");

                Funcoes.Deciduos(driver, "SelecionarDeciduos", "ProcedimentoOdontograma", "Não consegui alterar a dentição para decidua.");

                Funcoes.BtnOk(driver, "ConfirmaDeciduos", "ProcedimentoOdontograma", "Não consegui confirmar a troca de dentição.");

                Funcoes.carregamento(driver, "loading1", "ProcedimentoOdontograma", "");

                Funcoes.AbrirDente(driver, "AbrirDente", "ProcedimentoOdontograma", "Não consegui abrir um dente decíduo.");

                Funcoes.BtnCancelar(driver, "BtnVoltar", "Voltou", "ProcedimentoOdontograma", "Não consegui voltar para ver o odontograma");

                Funcoes.Deciduos(driver, "SelecionarPermanentes", "ProcedimentoOdontograma", "Não consegui alterar a dentição para permanentes.");

                Funcoes.carregamento(driver, "Loading2", "ProcedimentoOdontograma", "");

                Funcoes.BtnOk(driver, "ConfirmaPermanentes", "ProcedimentoOdontograma", "Não consegui confirmar a troca de dentição.");

                Funcoes.carregamento(driver, "Loading5", "ProcedimentoOdontograma", "");

                Funcoes.PreencherProcedimento(driver, "DentePermanente", "PesquisaProcedimento", "VerProfissionais", "DetalheObs", "ProcedimentoOdontograma", "Não consegui adicionar o procedimento no dente permanente.");

                Funcoes.BtnOk(driver, "ConfirmaProcedimento", "ProcedimentoOdontograma", "Não consegui confirmar o procedimento no dente.");

                Funcoes.carregamento(driver, "loading3", "ProcedimentoOdontograma", "");

                Funcoes.AssercaoProcedimento(driver, "ProcedimentoCriado", "ProcedimentoOdontograma", "O procedimento não condiz com o que criei.");

                Funcoes.AddProcedimento(driver, "BtnAddProced", "ProcedimentoOdontograma", "O botão de adicionar procedimento não funcionou.");

                Funcoes.BtnCancelar(driver, "BtnCancelarAdd", "Cancelou", "ProcedimentoOdontograma", "Não consegui clicar no botão de cancelar.");

                Funcoes.RemoverProcedimento(driver, "3Pontos", "Remover", "ProcedimentoOdontograma", "Não consegui clicar nos 3 pontos.");

                Funcoes.BtnOk(driver, "ExcluirProced", "ProcedimentoOdontograma", "Não consegui confirmar a exclusão do procedimento.");

                Funcoes.carregamento(driver, "loading4", "ProcedimentoOdontograma", "");

                Funcoes.AssercaoProcedimentoExcluido(driver, "ProcedimentoExcluído", "ProcedimentoOdontograma", "O procedimento não foi removido.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ProcedimentoOdontograma" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "ProcedimentoOdontograma");

                sendMessage("Erro em teste [Adicionar procedimento no Odontograma]", e.Message + Funcoes.body.ToString(), ProcedimentoOdontograma.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ProcedimentoOdontograma" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "ProcedimentoOdontograma" + "/" + nome + ".png"));

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
            ProcedimentoOdontograma.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


