using System;using System.Collections.Generic;using System.Linq;using Microsoft.AspNetCore.Mvc.Controllers;using Microsoft.AspNetCore.Mvc;using Microsoft.Extensions.Logging;using Exemplo_2;using Polly;using OpenQA.Selenium.DevTools.V108.Network;using Microsoft.AspNetCore.Http;using System.Net;using System.IO;
using API.Models;
using Exemplo_2.Helpers;

namespace API.Controllers{    [ApiController]    [Route("[controller]")]

    public class APIController : ControllerBase    {        private static readonly string[] Summaries = new[]        {            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"        };        private readonly ILogger<APIController> _logger;        public APIController(ILogger<APIController> logger)        {            _logger = logger;        }        [HttpGet]        public IEnumerable<WeatherForecast> Get()        {            var rng = new Random();            return Enumerable.Range(1, 5).Select(index => new WeatherForecast            {                Date = DateTime.Now.AddDays(index),                TemperatureC = rng.Next(-20, 55),                Summary = Summaries[rng.Next(Summaries.Length)]            })            .ToArray();        }

        [ApiController]
        [Route("[controller]")]
        public class MeuController : ControllerBase
        {
            [HttpPost]
            public IActionResult Post([FromBody] MeuModelo modelo)
            {
                if (modelo == null)
                {
                    return BadRequest();
                }

                // Processa os dados do modelo aqui

                return Ok();
            }
        }

        public class MeuModelo
        {
            public string Text1 { get; set; }
            public string Text2 { get; set; }
            public string Text3 { get; set; }
        }

        public class DadosModel
        {
            public  string link { get; set; }
            public  string email { get; set; }
            public  string caminho { get; set; }
        }

        [HttpPost]
        [Route("enviarDados")]
        public IActionResult EnviarDados([FromBody] DadosModel dados)
        {
            // Lógica do metodo para tratar os dados recebidos
            // A variável "dados" contém os valores do corpo da solicitação
            TestHelpers.pasta = dados.caminho;
            TestHelpers.linkSistema = dados.link;
            TestHelpers.email = dados.email;
            return Ok(dados);
        }        [HttpGet]        [Route("teste")]        public string test()        {            Exemplo_2.Testes.Agendar_Botao_Mais.AcessarSistema();            return "teste bem sucedido";        }

        [HttpGet]        [Route("agendarDuplo")]        public string agendarDuplo()        {            Exemplo_2.Testes.Agendar_duplo_Clique.AgendarDuploClique();            return "teste bem sucedido";        }

        [HttpGet]        [Route("alertaconsulta")]        public string AleraConsulta()        {            Exemplo_2.Testes.AlertaConsulta.AlertaDeConsulta();            return "teste bem sucedido";        }

        [HttpGet]        [Route("aprovar-desaprovar-orcamento")]        public string AprovarDesaprovarOrc()        {            Exemplo_2.Testes.CriarDesaprovarOrcamento.TesteAprovarDesaprovarOrcamento();            return "teste bem sucedido";        }

        [HttpGet]        [Route("abacaixa")]        public string abaCaixa()        {            Exemplo_2.Testes.Caixa.AbaCaixa();            return "teste bem sucedido";        }

        [HttpGet]        [Route("cartaoSistema")]        public string cartaoSistema()        {            Exemplo_2.Testes.CartaoSistema.TesteCartaoSistema();            return "teste bem sucedido";        }

        [HttpGet]        [Route("comissao-orcamento")]        public string comissaoOrcameno()        {            Exemplo_2.Testes.ComissaoOrcamento.ComissaoPorOrcamento();            return "teste bem sucedido";        }

        [HttpGet]        [Route("comissao-pagamento")]        public string comissaoPagamento()        {            Exemplo_2.Testes.ComissaoPagamento.ComissaoRecebimento();            return "teste bem sucedido";        }


        [HttpGet]        [Route("comissao-procedimento")]        public string comissaoProcedimento()        {            Exemplo_2.Testes.ComissaoProcedimento.ComissaoPorProcedimento();            return "teste bem sucedido";        }


        [HttpGet]        [Route("consulta-spc")]        public string consultaSpc()        {            Exemplo_2.Testes.Consultar_SPC.ConsultarSPC();            return "teste bem sucedido";        }


        [HttpGet]        [Route("novo-usuario")]        public string novoUsuario()        {            Exemplo_2.Testes.NovoUsuario.CriarNovoUsuario();            return "teste bem sucedido";        }


        [HttpGet]        [Route("criar-excluir-anamnese")]        public string criarExcluirAnamnese()        {            Exemplo_2.Testes.CriarExcluirAnamnese.Criar_ExcluirAnamnese();            return "teste bem sucedido";        }


        [HttpGet]        [Route("documentos-pacientes")]        public string documentosPacientes()        {            Exemplo_2.Testes.DocumentosPaciente.DocumentosDoPaciente();            return "teste bem sucedido";        }

        [HttpGet]        [Route("excluir-cadastrar-pacientes")]        public string excluirCadastrarPaciente()        {            Exemplo_2.Testes.ExcluirCadastrarPaciente.CadastrarExcluirCadastrar_Paciente();            return "teste bem sucedido";        }

        [HttpGet]        [Route("ficha-clinica-orcamento")]        public string fichaClinicaOrcamento()        {            Exemplo_2.Testes.FichaClinicaOrcamento.FichaClinicaOrcamentoo();            return "teste bem sucedido";        }

        [HttpGet]        [Route("ficha-clinica-manual")]        public string fichaClinicaManual()        {            Exemplo_2.Testes.FichaClinica.FichaClinicaManual();            return "teste bem sucedido";        }

        [HttpGet]        [Route("financeiro-clinica")]        public string financeiroClinica()        {            Exemplo_2.Testes.Financeiro_Clinica.FinanceiroClinica();            return "teste bem sucedido";        }

        [HttpGet]        [Route("link-pagamento")]        public string LinkPagamento()        {            Exemplo_2.Testes.LinkPagamento.LinkDePagamento();            return "teste bem sucedido";        }


        [HttpGet]        [Route("menu-inicio")]        public string MenuInicio()        {            Exemplo_2.Testes.Menu_Inicio.AcessarSistema();            return "teste bem sucedido";        }


        [HttpGet]        [Route("orcamento-plano")]        public string orcamentoPlano()        {            Exemplo_2.Testes.OrcamentoPlano.FazerOrcamentoPlano();            return "teste bem sucedido";        }


        [HttpGet]        [Route("checkout-unificado-novo-orcamento")]        public string checkoutUnificadoOrcamento()        {            Exemplo_2.Testes.Pacientes.AbrirTelaProntuarioPacientes();            return "teste bem sucedido";        }


        [HttpGet]        [Route("procedimento-executado")]        public string procedimentoExecutado()        {            Exemplo_2.Testes.PrcedimentoExecutado.ProcedExec();            return "teste bem sucedido";        }

        [HttpGet]        [Route("procedimento-odontograma")]        public string procedimentoOdontograma()        {            Exemplo_2.Testes.ProcedimentoOdontograma.AdicionarProcedimentoOdontograma();            return "teste bem sucedido";        }


        [HttpGet]        [Route("prontuario-paciente")]        public string prontuarioPaciente()        {            Exemplo_2.Testes.Prontuario_Paciente.Prontuario();            return "teste bem sucedido";        }


        [HttpGet]        [Route("relatorios-financeiros")]        public string relatoriosFinanceiros()        {            Exemplo_2.Testes.RelatoriosFinanceiros.Relatorios();            return "teste bem sucedido";        }


        [HttpGet]        [Route("relatorios-todos")]        public string relatoriosTodos()        {            Exemplo_2.Testes.Todos_Relatorios.Relatorios();            return "teste bem sucedido";        }

        [HttpGet]        [Route("reset-senha")]        public string resetSenha()        {            Exemplo_2.Testes.ResetSenha.ResetdeSenha();            return "teste bem sucedido";        }

        [HttpGet]        [Route("visualizar-odontograma")]        public string visualizarOdontograma()        {            Exemplo_2.Testes.VisualizarOdontograma.VerOdontograma();            return "teste bem sucedido";        }

        [HttpGet]        [Route("visualizar-tela-agendamento-online")]        public string visualizarTelaAgendamentoOnline()        {            Exemplo_2.Testes.TelaAgendamentoOnline.VisualizarTelaAgendamentoOnline();            return "teste bem sucedido";        }


        [HttpGet]        [Route("visualizar-remover-ficha-alinhadores")]        public string visualizarRemoverfichaAlinhadores()        {            Exemplo_2.Testes.VisualizarRemoverFicha.VisualizarRemoverFichaAlinhadores();            return "teste bem sucedido";        }


    }}