import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { Box } from 'src/app/models/Box';
import { BoxOrderLine } from 'src/app/models/BoxOrder';
import { AddOrderLine, CreateOrder } from 'src/app/models/requestModels/CreateOrder';
import { BoxService } from 'src/app/services/box.service';

@Component({
    selector: 'app-addorder',
    templateUrl: './addorder.component.html',
    styleUrls: ['./addorder.component.scss'],
})
export class AddorderComponent implements OnInit {

    inputForm: FormGroup;

    lines: AddOrderLine[] = [];

    constructor(private modalController: ModalController, private boxService: BoxService) {
        this.inputForm = new FormGroup({
            street: new FormControl(),
            number: new FormControl(),
            city: new FormControl(),
            zip: new FormControl(),
        });
    }

    ngOnInit() { }

    submitForm(): void {
        if(!this.inputForm.valid) {
            console.error("Input form not valid", this.inputForm);
            return;
        }

        const createModel: CreateOrder = {
            street: this.inputForm.get("street")!.value,
            number: this.inputForm.get("number")!.value,
            city: this.inputForm.get("city")!.value,
            zip: this.inputForm.get("zip")!.value,
            orderLines: this.lines
        }

        this.modalController.dismiss(createModel);
    }

    addLine(): void {
        const lineToAdd: AddOrderLine = {
            boxId: 1,
            amount: 1,
            price: 1
        }

        this.lines.push(lineToAdd)
    }

    cancel(): void {
        this.modalController.dismiss(null);
    }

    boxIdChanged(index: number, boxId: string): void {

        const boxIdNumber: number = Number(boxId);

        if(isNaN(boxIdNumber)) {
            this.lines[index].amount = 0;
            this.lines[index].price = 0;
            return;
        }

        const boxes: Box[] = this.boxService.boxes.getValue();

        const selectedBox = boxes.find(f => f.id == boxIdNumber);

        this.lines[index].price = selectedBox?.price ?? -1;
    }
}
