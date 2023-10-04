import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Box} from "../models/Box";

@Injectable({
  providedIn: 'root'
})
export class BoxService {

  readonly url : string = 'http://localhost:5206/api/Box';
  constructor(public http: HttpClient) { }

  getAllBoxes() {
    let result = this.http.get<Box[]>(this.url)
    return result;
  }
}
