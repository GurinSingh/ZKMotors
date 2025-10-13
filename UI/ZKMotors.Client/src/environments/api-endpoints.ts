export class ApiEndpoints {
    private static _base: string = 'api/';
    private static _baseAdmin: string = this._base+ 'admin/';

    static get getAllVehicles(){ return this._base + 'vehicle/get'}
    static get getVehicleBySlug(){ return this._base +'vehicle/get'}
    static get getRelated(){ return this._base +'vehicle/getrelated'}
    static get getAllVehicleMakes() { return this._base + 'vehicle/getVehicleMakes'}
    static get getAllVehicleModels() { return this._base + 'vehicle/getVehicleModels'}
    static get getAllBodyTypes() { return this._base + 'vehicle/getBodyTypes'}

    static get registerUser() { return this._baseAdmin + 'account/register'}
    static get loginUser() { return this._baseAdmin + 'account/login'}
    static get getAllVehiclesAsAdmin() { return this._baseAdmin + 'vehicle/get'}
    static get addVehicles() { return this._baseAdmin + 'vehicle/add'}
    static get getVehicleInformation() { return this._baseAdmin + 'vehicle/GetVehicleInformation'}
}
