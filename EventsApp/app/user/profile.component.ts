import { Component, OnInit, Inject } from '@angular/core'
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Router } from '@angular/router'
import { AuthService } from './auth.service'
import { TOASTR_TOCKEN, Toastr  } from '../common/toastr.service'


@Component({
    moduleId: './app/user/',
    templateUrl: 'profile.component.html',
    styles: [`
em {float:right; color:#E05C65;padding-left:10px}
.error input {background-color:#E3C3C5}
.error ::-webkit-input-placeholder {color:#999}
.error ::-moz-placeholder {color:#999}
.error :-moz-placeholder {color:#999}
.error :-ms-input-placeholder {color:#999}


`]
})
export class ProfileComponent implements OnInit {
    profileForm: FormGroup
    private firstName: FormControl
    private lastName: FormControl

    constructor(
        private router: Router,
        private auth: AuthService,
        @Inject(TOASTR_TOCKEN) private toastr: Toastr
    ) {
        
    }
    ngOnInit() {

        this.firstName = new FormControl(this.auth.currentUser.firstName, [Validators.required, Validators.pattern('[a-zA-Z].*')])
        this.lastName = new FormControl(this.auth.currentUser.lastName, Validators.required)
        this.profileForm = new FormGroup({
            firstName: this.firstName,
            lastName: this.lastName
        })


    }
    cancel() {
        this.router.navigate(['/events'])
    }
    save(formValues) {
        if (this.profileForm.valid) {
            this.auth.updateCurrentUser(formValues.firstName, formValues.lastName)
            this.toastr.success("Current User Saved")
            this.router.navigate(['/events']);
        }
    }
    validateFirstName() {
        return this.firstName.valid || this.firstName.untouched
    }
    validateLastName() {
        return this.lastName.valid || this.lastName.untouched
    }
   
   

}
