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

    public class FichaClinica
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public FichaClinica(TestFixture fixture)
        {
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();
        }
        [Fact]

        public static void FichaClinicaManual()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "FichaClinica"))
            {

            }
            else
            {

                Directory.CreateDirectory(pasta + "" + "FichaClinica");

            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "FichaClinica", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "FichaClinica", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "FichaClinica", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Ficha Clinica Manual", "PesquisaPacientes", "FichaClinica", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "FichaClinica", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Ficha Clinica Manual");

                Funcoes.AssercaoPlanoEFicha(driver, "AssercaoPlanoEFicha", "FichaClinica", "[Paciente.Visualizacao Aba Plano Ficha.Abrir Aba Plano e Ficha ] -  Não consegui identificar os elementos da aba de Plano e Ficha Clínica.");

                Funcoes.BtnNovo(driver, "NovaFicha", "FichaClinica", "[Paciente.Ficha Clinica.Adicionar Novo Item Manualmente] - Não consegui adicionar nova ficha manual.");

                Funcoes.PreencherFicha(driver, "Dentição", "Dente", "Procedimento", "Profissional", "FichaPreenchida", "FichaClinica", "Não consegui inserir os dados na ficha clínica.");

                Funcoes.BtnOk(driver, "ConfirmaFicha", "FichaClinica", "Não consegui confirma a criação de uma nova ficha clínica manual.");

                Funcoes.carregamento(driver, "Carregamento", "FichaClinica", "");

                Funcoes.AssercaoNovaFicha(driver, "FichaCriada", "FichaClinica", "As informações da nova ficha não condizem com o que foi preenchido.");

                Funcoes.ExcluirNovaFicha(driver, "ExcluirFicha", "FichaClinica", "Não consegui clicar no botão para excluir a ficha clínica.");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "FichaClinica", "Não consegui dar o Ok para excluir a ficha clínica.");

                Funcoes.carregamento(driver, "Carregando", "FichaClinica", "");

                Funcoes.FichaExcluida(driver, "Excluida", "FichaClinica", "Ocorreu um problema no processo de excluir a ficha clínica manual.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "FichaClinica" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();
            
            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "FichaClinica");

                sendMessage("Erro em teste [Ficha_Clínica_Manual]", e.Message + Funcoes.body.ToString(), FichaClinica.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "FichaClinica" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "FichaClinica" + "/" + nome + ".png"));
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
            FichaClinica.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }
}


