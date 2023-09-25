using Xunit;
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

namespace Exemplo_2.Testes

{
    [Collection("Chrome Driver")]

    

    public class Agendar_duplo_Clique
    {
        public static ExtentTest test;
        public static ExtentReports extent;
        //private IWebDriver driver;
        private string folder;
        public static string name;
        public static string pasta;        public static string email;

        public Agendar_duplo_Clique(TestFixture fixture)
        {
            //driver = fixture.Driver;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }


        [Fact]
        
        public static void AgendarDuploClique()

        {
            //Console.Write(TestHelpers.caminhoArquivo);	        pasta = TestHelpers.pasta;            email = TestHelpers.email;
            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            driver.Manage().Window.Maximize();
            DateTime startTime = DateTime.Now;


            if (Directory.Exists(pasta + "" + "AgendaDuploClique"))
            {

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "AgendaDuploClique");
            }
            try
            {

                Funcoes.PaginaInicial(driver, "PaginaInicial", "AgendaDuploClique", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Login", "Senha", "TelaInicial", "AgendaDuploClique", " Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "AgendaDuploClique", "Não consegui encontrar os ícones do menu inicial.");

                Funcoes.JanelaAgenda(driver, "JanelaAgenda", "AgendaDuploClique", "Não consegui clicar no ícone para abrir a agenda.");

                Funcoes.SelecionarClinicaAgenda(driver, "SelecionarClinica", "VerClinicas", "AgendaDuploClique", "Não consegui selecionar a clinica na agenda.");

                Funcoes.SelecionarDentistaAgenda(driver, "SelecionarDentista", "AgendaDuploClique", "Não consegui selecionar o dentista na agenda.");

                Funcoes.VisualizarAgendaDia(driver, "AgendaDia", "AgendaDuploClique", "Não consegui visualizar a agenda por dia.");

                Funcoes.DuploClique(driver, "BtnMais", "AgendaDuploClique", "Não consegui visualizar a tela de novo agendamento.");

                Funcoes.PacienteExistente(driver, "PacienteNovo", "AgendaDuploClique", "Não consegui pesquisar o paciente na agenda.");

                Funcoes.SelecionarPacienteExistente(driver, "SelecionarPacienteNovo", "AgendaDuploClique", "Não consegui selecionar um paciente existente na agenda.");

                Funcoes.ProcedimentosAgenda(driver, "InserirProcedimento", "Agendamento Automação duplo clique", "AgendaDuploClique", "Não consegui inserir o procedimento ao agendar o horário.");

                Funcoes.ObservacaoAgenda(driver, "InserirObservacao", "Observação paciente novo", "AgendaDuploClique", "Não consegui inserir a observação ao agendar o horário.");

                Funcoes.SelecionarCategoria(driver, "VerCategorias", "CategoriaSelecionada", "AgendaDuploClique", "Não consegui inserir a observação ao agendar o horário.");

                Funcoes.ConcluirAgendamento(driver, "ConcluirAgendamento", "AgendaDuploClique", "Não consegui concluir o agendamento.");

                Funcoes.VerAgendamento(driver, "VerAgendamento", "AgendaDuploClique", "Não consegui ver o agendamento.", "Agendamento Automação duplo clique", "Observação paciente novo", "(47) 99628-0417");

                Funcoes.ExcluirAgendamento(driver, "ExcluirAgendamento", "ConfirmaExclusao", "AgendamentoExcluido", "AgendaDuploClique", "Não consegui Excluir o agendamento.");


                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "AgendaDuploClique" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();


            }
            catch (Exception e)
            {

                printScreen(driver, "Erro", "AgendaDuploClique");
                sendMessage("Erro em teste [Agenda.Agendamento Profissional.Agendar duplo clique]", e.Message + Funcoes.body.ToString(), Agendar_duplo_Clique.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou até o teste falhar foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "AgendaDuploClique" + "/" + "tempo_de_teste.txt";

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
            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "AgendaDuploClique" + "/" + nome + ".png"));
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
            Agendar_duplo_Clique.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();
            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }


       
    }
    
}


