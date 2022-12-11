export class Dealing {
  constructor(
    private _date: Date,
    public readonly amount: number,
    public readonly value: number
  ) {}

  get date(): Date {
    const date = new Date(this._date.getTime())
    return date;
  }
  get volume(): number {
    return this.amount * this.value;
  }
} 
