package com.api.api_rest.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.api_rest.paciente.DadosCadastroPaciente;
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
}
