import { Dealing } from "../models/Dealing.js";
export class DealingService {
    getDealing() {
        return fetch("http://localhost:8080/dados")
            .then((res) => res.json())
            .then((data) => {
            return data.map((dataNow) => {
                return new Dealing(new Date(), dataNow.vezes, dataNow.montante);
            });
        });
    }
}
//# sourceMappingURL=DealingService.js.map