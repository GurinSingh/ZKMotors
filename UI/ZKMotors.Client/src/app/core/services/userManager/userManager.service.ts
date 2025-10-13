import { Injectable } from '@angular/core';
import { UserService } from '../dataAccess/user/user.service';
import { ILoginRequest, IRegisterRequest, IUser } from 'app/core/models/user-service.model';
import { NotExpr } from '@angular/compiler';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserManagerService {
  private _currentUser: IUser | null = null;
  constructor(private _userService: UserService){}

  register(registerRequest: IRegisterRequest): Observable<IUser>{
    return this._userService.register(registerRequest);
  }
  
  login(loginRequest: ILoginRequest): Observable<IUser> {
    return this._userService.login(loginRequest).pipe(
      tap(user =>{
        this._currentUser = user;
        localStorage.setItem('authToken', user.token);
      })
    );
  }

  logout(): void{
    this._currentUser = null;
    localStorage.removeItem('authToken');
  }

  isLoggedIn(): boolean{
    return this._currentUser !== null;
  }

  getCurrentUser(): IUser | null{
    return this._currentUser;
  }
}
