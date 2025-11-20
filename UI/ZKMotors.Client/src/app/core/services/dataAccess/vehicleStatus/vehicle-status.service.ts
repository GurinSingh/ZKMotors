import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IViewVehicleStatusModel } from 'app/core/models/services/dataAccess/vehicle-status.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleStatusService {

  constructor(private _http: HttpClient) {
  }

  getAll(): Observable<IViewVehicleStatusModel[]>{
    return this._http.get<IViewVehicleStatusModel[]>(ApiEndpoints.getAllVehicleStatus);
  }

  // getById(): Observable<ViewVehicleStatusModel>{
  //   return this._http.get<ViewVehicleStatusModel>(ApiEndpoints.getAllVehicleStatusById);
  // }
}
