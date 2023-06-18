package med.voll.VollMedApi_02.paciente;

import jakarta.validation.constraints.NotNull;
import med.voll.VollMedApi_02.endereco.DadosEndereco;

public record DadosAtualizacaoPaciente(
        @NotNull
        Long id,
        String nome,
        String telefone,
        DadosEndereco endereco) {
}
