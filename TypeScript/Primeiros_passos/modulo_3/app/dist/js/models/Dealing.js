export class Dealing {
    constructor(_date, amount, value) {
        this._date = _date;
        this.amount = amount;
        this.value = value;
    }
    static createDealing(dateString, amountString, valueString) {
        const exp = /-/g;
        const date = new Date(dateString.replace(exp, ","));
        const amount = parseInt(amountString);
        const value = parseFloat(valueString);
        return new Dealing(date, amount, value);
    }
    get date() {
        const date = new Date(this._date.getTime());
        return date;
    }
    get volume() {
        return this.amount * this.value;
    }
    convertToText() {
        return `
    Data: ${this.date}
    Quantidade: ${this.amount}
    Valor: ${this.value}
    `;
    }
    equals(dealing) {
        return (this.date.getDate() === dealing.date.getDate() &&
            this.date.getMonth() === dealing.date.getMonth() &&
            this.date.getFullYear() === dealing.date.getFullYear());
    }
}
//# sourceMappingURL=Dealing.js.map