import { Injectable } from '@angular/core';
import Point from '../Models/Point.model';
import Vector from '../Models/Vector.model';

@Injectable({
  providedIn: 'root'
})
export class SquareCalculatorService {
  public points: Point[] = [];
  private A: Point = {};
  private B: Point = {};
  private C: Point = {};

  constructor() { }

  public checkSquare(){
    for(let a = 0; a < this.points.length; a++){
      this.A = this.points[a];
      for(let b = 0; b < this.points.length; b++){
        if(this.points[b].id != this.A.id){
          this.B = this.points[b];
          for(let c = 0; c < this.points.length; c++){
            if(this.points[c].id != this.A.id && this.points[c].id != this.B.id){
              let AB: Vector = {};
              AB.x = this.B.x! - this.A.x!;
              AB.y = this.B.y! - this.A.y!;

              console.log(AB);
            }
          }
        }
      }
    }
  }
}
