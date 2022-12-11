export class Dealing {
  constructor(
    private _date: Date,
    public readonly _amount: number,
    public readonly _value: number
  ) {}

  get date(): Date {
    const date = new Date(this._date.getTime())
    return date;
  }
  get volume(): number {
    return this._amount * this._value;
  }
} 
