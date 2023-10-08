import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { BoxOrder } from '../models/BoxOrder';
import { CreateOrder } from '../models/requestModels/CreateOrder';

@Injectable({
    providedIn: 'root'
})
export class OrdersService {

    readonly url: string = 'http://localhost:5206/api/BoxOrders';

    orders = new BehaviorSubject<BoxOrder[]>([]);

    constructor(private http: HttpClient) { }

    loadAllOrders(): void {
        let response = this.http.get<BoxOrder[]>(this.url);

        response.subscribe(orders => this.orders.next(orders));
    }

    delete(id: number) {
		let response = this.http.delete(this.url + "/" + id, { observe: "response" });

        response.subscribe(result => {
			if (result.status === 204) {
				let current: BoxOrder[] = this.orders.getValue();

				let newState = current.filter(f => f.id != id);

				this.orders.next(newState);
			}
		});
    }

    createOrder(createOrder: CreateOrder) {
        let response = this.http.post<BoxOrder | null>(this.url, createOrder);

        response.subscribe(result => {
            if (!result) {
                return;
            }

            let boxes: BoxOrder[] = this.orders.getValue();

            boxes.push(result);

            this.orders.next(boxes);
        });
    }
}
