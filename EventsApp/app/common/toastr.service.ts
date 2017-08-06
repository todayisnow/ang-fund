// to use global var that has been added as js in index you can make service class and wrap its functions or use OpaqueTocken and interface for just intelicence

//import { Injectable } from '@angular/core'

//declare let toastr: any // just to tell compilr not to worry about our global scoop

//@Injectable()

//export class ToastrService {

//    success(message: string, title?: string) {
//        toastr.success(message,title)
//    }
//    info(message: string, title?: string) {
//        toastr.info(message, title)
//    }
//    warning(message: string, title?: string) {
//        toastr.warning(message, title)
//    }
//    error(message: string, title?: string) {
//        toastr.errors(message, title)
//    }

//} 
import { OpaqueToken} from '@angular/core'

export let TOASTR_TOCKEN = new OpaqueToken('toastr')
export interface Toastr {
    success(message: string, title?: string): void
    info(message: string, title?: string): void
    warning(message: string, title?: string): void
    error(message: string, title?: string): void
}

