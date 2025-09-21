import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { VehicleMakeModel } from '@models/vehicle-make.model';
import { ApiEndpoints } from 'environments/api-endpoints';

@Component({
  selector: 'app-home',
  imports: [RouterModule, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  vehicleMakes: VehicleMakeModel[] = [];

  constructor(private _http: HttpClient) {
  }

  ngOnInit(): void {
    this._http.get<VehicleMakeModel[]>(ApiEndpoints.getVehicleMakes).subscribe({
      next: (value: VehicleMakeModel[])=>{
        this.vehicleMakes = value;
      },
      error: (err)=>{
        debugger;
        alert('Error in Vehicle make request');
      }
    })
  }
}
