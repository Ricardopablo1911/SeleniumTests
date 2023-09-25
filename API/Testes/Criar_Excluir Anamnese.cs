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

    public class CriarExcluirAnamnese
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email; 

        public CriarExcluirAnamnese(TestFixture fixture)
        {

            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();

        }

        [Fact]

        public static void Criar_ExcluirAnamnese()

        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "CriarExcluirAnamnese"))
            {

            }

            else
            {
                Directory.CreateDirectory(pasta + "" + "CriarExcluirAnamnese");
            }

            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "CriarExcluirAnamnese", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "CriarExcluirAnamnese", " Não consegui efetuar o login no sistema.");

                Funcoes.MenuLateral(driver, "MenuLateral", "CriarExcluirAnamnese", "Não consegui abrir o menu lateral");

                Funcoes.Configuração(driver, "BtnConfiguração", "Configuracao", "CriarExcluirAnamnese", "Não consegui acessar a janela de configuração.");

                Funcoes.Anamnese(driver, "BtnAnamnese", "Assercao", "CriarExcluirAnamnese", "Não consegui expandir a aba de anamnese");

                Funcoes.AbrirHoroFacial(driver, "BtnHoroFacial", "Assercao", "CriarExcluirAnamnese", "Não consegui abrir a anamnese de Harmonização Horofacial");

                Funcoes.BtnNovaPergunta(driver, "NovaPergunta", "Opcoes", "CriarExcluirAnamnese", "Não consegui criar uma nova pergunta.");

                Funcoes.BtnOk(driver, "Confirma", "CriarExcluirAnamnese", "Não consegui confirmar a criação de uma nova pergunta na anamnese.");

                Funcoes.carregamento(driver, "Carregando", "CriarExcluirAnamnese", "");

                // ******************************** PESQUISA PACIENTE

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Pablo Automação", "PesquisaPaciente", "CriarExcluirAnamnese", "Não consegui pesquisar o paciente na barra de pesquisa");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Pablo Automação", "PabloAutomacao", "CriarExcluirAnamnese", "Não consegui abrir o prontuário pela barra de pesquisa.");

                Funcoes.AssercaoAnamnesePaciente(driver, "AnamnesePaciente", "CriarExcluirAnamnese", "Não consegui abrir a janela de anamnese no prontuário do paciente.");

                Funcoes.BtnNovaAnamnese(driver, "NovaAnamnese", "CriarExcluirAnamnese", "Não consegui abrir a janela de nova anamnese no prontuário do paciente.");

                Funcoes.BtnOk(driver, "ConfirmaNovaAnamnese", "CriarExcluirAnamnese", "Não consegui confirmar a criação de nova anamnese no prontuário do paciente.");

                Funcoes.BtnAnamneseEspecialidade(driver, "AnamneseEspecialidade", "Especialidade", "CriarExcluirAnamnese", "Não consegui inserir uma anamnese por especialidade no prontuário do paciente.");

                Funcoes.BtnOk(driver, "ConfirmarEspecialidade", "CriarExcluirAnamnese", "Não consegui concluir a anamnese por especialidade.");

                Funcoes.AssersaoAnamneseEspecialidade(driver, "VerEspecialidade", "Voltar", "CriarExcluirAnamnese", "Não consegui ver a anamnese por especialidade.");

                Funcoes.BtnVoltarConfiguracao(driver, "BtnVoltarConfiguracao", "Voltar", "CriarExcluirAnamnese", "Não consegui voltar para configuração.");

                Funcoes.ExcluirPergunta(driver, "BtnRemover","ExcluirPergunta", "CriarExcluirAnamnese", "Não consegui clicar no botão para excluir a pergunta.");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "CriarExcluirAnamnese", "Não consegui confirmar a exclusão de uma pergunta.");

                Funcoes.FichaExcluida(driver, "SemDados", "CriarExcluirAnamnese", "A pergunta não foi excluída.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "CriarExcluirAnamnese" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "CriarExcluirAnamnese");

                sendMessage("Erro em teste [Criar_Excluir_Anamnese]", e.Message + Funcoes.body.ToString(), CriarExcluirAnamnese.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "CriarExcluirAnamnese" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "CriarExcluirAnamnese" + "/" + nome + ".png"));

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
            CriarExcluirAnamnese.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


