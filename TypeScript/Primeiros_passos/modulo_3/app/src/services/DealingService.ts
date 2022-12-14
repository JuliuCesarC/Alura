import { DealingDay } from "../interface/DealingDay.js";
import { Dealing } from "../models/Dealing.js";

export class DealingService{
  public getDealing():Promise<Dealing[]>{
    return fetch("http://localhost:8080/dados")
      .then((res) => res.json())
      .then((data: DealingDay[]) => {
        return data.map((dataNow) => {
          return new Dealing(new Date(), dataNow.vezes, dataNow.montante);
        });
      })
  }
}