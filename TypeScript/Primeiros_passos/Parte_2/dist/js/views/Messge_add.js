import { View } from "./view.js";
export class MessageAdd extends View {
    // Ao estendermos da classe View, passamos para ela o tipo <string>, que sera utilizado no tipo Generic do View.
    template(model) {
        return `
      <p class="alert alert-info">${model}</p>
    `;
    }
}
