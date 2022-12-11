import { Dealing } from "./Dealing.js";

export class TradingList{
  private tradingList: Dealing[] = []

  add(dealing: Dealing){
    this.tradingList.push(dealing)
  }
  list(): ReadonlyArray<Dealing>{
    return this.tradingList;
  }
}