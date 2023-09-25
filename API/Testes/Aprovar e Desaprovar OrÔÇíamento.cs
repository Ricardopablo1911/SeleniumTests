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



    public class CriarDesaprovarOrcamento
    {
        private IWebDriver driver;
        private string folder;
        public static string name;
        public static string pasta;        public static string email;

        public CriarDesaprovarOrcamento(TestFixture fixture)
        {

            driver = fixture.Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            

        }

        [Fact]

        public static void TesteAprovarDesaprovarOrcamento()

        {
            pasta = TestHelpers.pasta;            email = TestHelpers.email;
            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            driver.Manage().Window.Maximize();
            DateTime startTime = DateTime.Now;


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;



            if (Directory.Exists(pasta + "" + "CriarDesaprovarOrcamento"))
            {

            }

            else
            {

                Directory.CreateDirectory(pasta + "" + "CriarDesaprovarOrcamento");

            }

            try
            {

                Funcoes.PaginaInicial(driver, "PaginaInicial", "CriarDesaprovarOrcamento", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "CriarDesaprovarOrcamento", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "CriarDesaprovarOrcamento", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Pablo Orçamento Plano", "PesquisaPacientes", "CriarDesaprovarOrcamento", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "CriarDesaprovarOrcamento", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Automação");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "CriarDesaprovarOrcamento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "CriarDesaprovarOrcamento", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas", "DentistaSelecionado", "CriarDesaprovarOrcamento", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VerClinicas", "ClinicaSelecionada", "CriarDesaprovarOrcamento", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas", "Particular", "CriarDesaprovarOrcamento", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "CriarDesaprovarOrcamento", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "CriarDesaprovarOrcamento", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "carregamento", "CriarDesaprovarOrcamento", "");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro", "CriarDesaprovarOrcamento", "Não conseegui abrir o financeiro do paciente");

                Funcoes.Btn3Pontos(driver, "3pontos", "VerOpcoes", "CriarDesaprovarOrcamento", "Não consegui clicar nos 3 pontos do financeiro paciente");

                Funcoes.Opcao3Pontos(driver, "AntesClickExcluir", "Excluir", "CriarDesaprovarOrcamento", "'Excluir Lançamento'", "Não consegui clicar em Excluir Lançamento");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "CriarDesaprovarOrcamento", " Não consegui clicar no botão de Ok para realizar a exclusão do financeiro.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "Autorizar", "CriarDesaprovarOrcamento", "Não consegui inserir os dados para autozizar a exclusão do financeiro");

                Funcoes.BtnOk(driver, "ConfirmarDados", "CriarDesaprovarOrcamento", " Não consegui clicar no botão de Ok para Autorizar a exclusão do financeiro.");

                Funcoes.carregamento(driver, "Carregar", "CriarDesaprovarOrcamento", "");

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos2", "BtnNovoOrcamento2", "CriarDesaprovarOrcamento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.DesaprovarOrcamento(driver, "DesaprovarOrcamento", "CriarDesaprovarOrcamento", " Não consegui clicar no botão de Desaprovar Orçamento.");

                Funcoes.BtnOk(driver, "ConfirmarDesaprovacao", "CriarDesaprovarOrcamento", "Não consegui confirmar a desaprovação do orçamento.");

                Funcoes.AssercaoEmAberto(driver, "EmAberto", "CriarDesaprovarOrcamento", "Orçamento não ficou como Em Aberto.");



                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);
                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");


                string filePath = pasta + "" + "CriarDesaprovarOrcamento" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();



            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "CriarDesaprovarOrcamento");
                sendMessage("Erro em teste de Criar e Desaprovar Orçamento", e.Message + Funcoes.body.ToString(), CriarDesaprovarOrcamento.name);
                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);
                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");
                string filePath = pasta + "" + "CriarDesaprovarOrcamento" + "/" + "tempo_de_teste.txt";
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
            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "CriarDesaprovarOrcamento" + "/" + nome + ".png"));
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
            CriarDesaprovarOrcamento.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();
            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


