﻿using System;
using API.Models;
using Exemplo_2.Helpers;

namespace API.Controllers

    public class APIController : ControllerBase

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
        }

        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]


        [HttpGet]


        [HttpGet]


        [HttpGet]


        [HttpGet]


        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]


        [HttpGet]


        [HttpGet]


        [HttpGet]


        [HttpGet]

        [HttpGet]


        [HttpGet]


        [HttpGet]


        [HttpGet]

        [HttpGet]

        [HttpGet]

        [HttpGet]


        [HttpGet]


    }