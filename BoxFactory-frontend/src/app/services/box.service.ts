import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Box} from "../models/Box";
import { BehaviorSubject, Subject } from 'rxjs';
import { HttpResponse } from '@capacitor/core';

@Injectable({
  providedIn: 'root'
})
export class BoxService {

  readonly url : string = 'http://localhost:5206/api/Box';

	boxes = new BehaviorSubject<Box[]>([]); 

  constructor(public http: HttpClient) { }

  loadAllBoxes(): void {
    let response = this.http.get<Box[]>(this.url);

		response.subscribe(boxes => this.boxes.next(boxes));
  }

	delete(id: number): void {

		let response = this.http.delete(this.url + "/" + id, { observe: "response" });

		response.subscribe(result => {
			if(result.status === 204) {
				let current: Box[] = this.boxes.getValue();
		
				let newState = current.filter(f => f.id != id);
		
				this.boxes.next(newState);
			}
		});
	}
}
