package com.api.api_rest.domain.consulta;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.api.api_rest.domain.ValidacaoException;
import com.api.api_rest.domain.medico.Medico;
import com.api.api_rest.domain.medico.MedicoRepository;
import com.api.api_rest.domain.paciente.PacienteRepository;

@Service
public class AgendaDeConsultas {

  @Autowired
  private ConsultaRepository consultaRepository;

  @Autowired
  private MedicoRepository medicoRepository;

  @Autowired
  private PacienteRepository pacienteRepository;

  public void agendar(DadosAgendamentoConsulta dados) {
    if (!pacienteRepository.existsById(dados.idPaciente())) {
      throw new ValidacaoException("Id do paciente não encontrado, ou paciente não cadastrado.");
    }
    if (dados.idMedico() != null && !medicoRepository.existsById(dados.idMedico())) {
      throw new ValidacaoException("Id do medico não encontrado.");
    }

    var paciente = pacienteRepository.findById(dados.idPaciente()).get();
    var medico = escolherMedico(dados);

    var consulta = new Consulta(null, medico, paciente, dados.data());

    System.out.println("\nConsulta: " + consulta);
    // consultaRepository.save(consulta);

  }

  private Medico escolherMedico(DadosAgendamentoConsulta dados) {
        if (dados.idMedico() != null) {
            return medicoRepository.getReferenceById(dados.idMedico());
          }
          
          if (dados.especialidade() == null) {
            throw new ValidacaoException("Especialidade é obrigatória no caso do médico não ser escolhido.");
          }
          
          return medicoRepository.getReferenceById(Long.parseLong("2"));
        // return medicoRepository.escolherMedicoAleatorioLivreNaData(dados.especialidade(), dados.data());
    }
}
