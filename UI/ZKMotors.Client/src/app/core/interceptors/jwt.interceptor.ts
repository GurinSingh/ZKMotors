import { HttpInterceptorFn } from '@angular/common/http';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('authToken');

  if(token){
    const modifiedReq = req.clone({
      setHeaders: {
        Authorization: 'Bearer ' + token
      }
    });

    return next(modifiedReq);
  }

  return next(req);
};
