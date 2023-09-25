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

    

    public class Caixa
    {
        public static ExtentTest test;
        public static ExtentReports extent;
        private string folder;

        public static string name;
        public static string pasta;        public static string email;


        public Caixa(TestFixture fixture)
        {

        }



        [Fact]
        
        public static void AbaCaixa()

        {
            pasta = TestHelpers.pasta;            email = TestHelpers.email;
            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            driver.Manage().Window.Maximize();
            DateTime startTime = DateTime.Now;


            if (Directory.Exists(pasta + "" + "Caixa"))
            {


            }
            else
            {

                Directory.CreateDirectory(pasta + "" + "Caixa");

            }

            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "Caixa", " [Login.Acesso.Acessar URL Clinicorp] - Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "Caixa", " [Login.Acesso.Clicar Botao Entrar] - Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "Caixa", " [Login.Visualizacao Menu Inicial.Acessar Menu Lateral] - Não consegui encontrar os ícones do menu inicial.");

                Funcoes.JanelaFinanceiroClinica(driver, "JanelaFinanceiro", "Caixa", " Não consegui clicar no botão de financeiro.");

                Funcoes.AssercaoJanelaFinanceiroClinica(driver, "JanelaFinanceiro", "Caixa", " Não consegui encontrar todas as opções da janela do financeiro clínica.");

                Funcoes.JanelaCaixa(driver, "JanelaCaixa", "VerClinicasCaixa", "Caixa", "[Financeiro.Visualizacao Aba Caixa.Abrir Aba Caixa] - Encontrei um problema na janela do caixa.");

                Funcoes.AssercaoJanelaCaixa(driver, "AddDinheiro", "Retirar", "Transbordo", "Fechar", "Caixa", "Não consegui ver as opções da janela do caixa.");



                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);
                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");
                string filePath = pasta + "" + "Caixa" + "/" + "tempo_de_teste.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();


            }
            catch (Exception e)
            {

                printScreen(driver, "Erro", "Caixa");
                sendMessage("Erro em teste de visualizar o Caixa", e.Message + Funcoes.body.ToString(), Caixa.name);
                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);
                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");
                string filePath = pasta + "" + "Caixa" + "/" + "tempo_de_teste.txt";

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
            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "Caixa" + "/" + nome + ".png"));
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
            Caixa.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();
            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }


       
    }
    
}


