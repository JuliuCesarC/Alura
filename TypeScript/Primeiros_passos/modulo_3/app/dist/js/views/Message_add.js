import { View } from "./view.js";
export class MessageAdd extends View {
    template(model) {
        return `
      <p class="alert alert-info">${model}</p>
    `;
    }
}
//# sourceMappingURL=Message_add.js.map