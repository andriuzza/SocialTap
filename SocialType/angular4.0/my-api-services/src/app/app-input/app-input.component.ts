import { Component, OnInit, NgModule, Output, EventEmitter, Input } from '@angular/core';
import {NgForm} from '@angular/forms';
import{Location} from '../location';

@Component({
  selector: 'app-app-input',
  templateUrl: './app-input.component.html',
  styleUrls: ['./app-input.component.css']
})
export class AppInputComponent implements OnInit {
 @Output() SendOut : EventEmitter<Location> = new EventEmitter();
location1: Location = {
  Name:"fasfa",
  Address:"fasfas",
  Latitude: 0,
  Longitude: 0
};

  ifClicked = false;
  constructor() { }

  public Clicked(data: Location): void {
    var a: Location = {
      Name : data.Name,
      Address : data.Address,
      Latitude: 456465,
      Longitude: 454545
    };
    this.ifClicked = true;
    this.SendOut.emit(a);
    

  }
  unClicked(){
    this.ifClicked = false;
  }
  ngOnInit() {
  }
 
}
