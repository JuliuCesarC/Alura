var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { DealingList } from "../models/DealingList.js";
import { Dealing } from "../models/Dealing.js";
import { Dealing_view } from "../views/Dealing_view.js";
import { MessageAdd } from "../views/Message_add.js";
import { DaysOfWeek } from "../enums/DaysOfWeek.js";
import { LogRuntime } from "../decorators/LogRuntime.js";
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
__decorate([
    LogRuntime()
], Controller.prototype, "addToList", null);
