import { Component, OnInit } from '@angular/core';
import { Box } from 'src/app/models/Box';
import { BoxService } from 'src/app/services/box.service';
import { UpdateboxComponent } from '../updatebox/updatebox.component';
import { ModalController } from '@ionic/angular';
import { ModifyBox } from 'src/app/models/requestModels/ModifyBox';
import { Router } from '@angular/router';
import { TypeModifier } from '@angular/compiler';

@Component({
	selector: 'app-boxes',
	templateUrl: './boxes.component.html',
	styleUrls: ['./boxes.component.scss'],
})
export class BoxesComponent implements OnInit {

	boxes: Box[] = [];

	constructor(private boxservice: BoxService, private modalController: ModalController, private router: Router) { }

	ngOnInit(): void {
		this.boxservice.loadAllBoxes();

		this.boxservice.boxes.subscribe(newData => {
			const tempResult = newData.map(value => Object.assign(new Box(), value));

            this.boxes = tempResult;
		});
	}

	delete(id: number) {
		this.boxservice.delete(id);
	}

    async update(id: number) {
        const boxToEdit: Box | undefined = this.boxes.find(f => f.id === id);

        if(!boxToEdit) {
            console.log("Could not edit the box since it was not found!");
            return;
        }

		const modal = await this.modalController.create({
			component: UpdateboxComponent,
			componentProps: { box: boxToEdit},
		});

		modal.onDidDismiss().then(data => {
			const modifyObject: ModifyBox | undefined = data.data;

            if(!modifyObject) {
                console.log("Did not return modify object");
                return;
            }

            this.boxservice.update(id, modifyObject);
		});

		await modal.present();
    }

	async openAddModal(): Promise<void> {
		const modal = await this.modalController.create({
			component: UpdateboxComponent,
			componentProps: { box: null },
		});

		modal.onDidDismiss().then(data => {
			const modifyObject: ModifyBox | undefined = data.data;

			if(!modifyObject) {
				console.log("Did not return modify object");
				return;
			}

			this.boxservice.create(modifyObject);
		});

		await modal.present();
	}

    showBox(id: number) {
        this.router.navigate([`boxes/view/${id}`]);
    }
}
