import { Injectable } from '@angular/core'

declare let toastr: any // just to tell compilr not to worry about our global scoop

@Injectable()

export class ToastrService {

    success(message: string, title?: string) {
        toastr.success(message,title)
    }
    info(message: string, title?: string) {
        toastr.info(message, title)
    }
    warning(message: string, title?: string) {
        toastr.warning(message, title)
    }
    error(message: string, title?: string) {
        toastr.errors(message, title)
    }

} 