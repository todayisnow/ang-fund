import { Component } from '@angular/core' 

@Component({
    selector: 'nav-bar',
    moduleId: './app/nav/',
    templateUrl: './nav-bar.component.html',
    styles: [`
     li > a.active {color: #F97924}
    .nav.navbar-nav {font-size: 15px;}
    #searchForm {margin-right: 100ppx;}
    @media (max-width: 1200px) {#searchForm {display:none}}
`]
})

export class NavBarComponent {
}