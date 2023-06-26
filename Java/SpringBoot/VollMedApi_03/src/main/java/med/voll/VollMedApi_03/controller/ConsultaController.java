package med.voll.VollMedApi_03.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import jakarta.validation.Valid;
import med.voll.VollMedApi_03.domain.consulta.DadosAgendamentoConsulta;
import med.voll.VollMedApi_03.domain.consulta.DadosDetalhamentoConsulta;

@RestController
@RequestMapping("consultas")
public class ConsultaController {

  @PostMapping
  @Transactional
  public ResponseEntity agendarConsulta(@RequestBody @Valid DadosAgendamentoConsulta dados) {
    System.out.println(dados);
    return ResponseEntity.ok(new DadosDetalhamentoConsulta(null, null, null, null));
  }

}
