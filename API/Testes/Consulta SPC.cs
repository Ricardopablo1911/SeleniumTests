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
using System.IO;

namespace Exemplo_2.Testes

{
    [Collection("Chrome Driver")]   

    public class Consultar_SPC
    {
        public static ExtentTest test;

        public static ExtentReports extent;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public static string linkSistema;  

        private IWebDriver driver;

        public Consultar_SPC(TestFixture fixture)
        {
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }

        [Fact]
        
        public static void ConsultarSPC()

        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;


            if (Directory.Exists(pasta + "" + "ConsultaSPC"))
            {

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "ConsultaSPC");
            }

            try
            {

                // ************************* LOGIN


                Funcoes.PaginaInicial(driver, "PaginaInicial", "ConsultaSPC", " [Login.Acesso.Acessar URL Clinicorp] - Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "ConsultaSPC", " [Login.Acesso.Clicar Botao Entrar] - Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "ConsultaSPC", " [Login.Visualizacao Menu Inicial.Acessar Menu Lateral] - Não consegui encontrar os ícones do menu inicial.");

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "JanelaPacientes", "ConsultaSPC", " [Pacientes.Visualizacao Aba Pacientes.Abrir Aba Pacientes] - Não consegui abrir a janela de pesquisar pacientes");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Paciente Sem SPC 00805303111", "PesquisaPaciente", "ConsultaSPC", "[Pacientes.Criacao Paciente.Buscar Paciente barra pesquisa] - Não consegui pesquisar o paciente pela janela de pesquisa");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbrirProntuario", "ConsultaSPC", "[Paciente.Visualizacao Prontuario Geral.Abrir prontuario geral] - Não conseugi abrir o prontuário do paciente corretamente.", "Paciente Sem SPC 00805303111");

                Funcoes.BtnSPC(driver, "BotaoSPC", "AssercaoSPC", "ConsultaSPC", "[Paciente.Consulta SPC/Serasa.Consultar CPF] - Não abrir o modal de Consulta ao SPC.");

                Funcoes.InserirCpfSpc(driver, "InserirCPF", "ConsultaSPC", "[Paciente.Consulta SPC/Serasa.Consultar CPF] - Não consegui inserir o CPF para a consulta no SPC.");

                Funcoes.BtnOk(driver, "Consultar", "ConsultaSPC", "[Paciente.Consulta SPC/Serasa.Consultar CPF] - Não consegui confirmar a consulta no SPC.");

                Funcoes.CarregarConsultaSPC(driver, "CarregarConsulta", "Confirmar Reconsulta", "Erro na Consulta", "Confirmar Reconsulta Apos Erro", "BtnSpc Apos erro", "InserirCpf Apos Erro", "ConsultaSPC", "[Paciente.Consulta SPC/Serasa.Consultar CPF] - Não consegui concluir a consulta SPC/Serasa.");

                Funcoes.ConsultaSPC(driver, "Consultado", "ConsultaSPC", "[Paciente.Consulta SPC/Serasa.Consultar CPF] - As informações de consulta não me parecem corretas.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ConsultaSPC" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();



            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "ConsultaSPC");

                sendMessage("Erro em teste [Paciente.Consulta SPC/Serasa.Consultar CPF]", e.Message + Funcoes.body.ToString(), Consultar_SPC.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ConsultaSPC" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "ConsultaSPC" + "/" + nome + ".png"));

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

            Consultar_SPC.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }


       
    }
    
}


