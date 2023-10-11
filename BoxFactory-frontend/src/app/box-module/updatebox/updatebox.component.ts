import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { Box, BoxColor } from 'src/app/models/Box';
import { ModifyBox } from 'src/app/models/requestModels/ModifyBox';

@Component({
    selector: 'app-updatebox',
    templateUrl: './updatebox.component.html',
    styleUrls: ['./updatebox.component.scss'],
})
export class UpdateboxComponent implements OnInit {

    //If this is set to null, it will be in create mode, and if there is a box it will be in update mode
    @Input() box: Box | null = null;

    public boxColorValues = Object.values(BoxColor).filter(value => typeof value !== 'number');

    inputForm: FormGroup;

    constructor(private modalController: ModalController) {
        this.inputForm = new FormGroup({
            width: new FormControl(1, [
                Validators.required,
                Validators.min(1),
                Validators.max(2000)
            ]),
            height: new FormControl(1, [
                Validators.required,
                Validators.min(1),
                Validators.max(2000)
            ]),
            length: new FormControl(1, [
                Validators.required,
                Validators.min(1),
                Validators.max(2000)
            ]),
            weight: new FormControl(1, [
                Validators.required,
                Validators.min(0)
            ]),
            color: new FormControl("Red", [
                Validators.required
            ]),
            price: new FormControl(1, [
                Validators.required,
                Validators.min(1),
                Validators.max(2000)
            ]),
        });
    }

    ngOnInit() {
        this.setValuesIfInUpdateMode();
    }

    setValuesIfInUpdateMode() {
        if(!this.box) return;

        this.inputForm.get("width")!.setValue(this.box.width);
        this.inputForm.get("height")!.setValue(this.box.height);
        this.inputForm.get("length")!.setValue(this.box.length);
        this.inputForm.get("weight")!.setValue(this.box.weight);
        this.inputForm.get("color")!.setValue(BoxColor[this.box.color]);
        this.inputForm.get("price")!.setValue(this.box.price);
    }

    submitForm() {
        if (!this.inputForm.valid) {
            console.error("Input form not valid", this.inputForm);
            return;
        }

        const updateObject: ModifyBox = {
            width:  this.inputForm.get("width")!.value,
            height: this.inputForm.get("height")!.value,
            length: this.inputForm.get("length")!.value,
            weight: this.inputForm.get("weight")!.value,
            color: BoxColor[this.inputForm.get("color")!.value as keyof typeof BoxColor],
            price: this.inputForm.get("price")!.value,
        };

        this.modalController.dismiss(updateObject);
    }

    cancel() {
        this.modalController.dismiss(null);
    }

    forceIntegers(event: any) {
        const inputValue = event.target.value;
        const numericValue = inputValue.replace(/[^0-9]/g, '');

        event.target.value = numericValue;
    }
}
