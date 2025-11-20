import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UserManagerService } from 'app/core/services/userManager/userManager.service';

export const authGuard: CanActivateFn = (route, state) => {
  const userManager = inject(UserManagerService);
  const router = inject(Router);

  if(userManager.isLoggedIn())
    return true;
  else{
    router.navigate(['/login']);
    return false;
  }
};
