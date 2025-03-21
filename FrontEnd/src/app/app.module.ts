import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';  // Importar RouterModule desde angular/router

import { AppComponent } from './app.component';  // Importar el componente principal
import { HomeComponent } from './home/home.component';  // Importar el componente que vayas a usar

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,  // Asegúrate de declarar tu componente
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([])  // Configura el enrutamiento (aunque no tengas rutas todavía)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
