import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IVehicle } from 'app/core/models/vehicle.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  constructor(private _http: HttpClient) { }

  getVehicleInformation(vehicleMakeId: number, vehicleModelId: number, year?: number, trim?: string): Observable<IVehicle> {
    let q = 'vehicleMakeId=' + vehicleMakeId + '&vehicleModelId=' + vehicleModelId + '&year=' + year + '&trim=' + trim;
    return this._http.get<IVehicle>(ApiEndpoints.getVehicleInformation + '?' + q);
  }

  add(vehicle: IVehicle): Observable<IVehicle> {
    return this._http.post<IVehicle>(ApiEndpoints.addVehicles, vehicle);
  }
}
