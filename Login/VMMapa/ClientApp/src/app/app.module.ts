import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MapaComponent } from './mapa/mapa.component';
import { PalindromoComponent } from './palindromo/palindromo.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    MapaComponent,
    PalindromoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([{ path: 'mapa', component: MapaComponent, pathMatch: 'full' }, { path: 'palindromo', component: PalindromoComponent, pathMatch: 'full' }])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
