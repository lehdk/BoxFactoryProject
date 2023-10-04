import { Pipe, PipeTransform } from "@angular/core";

export type Box = {
  id: number;
  width: number;
  height: number;
  length: number;
  weight: number;
  color: BoxColor;
  createdAt: Date;
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