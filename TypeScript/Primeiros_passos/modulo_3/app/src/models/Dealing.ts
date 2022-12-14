import { Printable } from "../utils/Printable.js";

export class Dealing implements Printable {
  constructor(
    private _date: Date,
    public readonly amount: number,
    public readonly value: number
  ) {}
  public static createDealing(
    dateString: string,
    amountString: string,
    valueString: string
  ): Dealing {
    const exp = /-/g;
    const date = new Date(dateString.replace(exp, ","));
    const amount = parseInt(amountString);
    const value = parseFloat(valueString);
    return new Dealing(date, amount, value);
  }

  get date(): Date {
    const date = new Date(this._date.getTime());
    return date;
  }
  get volume(): number {
    return this.amount * this.value;
  }
  public convertToText(): string {
    return `
    Data: ${this.date}
    Quantidade: ${this.amount}
    Valor: ${this.value}
    `;
  }
  public equals(dealing: Dealing): boolean {
    return (
      this.date.getDate() === dealing.date.getDate() &&
      this.date.getMonth() === dealing.date.getMonth() &&
      this.date.getFullYear() === dealing.date.getFullYear()
    );
  }
}
