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

    public class LinkPagamento
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public LinkPagamento(TestFixture fixture)
        {
            driver = fixture.Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
        }

        [Fact]

        public static void LinkDePagamento()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "LinkPagamento"))
            {

            }
            else
            {

                Directory.CreateDirectory(pasta + "" + "LinkPagamento");

            }
            try
            {
               // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "LinkPagamento", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "LinkPagamento", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "LinkPagamento", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Link Pagamento", "PesquisaPacientes", "LinkPagamento", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "LinkPagamento", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Automação");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "LinkPagamento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "LinkPagamento", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas", "DentistaSelecionado", "LinkPagamento", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VerClinicas", "ClinicaSelecionada", "LinkPagamento", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas", "Particular", "LinkPagamento", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "LinkPagamento", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "LinkPagamento", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "LinkPagamento", "");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro", "LinkPagamento", "Não conseegui abrir o financeiro do paciente");

                Funcoes.GlobalCheckout(driver, "BtnCheckout", "Assercao", "LinkPagamento", "Não consegui clicar no botão de checkout");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Credito", "LinkPagamento", " Não consegui selecionar a forma de pagamento", "'Cartão de Crédito'");

                Funcoes.BtnTipoCheckout(driver, "Tipo_Credito", "LinkPagamento", " Não consegui expandir a seleção de tipos de pagamento.");

                Funcoes.selecionarLinkPagamento(driver, "LinkPagamento", "LinkPagamento", " Não consegui expandir a seleção de tipos de pagamento.");
          
                Funcoes.BtnOk(driver, "ConfirmaSemEmail", "LinkPagamento", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoFaltaEmail(driver, "FaltaEmail", "LinkPagamento", "O sistema permitiu o checkout de link de pagamento sem inserir o e-mail.");

                Funcoes.EmailBoleto(driver, "InserirEmail", "LinkPagamento", "Não consegui inserir o e-mail no checkout");

                Funcoes.BtnOk(driver, "ConfirmaLink", "LinkPagamento", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.ConfirmaCheckoutLink(driver, "RealizandoCheckout_Credito", "LinkPagamento", " Não consegui finalizar o processo de Checkout.");

                Funcoes.VerLinkPagamento(driver, "CheckoutRealizado", "LinkPagamento", "Não consegui gerar o link de pagamento");

                Funcoes.AbrirLinkPagamento(driver, "VerLink", "LinkAberto", "LinkPagamento", "Não consegui ver o campo de responsável pelo pagamento.");

                Funcoes.BtnOk(driver, "Proximo", "LinkPagamento", " Não consegui clicar no botão de Próximo para realizar o pagamento.");

                Funcoes.PreencherCartaoSistema(driver, "CartaoSistemaPreenchido", "LinkPagamento", " Não consegui preencher os campos do cartão sistema.");

                Funcoes.BtnOk(driver, "ConfirmarPagamento", "LinkPagamento", " Não consegui clicar no botão de Ok para realizar o pagamento.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "LinkPagamento" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "LinkPagamento");

                sendMessage("Erro em teste de Checkout por Link de Pagamento", e.Message + Funcoes.body.ToString(), LinkPagamento.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "LinkPagamento" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "LinkPagamento" + "/" + nome + ".png"));
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
            LinkPagamento.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


