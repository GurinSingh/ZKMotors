import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IViewTransmissionModel } from 'app/core/models/services/dataAccess/transmission.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransmissionService {
  constructor(private _http: HttpClient){}

  getAll(): Observable<IViewTransmissionModel[]>{
    return this._http.get<IViewTransmissionModel[]>(ApiEndpoints.getAllTransmissions);
  }
}
