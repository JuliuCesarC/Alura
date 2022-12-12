export class DealingList {
    constructor() {
        this.dealingList = [];
    }
    addDealing(dealing) {
        this.dealingList.push(dealing);
    }
    list() {
        return this.dealingList;
    }
}
