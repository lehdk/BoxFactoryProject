import {Component, OnInit} from '@angular/core';
import {BoxService} from "../services/box.service";
import {Box} from "../models/Box";

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit{

  boxes : Box[] = []
  constructor(private boxservice : BoxService) {}

  ngOnInit(): void {
    this.boxservice.getAllBoxes().subscribe(boxes =>{
      this.boxes=boxes;
    })
  }

}
