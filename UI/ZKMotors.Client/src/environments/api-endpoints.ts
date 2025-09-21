export class ApiEndpoints {
    private static _base: string = 'api/';

    static get getAllVehicles(){ return this._base + 'vehicle/get'}
    static get getVehicleBySlug(){ return this._base +'vehicle/get'}
    static get getRelated(){ return this._base +'vehicle/getrelated'}
    static get getAllVehicleMakes() { return this._base + 'vehicle/getVehicleMakes'}
    static get getAllBodyTypes() { return this._base + 'vehicle/getBodyTypes'}
}
