using System;
using System.Collections.Generic;
using System.Linq;
using UsuarioProgram.Models;

namespace UsuarioProgram.Repositorios
{
    public class UsuarioRepositorio
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public List<Usuario> ConsultarTodos()
        {
            return usuarios;
        }

        public void Incluir(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void Excluir(string cpf)
        {
            Usuario usuario = usuarios.FirstOrDefault(u => u.CPF == cpf);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
            }
        }
    }
}
