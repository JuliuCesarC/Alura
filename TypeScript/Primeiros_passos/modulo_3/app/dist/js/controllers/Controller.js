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
import { Inspect } from "../decorators/Inspect.js";
import { DomInjector } from "../decorators/DomInjector.js";
import { DealingService } from "../services/DealingService.js";
export class Controller {
    constructor() {
        this.dealingList = new DealingList();
        this.dealingView = new Dealing_view("#dealingView");
        this.messageView = new MessageAdd("#messageView");
        this.dealingService = new DealingService();
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
    importData() {
        this.dealingService.getDealing()
            .then((dealingNow) => {
            for (let dealing of dealingNow) {
                this.dealingList.addDealing(dealing);
            }
            this.dealingView.update(this.dealingList);
        });
    }
    importData_exe_02() {
        fetch("http://localhost:8080/dados")
            .then((res) => res.json())
            .then((data) => {
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
    importData_exe_01() {
        fetch("http://localhost:8080/dados")
            .then((res) => res.json())
            .then((data) => {
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
    isBusinessDay(date) {
        return (date.getDay() > DaysOfWeek.SUNDAY && date.getDay() < DaysOfWeek.SATURDAY);
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
    DomInjector("#data")
], Controller.prototype, "inputDate", void 0);
__decorate([
    DomInjector("#quantidade")
], Controller.prototype, "inputAmount", void 0);
__decorate([
    DomInjector("#valor")
], Controller.prototype, "inputValue", void 0);
__decorate([
    LogRuntime(),
    Inspect()
], Controller.prototype, "addToList", null);
