import { Routes } from "@angular/router";
import { AdminLayoutComponent } from "./pages/admin-layout/admin-layout.component";
import { DashboardComponent } from "./pages";

export const adminRoutes: Routes = [
    {
        path: 'dashboard', component: DashboardComponent
    },
    { 
        path: 'vehicle/add', 
        loadComponent: () => import('./features/add-vehicle/add-vehicle.component').then(m => m.AddVehicleComponent) 
    },
]