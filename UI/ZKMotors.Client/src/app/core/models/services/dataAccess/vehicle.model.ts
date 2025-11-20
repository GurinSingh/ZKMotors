import { IAddVehicleBasicIdentificationModel, IViewVehicleBasicIdentificationModel } from "./vehicle-basic-identification.model";
import { IViewVehicleImageModel, IAddVehicleImageModel } from "./vehicle-image.model";
import { IViewVehicleTechnicalSpecificationModel, IAddVehicleTechnicalSpecificationModel } from "./vehicle-technical-specification.model";

export interface IViewVehicleModel {
    vehicleId: number;
    price: number;
    slug: string;
    addedDateTime: Date;
    lastUpdatedDateTime: Date;

    basicIdentification: IViewVehicleBasicIdentificationModel;
    technicalSpecification: IViewVehicleTechnicalSpecificationModel;
    images: IViewVehicleImageModel[];
}
export interface IAddVehicleModel{
    vehicleStatusId: number;
    price: number;

    basicIdentification: IAddVehicleBasicIdentificationModel;
    technicalSpecification: IAddVehicleTechnicalSpecificationModel;
    images: IAddVehicleImageModel[];
}

export interface IDashboardStats {
    onSale: number;
    sold: number;
    onHold: number;
    totalRevenue: number;
}