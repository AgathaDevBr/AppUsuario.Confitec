using ApiUsuarios.Data.Entities;
using ApiUsuarios.Data.Interfaces;
using ApiUsuarios.Services.Middlewares.Exceptions;
using ApiUsuarios.Services.Models;
using ApiUsuarios.Services.Models.Request;
using ApiUsuarios.Services.Models.Response;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salesforce.Common.Models.Json;
using System.Globalization;

namespace ApiUsuarios.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository? _usuarioRepository;
        private readonly IEscolaridadeRepository? _escolaridadeRepository;
        private readonly IMapper? _mapper;

        public UsuarioController(IUsuarioRepository? usuarioRepository, IMapper? mapper, 
            IEscolaridadeRepository? escolaridadeRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _escolaridadeRepository = escolaridadeRepository;
        }

        /// <summary>
        /// Serviço para cadastro de usuários.
        /// </summary>
        [HttpPost]
        [Route("adicionar-usuario")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResult), 400)]
        public IActionResult AdicionarUsuario(UsuarioCreateRequest request)
        {
            TimeSpan diferenca = DateTime.Now - request.DataNascimento.Value;
            int idade = (int)diferenca.TotalDays / 365;

            if (idade >= 15)
            {
                var response = new UsuarioResponse();

                if (_usuarioRepository.GetByEmail(request.Email) != null)
                    throw new EmailJaCadastradoException();

                var usuario = new UsuarioEntity
                {
                    IdEscolaridade = request.IdEscolaridade,
                    Nome = request.Nome,
                    SobreNome = request.Sobrenome,
                    Email = request.Email,
                    DataNascimento = request.DataNascimento,
                };

                _usuarioRepository?.Add(usuario);

                var usuarioResponse = new UsuarioViewModel
                {
                    IdEscolaridade = usuario.IdEscolaridade,
                    Nome = usuario.Nome,
                    SobreNome = usuario.SobreNome,
                    Email = usuario.Email,
                    DataNascimento = request.DataNascimento,
                    Escolaridade = _escolaridadeRepository.GetEscolaridadeById(usuario.IdEscolaridade)
                };

                response.Status = 201;
                response.Mensagem = "Usuário cadastrado com sucesso.";
                response.Usuario = usuarioResponse;

                return StatusCode(response.Status.Value, response);
            }
            else
            {
                throw new IdadeException();
            }
           
        }

        /// <summary>
        /// Serviço para atualização de usuários.
        /// </summary>
        [HttpPut]
        [Route("atualizar-usuario")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), 404)]
        public IActionResult AtualizarUsuario(UsuarioUpdateRequest request)
        {
            var usuario = _usuarioRepository?.GetById(request.IdUsuario);

            if(usuario != null)
            {
                TimeSpan diferenca = DateTime.Now - request.DataNascimento;
                int idade = (int)diferenca.TotalDays / 365;

                if (idade >= 15)
                {
                    var response = new UsuarioResponse();

                    usuario.Nome = request.Nome;
                    usuario.SobreNome = request.Sobrenome;
                    usuario.Email = request.Email;
                    usuario.DataNascimento = request.DataNascimento;
                    usuario.IdEscolaridade = request.IdEscolaridade;

                    _usuarioRepository?.Update(usuario);

                    var usuarioResponse = new UsuarioViewModel
                    {
                        IdEscolaridade = usuario.IdEscolaridade,
                        Nome = usuario.Nome,
                        SobreNome = usuario.SobreNome,
                        Email = usuario.Email,
                        DataNascimento = request.DataNascimento,
                        Escolaridade = _escolaridadeRepository.GetEscolaridadeById(usuario.IdEscolaridade)
                    };

                    response.Status = 200;
                    response.Mensagem = "Usuário atualizado com sucesso.";
                    response.Usuario = usuarioResponse;

                    return StatusCode(response.Status.Value, response);
                }
                else
                {
                    throw new IdadeException();
                }
            }
            else
            {
                throw new UsuarioNaoEncontradoException();
            }
           

        }

        /// <summary>
        /// Serviço para excluir usuários.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
        public IActionResult DeletarUsuario(int id)
        {
            var usuario = _usuarioRepository?.GetById(id);

            if (usuario != null)
            {
                var response = new UsuarioResponse();

                _usuarioRepository?.Delete(usuario);

                response.Status = 200;
                response.Mensagem = "Usuário excluído com sucesso.";
                //response.Usuario = _mapper?.Map<UsuarioViewModel>(usuario);
                return StatusCode(response.Status.Value, response);
            }
            else
            {
                throw new UsuarioNaoEncontradoException();
            }

        }

        /// <summary>
        /// Serviço para listar todos usuários.
        /// </summary>
        [HttpGet]
        [Route("listar-usuarios")]
        [ProducesResponseType(typeof(List<UsuarioViewModel>), StatusCodes.Status200OK)]
        public IActionResult ListaTodosUsuarios()
        {
            var usuario = _usuarioRepository?.GetAll().ToList();

            return StatusCode(200, usuario);
        }

        /// <summary>
        /// Serviço para listar todas escolaridades.
        /// </summary>
        [HttpGet]
        [Route("listar-escolaridades")]
        [ProducesResponseType(typeof(List<EscolaridadeViewModel>), StatusCodes.Status200OK)]
        public IActionResult ListaEscolaridades()
        {
            var escolaridade = _escolaridadeRepository?.GetEscolaridade().ToList() ;

            return StatusCode(200, escolaridade);
        }

        /// <summary>
        /// Serviço para listar apenas um usuário por id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EscolaridadeViewModel), StatusCodes.Status200OK)]
        public IActionResult ListaUsuario(int id)
        {
            if(id != null)
            {
               var usuario = _usuarioRepository?.GetById(id);
               return StatusCode(200, usuario);
            }
            else
            {
                throw new UsuarioNaoEncontradoException();
            }
        }



    }
}
