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

    public class OrcamentoPlano
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public OrcamentoPlano(TestFixture fixture)
        {
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();
        }

        [Fact]

        public static void FazerOrcamentoPlano()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            
            if (Directory.Exists(pasta + "" + "OrcamentoPlano"))
            {

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "OrcamentoPlano");
            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "OrcamentoPlano", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "OrcamentoPlano", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "OrcamentoPlano", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Pablo Orçamento Plano", "PesquisaPacientes", "OrcamentoPlano", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "OrcamentoPlano", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Automação");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "OrcamentoPlano", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "OrcamentoPlano", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas", "DentistaSelecionado", "OrcamentoPlano", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VerClinicas", "ClinicaSelecionada", "OrcamentoPlano", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaPlano(driver, "VisualizarTabelas", "RedeUnna", "OrcamentoPlano", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "OrcamentoPlano", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "OrcamentoPlano", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "OrcamentoPlano", "");

                Funcoes.MenuLateral(driver, "MenuLateral", "OrcamentoPlano", "Não consegui acessar o menu Lateral");

                Funcoes.Inicio(driver, "BtnInicio", "TelaInicial", "OrcamentoPlano", "Não consegui voltar ao Início");

                Funcoes.JanelaFinanceiroClinica(driver, "AbrirFinanceiro", "OrcamentoPlano", "Não consegui abrir o financeiro");

                Funcoes.JanelaControlePlanos(driver, "Controle de Planos", "ListaPlanos", "TipoPlano", "OrcamentoPlano", "Não consegui visualizar as informações do controle de plçanos");

                Funcoes.GuiaPlano(driver, "GuiaPlano", "OrcamentoPlano", "Não consegui listar o procedimento no controle de Planos");

                Funcoes.Parcelas(driver, "BtnBaixa", "ConfirmarRecebimento", "OrcamentoPlano", "'file_download'", "Não consegui clicar no botão de confirmar o recebimento no Controle de Planos.");

                Funcoes.BtnOk(driver, "ConfirmandoRecebimento", "OrcamentoPlano", "Não consegui confirmar o recebimento no controle de Planos");

                Funcoes.ListarTodos(driver, "ListarTodos", "OrcamentoPlano", "Não consegui listar tipo Todos no controle de Planos.");

                Funcoes.DesfazerRecebimento(driver, "DesfazerRecebimento", "OrcamentoPlano", "Não consegui clicar no botão de desfazer recebimento no controle de Planos.");

                Funcoes.BtnOk(driver, "CancelarPagamento", "OrcamentoPlano", "Não consegui cancelar o recebimento no controle de Planos");

                Funcoes.ExcluirParcela(driver, "ExcluirParcela", "OrcamentoPlano", "Não consegui clicar no botão da lixeira no controle de Planos");

                Funcoes.BtnOk(driver, "ExcluirLancamento", "OrcamentoPlano", "Não consegui excluir o lançamento no controle de Planos.");

                Funcoes.ParcelaExcluida(driver, "LancamentoExcluido", "OrcamentoPlano", "O lançamento não foi excluido no controle de planos.");

                Funcoes.Inicio(driver, "BtnInicioExclusao", "TelaInicial2", "OrcamentoPlano", "Não consegui voltar ao Início");

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes2", "OrcamentoPlano", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Pablo Orçamento Plano", "PesquisaPacientes2", "OrcamentoPlano", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario2", "OrcamentoPlano", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Automação");

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos2", "BtnNovoOrcamento2", "OrcamentoPlano", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.DesaprovarOrcamento(driver, "DesaprovarOrcamento", "OrcamentoPlano", " Não consegui clicar no botão de Desaprovar Orçamento.");

                Funcoes.BtnOk(driver, "ConfirmarDesaprovacao", "OrcamentoPlano", "Não consegui confirmar a desaprovação do orçamento.");

                Funcoes.AssercaoEmAberto(driver, "EmAberto", "OrcamentoPlano", "Orçamento não ficou como Em Aberto.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "OrcamentoPlano" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "OrcamentoPlano");

                sendMessage("Erro em teste [Menu_Pagina_Inicial]", e.Message + Funcoes.body.ToString(), OrcamentoPlano.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "OrcamentoPlano" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "OrcamentoPlano" + "/" + nome + ".png"));
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
            OrcamentoPlano.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


