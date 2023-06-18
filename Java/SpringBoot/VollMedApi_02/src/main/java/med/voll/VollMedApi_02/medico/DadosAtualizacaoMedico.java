package med.voll.VollMedApi_02.medico;

import jakarta.validation.constraints.NotNull;
import med.voll.VollMedApi_02.endereco.DadosEndereco;

public record DadosAtualizacaoMedico(
    @NotNull Long id,
    String nome,
    String telefone,
    DadosEndereco endereco) {
}
