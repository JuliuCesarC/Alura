package com.api.api_rest.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.web.PageableDefault;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

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
    return repository.findAll(paginacao).map(DadosListagemMedico::new);
  }
}
