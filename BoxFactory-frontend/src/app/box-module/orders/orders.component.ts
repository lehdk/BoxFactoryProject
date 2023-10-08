import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BoxOrder } from 'src/app/models/BoxOrder';
import { OrdersService } from 'src/app/services/orders.service';
import { AddorderComponent } from '../addorder/addorder.component';
import { ModalController } from '@ionic/angular';
import { CreateOrder } from 'src/app/models/requestModels/CreateOrder';

@Component({
    selector: 'app-orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.scss'],
})
export class OrdersComponent implements OnInit, OnDestroy {

    orders: BoxOrder[] = [];

    subscriptions: Subscription[] = [];

    constructor(private orderService: OrdersService, public router: Router, private modalController: ModalController) { }

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

    showOrder(id: number) { }

    search(event: any): void {

        const searchString: string = event.target.value.toString();

        if (searchString.length == 0) {
            this.orders = this.orderService.orders.getValue();
            return;
        }

        this.orders = this.orderService.orders.getValue().filter(o => {
            if (o.id + "" == event.target.value.toString()) return true;
            if (o.street.toUpperCase().includes(searchString.toUpperCase())) return true;
            if (o.number.toUpperCase().includes(searchString.toUpperCase())) return true;
            if (o.city.toUpperCase().includes(searchString.toUpperCase())) return true;
            if (o.zip.toUpperCase().includes(searchString.toUpperCase())) return true;

            return false;
        })
    }

    ngOnDestroy(): void {
        this.subscriptions.forEach(s => {
            s.unsubscribe();
        });
    }

    async openAddModal(): Promise<void> {
        const modal = await this.modalController.create({
			component: AddorderComponent
		});

        modal.onDidDismiss().then(data => {
			const modifyObject: CreateOrder | undefined = data.data;

            console.log(modifyObject);

			if(!modifyObject) {
				console.log("Did not return create data");
				return;
			}

			this.orderService.createOrder(modifyObject);
		});

        await modal.present();
    }
}
