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
using Xunit;

namespace Exemplo_2.Testes
{
    [Collection("Chrome Driver")]

    

    public class Financeiro_Clinica
    {
        public static ExtentTest test;

        public static ExtentReports extent;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email; 

        public Financeiro_Clinica(TestFixture fixture)
        {

        }

        [Fact]
        
        public static void FinanceiroClinica()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            if (Directory.Exists(pasta + "" + "FinanceiroClinica"))
            {

            }
            else
            {
               Directory.CreateDirectory(pasta + "" + "FinanceiroClinica");
            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "FinanceiroClinica", " [Login.Acesso.Acessar URL Clinicorp] - Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "FinanceiroClinica", " [Login.Acesso.Clicar Botao Entrar] - Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "FinanceiroClinica", " [Login.Visualizacao Menu Inicial.Acessar Menu Lateral] - Não consegui encontrar os ícones do menu inicial.");

                Funcoes.JanelaFinanceiroClinica(driver, "JanelaFinanceiro", "FinanceiroClinica", " Não consegui clicar no botão de financeiro.");

                Funcoes.AssercaoJanelaFinanceiroClinica(driver, "JanelaFinanceiro", "FinanceiroClinica", " Não consegui encontrar todas as opções da janela do financeiro clínica.");

                Funcoes.JanelaContaCorrente(driver, "JanelaContaCorrente", "VerClinicasCC", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Conta Corrente.Abrir Aba Conta Corrente] - Encontrei um problema na janela da Conta Corrente.");

                Funcoes.JanelaFluxoCaixa(driver, "JanelaContaFluxoDeCaixa", "VerClinicasFluxo", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Fluxo de Caixa.Abrir Aba Fluxo de Caixa] - Encontrei um problema na janela do Fluxo de Caixa.");

                Funcoes.JanelaCaixa(driver, "JanelaCaixa", "VerClinicasCaixa", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Caixa.Abrir Aba Caixa] - Encontrei um problema na janela do caixa.");

                Funcoes.JanelaControleBoletos(driver, "JanelaControleBoletos", "VerClinicasBoletos", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Controle de Boletos.Abrir Aba Controle de Boletos ] - Encontrei um problema na janela do Controle de Boletos.");

                Funcoes.JanelaControleCheque(driver, "JanelaControleCheques", "VerClinicasCheque", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Controle de Cheques.Abrir Aba Controle de Cheques] - Encontrei um problema na janela do Controle de Cheques.");

                Funcoes.JanelaControleCartoes(driver, "JanelaControleCartao", "VerClinicasCartao", "TiposCartao", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Controle de Cartoes.Abrir Aba Controle de Cartoes] - Encontrei um problema na janela do Controle de Cartões.");

                Funcoes.JanelaControlePlanos(driver, "JanelaControlePlanos", "ListaPlanos", "TiposPlanos", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Controle de Planos .Abrir Aba Controle de Planos] - Encontrei um problema na janela do Controle de Planos.");

                Funcoes.JanelaRecebiveisSistema(driver, "JanelaRecebiveisSistema", "VerStatusTipo", "VerFormaPagamento", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Recebiveis Sistema.Abrir Aba Recebiveis Sistema] - Encontrei um problema na janela dos Recebíveis Sistema.");

                Funcoes.JanelaContasAPagar(driver, "JanelaContasAPagar", "ClinicaContas", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Contas a Pagar.Abrir Contas a Pagar] - Encontrei um problema na janela de Contas a Pagar.");

                Funcoes.JanelaContasAReceber(driver, "JanelaContasAReceber", "ClinicaContasAReceber", "FinanceiroClinica", "[Financeiro.Visualizacao Aba Contas a Receber.Abrir Aba Contas a Receber] - Encontrei um problema na janela de Contas a Receber.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "FinanceiroClinica" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "FinanceiroClinica");

                sendMessage("Erro em teste de visualizar todas as abas do Financeiro Clínica", e.Message + Funcoes.body.ToString(), Financeiro_Clinica.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "FinanceiroClinica" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "FinanceiroClinica" + "/" + nome + ".png"));

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
            Financeiro_Clinica.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
       
    }
    
}


