
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Component({
    moduleId: './app/user/',
    templateUrl: 'login.component.html',
    styles: [`
em {float:right; color:#E05c65; padding-left:10px}
`]
})
export class LoginComponent {
    loginInvalid: boolean = false;

    constructor(private authService: AuthService, private router: Router) {

    }
    Login(formValues) {
        this.authService.loginUser(formValues.userName, formValues.password).subscribe(resp => {
            if (!resp) {
                this.loginInvalid = true;
            } else {

                this.router.navigate(['events']);
            }
        });
    }
    cancel() {
        this.router.navigate(['/events']);
    }
}
