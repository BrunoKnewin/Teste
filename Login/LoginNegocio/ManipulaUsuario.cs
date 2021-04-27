using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using LoginNegocio.Tabelas;
using Microsoft.IdentityModel.Tokens;

namespace LoginNegocio
{
    /// <summary>
    /// Manipulador de procedimento voltados ao Usuário
    /// </summary>
    public class ManipulaUsuario : BancoDeDados
    {
        /// <summary>
        /// Realiza login no sistema.
        /// </summary>
        /// <param name="nome">Nome de usário/login</param>
        /// <param name="senha">Senha do Usuário</param>
        /// <returns>Texto com o token de acesso as funcionalidades</returns>
        public string RealizaLogin(string nome, string senha)
        {
            Usuario usuario = new Usuario() { nome = nome, senha = senha };
            if (!TestaUsuario(usuario.nome) || !TestaSenha(usuario))
            {
                return "Nome de usuário ou senha inválido";
            }
            else if (usuario.nome.Length > 0)
            {
                usuario.codigo = RetorneIdUsuarioVMPorNome(usuario.nome);
                return CriaAcesso(usuario);
            }
            return "Erro não mapeado";
        }
        /// <summary>
        /// Verifica se existe este nome de usuário
        /// </summary>
        /// <param name="usuario">Nome de usuário/login</param>
        /// <returns>Verdadeiro se existir</returns>
        private bool TestaUsuario(string usuario)
        {
            return busca.PesquisaT<Usuario>(new Usuario() { nome = usuario }, 1).Where(s => s.nome.Equals(usuario)).Count() > 0;
        }
        /// <summary>
        /// Verifica se a senha está correta
        /// </summary>
        /// <param name="usuario">Modelo de dados de usuário</param>
        /// <returns>Verdadeiro se a senha conferir</returns>
        private bool TestaSenha(Usuario usuario)
        {
            if(usuario.codigo == 0)
            {
                return false;
            }
            Usuario usuarioRetorno = busca.BuscaT<Usuario>(new Usuario() { codigo = usuario.codigo }, 1);
            return usuario.senha == usuarioRetorno.senha;
        }
        /// <summary>
        /// Verifica se a senha está correta
        /// </summary>
        /// <param name="usuario">Modelo de dados de usuário</param>
        /// <returns>Verdadeiro se a senha conferir</returns>
        private long RetorneIdUsuarioVMPorNome(string usuario)
        {
            try
            {
                Usuario usuarioCorrente = new Usuario() { nome = usuario };
                List<Usuario> usuarios = busca.PesquisaT<Usuario>(usuarioCorrente, 1);
                if (usuarios.Count > 0)
                    return usuarios.FirstOrDefault().codigo;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return 0;
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Cria acesso conforme dados de login
        /// </summary>
        /// <param name="login">Modelo de dados usuário</param>
        /// <returns>Token de acesso</returns>
        private string CriaAcesso(Usuario login)
        {
            DateTime dataGeracao = DateTime.Now;
            int dataMilisegundo = dataGeracao.Millisecond;
            int nome = login.nome.GetHashCode();
            int tokenInteiro = (dataMilisegundo.ToString() + nome).GetHashCode();
            Token token = new Token();
            token.ativo = true;
            token.dataSecao = dataGeracao;
            token.codigoToken = GerarToken(tokenInteiro.ToString());
            token = inclui.IncluiT<Token>(token, 1);
            TokensUsuario tokenUsuario = new TokensUsuario();
            tokenUsuario.tokenId = token.codigo;
            tokenUsuario.usuarioId = login.codigo;
            tokenUsuario = inclui.IncluiT<TokensUsuario>(tokenUsuario, 1);
            tokenUsuario.Token = token;
            return token.codigoToken;
        }
        /// <summary>
        /// Gera token conforme dados informados
        /// </summary>
        /// <param name="tokenExterno">dados selecionado para virar Token</param>
        /// <returns>Texto que representa o token</returns>
        private static string GerarToken(string tokenExterno)
        {
            var manipuladorDeToken = new JwtSecurityTokenHandler();
            var senha = Encoding.ASCII.GetBytes("c6f3afa47e33398abb202c38c673d12dacb493f581a65696330e24950b5f2485");
            var desencriptadorToken = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, tokenExterno)
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(senha), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = manipuladorDeToken.CreateToken(desencriptadorToken);
            return manipuladorDeToken.WriteToken(token);
        }
    }
}
