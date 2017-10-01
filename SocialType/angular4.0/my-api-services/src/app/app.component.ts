import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Location} from './location';
import {LocationData} from './http.injection';
import {HttpModule} from '@angular/http';
import{Http} from '@angular/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  result = '';
  detaliu: Location={
    Name: '',
    Latitude :0,
    Longitude: 0,
    Address:''
  };
  naujas: Location={
    Name: '',
    Latitude :0,
    Longitude: 0,
    Address:''
  };
  locations = [];
  private http: Http;
  constructor(private _data: LocationData){

  }
 onOpen(loc: Location){
   console.log(loc.Name + "fsafashjfsaj");
 
  
   this.locations.push(loc);
   
    this.naujas.Name = loc.Name;
    this.naujas.Address= loc.Address;
    this.naujas.Latitude= loc.Latitude;
    this.naujas.Longitude= loc.Longitude;
    var a: Location = this.naujas;
  this._data.postLocation(loc).
  subscribe((response)=>console.log(response));
  }


  blah() {
    for (var i = 0; i < 5; i++){
      console.log(i);
    }
    i++;
  }


  GetDetails(loc:Location){
    this.detaliu.Name = loc.Name,
    this.detaliu.Address = loc.Address,
    this.detaliu.Latitude = loc.Latitude,
    this.detaliu.Longitude = loc.Longitude
    this.detaliu = loc;
  }

 // public asd : Location[];

   ngOnInit(): void {
    //  this.http.get<Location[]>('http://localhost:55700/api/locations').subscribe(
    //    data => this.asd = data,
    //    err => alert('something whent wrong'),
    //    () => this.asd.forEach(x => console.log(x.Name))
    //  );
   this._data.getLocation().subscribe(res=>this.locations = res);
   }

}


