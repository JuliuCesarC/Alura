import { DealingList } from "../models/DealingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";
import { MessageAdd } from "../views/Message_add.js";
import { DaysOfWeek } from "../enums/DaysOfWeek.js";
import { LogRuntime } from "../decorators/LogRuntime.js";
import { Inspect } from "../decorators/Inspect.js";
import { DomInjector } from "../decorators/DomInjector.js";
import { DealingDay } from "../interface/DealingDay.js";
import { DealingService } from "../services/DealingService.js";

export class Controller {
  @DomInjector("#data")
  private inputDate: HTMLInputElement;
  @DomInjector("#quantidade")
  private inputAmount: HTMLInputElement;
  @DomInjector("#valor")
  private inputValue: HTMLInputElement;
  private dealingList = new DealingList();
  private dealingView = new Dealing_view("#dealingView");
  private messageView = new MessageAdd("#messageView");
  private dealingService = new DealingService()

  constructor() {
    this.dealingView.update(this.dealingList);
  }
  @LogRuntime()
  @Inspect()
  public addToList(): void {
    const dealingList = Dealing.createDealing(
      this.inputDate.value,
      this.inputAmount.value,
      this.inputValue.value
    );
    if (!this.isBusinessDay(dealingList.date)) {
      this.messageView.update("Apenas negociações em dias uteis.");
      return;
    }

    this.dealingList.addDealing(dealingList);
    this.updateView();
    this.clearForm();
  }
  // -------------------- Exe 03 --------------------
  public importData(): void {
    // Criamos um serviço com o 'fetch' para que caso seja necessário chamar essa api em outros lugares, não seja necessário repetir os mesmos códigos.
    // Assim como no exercício 2, podemos alterar o nome do método 'getDealing' utilizando o alterar simbolo(F2), que automaticamente ele sera atualizado onde o método foi chamado.
      this.dealingService.getDealing()
      .then((dealingNow) => {
        for (let dealing of dealingNow) {
          this.dealingList.addDealing(dealing);
        }
        this.dealingView.update(this.dealingList);
      });
  }
  // -------------------- Exe 02 --------------------
  public importData_exe_02(): void {
    fetch("http://localhost:8080/dados")
      .then((res) => res.json())
      // No exercício 1 definimos o 'data' abaixo como um array any, porem isso cria um problema, caso tenha algum erro de gramatica o TypeScript não tem como saber, somente em runtime saberemos desse problema.
      // Para corrigir isto podemos utilizar um 'interface' com os parâmetros corretos.
      // Além disso temos outro enorme beneficio, caso no backend seja alterado o nome de algum campo, é preciso apenas alterar o nome do simbolo no 'interface' que ele ira automaticamente alterar o nome em todos os lugares onde foi chamado.
      // OBS: é possível alterar o simbolo clicando nele e utilizando a tecla 'F2'.
      .then((data: DealingDay[]) => {
        return data.map((dataNow) => {
          return new Dealing(new Date(), dataNow.vezes, dataNow.montante);
        });
      })
      .then((dealingNow) => {
        for (let dealing of dealingNow) {
          this.dealingList.addDealing(dealing);
        }
        this.dealingView.update(this.dealingList);
      });
  }
  // -------------------- Exe 01 --------------------
  public importData_exe_01(): void {
    // Neste projeto temos uma api fornecendo dados de negociações que iremos utilizar.
    fetch("http://localhost:8080/dados")
      // Após fazer um fetch precisamos executar as 2 promises.
      .then((res) => res.json())
      .then((data: any[]) => {
        // Precisamos retornar o 'data.map' para ao final dessa promise, podermos executar um novo then onde iremos inserir esses dados na tabela.
        return data.map((dataNow) => {
          return new Dealing(new Date(), dataNow.vezes, dataNow.montante);
          // Retornamos uma nova negociação para cada objeto do Json.
        });
      })
      .then((dealingNow) => {
        // Precisamos adicionar cada nova negociação na lista de negociações. Para isso utilizamos um loop com o array vindo da promise acima.
        for (let dealing of dealingNow) {
          this.dealingList.addDealing(dealing);
        }
        // Após adicionarmos as negociações na lista, atualizamos na tela a nova lista de negociações.
        this.dealingView.update(this.dealingList);
      });
  }
  private isBusinessDay(date: Date) {
    return (
      date.getDay() > DaysOfWeek.SUNDAY && date.getDay() < DaysOfWeek.SATURDAY
    );
  }
  private clearForm(): void {
    this.inputDate.value = "";
    this.inputAmount.value = "";
    this.inputValue.value = "";
    this.inputDate.focus();
  }
  private updateView(): void {
    this.dealingView.update(this.dealingList);
    this.messageView.update("Negociação adicionada com sucesso.");
  }
}
