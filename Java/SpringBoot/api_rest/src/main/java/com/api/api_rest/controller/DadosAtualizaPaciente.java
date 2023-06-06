package com.api.api_rest.controller;

import com.api.api_rest.endereco.DadosEndereco;

import jakarta.validation.constraints.NotNull;

public record DadosAtualizaPaciente(

    @NotNull Long id,
    String nome,
    String telefone,
    DadosEndereco endereco) {

}