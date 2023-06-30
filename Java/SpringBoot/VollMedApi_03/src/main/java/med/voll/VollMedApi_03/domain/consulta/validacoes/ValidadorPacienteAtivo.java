package med.voll.VollMedApi_03.domain.consulta.validacoes;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import med.voll.VollMedApi_03.domain.ValidacaoException;
import med.voll.VollMedApi_03.domain.consulta.DadosAgendamentoConsulta;
import med.voll.VollMedApi_03.domain.paciente.PacienteRepository;

@Component
public class ValidadorPacienteAtivo implements ValidadorAgendamentoDeConsulta {

  @Autowired
  private PacienteRepository repository;

  public void validar(DadosAgendamentoConsulta dados) {
    var pacienteEstaAtivo = repository.findAtivoById(dados.idPaciente());
    // Temos a mesma situação do médico ativo, buscamos no banco de dados o campo "ativo" do paciente, e inserimos na variável a valor do campo.
    if (!pacienteEstaAtivo) {
      // Caso o paciente estava inativo, bloqueamos de agendar a consulta.
      throw new ValidacaoException("Consulta não pode ser agendada com paciente excluído");
    }
  }
}
