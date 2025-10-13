export interface IVehicle {
    id:number;
    slug: string;
    year: number;
    isSold: boolean;
    exteriorColor: string;
    interiorColor: string;
    description: string;
    price: number;
    mileage: number;
    make: string;
    model: string;
    vin: string;
    trim: string;
    bodyType: string;
    engine: string;
    transmission: string;
    fuelType: string;
    drivetrain: string;
    numberOfOwners: number;
    numberOfDoors: number;
    seatingCapacity: number;
    features: string;
    addedDateTime: Date;
    lastUpdatedDateTime: Date;

    images: IVehicleImage[];
}

export interface IVehicleImage{
    vehicleImageId: number;
    vehicleId: number;
    imageBase64: string;
    contentType: string;
    fileName: string;
}