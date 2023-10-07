import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BoxOrder } from 'src/app/models/BoxOrder';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
    selector: 'app-orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.scss'],
})
export class OrdersComponent implements OnInit, OnDestroy {

    orders: BoxOrder[] = [];
    
    subscriptions: Subscription[] = [];

    constructor(private orderService: OrdersService, public router: Router) {}
    
    ngOnInit() {
        this.orderService.loadAllOrders();

        const ordersSubscription = this.orderService.orders.subscribe(newData => {
            this.orders = newData;
		});

        this.subscriptions.push(ordersSubscription);
    }

    delete(id: number) {
        this.orderService.delete(id);
    }
    
    showOrder(id: number) {}

    search(event: any): void {

    }

    ngOnDestroy(): void {
        this.subscriptions.forEach(s => {
            s.unsubscribe();
        });
    }
}
