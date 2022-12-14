import { DealingList } from "../models/DealingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";
import { MessageAdd } from "../views/Message_add.js";
import { DaysOfWeek } from "../enums/DaysOfWeek.js";
export class Controller {
    constructor() {
        this.dealingList = new DealingList();
        this.dealingView = new Dealing_view("#dealingView", true);
        this.messageView = new MessageAdd("#messageView");
        this.inputDate = document.querySelector("#data");
        this.inputAmount = document.querySelector("#quantidade");
        this.inputValue = document.querySelector("#valor");
        this.dealingView.update(this.dealingList);
    }
    addToList() {
        const dealingList = Dealing.createDealing(this.inputDate.value, this.inputAmount.value, this.inputValue.value);
        if (!this.isBusinessDay(dealingList.date)) {
            this.messageView.update("Apenas negociações em dias uteis.");
            return;
        }
        this.dealingList.addDealing(dealingList);
        this.updateView();
        this.clearForm();
    }
    isBusinessDay(date) {
        return date.getDay() > DaysOfWeek.SUNDAY && date.getDay() < DaysOfWeek.SATURDAY;
    }
    clearForm() {
        this.inputDate.value = "";
        this.inputAmount.value = "";
        this.inputValue.value = "";
        this.inputDate.focus();
    }
    updateView() {
        this.dealingView.update(this.dealingList);
        this.messageView.update("Negociação adicionada com sucesso.");
    }
}
