import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { CreateOrder } from 'src/app/models/requestModels/CreateOrder';

@Component({
    selector: 'app-addorder',
    templateUrl: './addorder.component.html',
    styleUrls: ['./addorder.component.scss'],
})
export class AddorderComponent implements OnInit {

    inputForm: FormGroup;

    constructor(private modalController: ModalController) {
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
            orderLines: []
        }

        this.modalController.dismiss(createModel);
    }

    cancel(): void {
        this.modalController.dismiss(null);
    }
}
