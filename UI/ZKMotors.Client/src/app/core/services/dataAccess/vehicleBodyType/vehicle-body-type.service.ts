import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBodyType } from 'app/core/models/body-type.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleBodyTypeService {
  constructor(private _http: HttpClient){}

  getAll(): Observable<IBodyType[]>{
    return this._http.get<IBodyType[]>(ApiEndpoints.getAllBodyTypes);
  }
}
