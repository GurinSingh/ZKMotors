import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserManagerService } from 'app/core';

@Component({
  selector: 'admin-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './admin-header.component.html',
  styleUrl: './admin-header.component.css'
})
export class AdminHeaderComponent {
  userName: string = 'Coming soon';

  constructor(private _userManager: UserManagerService, private _router: Router) { }

  onLogout() {
    this._userManager.logout();
    this._router.navigate(['login']);
  }
}
