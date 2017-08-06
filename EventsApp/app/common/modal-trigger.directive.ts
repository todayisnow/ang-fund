
import { Directive, OnInit, Inject, ElementRef, Input } from '@angular/core'
import { JQ_TOCKEN } from './jQuery.service'

@Directive({
    selector:'[modal-trigger]'
})
export class ModalTriggerDirective implements OnInit {
    private el: HTMLElement
    @Input('modal-trigger') modalId :string // alias becase cant use hyphen
    constructor(ref: ElementRef, @Inject(JQ_TOCKEN) private $: any) {
        this.el = ref.nativeElement
    }
    ngOnInit() {
        this.el.addEventListener('click', e => {
            this.$(`#${this.modalId}`).modal({})
        })
    }
}