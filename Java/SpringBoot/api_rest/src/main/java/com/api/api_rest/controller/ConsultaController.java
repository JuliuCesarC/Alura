package com.api.api_rest.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.api.api_rest.domain.consulta.AgendaDeConsultas;
import com.api.api_rest.domain.consulta.DadosAgendamentoConsulta;
import com.api.api_rest.domain.consulta.DadosCancelamentoConsulta;
import com.api.api_rest.domain.consulta.DadosDetalhamentoConsulta;

import jakarta.transaction.Transactional;
import jakarta.validation.Valid;

@RestController
@RequestMapping("consultas")
public class ConsultaController {

  @Autowired
  private AgendaDeConsultas agenda;

  @PostMapping
  @Transactional
  public ResponseEntity agendar(@RequestBody @Valid DadosAgendamentoConsulta dados) {
    agenda.agendar(dados);

    return ResponseEntity.ok(new DadosDetalhamentoConsulta(null, null, null, null));
  }

  @DeleteMapping
  @Transactional
  public ResponseEntity cancelar(@RequestBody @Valid DadosCancelamentoConsulta dados) {
    agenda.cancelar(dados);
    return ResponseEntity.noContent().build();
  }
}
