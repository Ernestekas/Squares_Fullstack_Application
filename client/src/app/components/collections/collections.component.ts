import { Component, OnInit } from '@angular/core';
import Collection from 'src/app/Models/Collection.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-collections',
  templateUrl: './collections.component.html',
  styleUrls: ['./collections.component.scss']
})
export class CollectionsComponent implements OnInit {

  public collectionsInput: Collection[] = [];

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.sharedService.loadAll();

    this.sharedService.collections$.subscribe({
      next: (collectionsData) => {
        this.collectionsInput = collectionsData;
      },
      error: (response) => console.log(response.error),
      complete: () => console.log("Ok shared.")
    });
  }

  test() {
    console.log("Labas");
  }

}
