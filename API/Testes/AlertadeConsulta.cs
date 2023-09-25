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

   
    public class AlertaConsulta
    {
        public static ExtentTest test;
        public static ExtentReports extent;

        private string folder;
        public static string name;
        public static string pasta;        public static string email;

        public AlertaConsulta(TestFixture fixture)
        {
            //driver = fixture.Driver;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }

        [Fact]
        
        public static void AlertaDeConsulta()

        {
            pasta = TestHelpers.pasta;            email = TestHelpers.email;
            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;


            if (Directory.Exists(pasta + "" + "AlertaConsulta"))
            {

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "AlertaConsulta");
            }
            try
            {

                Funcoes.PaginaInicial(driver, "PaginaInicial", "AlertaConsulta", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Login", "Senha", "TelaInicial", "AlertaConsulta", " Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "AlertaConsulta", "Não consegui encontrar os ícones do menu inicial.");

                Funcoes.JanelaAgenda(driver, "JanelaAgenda", "AlertaConsulta", "Não consegui clicar no ícone para abrir a agenda.");

                Funcoes.SelecionarClinicaAgenda(driver, "SelecionarClinica", "VerClinicas", "AlertaConsulta", "Não consegui selecionar a clinica na agenda.");

                Funcoes.SelecionarDentistaAgenda(driver, "SelecionarDentista", "AlertaConsulta", "Não consegui selecionar o dentista na agenda.");

                Funcoes.VisualizarAgendaDia(driver, "AgendaDia", "AlertaConsulta", "Não consegui visualizar a agenda por dia.");

                Funcoes.BtnProximoAgenda(driver, "ProximoDia", "AlertaConsulta", "Não consegui clicar na seta do próximo dia");

                Funcoes.HorarioCedo(driver, "DuploClique", "AlertaConsulta", "Não consegui visualizar a tela de novo agendamento.");

                Funcoes.PabloAgendamento(driver, "PabloAgendamento", "AlertaConsulta", "Não consegui pesquisar o paciente na agenda.");

                Funcoes.SelecionarPabloAgendamento(driver, "SelecionarPacienteNovo", "AlertaConsulta", "Não consegui selecionar um paciente existente na agenda.");

                Funcoes.SelecionarAlertas(driver, "SelecionarAlertas", "AlertaConsulta", "Não consegui selecionar as opções de alerta de consulta");

                Funcoes.ConcluirAgendamento(driver, "ConcluirAgendamento", "AlertaConsulta", "Não consegui concluir o agendamento.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");


                string filePath = pasta + "" + "AlertaConsulta" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();


            }
            catch (Exception e)
            {

                printScreen(driver, "Erro", "AlertaConsulta");
                sendMessage("Erro em teste Criar Alerta de Consulta", e.Message + Funcoes.body.ToString(), AlertaConsulta.name);
                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);
                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string outputStr = "O tempo que levou até o teste falhar foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");
                string filePath = pasta + "" + "AlertaConsulta" + "/" + "tempo_de_teste.txt";
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
            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "AlertaConsulta" + "/" + nome + ".png"));
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
            AlertaConsulta.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();
            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }


       
    }
    
}


