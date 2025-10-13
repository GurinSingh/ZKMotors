import { Routes } from "@angular/router";
import { HomeComponent } from "./features/home/home.component";

export const userRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'vehicle/get', loadComponent: () => import('./features/vehicles-list/vehicles-list.component').then(m=> m.VehiclesListComponent) },
    { path: 'vehicle/:slug', loadComponent: () => import('./features/vehicle-details/vehicle-details.component').then(m=> m.VehicleDetailsComponent) },
    { path: 'login', loadComponent: ()=> import('./pages/login/login.component').then(m=> m.LoginComponent) },
    { path: 'register', loadComponent: ()=> import('./pages/register/register.component').then(m=> m.RegisterComponent) }
]