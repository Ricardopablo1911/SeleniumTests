﻿using Xunit;

namespace Exemplo_2.Testes
            {

                Funcoes.PaginaInicial(driver, "PaginaInicial", "AgendaBtn+", " Não consegui encontrar o seja bem vindo na página inicial.");

                Funcoes.Login(driver, "pablo@qms", "Pr102030!", "AgendaBtn+", "Senha", "TelaInicial", "AgendaBtn+", " Não consegui efetuar o login no sistema.");

                Funcoes.AssercaoLogin(driver, "ConfirmaMenu", "AgendaBtn+", "Não consegui encontrar os ícones do menu inicial.");

                Funcoes.JanelaAgenda(driver, "JanelaAgenda", "AgendaBtn+", "Não consegui clicar no ícone para abrir a agenda.");

                Funcoes.SelecionarClinicaAgenda(driver, "SelecionarClinica", "VerClinicas", "AgendaBtn+", "Não consegui selecionar a clinica na agenda.");

                Funcoes.SelecionarDentistaAgenda(driver, "SelecionarDentista", "AgendaBtn+", "Não consegui selecionar o dentista na agenda.");

                Funcoes.VisualizarAgendaDia(driver, "AgendaDia", "AgendaBtn+", "Não consegui visualizar a agenda por dia.");

                Funcoes.Btn_Mais(driver, "BtnMais", "AgendaBtn+", "Não consegui visualizar a tela de novo agendamento.");

                Funcoes.PacienteNovo(driver, "PacienteNovo", "AgendaBtn+", "Não consegui pesquisar o paciente na agenda.");

                Funcoes.SelecionarPacienteNovo(driver, "SelecionarPacienteNovo", "AgendaBtn+", "Não consegui selecionar um paciente novo na agenda.");

                Funcoes.PacienteEmail(driver, "EmailAgenda", "AgendaBtn+", "Não consegui inerir o e-mail do paciente.");

                Funcoes.PacienteTelefone(driver, "TelefoneAgenda", "AgendaBtn+", "Não consegui inserir o telefone do paciente.");

                Funcoes.PrimeiraConsulta(driver, "SelecionarPrimeiraConsulta", "ComoConheceu", "AgendaBtn+", "Não consegui habilitar a opção de primeira consulta.");

                Funcoes.ProcedimentosAgenda(driver, "InserirProcedimento", "Primeiro agendamento do paciente novo", "AgendaBtn+", "Não consegui inserir o procedimento ao agendar o horário.");

                Funcoes.ObservacaoAgenda(driver, "InserirObservacao", "Observação paciente novo", "AgendaBtn+", "Não consegui inserir a observação ao agendar o horário.");

                Funcoes.SelecionarCategoria(driver, "VerCategorias", "CategoriaSelecionada", "AgendaBtn+", "Não consegui inserir a observação ao agendar o horário.");

                Funcoes.SelecionarProfissionalAgenda(driver, "VerProfissionais", "DentistaSelecionado", "AgendaBtn+", "Não consegui inserir a observação ao agendar o horário.");

                Funcoes.SelecionarHorario(driver, "SelecionarHorario", "AgendaBtn+", "Não consegui selecionar o horário na agenda.");

                Funcoes.ConcluirAgendamento(driver, "ConcluirAgendamento", "AgendaBtn+", "Não consegui concluir o agendamento.");

                Funcoes.VerAgendamento(driver, "VerAgendamento", "AgendaBtn+", "Não consegui concluir o agendamento.", "Primeiro agendamento do paciente novo", "Observação paciente novo", "(47) 99628-0417");

                Funcoes.ExcluirAgendamento(driver, "ExcluirAgendamento", "ConfirmaExclusao", "AgendamentoExcluido", "AgendaBtn+", "Não consegui Excluir o agendamento.");

                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);
                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string outputStr = "O tempo que levou para concluir o teste foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");


                string filePath = pasta + "" + "AgendaBtn+" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();
               


            }
            catch (Exception e)
            {

                printScreen(driver, "Erro", "AgendaBtn+");
                sendMessage("Erro em teste [Agenda.Agendamento Profissional.Agendar botao +]", e.Message + Funcoes.body.ToString(), Agendar_Botao_Mais.name);
                DateTime endTime = DateTime.Now;

                double duration = (endTime - startTime).TotalSeconds;
                int minutes = (int)(duration / 60);
                int seconds = (int)(duration % 60);


                string dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                string outputStr = "O tempo que levou até o teste falhar foi de: " + string.Format("{0:00}:{1:00}, {2}\n", minutes, seconds, dateTimeStr + "\n");

                string filePath = pasta + "" + "AgendaBtn+" + "/" + "tempo_de_teste.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(outputStr);
                }


                driver.Quit();
               
            }







        }