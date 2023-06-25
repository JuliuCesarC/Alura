package med.voll.VollMedApi_03.controller;

import io.swagger.v3.oas.annotations.security.SecurityRequirement;
import jakarta.validation.Valid;
import med.voll.VollMedApi_03.domain.consulta.AgendaDeConsultas;
import med.voll.VollMedApi_03.domain.consulta.DadosAgendamentoConsulta;
import med.voll.VollMedApi_03.domain.consulta.DadosCancelamentoConsulta;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("consultas")
public class ConsultaController {

  @PostMapping
  @Transactional
  public ResponseEntity agendar(@RequestBody @Valid DadosAgendamentoConsulta dados) {
    System.out.println(dados);
    return ResponseEntity.ok(new DadosDetalhamentoConsulta(null, null, null, null));
  }

}
