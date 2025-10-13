import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { VehicleListModel } from 'app/user/models';
import { ApiEndpoints } from 'environments/api-endpoints';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserManagerService } from 'app/core';

@Component({
  selector: 'user-vehicles-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './vehicles-list.component.html',
  styleUrl: './vehicles-list.component.css'
})
export class VehiclesListComponent implements OnInit {
  vehicleList: VehicleListModel[] = [];

  constructor(private http: HttpClient, private userManager: UserManagerService) {
  }
  ngOnInit(): void {
    this.http.get(ApiEndpoints.getAllVehicles).subscribe({
      next: (value: any)=> {
        this.vehicleList = value;

        this.userManager.logout();
      },
      error: (err)=>{
        alert("vehicle list error");
      }
    });
  }
}
