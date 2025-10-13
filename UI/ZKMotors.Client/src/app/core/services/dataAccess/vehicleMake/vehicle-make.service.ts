import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IVehicleMake } from 'app/core/models/vehicle-make.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleMakeService {
  constructor(private _http: HttpClient) {}

  create(vehicleMake: IVehicleMake):Observable<IVehicleMake>{
    return this._http.post<IVehicleMake>(ApiEndpoints.addVehicles, vehicleMake);
  }

  getAll(): Observable<IVehicleMake[]>{
    return this._http.get<IVehicleMake[]>(ApiEndpoints.getAllVehicleMakes);
  }
}
