function animacao () 
{
    var barraProgresso = document.getElementById("barra-progresso");
    barraProgresso.style.display = "block";
    var largura = 0;
    var intervalo = setInterval(function() {
      if (largura >= 100) {
        clearInterval(intervalo);
        barraProgresso.style.display = "none";
      } else {
        largura++;
        barraProgresso.style.width = largura + "%";
      }
    }, 1000);
    getWeatherForecast();
    barraProgresso.style.display = "none";
}

async function getWeatherForecast () 
{

    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/teste")
    console.log(result)
    console.log(await result2.text())
    
}

async function agendarDuplo () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/agendarDuplo")
    console.log(result)
    console.log(await result2.text())
}

async function alertaConsulta () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/alertaconsulta")
    console.log(result)
    console.log(await result2.text())
}

async function aprovardesaprovarOrcamento () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/aprovar-desaprovar-orcamento")
    console.log(result)
    console.log(await result2.text())
}

async function abacaixa () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/abacaixa")
    console.log(result)
    console.log(await result2.text())
}

async function cartaoSistema () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/cartaosistema")
    console.log(result)
    console.log(await result2.text())
}

async function comissaoOrcamento () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/comissao-orcamento")
    console.log(result)
    console.log(await result2.text())
}
async function comissaoPagamento () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/comissao-pagamento")
    console.log(result)
    console.log(await result2.text())
}

async function comissaoProcedimento () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/comissao-procedimento")
    console.log(result)
    console.log(await result2.text())
}

async function consultaSpc () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/consulta-spc")
    console.log(result)
    console.log(await result2.text())
}

async function novoUsuario () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/novo-usuario")
    console.log(result)
    console.log(await result2.text())
}

async function criarExcluirAnamnese () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/criar-excluir-anamnese")
    console.log(result)
    console.log(await result2.text())
}

async function documentosPacientes () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/documentos-pacientes")
    console.log(result)
    console.log(await result2.text())
}

async function excluirCadastrarPaciente () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/excluir-cadastrar-pacientes")
    console.log(result)
    console.log(await result2.text())
}

async function fichaClinicaOrcamento () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/ficha-clinica-orcamento")
    console.log(result)
    console.log(await result2.text())
}

async function fichaClinicaManual () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/ficha-clinica-manual")
    console.log(result)
    console.log(await result2.text())
}

async function financeiroClinica () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/financeiro-clinica")
    console.log(result)
    console.log(await result2.text())
}

async function linkPagamento () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/link-pagamento")
    console.log(result)
    console.log(await result2.text())
}

async function menuInicio () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/menu-inicio")
    console.log(result)
    console.log(await result2.text())
}

async function orcamentoPlano () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/orcamento-plano")
    console.log(result)
    console.log(await result2.text())
}

async function checkoutUnificadoOrcamento () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/checkout-unificado-novo-orcamento")
    console.log(result)
    console.log(await result2.text())
}

async function procedimentoExecutado () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/procedimento-executado")
    console.log(result)
    console.log(await result2.text())
}

async function procedimentoOdontograma () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/procedimento-odontograma")
    console.log(result)
    console.log(await result2.text())
}

async function prontuarioPaciente () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/prontuario-paciente")
    console.log(result)
    console.log(await result2.text())
}

async function relatoriosFinanceiros () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/relatorios-financeiros")
    console.log(result)
    console.log(await result2.text())
}

async function relatoriosTodos () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/relatorios-todos")
    console.log(result)
    console.log(await result2.text())
}

async function resetSenha () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/reset-senha")
    console.log(result)
    console.log(await result2.text())
}

async function visualizarOdontograma () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/visualizar-odontograma")
    console.log(result)
    console.log(await result2.text())
}

async function visualizarTelaAgendamentoOnline () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/visualizar-tela-agendamento-online")
    console.log(result)
    console.log(await result2.text())
}

async function removerVisualizarFicha () 
{
    let result = await fetch("https://localhost:7078/API")
    let result2 = await fetch("https://localhost:7078/API/visualizar-remover-ficha-alinhadores")
    console.log(result)
    console.log(await result2.text())
}