import { DealingList } from "../models/DealingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";
import { MessageAdd } from "../views/Messge_add.js";
export class Controller {
    constructor() {
        this.dealingList = new DealingList;
        this.dealingView = new Dealing_view("#dealingView");
        this.messageView = new MessageAdd("#messageView");
        this.inputDate = document.querySelector("#data");
        this.inputAmount = document.querySelector("#quantidade");
        this.inputValue = document.querySelector("#valor");
        this.dealingView.update(this.dealingList);
    }
    addToList() {
        const dealingList = this.createDealing();
        this.dealingList.add(dealingList);
        console.log(this.dealingList.list());
        this.dealingView.update(this.dealingList);
        this.messageView.update('Negociação adicionada com sucesso.');
        this.clearForm();
    }
    createDealing() {
        const exp = /-/g;
        const date = new Date(this.inputDate.value.replace(exp, ","));
        const amount = parseInt(this.inputAmount.value);
        const value = parseFloat(this.inputValue.value);
        return new Dealing(date, amount, value);
    }
    clearForm() {
        this.inputDate.value = "";
        this.inputAmount.value = "";
        this.inputValue.value = "";
        this.inputDate.focus();
    }
}
