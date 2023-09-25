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

    public class RelatoriosFinanceiros
    {
        public static ExtentTest test;

        public static ExtentReports extent;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public RelatoriosFinanceiros(TestFixture fixture)
        {

        }

        [Fact]
        
        public static void Relatorios()
        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            if (Directory.Exists(pasta + "" + "RelatoriosFinanceiros"))
            {
                
            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "RelatoriosFinanceiros");
            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "RelatoriosFinanceiros", " [Login.Acesso.Acessar URL Clinicorp] - Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "RelatoriosFinanceiros", " [Login.Acesso.Clicar Botao Entrar] - Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "RelatoriosFinanceiros", " [Login.Visualizacao Menu Inicial.Acessar Menu Lateral] - Não consegui encontrar os ícones do menu inicial.");

                Funcoes.Relatorios(driver, "Relatorios", "RelatoriosFinanceiros", " [Relatorios.Visualizacao Relatorios.Abrir Relatorios Indicadores] - Não consegui as opções em Relatórios Indicadores.");

                Funcoes.RelatoriosFinanceiro(driver, " [Relatorios.Visualizacao Relatorios.Abrir Relatorios Indicadores] - Não consegui as opções em Relatórios Financeiros.");

                Funcoes.AssercaoRelatoriosFinanceiro(driver, "RelatoriosFinanceiro", "RelatoriosFinanceiros", " [Relatorios.Visualizacao Relatorios.Abrir Relatorios Indicadores] - Não consegui as opções em Relatórios Financeiros.");

                Funcoes.RelatorioFinanceiro_ContaCorrente(driver, "RelatoriosFinanceiroContaCorrente", "ClincasContaCorrente", "RelatoriosFinanceiros", " [Relatorios.Conta Corrente.Abrir Aba Conta Corrente] - Não consegui identificar as opções em Relatórios de Conta Corrente.");

                Funcoes.RelatorioFinanceiro_ContasPagar(driver, "RelatoriosFinanceiroContasPagar", "ClinicaContasPagar", "ClassificacaoContasPagar", "CategoriaContasPagar", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba contas a Pagar] - Não identificar consegui as opções em Relatórios de Contas a Pagar.");

                Funcoes.Listar_ContasPagar(driver, "ListarContasPagar", "RelatoriosFinanceiros", "Não consegui listar o relatório de contas a pagar.");

                Funcoes.RelatorioFinanceiro_Caixa(driver, "RelatoriosFinanceiroCaixa", "ClinicasCaixa", "RelatoriosFinanceiros", " [Relatorios.Visualizacao Relatorios.Abrir Aba Caixa] - Não identificar consegui as opções em Relatórios de Caixa.");

                Funcoes.RelatorioFinanceiro_ListarCaixa(driver, "VerAbretura", "VerFechamento", "Listar", "Detalhes", "RelatoriosFinanceiros", "Não consegui listar o relatório de caixa.");

                Funcoes.RelatorioFinanceiro_DRE(driver, "RelatoriosFinanceiroDre", "ClinicasDre", "RelatoriosFinanceiros", " [Relatorios.Visualizacao Relatorios.Abrir Aba DRE] - Não identificar consegui as opções em Relatórios de DRE.");

                Funcoes.Listar_DRE(driver, "ListarDRE", "RelatoriosFinanceiros", "Não consegui listar o relatório de DRE");

                Funcoes.RelatorioFinanceiro_Fluxo(driver, "RelatoriosFinanceiroFluxo", "ClinicasFluxo", "RelatoriosFinanceiros", " [Relatorios.Visualizacao Relatorios.Abrir Aba Fluxo de Caixa] - Não identificar consegui as opções em Relatórios do Fluxo Financeiro.");

                Funcoes.ListarFluxoFinanceiro(driver, "ListarFluxo", "RelatoriosFinanceiros", "Não consegui listar o relatório de Fluxo Financeiro.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "RelatoriosFinanceiros" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "Relatorios");

                sendMessage("Erro em teste de visualizar os Relatórios Financeiros", e.Message + Funcoes.body.ToString(), Todos_Relatorios.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "RelatoriosFinanceiros" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "RelatoriosFinanceiros" + "/" + nome + ".png"));

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
            Todos_Relatorios.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }
    }    
}


