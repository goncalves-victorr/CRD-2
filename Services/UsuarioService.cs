using UsuarioProgram.Models;
using UsuarioProgram.Repositorios;
using System;
using System.Collections.Generic;

namespace UsuarioProgram.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public List<Usuario> ConsultarUsuarios()
        {
            return _usuarioRepositorio.ConsultarTodos();
        }

        public void IncluirUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Incluir(usuario);
        }

        public void ExcluirUsuario(string cpf)
        {
            _usuarioRepositorio.Excluir(cpf);
        }
    }
}
