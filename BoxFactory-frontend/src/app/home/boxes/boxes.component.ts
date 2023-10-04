import { Component, OnInit } from '@angular/core';
import { Box } from 'src/app/models/Box';
import { BoxService } from 'src/app/services/box.service';
import { UpdateboxComponent } from '../updatebox/updatebox.component';
import { ModalController } from '@ionic/angular';
import { ModifyBox } from 'src/app/models/requestModels/ModifyBox';

@Component({
	selector: 'app-boxes',
	templateUrl: './boxes.component.html',
	styleUrls: ['./boxes.component.scss'],
})
export class BoxesComponent implements OnInit {

	boxes: Box[] = [];

	constructor(private boxservice: BoxService, private modalController: ModalController) { }

	ngOnInit(): void {
		this.boxservice.loadAllBoxes();

		this.boxservice.boxes.subscribe(newData => {
			this.boxes = newData;
		});
	}

	delete(id: number) {
		this.boxservice.delete(id);
	}

    async update(id: number) {
		const modal = await this.modalController.create({
			component: UpdateboxComponent,
			componentProps: { currentId: id },
		});

		modal.onDidDismiss().then(data => {
			
		});

		await modal.present();
    }

	async openAddModal(): Promise<void> {
		const modal = await this.modalController.create({
			component: UpdateboxComponent,
			componentProps: { currentId: null },
		});

		modal.onDidDismiss().then(data => {
			const modifyObject: ModifyBox | undefined = data.data;

			if(!modifyObject) {
				console.error("Did not return modify object!");
				return;
			}

			this.boxservice.create(modifyObject);
		});

		await modal.present();
	}
}
