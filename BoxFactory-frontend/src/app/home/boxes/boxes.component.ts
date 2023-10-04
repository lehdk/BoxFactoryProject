import { Component, OnInit } from '@angular/core';
import { Box } from 'src/app/models/Box';
import { BoxService } from 'src/app/services/box.service';

@Component({
	selector: 'app-boxes',
	templateUrl: './boxes.component.html',
	styleUrls: ['./boxes.component.scss'],
})
export class BoxesComponent implements OnInit {

	boxes: Box[] = [];

	constructor(private boxservice: BoxService) { }

	ngOnInit(): void {
		this.boxservice.loadAllBoxes();

		this.boxservice.boxes.subscribe(newData => {
			this.boxes = newData;
		});
	}

	delete(id: number) {
		this.boxservice.delete(id);
	}
}
