import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAddVehicleModel, IDashboardStats, IViewVehicleModel } from 'app/core/models/services/dataAccess/vehicle.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  constructor(private _http: HttpClient) { }

  getVehicleInformation(vehicleMakeId: number, vehicleModelId: number, year?: number, trim?: string): Observable<IViewVehicleModel> {
    let q = 'vehicleMakeId=' + vehicleMakeId + '&vehicleModelId=' + vehicleModelId + '&year=' + year + '&trim=' + trim;
    return this._http.get<IViewVehicleModel>(ApiEndpoints.getVehicleInformation + '?' + q);
  }

  add(vehicle: IAddVehicleModel): Observable<IAddVehicleModel> {
    return this._http.post<IAddVehicleModel>(ApiEndpoints.addVehicles, vehicle);
  }

  getVehiclesForSale(): Observable<IViewVehicleModel[]> {
    return this._http.get<IViewVehicleModel[]>(ApiEndpoints.getAllVehicles);
  }

  getDashboardStats(): Observable<IDashboardStats>{
    return this._http.get<IDashboardStats>(ApiEndpoints.getDashboardStats);
  }
}
