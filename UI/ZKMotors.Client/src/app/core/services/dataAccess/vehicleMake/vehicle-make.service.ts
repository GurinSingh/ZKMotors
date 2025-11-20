import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IVehicleMakeModel } from 'app/core/models/services/dataAccess/vehicle-make.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleMakeService {
  constructor(private _http: HttpClient) {}

  create(vehicleMake: IVehicleMakeModel):Observable<IVehicleMakeModel>{
    return this._http.post<IVehicleMakeModel>(ApiEndpoints.addVehicles, vehicleMake);
  }

  getAll(): Observable<IVehicleMakeModel[]>{
    return this._http.get<IVehicleMakeModel[]>(ApiEndpoints.getAllVehicleMakes);
  }
}
