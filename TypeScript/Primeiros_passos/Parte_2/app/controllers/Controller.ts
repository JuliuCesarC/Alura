import { DealingList } from "../models/DealingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";
import { MessageAdd } from "../views/Messge_add.js";

export class Controller {
  private inputDate: HTMLInputElement;
  private inputAmount: HTMLInputElement;
  private inputValue: HTMLInputElement;
  private dealingList = new DealingList();
  private dealingView = new Dealing_view("#dealingView");
  private messageView = new MessageAdd("#messageView");

  constructor() {
    this.inputDate = document.querySelector("#data");
    this.inputAmount = document.querySelector("#quantidade");
    this.inputValue = document.querySelector("#valor");
    this.dealingView.update(this.dealingList);
  }
  public addToList(): void {
    const dealingList = this.createDealing();
    if (!this.isBusinessDay(dealingList.date)) {
      this.messageView.update("Apenas negociações em dias uteis.");
    }

    this.dealingList.addDealing(dealingList);
    this.updateView();
    this.clearForm();
  }
  private isBusinessDay(date: Date) {
    return date.getDay() > 0 && date.getDay() < 6;
  }
  private createDealing(): Dealing {
    const exp = /-/g;
    const date = new Date(this.inputDate.value.replace(exp, ","));
    const amount = parseInt(this.inputAmount.value);
    const value = parseFloat(this.inputValue.value);
    return new Dealing(date, amount, value);
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
