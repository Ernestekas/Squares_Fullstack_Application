import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CollectionsComponent } from './components/collections/collections.component';
import { SelectedCollectionComponent } from './components/selected-collection/selected-collection.component';
import { LoadedFileResultComponent } from './components/loaded-file-result/loaded-file-result.component';
import { SquaresResultComponent } from './components/squares-result/squares-result.component';

@NgModule({
  declarations: [
    AppComponent,
    CollectionsComponent,
    SelectedCollectionComponent,
    LoadedFileResultComponent,
    SquaresResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
