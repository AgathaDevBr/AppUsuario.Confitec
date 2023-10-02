using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Services.Middlewares.Exceptions
{
    public class UsuarioNaoEncontradoException : Exception
    {
        public override string Message
            => @"Usuário não encontrado.";
    }
}
