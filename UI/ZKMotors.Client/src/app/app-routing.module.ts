import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApiEndpoints } from 'environments/api-endpoints';
import { VehiclesListComponent } from './features/components/vehicles-list/vehicles-list.component';
import { VehicleDetailsComponent } from './features/components/vehicle-details/vehicle-details.component';
import { HomeComponent } from './features/components/home/home.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'vehicle/get', component: VehiclesListComponent},
  {path: 'vehicle/get/:slug', component: VehicleDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
