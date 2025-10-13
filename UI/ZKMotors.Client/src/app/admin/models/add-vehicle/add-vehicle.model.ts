import { VehicleBasicIdentifications, VehicleTechnicalSpecifications } from "app/shared";

export interface IAddVehicleModel{
    vehicleMakeId: number;

    basicIdentifications: VehicleBasicIdentifications,
    technicalSpecifications: VehicleTechnicalSpecifications
}