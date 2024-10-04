using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Postech.Hackaton.Application.Services
{
    public class TokenService : ITokenService
    {
        public string GetToken(UsuarioPaciente paciente)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var privateKey = Encoding.ASCII.GetBytes("-PostechHackaton-FinalmenteTeminou-");

            var securityTokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new(ClaimTypes.Name, paciente.Email),
                        new(ClaimTypes.Role, "PACIENTE")

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(securityTokenDescritor);
            return jwtTokenHandler.WriteToken(token);
        }

        public string GetToken(UsuarioMedico medico)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var privateKey = Encoding.ASCII.GetBytes("-PostechHackaton-FinalmenteTeminou-");

            var securityTokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new(ClaimTypes.Name, medico.Email),
                        new(ClaimTypes.Role, "MEDICO")

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(securityTokenDescritor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
