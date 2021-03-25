using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuairo
        [HttpGet]
        [Route("api/Usuario")]
        public IHttpActionResult GetAllUsuario()
        {
            ML.Result result = BL.Usuario.GetAllUsuario();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Usuairo/5
        [HttpGet]
        [Route("api/Usuario/{IdUsuario}")]
        public IHttpActionResult GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdUsuario(IdUsuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Usuairo
        [HttpPost]
        [Route("api/Usuario")]
        public IHttpActionResult AddUsuario([FromBody] ML.Usuario Usuario)
        {
            ML.Result result = BL.Usuario.AddUsuario(Usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Usuairo/5
        [HttpPut]
        [Route("api/Usuario/{IdUsuario}")]
        public IHttpActionResult UpdateUsuario(int IdUsuario, [FromBody] ML.Usuario Usuario)
        {
            Usuario.IDUsuario = IdUsuario;
            ML.Result result = BL.Usuario.UpdateUsuario(Usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Usuairo/5
        [HttpDelete]
        [Route("api/Usuario/{IdUsuario}")]
        public IHttpActionResult DeleteUsuario(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteUsuario(IdUsuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
