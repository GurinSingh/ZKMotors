import { VehicleDetailsImageModel } from "./vehicle-details-image.model";

export class VehicleDetailsModel {
    id:number = 0;
    slug: string = '';
    year: number = 0;
    isSold: boolean = false;
    exteriorColor: string = '';
    interiorColor: string = '';
    description: string = '';
    price: number = 0;
    mileage: number = 0;
    make: string ='';
    model: string = '';
    vin: string = '';
    trim: string = '';
    bodyType: string = '';
    engine: string = '';
    transmission: string = '';
    fuelType: string = '';
    drivetrain: string = '';
    numberOfOwners: number = 0;
    numberOfDoors: number = 0;
    seatingCapacity: number = 0;
    features: string = '';
    addedDateTime: Date = new Date();
    lastUpdatedDateTime: Date = new Date();

    images: VehicleDetailsImageModel[] = [];
}