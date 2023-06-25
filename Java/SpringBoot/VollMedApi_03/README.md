# Curso 3 projeto de api Voll Med

Esta formação busca ensinar desde a criação de um projeto com Spring Boot, passando por segurança, testes automatizados e por fim o build. A ideia é criar uma api para a empresa fictícia Voll Med, que é uma clinica que precisa de um sistema para gerenciar as consultas.

É necessario os arquivos do curso anterior para continuidade deste curso.

## Adicionando controller para consultas

A primeira funcionalidade que vamos implementar sera a de agendar consultas, e de praxe começaremos por adicionar o controller. No pacote `controller` vamos criar a classe `ConsultaController`, com as anotações ja vista anteriormente.

```java
@RestController
@RequestMapping("consultas")
public class ConsultaController {}
```

E o verbo que vamos mapear sera o POST.
