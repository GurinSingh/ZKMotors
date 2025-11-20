import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, tap, throwError } from 'rxjs';
import { UserService } from '../services/dataAccess/user/user.service';
import { inject } from '@angular/core';
import { UserManagerService } from '../services/userManager/userManager.service';
import { Router } from '@angular/router';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  const userManager: UserManagerService = inject(UserManagerService);
  const router: Router = inject(Router);

  let handleHttpResponse = (error: HttpErrorResponse)=>{
    debugger;
    if(error.status == 401){
      userManager.logout();
      router.navigate(['login']);
    }

    console.log(error);
  }
  return next(req).pipe(
    catchError(error => {
      handleHttpResponse(error);

      return throwError(() => error);
    })
  );
};


