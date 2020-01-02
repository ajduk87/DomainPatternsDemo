import { Component, OnInit} from '@angular/core';

@Component({
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css'],
    selector: 'app-main'
})

export class MainComponent implements OnInit {
    selection = '-';
    ngOnInit(): void {
    }
    constructor() {}
    select(param: any): void {
        this.selection = param.target.textContent;
    }
}
