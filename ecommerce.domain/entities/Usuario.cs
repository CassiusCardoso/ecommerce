using ecommerce.domain.valueobjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.domain.entities;

public class Usuario
{
    private Guid Id { get; set; }
    private string Nome { get; set; }
    private Email email { get; set; }
    private Senha senha { get; set; }
    private Cpf cpf  { get; set; }
    private DateTime DataCriacao { get; set; }
    private DateTime DataAtualizacao { get; set; }
    private DateTime? DataExclusao { get; set; }

    private bool Ativo { get; set; } = true;
    public Usuario(Guid id, string nome, string email, string hashDaSenha, string cpf, bool ativo)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        this.email = new Email(email);
        this.senha = Senha.CarregarDoBanco(hashDaSenha); // Criar o VO com o hash
        this.cpf = new Cpf(cpf);
        DataCriacao = DateTime.Now;
        DataAtualizacao = DateTime.Now;
        DataExclusao = null; // Inicialmente não está excluído
        Ativo = ativo;
    }

    // Desativar o Usuário (SEM HARD DELETE)
    public Usuario Desativar()
    {
        return new Usuario(
            Id,
            Nome,
            email.GetEmail(),
            senha.GetSenha(),
            cpf.GetCpf(),
            false // Define como inativo
        )
        {
            DataCriacao = this.DataCriacao,
            DataAtualizacao = DateTime.Now, // Atualiza a data de atualização
            DataExclusao = DateTime.Now // Define a data de exclusão como agora
        };
    }
}
