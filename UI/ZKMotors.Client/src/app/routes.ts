import { Routes } from "@angular/router";
import { AdminLayoutComponent } from "./admin/pages";
import { UserLayoutComponent } from "./user/pages";

export const appRoutes: Routes = [
    { 
        path: '', 
        component: UserLayoutComponent,
        loadChildren: ()=> import('./user/user.routes').then(m=> m.userRoutes)
    },
    { 
        path: 'admin', 
        component: AdminLayoutComponent, 
        loadChildren: ()=> import('./admin/admin.routes').then(m => m.adminRoutes) 
    }
]
