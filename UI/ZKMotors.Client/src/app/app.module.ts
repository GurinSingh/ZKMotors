import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VehiclesListComponent } from './features/components/vehicles-list/vehicles-list.component';
import { VehicleDetailsComponent } from './features/components/vehicle-details/vehicle-details.component';
import { HomeComponent } from './features/components/home/home.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    VehiclesListComponent,
    VehicleDetailsComponent,
    HomeComponent,
    AppRoutingModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
