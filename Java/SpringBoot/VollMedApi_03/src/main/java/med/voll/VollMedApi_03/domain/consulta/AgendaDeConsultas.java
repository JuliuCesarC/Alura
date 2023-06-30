package med.voll.VollMedApi_03.domain.consulta;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import med.voll.VollMedApi_03.domain.ValidacaoException;
import med.voll.VollMedApi_03.domain.consulta.validacoes.ValidadorAgendamentoDeConsulta;
import med.voll.VollMedApi_03.domain.medico.Medico;
import med.voll.VollMedApi_03.domain.medico.MedicoRepository;
import med.voll.VollMedApi_03.domain.paciente.PacienteRepository;

@Service
public class AgendaDeConsultas {

  @Autowired
  private ConsultaRepository consultaRepository;

  @Autowired
  private MedicoRepository medicoRepository;

  @Autowired
  private PacienteRepository pacienteRepository;

  @Autowired
  private List<ValidadorAgendamentoDeConsulta> validadoresAgendar;

  public DadosDetalhamentoConsulta agendar(DadosAgendamentoConsulta dados) {
    if (!pacienteRepository.existsById(dados.idPaciente())) {
      throw new ValidacaoException("Id do paciente não encontrado, ou paciente não cadastrado.");
    }
    if (dados.idMedico() != null && !medicoRepository.existsById(dados.idMedico())) {
      throw new ValidacaoException("Id do medico não encontrado.");
    }

    validadoresAgendar.forEach(v -> v.validar(dados));

    var medico = medicoRepository.findById(dados.idMedico()).get();
    var paciente = pacienteRepository.getReferenceById(dados.idPaciente());
    if (medico == null) {
      throw new ValidacaoException("Não existe médico disponível neste horário");
    }
    var consulta = new Consulta(null, medico, paciente, dados.data(), null);

    consultaRepository.save(consulta);
    return new DadosDetalhamentoConsulta(consulta);
  }

  private Medico escolherMedico(DadosAgendamentoConsulta dados) {
    if (dados.idMedico() != null) {
      return medicoRepository.getReferenceById(dados.idMedico());
    }

    if (dados.especialidade() == null) {
      throw new ValidacaoException("Especialidade é obrigatória no caso do médico não ser escolhido.");
    }

    return medicoRepository.escolherMedicoAleatorioLivreNaData(dados.especialidade(), dados.data());
  }
}
