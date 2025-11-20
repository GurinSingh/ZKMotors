import { Routes } from "@angular/router";
import { AdminLayoutComponent } from "./admin/pages";
import { UserLayoutComponent } from "./user/pages";
import { authGuard } from "./core/guards/auth/auth.guard";

export const appRoutes: Routes = [
    { 
        path: '', 
        component: UserLayoutComponent,
        loadChildren: ()=> import('./user/user.routes').then(m=> m.userRoutes)
    },
    { 
        path: 'admin', 
        component: AdminLayoutComponent, 
        loadChildren: ()=> import('./admin/admin.routes').then(m => m.adminRoutes),
        canLoad: [authGuard],
        canActivate: [authGuard]
    }
]
