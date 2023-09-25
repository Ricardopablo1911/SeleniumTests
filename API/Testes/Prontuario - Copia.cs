using Exemplo_2.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Net.Mail;
using Assert = Xunit.Assert;
using System.ComponentModel.Design;
using Usar;
using Exemplo_2.Helpers;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;
using System;
using System.IO;
using Xunit;

namespace Exemplo_2.Testes
{
    [Collection("Chrome Driver")]

    public class Prontuario_Paciente
    {
        public static ExtentTest test;

        public static ExtentReports extent;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email; 

        public Prontuario_Paciente(TestFixture fixture)
        {

        }

        [Fact]
        
        public static void Prontuario()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            if (Directory.Exists(pasta + "" + "Prontuario"))
            {

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "Prontuario");
            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "Prontuario", " [Login.Acesso.Acessar URL Clinicorp] - Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "Prontuario", " [Login.Acesso.Clicar Botao Entrar] - Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "Prontuario", " [Login.Visualizacao Menu Inicial.Acessar Menu Lateral] - Não consegui encontrar os ícones do menu inicial.");

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "JanelaPacientes", "Prontuario", "[Pacientes.Visualizacao Aba Pacientes.Abrir Aba Pacientes] - Não consegui abrir a aba Pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Cadastro Paciente Automatico", "PesquisarPaciente", "Prontuario", "[Pacientes.Criacao Paciente.Buscar Paciente barra pesquisa] - Não consegui pesquisar o paciente pela janela de pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbrirProntuario", "Prontuario", "[Paciente.Visualizacao Prontuario Geral.Abrir prontuario geral] - Não consegui abrir o prontuário do paciente.", "Cadastro Paciente Automatico");

		        try 
		        {
                    Funcoes.TresPontosPaciente(driver, "ExpandirProntuario", "BtnContato", "Prontuario", "[Paciente.Visualizacao Prontuario Geral.Abrir prontuario geral] - Não consegui expandir as opções no cabeçalho do prontuário.");
                }
                catch 
		        {
                   
                }
                Funcoes.AssercaoCabecalho(driver, "AbrirProntuario", "Prontuario", "[Paciente.Visualizacao Prontuario Geral.Abrir prontuario geral] - Não consegui encontrar todas as informações no cabeçalho do prontuário.");

                Funcoes.AssercaoCadastro(driver, "Cadastro", "Prontuario", "[Pacientes.Visualizacao Aba Pacientes.Abrir Aba Pacientes] -  Não consigo clicar nas opções cadastrais do paciente.");

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "Prontuario", "[Paciente.Visualizacao Aba Orcamento.Abrir Aba Orcamento] - Não consegui abrir a aba Orçamentos no prontuário do paciente");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro", "Prontuario", "[Paciente.Visualizacao Aba Financeiro Paciente.Abrir Financeiro Paciente] - Não consegui abrir a aba Financeiro do Paciente");

                Funcoes.AssercaoFinanceiro(driver, "AssercaoFinanceiro", "Prontuario", "[Pacientes.Visualizacao Aba Pacientes.Abrir Aba Pacientes] -  Não consegui identificar a barra de informações no financeiro do paciente.");

                Funcoes.AssercaoFotosPaciente(driver, "AssercaoFotos", "Prontuario", "[Paciente.Visualizacao Aba Fotos.Abrir Aba fotos] -  Não consegui identificar os elementos da aba de Fotos do paciente.");

                Funcoes.AssercaoPlanoEFicha(driver, "AssercaoPlanoEFicha", "Prontuario", "[Paciente.Visualizacao Aba Plano Ficha.Abrir Aba Plano e Ficha ] -  Não consegui identificar os elementos da aba de Plano e Ficha Clínica.");

                Funcoes.AssercaoFichaEspecialidades(driver, "AssercaoFichaEspecialidades", "Prontuario", "[Paciente.Visualizacao Aba Fichas Especialidades.Abrir Aba Fichas Especialidades] -  Não consegui identificar os elementos da aba de Ficha de Especialidades.");

                Funcoes.AssercaoOdontograma(driver, "AssercaoOdontograma", "Denticao", "Prontuario", "[Paciente.Visualizacao Aba Odontograma.Abrir Aba Odontograma] -  Não consegui identificar os elementos no odontograma do paciente.");

                Funcoes.AssercaoAnamnesePaciente(driver, "AssercaoAnamnese", "Prontuario", "[Paciente.Visualizacao Aba Anamnese.Abrir Aba Anamnese] -  Não consegui identificar os elementos na aba de Anamnese.");

                Funcoes.AssercaoPlanosRecorrentes(driver, "AssercaoPlanosRecorrentes", "Prontuario", "[Paciente.Visualizacao Aba Plano Recorrente.Abrir Aba Planos Recorrentes] -  Não consegui identificar os elementos na aba de Planos Recorrentes.");

                Funcoes.AssercaoDocumentos(driver, "AssercaoDocumentos", "Prontuario", "[Paciente.Visualizacao Aba Documentos.Abrir Aba Documentos] -  Não consegui identificar os elementos na aba de Planos Recorrentes.");

                Funcoes.AssercaoExames(driver, "AssercaoExames", "Prontuario", "[Paciente.Visualizacao Aba Exames.Abrir Aba Exames] -  Não consegui identificar os elementos na aba de Exames.");

                Funcoes.AssercaoRecibos(driver, "AssercaoRecibos", "Prontuario", "[Paciente.Visualizacao Aba Recibos.Abrir Aba Recibos] -  Não consegui identificar os elementos na aba de Recibos.");

                Funcoes.AssercaoAgendamentosPacientes(driver, "AssercaoAgendamentos", "Prontuario", "[Paciente.Visualizacao Aba Agendamentos.Abrir Aba Agendamentos] -  Não consegui identificar os elementos na aba de Agendamentos.");

                Funcoes.AssercaoIndicacao(driver, "AssercaoIndicacoes", "Prontuario", " Não consegui identificar os elementos na aba de Indicações.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "Prontuario" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "Prontuario");

                sendMessage("Erro em teste de visualizar as abas do Prontuario", e.Message + Funcoes.body.ToString(), Prontuario_Paciente.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "Prontuario" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "Prontuario" + "/" + nome + ".png"));

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
            Prontuario_Paciente.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
       
    }
    
}


