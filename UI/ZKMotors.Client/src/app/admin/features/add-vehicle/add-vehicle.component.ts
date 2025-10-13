import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { VehicleMakeService, VehicleModelService, VehicleBodyTypeService, IBodyType, IVehicleMake, IVehicleModel, VehicleService, IVehicle, IVehicleImage } from 'app/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'admin-add-vehicle',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-vehicle.component.html',
  styleUrl: './add-vehicle.component.css',
  standalone: true
})
export class AddVehicleComponent implements OnInit {
  private _allVehicleModels: IVehicleModel[] = [];
  vehicleMakes: IVehicleMake[] = [];
  vehicleModels: IVehicleModel[] = [];
  bodyTypes: IBodyType[] = [];
  trims: string[] = [];
  selectedImages: string[] = [];
  formWrapperCss = 'col-12 col-sm-6 col-md-4 col-lg-3 px-sm-3 my-3';

  addVehicleForm = new FormGroup({
    makeId: new FormControl('', Validators.required),
    modelId: new FormControl('', Validators.required),
    year: new FormControl('', Validators.required),
    mileage: new FormControl('', Validators.required),
    vin: new FormControl('', Validators.required),
    trim: new FormControl('', Validators.required),
    bodyTypeId: new FormControl('', Validators.required),
    exteriorColor: new FormControl('', Validators.required),
    interiorColor: new FormControl('', Validators.required),
    features: new FormControl('', Validators.required),

    engine: new FormControl('', Validators.required),
    transmission: new FormControl('', Validators.required),
    fuelType: new FormControl('', Validators.required),
    drivetrain: new FormControl('', Validators.required),
    numberOfOwners: new FormControl('', Validators.required),
    seatingCapacity: new FormControl('', Validators.required),
    numberOfDoors: new FormControl('', Validators.required),
    images: new FormControl(''),
  });

  constructor(private _vehicleMakeService: VehicleMakeService
    , private _vehicleModelService: VehicleModelService, private _vehicleService: VehicleService
    , private _bodyTypeService: VehicleBodyTypeService) { }

  ngOnInit(): void {
    this.loadAllVehicleMakes();
    this.loadAllVehicleModels();
    this.loadAllBodyTypes();
    this.onVehicleMakeValueChanges();
    this.onVehicleModelValueChanges();
    this.onYearValueChanges();
    this.onTrimValueChanges();
    //this.onImageValueChanges();
  }

  onSubmit() {
    debugger;
    this._vehicleService.add(<any>this.addVehicleForm.value).subscribe({
      next: (value: IVehicle)=>{
        console.log(value);
      },
      error: (err)=>{
        console.log(err);
      }
    })
  }

  onFileSelected(event: Event): void {
    debugger;
    const input = event.target as HTMLInputElement;
    const files = input.files || new FileList();

    for(let i = 0, l = files.length; i<l; i++){
      this.selectedImages.push(URL.createObjectURL(files[i]))
    }
  }

  private loadAllVehicleMakes(): void {
    this._vehicleMakeService.getAll().subscribe({
      next: (value: IVehicleMake[]) => {
        this.vehicleMakes = value;
      }
    })
  }

  private loadAllVehicleModels(): void {
    this._vehicleModelService.getAll().subscribe({
      next: (value: IVehicleModel[]) => {
        this._allVehicleModels = value;
        this.vehicleModels = this._allVehicleModels;
      }
    })
  }

  private loadAllBodyTypes(): void {
    this._bodyTypeService.getAll().subscribe({
      next: (value: IBodyType[]) => {
        this.bodyTypes = value;
      }
    })
  }

  private loadvehicleInformation(): void {
    debugger;
    let makeId = parseInt(<any>this.addVehicleForm.get('makeId')?.value);
    if(Number.isNaN(makeId))
      return;

    let modelId = parseInt(<any>this.addVehicleForm.get('modelId')?.value);
    if(Number.isNaN(modelId))
      return;

    let year = parseInt(<any>this.addVehicleForm.get('year')?.value);
    if(Number.isNaN(year))
      year = 0;

    let trim = <any>this.addVehicleForm.get('trim')?.value;

    this._vehicleService.getVehicleInformation(makeId, modelId, year, trim).subscribe({
      next: (value: IVehicle) => {
        console.log(value);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  private onVehicleMakeValueChanges(): void {
    this.addVehicleForm.get('makeId')!.valueChanges.subscribe(makeId => {
      this.vehicleModels = this._allVehicleModels.filter(vm => (makeId != '' && vm.makeId == makeId) || (makeId == ''));
      this.addVehicleForm.get('modelId')!.setValue('');

      this.loadvehicleInformation();
    });
  }
  private onVehicleModelValueChanges(): void {
    this.addVehicleForm.get('modelId')!.valueChanges.subscribe(modelId => {
      this.loadvehicleInformation();
    });
  }
  private onYearValueChanges(): void {
    this.addVehicleForm.get('year')!.valueChanges.subscribe(year => {
      this.loadvehicleInformation();
    });
  }
  private onTrimValueChanges(): void {
    this.addVehicleForm.get('trim')!.valueChanges.subscribe(trim=>{
      this.loadvehicleInformation();
    });
  }

}
