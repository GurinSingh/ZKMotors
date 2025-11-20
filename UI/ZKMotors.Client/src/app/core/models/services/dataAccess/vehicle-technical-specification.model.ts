import { IViewDrivetrainModel } from "./drivetrain.model";
import { IEngineModel } from "./engine.model";
import { IViewFuelTypeModel } from "./fuel-type.model";
import { IViewTransmissionModel } from "./transmission.model";

export interface IViewVehicleTechnicalSpecificationModel {
    vehicleTechnicalSpecificationId: number;
    seatingCapacity: number;
    numberOfOwners: number;
    numberOfDoors: number;
    horsepower: number;
    torque: number;
    kmpl_City: number;
    kmpl_Highway: number;
    kmpl_Combined: number;

    engine: IEngineModel;
    transmission: IViewTransmissionModel;
    fuelType: IViewFuelTypeModel;
    drivetrain: IViewDrivetrainModel;
}

export interface IAddVehicleTechnicalSpecificationModel{
    seatingCapacity: number;
    numberOfOwners: number;
    numberOfDoors: number;
    horsepower: number;
    torque: number;
    kmpl_City: number;
    kmpl_Highway: number;
    kmpl_Combined: number;
    engineId: number;
    transmissionId: number;
    fuelTypeId: number;
    drivetrainId: number;
}