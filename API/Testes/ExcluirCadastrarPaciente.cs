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
using mailslurp.Model;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using Xunit;
namespace Exemplo_2.Testes

{
    [Collection("Chrome Driver")]

    public class ExcluirCadastrarPaciente
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public ExcluirCadastrarPaciente(TestFixture fixture)
        {    
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Fact]

        public static void CadastrarExcluirCadastrar_Paciente()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "ExcluirCadastrarPaciente"))
            {  

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "ExcluirCadastrarPaciente");
            }
            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "ExcluirCadastrarPaciente", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "ExcluirCadastrarPaciente", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.PesquisarNomeBarraPesquisa(driver, "%Automatico", "PesquisaPacientes", "ExcluirCadastrarPaciente", " Não consegui encontrar o paciente pela barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Cadastro Paciente Automatico", "Prontuario", "ExcluirCadastrarPaciente", "Não consegui abrir o prontuário do paciente pela barra de pesquisa.");

		        try 
		        {
                    Funcoes.TresPontosPaciente(driver, "3Pontos", "BtnContato", "ExcluirCadastrarPaciente", "Não consegui visualizar as opções do paciente.");
                }

		        catch 
		        {

		        }  

                Funcoes.BtnExcluirPaciente(driver, "BtnExcluir", "Excluir", "ExcluirCadastrarPaciente", "Não Clicar no botão de excluir Paciente.");

                Funcoes.BtnOk(driver, "Confirmar", "ExcluirCadastrarPaciente", "Não Confirmar exclusão do paciente.");

                Funcoes.BtnNovoPaciente(driver, "NovoPaciente", "ExcluirCadastrarPaciente", " Não consegui abrir a janela para cadastrar novo paciente.");

                Funcoes.PrimeirosDadosNovoPaciente(driver, "DadosPaciente", "ExcluirCadastrarPaciente", " Não consegui inserir os dados para cadastrar novo paciente.", "Cadastro Paciente Automatico", "pablo_ricardo.jgs@hotmail.com", "47 996280417", "6239558");

                Funcoes.SegundosDadosNovoPaciente(driver, "DadosPaciente2", "ExcluirCadastrarPaciente", " Não consegui inserir os segundos dados para cadastrar novo paciente.", "67490492904");

                Funcoes.BtnOkPaciente(driver, "ConfirmarCadastro", "ExcluirCadastrarPaciente", " Não consegui confirmar o cadastro de um novo paciente.");

                Funcoes.carregamento(driver, "Carregamento", "ExcluirCadastrarPaciente", "");

                Funcoes.AssercaoCadastro(driver, "DadosCadastrais", "Contato", "ExcluirCadastrarPaciente", "Os dados inseridos no cadastro do paciente não correspondem ao cadastro exibido no prontuário.");

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Cadastro Paciente Automatico", "BuscaNomeCompleto", "ExcluirCadastrarPaciente", " Não consegui encontrar o paciente pela barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Cadastro Paciente Automatico", "ProntuarioNomeCompleto", "ExcluirCadastrarPaciente", "Não consegui abrir o prontuário do paciente pela barra de pesquisa.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ExcluirCadastrarPaciente" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "ExcluirCadastrarPaciente");

                sendMessage("Erro em teste de Excluir e Cadastrar um Paciente", e.Message + Funcoes.body.ToString(), ExcluirCadastrarPaciente.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ExcluirCadastrarPaciente" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "ExcluirCadastrarPaciente" + "/" + nome + ".png"));

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
            ExcluirCadastrarPaciente.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }



    }
    
}


