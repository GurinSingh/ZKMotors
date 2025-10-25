import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IVehicleModel } from 'app/core/models/services/dataAccess/vehicle-model.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleModelService {
  constructor(private _http: HttpClient){}

  getAll(): Observable<IVehicleModel[]>{
    return this._http.get<IVehicleModel[]>(ApiEndpoints.getAllVehicleModels);
  }
}
