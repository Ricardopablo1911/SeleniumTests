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



    public class CartaoSistema
    {
        private IWebDriver driver;
        private string folder;
        public static string name;
        public static string pasta;        public static string email;

        public CartaoSistema(TestFixture fixture)
        {

            driver = fixture.Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();

        }

        [Fact]

        public static void TesteCartaoSistema()

        {
            pasta = TestHelpers.pasta;            email = TestHelpers.email;
            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            DateTime startTime = DateTime.Now;



            if (Directory.Exists(pasta + "" + "CartaoSistema"))
            {

            }

            else
            {

                Directory.CreateDirectory(pasta + "" + "CartaoSistema");

            }

            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "CartaoSistema", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "CartaoSistema", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "CartaoSistema", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Cartão Sistema", "PesquisaPacientes", "CartaoSistema", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "CartaoSistema", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Automação");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "CartaoSistema", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "CartaoSistema", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas", "DentistaSelecionado", "CartaoSistema", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VerClinicas", "ClinicaSelecionada", "CartaoSistema", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas", "Particular", "CartaoSistema", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "CartaoSistema", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "CartaoSistema", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "CartaoSistema", "");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro", "CartaoSistema", "Não conseegui abrir o financeiro do paciente");

                Funcoes.GlobalCheckout(driver, "BtnCheckout", "Assercao", "CartaoSistema", "Não consegui clicar no botão de checkout");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Credito", "CartaoSistema", " Não consegui selecionar a forma de pagamento", "'Cartão de Crédito'");

                Funcoes.BtnTipoCheckout(driver, "Tipo_Credito", "CartaoSistema", " Não consegui expandir a seleção de tipos de pagamento.");

                Funcoes.selecionarCartaoSistema(driver, "CartaoSistema", "CartaoSistema", " Não consegui expandir a seleção de tipos de pagamento.");

                Funcoes.PreencherCartaoSistema(driver, "CartaoSistemaPreenchido", "CartaoSistema", " Não consegui preencher os campos do cartão sistema.");

                Funcoes.EmailBoleto(driver, "InserirEmail", "CartaoSistema", "Não consegui inserir o e-mail no checkout");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Credito", "CartaoSistema", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Credito", "CartaoSistema", "cartão de crédito", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Credito", "CartaoSistema", "CartaoSistema", " Não consegui finalizar o processo de Checkout.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "CartaoSistema" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();


            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "CartaoSistema");
                sendMessage("Erro em teste de realizar checkout com Cartão Sistema", e.Message + Funcoes.body.ToString(), CartaoSistema.name);
                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "CartaoSistema" + "/" + "tempo_de_teste.txt";

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
            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "CartaoSistema" + "/" + nome + ".png"));
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
            CartaoSistema.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();
            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


