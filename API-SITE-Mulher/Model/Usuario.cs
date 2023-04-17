﻿using API_SITE_Mulher.Enum;
using API_SITE_Mulher.Model.Base;

namespace API_SITE_Mulher.Model
{
    public class Usuario : BaseEntity
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Apelido { get; set; }
        public Roles Role { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
