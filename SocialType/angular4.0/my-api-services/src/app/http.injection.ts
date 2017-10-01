import {Injectable} from '@angular/core';
import {Http, Response} from '@angular/http';
import {Location} from './location';
import 'rxjs/add/operator/map';
@Injectable()
export class LocationData{
    constructor(private _http: Http){}
       getLocation(){
        return this._http.get("http://localhost:55700/api/locations").map((respnse: Response )=>respnse.json());
    }
    postLocation(servers: Location){
        return this._http.post('http://localhost:55700/api/locations', servers);
    }
    
}