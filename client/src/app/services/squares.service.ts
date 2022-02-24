import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Collection from '../Models/Collection.model';
import SquaresCollection from '../Models/squares-collection.model';

@Injectable({
  providedIn: 'root'
})
export class SquaresService {
  private url: string = "https://localhost:44340/api/Squares/";

  constructor(private http: HttpClient) { }

  public post(collection: SquaresCollection): Observable<any>{
    return this.http.post(this.url, collection);
  }
}
