import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from 'app/app.component';
import { jwtInterceptor } from 'app/core';
import { provideRouter } from '@angular/router';
import { appRoutes } from 'app/routes';

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(withInterceptors([jwtInterceptor])),
    provideRouter(appRoutes)
  ]
}).catch((err) => console.error(err));
