import { Printable } from "../utils/Printable.js";
import { Dealing } from "./Dealing.js";

export class DealingList implements Printable{
  private dealingList: Dealing[] = []

  public addDealing(dealing: Dealing){
    this.dealingList.push(dealing)
  }
  public list(): ReadonlyArray<Dealing>{
    return this.dealingList;
  }
  public convertToText(): string{
    return JSON.stringify(this.dealingList, null, 2)    
  }
}