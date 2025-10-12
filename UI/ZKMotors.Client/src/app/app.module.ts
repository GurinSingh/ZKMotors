import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VehiclesListComponent } from './features/vehicles-list/components/vehicles-list.component';
import { VehicleDetailsComponent } from './features/vehicle-details/components/vehicle-details.component';
import { HomeComponent } from './features/home/components/home.component';
import { jwtInterceptor } from './core/interceptors/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    VehiclesListComponent,
    VehicleDetailsComponent,
    HomeComponent,
    AppRoutingModule,
    
  ],
  providers: [
    provideHttpClient(withInterceptors([jwtInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
