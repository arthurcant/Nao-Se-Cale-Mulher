﻿using API_SITE_Mulher.Configuration;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Enum;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Services;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Data.FillingEntities
{
    public class FillingEntity : ControllerBase
    {
        private IUsersRepository _repository;
        private readonly ITokenService _tokenService;
        private TokenConfiguration _configuration;

        public FillingEntity(IUsersRepository repository, ITokenService tokenService, TokenConfiguration configuration)
        {
            _repository = repository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public tb_usuario FillingEntityTbUsuario(UsuarioRegisterVO usuarioRegisterVO)
        {
            tb_usuario tbUsuario = new tb_usuario();
            tbUsuario.NomeCompleto = usuarioRegisterVO.NomeCompleto;
            tbUsuario.Senha = _repository.ComputerHash(usuarioRegisterVO.Senha, new SHA256CryptoServiceProvider());
            tbUsuario.Email = usuarioRegisterVO.Email;
            tbUsuario.Apelido = usuarioRegisterVO.Apelido;
            tbUsuario.Role = (int)Roles.Voluntario;
            tbUsuario.RefreshToken = _tokenService.GenerateRefreshToken();
            tbUsuario.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            return tbUsuario;
        }

        public tb_poster FillingEntityTbPoster(PosterRegisterVO posterRegisterVO)
        {
            tb_poster tbPoster = new tb_poster();
            tbPoster.Titulo = posterRegisterVO.Titulo;
            tbPoster.Descricao = posterRegisterVO.Descricao;
            tbPoster.Conteudo = posterRegisterVO.Conteudo;
            tbPoster.DataDaPublicacao = DateTime.Now;
            var email = User.Identity.Name;
            tbPoster.Autor = _repository.ValidateCredentials(email);
            tbPoster.Id_usuario = tbPoster.Autor.Id;

            foreach (var item in posterRegisterVO.Tags)
            {
                tbPoster.tb_Detalhes_Do_Poster.tb_Categoria_De_Posteres.Add(item);
            }

            return tbPoster;   
        }

    }
}
