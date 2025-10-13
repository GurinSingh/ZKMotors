import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserHeaderComponent } from 'app/user/layouts';

@Component({
  selector: 'user-layout',
  imports: [UserHeaderComponent, RouterOutlet ],
  templateUrl: './user-layout.component.html',
  styleUrl: './user-layout.component.css'
})
export class UserLayoutComponent {

}
