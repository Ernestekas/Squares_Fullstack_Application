import { Component, Input, OnInit } from '@angular/core';
import Collection from 'src/app/Models/Collection.model';
import {Modal} from 'bootstrap'
import * as bootstrap from 'bootstrap';
import Square from 'src/app/Models/Square.model';
import { SquaresService } from 'src/app/services/squares.service';
import SquaresCollection from 'src/app/Models/squares-collection.model';

@Component({
  selector: 'app-squares-result',
  templateUrl: './squares-result.component.html',
  styleUrls: ['./squares-result.component.scss']
})
export class SquaresResultComponent implements OnInit {
  @Input() importedCollectionForSquares: SquaresCollection = {};
  private squares: Square[] = [];
  // public squares: Square[] = [];
  private initChange: boolean = true;
  private changeChecked: boolean = true;

  constructor(private squaresService: SquaresService) { }

  ngOnInit(): void {
  }

  ngOnChanges(){
    if(!this.initChange && this.changeChecked){
      this.squaresService.post(this.importedCollectionForSquares).subscribe({
        next: (squares) => {
          console.log(squares);
        }
      })
    }

    if(this.initChange){
      this.initChange = false;
    }
    
  }
  // ngOnChanges(){
  //   if(this.changeChecked && !this.initChange){
  //     this.squaresService.post(this.importedCollectionForSquares).subscribe({
  //       next: (squares) => {
  //         this.squares = squares;
  //         console.log(squares);
  //       }
  //     })
  //     // let modal = new bootstrap.Modal(document.getElementById('squaresModal')!, {
  //     //   keyboard: false
  //     // })
  //     // modal.show();
  //   }

  //   if(this.initChange){
  //     this.initChange = false;
  //   }
  // }
}
