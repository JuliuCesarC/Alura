package com.api.api_rest.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.api_rest.medico.DadosCadastroMedico;
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
  public void cadastrar(@RequestBody @Valid DadosCadastroMedico dados){
    repository.save(new Medico(dados));
  }
}
