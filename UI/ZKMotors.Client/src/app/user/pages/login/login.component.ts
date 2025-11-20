import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser, UserManagerService } from 'app/core';


@Component({
  selector: 'user-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private _userManager: UserManagerService, private _router: Router) {
    if(this._userManager.isLoggedIn())
      this._router.navigate(['admin/dashboard']);
  }

  loginForm = new FormGroup({
    userName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  onSubmit(){
    this._userManager.login(<any>this.loginForm.value).subscribe({
      next: (value: IUser)=> {
        console.log(value);
        this._router.navigate(['admin/dashboard']);
      },
      error: (err)=>{
        console.log(err);
        alert('err');
      }
    });
  }
}
