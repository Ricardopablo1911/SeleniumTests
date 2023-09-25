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

    

    public class ComissaoOrcamento
    {
        private IWebDriver driver;
        private string folder;
        public static string name;
        public static string pasta;        public static string email;

        public ComissaoOrcamento(TestFixture fixture)
        {
            
            driver = fixture.Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();

        }

        [Fact]

        public static void ComissaoPorOrcamento()

        {
            pasta = TestHelpers.pasta;            email = TestHelpers.email;
            ChromeDriver driver = new ChromeDriver(TestHelpers.PastaDoExecutavel);
            driver.Manage().Window.Maximize();

            DateTime startTime = DateTime.Now;

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;



            if (Directory.Exists(pasta + "" + "ComissaoOrcamento"))
            {
                

            }
            else
            {
                Directory.CreateDirectory(pasta + "" + "ComissaoOrcamento");
            }
            try
            {

                // ************************* LOGIN

                Funcoes.PaginaInicial(driver, "PaginaInicial", "ComissaoOrcamento", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "Usuario", "Senha", "TelaInicial", "ComissaoOrcamento", " Não consegui efetuar o login no sistema.");

                // ************************ PROFISSIONAIS

                Funcoes.JanelaProfissionais(driver, "Profissional", "ComissaoOrcamento", " Não consegui abrir a tela de Profissionais.");

                Funcoes.AbrirDentista7(driver, "Dentista7", "ComissaoOrcamento", "Não consegui encontrar ou abrir o dentista com a configuração por aprovação do orçamento.");

                Funcoes.carregamento(driver, "loading", "ComissaoOrcamento", "");

                Funcoes.AnaliseComissoes(driver, "AnaliseComissao", "ComissaoOrcamento", "Não consegui abrir a aba de análise de comissões.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Pablo Comissão", "BuscaPaciente", "ComissaoOrcamento", "Não consegui buscar paciente na barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Pablo Comissão", "PabloComissao", "ComissaoOrcamento", "Não consegui abrir o prontuário pela barra de pesquisa.");

                // ***************************** CRIAR ORCAMENTO_CREDITO

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "ComissaoOrcamento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.BtnNovoOrcamento(driver, "NovoOrcamento", "ComissaoOrcamento", " Não consegui clicar no botão de novo orçamento.");

                Funcoes.SelecionarDentista(driver, "Dentista 7 - Porcentagem / Aprovação orçamento", "VisualizarDentistas", "DentistaSelecionado", "ComissaoOrcamento", " Não consegui encontrar o profissional Pablo Souza.");

                Funcoes.SelecionarClinicaOrcamento(driver, "VisualizarClinicas", "ClinicaSelecionada", "ComissaoOrcamento", " Não consegui encontrar a clinica Automação.");

                Funcoes.SelecionarTabelaParticular(driver, "VisualizarTabelas", "TabelaSelecionada", "ComissaoOrcamento", " Não consegui selecionar a tabela Particular.");

                Funcoes.AdicionarProcedimentoOrcamento(driver, "PesquisaProcedimento", "ProcedimentoTesteDatadog", "ProcedimentoSelecionado", "ProcedimentoAdicionado", "ComissaoOrcamento", " Não consegui adicionar o procedimento no orçamento.");

                Funcoes.AprovarOrcamento(driver, "ConfirmarAprovacao", "OrcamentoAprovado", "ComissaoOrcamento", " Não consegui aprovar o orçamento");

                Funcoes.carregamento(driver, "loadinga", "ComissaoOrcamento", "");

                // ***************************** FINANCEIRO_CREDITO

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro", "ComissaoOrcamento", " Não consegui abrir o financeiro do paciente.");

                Funcoes.BtnVoltarProfissionais(driver, "BtnVoltarProfissional", "Assercao", "ComissaoOrcamento", "Não consegui clicar no botão de Voltar para Profissionais");

                // ***************************** PROFISSIONAIS

                Funcoes.AnaliseComissoes(driver, "AnaliseComissoes", "ComissaoOrcamento", "Não consegui encontrar as opções na aba de Analise de Comissões");

                Funcoes.SelecionarOrcamento(driver, "SelecionarPagamento", "ComissaoOrcamento", "Não consegui selecionar a opção de Procedimento Executado");

                Funcoes.Listar(driver, "Listar", "ComissaoOrcamento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissaoProcedimento(driver, "Orçamento Aprovado", "AnaliseComissoes", "ComissaoOrcamento", "Não consegui encontrar a comissão na aba de análise de comissões.");

                Funcoes.Observacao(driver, "Observacao", "ComissaoOrcamento", "Não consegui adicionar observação na comissão.");

                Funcoes.BtnOk(driver, "ConfirmarObservacao", "ComissaoOrcamento", "Não consegui confirmar a insersão de observação na comissão.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarObservacao", "ComissaoOrcamento", "Não consegui autorizar a observação na comissão");

                Funcoes.BtnOk(driver, "ConfirmarAutorizacao", "ComissaoOrcamento", "Não consegui confirmar a autorização da observação na comissão");

                Funcoes.carregamento(driver, "ConcluirObservacao", "ComissaoOrcamento", "O processo de adicionar observação na comissão não foi concluido.");

                Funcoes.AprovarComissao(driver, "AprovarComissao", "ComissaoOrcamento", "Não consegui clicar no botão de aprovar a comissão");

                Funcoes.BtnOk(driver, "ConfirmaAprovacao", "ComissaoOrcamento", "Não consegui confirmar a aprovação da comissão");

                Funcoes.carregamento(driver, "CarregarAprovacao", "ComissaoOrcamento", "Não consegui aprovar a comissão");

                Funcoes.AssercaoAprovada(driver, "Gerada", "ComissaoOrcamento", "A comissão não foi gerada.");

                Funcoes.BtnComissoes(driver, "Comissoes", "ComissaoOrcamento", "Não consegui abrir a aba de comissões.");

                Funcoes.DataComissoes(driver, "DataComissoes", "ComissaoOrcamento", "Não consegui selecionar a data de hoje no calendário para listar as comissões.");

                Funcoes.Listar(driver, "ListarComissoes", "ComissaoOrcamento", "Não consegui clicar no botão de listar comissão.");

                Funcoes.AssercaoComissao(driver, "LancamentosDeComissao", "ComissaoOrcamento", "Não consegui visualizar o lançamento de comissão");

                Funcoes.SelecionarComissoesemAberto(driver, "ComissoesemAberto", "ComissaoOrcamento", "Não consegui encontrar a opção de comissões em aberto.");

                Funcoes.Listar(driver, "ListarComissoesemAberto", "ComissaoOrcamento", "Não consegui clicar no botão de listar comissão em aberto.");

                Funcoes.AssercaoComissaoemAberto(driver, "ComissoesAberto", "ComissaoOrcamento", "Não consegui encontrar as opções de comissões em aberto.");

                Funcoes.BtnPagarComissao(driver, "PagarComissao", "ComissaoOrcamento", "Não consegui clicar no botão de Pagar Comissões.");

                Funcoes.carregamento(driver, "loading6", "ComissaoOrcamento", "");

                Funcoes.FormasPagamento(driver, "FormasPagamento", "ComissaoOrcamento", "Não consegui visualizar as formas de pagamento.");

                Funcoes.SelecionarFormadePagamento(driver, "SelecionarDinheiro", "ComissaoOrcamento", "Não consegui selecionar Dinheiro como forma de pagamento.");

                Funcoes.BtnOk(driver, "OkPagarComissao", "ComissaoOrcamento", "Não consegui clicar no botão de Ok para pagar a comissão");

                Funcoes.AssercaoPagamento(driver, "ConfirmaPagamentoComissao", "ComissaoOrcamento", "Não apareceu a janela de confirmar o pagamento.");

                Funcoes.BtnOk(driver, "ConfirmarPagamento", "ComissaoOrcamento", "Não consegui Confirmar o pagamento da comissão.");

                Funcoes.carregamento(driver, "loading7", "ComissaoOrcamento", "");

                Funcoes.SelecionarComissoesPagas(driver, "SelecionarComissoesPagas", "ComissaoOrcamento", "Não consegui selecionar Comissões Pagas.");

                Funcoes.Listar(driver, "ListarComissoesemPagas", "ComissaoOrcamento", "Não consegui clicar no botão de listar comissão em pagas.");

                Funcoes.BtnCancelarUltimoPagamento(driver, "CancelarPagamento", "ComissaoOrcamento", "Não consegui clicar no botão de cancelar último pagamento.");

                Funcoes.BtnOk(driver, "Cancelar", "ComissaoOrcamento", "Não consegui Confirmar o cancelamento do pagemento.");

                Funcoes.AssercaoCancelamento(driver, "ConfirmarCancelamento", "ComissaoOrcamento", "Não consegui cancelar o pagamento da última comissão.");

                Funcoes.BtnOkTypeLast(driver, "Cancelar2", "ComissaoOrcamento", "Não consegui Confirmar o cancelamento do pagemento.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarCancelamento", "ComissaoOrcamento", "Não consegui autorizar o cancelamento do pagamento");

                Funcoes.BtnOkTypeLast(driver, "AutorizarCancelamento", "ComissaoOrcamento", "Não consegui Autorizar o cancelamento do pagemento.");

                Funcoes.carregamento(driver, "loading2", "ComissaoOrcamento", "");

                Funcoes.AssercaoCancelado(driver, "SemComissão", "ComissaoOrcamento", "Após a exclusão ainda aparece uma comissão paga.");

                Funcoes.AnaliseComissoes(driver, "AnaliseComissoes2", "ComissaoOrcamento", "Não consegui encontrar as opções na aba de Analise de Comissões");

                Funcoes.SelecionarOrcamento(driver, "SelecionarPagamento2", "ComissaoOrcamento", "Não consegui selecionar a opção de Procedimento Executado");

                Funcoes.Listar(driver, "Listar2", "ComissaoOrcamento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissaoProcedimento(driver, "Orçamento Aprovado", "AnaliseComissoes2", "ComissaoOrcamento", "Não consegui encontrar a comissão na aba de análise de comissões.");

                Funcoes.EditarObservacao(driver, "EditarObservacao", "ComissaoOrcamento", "Não consegui editar a observação.");

                Funcoes.BtnOk(driver, "OkEditar", "ComissaoOrcamento", "Não consegui clicar no Ok para editar a observação da comissão.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "AutorizarObservacao2", "ComissaoOrcamento", "Não consegui autorizar a edição da observação.");

                Funcoes.BtnOk(driver, "Autorizar2", "ComissaoOrcamento", "Não consegui confirmar a autorização da observação.");

                Funcoes.carregamento(driver, "loading3", "ComissaoOrcamento", "");

                Funcoes.AssercaoSemComissao(driver, "SemComissao", "ComissaoOrcamento", "Não consegui encontrar a informação de Sem Comissão.");

                // ******************************** PESQUISA PACIENTE

                Funcoes.PesquisarNomeBarraPesquisa(driver, "Pablo Comissão", "BuscaPaciente2", "ComissaoOrcamento", "Não consegui buscar paciente na barra de pesquisa.");

                Funcoes.AbrirProntuarioBarraPesquisa(driver, "Pablo Comissão", "PabloComissao2", "ComissaoOrcamento", "Não consegui abrir o prontuário pela barra de pesquisa.");

                Funcoes.BtnFinanceiroPaciente(driver, "Financeiro_Dinheiro2", "ComissaoOrcamento", " Não consegui abrir o financeiro do paciente.");

                Funcoes.Btn3Pontos(driver, "3pontos", "VerOpcoes", "ComissaoOrcamento", "Não consegui clicar nos 3 pontos do financeiro paciente");

                Funcoes.Opcao3Pontos(driver, "AntesClickExcluir", "Excluir", "ComissaoOrcamento", "'Excluir Lançamento'", "Não consegui clicar em Excluir Lançamento");

                Funcoes.BtnOk(driver, "ConfirmaExclusao", "ComissaoOrcamento", " Não consegui clicar no botão de Ok para realizar a exclusão do financeiro.");

                Funcoes.Autorizar(driver, "pablo@qms", "Pr102030!", "Autorizar", "ComissaoOrcamento", "Não consegui inserir os dados para autozizar a exclusão do financeiro");

                Funcoes.BtnOk(driver, "ConfirmarDados", "ComissaoOrcamento", " Não consegui clicar no botão de Ok para Autorizar a exclusão do financeiro.");

                Funcoes.carregamento(driver, "Carregar", "ComissaoOrcamento", "Não consegui encontrar a tela de carregamento");

                Funcoes.BtnOrcamentosPaciente(driver, "BtnOrcamentos", "BtnNovoOrcamento", "ComissaoOrcamento", " Não consegui abrir a aba de Orçamentos no prontuário.");

                Funcoes.DesaprovarOrcamento(driver, "DesaprovarOrcamento", "ComissaoOrcamento", " Não consegui clicar no botão de Desaprovar Orçamento.");

                Funcoes.BtnOk(driver, "ConfirmarDesaprovacao", "ComissaoOrcamento", "Não consegui confirmar a desaprovação do orçamento.");

                Funcoes.AssercaoEmAberto(driver, "EmAberto", "ComissaoOrcamento", "Orçamento não ficou como Em Aberto.");

                Funcoes.BtnVoltarProfissionais(driver, "BtnnVoltarProfissional", "Assercao2", "ComissaoOrcamento", "Não consegui clicar no botão de Voltar para Profissionais");

                Funcoes.Listar(driver, "Listar3", "ComissaoOrcamento", "Não consegui listar a análise de comissões");

                Funcoes.AssercaoAnaliseComissaoCancelado(driver, "AnaliseComissoesCancelado", "ComissaoOrcamento", "A comissão não foi cancelada como deveria.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");


                string filePath = pasta + "" + "ComissaoOrcamento" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();


            }
            catch (Exception e)
            {
                printScreen(driver, "Erro", "ComissaoOrcamento");
                sendMessage("Erro em teste de Comissão por orçamento aprovado", e.Message + Funcoes.body.ToString(), ComissaoOrcamento.name);
                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);

                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "ComissaoOrcamento" + "/" + "tempo_de_teste.txt";

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
            mail.Attachments.Add(new System.Net.Mail.Attachment(pasta + "" + "ComissaoOrcamento" + "/" + nome + ".png"));
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
            ComissaoOrcamento.name = name;

            var print = ((ITakesScreenshot)driver).GetScreenshot();
            print.SaveAsFile(pasta + "" + folder + "/" + name + ".png");

        }



    }
    
}


