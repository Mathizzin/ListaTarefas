// app.module.ts

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Importe o ReactiveFormsModule
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TarefaCadastrarComponent } from './pages/Tarefa/pages/tarefa/tarefa-cadastrar/tarefa-cadastrar.component';
import { TarefaListarComponent } from './pages/Tarefa/pages/tarefa/tarefa-listar/tarefa-listar.component'; // Certifique-se de importar o componente
import { CommonModule } from '@angular/common';
import { MenuComponent } from './pages/Tarefa/pages/tarefa/menu/menu/menu.component';
import { FooterComponent } from './pages/Tarefa/pages/tarefa/Footer/footer/footer.component';


@NgModule({
  declarations: [
    AppComponent,
    TarefaCadastrarComponent,
    TarefaListarComponent,
    MenuComponent,
    FooterComponent,
    // Outros componentes...
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule, // Adicione o ReactiveFormsModule aos imports
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
