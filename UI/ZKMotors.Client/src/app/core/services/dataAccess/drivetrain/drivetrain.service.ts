import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IViewDrivetrainModel } from 'app/core/models/services/dataAccess/drivetrain.model';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DrivetrainService {
  constructor(private _http: HttpClient){}

  getAll(): Observable<IViewDrivetrainModel[]>{
    return this._http.get<IViewDrivetrainModel[]>(ApiEndpoints.getAllDrivetrains);
  }
}
