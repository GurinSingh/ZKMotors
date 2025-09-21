import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { VehicleMakeModel } from '@models/vehicle-make.model';
import { BodyTypeModel } from '@models/body-type.model';
import { ApiEndpoints } from 'environments/api-endpoints';

@Component({
  selector: 'app-home',
  imports: [RouterModule, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  vehicleMakes: VehicleMakeModel[] = [];
  bodyTypes: BodyTypeModel[] = [];

  constructor(private _http: HttpClient) {
  }

  ngOnInit(): void {
    this.loadVehicleMakes();
    this.loadVehicleType();
  }
  private loadVehicleMakes(){
    this._http.get<VehicleMakeModel[]>(ApiEndpoints.getAllVehicleMakes).subscribe({
      next: (value: VehicleMakeModel[])=>{
        this.vehicleMakes = value;
      },
      error: (err)=>{
        debugger;
        alert('Error in Vehicle make request');
      }
    });
  }
  private loadVehicleType(){
    this._http.get<BodyTypeModel[]>(ApiEndpoints.getAllBodyTypes).subscribe({
      next: (value: BodyTypeModel[])=>{
        this.bodyTypes = value;
      },
      error: (err)=>{
        alert('Error in body types request');
      }
    });
  }
}
