import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent, VehiclesListComponent, VehicleDetailsComponent } from './features';
import { RegisterComponent, LoginComponent } from './pages';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'vehicle/get', component: VehiclesListComponent},
  {path: 'vehicle/:slug', component: VehicleDetailsComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
