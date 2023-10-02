using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Services.Middlewares.Exceptions
{
    public class IdadeException : Exception
    {
        public override string Message
            => @"Idade menor que 15 anos não é permitido.";
    }
}
