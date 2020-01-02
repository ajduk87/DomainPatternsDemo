import { Component, OnInit, OnChanges, SimpleChanges, Input } from '@angular/core';
import { DataService } from '../data.service';

@Component({
    selector: 'app-display',
    templateUrl: './display.component.html',
    styleUrls: ['./display.component.css']
})

export class DisplayComponent implements OnInit, OnChanges {
    @Input() endpoint;
    data: any;
    ngOnChanges(changes: SimpleChanges): void {
        if (changes.endpoint.previousValue !== undefined) {
            const currentValue: string = changes.endpoint.currentValue;
            this.dataService.get(currentValue)
            .subscribe(data => {
                this.data = data;
                console.log(data);
            });
        }
    }
    constructor(private dataService: DataService) {}

    ngOnInit() { }
}
