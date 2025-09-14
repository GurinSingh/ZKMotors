import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { VehicleListModel } from '@models/vehicle-list.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-vehicles-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './vehicles-list.component.html',
  styleUrl: './vehicles-list.component.css'
})
export class VehiclesListComponent implements OnInit {
  vehicleList: VehicleListModel[] = [];

  constructor(private http: HttpClient) {
  }
  ngOnInit(): void {
    debugger;
    this.http.get(ApiEndpoints.getAllVehicles).subscribe({
      next: (value: any)=> {
        this.vehicleList = value;
      },
      error: (err)=>{
        alert("vehicle list error");
      }
    });
  }
}
