import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IViewBodyTypeModel } from 'app/core/models/services/dataAccess/body-type.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleBodyTypeService {
  constructor(private _http: HttpClient){}

  getAll(): Observable<IViewBodyTypeModel[]>{
    return this._http.get<IViewBodyTypeModel[]>(ApiEndpoints.getAllBodyTypes);
  }
}
