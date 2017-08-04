
import { Component } from '@angular/core';
import { Router } from '@angular/router'
import { AuthService } from './auth.service'

@Component({
    moduleId:'./app/user/',
    templateUrl: 'login.component.html',
    styles: [`
em {float:right; color:#E05c65; padding-left:10px}
`]
})
export class LoginComponent {

    constructor(private authService: AuthService, private  router:Router) {

    }
    Login(formValue)
    {
        this.authService.loginUser(formValue.userName, formValue.password)
        if (this.authService.isAuthenticated())
        {
            this.router.navigate(['/events'])
        }
    }
    cancel()
    {
     
            this.router.navigate(['/events'])
        
    }
}
