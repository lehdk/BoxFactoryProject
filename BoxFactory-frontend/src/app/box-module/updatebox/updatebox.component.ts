import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { Box, BoxColor } from 'src/app/models/Box';
import { ModifyBox } from 'src/app/models/requestModels/ModifyBox';

@Component({
    selector: 'app-updatebox',
    templateUrl: './updatebox.component.html',
    styleUrls: ['./updatebox.component.scss'],
})
export class UpdateboxComponent implements OnInit {

    @Input() box: Box | null = null;

    public boxColorValues = Object.values(BoxColor).filter(value => typeof value !== 'number');

    inputForm: FormGroup;

    constructor(private modalController: ModalController) {
        this.inputForm = new FormGroup({
            width: new FormControl(),
            height: new FormControl(),
            length: new FormControl(),
            weight: new FormControl(),
            color: new FormControl(),
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
            color: BoxColor[this.inputForm.get("color")!.value as keyof typeof BoxColor]
        };

        this.modalController.dismiss(updateObject);
    }

    cancel() {
        this.modalController.dismiss(null);
    }
}
