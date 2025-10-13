import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'admin-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './admin-header.component.html',
  styleUrl: './admin-header.component.css'
})
export class AdminHeaderComponent {

}
