package med.voll.VollMedApi_01.endereco;

public record DadosEndereco(String logradouro, String bairro, String cep, String cidade, String uf, String complemento, String numero) {
  // A classe Record facilita a criação de DTOs, pois ja possui implementação dos métodos getters e setters por baixo dos panos.
}
