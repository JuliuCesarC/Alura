package med.voll.VollMedApi_01.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import jakarta.validation.Valid;
import med.voll.VollMedApi_01.medico.DadosCadastroMedico;
import med.voll.VollMedApi_01.medico.Medico;
import med.voll.VollMedApi_01.medico.MedicoRepository;

@RestController
// Indica para o Sprign que esta classe é um controller.
@RequestMapping("medicos")
// Seta o caminho na url para essa classe.
public class MedicoController {

  @Autowired
  private MedicoRepository repository;

  @PostMapping
  // Define o verbo para este método
  @Transactional
  // Abre uma transação sql quando executa esse método.
  public void cadastrarMedico(@RequestBody @Valid DadosCadastroMedico dados) {
    System.out.println(dados);
    repository.save(new Medico(dados));
  }

  // @GetMapping
  // public Page<DadosListagemMedico> listar(@PageableDefault(size = 10, sort =
  // {"nome"}) Pageable paginacao) {
  // return
  // repository.findAllByAtivoTrue(paginacao).map(DadosListagemMedico::new);
  // }

  // @PutMapping
  // @Transactional
  // public void atualizar(@RequestBody @Valid DadosAtualizacaoMedico dados) {
  // var medico = repository.getReferenceById(dados.id());
  // medico.atualizarInformacoes(dados);
  // }

  // @DeleteMapping("/{id}")
  // @Transactional
  // public void excluir(@PathVariable Long id) {
  // var medico = repository.getReferenceById(id);
  // medico.excluir();
  // }

}
