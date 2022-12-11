import { Dealing } from "./Dealing.js";

export class DealingList{
  private dealingList: Dealing[] = []

  add(dealing: Dealing){
    this.dealingList.push(dealing)
  }
  list(): ReadonlyArray<Dealing>{
    return this.dealingList;
  }
}