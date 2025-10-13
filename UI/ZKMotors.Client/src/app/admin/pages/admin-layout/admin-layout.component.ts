import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AdminHeaderComponent } from "app/admin/layout";
import { SidebarComponent } from "app/admin/layout/sidebar/sidebar.component";

@Component({
  selector: 'admin-layout',
  imports: [AdminHeaderComponent, RouterOutlet, SidebarComponent],
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.css'
})
export class AdminLayoutComponent {

}
