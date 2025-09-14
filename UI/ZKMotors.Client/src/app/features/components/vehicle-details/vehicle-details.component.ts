import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehicleBasicIdentifications } from '@models/vehicle-basic-identifications';
import { VehicleListModel } from '@models/vehicle-list.model';
import { VehicleTechnicalSpecifications } from '@models/vehicle-technical-specifications';
import { RouterModule } from '@angular/router';
import { ApiEndpoints } from 'environments/api-endpoints';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-vehicle-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './vehicle-details.component.html',
  styleUrl: './vehicle-details.component.css'
})
export class VehicleDetailsComponent implements OnInit {
  vehicleListModel: VehicleListModel = new VehicleListModel();
  basicIdentifications: Record<string, any> = {};
  technicalSpecifications: Record<string, any> = {};
  relatedVehicles: Array<VehicleListModel> = [];


  constructor(private http: HttpClient, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    debugger;
    this.route.params.subscribe(param=> {
      this._loadData(param['slug']);
    
    });
  }

  private _loadData(slug: string){
    this.http.get(ApiEndpoints.getVehicleBySlug+'/'+slug)
    .subscribe({
      next: (value: any)=>{
        debugger;
        this.vehicleListModel = value;
        
        Object.keys(new VehicleBasicIdentifications()).forEach(key=> this.basicIdentifications[key] = value[key]);

        Object.keys(new VehicleTechnicalSpecifications()).forEach(key=> this.technicalSpecifications[key] = value[key]);

        this._getRelatedVehicles(this.vehicleListModel.id);
      },
      error: (err)=>{
        debugger;
        alert('Error');
      }
    });
  }

  private _getRelatedVehicles(vehicleId: number){
    this.http.get(ApiEndpoints.getRelated+'/'+vehicleId)
    .subscribe({
      next: (value: any)=>{
        debugger;
        this.relatedVehicles = value;
      },
      error: (err)=>{
        alert('Error in get related');
      }
    });
  }

}
