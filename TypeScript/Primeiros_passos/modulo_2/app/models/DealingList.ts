import { Dealing } from "./Dealing.js";

export class DealingList{
  private dealingList: Dealing[] = []

  public addDealing(dealing: Dealing){
    this.dealingList.push(dealing)
  }
  public list(): ReadonlyArray<Dealing>{
    return this.dealingList;
  }
}