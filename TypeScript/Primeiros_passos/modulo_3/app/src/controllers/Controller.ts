import { DealingList } from "../models/DealingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";
import { MessageAdd } from "../views/Message_add.js";
import { DaysOfWeek } from "../enums/DaysOfWeek.js";
import { LogRuntime } from "../decorators/LogRuntime.js";

export class Controller {
  private inputDate: HTMLInputElement;
  private inputAmount: HTMLInputElement;
  private inputValue: HTMLInputElement;
  private dealingList = new DealingList();
  private dealingView = new Dealing_view("#dealingView", true);
  private messageView = new MessageAdd("#messageView");

  constructor() {
    this.inputDate = <HTMLInputElement>document.querySelector("#data");
    this.inputAmount = document.querySelector("#quantidade") as HTMLInputElement;
    this.inputValue = document.querySelector("#valor") as HTMLInputElement;
    this.dealingView.update(this.dealingList);
  }
  @LogRuntime()
  public addToList(): void {
    const dealingList = Dealing.createDealing(
      this.inputDate.value,
      this.inputAmount.value,
      this.inputValue.value,
      )
      
      if (!this.isBusinessDay(dealingList.date)) {
        this.messageView.update("Apenas negociações em dias uteis.");
        return;
      }
      
      this.dealingList.addDealing(dealingList);
      this.updateView();
      this.clearForm();
    }
    private isBusinessDay(date: Date) {
      return date.getDay() > DaysOfWeek.SUNDAY && date.getDay() < DaysOfWeek.SATURDAY;
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
