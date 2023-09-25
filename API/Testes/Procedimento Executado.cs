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

    public class PrcedimentoExecutado
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public PrcedimentoExecutado(TestFixture fixture)
        {           
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();
        }

        [Fact]

        public static void ProcedExec()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "PrcedimentoExecutado"))
            {
                
            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "PrcedimentoExecutado");

            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "PrcedimentoExecutado", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "PrcedimentoExecutado", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "PrcedimentoExecutado", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Pablo Procedimento", "PesquisaPacientes", "PrcedimentoExecutado", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "PrcedimentoExecutado", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Procedimento");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "PrcedimentoExecutado", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento_Credito", "PrcedimentoExecutado", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas_Credito", "DentistaSelecionado_Credito", "PrcedimentoExecutado", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas_Credito", "ClinicaSelecionada_Credito", "PrcedimentoExecutado", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas_Credito", "TabelaSelecionada_Credito", "PrcedimentoExecutado", " Não consegui selecionar a tabela Particular.");

                Funcoes.Procedimento2Dentes(driver, "Btn", "AdicionarProced", "SelecionarDentes", "Adicionado", "PrcedimentoExecutado", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.FormaPagamento(driver, "BtnFormaPagamento", "BtnProcedEcex", "PrcedimentoExecutado", "Não conegui definir a forma de Pagamento por Procedimento Executado ao criar orçamento.");

                Funcoes.BtnOk(driver, "ConfirmarFormaPagamento", "PrcedimentoExecutado", "Não consegui confirmar a forma de pagamento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao_Credito", "OrcamentoAprovado_Credito", "PrcedimentoExecutado", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "PrcedimentoExecutado", "");

                // ***************************** PLANO E FICHA

                Funcoes.AssercaoPlanoEFicha(driver, "PlanoEficha", "PrcedimentoExecutado", "Não consegui acessar a aba de Plano e Ficha Clínica");

                Funcoes.PlanosTratamentos(driver, "PlanosTratamentos", "EmAberto", "PrcedimentoExecutado", "Não consegui visualizar os planos de tratamentos em aberto");

                Funcoes.ExecutarProcedimento(driver, "ExecutarProced", "PrcedimentoExecutado", "Não consegui visualizar a janela de executar Procedimento");

                Funcoes.BtnOk(driver, "ExecutarProcedimento", "PrcedimentoExecutado", "Não consegui executar o procedimento.");

                Funcoes.carregamento(driver, "Carregando", "PrcedimentoExecutado", "Erro ao carregar");

                // ***************************** FINANCEIRO_DINHEIRO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro", "PrcedimentoExecutado", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout", "Assercao", "PrcedimentoExecutado", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Dinheiro", "PrcedimentoExecutado", " Não consegui selecionar a forma de pagamento", "'Dinheiro'");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Dinheiro", "PrcedimentoExecutado", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Dinheiro", "PrcedimentoExecutado", "dinheiro", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Dinheiro", "CheckoutRealizado_Dinheiro", "PrcedimentoExecutado", " Não consegui finalizar o processo de Checkout.");

                Funcoes.Btn3Pontos(driver, "verFinanceiro_Dinheiro", "VerOpcoes_Dinheiro", "PrcedimentoExecutado", " Não consegui clicar nos 3 pontinhos para visualizar as opções");

                Funcoes.Opcao3Pontos(driver, "AntesClick_Dinheiro", "ClickParcelas_Dinheiro", "PrcedimentoExecutado", "'Parcelas'", "Não consegui clicar em Parcelas");

                //Funcoes.PagamentoRecebido(driver, "PagamentoRecebido_Dinheiro", "chekoutUnificado", "Não consegui encontrar o Recebido na parcela.");

                Funcoes.BtnFechar(driver, "FecharParcelas_Dinheiro", "PrcedimentoExecutado", "Não consegui fechar a janela Parcelas.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "PrcedimentoExecutado" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "PrcedimentoExecutado");

                sendMessage("Erro em teste Orçamento por Procedimento Executado", e.Message + Funcoes.body.ToString(), PrcedimentoExecutado.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "PrcedimentoExecutado" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "PrcedimentoExecutado" + "/" + nome + ".png"));
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
            PrcedimentoExecutado.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }

    }
    
}


