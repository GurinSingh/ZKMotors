import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IUser, UserManagerService } from 'app/core';


@Component({
  selector: 'user-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private _userManager: UserManagerService) {  }

  loginForm = new FormGroup({
    userName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  onSubmit(){
    this._userManager.login(<any>this.loginForm.value).subscribe({
      next: (value: IUser)=> {
        console.log(value);
      },
      error: (err)=>{
        console.log(err);
        alert('err');
      }
    });
  }
}
