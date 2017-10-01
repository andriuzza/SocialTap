import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import {Location} from './location';
import { AppComponent } from './app.component';
import { AppInputComponent } from './app-input/app-input.component';
import { AppListComponent } from './app-list/app-list.component';
import { DetailsComponent } from './details/details.component';
import { HttpModule } from '@angular/http';
import {LocationData} from './http.injection';
import {RouterModule, Routes} from '@angular/router';

const appRoutes: Routes = [
 {path: 'list', component: AppListComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    AppInputComponent,
    AppListComponent,
    DetailsComponent,
  
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(
      appRoutes,
      {enableTracing: true}

    )
  ],
  providers: [LocationData],
  bootstrap: [AppComponent]
})
export class AppModule { }
