import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomePage } from './home.page';

import { HomePageRoutingModule } from './home-routing.module';
import { HttpClientModule } from "@angular/common/http";
import { BoxesComponent } from './boxes/boxes.component';
import { UpdateboxComponent } from './updatebox/updatebox.component';
import { BoxviewComponent } from './boxview/boxview.component';
import { BoxColorDisplayNamePipe } from '../models/Box';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        HomePageRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule
    ],
    declarations: [
        HomePage,
        BoxesComponent,
        UpdateboxComponent,
        BoxviewComponent,
        BoxColorDisplayNamePipe
    ]
})
export class HomePageModule { }
