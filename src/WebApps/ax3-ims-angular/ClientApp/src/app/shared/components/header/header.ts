import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl: './header.html',
    styleUrls: ['./header.scss']
})
export class Header {
    @Input()
    url: string;
}
