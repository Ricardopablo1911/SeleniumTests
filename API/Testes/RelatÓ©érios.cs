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

    public class Todos_Relatorios
    {
        public static ExtentTest test;

        public static ExtentReports extent;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public static string linkSistema;

        public Todos_Relatorios(TestFixture fixture)
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

            if (Directory.Exists(pasta + "" + "Relatorios"))
            {
                
            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "Relatorios");
            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "Relatorios", " [Login.Acesso.Acessar URL Clinicorp] - Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "Relatorios", " [Login.Acesso.Clicar Botao Entrar] - Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "Relatorios", " [Login.Visualizacao Menu Inicial.Acessar Menu Lateral] - Não consegui encontrar os ícones do menu inicial.");

                Funcoes.Relatorios(driver, "Relatorios", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Relatorios Indicadores] - Não consegui as opções em Relatórios Indicadores.");

                Funcoes.RelatoriosFinanceiro(driver, " [Relatorios.Visualizacao Relatorios.Abrir Relatorios Indicadores] - Não consegui as opções em Relatórios Financeiros.");

                Funcoes.AssercaoRelatoriosFinanceiro(driver, "RelatoriosFinanceiro", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Relatorios Indicadores] - Não consegui as opções em Relatórios Financeiros.");

                Funcoes.RelatorioFinanceiro_ContaCorrente(driver, "RelatoriosFinanceiroContaCorrente", "ClincasContaCorrente", "Relatorios", " [Relatorios.Conta Corrente.Abrir Aba Conta Corrente] - Não consegui identificar as opções em Relatórios de Conta Corrente.");

                Funcoes.RelatorioFinanceiro_Balancete(driver, "RelatoriosFinanceiroBalancete", "ClincasContaBalancete", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba Balancete] - Não consegui identificar as opções em Relatórios de Balancete.");

                Funcoes.RelatorioFinanceiro_TodosLancamentos(driver, "RelatoriosFinanceiroTodosLancamentos", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba Todos Lancamentos] - Não consegui identificar as opções em Relatórios de Todos os Lançamentos.");

                Funcoes.RelatorioFinanceiro_Recibos(driver, "RelatoriosFinanceiroRecibos", "ClinicaRecibos", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba recibos] - Não consegui identificar as opções em Relatórios de Recibos.");

                Funcoes.RelatorioFinanceiro_ContasPagar(driver, "RelatoriosFinanceiroContasPagar", "ClinicaContasPagar", "ClassificacaoContasPagar", "CategoriaContasPagar", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba contas a Pagar] - Não consegui identificar as opções em Relatórios de Contas a Pagar.");

                Funcoes.RelatorioFinanceiro_PagamentosComissoes(driver, "RelatoriosFinanceiroTodosLancamentos", "Profissionais", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba Todos Lancamentos] - Não identificar consegui as opções em Relatórios de Todos os Lancamentos.");

                Funcoes.RelatorioFinanceiro_NfExternas(driver, "RelatoriosFinanceiroNfExternas", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba Nota Fiscal] - Não identificar consegui as opções em Relatórios de Nota Fiscal.");

                Funcoes.RelatorioFinanceiro_Caixa(driver, "RelatoriosFinanceiroCaixa", "ClinicasCaixa", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba Caixa] - Não identificar consegui as opções em Relatórios de Caixa.");

                Funcoes.RelatorioFinanceiro_DRE(driver, "RelatoriosFinanceiroDre", "ClinicasDre", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba DRE] - Não identificar consegui as opções em Relatórios de DRE.");

                Funcoes.RelatorioFinanceiro_Fluxo(driver, "RelatoriosFinanceiroFluxo", "ClinicasFluxo", "Relatorios", " [Relatorios.Visualizacao Relatorios.Abrir Aba Fluxo de Caixa] - Não identificar consegui as opções em Relatórios do Fluxo Financeiro.");

                Funcoes.RelatoriosFinanceiro(driver, " [Relatorios.Visualizacao Relatorios.Abrir Relatorios Indicadores] - Não consegui as opções em Relatórios Financeiros.");

                Funcoes.RelatoriosEstoque(driver, " [Relatorios.Visualisacao Relatorios Estoque.Abrir Aba Controle Estoque] - Não consegui expandir Relatório de Estoque.");

                Funcoes.AssercaoRelatoriosEstoque(driver, "RelatorioEstoque", "Relatorios", " [Relatorios.Visualisacao Relatorios Estoque.Abrir Aba Controle Estoque] - Não consegui encontrar a opção de Relatório de estoque.");

                Funcoes.Relatorio_Estoque(driver, "VerRelatorioEstoque", "Relatorios", " [Relatorios.Visualisacao Relatorios Estoque.Abrir Aba Controle Estoque] - Não consegui ver as informações de Relatório de estoque.");

                Funcoes.RelatoriosEstoque(driver, " [Relatorios.Visualisacao Relatorios Estoque.Abrir Aba Controle Estoque] - Não consegui retrair as opções dos Relatório de Estoque.");

                Funcoes.RelatoriosPacientes(driver, "VerRelatorioEstoque", "Relatorios", "Não consegui expandir as opções dos relatórios de Pacientes.");

                Funcoes.AssercaoRelatoriosPacientes(driver, "RelatorioPacientes", "Relatorios", "Não consegui encontrar as opções de relatórios de pacientes.");

                Funcoes.RelatorioPacientes_CobrancaPagamento(driver, "RelatorioCobrancaPagamentos", "ClinicasCobrancaPagamentos", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Cobrancas e Pagamentos] Não consegui encontrar as opções do relatório de Cobrança e Pagamentos.");

                Funcoes.RelatorioPacientes_PagamentosParciais(driver, "PagamentosParciais", "Relatorios", "[Relatorios.Visualizacao Relatorios.Abrir Aba Pagamento Parciais] Não consegui encontrar as opções do relatório de Pagamentos Parciais.");

                Funcoes.RelatorioPacientes_Aniversariantes(driver, "Aniversariantes", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Aniversariantes] Não consegui encontrar as opções de relatório de aniversariantes.");

                Funcoes.RelatorioPacientes_Localizacao(driver, "Localização", "Relatorios", "[Relatorios.Visualizacao Relatorios.Abrir Aba Localizacao] Não consegui encontrar as informações do relatório de Localização.");

                Funcoes.RelatorioPacientes_FaixaEtaria(driver, "FaixaEtaria", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Faixa Etaria] Não consegui encontrar as informações do relatório de Faixa Etária.");

                Funcoes.RelatorioPacientes_PlanosConvenios(driver, "Planosconvenios", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Planos/Convenios] Não consegui encontrar as informações do relatório de Planos e Convenios.");

                Funcoes.RelatorioPacientes_Orcamentos(driver, "Orcamentos", "ClinicaOrcamentos", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Orcamento] Não consegui encontrar as informações do relatório de Orçamentos.");

                Funcoes.RelatorioPacientes_OportunidadesConversao(driver, "OportunidadesConversao", "Tipo", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Oportunidades e Conversao] Não consegui encontrar as informações do relatório de Oportunidades e Conversão.");

                Funcoes.RelatorioPacientes_Indicacoes(driver, "Indicacoes", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Indicacoes] Não consegui encontrar as informações do relatório de Indicações.");

                Funcoes.RelatorioPacientes_ConsultasSPC(driver, "SPC", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Consultas SPC/Serasa] Não consegui encontrar as informações do relatório de consultas do SPC/SERASA.");

                Funcoes.RelatorioPacientes_UltimosAgendamentos(driver, "UltimoAgendamento", "ClinicasUltimoAgendamento", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Ultimo Agendamento] Não consegui encontrar as informações do relatório de Último Agendamento.");

                Funcoes.RelatorioPacientes_PlanosRecorrentes(driver, "PlanosRecorrentes", "PlanoRecorrente", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Planos Recorrentes] Não consegui encontrar as informações do relatório de Planos Recorrentes.");

                Funcoes.RelatorioPacientes_RegistrosSPC(driver, "RegistrosSPC", "StatusRegistro", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Registros SPC/Serasa] Não consegui encontrar as informações do relatório de Registros SPC/SERASA.");

                Funcoes.RelatorioPacientes_AlertasReguaCobranca(driver, "Alerta", "TipoAlerta", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Alertas Regua de Cobranca] Não consegui encontrar as informações do relatório de Alertas Régua de Cobrança.");

                Funcoes.RelatorioPacientes_ExamesRadiologicos(driver, "ExamesRadiologicos", "ClinicasExames", "Relatorios", "[Relatorios.Visualizacao Relatorios Pacientes.Abrir Aba Exames Radiologicos] Não consegui encontrar as informações do relatório de Exames Radiológicos.");

                Funcoes.RelatoriosPacientes(driver, "RetrairPacientes", "Relatorios", "Não consegui retrair as opções dos relatórios de Pacientes.");

                Funcoes.RelatoriosAgendamentos(driver, "ExpandirAgendamentos", "Relatorios", "Não consegui expandir as opções dos relatórios de Agendamentos.");

                Funcoes.RelatorioAgendamentos_Geral(driver, "AgendamentosGeral", "ClinicaAgendamentosGeral", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Geral] Não consegui encontrar as informações do Relatório de Agendamento - Geral.");

                Funcoes.RelatorioAgendamentos_Faltas(driver, "AgendamentosFaltas", "ClinicaAgendamentosFaltas", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Faltas] Não consegui encontrar as informações do Relatório de Agendamento - Faltas.");

                Funcoes.RelatorioAgendamentos_Desmarcacoes(driver, "AgendamentoDesmarcacoes", "ClinicaAgendamentosDesmarcacoes", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Desmarcacoes] Não consegui encontrar as informações do Relatório de Agendamento - Desmarcações.");

                Funcoes.RelatorioAgendamentos_PrimeiraConsulta(driver, "AgendamentoPrimeiraConsulta", "ClinicaAgendamentosPrimeiraConsulta", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Primeira Consulta] Não consegui encontrar as informações do Relatório de Agendamento - Primeira Consulta.");

                Funcoes.RelatorioAgendamentos_ConversoesSemAgendamento(driver, "AgendamentoConversoesSem", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Conversoes Sem Agendamento] Não consegui encontrar as informações do Relatório de Agendamento - Conversões sem Agendamento.");

                Funcoes.RelatorioAgendamentos_AlertaRetorno(driver, "AgendamentoAlertasRetorno", "ClinicaAgendamentosAlertaRetorno", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Alerta de Retornos] Não consegui encontrar as informações do Relatório de Agendamento - Alerta de Retorno.");

                Funcoes.RelatorioAgendamentos_Categoria(driver, "AgendamentoCategoria", "ClinicaAgendamentosCategoria", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Categoria] Não consegui encontrar as informações do Relatório de Agendamento - Categoria.");

                Funcoes.RelatorioAgendamentos_Marcadores(driver, "AgendamentoMarcadores", "ClinicaAgendamentosMarcadores", "Relatorios", "[Relatorios.Visualizacao Relatorios Agendamento.Abrir Aba Marcadores] Não consegui encontrar as informações do Relatório de Agendamento - Marcadores.");

                Funcoes.RelatoriosAgendamentos(driver, "RetrairAgendamentos", "Relatorios", "Não consegui Retrair as opções dos relatórios de Agendamentos.");

                Funcoes.RelatoriosTratamentos(driver, "ExpandirTratamentos", "Relatorios", "Não consegui Expandir as opções dos relatórios de Tratamentos.");

                Funcoes.RelatoriosTratamentos_Faturamento(driver, "TratamentoFaturamento", "ClinicaTratamentoFaturamento", "Relatorios", "[Relatorios.Visualizacao Relatorios Tratamento.Abrir Aba Faturamento] Não consegui encontrar as informações do Relatório de Tratamentos - Faturamento.");

                Funcoes.RelatoriosTratamentos_TratamentosOrtodonticos(driver, "TratamentoOrtodonticos", "Relatorios", "[Relatorios.Visualizacao Relatorios Tratamento.Abrir Aba Tratamentos Ortodonticos] Não consegui encontrar as informações do Relatório de Tratamentos - Tratamentos Ortodônticos.");

                Funcoes.RelatoriosTratamentos_ImplantesTratamento(driver, "TratamentoImplantes", "Relatorios", "[Relatorios.Visualizar Relatorios Tratamento.Abrir Aba Implantes em Tratamento] Não consegui encontrar as informações do Relatório de Tratamentos - Implantes em Tratamento.");

                Funcoes.RelatoriosTratamentos_EstatisticaImplantes(driver, "TratamentoEstatisticaImplantes", "Relatorios", "[Relatorios.Visualizar Relatorios Tratamento.Abrir Aba Estatistica de Implantes] Não consegui encontrar as informações do Relatório de Tratamentos - Estatística de Implantes.");

                Funcoes.RelatoriosTratamentos_ControleOrtodontia(driver, "TratamentoControleOrtodontia", "Relatorios", "[Relatorios.Visualizar Relatorios Tratamento.Abrir Aba Controle de Otodentia] Não consegui encontrar as informações do Relatório de Tratamentos - Controle de Ortodontia.");

                Funcoes.RelatoriosTratamentos_ControleProtetico(driver, "TratamentoControleProtetico", "Relatorios", "[Relatorios.Visualizar Relatorios Tratamento.Abrir Aba Controle Protetico] Não consegui encontrar as informações do Relatório de Tratamentos - Controle de Protetico.");

                Funcoes.RelatoriosTratamentos(driver, "RetrairTratamentos", "Relatorios", "Não consegui Retrair as opções dos relatórios de Tratamentos.");

                Funcoes.RelatoriosGeral(driver, "ExpandirGeral", "Relatorios", "Não consegui Retrair as opções dos relatórios Gerais.");

                Funcoes.RelatoriosGerais_AcoesUsuarios(driver, "GeralAcoes", "Relatorios", "[Relatorios.Visualizar Relatorios Geral.Abrir Aba Acoes Usuarios] Não consegui encontrar as informações do Relatórios Gerais - Ações Usuários.");

                Funcoes.RelatoriosGerais_AcoesUsuarios(driver, "GeralAcoes", "Relatorios", "[Relatorios.Visualizar Relatorios Geral.Abrir Aba Acoes Usuarios] Não consegui encontrar as informações do Relatórios Gerais - Ações Usuários.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "Relatorios" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "Relatorios");

                sendMessage("Erro em teste de visualizar todos os Relatórios", e.Message + Funcoes.body.ToString(), Todos_Relatorios.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "Relatorios" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "Relatorios" + "/" + nome + ".png"));

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


