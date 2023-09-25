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

    public class FichaClinicaOrcamento
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public FichaClinicaOrcamento(TestFixture fixture)
        {

            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();

        }

        [Fact]

        public static void FichaClinicaOrcamentoo()
        {

            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "FichaClinicaOrcamento"))
            {

            }

            else
            {
                Directory.CreateDirectory(pasta + "" + "FichaClinicaOrcamento");
            }

            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "FichaClinicaOrcamento", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "FichaClinicaOrcamento", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "FichaClinicaOrcamento", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Ficha Clinica Orcamento", "PesquisaPacientes", "FichaClinicaOrcamento", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "FichaClinicaOrcamento", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Ficha Clinica Orcamento");

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "FichaClinicaOrcamento", "Não consegui abrir a aba de orçamentos do paciente.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "FichaClinicaOrcamento", "Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas", "DentistaSelecionado", "FichaClinicaOrcamento", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VerClinicas", "ClinicaSelecionada", "FichaClinicaOrcamento", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas", "Particular", "FichaClinicaOrcamento", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "FichaClinicaOrcamento", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "FichaClinicaOrcamento", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "FichaClinicaOrcamento", "");

                Funcoes.AssercaoPlanoEFicha(driver, "PlanoeFicha", "FichaClinicaOrcamento", "Não consegui acessar a aba de Plano e Ficha Clínica.");

                Funcoes.PlanosTratamentos(driver, "PlanosTratamentos", "EmAberto", "FichaClinicaOrcamento", "Não consegui visualizar os planos de tratamentos em aberto");

                Funcoes.ExecutarProcedimento(driver, "ExecutarProced", "FichaClinicaOrcamento", "Não consegui visualizar a janela de executar Procedimento");

                Funcoes.BtnOk(driver, "ExecutarProcedimento", "FichaClinicaOrcamento", "Não consegui executar o procedimento.");

                Funcoes.carregamento(driver, "Carregando", "FichaClinicaOrcamento", "Erro ao carregar");

                Funcoes.AssercaoNovaFicha(driver, "FichaCriada", "FichaClinicaOrcamento", "Não consegui encontrar as informações corretas na ficha clínica.");

                Funcoes.CancelarExecucao(driver, "CancelarExecucao", "FichaClinicaOrcamento", "Não consegui clicar no X para cancelar a execução.");

                Funcoes.BtnOk(driver, "ConfirmaCancelar", "FichaClinicaOrcamento", "Não consegui cancelar a execução do procedimento.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "Autorizar", "FichaClinicaOrcamento", "Não consegui autorizar o cancelamento do procedimento.");

                Funcoes.BtnOk(driver, "OkAutorizar", "FichaClinicaOrcamento", "Não consegui finalizar o cancelamento da execução do procedimento.");

                Funcoes.carregamento(driver, "loading3", "FichaClinicaOrcamento", "");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro", "FichaClinicaOrcamento", "Não conseegui abrir o financeiro do paciente");

                Funcoes.Btn3Pontos(driver, "3pontos", "VerOpcoes", "FichaClinicaOrcamento", "Não consegui clicar nos 3 pontos do financeiro paciente");

                Funcoes.Opcao3Pontos(driver, "AntesClickExcluir", "Excluir", "FichaClinicaOrcamento", "'Excluir Lançamento'", "Não consegui clicar em Excluir Lançamento");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "FichaClinicaOrcamento", " Não consegui clicar no botão de Ok para realizar a exclusão do financeiro.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "Autorizar", "FichaClinicaOrcamento", "Não consegui inserir os dados para autozizar a exclusão do financeiro");

                Funcoes.BtnOk(driver, "ConfirmarDados", "FichaClinicaOrcamento", " Não consegui clicar no botão de Ok para Autorizar a exclusão do financeiro.");

                Funcoes.carregamento(driver, "Carregar", "FichaClinicaOrcamento", "Não consegui encontrar a tela de carregamento");

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "FichaClinicaOrcamento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.DesaprovarOrcamento(driver, "DesaprovarOrcamento", "FichaClinicaOrcamento", " Não consegui clicar no botão de Desaprovar Orçamento.");

                Funcoes.BtnOk(driver, "ConfirmarDesaprovacao", "FichaClinicaOrcamento", "Não consegui confirmar a desaprovação do orçamento.");

                Funcoes.AssercaoEmAberto(driver, "EmAberto", "FichaClinicaOrcamento", "Orçamento não ficou como Em Aberto.");

                Funcoes.AbrirOrcamentoEmAberto(driver, "AbrirOrcamento", "FichaClinicaOrcamento", "Não consegui abrir o orçamento em aberto.");

                Funcoes.Remover(driver, "VerValor", "Remover", "FichaClinicaOrcamento", "Não consegui clicar para remover o procedimento no orçamento.");

                Funcoes.BtnOk(driver, "ConfirmarRemocao", "FichaClinicaOrcamento", "Não consegui confirmar a remoção do procedimento no orçamento.");

                Funcoes.BtnOk(driver, "Salvar", "FichaClinicaOrcamento", "Não consegui clicar no salvar para remover o orçamento.");

                Funcoes.carregamento(driver, "loadingFinal", "FichaClinicaOrcamento", "");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "FichaClinicaOrcamento" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "FichaClinicaOrcamento");

                sendMessage("Erro em teste [Ficha_Clínica_Orçamento]", e.Message + Funcoes.body.ToString(), FichaClinicaOrcamento.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "FichaClinicaOrcamento" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "FichaClinicaOrcamento" + "/" + nome + ".png"));

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
            FichaClinicaOrcamento.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");
        }
    }
}


