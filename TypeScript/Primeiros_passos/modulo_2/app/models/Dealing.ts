export class Dealing {
  constructor(
    private _date: Date,
    public readonly amount: number,
    public readonly value: number
  ) {}

  get date(): Date {
    const date = new Date(this._date.getTime());
    return date;
  }
  get volume(): number {
    return this.amount * this.value;
  }
  // O parâmetro 'static' permite chamar o método diretamente da classe, sem precisar criar uma instancia, para assim poder acessar o método.
  // Chamando diretamente da classe:
  // Dealing.createDealing( parâmetros );
  // Criando uma instância:
  // const dealing = new Dealing( parâmetros )
  // dealing.createDealing( parâmetros ) 
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
}
