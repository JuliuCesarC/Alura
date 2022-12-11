export class DealingList {
    constructor() {
        this.dealingList = [];
    }
    add(dealing) {
        this.dealingList.push(dealing);
    }
    list() {
        return this.dealingList;
    }
}
