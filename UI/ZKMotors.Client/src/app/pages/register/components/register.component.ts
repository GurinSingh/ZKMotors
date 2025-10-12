import { Component } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import { IUser, UserManagerService } from 'app/core';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  constructor(private _userManager: UserManagerService) {
  }

  register = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    userName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl(''),
    roleIds: new FormControl([2]),
  });
  onSubmit(){
    debugger;
    this._userManager.register(<any>this.register.value).subscribe({
      next: (value: IUser)=>{
        console.log(value);
      },
      error: (err)=>{
        console.log(err);
        alert('err');
      }
    });
  }
}
