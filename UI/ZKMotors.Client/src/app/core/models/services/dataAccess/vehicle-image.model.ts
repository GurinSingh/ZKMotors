export interface IViewVehicleImageModel {
    vehicleImageId: number;
    vehicleId: number;
    image: string;
    contentType: string;
    fileName: string;
}

export interface IAddVehicleImageModel {
    image: File;
    contentType: string;
    fileName: string;
}