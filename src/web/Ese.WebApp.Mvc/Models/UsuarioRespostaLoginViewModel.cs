﻿namespace Ese.WebApp.Mvc.Models
{
    public class UsuarioRespostaLoginViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
        public ResponseResultViewModel ResponseResult { get; set; }
    }
}
