using ecommerce.application.interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrastructure.services;

public class SenhaService : ISenhaService
{
    private readonly PasswordHasher<object> _passwordHasher;

    public SenhaService()
    {
        _passwordHasher = new PasswordHasher<object>();
    }
    public string GerarHash(string senhaPura)
    {
        if(string.IsNullOrWhiteSpace(senhaPura))
        {
            // É uma boa prática validar os argumentos de entrada.
            throw new ArgumentNullException(nameof(senhaPura), "A senha não pode ser nula ou vazia.");
        }

        // O primeiro argumento 'null' é um espaço reservado para um objeto de usuário,
        // que não é necessário para o algoritmo de hashing padrão.
        return _passwordHasher.HashPassword(null, senhaPura);
    }

    public bool VerificarSenha(string senhaPura, string hash)
    {
        if(string.IsNullOrWhiteSpace(senhaPura) || string.IsNullOrWhiteSpace(hash))
        {
            return false; // Não se pode verificar uma senha ou hash vazio.
        }

        // O método de verificação retorna um enum (PasswordVerificationResult).
        var resultado = _passwordHasher.VerifyHashedPassword(null, hash, senhaPura);

        // Retornamos 'true' apenas se a verificação for um sucesso.
        return resultado == PasswordVerificationResult.Success;

    }
}
