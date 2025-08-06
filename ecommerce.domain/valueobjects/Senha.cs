using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain.valueobjects;

public class Senha
{
    public string Hash { get; private set; }
    
    private Senha(string hash) // Construtor é privado para forçar o uso dos métodos de fábrica (factory methods)

    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new ArgumentException("O hash da senha não pode ser vazio.");

        Hash = hash;
    }

    // Método de fábrica para carregar uma senha que JÁ EXISTE no banco
    public static Senha CarregarDoBanco(string hash)
    {
        return new Senha(hash);
    }

    // Método estático para validar o formato da senha em texto puro
    public static void ValidarFormato(string senhaPura)
    {
        string regexSenha = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$"; // Mínimo 6 caracteres, uma letra e um número.
        
        if(string.IsNullOrWhiteSpace(senhaPura))
            throw new ArgumentException("Formato de senha inválido. A senha deve ter no mínimo 6 caracteres, com pelo menos uma letra e um número.");
    }

    public string GetSenha() => Hash;
}
