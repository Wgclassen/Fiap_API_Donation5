﻿using Fiap.Api.Donation5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        [HttpGet]
        public IList<CategoriaModel> Get()
        {
            return new List<CategoriaModel>()
            {
            new CategoriaModel()
            {
                CategoriaId = 1,
                NomeCategoria = "Celular"
            },
            new CategoriaModel()
            {
                CategoriaId = 2,
                NomeCategoria = "Televisor"
            }
            };
        }

        [HttpGet("{id:int}")]
        public CategoriaModel Get([FromRoute] int id)
        {
            return new CategoriaModel()
            {
                CategoriaId = 1,
                NomeCategoria = "Celular"
            };
        }

        [HttpPost]
        public int Post([FromBody] CategoriaModel categoriaModel)
        {
            return 1311;
        }

        [HttpPut("{id:int}")]
        public int Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            return 1311;
        }

        [HttpDelete("{id:int}")]
        public int Delete([FromRoute] int id)
        {
            return 1333;
        }
    }
}
