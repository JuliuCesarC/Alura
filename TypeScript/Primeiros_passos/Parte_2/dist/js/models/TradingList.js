export class TradingList {
    constructor() {
        this.tradingList = [];
    }
    add(dealing) {
        this.tradingList.push(dealing);
    }
    list() {
        return this.tradingList;
    }
}
