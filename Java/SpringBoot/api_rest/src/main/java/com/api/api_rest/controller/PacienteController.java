package com.api.api_rest.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.web.PageableDefault;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.api_rest.paciente.DadosCadastroPaciente;
import com.api.api_rest.paciente.DadosListagemPaciente;
import com.api.api_rest.paciente.Paciente;
import com.api.api_rest.paciente.PacienteRepository;

import jakarta.transaction.Transactional;
import jakarta.validation.Valid;

@RestController
@RequestMapping("pacientes")
public class PacienteController {
  @Autowired
  private PacienteRepository repository;

  @PostMapping
  @Transactional
  public void cadastrarPaciente(@RequestBody @Valid DadosCadastroPaciente dados) {
    repository.save(new Paciente(dados));
  }

  @GetMapping
  public Page<DadosListagemPaciente> listarPaciente(@PageableDefault(size = 10, sort = { "nome" }) Pageable paginacao) {
    return repository.findAllByAtivoTrue(paginacao).map(DadosListagemPaciente::new);
  }

  @PutMapping
  @Transactional
  public void atualizaPaciente(@RequestBody @Valid DadosAtualizaPaciente dados) {
    var paciente = repository.getReferenceById(dados.id());
    paciente.atualizarInformacoesPaciente(dados);
  }
  
  @DeleteMapping("/{id}")
  @Transactional
  public void excluirPaciente(@PathVariable Long id){
    var paciente = repository.getReferenceById(id);
    paciente.desativarPaciente();
  }
}