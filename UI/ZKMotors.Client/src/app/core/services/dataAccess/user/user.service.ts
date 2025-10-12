import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRegisterRequest, ILoginRequest, IUser } from 'app/core/models/iUserService';
import { ApiEndpoints } from 'environments/api-endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private _http: HttpClient) {
  }
  register(registerRequest: IRegisterRequest): Observable<IUser> {
    return this._http.post<IUser>(ApiEndpoints.registerUser, registerRequest);
  }

  login(loginRequest: ILoginRequest): Observable<IUser>{
    return this._http.post<IUser>(ApiEndpoints.loginUser, loginRequest);
  }
}
