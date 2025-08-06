using ecommerce.application.dto.request.usuario;
using ecommerce.application.dto.response.usuario;
using ecommerce.application.interfaces;
using ecommerce.application.mapper;
using ecommerce.domain.repositories;
using ecommerce.domain.valueobjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.application.usecases.Usuario;

public class CriarUsuarioUseCase
{
    private readonly ISenhaService _senhaService;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly UsuarioMapper _usuarioMapper;


    public CriarUsuarioUseCase(ISenhaService senhaService, IUsuarioRepository usuarioRepository, UsuarioMapper usuarioMapper)
    {
        _senhaService = senhaService ?? throw new ArgumentNullException(nameof(senhaService));
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        _usuarioMapper = usuarioMapper ?? throw new ArgumentNullException(nameof(usuarioMapper));
    }

    public UsuarioResponse Executar(CadastrarUsuarioRequest request)
    {
        // Buscar um usuário pelo email
        var usuarioExistente = _usuarioRepository.BuscarPorEmail(request.Email);
        if (usuarioExistente != null)
        {
            throw new InvalidOperationException("Já existe um usuário cadastrado com este email.");
        }
    }
