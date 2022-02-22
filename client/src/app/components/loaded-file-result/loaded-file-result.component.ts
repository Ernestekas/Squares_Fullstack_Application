import { Component, Input, OnInit } from '@angular/core';
import ImportedCollection from 'src/app/Models/imported-collection.model';
import {Modal} from 'bootstrap'
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-loaded-file-result',
  templateUrl: './loaded-file-result.component.html',
  styleUrls: ['./loaded-file-result.component.scss']
})
export class LoadedFileResultComponent implements OnInit {
  @Input() importedCollection: ImportedCollection = {failedEntries: [], importedPoints: [], failedValidation: []};

  private initChange: boolean = true;
  private changeChecked: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(){
    if(this.changeChecked && !this.initChange){
      let modal = new bootstrap.Modal(document.getElementById('reportModal')!, {
        keyboard: false
      })
      modal.show();
    }

    if(this.initChange){
      this.initChange = false;
    }
  }
}
