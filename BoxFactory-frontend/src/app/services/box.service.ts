import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Box } from "../models/Box";
import { BehaviorSubject, Subject } from 'rxjs';
import { HttpResponse } from '@capacitor/core';
import { ModifyBox } from '../models/requestModels/ModifyBox';

@Injectable({
    providedIn: 'root'
})
export class BoxService {

    readonly url: string = 'http://localhost:5206/api/Box';

    boxes = new BehaviorSubject<Box[]>([]);

    constructor(private http: HttpClient) {
        this.loadAllBoxes();
    }

    loadAllBoxes(): void {
        let response = this.http.get<Box[]>(this.url);

        response.subscribe(boxes => this.boxes.next(boxes));
    }

    getBox(id: number) {
        return this.http.get<Box | null>(`${this.url}/${id}`);
    }

    delete(id: number): void {

        let response = this.http.delete(this.url + "/" + id, { observe: "response" });

        response.subscribe(result => {
            if (result.status === 204) {
                let current: Box[] = this.boxes.getValue();

                let newState = current.filter(f => f.id != id);

                this.boxes.next(newState);
            }
        });
    }

    create(object: ModifyBox): void {
        let response = this.http.post<Box | null>(this.url, object);

        response.subscribe(result => {
            if (!result) {
                return;
            }

            let boxes: Box[] = this.boxes.getValue();
            boxes.push(result);

            this.boxes.next(boxes);
        });
    }

    update(id: number, object: ModifyBox): void {

        let response = this.http.patch<Box | null>(`${this.url}/${id}`, object);

        response.subscribe(result => {
            if (!response) {
                return;
            }

            let boxes: Box[] = this.boxes.getValue();

            const box: Box | undefined = boxes.find(f => f.id === id);

            if (!box) {
                return;
            }

            box.width = object.width;
            box.height = object.height;
            box.length = object.length;
            box.weight = object.weight;
            box.color = object.color;
            box.price = object.price;

            this.boxes.next(boxes);
        });
    }
}
