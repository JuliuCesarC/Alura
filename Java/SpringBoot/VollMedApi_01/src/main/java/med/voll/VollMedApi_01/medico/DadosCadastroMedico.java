package med.voll.VollMedApi_01.medico;

import med.voll.VollMedApi_01.endereco.DadosEndereco;

public record DadosCadastroMedico(String nome, String email, String telefone, String crm, Especialidade especialidade, DadosEndereco endereco) {
}