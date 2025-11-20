import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IViewFuelTypeModel } from 'app/core/models/services/dataAccess/fuel-type.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FuelTypeService {
  constructor(private _http: HttpClient) {  }

  getAll(): Observable<IViewFuelTypeModel[]>{
    return this._http.get<IViewFuelTypeModel[]>(ApiEndpoints.getAllFuelTypes);
  }
 
}
