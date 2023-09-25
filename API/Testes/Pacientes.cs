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

    public class Pacientes
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public Pacientes(TestFixture fixture)
        {            
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();
        }

        [Fact]

        public static void AbrirTelaProntuarioPacientes()
        {

            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "chekoutUnificado"))
            {
                
            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "chekoutUnificado");
            }
            try
            {
                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "chekoutUnificado", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "chekoutUnificado", " Não consegui efetuar o login no sistema.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.JanelaPacientes(driver, "BtnPacientes", "Pacientes", "chekoutUnificado", " Não consegui abrir a tela de pacientes.");

                Funcoes.PesquisarNomeJanelaPacientes(driver, "Pablo Automação", "PesquisaPacientes", "chekoutUnificado", " Não consegui encontrar o paciente na pesquisa.");

                Funcoes.AbrirProntuarioPesquisa(driver, "AbreProntuario", "chekoutUnificado", " Não consegui abrir o prontuário do paciente pela janela de Pacientes.", "Pablo Automação");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos_Credito", "BtnNovoOrcamento_Credito", "chekoutUnificado", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento_Credito", "chekoutUnificado", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas_Credito", "DentistaSelecionado_Credito", "chekoutUnificado", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas_Credito", "ClinicaSelecionada_Credito", "chekoutUnificado", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas_Credito", "TabelaSelecionada_Credito", "chekoutUnificado", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento_Credito", "ProcedimentoTesteDatadog_Credito", "ProcedimentoSelecionado_Credito", "ProcedimentoAdicionado_Credito", "chekoutUnificado", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao_Credito", "OrcamentoAprovado_Credito", "chekoutUnificado", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "chekoutUnificado", "");

                // ***************************** FINANCEIRO_CREDITO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Credito", "chekoutUnificado", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout_credito", "Assercao_credito", "chekoutUnificado", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Credito", "chekoutUnificado", " Não consegui selecionar a forma de pagamento", "'Cartão de Crédito'");

                Funcoes.BtnTipoCheckout(driver, "Tipo_Credito", "chekoutUnificado", " Não consegui expandir a seleção de tipos de pagamento.");

                Funcoes.selecionarCartaoExterno(driver, "CartaoExterno_Credito", "chekoutUnificado", " Não consegui selecionar a opção de cartão externo.");

                IWebElement Ok = driver.FindElement(By.XPath("/html/body/span/div/div[2]/div/div[3]/div/button[2]/span"));

                js.ExecuteScript("arguments[0].scrollIntoView();", Ok);

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Credito", "chekoutUnificado", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Credito", "chekoutUnificado", "cartão de crédito", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Credito", "CheckoutRealizado_Credito", "chekoutUnificado", " Não consegui finalizar o processo de Checkout.");

                Funcoes.Btn3Pontos(driver, "verFinanceiro_Credito", "VerOpcoes_Credito", "chekoutUnificado", " Não consegui clicar nos 3 pontinhos para visualizar as opções");

                Funcoes.Opcao3Pontos(driver, "AntesClick_Credito", "ClickParcelas_Credito", "chekoutUnificado", "'Parcelas'", "Não consegui clicar em Parcelas");

                Funcoes.Parcelas(driver, "VerParcelas_Credito", "ConfirmarRecebimento_Credito", "chekoutUnificado", "'file_download'", "Não consegui clicar no botão de confirmar recebimento.");

                Funcoes.BtnOk(driver, "ConfirmaRecebimento_Credito", "chekoutUnificado", " Não consegui clicar no botão de Ok para confirmar o recebimento.");

                Funcoes.PagamentoRecebido(driver, "PagamentoRecebido_Credito", "chekoutUnificado", "Não consegui encontrar o Recebido na parcela.");

                Funcoes.BtnFechar(driver, "FecharParcelas_Credito", "chekoutUnificado", "Não consegui fechar a janela Parcelas.");

                // ***************************** CRIAR ORCAMENTO_DEBITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos_Debito", "BtnNovoOrcamento_Debito", "chekoutUnificado", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento_Debito", "chekoutUnificado", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas_Debito", "DentistaSelecionado_Debito", "chekoutUnificado", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas_Debito", "ClinicaSelecionada_Debito", "chekoutUnificado", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas_Debito", "TabelaSelecionada_Debito", "chekoutUnificado", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento_Debito", "ProcedimentoTesteDatadog2", "ProcedimentoSelecionado2", "ProcedimentoAdicionado2", "chekoutUnificado", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao_Debito", "OrcamentoAprovado_Debito", "chekoutUnificado", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "chekoutUnificado", "");

                // ***************************** FINANCEIRO_DEBITO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Debito", "chekoutUnificado", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout_debito", "Assercao_debito", "chekoutUnificado", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Debito", "chekoutUnificado", " Não consegui selecionar a forma de pagamento", "'Cartão de Débito'");

                Funcoes.BtnTipoCheckout(driver, "Tipo_Debito", "chekoutUnificado", " Não consegui expandir a seleção de tipos de pagamento.");

                Funcoes.selecionarCartaoExterno(driver, "CartaoExterno_Debito", "chekoutUnificado", " Não consegui selecionar a opção de cartão externo.");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Debito", "chekoutUnificado", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Debito", "chekoutUnificado", "cartão de débito", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Debito", "CheckoutRealizado_Debito", "chekoutUnificado", " Não consegui finalizar o processo de Checkout.");

                Funcoes.Btn3Pontos(driver, "verFinanceiro_Debito", "VerOpcoes_Debito", "chekoutUnificado", " Não consegui clicar nos 3 pontinhos para visualizar as opções");

                Funcoes.Opcao3Pontos(driver, "AntesClick_Debito", "ClickParcelas_Debito", "chekoutUnificado", "'Parcelas'", "Não consegui clicar em Parcelas");

                Funcoes.Parcelas(driver, "VerParcelas_Debito", "ConfirmarRecebimento_Debito", "chekoutUnificado", "'file_download'", "Não consegui clicar no botão de confirmar recebimento.");

                Funcoes.BtnOk(driver, "ConfirmaRecebimento_Debito", "chekoutUnificado", " Não consegui clicar no botão de Ok para confirmar o recebimento.");

                Funcoes.PagamentoRecebido(driver, "PagamentoRecebido_Debito", "chekoutUnificado", "Não consegui encontrar o Recebido na parcela.");

                Funcoes.BtnFechar(driver, "FecharParcelas_Debito", "chekoutUnificado", "Não consegui fechar a janela Parcelas.");

                // ***************************** CRIAR ORCAMENTO_CHEQUE

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos_Cheque", "BtnNovoOrcamento_Cheque", "chekoutUnificado", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento_Cheque", "chekoutUnificado", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas_Cheque", "DentistaSelecionado_Cheque", "chekoutUnificado", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas_Cheque", "ClinicaSelecionada_Cheque", "chekoutUnificado", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas_Cheque", "TabelaSelecionada_Cheque", "chekoutUnificado", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento_Cheque", "ProcedimentoTesteDatadog_Cheque", "ProcedimentoSelecionado_Cheque", "ProcedimentoAdicionado_Cheque", "chekoutUnificado", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao_Cheque", "OrcamentoAprovado_Cheque", "chekoutUnificado", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "chekoutUnificado", "");

                // ***************************** FINANCEIRO_CHEQUE

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Cheque", "chekoutUnificado", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout_cheque", "Assercao_cheque", "chekoutUnificado", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Cheque", "chekoutUnificado", " Não consegui selecionar a forma de pagamento", "'Cheque'");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Cheque", "chekoutUnificado", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Cheque", "chekoutUnificado", "cheque", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Cheque", "CheckoutRealizado_Cheque", "chekoutUnificado", " Não consegui finalizar o processo de Checkout.");

                Funcoes.Btn3Pontos(driver, "verFinanceiro_Cheque", "VerOpcoes_Cheque", "chekoutUnificado", " Não consegui clicar nos 3 pontinhos para visualizar as opções");

                Funcoes.Opcao3Pontos(driver, "AntesClick_Cheque", "ClickParcelas_Cheque", "chekoutUnificado", "'Parcelas'", "Não consegui clicar em Parcelas");

                Funcoes.Parcelas(driver, "VerParcelas_Cheque", "ConfirmarRecebimento_Cheque", "chekoutUnificado", "'file_download'", "Não consegui clicar no botão de confirmar recebimento.");

                Funcoes.BtnOk(driver, "ConfirmaRecebimento_Cheque", "chekoutUnificado", " Não consegui clicar no botão de Ok para confirmar o recebimento.");

                Funcoes.PagamentoRecebido(driver, "PagamentoRecebido_Cheque", "chekoutUnificado", "Não consegui encontrar o Recebido na parcela.");

                Funcoes.BtnFechar(driver, "FecharParcelas_Cheque", "chekoutUnificado", "Não consegui fechar a janela Parcelas.");

                // ***************************** CRIAR ORCAMENTO_DINHEIRO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos_Dinheiro", "BtnNovoOrcamento_Dinheiro", "chekoutUnificado", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento_Dinheiro", "chekoutUnificado", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas_Dinheiro", "DentistaSelecionado_Dinheiro", "chekoutUnificado", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas_Dinheiro", "ClinicaSelecionada_Dinheiro", "chekoutUnificado", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas_Dinheiro", "TabelaSelecionada_Dinheiro", "chekoutUnificado", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento_Dinheiro", "ProcedimentoTesteDatadog_Dinheiro", "ProcedimentoSelecionado_Dinheiro", "ProcedimentoAdicionado_Dinheiro", "chekoutUnificado", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao_Dinheiro", "OrcamentoAprovado_Dinheiro", "chekoutUnificado", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "chekoutUnificado", "");

                // ***************************** FINANCEIRO_DINHEIRO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro", "chekoutUnificado", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout_dinheiro", "Assercao_dinheiro", "chekoutUnificado", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Dinheiro", "chekoutUnificado", " Não consegui selecionar a forma de pagamento", "'Dinheiro'");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Dinheiro", "chekoutUnificado", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Dinheiro", "chekoutUnificado", "dinheiro", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Dinheiro", "CheckoutRealizado_Dinheiro", "chekoutUnificado", " Não consegui finalizar o processo de Checkout.");

                Funcoes.Btn3Pontos(driver, "verFinanceiro_Dinheiro", "VerOpcoes_Dinheiro", "chekoutUnificado", " Não consegui clicar nos 3 pontinhos para visualizar as opções");

                Funcoes.Opcao3Pontos(driver, "AntesClick_Dinheiro", "ClickParcelas_Dinheiro", "chekoutUnificado", "'Parcelas'", "Não consegui clicar em Parcelas");

                //Funcoes.PagamentoRecebido(driver, "PagamentoRecebido_Dinheiro", "chekoutUnificado", "Não consegui encontrar o Recebido na parcela.");

                Funcoes.BtnFechar(driver, "FecharParcelas_Dinheiro", "chekoutUnificado", "Não consegui fechar a janela Parcelas.");

                // ***************************** CRIAR ORCAMENTO_TRANSFERENCIA

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos_Transferencia", "BtnNovoOrcamento_Transferencia", "chekoutUnificado", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento_Transferencia", "chekoutUnificado", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas_Transferencia", "DentistaSelecionado_Transferencia", "chekoutUnificado", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas_Transferencia", "ClinicaSelecionada_Transferencia", "chekoutUnificado", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas_Transferencia", "TabelaSelecionada_Transferencia", "chekoutUnificado", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento_Transferencia", "ProcedimentoTesteDatadog_Transferencia", "ProcedimentoSelecionado_Transferencia", "ProcedimentoAdicionado_Transferencia", "chekoutUnificado", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao_Transferencia", "OrcamentoAprovado_Transferencia", "chekoutUnificado", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "chekoutUnificado", "");

                // ***************************** FINANCEIRO_TRANSFERENCIA

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Transferencia", "chekoutUnificado", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout_transferencia", "Assercao_transferencia", "chekoutUnificado", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Transferencia", "chekoutUnificado", " Não consegui selecionar a forma de pagamento", "'Transferência'");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Transferencia", "chekoutUnificado", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Transferencia", "chekoutUnificado", "transferência", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Transferencia", "CheckoutRealizado_Transferencia", "chekoutUnificado", " Não consegui finalizar o processo de Checkout.");

                Funcoes.Btn3Pontos(driver, "verFinanceiro_Transferencia", "VerOpcoes_Transferencia", "chekoutUnificado", " Não consegui clicar nos 3 pontinhos para visualizar as opções");

                Funcoes.Opcao3Pontos(driver, "AntesClick_Transferencia", "ClickParcelas_Transferencia", "chekoutUnificado", "'Parcelas'", "Não consegui clicar em Parcelas");

                Funcoes.Parcelas(driver, "VerParcelas_Transferencia", "ConfirmarRecebimento_Transferencia", "chekoutUnificado", "'file_download'", "Não consegui clicar no botão de confirmar recebimento.");

                Funcoes.BtnOk(driver, "ConfirmaRecebimento_Transferencia", "chekoutUnificado", " Não consegui clicar no botão de Ok para confirmar o recebimento.");

                Funcoes.PagamentoRecebido(driver, "PagamentoRecebido_Transferencia", "chekoutUnificado", "Não consegui encontrar o Recebido na parcela.");

                Funcoes.BtnFechar(driver, "FecharParcelas_Transferencia", "chekoutUnificado", "Não consegui fechar a janela Parcelas.");

                // ***************************** CRIAR ORCAMENTO_BOLETO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos_Boleto", "BtnNovoOrcamento_Boleto", "chekoutUnificado", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento_Boleto", "chekoutUnificado", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Pablo Souza", "VisualizarDentistas_Boleto", "DentistaSelecionado_Boleto", "chekoutUnificado", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas_Boleto", "ClinicaSelecionada_Boleto", "chekoutUnificado", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas_Boleto", "TabelaSelecionada_Boleto", "chekoutUnificado", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento_Boleto", "ProcedimentoTesteDatadog_Boleto", "ProcedimentoSelecionado_Boleto", "ProcedimentoAdicionado_Boleto", "chekoutUnificado", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao_Boleto", "OrcamentoAprovado_Boleto", "chekoutUnificado", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "chekoutUnificado", "");

                // ***************************** FINANCEIRO_BOLETO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Boleto", "chekoutUnificado", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout_boleto", "Assercao_boleto", "chekoutUnificado", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Boleto", "chekoutUnificado", " Não consegui selecionar a forma de pagamento", "'Boleto'");

                Funcoes.BtnTipoCheckout(driver, "Tipo_Boleto", "chekoutUnificado", " Não consegui expandir a seleção de tipos de pagamento.");

                Funcoes.selecionaTipoBoletoSistema(driver, "BoletoSistema", "chekoutUnificado", "Não consegui clicar selecionar a opção de Boleto Sistema.");

                Funcoes.EnderecoBoleto(driver, "EnderecoBoleto", "chekoutUnificado", "89257-647", "Rua Manoel Tomaz de Araujo Junior", "350", "Não consegui inserir o endereço no boleto sistema.");

                Funcoes.EmailBoleto(driver, "EmailBoleto", "chekoutUnificado", "Não consegui inserir o e-mail para emitir boleto sistema.");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Boleto", "chekoutUnificado", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Boleto", "chekoutUnificado", "boleto", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckoutBoletoSistema(driver, "RealizandoCheckout_Boleto", "CheckoutRealizado_Boleto", "chekoutUnificado", " Não consegui finalizar o processo de Checkout.");

                Funcoes.EnviarBoletoEmail(driver, "Btn", "EnviarEmail", "chekoutUnificado", "Não consegui enviar o boleto via e-mail");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "chekoutUnificado" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();

            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "chekoutUnificado");

                sendMessage("Erro em teste de Checkout Unificado", e.Message + Funcoes.body.ToString(), Pacientes.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "chekoutUnificado" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "chekoutUnificado" + "/" + nome + ".png"));
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
            Pacientes.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }

    }
    
}


