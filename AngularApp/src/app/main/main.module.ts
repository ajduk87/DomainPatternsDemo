import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { MainComponent } from './main.component';
import { DisplayComponent } from './display/display.component';
import { DataService } from './data.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    MainComponent,
    DisplayComponent
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    HttpClientModule
  ],
  providers: [
    DataService
  ],
  exports: [
    MainComponent
  ]
})
export class MainModule { }
