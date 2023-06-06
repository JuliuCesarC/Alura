package com.api.api_rest.medico;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

// O primeiro tipo no JpaRepository é a classe que ele vai trabalhar, e o segundo é o tipo da chave primaria dessa entidade, no caso para a classe Médico o id foi setado como "Long".
public interface MedicoRepository extends JpaRepository<Medico, Long> {

  Page<Medico> findAllByAtivoTrue(Pageable paginacao);
}
