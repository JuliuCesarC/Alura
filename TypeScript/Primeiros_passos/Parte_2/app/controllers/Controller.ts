import { DealingList } from "../models/DealingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";
import { MessageAdd } from "../views/Messge_add.js";

export class Controller {
  private inputDate: HTMLInputElement;
  private inputAmount: HTMLInputElement;
  private inputValue: HTMLInputElement;
  private dealingList = new DealingList;
  private dealingView = new Dealing_view("#dealingView")
  private messageView = new MessageAdd("#messageView")

  constructor() {
    this.inputDate = document.querySelector("#data");
    this.inputAmount = document.querySelector("#quantidade");
    this.inputValue = document.querySelector("#valor");
    this.dealingView.update(this.dealingList)
  }
  addToList(): void {
    const dealingList = this.createDealing()
    this.dealingList.add(dealingList)
    console.log(this.dealingList.list());
    this.dealingView.update(this.dealingList)
    this.messageView.update('Negociação adicionada com sucesso.')
    this.clearForm()
  }
  createDealing(): Dealing {
    const exp = /-/g;
    const date = new Date(this.inputDate.value.replace(exp, ","));
    const amount = parseInt(this.inputAmount.value);
    const value = parseFloat(this.inputValue.value);
    return new Dealing(date, amount, value);
  }
  clearForm(): void{
    this.inputDate.value = ""
    this.inputAmount.value = ""
    this.inputValue.value = ""
    this.inputDate.focus()
  }
}
