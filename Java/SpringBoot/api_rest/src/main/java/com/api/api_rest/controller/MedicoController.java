package com.api.api_rest.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.web.PageableDefault;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.api_rest.medico.DadosAtualizaMedico;
import com.api.api_rest.medico.DadosCadastroMedico;
import com.api.api_rest.medico.DadosListagemMedico;
import com.api.api_rest.medico.Medico;
import com.api.api_rest.medico.MedicoRepository;

import jakarta.validation.Valid;

@RestController
@RequestMapping("medicos")
public class MedicoController {

  @Autowired
  private MedicoRepository repository;

  @PostMapping
  @Transactional
  public void cadastrarMedico(@RequestBody @Valid DadosCadastroMedico dados) {
    repository.save(new Medico(dados));
  }

  @GetMapping
  public Page<DadosListagemMedico> listarMedico(@PageableDefault(size = 10, sort = {"nome"}) Pageable paginacao) {
    return repository.findAllByAtivoTrue(paginacao).map(DadosListagemMedico::new);
  }

  @PutMapping
  @Transactional
  public void atualizarMedico(@RequestBody @Valid DadosAtualizaMedico dados){
    var medico = repository.getReferenceById(dados.id());
    medico.atualizarInformacoesMedico(dados);
  }

  // Para criar uma sub rota dentro de uma rota, passamos como parâmetro a sub rota desejada no Mapping.
  @DeleteMapping("/{id}")
  // Para definirmos uma parâmetro dinâmico na rota, utilizamos as chaves "{ nomeDoParâmetro }".
  @Transactional
  public void excluirMedico(@PathVariable Long id){
    var medico = repository.getReferenceById(id);
    medico.desativarMedico();
  }
}
