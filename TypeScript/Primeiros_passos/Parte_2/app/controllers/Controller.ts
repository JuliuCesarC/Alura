import { TradingList } from "../models/TradingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";

export class Controller {
  private inputDate: HTMLInputElement;
  private inputAmount: HTMLInputElement;
  private inputValue: HTMLInputElement;
  private dealing = new TradingList;
  private dealingView = new Dealing_view("#dealingView")

  constructor() {
    this.inputDate = document.querySelector("#data");
    this.inputAmount = document.querySelector("#quantidade");
    this.inputValue = document.querySelector("#valor");
    this.dealingView.update()
  }
  addToList(): void {
    const dealing = this.createDealing()
    this.dealing.add(dealing)
    console.log(this.dealing.list());
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
