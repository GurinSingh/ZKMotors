import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiEndpoints } from 'environments/api-endpoints';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { VehicleDetailsModel, VehicleBasicIdentifications, VehicleTechnicalSpecifications } from 'app/user/models';

@Component({
  selector: 'user-vehicle-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './vehicle-details.component.html',
  styleUrl: './vehicle-details.component.css'
})
export class VehicleDetailsComponent implements OnInit {
  vehicleListModel: VehicleDetailsModel = new VehicleDetailsModel();
  basicIdentifications: Record<string, any> = {};
  technicalSpecifications: Record<string, any> = {};
  relatedVehicles: Array<VehicleDetailsModel> = [];

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
