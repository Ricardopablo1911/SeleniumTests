using Xunit;
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

namespace Exemplo_2.Testes

{
    [Collection("Chrome Driver")]

    

    public class ComissaoPagamento
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public ComissaoPagamento(TestFixture fixture)
        {
            
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();

        }

        [Fact]

        public static void ComissaoRecebimento()

        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (Directory.Exists(pasta + "" + "ComissaoPagamento"))
            {
                

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "ComissaoPagamento");
            }
            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "ComissaoPagamento", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "ComissaoPagamento", " Não consegui efetuar o login no sistema.");

                // ************************ PROFISSIONAIS

                Funcoes.JanelaProfissionais(driver, "Profissional", "ComissaoPagamento", " Não consegui abrir a tela de Profissionais.");

                Funcoes.NovoProfissional(driver, "NovoProfissional", "DadosPreenchidos", "ComissaoPagamento", " Não consegui preencher os dados para criar um novo profissional.");

                Funcoes.BtnOk(driver, "ConfirmarProfissional", "ComissaoPagamento", "Não consegui confirmar a criação de um novo profissional.");

                Funcoes.carregamento(driver, "loading", "ComissaoPagamento", "");

                Funcoes.AssercaoProfissionalCriado(driver, "ProfissionalCriado", "ComissaoPagamento", "Não consegui ver um novo profissional.");

                Funcoes.ConfiguracaoComissao(driver, "ConfiguracaoComissao", "NovaConfiguracao", "DuracaoDeterminada", "Calendario", "CalendarioOk", "DuracaoIndeterminada", "ValorFixo", "Porcentagem", "ComissaoPlano", "ComissaoPagamento", "Não consegui configurar a comissão do novo profissional.");

                Funcoes.BtnOk(driver, "ConfirmaConfiguracaoComissao", "ComissaoPagamento", "Não consegui confirmar a configuracao de comissão");

                Funcoes.BtnOkTypeLast(driver, "SalvarComissao", "ComissaoPagamento", "Não consegui salvar a configuração da comissão");

                Funcoes.AssercaoConfiguracaoComissao(driver, "ComissaoConfigurada", "ComissaoPagamento", "As informações da configuração de comissão não estão corretas");

                // ******************************** PESQUISA PACIENTE

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Pablo Comissão", "BuscaPaciente", "ComissaoPagamento", "Não consegui buscar paciente na barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Pablo Comissão", "PabloComissao", "ComissaoPagamento", "Não consegui abrir o prontuário pela barra de pesquisa.");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "ComissaoPagamento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "ComissaoPagamento", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Profissional Comissão", "VisualizarDentistas", "DentistaSelecionado", "ComissaoPagamento", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas", "ClinicaSelecionada", "ComissaoPagamento", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas", "TabelaSelecionada", "ComissaoPagamento", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "ComissaoPagamento", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "ComissaoPagamento", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "ComissaoPagamento", "");

                // ***************************** FINANCEIRO_CREDITO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro", "ComissaoPagamento", " Não consegui abrir o financeiro do paciente.");

                Funcoes.GlobalCheckout(driver, "BtnCheckout", "Assercao", "ComissaoPagamento", " Não consegui clicar no último botão de checkout.");

                Funcoes.FormaDePagamento(driver, "FormaDePagamento_Dinheiro", "ComissaoPagamento", " Não consegui selecionar a forma de pagamento", "'Dinheiro'");

                Funcoes.BtnOk(driver, "ConfirmarCheckout_Dinheiro", "ComissaoPagamento", " Não consegui clicar no botão de Ok para realizar o checkout.");

                Funcoes.AssercaoPagamento(driver, "VerInformacoes_Dinheiro", "ComissaoPagamento", "dinheiro", "1.000,00", " Não consegui encontrar a forma de pagamento ou valor correto.");

                Funcoes.ConfirmaCheckout(driver, "RealizandoCheckout_Dinheiro", "CheckoutRealizado_Dinheiro", "ComissaoPagamento", " Não consegui finalizar o processo de Checkout.");

                Funcoes.BtnVoltarProfissionais(driver, "BtnVoltarProfissional", "Assercao", "ComissaoPagamento", "Não consegui clicar no botão de Voltar para Profissionais");

                // ***************************** PROFISSIONAIS

                Funcoes.AnaliseComissoes(driver, "AnaliseComissoes", "ComissaoPagamento", "Não consegui encontrar as opções na aba de Analise de Comissões");

                Funcoes.SelecionarPagamentoRecebido(driver, "SelecionarPagamento", "ComissaoPagamento", "Não consegui selecionar a opção de pagamento recebido");

                Funcoes.Listar(driver, "Listar", "ComissaoPagamento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissao(driver, "Pagamento Recebido", "AnaliseComissoes", "ComissaoPagamento", "Não consegui encontrar a comissão na aba de análise de comissões.");

                Funcoes.Observacao(driver, "Observacao", "ComissaoPagamento", "Não consegui adicionar observação na comissão.");

                Funcoes.BtnOk(driver, "ConfirmarObservacao", "ComissaoPagamento", "Não consegui confirmar a insersão de observação na comissão.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarObservacao", "ComissaoPagamento", "Não consegui autorizar a observação na comissão");

                Funcoes.BtnOk(driver, "ConfirmarAutorizacao", "ComissaoPagamento", "Não consegui confirmar a autorização da observação na comissão");

                Funcoes.Esperar(driver, "ConcluirObservacao", "ComissaoPagamento", "O processo de adicionar observação na comissão não foi concluido.");

                Funcoes.AprovarComissao(driver, "AprovarComissao", "ComissaoPagamento", "Não consegui clicar no botão de aprovar a comissão");

                Funcoes.BtnOk(driver, "ConfirmaAprovacao", "ComissaoPagamento", "Não consegui confirmar a aprovação da comissão");

                Funcoes.carregamento(driver, "CarregarAprovacao", "ComissaoPagamento", "Não consegui aprovar a comissão");

                Funcoes.AssercaoAprovada(driver, "Gerada", "ComissaoPagamento", "A comissão não foi gerada.");

                Funcoes.BtnComissoes(driver, "Comissoes", "ComissaoPagamento", "Não consegui abrir a aba de comissões.");

                Funcoes.DataComissoes(driver, "DataComissoes", "ComissaoPagamento", "Não consegui selecionar a data de hoje no calendário para listar as comissões.");

                Funcoes.Listar(driver, "ListarComissoes", "ComissaoPagamento", "Não consegui clicar no botão de listar comissão.");

                Funcoes.AssercaoComissao(driver, "LancamentosDeComissao", "ComissaoPagamento", "Não consegui visualizar o lançamento de comissão");

                Funcoes.SelecionarComissoesemAberto(driver, "ComissoesemAberto", "ComissaoPagamento", "Não consegui encontrar a opção de comissões em aberto.");

                Funcoes.Listar(driver, "ListarComissoesemAberto", "ComissaoPagamento", "Não consegui clicar no botão de listar comissão em aberto.");

                Funcoes.AssercaoComissaoemAberto(driver, "ComissoesAberto", "ComissaoPagamento", "Não consegui encontrar as opções de comissões em aberto.");

                Funcoes.BtnPagarComissao(driver, "PagarComissao", "ComissaoPagamento", "Não consegui clicar no botão de Pagar Comissões.");

                Funcoes.carregamento(driver, "loading6", "ComissaoPagamento", "");

                Funcoes.FormasPagamento(driver, "FormasPagamento", "ComissaoPagamento", "Não consegui visualizar as formas de pagamento.");

                Funcoes.SelecionarFormadePagamento(driver, "SelecionarDinheiro", "ComissaoPagamento", "Não consegui selecionar Dinheiro como forma de pagamento.");

                Funcoes.BtnOk(driver, "OkPagarComissao", "ComissaoPagamento", "Não consegui clicar no botão de Ok para pagar a comissão");

                Funcoes.AssercaoPagamento(driver, "ConfirmaPagamentoComissao", "ComissaoPagamento", "Não apareceu a janela de confirmar o pagamento.");

                Funcoes.BtnOk(driver, "ConfirmarPagamento", "ComissaoPagamento", "Não consegui Confirmar o pagamento da comissão.");

                Funcoes.carregamento(driver, "loading7", "ComissaoPagamento", "");

                Funcoes.SelecionarComissoesPagas(driver, "SelecionarComissoesPagas", "ComissaoPagamento", "Não consegui selecionar Comissões Pagas.");

                Funcoes.Listar(driver, "ListarComissoesemPagas", "ComissaoPagamento", "Não consegui clicar no botão de listar comissão em pagas.");

                Funcoes.BtnCancelarUltimoPagamento(driver, "CancelarPagamento", "ComissaoPagamento", "Não consegui clicar no botão de cancelar último pagamento.");

                Funcoes.BtnOk(driver, "Cancelar", "ComissaoPagamento", "Não consegui Confirmar o cancelamento do pagemento.");

                Funcoes.AssercaoCancelamento(driver, "ConfirmarCancelamento", "ComissaoPagamento", "Não consegui cancelar o pagamento da última comissão.");

                Funcoes.BtnOkTypeLast(driver, "Cancelar2", "ComissaoPagamento", "Não consegui Confirmar o cancelamento do pagemento.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarCancelamento", "ComissaoPagamento", "Não consegui autorizar o cancelamento do pagamento");

                Funcoes.BtnOkTypeLast(driver, "AutorizarCancelamento", "ComissaoPagamento", "Não consegui Autorizar o cancelamento do pagemento.");

                Funcoes.carregamento(driver, "loading2", "ComissaoPagamento", "");

                Funcoes.AssercaoCancelado(driver, "SemComissão", "ComissaoPagamento", "Após a exclusão ainda aparece uma comissão paga.");

                Funcoes.AnaliseComissoes(driver, "AnaliseComissoes2", "ComissaoPagamento", "Não consegui encontrar as opções na aba de Analise de Comissões");

                Funcoes.SelecionarPagamentoRecebido(driver, "SelecionarPagamento2", "ComissaoPagamento", "Não consegui selecionar a opção de pagamento recebido");

                Funcoes.Listar(driver, "Listar2", "ComissaoPagamento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissao(driver, "Pagamento Recebido", "AnaliseComissoes2", "ComissaoPagamento", "Não consegui encontrar a comissão na aba de análise de comissões.");

                Funcoes.EditarObservacao(driver, "EditarObservacao", "ComissaoPagamento", "Não consegui editar a observação.");

                Funcoes.BtnOk(driver, "OkEditar", "ComissaoPagamento", "Não consegui clicar no Ok para editar a observação da comissão.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarObservacao2", "ComissaoPagamento", "Não consegui autorizar a edição da observação.");

                Funcoes.BtnOk(driver, "Autorizar2", "ComissaoPagamento", "Não consegui confirmar a autorização da observação.");

                Funcoes.carregamento(driver, "loading3", "ComissaoPagamento", "");

                Funcoes.AssercaoSemComissao(driver, "SemComissao", "ComissaoPagamento", "Não consegui encontrar a informação de Sem Comissão.");

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Pablo Comissão", "BuscaPaciente2", "ComissaoPagamento", "Não consegui buscar paciente na barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Pablo Comissão", "PabloComissao2", "ComissaoPagamento", "Não consegui abrir o prontuário pela barra de pesquisa.");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro2", "ComissaoPagamento", " Não consegui abrir o financeiro do paciente.");

                Funcoes.Btn3Pontos(driver, "3pontos", "VerOpcoes", "ComissaoPagamento", "Não consegui clicar nos 3 pontos do financeiro paciente");

                Funcoes.Opcao3Pontos(driver, "Opcoes", "CancelarPagamento", "ComissaoPagamento", "'Cancelar Pagamento'", "Não consegui clicar em Cancelar Pagamento");

                Funcoes.BtnOk(driver, "CancelarPagamentoFinanceiro", "ComissaoPagamento", "Não consegui confirmar o cancelamento do pagamento.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarCancelamentoFinanceiro", "ComissaoPagamento", "Não consegui autorizar o cancelamento do pagamento do paciente.");

                Funcoes.BtnOk(driver, "ConfirmarCancelamentoFinanceiro", "ComissaoPagamento", "Não consegui confirmar o cancelamento do pagamento.");

                Funcoes.EsperarCancelamento(driver, "Cancelando", "ComissaoPagamento", "Não consegui confirmar que o pagamento foi cancelado.");

                Funcoes.Btn3Pontos(driver, "3pontos", "VerOpcoes", "ComissaoPagamento", "Não consegui clicar nos 3 pontos do financeiro paciente");

                Funcoes.Opcao3Pontos(driver, "AntesClickExcluir", "Excluir", "ComissaoPagamento", "'Excluir Lançamento'", "Não consegui clicar em Excluir Lançamento");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "ComissaoPagamento", " Não consegui clicar no botão de Ok para realizar a exclusão do financeiro.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "Autorizar", "ComissaoPagamento", "Não consegui inserir os dados para autozizar a exclusão do financeiro");

                Funcoes.BtnOk(driver, "ConfirmarDados", "ComissaoPagamento", " Não consegui clicar no botão de Ok para Autorizar a exclusão do financeiro.");

                Funcoes.Esperar(driver, "Carregar", "ComissaoPagamento", "Não consegui encontrar a tela de carregamento");

                Funcoes.BtnVoltarProfissionais(driver, "BtnnVoltarProfissional", "Assercao2", "ComissaoPagamento", "Não consegui clicar no botão de Voltar para Profissionais");

                Funcoes.Listar(driver, "Listar3", "ComissaoPagamento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissaoCancelado(driver, "AnaliseComissoesCancelado", "ComissaoPagamento", "A comissão não foi cancelada como deveria.");

                Funcoes.BtnInativar(driver, "Inativar", "ComissaoPagamento", "Não consegui clicar no botão de inativar Profissional.");

                Funcoes.BtnOk(driver, "ConfirmaInativacao", "ComissaoPagamento", " Não consegui clicar no botão de Ok confirmar a inativação de um profissional.");

                Funcoes.carregamento(driver, "loading4", "ComissaoPagamento", "");

                Funcoes.BtnExcluirPaciente(driver, "BtnExcluirProfissional", "Excluir", "ComissaoPagamento", "Não consegui clicar no botão de excluir um profissional.");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "ComissaoPagamento", " Não consegui clicar no botão de Ok confirmar a exclusao de um profissional.");

                Funcoes.carregamento(driver, "loading5", "ComissaoPagamento", "");

                Funcoes.AssercaoProfissionalExcluido(driver, "ProfissionalExcluido", "ComissaoPagamento", "O profissional que confirmei a exclusão ainda aparece na página de profissionais.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ComissaoPagamento" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }

                driver.Quit();



            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "ComissaoPagamento");

                sendMessage("Erro em teste de Comissão por pagamento recebido", e.Message + Funcoes.body.ToString(), ComissaoPagamento.name);

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ComissaoPagamento" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "ComissaoPagamento" + "/" + nome + ".png"));

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
            ComissaoPagamento.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();

            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }



    }
    
}


