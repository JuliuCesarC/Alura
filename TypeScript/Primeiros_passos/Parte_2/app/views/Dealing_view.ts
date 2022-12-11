import { DealingList } from "../models/DealingList.js";
import { View } from "./view.js";

export class Dealing_view extends View<DealingList> {

  template(model: DealingList): string {
    return `
    <table class="table table-hover table-bordered">
      <thead>
        <tr>
          <th>DATA</th>
          <th>QUANTIDADE</th>
          <th>VALOR</th>
        </tr>
      </thead>
      <tbody>    
      ${model.list().map(DList=>{
        return`
          <tr>
            <td>${new Intl.DateTimeFormat().format(DList.date)}</td>
            <td>${DList.amount}</td>
            <td>${DList.value}</td>
          </tr>
        `
      }).join('')}   
      </tbody>
    </table>
    `;
  }
}
