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

    

    public class ComissaoProcedimento
    {
        private IWebDriver driver;

        private string folder;

        public static string name;

        public static string pasta;

        public static string email;

        public ComissaoProcedimento(TestFixture fixture)
        {
            
            driver = fixture.Driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Manage().Window.Maximize();

        }

        [Fact]

        public static void ComissaoPorProcedimento()

        {
            pasta = TestHelpers.pasta;

            email = TestHelpers.email;

            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);

            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            DateTime startTime = DateTime.Now;

            if (Directory.Exists(pasta + "" + "ComissaoProcedimento"))
            {
                

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "ComissaoProcedimento");
            }
            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "ComissaoProcedimento", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "ComissaoProcedimento", " Não consegui efetuar o login no sistema.");

                // ************************ PROFISSIONAIS

                Funcoes.JanelaProfissionais(driver, "Profissional", "ComissaoProcedimento", " Não consegui abrir a tela de Profissionais.");

                Funcoes.AbrirDentista2(driver, "Dentista2", "ComissaoProcedimento", "Não consegui encontrar ou abrir o dentista com a configuração por procedimento executado.");

                Funcoes.carregamento(driver, "loading", "ComissaoPagamento", "");

                Funcoes.AnaliseComissoes(driver, "AnaliseComissao", "ComissaoProcedimento", "Não consegui abrir a aba de análise de comissões.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Pablo Comissão", "BuscaPaciente", "ComissaoProcedimento", "Não consegui buscar paciente na barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Pablo Comissão", "PabloComissao", "ComissaoProcedimento", "Não consegui abrir o prontuário pela barra de pesquisa.");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "ComissaoProcedimento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "ComissaoProcedimento", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Dentista 2 - porcentagem / exec.", "VisualizarDentistas", "DentistaSelecionado", "ComissaoProcedimento", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas", "ClinicaSelecionada", "ComissaoProcedimento", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas", "TabelaSelecionada", "ComissaoProcedimento", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "ComissaoProcedimento", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.FormaPagamento(driver, "BtnFormaPagamento", "BtnProcedExec", "ComissaoProcedimento", "Não conegui definir a forma de Pagamento por Procedimento Executado ao criar orçamento.");

                Funcoes.BtnOk(driver, "ConfirmarFormaPagamento", "ComissaoProcedimento", "Não consegui confirmar a forma de pagamento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "ComissaoProcedimento", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loading", "ComissaoProcedimento", "");

                // ***************************** PLANO E FICHA

                Funcoes.AssercaoPlanoEFicha(driver, "PlanoEficha", "ComissaoProcedimento", "Não consegui acessar a aba de Plano e Ficha Clínica");

                Funcoes.PlanosTratamentos(driver, "PlanosTratamentos", "EmAberto", "ComissaoProcedimento", "Não consegui visualizar os planos de tratamentos em aberto");

                Funcoes.ExecutarProcedimento(driver, "ExecutarProced", "ComissaoProcedimento", "Não consegui visualizar a janela de executar Procedimento");

                Funcoes.BtnOk(driver, "ExecutarProcedimento", "ComissaoProcedimento", "Não consegui executar o procedimento.");

                Funcoes.carregamento(driver, "Carregando", "ComissaoProcedimento", "Erro ao carregar");

                // ***************************** FINANCEIRO_CREDITO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro", "ComissaoProcedimento", " Não consegui abrir o financeiro do paciente.");

                Funcoes.BtnVoltarProfissionais(driver, "BtnVoltarProfissional", "Assercao", "ComissaoProcedimento", "Não consegui clicar no botão de Voltar para Profissionais");

                // ***************************** PROFISSIONAIS

                Funcoes.AnaliseComissoes(driver, "AnaliseComissoes", "ComissaoProcedimento", "Não consegui encontrar as opções na aba de Analise de Comissões");

                Funcoes.SelecionarProcedExec(driver, "SelecionarPagamento", "ComissaoProcedimento", "Não consegui selecionar a opção de Procedimento Executado");

                Funcoes.Listar(driver, "Listar", "ComissaoProcedimento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissaoProcedimento(driver, "Procedimento Executado", "AnaliseComissoes", "ComissaoProcedimento", "Não consegui encontrar a comissão na aba de análise de comissões.");

                Funcoes.Observacao(driver, "Observacao", "ComissaoProcedimento", "Não consegui adicionar observação na comissão.");

                Funcoes.BtnOk(driver, "ConfirmarObservacao", "ComissaoProcedimento", "Não consegui confirmar a insersão de observação na comissão.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarObservacao", "ComissaoProcedimento", "Não consegui autorizar a observação na comissão");

                Funcoes.BtnOk(driver, "ConfirmarAutorizacao", "ComissaoProcedimento", "Não consegui confirmar a autorização da observação na comissão");

                Funcoes.carregamento(driver, "ConcluirObservacao", "ComissaoProcedimento", "O processo de adicionar observação na comissão não foi concluido.");

                Funcoes.AprovarComissao(driver, "AprovarComissao", "ComissaoProcedimento", "Não consegui clicar no botão de aprovar a comissão");

                Funcoes.BtnOk(driver, "ConfirmaAprovacao", "ComissaoProcedimento", "Não consegui confirmar a aprovação da comissão");

                Funcoes.carregamento(driver, "CarregarAprovacao", "ComissaoProcedimento", "Não consegui aprovar a comissão");

                Funcoes.AssercaoAprovada(driver, "Gerada", "ComissaoProcedimento", "A comissão não foi gerada.");

                Funcoes.BtnComissoes(driver, "Comissoes", "ComissaoProcedimento", "Não consegui abrir a aba de comissões.");

                Funcoes.DataComissoes(driver, "DataComissoes", "ComissaoProcedimento", "Não consegui selecionar a data de hoje no calendário para listar as comissões.");

                Funcoes.Listar(driver, "ListarComissoes", "ComissaoProcedimento", "Não consegui clicar no botão de listar comissão.");

                Funcoes.AssercaoComissao(driver, "LancamentosDeComissao", "ComissaoProcedimento", "Não consegui visualizar o lançamento de comissão");

                Funcoes.SelecionarComissoesemAberto(driver, "ComissoesemAberto", "ComissaoProcedimento", "Não consegui encontrar a opção de comissões em aberto.");

                Funcoes.Listar(driver, "ListarComissoesemAberto", "ComissaoProcedimento", "Não consegui clicar no botão de listar comissão em aberto.");

                Funcoes.AssercaoComissaoemAberto(driver, "ComissoesAberto", "ComissaoProcedimento", "Não consegui encontrar as opções de comissões em aberto.");

                Funcoes.BtnPagarComissao(driver, "PagarComissao", "ComissaoProcedimento", "Não consegui clicar no botão de Pagar Comissões.");

                Funcoes.carregamento(driver, "loading6", "ComissaoProcedimento", "");

                Funcoes.FormasPagamento(driver, "FormasPagamento", "ComissaoProcedimento", "Não consegui visualizar as formas de pagamento.");

                Funcoes.SelecionarFormadePagamento(driver, "SelecionarDinheiro", "ComissaoProcedimento", "Não consegui selecionar Dinheiro como forma de pagamento.");

                Funcoes.BtnOk(driver, "OkPagarComissao", "ComissaoProcedimento", "Não consegui clicar no botão de Ok para pagar a comissão");

                Funcoes.AssercaoPagamento(driver, "ConfirmaPagamentoComissao", "ComissaoProcedimento", "Não apareceu a janela de confirmar o pagamento.");

                Funcoes.BtnOk(driver, "ConfirmarPagamento", "ComissaoProcedimento", "Não consegui Confirmar o pagamento da comissão.");

                Funcoes.carregamento(driver, "loading7", "ComissaoProcedimento", "");

                Funcoes.SelecionarComissoesPagas(driver, "SelecionarComissoesPagas", "ComissaoProcedimento", "Não consegui selecionar Comissões Pagas.");

                Funcoes.Listar(driver, "ListarComissoesemPagas", "ComissaoProcedimento", "Não consegui clicar no botão de listar comissão em pagas.");

                Funcoes.BtnCancelarUltimoPagamento(driver, "CancelarPagamento", "ComissaoProcedimento", "Não consegui clicar no botão de cancelar último pagamento.");

                Funcoes.BtnOk(driver, "Cancelar", "ComissaoProcedimento", "Não consegui Confirmar o cancelamento do pagemento.");

                Funcoes.AssercaoCancelamento(driver, "ConfirmarCancelamento", "ComissaoProcedimento", "Não consegui cancelar o pagamento da última comissão.");

                Funcoes.BtnOkTypeLast(driver, "Cancelar2", "ComissaoProcedimento", "Não consegui Confirmar o cancelamento do pagemento.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarCancelamento", "ComissaoProcedimento", "Não consegui autorizar o cancelamento do pagamento");

                Funcoes.BtnOkTypeLast(driver, "AutorizarCancelamento", "ComissaoProcedimento", "Não consegui Autorizar o cancelamento do pagemento.");

                Funcoes.carregamento(driver, "loading2", "ComissaoProcedimento", "");

                Funcoes.AssercaoCancelado(driver, "SemComissão", "ComissaoProcedimento", "Após a exclusão ainda aparece uma comissão paga.");

                Funcoes.AnaliseComissoes(driver, "AnaliseComissoes2", "ComissaoProcedimento", "Não consegui encontrar as opções na aba de Analise de Comissões");

                Funcoes.SelecionarProcedExec(driver, "SelecionarPagamento2", "ComissaoProcedimento", "Não consegui selecionar a opção de Procedimento Executado");

                Funcoes.Listar(driver, "Listar2", "ComissaoProcedimento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissaoProcedimento(driver, "Procedimento Executado", "AnaliseComissoes2", "ComissaoProcedimento", "Não consegui encontrar a comissão na aba de análise de comissões.");

                Funcoes.EditarObservacao(driver, "EditarObservacao", "ComissaoProcedimento", "Não consegui editar a observação.");

                Funcoes.BtnOk(driver, "OkEditar", "ComissaoProcedimento", "Não consegui clicar no Ok para editar a observação da comissão.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarObservacao2", "ComissaoProcedimento", "Não consegui autorizar a edição da observação.");

                Funcoes.BtnOk(driver, "Autorizar2", "ComissaoProcedimento", "Não consegui confirmar a autorização da observação.");

                Funcoes.carregamento(driver, "loading3", "ComissaoProcedimento", "");

                Funcoes.AssercaoSemComissao(driver, "SemComissao", "ComissaoProcedimento", "Não consegui encontrar a informação de Sem Comissão.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Pablo Comissão", "BuscaPaciente2", "ComissaoProcedimento", "Não consegui buscar paciente na barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Pablo Comissão", "PabloComissao2", "ComissaoProcedimento", "Não consegui abrir o prontuário pela barra de pesquisa.");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro2", "ComissaoProcedimento", " Não consegui abrir o financeiro do paciente.");

                Funcoes.Btn3Pontos(driver, "3pontos", "VerOpcoes", "ComissaoProcedimento", "Não consegui clicar nos 3 pontos do financeiro paciente");

                Funcoes.Opcao3Pontos(driver, "AntesClickExcluir", "Excluir", "ComissaoProcedimento", "'Excluir Lançamento'", "Não consegui clicar em Excluir Lançamento");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "ComissaoProcedimento", " Não consegui clicar no botão de Ok para realizar a exclusão do financeiro.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "Autorizar", "ComissaoProcedimento", "Não consegui inserir os dados para autozizar a exclusão do financeiro");

                Funcoes.BtnOk(driver, "ConfirmarDados", "ComissaoProcedimento", " Não consegui clicar no botão de Ok para Autorizar a exclusão do financeiro.");

                Funcoes.carregamento(driver, "Carregar", "ComissaoProcedimento", "Não consegui encontrar a tela de carregamento");

                Funcoes.AssercaoPlanoEFicha(driver, "PlanoEficha", "ComissaoProcedimento", "Não consegui acessar a aba de Plano e Ficha Clínica");

                Funcoes.ExpandirExecucao(driver, "Expandir", "ComissaoProcedimento", "Não consegui expandir o procedimento executado");

                Funcoes.CancelarExecucao(driver, "CancelarExecucao", "ComissaoProcedimento", "Não consegui clicar no X para cancelar a execução.");

                Funcoes.BtnOk(driver, "ConfirmaCancelar", "ComissaoProcedimento", "Não consegui cancelar a execução do procedimento.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "Autorizar", "ComissaoProcedimento", "Não consegui autorizar o cancelamento do procedimento.");

                Funcoes.BtnOk(driver, "OkAutorizar", "ComissaoProcedimento", "Não consegui finalizar o cancelamento da execução do procedimento.");

                Funcoes.carregamento(driver, "loading3", "ComissaoProcedimento", "");

                Funcoes.BtnVoltarProfissionais(driver, "BtnnVoltarProfissional", "Assercao2", "ComissaoProcedimento", "Não consegui clicar no botão de Voltar para Profissionais");

                Funcoes.Listar(driver, "Listar3", "ComissaoProcedimento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissaoCancelado(driver, "AnaliseComissoesCancelado", "ComissaoProcedimento", "A comissão não foi cancelada como deveria.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;

                int minutes = (int)(duration / 60);

                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ComissaoProcedimento" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();


            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "ComissaoProcedimento");
                sendMessage("Erro em teste Comissão por Procedimento Executado", e.Message + Funcoes.body.ToString(), ComissaoProcedimento.name);
                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ComissaoProcedimento" + "/" + "tempo_de_teste.txt";

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

            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "ComissaoProcedimento" + "/" + nome + ".png"));

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


