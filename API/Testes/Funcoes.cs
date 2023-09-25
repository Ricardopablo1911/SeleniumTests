﻿using System;
using Xunit;

            linkSistema = TestHelpers.linkSistema;

            if (driver.PageSource.Contains("bounce3"))

            //IWebElement carregamento = driver.FindElement(By.XPath("//div[@class='modal-header-div']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='modal-header-div']")));


            Assert.Contains("Tem certeza que deseja excluir o registro selecionado?", driver.PageSource);


            IWebElement ExpAno = driver.FindElement(By.XPath("//*[@id=\"undefined_year-toggle\"]"));



            IWebElement Sexo = driver.FindElement(By.XPath("//span[contains(text(),'Masculino')]"));

            // Obtém todas as janelas abertas
            string janelaAtual = driver.CurrentWindowHandle;
            ICollection<string> todasJanelas = driver.WindowHandles;

            // Alterna para a nova janela
            foreach (string janela in todasJanelas)
            {
                if (janela != janelaAtual)
                {
                    driver.SwitchTo().Window(janela);
                    break;
                }
            }
            IWebElement btnOkSobreposto = driver.FindElement(By.XPath("/html/body/span[2]/div/div[2]/div/div[3]/div/button[2]/div/div[2]"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        }

            new Actions(driver)
            .KeyDown(Keys.PageUp)
            .KeyUp(Keys.PageUp)
            .KeyDown(Keys.PageUp)
            .KeyUp(Keys.PageUp)
            .Perform();
            Thread.Sleep(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", clinicaCaixa);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", clinicaCaixa);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", saldo);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", saldo);
            //IWebElement retirarCaixa = driver.FindElement(By.XPath("//*[@id=\"tippy-tooltip-214\"]"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", retirarCaixa);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", retirarCaixa);
            //IWebElement transbordoCaixa = driver.FindElement(By.XPath("//*[@id=\"tippy-tooltip-215\"]"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", transbordoCaixa);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", transbordoCaixa);
            //IWebElement fecharCaixa = driver.FindElement(By.XPath("//*[@id=\"tippy-tooltip-216\"]"));
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", fecharCaixa);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", fecharCaixa);
            IWebElement Caixa = driver.FindElement(By.XPath("//h3[normalize-space()='Caixa']"));
            IWebElement cC = driver.FindElement(By.XPath("//h3[normalize-space()='Conta Corrente']"));
            IWebElement fluxo = driver.FindElement(By.XPath("//h3[normalize-space()='Fluxo de Caixa']"));
            IWebElement rs = driver.FindElement(By.XPath("//h3[normalize-space()='Recebíveis Sistema']"));
            IWebElement cheques = driver.FindElement(By.XPath("//h3[normalize-space()='Controle de Cheques']"));
            IWebElement boletos = driver.FindElement(By.XPath("//h3[normalize-space()='Controle de Boletos']"));
            IWebElement cartoes = driver.FindElement(By.XPath("//h3[normalize-space()='Controle de Cartões']"));
            IWebElement planos = driver.FindElement(By.XPath("//h3[normalize-space()='Controle de Planos']"));
            IWebElement aPagar = driver.FindElement(By.XPath("//h3[normalize-space()='Contas a Pagar']"));
            IWebElement aReceber = driver.FindElement(By.XPath("//h3[normalize-space()='Contas a Receber']"));
            IWebElement extrato = driver.FindElement(By.XPath("//h3[normalize-space()='Extrato']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", emAberto);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", emAberto);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", agenda);
            agenda.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", selecionarClinica);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", selecionarClinica);
            IWebElement clinicaAuto = driver.FindElement(By.XPath("//div[contains(text(),'Clínica Automação')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", clinicaAuto);
            var print2 = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", clinicaAuto);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", SelecionarAgendaDentista);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", SelecionarAgendaDentista);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", dia);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", BtnMais);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", BtnMais);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", DuploClique);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", DuploClique);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", DuploClique);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", DuploClique);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", next);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", next);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", boxPaciente);
            NovoPaciente.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", boxPaciente);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", boxPaciente);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", boxPaciente);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", boxPaciente);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", PabloAutomacao);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", PabloAutomacao);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", PabloAutomacao);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", PabloAutomacao);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", diaAntes);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", cliniMe);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", whatsApp);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", sms);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", eMail);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", NovoPaciente);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", NovoPaciente);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", boxEmail);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", boxEmail);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", boxTelefone);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", boxTelefone);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", primeiraConsulta);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", comoConheceu);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", comoConheceu);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", facebook);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", facebook);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", boxProcedimento);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", boxProcedimento);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", obs);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", obs);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", categoria);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", categoria);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", SelecionarCategoria);
            var print2 = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", dentista);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", dentista);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", PabloAutomacao);
            var print2 = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", PabloAutomacao);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", horario);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", Agendado);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", Agendado);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", telefone);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", proced);

            Assert.Contains(assercaoObservacao, driver.PageSource);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", obs);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", telefone);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", proced);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", obs);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", deletar);
            var print = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", deletar);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px solid red'", excluir);
            var print2 = ((ITakesScreenshot)driver).GetScreenshot();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='none'", excluir);
            var print3 = ((ITakesScreenshot)driver).GetScreenshot();
            Funcoes.name = name;
            IWebElement expandir = driver.FindElement(By.XPath("//div[@class='itens-center flex info-container'][1]"));
        }

            IWebElement mes = driver.FindElement(By.XPath("//*[@id=\"undefined_month-toggle\"]"));

            IWebElement selecMes = driver.FindElement(By.XPath("//div[contains(text(),'AGO')]"));

            IWebElement ano = driver.FindElement(By.XPath("//*[@id=\"undefined_year-toggle\"]"));


            new Actions(driver)

            IWebElement selectAno = driver.FindElement(By.XPath("//div[contains(text(),'2000')]"));