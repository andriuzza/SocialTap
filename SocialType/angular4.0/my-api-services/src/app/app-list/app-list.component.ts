import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import{Location} from '../location'
@Component({
  selector: 'app-app-list',
  templateUrl: './app-list.component.html',
  styleUrls: ['./app-list.component.css']
})
export class AppListComponent implements OnInit {
  @Input()  element: Location;
  teisingas: boolean = false;
  @Output() call = new EventEmitter<Location>();

  public OpenAlert(): void{
     var el: Location = {
      Name: this.element.Name,
      Address: this.element.Address,
      Latitude: this.element.Latitude,
      Longitude: this.element.Longitude
     };
    
    this.call.emit(el);
  }
  constructor() { }

  ngOnInit() {
  }

}
