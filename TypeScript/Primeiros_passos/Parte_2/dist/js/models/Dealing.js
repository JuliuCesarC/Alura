export class Dealing {
    constructor(_date, _amount, _value) {
        this._date = _date;
        this._amount = _amount;
        this._value = _value;
    }
    get date() {
        const date = new Date(this._date.getTime());
        return date;
    }
    get volume() {
        return this._amount * this._value;
    }
}
