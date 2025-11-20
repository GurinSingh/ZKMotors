import { Injectable } from '@angular/core';
import { UserService } from '../dataAccess/user/user.service';
import { ILoginRequest, IRegisterRequest, IUser } from 'app/core/models/services/dataAccess/user-service.model';
import { NotExpr } from '@angular/compiler';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserManagerService {
  private readonly key: string = 'authToken';

  constructor(private _userService: UserService){ }

  register(registerRequest: IRegisterRequest): Observable<IUser>{
    return this._userService.register(registerRequest);
  }
  
  login(loginRequest: ILoginRequest): Observable<IUser> {
    return this._userService.login(loginRequest).pipe(
      tap(user =>{
        localStorage.setItem(this.key, user.token);
      })
    );
  }

  logout(): void{
    localStorage.removeItem(this.key);
  }

  isLoggedIn(): boolean{
    return localStorage.getItem(this.key) !== null;
  }

  getCurrentUser(): IUser | null{
    return null;
  }
}
