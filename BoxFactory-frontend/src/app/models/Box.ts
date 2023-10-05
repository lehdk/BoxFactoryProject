import { Pipe, PipeTransform } from "@angular/core";

export class Box {
  id: number;
  width: number;
  height: number;
  length: number;
  weight: number;
  color: BoxColor;
  price: number;
  createdAt: Date;

  constructor() {
    this.id = -1;
    this.width = -1;
    this.height = -1;
    this.length = -1;
    this.weight = -1;
    this.color = BoxColor.Red;
    this.price = -1;
    this.createdAt = new Date();
  }

  getVolume(): number {
    return this.width * this.height * this.length;
  }

  getSurfaceArea(): number {
    return(
        2 * this.length * this.width +
        2 * this.length * this.height +
        2 * this.width * this.height
    );
  }
}

export enum BoxColor {
  Red = 0,
  Blue = 1,
  Green = 2,
  Yellow = 3,
  Purple = 4,
  Orange = 5,
  Pink = 6,
  Brown = 7,
  Gray = 8,
  Teal = 9,
  Cyan = 10,
  Magenta = 11,
  Indigo = 12,
  Lavender = 13,
  Turquoise = 14,
  Maroon = 15,
}

@Pipe({name: 'boxColorDisplayName'})
export class BoxColorDisplayNamePipe implements PipeTransform {
    transform(value: BoxColor, ...args: any[]) {
        return BoxColor[value];
    }
}