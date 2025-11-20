import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { VehicleMakeService, VehicleModelService, VehicleBodyTypeService, IVehicleMakeModel, IVehicleModel, VehicleService, IAddVehicleModel, IViewBodyTypeModel, IViewVehicleModel, IAddVehicleImageModel, IViewFuelTypeModel, IViewTransmissionModel, IViewDrivetrainModel } from 'app/core';
import { CommonModule } from '@angular/common';
import { VehicleStatusService } from 'app/core/services/dataAccess/vehicleStatus/vehicle-status.service';
import { IViewVehicleStatusModel } from 'app/core/models/services/dataAccess/vehicle-status.model';
import { HttpErrorResponse } from '@angular/common/http';
import { FuelTypeService } from 'app/core/services/dataAccess/fuelType/fuel-type.service';
import { TransmissionService } from 'app/core/services/dataAccess/transmission/transmission.service';
import { DrivetrainService } from 'app/core/services/dataAccess/drivetrain/drivetrain.service';

@Component({
  selector: 'admin-add-vehicle',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './add-vehicle.component.html',
  styleUrl: './add-vehicle.component.css',
  standalone: true
})
export class AddVehicleComponent implements OnInit {
  private _allVehicleModels: IVehicleModel[] = [];
  vehicleMakes: IVehicleMakeModel[] = [];
  vehicleStatus: IViewVehicleStatusModel[] = []
  vehicleModels: IVehicleModel[] = [];
  bodyTypes: IViewBodyTypeModel[] = [];
  fuelTypes: IViewFuelTypeModel[] = [];
  transmissions: IViewTransmissionModel[]=[];
  drivetrains: IViewDrivetrainModel[]=[];
  trims: string[] = [];
  imageModel: IAddVehicleImageModel[] = [];
  selectedImages: {name: string, url: string}[] = [];
  formWrapperCss = 'col-12 col-sm-6 col-md-4 col-lg-3 px-sm-3 mt-3';

  addVehicleForm = new FormGroup({
    price: new FormControl(null, Validators.required),
    statusId: new FormControl(null, Validators.required),
    images: new FormControl([]),
    basicIdentification: new FormGroup({
      year: new FormControl(null, Validators.required),
      exteriorColor: new FormControl('', Validators.required),
      interiorColor: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      vin: new FormControl('', Validators.required),
      trim: new FormControl('', Validators.required),
      features: new FormControl('', Validators.required),
      bodyTypeId: new FormControl(null, Validators.required),
      makeId: new FormControl(null, Validators.required),
      modelId: new FormControl(null, Validators.required),
    }),
    technicalSpecification: new FormGroup({
      seatingCapacity: new FormControl(null, Validators.required),
      numberOfOwners: new FormControl(null, Validators.required),
      numberOfDoors: new FormControl(null, Validators.required),
      horsepower: new FormControl(null, Validators.required),
      torque: new FormControl(null, Validators.required),
      kmpl_City: new FormControl(null, Validators.required),
      kmpl_Highway: new FormControl(null, Validators.required),
      kmpl_Combined: new FormControl(null, Validators.required),
      engineId: new FormControl(null, Validators.required),
      transmissionId: new FormControl(null, Validators.required),
      fuelTypeId: new FormControl(null, Validators.required),
      drivetrainId: new FormControl(null, Validators.required),
      mileage: new FormControl(null, Validators.required),
    })
  });

  constructor(private _vehicleMakeService: VehicleMakeService
    , private _vehicleModelService: VehicleModelService, private _vehicleService: VehicleService
    , private _bodyTypeService: VehicleBodyTypeService, private _vehicleStatusService: VehicleStatusService
    , private _fuelTypeService: FuelTypeService, private _transmissionService: TransmissionService
    , private _drivetrainService: DrivetrainService
  ) { }

  ngOnInit(): void {
    this.loadAllVehicleStatus();
    this.loadAllVehicleMakes();
    this.loadAllVehicleModels();
    this.loadAllBodyTypes();
    this.loadAllFuelTypes();
    this.loadAllTransmissions();
    this.loadAllDrivetrains();
    //this.onVehicleMakeValueChanges();
    //this.onVehicleModelValueChanges();
    //this.onYearValueChanges();
    //this.onTrimValueChanges();
    //this.onImageValueChanges();
  }

  private loadAllVehicleStatus() {
    this._vehicleStatusService.getAll()
      .subscribe(
        {
          next: (value: IViewVehicleStatusModel[]) => {
            this.vehicleStatus = value;
          }
        });
  }

  onSubmit() {
    let d = this.convertToFormData(this.addVehicleForm.value);
    this._vehicleService.add(<any>d).subscribe({
      next: (value: any) => {
        console.log(value);
      }
    });
  }

  private convertToFormData(form: any): FormData{
    debugger;
    let formData: FormData = new FormData();

    let getValueByKey = (key: string)=>{
      return key.split('.').reduce((o, i)=> (o ? o[i] : undefined), form);
    };
    
    let getData = (obj: any, parentKey: string) =>{
      debugger;
      let keys: string[] = Object.keys(obj);
      
      keys.forEach(key => {
        let combinedKey: string = parentKey == '' ? key : `${parentKey}.${key}`;
        let value: any = getValueByKey(combinedKey);

        if(typeof(value) === 'object' && value != undefined && value != null){
          //if array
          if(Array.isArray(value)){
            formData.append(combinedKey, JSON.stringify(value));
          }
          else
            getData(value, combinedKey);
        }
        else{
          if(value != null && value != undefined && value != '')
            formData.append(combinedKey, value);
        }
        
      });

    }

    getData(form, '');
    //logging
      for (const [key, value] of formData.entries()) {
        console.log(key, value);
      }

    return formData;
  }

  onFileSelected(event: Event): void {
    debugger;
    const input = event.target as HTMLInputElement;
    const files = input.files;

    if (files == null)
      return;

    for (let i = 0, l = files?.length || 0; i < l; i++) {
      const file = files[i];

      let model = {
        fileName: file.name,
        contentType: file.type,
        image: file
      };

      this.imageModel.push(model);

      this.selectedImages.push({
        name: model.fileName,
        url: URL.createObjectURL(model.image)
      })
    }

    this.addVehicleForm.get('images')!.patchValue(<any>this.imageModel);
  }

  private loadAllVehicleMakes(): void {
    this._vehicleMakeService.getAll().subscribe({
      next: (value: IVehicleMakeModel[]) => {
        this.vehicleMakes = value;

        this.onVehicleMakeValueChanges();
      },
    })
  }

  private loadAllVehicleModels(): void {
    this._vehicleModelService.getAll().subscribe({
      next: (value: IVehicleModel[]) => {
        this._allVehicleModels = value;
        this.vehicleModels = this._allVehicleModels;

        this.onVehicleModelValueChanges();
      }
    })
  }

  private loadAllBodyTypes(): void {
    this._bodyTypeService.getAll().subscribe({
      next: (value: IViewBodyTypeModel[]) => {
        this.bodyTypes = value;
      }
    })
  }

  private loadAllFuelTypes(): void{
    this._fuelTypeService.getAll()
    .subscribe(
      (value)=>{
        this.fuelTypes = value;
      }
    )
  }

  private loadAllTransmissions(){
    this._transmissionService.getAll()
    .subscribe(
      (value)=>{
        this.transmissions = value;
      }
    )
  }

  private loadAllDrivetrains(){
    this._drivetrainService.getAll()
    .subscribe(
      (value)=>{
        this.drivetrains = value;
      }
    )
  }

  private loadvehicleInformation(): void {
    debugger;
    let makeId = parseInt(<any>this.addVehicleForm.get('basicIdentification.makeId')?.value);
    if (Number.isNaN(makeId))
      return;

    let modelId = parseInt(<any>this.addVehicleForm.get('basicIdentification.modelId')?.value);
    if (Number.isNaN(modelId))
      return;

    let year = parseInt(<any>this.addVehicleForm.get('basicIdentification.year')?.value);
    if (Number.isNaN(year))
      year = 0;

    let trim = <any>this.addVehicleForm.get('basicIdentification.trim')?.value;

    this._vehicleService.getVehicleInformation(makeId, modelId, year, trim).subscribe({
      next: (value: IViewVehicleModel) => {
        console.log(value);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  private onVehicleMakeValueChanges(): void {
    debugger;
    this.addVehicleForm.get('basicIdentification.makeId')!.valueChanges.subscribe(makeId => {
      debugger;
      this.vehicleModels = this._allVehicleModels.filter(vm => (makeId != '' && vm.makeId == makeId) || (makeId == ''));
      this.addVehicleForm.get('basicIdentification.modelId')!.setValue(null);

      this.loadvehicleInformation();
    });
  }
  private onVehicleModelValueChanges(): void {
    this.addVehicleForm.get('basicIdentification.modelId')!.valueChanges.subscribe(modelId => {
      this.loadvehicleInformation();
    });
  }
  private onYearValueChanges(): void {
    this.addVehicleForm.get('basicIdentification.year')!.valueChanges.subscribe(year => {
      this.loadvehicleInformation();
    });
  }
  private onTrimValueChanges(): void {
    this.addVehicleForm.get('basicIdentification.trim')!.valueChanges.subscribe(trim => {
      this.loadvehicleInformation();
    });
  }

}
